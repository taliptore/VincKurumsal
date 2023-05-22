using FluentValidation;
using KurumsalWebVinc.Models;

namespace KurumsalWebVinc.Services.Validations
{
	public class TalepFormuValidator : AbstractValidator<TalepFormu>
	{
		public TalepFormuValidator()
		{
			RuleFor(x => x.Ad).NotNull().WithMessage("{PropertyName} is required (Boş olmaz) ")
				.NotEmpty().WithMessage("{PropertyName} is required (Boş olmaz) ");
			RuleFor(x => x.Soyad).NotNull().WithMessage("{PropertyName} is required (Boş olmaz) ")
				.NotEmpty().WithMessage("{PropertyName} is required (Boş olmaz) ");
			RuleFor(x => x.iletisimNo).NotNull().WithMessage("{PropertyName} is required (Boş olmaz) ")
				.NotEmpty().WithMessage("{PropertyName} is required (Boş olmaz) ");
			RuleFor(x => x.Adres).NotNull().WithMessage("{PropertyName} is required (Boş olmaz) ")
				.NotEmpty().WithMessage("{PropertyName} is required (Boş olmaz) ");
			RuleFor(x => x.Mesaj).NotNull().WithMessage("{PropertyName} is required (Boş olmaz) ")
				.NotEmpty().WithMessage("{PropertyName} is required (Boş olmaz) ");
			// RuleFor(x => x.Soyad).InclusiveBetween(1, int.MaxValue).WithMessage("{PropertyName} Menu Sıra 0(Sıfır) büyük olması gerekli! ");
		}
	}
}
