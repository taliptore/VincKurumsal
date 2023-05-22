namespace KurumsalWebVinc.Models.ModelArac
{
	public class AracRapor : BaseEntity
	{
		public string Baslik { get; set; }
		public string Aciklama { get; set; }
		public string RaporuDuzunleyenFirma { get; set; }
		public int AracBilgisiId { get; set; }
		public string RaporYolu { get; set; }
		public DateTime RaporVerilisTarihi { get; set; }


	}
}
