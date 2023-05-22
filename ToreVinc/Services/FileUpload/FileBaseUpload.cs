using KurumsalWebVinc.Models.DTOs;
using Microsoft.AspNetCore.Http;

using System.IO;
using System.Security.Policy;

namespace KurumsalWebVinc.Services.FileUpload
{
	public static class FileBaseUpload
	{




		public static bool Upload(IFormFile file, string source_path = "upload/images")
		{
			if (file == null || file.Length == 0)
				return false;
			if (file == null || file.Length > 5242880)
				return false;

			var extension = Path.GetExtension(file.FileName.Trim('.').ToLower());
			if (!new[] { "jpg", "png", "jpeg" }.Contains(extension))
				return false;

			var local_image_dir = $"{source_path}";
			var local_image_path = $"{local_image_dir}/{file.FileName}";

			if (!Directory.Exists(Path.Combine(local_image_dir)))
				Directory.CreateDirectory(local_image_dir);

			using (Stream fileStream = new FileStream(local_image_path, FileMode.Create))
			{
				file.CopyTo(fileStream);
			}



			return true;

		}

		public static ResimVeriDto Upload2(IFormFile file, string WebRootPath, string source_path = "upload/images")
		{
			if (file == null || file.Length == 0)
				return new ResimVeriDto { Aciklama = "Dosya Hatalı.", Durum = false };
			if (file == null || file.Length > 5242880)
				return new ResimVeriDto { Aciklama = "Dosya Hatalı.", Durum = false };

			var extension = Path.GetExtension(file.FileName.Trim('.').ToLower());
			if (!new[] { ".jpg", ".png", ".jpeg" }.Contains(extension))
				return new ResimVeriDto { Aciklama = "Tip Hatalı", Durum = false };

			ResimVeriDto r = new ResimVeriDto();

			string uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;
			r.FileName = uniqueFileName;
			var local_image_dir = $"{source_path}";
			var local_image_path = $"{local_image_dir}/{uniqueFileName}";
			r.Path = local_image_path;
			var local_image_path_full = $"{WebRootPath}/{local_image_dir}/{uniqueFileName}";
			if (!Directory.Exists(Path.Combine(local_image_dir)))
				Directory.CreateDirectory(local_image_dir);

			using (Stream fileStream = new FileStream(local_image_path_full, FileMode.Create))
			{
				file.CopyTo(fileStream);
				r.Durum = true;
			}



			return r;

		}

		public static async Task<UploadSuccessDto> HizliUpload(IFormFile upload, string source_path = "upload/images")
		{
			if (upload.Length <= 0) return new UploadSuccessDto { Uploaded = -1, Mesaj = "Dosya bulunamadı." };
			if (upload.Length >= 5242880) return new UploadSuccessDto { Uploaded = -1, Mesaj = "Dosya Boyutu 5 Mb geçemez." };
			var fileName = Guid.NewGuid() + Path.GetExtension(upload.FileName).ToLower();

			//save file under wwwroot/CKEditorImages folder

			var extension = Path.GetExtension(upload.FileName.Trim('.').ToLower());
			if (!new[] { ".jpg", ".png", ".jpeg" }.Contains(extension))
				return new UploadSuccessDto { Uploaded = -1, Mesaj = "Dosya Uzantısı Hatalı. Dosay Uzantısı  (jpg, png, jpeg) olmalıdır.  " };

			var filePath = Path.Combine(
				Directory.GetCurrentDirectory(), $"wwwroot/{source_path}",
				fileName);

			using (var stream = File.Create(filePath))
			{

				await upload.CopyToAsync(stream);

				var url = $"/{source_path}/{fileName}";
				var success = new UploadSuccessDto
				{
					Uploaded = 1,
					FileName = fileName,

					Url = url,
					Mesaj = "Dosya Yüklendi."
				};

				return success;
			}





		}
		public static async Task<UploadSuccessDto> HizliUploadPdf(IFormFile upload, string source_path = "upload/pdf")
		{
			if (upload.Length <= 0) return new UploadSuccessDto { Uploaded = -1, Mesaj = "Dosya bulunamadı." };
			if (upload.Length >= 15728640) return new UploadSuccessDto { Uploaded = -1, Mesaj = "Dosya Boyotu 15 MB fazla olamaz." };
			var fileName = Guid.NewGuid() + Path.GetExtension(upload.FileName).ToLower();

			//save file under wwwroot/CKEditorImages folder

			var extension = Path.GetExtension(upload.FileName.Trim('.').ToLower());
			if (!new[] { ".pdf" }.Contains(extension))
				return new UploadSuccessDto { Uploaded = -1, Mesaj = "Dosya Uzantısı Hatalı. Dosay Uzantısı  (jpg, png, jpeg) olmalıdır.  " };

			var filePath = Path.Combine(
				Directory.GetCurrentDirectory(), $"wwwroot/{source_path}",
				fileName);

			using (var stream = File.Create(filePath))
			{
				await upload.CopyToAsync(stream);
			}

			var url = $"/{source_path}/{fileName}";

			var success = new UploadSuccessDto
			{
				Uploaded = 1,
				FileName = fileName,

				Url = url,
				Mesaj = "Dosya Yüklendi."
			};

			return success;

		}


	}
}
