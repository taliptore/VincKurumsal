
namespace KurumsalWebVinc.Models.ModelArac
{
	public class AracMarka : BaseEntity
	{
		public int MarkaKodu { get; set; }
		public string MarkaAdi { get; set; }

		public List<AracModel> AracModels { get; }
		public ICollection<AracBilgisi> AracBilgisis { get; set; }
	}
}
