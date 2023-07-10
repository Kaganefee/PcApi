﻿using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    internal class CategoryValidator : AbstractValidator<Category>
    {
        public CategoryValidator() 
        {
            RuleFor(p=>p.CategoryName).NotEmpty();
            RuleFor(p=>p.CategoryId).Empty();
            RuleFor(p => p.CategoryName).MinimumLength(2);
        }
    }
}
