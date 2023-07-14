using Business.Abstract;
using Business.BussinessAspecs.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class PcManager : IPcService
    {
        IPcDal _pcdal;
        ICategoryService _categoryService;

        public PcManager(IPcDal pcdal, ICategoryService categoryService)
        {
            _pcdal = pcdal;
            _categoryService = categoryService;
        }

        [SecuredOperation("product.add,admin")]
        [ValidationAspect(typeof(PcValidator))]
        public IResult Add(Pc pc)
        {
            IResult result = BusinessRules.Run(CheckIfCategoryLimitExceded(), CheckIfProductCountOfCategoryCorrect(pc.CategoryId), CheckIfProductNameExists(pc.ProductName));

            if (result!=null)
            {
                return result;
            }
            _pcdal.Add(pc);
            return new SuccessDataResult<Pc>(PcMessages.PcAdded);
        }


        [SecuredOperation("admin")]
        public IResult Delete(Pc pc)
        {
            _pcdal.Delete(pc);
            return new SuccessDataResult<Pc>(PcMessages.PcDeleted);
        }


        [CacheAspect]
        public IDataResult<List<Pc>> GetAll()
        {
            return new SuccessDataResult<List<Pc>>(_pcdal.GetAll(),PcMessages.PcsListed);
        }


        [CacheAspect]
        public IDataResult<Pc> GetById(int id)
        {
            return new SuccessDataResult<Pc>(_pcdal.Get(p=>p.ProductId==id),PcMessages.PcListed);
        }


        [CacheAspect]
        public IDataResult<List<PcDetailDto>> GetPcDetails()
        {
            return new SuccessDataResult<List<PcDetailDto>>(_pcdal.GetPcDetails(),PcMessages.PcDetailed);
        }


        [SecuredOperation("admin")]
        [ValidationAspect(typeof(PcValidator))]
        [CacheRemoveAspect("IPoductService.Get")]
        public IResult Update(Pc pc)
        {
            if (pc == null)
            {
                return new ErrorResult(PcMessages.PcNotBeNull);
            }
            _pcdal.Update(pc);
            return new SuccessDataResult<Pc>(PcMessages.PcUpdated);
        }


        private IResult CheckIfProductCountOfCategoryCorrect(int CategoryId)
        {
            var result = _pcdal.GetAll(p => p.CategoryId == CategoryId).Count;

            if (result >= 15)
            {
                return new ErrorResult(PcMessages.ProductCountOfCategoryError);
            }
            return new SuccessResult();
        }

        private IResult CheckIfProductNameExists(string productname)
        {
            var result = _pcdal.GetAll(p => p.ProductName == productname).Any();
            if (result == true)
            {
                return new ErrorResult(PcMessages.ProductNameInvalid);
            }
            return new SuccessResult();
        }
        private IResult CheckIfCategoryLimitExceded()
        {
            var result = _categoryService.GetAll();
            if (result.Data.Count > 15)
            {
                return new ErrorResult();
            }
            return new SuccessResult();
        }
    }
}
