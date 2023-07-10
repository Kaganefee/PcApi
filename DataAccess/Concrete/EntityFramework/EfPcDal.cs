using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfPcDal : EfEntityRepositoryBase<Pc, PcApiDbContext>, IPcDal
    {
        public List<PcDetailDto> GetPcDetails()
        {
            using (PcApiDbContext context = new PcApiDbContext())
            {
                var result = from p in context.Pcs
                             join c in context.Categories
                             on p.CategoryId equals c.CategoryId
                             select new PcDetailDto
                             {
                                 CategoryName = c.CategoryName,
                                 Description = p.Description,
                                 ProductName = p.ProductName,
                             };
                return result.ToList();
            }
        }
    }
}
