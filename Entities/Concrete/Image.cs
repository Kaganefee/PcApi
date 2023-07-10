using Core.Entities.Abstract;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Image : IEntity
    {
        public int? ImageId { get; set; }
        public string? ImagePath { get; set; }
        public DateTime? Date { get; set; }
        public int ProductId { get; set; }

        [NotMapped]
        public IFormFile ImageFile { get; set; }

    }
}
