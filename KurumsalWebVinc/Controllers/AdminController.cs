using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Net.Mail;
using System.Net;
using Microsoft.AspNetCore.Hosting.Server;
using KurumsalWebVinc.Migrations;
using KurumsalWebVinc.Services.FileUpload;
using KurumsalWebVinc.Models;
using KurumsalWebVinc.Models.DTOs;
using KurumsalWebVinc.Services.IService;
using KurumsalWebVinc.Halper;
using KurumsalWebVinc.Enums;

namespace KurumsalWebVinc.Controllers
{
	[Authorize(Roles = "Admin,Üye")]
	public class AdminController : BaseController
	{
		protected readonly IService<MailAyarlari> _mail;
		protected readonly IService<TalepFormu> _talep;
		protected readonly IService<AracBilgisi> _aracsay;
		protected readonly IService<Servisler> _hizmet;
		protected readonly IService<Icerik> _icerik;
		protected readonly IEmailService _mailyolla;

		public AdminController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<AppRole> roleManager, IMapper mapper, IService<MailAyarlari> mail, IService<TalepFormu> talep, IService<AracBilgisi> aracsay, IService<Servisler> hizmet, IService<Icerik> icerik, IEmailService mailyolla)
			: base(userManager, signInManager, roleManager, mapper)
		{
			_mail = mail;
			_talep = talep;
			_aracsay = aracsay;
			_hizmet = hizmet;
			_icerik = icerik;
			_mailyolla = mailyolla;
		}
		public async Task<ActionResult> Index()
		{
			TempData["Menu"] = "dashbord";
			// TempData["dropdown"] = "Genel";
			AppUser appUser = await userManager.FindByNameAsync(CurrentUser.UserName);
			IList<string> roles;
			roles = await userManager.GetRolesAsync(appUser);

			if (roles.FirstOrDefault().ToString() == "Admin")
			{
				return RedirectToAction("IndexAdmin");
			}

			// this.HttpContext.Items["UserName"] = "dsf";
			//var username= this.HttpContext.User.Identity.Name;

			// HttpContext.Session.SetString("CurrentUser", userManager.FindByNameAsync(User.Identity.Name).Result.UserName);
			// HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
			//HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();


			// var user = await manager.FindAsync(username, passwort);
			// CurrentUser.Email
			//ApplicationUserManager userManager = HttpContext.GetOwinContext().GetUserManager();
			// var user = _httpContextAccessor.HttpContext?.User.Identity.Name;
			//TempData["KulaniciSay"] = userManager.Users.Count();
			//var veri = await _talep.GetAllAsycn();
			//var al = veri.Where(x=>x.Durum=true);
			//TempData["Talepsay"]= al.Count();
			return RedirectToAction("IndexUye");
		}
		[Authorize(Roles = "Admin")]
		public async Task<ActionResult> IndexAdmin()
		{

			// this.HttpContext.Items["UserName"] = "dsf";
			//var username= this.HttpContext.User.Identity.Name;

			// HttpContext.Session.SetString("CurrentUser", userManager.FindByNameAsync(User.Identity.Name).Result.UserName);
			// HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
			//HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();


			// var user = await manager.FindAsync(username, passwort);
			// CurrentUser.Email
			//ApplicationUserManager userManager = HttpContext.GetOwinContext().GetUserManager();
			// var user = _httpContextAccessor.HttpContext?.User.Identity.Name;
			TempData["KulaniciSay"] = userManager.Users.Count();
			var veri = await _talep.GetAllAsycn();
			var al = veri.Where(x => x.Durum = true);
			TempData["Talepsay"] = al.Count();

			#region ilansay
			var arac = await _aracsay.GetAllAsycn();
			TempData["Aracsay"] = arac.Where(x => x.Durum == true && x.CreateDate.AddDays(35) > DateTime.Now).Count();
			#endregion
			#region hizmet
			var hizmet = await _hizmet.GetAllAsycn();
			TempData["Hizmetsay"] = hizmet.Where(x => x.Durum == true).Count();
			#endregion
			#region icerik
			var icerik = await _icerik.GetAllAsycn();
			TempData["iceriksay"] = icerik.Where(x => x.Durum == true).Count();
			#endregion


			return View();
		}
		[Authorize(Roles = "Üye")]
		public ActionResult IndexUye()
		{

			// this.HttpContext.Items["UserName"] = "dsf";
			//var username= this.HttpContext.User.Identity.Name;

			// HttpContext.Session.SetString("CurrentUser", userManager.FindByNameAsync(User.Identity.Name).Result.UserName);
			// HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
			//HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();


			// var user = await manager.FindAsync(username, passwort);
			// CurrentUser.Email
			//ApplicationUserManager userManager = HttpContext.GetOwinContext().GetUserManager();
			// var user = _httpContextAccessor.HttpContext?.User.Identity.Name;
			//TempData["KulaniciSay"] = userManager.Users.Count();
			//var veri = await _talep.GetAllAsycn();
			//var al = veri.Where(x => x.Durum = true);
			//TempData["Talepsay"] = al.Count();
			return View();
		}





