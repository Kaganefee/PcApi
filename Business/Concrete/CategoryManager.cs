using Business.Abstract;
using Business.BussinessAspecs.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        [SecuredOperation("product.add,admin")]
        [ValidationAspect(typeof(CategoryValidator))]
        public IResult Add(Category category)
        {
            _categoryDal.Add(category);
            return new SuccessDataResult<Category>(category,CategoryMessages.CategoryAdded);
        }


        [SecuredOperation("product.add,admin")]
        public IResult Delete(Category category)
        {
            _categoryDal.Delete(category);
            return new SuccessDataResult<Category>(CategoryMessages.CategoryDeleted);
        }

        [CacheAspect]
        public IDataResult<List<Category>> GetAll()
        {
            return new SuccessDataResult<List<Category>>(_categoryDal.GetAll(),CategoryMessages.CategoryListed);
        }

        [CacheAspect]
        public IDataResult<Category> GetById(int id)
        {
            return new SuccessDataResult<Category>(_categoryDal.Get(p=>p.CategoryId==id));
        }

        [CacheRemoveAspect("IPoductService.Get")]
        [SecuredOperation("product.add,admin")]
        public IResult Update(Category category)
        {
            if (category ==null)
            {
                return new ErrorResult(CategoryMessages.CategoryNotBeNull);
            }
            _categoryDal.Update(category);
            return new SuccessDataResult<Category>(CategoryMessages.CategoryUpdated);
        }



    }
}
