namespace KurumsalWebVinc.Models
{
	public class GenelBilgiler : BaseEntity
	{
		public string SiteAdresi { get; set; }
		public string SiteBasligi { get; set; }
		public string SiteAciklama { get; set; }
		public string SiteAnahtarKelime { get; set; }
		public string FirmaAdi { get; set; }
		public string SiteLogo { get; set; }
		public string SiteFavicon { get; set; }
		public string FiligramYazi { get; set; }
		public bool FiligramYaziEklensinmi { get; set; }
	}
}
