using Business.Abstract;
using Core.Utilities.Results;
using Entities.Concrete;
using DataAccess.Abstract;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.BussinessAspecs.Autofac;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Helpers;
using Core.Aspects.Autofac.Caching;

namespace Business.Concrete
{
    public class ImageManager : IImageService
    {
        IImageDal _imageDal;

        public ImageManager(IImageDal imageDal)
        {
            _imageDal = imageDal;
        }


        [SecuredOperation("admin")]
        public IResult Add( Image image)
        {
            IResult result = BusinessRules.Run(CheckImageLimit(image.ImageId));
            if (result != null)
            {
                return result;
            }
            image.ImagePath = FileHelper.Add(image.ImageFile);
            image.Date = DateTime.Now;
            _imageDal.Add(image);
            return new SuccessResult(ImageMessages.ImageAdded);
        }


        [SecuredOperation("admin")]
        public IResult Delete(Image image)
        {
            var oldpath = Path.GetFullPath(_imageDal.Get(p => p.ImageId == image.ImageId).ImagePath);

            IResult result = BusinessRules.Run(
                FileHelper.Delete(oldpath));

            if (result != null)
            {
                return result;
            }

            _imageDal.Delete(image);
            return new SuccessResult();
        }


        [CacheAspect]
        public IDataResult<List<Image>> GetAll()
        {
            return new SuccessDataResult<List<Image>>(_imageDal.GetAll(), ImageMessages.ImagesListed);
        }


        [CacheAspect]
        public IDataResult<Image> GetById(int? id)
        {
            return new SuccessDataResult<Image>(_imageDal.Get(p => p.ImageId == id));
        }


        [CacheAspect]
        public IDataResult<List<Image>> GetImageByPcId(int? id)
        {
            return new SuccessDataResult<List<Image>>(CheckIfImageNull(id));
        }


        [SecuredOperation("admin")]
        public IResult Update( Image image)
        {
            image.ImagePath = Environment.CurrentDirectory + @"\" + FileHelper.Update(_imageDal.Get(p => p.ImageId == image.ImageId).ImagePath, image.ImageFile);
            image.Date = DateTime.Now;
            _imageDal.Update(image);
            return new SuccessResult(ImageMessages.ImageUpdated);
        }


        private IResult CheckImageExists(int? imageId)
        {
            var result = _imageDal.Get(i => i.ImageId == imageId);
            if (result == null)
            {
                return new ErrorResult(ImageMessages.ImageExistsError);
            }

            return new SuccessResult();
        }

        private IResult CheckImageLimit(int? imageId)
        {
            var result = _imageDal.GetAll(c => c.ImageId == imageId).Count;
            if (result >= 5)
            {
                return new ErrorResult(ImageMessages.ImageLimitError);
            }

            return new SuccessResult();
        }


        private List<Image> CheckIfImageNull(int? id)
        {
            var path = @"images\default.jpg";
            var result = _imageDal.GetAll(p=>p.ProductId == id).Any();
            if (!result)
            {
                return new List<Image> { new Image { ProductId = (int)id, ImagePath = path.Replace("\\", "/"), Date = DateTime.Now } };
            }
            return _imageDal.GetAll(p => p.ProductId == id);
        }
    }


}
