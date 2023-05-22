namespace KurumsalWebVinc.Models.DTOs
{
	public class HakkimizdaDto : BaseDto
	{
		public string Baslik { get; set; }
		public string Icerik { get; set; }
		public string Resim { get; set; }
		public IFormFile ResimFile { get; set; }
	}
}
