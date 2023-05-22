namespace KurumsalWebVinc.Models.DTOs
{
	public class KadromuzDto : BaseDto
	{

		public string Isim { get; set; }
		public string Uzmanlik { get; set; }
		public string Aciklama { get; set; }
		public string Resim { get; set; }
		public IFormFile ResimFile { get; set; }
		public string Twiter { get; set; }
		public string Facebok { get; set; }
		public string Instagram { get; set; }
		public string Google { get; set; }
		public string Mail { get; set; }
		public string SayfaUrl { get; set; }
		public int SayfaId { get; set; }




	}
}