		#region Login İşlemleri
		//LOGIN
		[AllowAnonymous]
		public IActionResult Login(string ReturnUrl)
		{
			//kullanıcının login olmadan önce gezdiği sayfaya otomatik yönlendirme yapılacak
			TempData["ReturnUrl"] = ReturnUrl;
			return View();
		}
		[AllowAnonymous]
		[HttpPost]
		public async Task<IActionResult> Login(LoginDto userlogin)
		{
			if (ModelState.IsValid)
			{
				//Böyle bir kullanıcı var mı
				AppUser user = await userManager.FindByEmailAsync(userlogin.Email);
				if (user != null)
				{
					if (await userManager.IsLockedOutAsync(user))
					{
						ModelState.AddModelError("", "Hesabınız bir süreliğine kilitlenmiştir. Lütfen daha sonra tekrar deneyiniz.");
						return View(userlogin);
					}
					//eposta doğrulanmış mı?
					if (userManager.IsEmailConfirmedAsync(user).Result == false)
					{
						ModelState.AddModelError("", "Eposta adresiniz onaylanmamıştır. Lütfen eposta adresinizi kontrol ediniz.");
						return View(userlogin);
					}
					await signInManager.SignOutAsync();
					Microsoft.AspNetCore.Identity.SignInResult result = await signInManager.PasswordSignInAsync(user, userlogin.Password, userlogin.RememberMe, false);
					if (result.Succeeded)
					{
						AppUser appUser = userManager.FindByNameAsync(user.UserName).Result;
						TempData["UserName"] = appUser.UserName;
						TempData["UserId"] = appUser.Id;
						TempData["Userimg"] = appUser.Picture;

						_mailyolla.Send(appUser.Email, "Sisteme Giriş Bilgilendirmesi ", "Sisteme Giriş Mesajı:Eksperli Arabam Sitesine Giriş Yaptınız" +
							" <br> Giriş Bilgisi:" + DateTime.Now.ToString() + " İlginiz için teşekkür ederiz. <br>" +
							" İyi günler.");

						await userManager.ResetAccessFailedCountAsync(user);//geçersiz girişleri sıfırla
						if (TempData["ReturnUrl"] != null)
						{
							return Redirect(TempData["ReturnUrl"].ToString());
						}
						//TempData["UserName"] = userManager.FindByNameAsync(user.UserName).Result.UserName ;
						//TempData["UserName"] = CurrentUser.UserName;


						return RedirectToAction("Index", "Home");
					}
					else
					{
						await userManager.AccessFailedAsync(user);//başarısız girişi 1 artır
						int fail = await userManager.GetAccessFailedCountAsync(user);
						ModelState.AddModelError("", $"{fail} kez başarısız giriş");
						if (fail == 3)
						{
							await userManager.SetLockoutEndDateAsync(user, new DateTimeOffset(DateTime.Now.AddMinutes(20)));
							ModelState.AddModelError("", "Hesabınız 3 başarısız girişten dolayı 20dk süreyle kilitlenmiştir. Lütfen daha sonra tekrar deneyiniz");
							return View(userlogin);
						}
						else
						{
							ModelState.AddModelError("", "Eposta adresiniz veya şifreniz yanlış.");
						}
					}
				}
				else
				{
					ModelState.AddModelError("", "Bu eposta adresine kayıtlı kullanıcı bulunamamıştır.");
				}

			}
			return View(userlogin);
		}
		#endregion

