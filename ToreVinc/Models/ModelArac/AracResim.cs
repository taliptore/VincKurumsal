namespace KurumsalWebVinc.Models.ModelArac
{
	public class AracResim
	{
		public int Id { get; set; }
		public string ResimYolu { get; set; }
		public bool Durum { get; set; }

		//public AracBilgisi  AracBilgisi { get; set; }
		public int AracBilgisiId { get; set; }
	}
}
