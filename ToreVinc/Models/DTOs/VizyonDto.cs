namespace KurumsalWebVinc.Models.DTOs
{
	public class VizyonDto : BaseEntity
	{
		public string Baslik { get; set; }
		public string Icerik { get; set; }
		public string Resim { get; set; }
		public IFormFile ResimFile { get; set; }
	}
}
