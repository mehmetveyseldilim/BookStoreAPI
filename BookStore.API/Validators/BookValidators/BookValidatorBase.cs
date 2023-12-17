using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Domain.Request;
using FluentValidation;

namespace BookStore.API.Validators.BookValidators
{

    public abstract class BookValidatorBase<T> : AbstractValidator<T> where T : BookManipulationDTO 
    {
        public BookValidatorBase()
        {
            RuleFor(x => x.Title)
                .NotEmpty()
                .MaximumLength(100)
                .WithMessage("Title cannot exceed 100 characters");

            RuleFor(x => x.ReleaseDate).NotEmpty();
        }
    }
}