using DevFreela.Application.Commands.CreateComment;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Validators
{
    public class CreateCommentCommandValidator : AbstractValidator<CreateCommentCommand>
    {
        public CreateCommentCommandValidator()
        {
            RuleFor(c => c.Content)
                .MaximumLength(255)
                .WithMessage("Tamanho máximo de 255 caracteres");

            RuleFor(c => c.Content)
                .MinimumLength(50)
                .WithMessage("Tamanho mínimo de 50 caracteres");
        }
    }
}
