namespace KurumsalWebVinc.Models.ModelArac
{
	public class AracModel : BaseEntity
	{
		public int ModelKodu { get; set; }
		public string ModelAdi { get; set; }
		public AracMarka AracMarka { get; set; }
		public int AracMarkaKodu { get; set; }
		public ICollection<AracBilgisi> AracBilgisis { get; set; }
	}
}
