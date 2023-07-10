﻿using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IPcService
    {
        IDataResult<List<Pc>> GetAll();
        IDataResult<Pc> GetById(int id);
        IResult Add(Pc pc);
        IResult Update(Pc pc);
        IResult Delete(Pc pc);
        IDataResult<List<PcDetailDto>> GetCarDetail();
    }
}
