using FluentValidation;
using Sebo.Application.Commands.CreateChapter;

namespace Sebo.Application.Validators
{
    public class CreateChapterCommandValidator : AbstractValidator<CreateChapterCommand>
    {

        public CreateChapterCommandValidator()
        {

            RuleFor(chapter => chapter.MangaId)
                .NotEmpty()
                .WithMessage("Por favor informe o manga a qual o capítulo pertence");

            RuleFor(chapter => chapter.Title)
                .NotEmpty()
                .WithMessage("Por favor informe o título do capítulo");

        }

    }
}
