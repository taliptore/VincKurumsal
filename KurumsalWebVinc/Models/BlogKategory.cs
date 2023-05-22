namespace KurumsalWebVinc.Models
{
	public class BlogKategory : BaseEntity
	{
		public string Adi { get; set; }
		public ICollection<BlogKategory> BlogKategories { get; set; }

	}
}
