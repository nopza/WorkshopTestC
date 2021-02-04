using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkshopTest.ViewModels;

namespace WorkshopTest.Validations
{
    public class ProductViewModelValidator : AbstractValidator<ProductViewModel>
    {
        public ProductViewModelValidator ()
        {
            RuleFor(x => x.SearchProductName).NotEmpty().WithMessage("Search cannot be null") ;
        }
    }
}
