namespace KurumsalWebVinc.Models.ModelArac
{
	public class AracDurum : BaseAracEntity
	{
		public string AracinDurum { get; set; }

		public ICollection<AracBilgisi> AracBilgisis { get; set; }
	}
}
