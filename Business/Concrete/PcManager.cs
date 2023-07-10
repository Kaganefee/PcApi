using Business.Abstract;
using Business.BussinessAspecs.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
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
            _pcdal.Add(pc);
            return new SuccessDataResult<Pc>();
        }


        //[SecuredOperation("product.add,admin")]
        public IResult Delete(Pc pc)
        {
            _pcdal.Delete(pc);
            return new SuccessDataResult<Pc>();
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
        public IDataResult<List<PcDetailDto>> GetCarDetail()
        {
            return new SuccessDataResult<List<PcDetailDto>>(_pcdal.GetPcDetails(),PcMessages.PcDetailed);
        }


        [SecuredOperation("product.add,admin")]
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
    }
}