		#region Kullanıcı Kayıt İşlemleri
		//KAYIT OL
		[AllowAnonymous]
		public IActionResult SignUp()
		{
			TempData["dropdown"] = "kullanici";
			TempData["Menu"] = "SignUpmenu";
			return View();
		}
		[AllowAnonymous]
		[HttpPost]
		public async Task<IActionResult> SignUp(UserDto userDto)
		{
			if (ModelState.IsValid)
			{
				if (userManager.Users.Any(x => x.PhoneNumber == userDto.PhoneNumber))
				{
					ModelState.AddModelError("", "Bu telefon numarası kullanılmaktadır.");
					return View(userDto);
				}


			}
			else
			{

				//foreach (var item in ModelState)
				//{
				//     ModelState.AddModelError("", item.Key);
				//   // ModelState.AddModelError(string.Empty, item.Key);
				//    //return View(genelBilgiler);
				//}
				return View(userDto);
			}
			AppUser user = new AppUser();
			user.UserName = userDto.UserName;
			user.Email = userDto.Email;
			user.PhoneNumber = userDto.PhoneNumber;
			// user.EmailConfirmed = true;

			IdentityResult result = await userManager.CreateAsync(user, userDto.Password);
			string[] rolesUye = new string[] { "Üye" };
			var addrole = await userManager.AddToRolesAsync(user, rolesUye);

			if (result.Succeeded)
			{
				//eposta doğrulama
				string confirmationToken = await userManager.GenerateEmailConfirmationTokenAsync(user); //doğrulama tokenı
				string link = Url.Action("ConfirmEmail", "Admin", new
				{
					userId = user.Id,
					token = confirmationToken
				}, protocol: HttpContext.Request.Scheme
				);
				// burayı gercek sistemde ayarla ****************
				_mailyolla.SendEmailDogrulama(link, user.Email);//kullanıcıya eposta gönderildi              
				return RedirectToAction("Login");
			}
			else
			{
				AddModelError(result);
			}
			return View(userDto);

		}

		[AllowAnonymous]
		//[HttpPost]
		public async Task<IActionResult> ConfirmEmail(string userId, string token)
		{
			var user = await userManager.FindByIdAsync(userId);
			IdentityResult result = await userManager.ConfirmEmailAsync(user, token);
			if (result.Succeeded)
			{
				ViewBag.status = "Email adresiniz onaylanmıştır. Login ekranından giriş yapabilirsiniz. " + userId;
			}
			else
			{
				ViewBag.status = "Bir hata meydana geldi. Lütfen daha sonra tekrar deneyiniz. " + userId;
			}
			return View();
		}
		#endregion

		#region Rol İşlemleri
		//Kullanıcı Listesi
		[Authorize(Roles = "Admin")]
		public IActionResult Users()
		{
			TempData["dropdown"] = "kullanici";
			TempData["Menu"] = "usersmenu";
			return View(userManager.Users.ToList());
		}

