namespace KurumsalWebVinc.Models
{
	public class Blog : BaseEntity
	{
		public string BlogBaslik { get; set; }
		public string BlogAciklama { get; set; }
		public string BlogResim { get; set; }
		public string SayfaUrl { get; set; }
		public int SayfaId { get; set; }
		public BlogKategory BlogKategory { get; set; }
		public int BlogKategoryId { get; set; }

	}
}
