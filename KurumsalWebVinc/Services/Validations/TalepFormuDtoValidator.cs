using FluentValidation;
using KurumsalWebVinc.Models.DTOs;
using System.Text.RegularExpressions;

namespace KurumsalWebVinc.Services.Validations
{
	public class TalepFormuDtoValidator : AbstractValidator<TalepFormuDto>
	{
		public TalepFormuDtoValidator()
		{
			RuleFor(x => x.Ad).NotNull().WithMessage("{PropertyName} is required (Boş olmaz) ").NotEmpty().WithMessage("{PropertyName} is required (Boş olmaz) ");
			RuleFor(x => x.Soyad).NotNull().WithMessage("{PropertyName} is required (Boş olmaz) ").NotEmpty().WithMessage("{PropertyName} is required (Boş olmaz) ");
			RuleFor(x => x.Mesaj).NotNull().WithMessage("{PropertyName} is required (Boş olmaz) ").NotEmpty().WithMessage("{PropertyName} is required (Boş olmaz) ");
			RuleFor(x => x.Mail).NotNull().WithMessage("{PropertyName} is required (Boş olmaz) ").NotEmpty().WithMessage("{PropertyName} is required (Boş olmaz) ")
				.EmailAddress().WithMessage("{PropertyName} Adresi formatı uygun değil.");
			//RuleFor(x => x.iletisimNo).NotNull().WithMessage("{PropertyName} is required (Boş olmaz) ").NotEmpty().WithMessage("{PropertyName} is required (Boş olmaz) ");
			RuleFor(x => x.GuvenlikKodu).NotNull().WithMessage("{PropertyName} is required (Boş olmaz) ").NotEmpty().WithMessage("{PropertyName} is required (Boş olmaz) ");
			//{PropertyName}  yazarsak  x.Name name adını direk o kısma getiryor uyarı daha düzgün görülüyor.
			// RuleFor(x => x.MenuAdi).NotNull().WithMessage("{PropertyName} is required (Boş olmaz) ").NotEmpty().WithMessage("{PropertyName} is required (Boş olmaz) ");
			//RuleFor(x => x.MenuSirasi).InclusiveBetween(1, int.MaxValue).WithMessage("{PropertyName} Menu Sıra 0(Sıfır) büyük olması gerekli! ");



			//RuleFor(x => x.CategoriId).NotNull().WithMessage(" Kategori is required (Boş olmaz) ")
			//.NotEmpty().WithMessage("Kategori is required (Boş olmaz) ")
			//.InclusiveBetween(1, int.MaxValue).WithMessage("Lütfen Kategori seçiniz "); ;

		}
	}
}
