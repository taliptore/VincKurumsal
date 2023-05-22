using System.ComponentModel.DataAnnotations;

namespace KurumsalWebVinc.Models.DTOs
{
	public class LoginDto
	{
		[Display(Name = "E-Posta Adresiniz")]
		[Required(ErrorMessage = "E-posta alanı gereklidir")]
		[EmailAddress]
		public string Email { get; set; }

		[Display(Name = "Şifreniz")]
		[Required(ErrorMessage = "Şifre alanı gereklidir")]
		[DataType(DataType.Password)]
		[MinLength(6, ErrorMessage = "şifreniz en az 6 karakter olmalıdır")]
		public string Password { get; set; }

		public bool RememberMe { get; set; }
	}
}
