namespace KurumsalWebVinc.Models
{
	public class AltMenu : BaseEntity
	{
		public string AltMenuAdi { get; set; }
		public string AltMenuYol { get; set; }
		public int AltMenuSirasi { get; set; }
		public string AltMenuIcon { get; set; }
		public Menu Menu { get; set; }
		public int MenuId { get; set; }


	}
}
