using BookStore.Domain.Request;
using FluentValidation;

namespace BookStore.API.Validators.BookValidators
{
    public class CreateBookValidator : BookValidatorBase<BookCreateDTO> 
    {
        public CreateBookValidator()
        {
            

            RuleFor(x => x.AuthorId).NotEmpty();

            RuleFor(x => x.GenreId).NotEmpty();

          
        }
    }
}