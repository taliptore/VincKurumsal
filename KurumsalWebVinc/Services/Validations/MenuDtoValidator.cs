using FluentValidation;
using KurumsalWebVinc.Models;

namespace KurumsalWebVinc.Services.Validations
{
	public class MenuDtoValidator : AbstractValidator<Menu>
	{
		public MenuDtoValidator()
		{
			//{PropertyName}  yazarsak  x.Name name adını direk o kısma getiryor uyarı daha düzgün görülüyor.
			RuleFor(x => x.MenuAdi).NotNull().WithMessage("{PropertyName} is required (Boş olmaz) ").NotEmpty().WithMessage("{PropertyName} is required (Boş olmaz) ");
			RuleFor(x => x.MenuSirasi).InclusiveBetween(1, int.MaxValue).WithMessage("{PropertyName} Menu Sıra 0(Sıfır) büyük olması gerekli! ");



			//RuleFor(x => x.CategoriId).NotNull().WithMessage(" Kategori is required (Boş olmaz) ")
			//.NotEmpty().WithMessage("Kategori is required (Boş olmaz) ")
			//.InclusiveBetween(1, int.MaxValue).WithMessage("Lütfen Kategori seçiniz "); ;

		}
	}
}
