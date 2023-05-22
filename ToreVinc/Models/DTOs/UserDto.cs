using KurumsalWebVinc.Enums;
using System.ComponentModel.DataAnnotations;

namespace KurumsalWebVinc.Models.DTOs
{
	public class UserDto
	{
		[Required(ErrorMessage = "Kullanıcı ismi gereklidir")]
		[Display(Name = "Kullanıcı Adı")]
		public string UserName { get; set; }

		[Display(Name = "Tel No")] //regexr.com eklenti formatı
								   //[RegularExpression(@"^(0(\d{3}) (\d{3}) (\d{2}) (\d{2}))$", ErrorMessage = "Telefon numarası uygun formatta değil")]
		public string PhoneNumber { get; set; }

		[Required(ErrorMessage = "E-posta adresi gereklidir")]
		[Display(Name = "E-posta")]
		[EmailAddress(ErrorMessage = "E-posta adresiniz doğru formatta değil")]
		public string Email { get; set; }

		[Required(ErrorMessage = "Şifre gereklidir")]
		[Display(Name = "Şifre")]
		[DataType(DataType.Password)]
		public string Password { get; set; }

		[Display(Name = "Doğum Tarihi")]
		[DataType(DataType.Date)]
		public DateTime? BirtDay { get; set; }
		public string Picture { get; set; }
		[Display(Name = "Şehir")]
		public string City { get; set; }
		[Display(Name = "Cinsiyet")]
		public Gender Gender { get; set; }
	}
}