		//Rol Oluştur Ekranı
		[Authorize(Roles = "Admin")]
		public IActionResult RoleCreate()
		{
			return View();
		}
		//Rol Oluşturma
		[Authorize(Roles = "Admin")]
		[HttpPost]
		public IActionResult RoleCreate(RoleDto roleDto)
		{
			AppRole role = new AppRole();
			role.Name = roleDto.Name;
			IdentityResult result = roleManager.CreateAsync(role).Result;
			if (result.Succeeded)
			{
				return RedirectToAction("Roles");
			}
			else
			{
				AddModelError(result);//base deki methodum
			}

			return View(roleDto);
		}
		//Rol Listesi
		[Authorize(Roles = "Admin")]
		public IActionResult Roles()
		{
			TempData["dropdown"] = "kullanici";
			TempData["Menu"] = "rolesmenu";
			return View(roleManager.Roles.ToList());
		}
		//Rol Silme
		[Authorize(Roles = "Admin")]
		public IActionResult RoleDelete(string id)
		{
			AppRole role = roleManager.FindByIdAsync(id).Result;
			if (role != null)
			{
				IdentityResult result = roleManager.DeleteAsync(role).Result;
			}
			return RedirectToAction("Roles");
		}
		//Rol Güncelleme Ekranı
		[Authorize(Roles = "Admin")]
		public IActionResult RoleUpdate(string id)
		{
			AppRole role = roleManager.FindByIdAsync(id).Result;
			if (role != null)
			{

				return View(_mapper.Map<RoleDto>(role));
			}
			return RedirectToAction("Roles");
		}
		//Rol Güncelleme
		[Authorize(Roles = "Admin")]
		[HttpPost]
		public IActionResult RoleUpdate(RoleDto roleDto)
		{
			AppRole role = roleManager.FindByIdAsync(roleDto.Id).Result;
			if (role != null)
			{
				role.Name = roleDto.Name;
				IdentityResult result = roleManager.UpdateAsync(role).Result;
				if (result.Succeeded)
				{
					return RedirectToAction("Roles");
				}
				else
				{
					AddModelError(result);
				}
			}
			else
			{
				ModelState.AddModelError("", "Güncelleme işlemi başarısız oldu");
			}
			return View(roleDto);
		}
		[Authorize(Roles = "Admin")]
		public IActionResult RoleAssign(string id)
		{
			AppUser user = userManager.FindByIdAsync(id).Result;
			ViewBag.userName = user.UserName;
			TempData["userIdRol"] = id;//rol atama için kullanılacak
			IQueryable<AppRole> roles = roleManager.Roles;
			List<string> userroles = userManager.GetRolesAsync(user).Result as List<string>;
			List<RoleAssignDto> roleAssignDto = new List<RoleAssignDto>();
			foreach (var role in roles)
			{
				RoleAssignDto r = new RoleAssignDto();
				r.RoleId = role.Id;
				r.RoleName = role.Name;
				if (userroles.Contains(role.Name))
				{//kullanıcı o role sahip ise checkbox işaretle                    
					r.Exist = true;
				}
				else
				{
					r.Exist = false;
				}
				roleAssignDto.Add(r);
			}
			return View(roleAssignDto);
		}
		[Authorize(Roles = "Admin")]
		[HttpPost]
		public async Task<IActionResult> RoleAssign(List<RoleAssignDto> roleAssignDto)
		{
			var veri = TempData["userIdRol"];
			AppUser user = userManager.FindByIdAsync(veri.ToString()).Result;//Kullanıcıyı bul//kucuk büyük harfden dolayı güncellendi
			foreach (var item in roleAssignDto)
			{
				if (item.Exist)
				{
					await userManager.AddToRoleAsync(user, item.RoleName);
				}
				else
				{
					await userManager.RemoveFromRoleAsync(user, item.RoleName);
				}

			}
			return RedirectToAction("Users");
		}
		#endregion

