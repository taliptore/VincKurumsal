namespace KurumsalWebVinc.Models.DTOs
{
	public abstract class BaseDto
	{
		public int Id { get; set; }
		public bool Durum { get; set; }
		public string CreateUserId { get; set; }
		public DateTime CreateDate { get; set; }
		public string UpdateUserId { get; set; }
		public DateTime? UpdateDate { get; set; }
		public bool IsDeleted { get; set; }
		public string IsDeletedUserId { get; set; }
		public DateTime? IsDeleteDate { get; set; }
	}
}
