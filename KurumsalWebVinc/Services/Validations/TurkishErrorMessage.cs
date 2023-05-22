using Microsoft.AspNetCore.Identity;

namespace KurumsalWebVinc.Services.Validations
{
	public class TurkishErrorMessage : IdentityErrorDescriber
	{
		public override IdentityError InvalidUserName(string userName)
		{
			return new IdentityError()
			{
				Code = "InvalidUserName",
				Description = $"Bu {userName} geçersizdir."
			};
		}
		public override IdentityError DuplicateEmail(string email)
		{
			return new IdentityError()
			{
				Code = "DuplicateEmail",
				Description = $"Bu eposta adresi ({email}) kullanılmaktadır."
			};
		}
		public override IdentityError PasswordTooShort(int length)
		{
			return new IdentityError()
			{
				Code = "PasswordTooShort",
				Description = $"şifreniz en az {length} karakterli olmalıdır."
			};
		}
		public override IdentityError DuplicateUserName(string userName)
		{
			return new IdentityError()
			{
				Code = "DuplicateUserName",
				Description = $"Bu kullanıcı adı ({userName}) kullanılmaktadır."
			};
		}
	}
}
