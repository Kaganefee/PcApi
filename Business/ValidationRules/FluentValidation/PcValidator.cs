using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class PcValidator :AbstractValidator<Pc>
    {
        public PcValidator() 
        {
            RuleFor(p=>p.ProductName).NotEmpty();
            RuleFor(p => p.ProductName).MinimumLength(5);
            RuleFor(p => p.ProductName).MaximumLength(500);
            RuleFor(p=>p.CategoryId).NotEmpty();
            RuleFor(p=>p.Description).NotEmpty();
            RuleFor(p=>p.Description).MinimumLength(5);
            RuleFor(p=>p.Description).MaximumLength(500);
            
        }
    }
}
