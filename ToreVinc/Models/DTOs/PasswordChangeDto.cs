using System.ComponentModel.DataAnnotations;

namespace KurumsalWebVinc.Models.DTOs
{
	public class PasswordChangeDto
	{
		[Display(Name = "Eski Şifreniz")]
		[Required]
		[DataType(DataType.Password)]
		[MinLength(4, ErrorMessage = "Şifreniz en az 4 karakter olmalıdır")]
		public string PasswordOld { get; set; }

		[Display(Name = "Yeni Şifreniz")]
		[Required(ErrorMessage = "Yeni şifre gereklidir")]
		[DataType(DataType.Password)]
		[MinLength(6, ErrorMessage = "Şifreniz en az 6 karakter olmalıdır")]
		public string PasswordNew { get; set; }

		[Display(Name = "Onay Şifreniz")]
		[Required(ErrorMessage = "Onay şifreniz gereklidir")]
		[DataType(DataType.Password)]
		[MinLength(6, ErrorMessage = "Şifreniz en az 6 karakter olmalıdır")]
		[Compare("PasswordNew", ErrorMessage = "Yeni şifreniz ve onay şifreniz birbirinden farklıdır")]
		public string PasswordConfirm { get; set; }
	}
}
