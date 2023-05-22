using System.Text.Json.Serialization;

namespace KurumsalWebVinc.Models.DTOs
{
	public class CustomResponseDto<T>
	{
		public T Data { get; set; }
		[JsonIgnore] // json dönüştürürken bunu ıgnore et çünkü postmande falan buna gerek yok
		public int StatusCode { get; set; }
		public List<string> Errors { get; set; }

		public static CustomResponseDto<T> Success(int statusCode, T data) //başarılı ise datayı da dön
		{
			return new CustomResponseDto<T> { StatusCode = statusCode, Data = data };
		}
		public static CustomResponseDto<T> Success(int statusCode) //sdace status kod dön update delete falan
		{
			return new CustomResponseDto<T> { StatusCode = statusCode };
		}
		public static CustomResponseDto<T> Fail(int statusCode, List<string> error) //sdace status kod dön update delete falan
		{
			return new CustomResponseDto<T> { StatusCode = statusCode, Errors = error };
		}

		public static CustomResponseDto<T> Fail(int statusCode, string error) //sdace status kod dön update delete falan
		{
			return new CustomResponseDto<T> { StatusCode = statusCode, Errors = new List<string> { error } };
		}

	}
}