		#region Kullanıcı İşlemleri
		public IActionResult PasswordChange()
		{
			return View();
		}
		[HttpPost]
		public IActionResult PasswordChange(PasswordChangeDto passwordChangeDto, string id)
		{
			if (ModelState.IsValid)
			{
				AppUser user = userManager.FindByIdAsync(id).Result;
				bool exist = userManager.CheckPasswordAsync(user, passwordChangeDto.PasswordOld).Result;
				if (exist)
				{
					IdentityResult result = userManager.ChangePasswordAsync(user, passwordChangeDto.PasswordOld, passwordChangeDto.PasswordNew).Result;
					if (result.Succeeded)
					{
						userManager.UpdateSecurityStampAsync(user);
						signInManager.SignOutAsync();
						signInManager.PasswordSignInAsync(user, passwordChangeDto.PasswordNew, true, false);
						ViewBag.success = "true";
					}
					else
					{
						AddModelError(result);
					}
				}
				else
				{
					ModelState.AddModelError("", "Eski Şifreniz Yanlış");
				}
			}
			return View(passwordChangeDto);
		}

		public IActionResult UserEdit(string id)
		{
			AppUser user = userManager.FindByIdAsync(id).Result;
			ViewBag.Gender = new SelectList(Enum.GetNames(typeof(Gender)));
			UserDto userDto = _mapper.Map<UserDto>(user);// user.Adapt<UserDto>();//user daki bilgileri userDto ya doldur
			return View(userDto);
		}

		[HttpPost]
		public async Task<IActionResult> UserEdit(UserDto userDto, IFormFile userPicture, string id)
		{
			ModelState.Remove("Password");
			if (ModelState.IsValid)
			{
				AppUser user = userManager.FindByIdAsync(id).Result;
				//Kullanıcı Tel No değiştirmiş mi değiştirmemiş mi
				string phone = userManager.GetPhoneNumberAsync(user).Result;
				if (phone != userDto.PhoneNumber)
				{
					if (userManager.Users.Any(u => u.PhoneNumber == userDto.PhoneNumber))
					{
						ModelState.AddModelError("", "Bu telefon numarası kullanılmaktadır.");
						return View(userDto);
					}
				}
				//resmi kaydedelim
				if (userPicture is not null)
				{
					if (userPicture.Length > 0)
					{

						var resim = await FileBaseUpload.HizliUpload(userPicture);
						if (resim.Uploaded == 1)
						{
							user.Picture = resim.Url;
						}
						if (resim.Uploaded == -1)
						{

							ModelState.AddModelError("Resim", "Resim Hatalı");
							return View(userDto);

						}
					}
				}

				user.UserName = userDto.UserName;
				if (user.Email == "Admin@example.com")
				{
					user.Email = userDto.Email;
				}

				user.PhoneNumber = userDto.PhoneNumber;
				user.City = userDto.City;
				user.Gender = (int)userDto.Gender;

				IdentityResult result = await userManager.UpdateAsync(user);
				if (result.Succeeded)
				{
					await userManager.UpdateSecurityStampAsync(user);
					await signInManager.SignOutAsync();
					await signInManager.SignInAsync(user, true);
					ViewBag.success = "true";
				}
				else
				{
					AddModelError(result);
				}
			}

			return RedirectToAction(nameof(Users));
		}
		#endregion

		#region Delete
		public IActionResult UserDelete(string id)
		{
			AppUser user = userManager.FindByIdAsync(id).Result;
			ViewBag.Gender = new SelectList(Enum.GetNames(typeof(Gender)));
			UserDto userDto = _mapper.Map<UserDto>(user);// user.Adapt<UserDto>();//user daki bilgileri userDto ya doldur
			return View(userDto);
		}

		[HttpPost]
		public async Task<IActionResult> UserDelete(UserDto userDto, string id)
		{
			AppUser user = userManager.FindByIdAsync(id).Result;
			await userManager.DeleteAsync(user);

			return RedirectToAction(nameof(Users));
		}
		#endregion

		[AllowAnonymous]
		public IActionResult LogOut()
		{
			signInManager.SignOutAsync();
			return RedirectToAction("Index", "Home");
		}

