namespace KurumsalWebVinc.Models.DTOs
{
	public class ServislerDto : BaseDto
	{
		public string ServisAdi { get; set; }
		public string ServisAciklama { get; set; }
		public string ServisResim { get; set; }
		public IFormFile ServisResimFile { get; set; }
		public string ServisUrl { get; set; }
		public int SayfaId { get; set; }
	}
}
