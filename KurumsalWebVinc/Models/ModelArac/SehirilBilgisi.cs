namespace KurumsalWebVinc.Models.ModelArac
{
	public class SehirilBilgisi : BaseAracEntity
	{
		public int ilKod { get; set; }
		public string ilAdi { get; set; }
		public ICollection<AracBilgisi> AracBilgisis { get; set; }

	}
}
