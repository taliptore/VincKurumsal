namespace KurumsalWebVinc.Models
{
	public class SlideModel : BaseEntity
	{
		public string Baslik { get; set; }
		public string Aciklama { get; set; }
		public string Resim { get; set; }
		public string Video { get; set; }
		public DateTime BaslamaTarihi { get; set; }
		public DateTime BitisTarihi { get; set; }

	}
}
