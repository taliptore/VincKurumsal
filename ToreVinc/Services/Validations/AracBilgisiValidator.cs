using FluentValidation;
using KurumsalWebVinc.Models;

namespace KurumsalWebVinc.Services.Validations
{
	public class AracBilgisiValidator : AbstractValidator<AracBilgisi>
	{
		public AracBilgisiValidator()
		{
			RuleFor(x => x.Baslik).NotNull()
				.WithMessage("{PropertyName} alanı boş geçilemez ")
				.NotEmpty().WithMessage("{PropertyName} alanı boş geçilemez ");
			RuleFor(x => x.Aciklama).NotNull()
				.WithMessage("{PropertyName} alanı boş geçilemez ")
				.NotEmpty().WithMessage("{PropertyName} alanı boş geçilemez ");

			RuleFor(x => x.Yil).NotNull()
				.WithMessage("{PropertyName} alanı boş geçilemez ")
				.NotEmpty().WithMessage("{PropertyName} alanı boş geçilemez ");

			RuleFor(x => x.Fiyat).NotNull()
				.WithMessage("{PropertyName} alanı boş geçilemez ")
				.NotEmpty().WithMessage("{PropertyName} alanı boş geçilemez ")
				;
			RuleFor(x => x.KM).NotNull()
				.WithMessage("{PropertyName} alanı boş geçilemez ")
				.NotEmpty().WithMessage("{PropertyName} alanı boş geçilemez ")
				;

		}
	}
}
