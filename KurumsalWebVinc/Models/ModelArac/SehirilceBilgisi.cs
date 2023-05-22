namespace KurumsalWebVinc.Models.ModelArac
{
	public class SehirilceBilgisi : BaseAracEntity
	{
		public int ilceKodu { get; set; }
		public string ilceAdi { get; set; }
		public int ilKod { get; set; }
		public ICollection<AracBilgisi> AracBilgisis { get; set; }
	}
}
