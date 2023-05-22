namespace KurumsalWebVinc.Models.DTOs
{
	public class ResimlerDto : BaseDto
	{
		public string Baslik { get; set; }
		public string Aciklama { get; set; }
		public string Path { get; set; }
		public string FileName { get; set; }

		public List<IFormFile> Resimler { get; set; }
		public IFormFile TekResim { get; set; }



	}
}
