namespace KurumsalWebVinc.Models
{
	public class Servisler : BaseEntity
	{
		public string ServisAdi { get; set; }
		public string ServisAciklama { get; set; }
		public string ServisResim { get; set; }
		public string ServisUrl { get; set; }
		public int SayfaId { get; set; }


	}
}
