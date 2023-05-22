namespace KurumsalWebVinc.Models
{
	public class Mesaj : BaseEntity
	{
		public string UserIdGonderen { get; set; }
		public AracBilgisi AracBilgisi { get; set; }
		public int AracBilgisiId { get; set; }
		public string Icerik { get; set; }
		public bool Okundu { get; set; }

	}
}
