namespace KurumsalWebVinc.Models
{
	public class Icerik : BaseEntity
	{
		public string Baslik { get; set; }
		public string Yazar { get; set; }
		public string KisaYazi { get; set; }
		public string Url { get; set; }
		public string KucukResim { get; set; }
		public string Metin { get; set; }
		public string SeoBaslik { get; set; }
		public string SeoAciklama { get; set; }
		public string Etiket { get; set; }
		public int MenuId { get; set; }

		public int AltMenuId { get; set; }
		public bool SayfaMi { get; set; }





	}
}
