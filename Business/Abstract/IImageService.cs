using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface  IImageService
    {
        IDataResult<List<Image>> GetAll();
        IDataResult<List<Image>> GetImageByPcId(int? id);
        IResult Add(Image image);
        IResult Update(Image image);
        IResult Delete(Image image);
        IDataResult<Image> GetById(int? id);
    }
}
