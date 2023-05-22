namespace KurumsalWebVinc.Models
{
	public class MailAyarlari : BaseEntity
	{
		public string MailSmtp { get; set; }
		public string MailAdres { get; set; }
		public string MailSifre { get; set; }
		public string SmtpPort { get; set; }
	}
}