		#region Eposta
		[Authorize(Roles = "Admin")]
		// GET: AdminController/Edit/5
		public async Task<IActionResult> EpostaEdit()
		{
			TempData["dropdown"] = "Genel";
			TempData["Menu"] = "EpostaEdit";
			var veri = await _mail.GetAllAsycn();
			var mail = veri.FirstOrDefault();
			return View(mail);
		}
		[Authorize(Roles = "Admin")]
		// POST: AdminController/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> EpostaEdit(int id, MailAyarlari mailAyarlari)
		{
			try
			{
				if (ModelState.IsValid)
				{

					var veri = await _mail.GetByIdAscy(id);
					if (veri is null)
					{
						await _mail.AddAsync(mailAyarlari);
						@TempData["Alert"] = "Kayıt Eklendi.";
					}
					else
					{
						veri.SmtpPort = mailAyarlari.SmtpPort;
						veri.Durum = true;
						veri.MailAdres = mailAyarlari.MailAdres;
						veri.MailSifre = mailAyarlari.MailSifre;
						veri.MailSmtp = mailAyarlari.MailSmtp;
						veri.Id = id;
						await _mail.UpdateAsync(veri);
						@TempData["Alert"] = "Kayıt Güncellendi.";
					}

				}
				return RedirectToAction(nameof(EpostaEdit));
			}
			catch
			{
				return View(mailAyarlari);
			}
		}

		public void SendEmail(string email, string mesaj = "", string baslik = "")
		{

			var veri = _mail.GetAllAsycn().Result.FirstOrDefault();
			if (veri != null)
			{
				_mailyolla.Send(email, baslik, mesaj);
				try
				{
					var clientTEST = new SmtpClient(veri.MailSmtp.Trim().ToString(), int.Parse(veri.SmtpPort.Trim().ToString()));
					MailMessage mail = new MailMessage();
					mail.From = new MailAddress(veri.MailAdres.Trim().ToString());
					mail.To.Add(email);
					mail.Subject = baslik.Trim().ToString();
					mail.Body = mesaj.Trim().ToString();
					mail.IsBodyHtml = true;
					clientTEST.EnableSsl = false;
					clientTEST.UseDefaultCredentials = false;
					clientTEST.Credentials = new NetworkCredential(veri.MailAdres.Trim().ToString(), veri.MailSifre.Trim().ToString());
					clientTEST.DeliveryMethod = SmtpDeliveryMethod.Network;
					clientTEST.Send(mail);
					mail.Dispose();
					Response.WriteAsync("Mesaj iletildi! clientTEST.EnableSsl = false; ");

				}
				catch (Exception EX)
				{

					Response.WriteAsync("hata : " + EX);
				}




				/*
                try
                {
                    // E-posta gönderen hesap bilgileri
                    var fromAddress = new MailAddress("gnet@eksperyap.com", "gnet@eksperyap.com");
                    var fromPassword = "uy3Bm722~";

                    // E-posta alıcı adresi
                    var toAddress = new MailAddress("taliptr55@gmail.com", "taliptr55@gmail.com");

                    // E-posta konusu ve içeriği
                    const string subject = "Başlık ";
                    const string body = " İçerik dföşöfsd dfsdfsdf  465";

                    // SMTP sunucu ayarları
                    var smtp = new SmtpClient
                    {
                        Host = "mt-engine-win.guzelhosting.com",
                        Port = 587,
                        EnableSsl = false,
                        DeliveryMethod = SmtpDeliveryMethod.Network,
                        UseDefaultCredentials = false,
                        Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
                    };

                    var smtp2 = new SmtpClient
                    {
                        Host = "mt-engine-win.guzelhosting.com",
                        Port = 587,
                        EnableSsl = false,
                        DeliveryMethod = SmtpDeliveryMethod.Network,
                        UseDefaultCredentials = true,
                        Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
                    };

                    var smtp3 = new SmtpClient
                    {
                        Host = "mt-engine-win.guzelhosting.com",
                        Port = 587,
                        EnableSsl = false,
                        DeliveryMethod = SmtpDeliveryMethod.Network,
                        UseDefaultCredentials = false,
                        Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
                    };

                    // E-posta gönderme işlemi
                    
                      Response.WriteAsync("Mesaj başlıyor!");
                    using (var message = new MailMessage(fromAddress, toAddress)
                    {
                        Subject = subject,
                        Body = body
                    })
                    {
                        try
                        {
                            smtp3.SendMailAsync(message);
                            Response.WriteAsync("Mesaj iletildi! smt await");
                            //smtp3.SendMailAsync(message).Wait(); ;
                            //Console.WriteLine("Mesaj iletildi! smt await");

                        }
                        catch (Exception ex)
                        {
                            Response.WriteAsync(ex.Message);

                        }
                        try
                        {
                            smtp.SendMailAsync(message);
                            Response.WriteAsync("Mesaj iletildi! smt await");

                            //smtp.SendMailAsync(message).Wait();
                            //Console.WriteLine("Mesaj iletildi! smt ");

                        }
                        catch (Exception ex)
                        {
                            Response.WriteAsync(ex.Message);

                        }
                        try
                        {
                            smtp2.SendMailAsync(message);
                            Response.WriteAsync("Mesaj iletildi! smt1 await");

                            //smtp2.SendMailAsync(message).Wait();
                            //Console.WriteLine("Mesaj iletildi! smt2 ");
                        }
                        catch (Exception ex)
                        {

                            Response.WriteAsync(ex.Message);
                        }


                    }

                    Response.WriteAsync("Mesaj iletildi1!");
                  //  Console.ReadKey();
                }
                catch (Exception ex)
                {
                    // E-posta gönderirken bir hata oluşursa hatayı yakalayın
                    Response.WriteAsync(ex.Message);
                }
                */


				/*
                using (var client = new SmtpClient(veri.MailSmtp, 587))
                {

                    MailMessage mail = new MailMessage();
                    mail.From = new MailAddress(veri.MailAdres);
                    mail.To.Add(email);
                    mail.Subject = baslik;
                    mail.Body = mesaj;
                    mail.IsBodyHtml = true;

                    client.UseDefaultCredentials = false;
                    client.Credentials = new NetworkCredential(veri.MailAdres, veri.MailSifre);
                    client.EnableSsl = false;
                  //  client.DeliveryMethod = SmtpDeliveryMethod.Network;
                   // System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
                    client.Send(mail);

                    mail.Dispose();



                };
                */









			}

		}

