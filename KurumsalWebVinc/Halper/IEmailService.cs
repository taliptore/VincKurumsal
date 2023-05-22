using KurumsalWebVinc.Migrations;
using System.Net.Mail;
using System.Net;
using KurumsalWebVinc.Services.IService;
using KurumsalWebVinc.Models;

namespace KurumsalWebVinc.Halper
{
	public interface IEmailService
	{
		void Send(string to, string subject, string html, string from = null);
		void SendEmailDogrulama(string link, string email);
	}
	public class EmailService : IEmailService
	{
		protected readonly IService<MailAyarlari> _appSettings;

		public EmailService(IService<MailAyarlari> appSettings)
		{
			_appSettings = appSettings;
		}

		public void Send(string to, string subject, string html, string from = null)
		{
			var veri = _appSettings.GetAllAsycn().Result.FirstOrDefault();
			if (veri is not null)
			{
				if (to == "Admin@example.com") //eksperyap@gmail.com
				{
					to = "eksperyap@gmail.com";
				}
				if (to == "") //eksperyap@gmail.com
				{
					to = "eksperyap@gmail.com";
				}
				var clientTEST = new SmtpClient(veri.MailSmtp.Trim().ToString(), int.Parse(veri.SmtpPort.Trim().ToString()));
				MailMessage mail = new MailMessage();
				mail.From = new MailAddress(veri.MailAdres.Trim().ToString());
				mail.To.Add(to);
				mail.Subject = subject.Trim().ToString();
				mail.Body = html.Trim().ToString();
				mail.IsBodyHtml = true;
				clientTEST.EnableSsl = false;
				clientTEST.UseDefaultCredentials = false;
				clientTEST.Credentials = new NetworkCredential(veri.MailAdres.Trim().ToString(), veri.MailSifre.Trim().ToString());
				clientTEST.DeliveryMethod = SmtpDeliveryMethod.Network;
				clientTEST.Send(mail);
				mail.Dispose();
			}
			// create message

		}
		public void SendEmailDogrulama(string link, string email)
		{
			var veri = _appSettings.GetAllAsycn().Result.FirstOrDefault();
			if (veri != null)
			{
				MailMessage mail = new MailMessage();
				var smtpClient = new SmtpClient(veri.MailSmtp.Trim().ToString(), int.Parse(veri.SmtpPort.Trim().ToString()));
				mail.From = new MailAddress(veri.MailAdres);//Kimden gidecek
				mail.To.Add(email); //Kime gidecek
				mail.Subject = $"{veri.MailAdres}::Şifre Sıfırlama";
				mail.Body = "<h2>E-posta adresinizi doğrulamak için lütfen aşağıdaki linke tıklayınız</h2><hr/>";
				mail.Body += "<br> Bu adres Eksperyap.com tarafınızdan e-posta doğrulamak için gönderilmiştir.";
				mail.Body += "<br> Doğrulama işlemi yaptıktan sonra sisteme login olabilirsiniz.";
				mail.Body += $"<a href='{link}'> eposta doğrulama linki</a>";
				mail.IsBodyHtml = true;
				smtpClient.EnableSsl = false;
				smtpClient.UseDefaultCredentials = false;
				smtpClient.Port = int.Parse(veri.SmtpPort.Trim().ToString());
				smtpClient.Credentials = new NetworkCredential(veri.MailAdres.Trim().ToString(), veri.MailSifre.Trim().ToString());
				smtpClient.Send(mail);
			}
		}
	}
}
