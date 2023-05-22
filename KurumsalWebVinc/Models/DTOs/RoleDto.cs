using System.ComponentModel.DataAnnotations;

namespace KurumsalWebVinc.Models.DTOs
{
	public class RoleDto
	{
		[Display(Name = "Role ismi")]
		[Required(ErrorMessage = "Role ismi gereklidir")]
		public string Name { get; set; }

		public string Id { get; set; }
	}
}
