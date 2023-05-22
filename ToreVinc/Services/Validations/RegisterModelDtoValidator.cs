using FluentValidation;
using KurumsalWebVinc.Models.DTOs;

namespace KurumsalWebVinc.Services.Validations
{
	public class RegisterModelDtoValidator : AbstractValidator<RegisterModelDto>
	{
		public RegisterModelDtoValidator()
		{
			RuleFor(x => x.Email).NotNull().WithMessage("{PropertyName} Alanı Boş Geçilemez");
			RuleFor(x => x.Password).NotNull().WithMessage("{PropertyName} Alanı Boş Geçilemez");
			RuleFor(x => x.UserName).NotNull().WithMessage("{PropertyName} Alanı Boş Geçilemez");
		}
	}
}