		public void SendEmailDogrulama(string link, string email)
		{

			var veri = _mail.GetAllAsycn().Result.FirstOrDefault();
			if (veri != null)
			{

				try
				{
					MailMessage mail = new MailMessage();
					var smtpClient = new SmtpClient(veri.MailSmtp.Trim().ToString(), int.Parse(veri.SmtpPort.Trim().ToString()));
					mail.From = new MailAddress(veri.MailAdres);//Kimden gidecek
					mail.To.Add(email); //Kime gidecek
					mail.Subject = $"{veri.MailSmtp}::Şifre Sıfırlama";
					mail.Body = "<h2>E-posta adresinizi doğrulamak için lütfen aşağıdaki linke tıklayınız</h2><hr/>";
					mail.Body += $"<a href='{link}'> eposta doğrulama linki</a>";
					mail.IsBodyHtml = true;
					smtpClient.Port = int.Parse(veri.SmtpPort.Trim().ToString());
					smtpClient.Credentials = new NetworkCredential(veri.MailAdres.Trim().ToString(), veri.MailSifre.Trim().ToString());
					smtpClient.Send(mail);

				}
				catch (Exception EX)
				{

					Response.WriteAsync("hata : " + EX);
				}






			}

		}
		public ActionResult MailYolla()
		{
			TempData["Menu"] = "Mail";
			return View();
		}

		// POST: KadroController/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult MailYolla(MailDto mail)
		{
			SendEmail(mail.email, mail.Mesaj, mail.Baslik);

			return View();
		}

		#endregion
	}
}
