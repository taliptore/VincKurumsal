namespace KurumsalWebVinc.Models
{
	public class Menu : BaseEntity
	{
		public string MenuAdi { get; set; }
		public string MenuYol { get; set; }
		public int MenuSirasi { get; set; }

		public string MenuIcon { get; set; }

		public bool AdminMenusuMu { get; set; }

		public ICollection<AltMenu> AltMenus { get; set; }



	}
}
