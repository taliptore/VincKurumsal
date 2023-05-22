using System.Linq.Expressions;

namespace KurumsalWebVinc.Services.IService
{
	public interface IService<T> where T : class
	{
		Task<IEnumerable<T>> GetAllAsycn();
		Task<T> GetByIdAscy(int id);
		IQueryable<T> Where(Expression<Func<T, bool>> expression);
		Task<bool> AnyAsync(Expression<Func<T, bool>> expression);
		/// <summary>
		/// ilişkili tablo ile beraber verileri çağırma işlemi için yapılıdı
		/// </summary>
		/// <param name="GetAllIncluding">ilişkili properti alınacaksa</param>
		/// <returns></returns>
		Task<IEnumerable<T>> GetAllIncluding(params Expression<Func<T, object>>[] includeProperties);
		Task<T> AddAsync(T entity);
		Task<IEnumerable<T>> AddRangeAsycn(IEnumerable<T> entities);
		Task UpdateAsync(T entity); // update ve remove asyc olması yok EFCORE
		Task RomeveAsync(T entity);
		Task RomeveRangeAsync(IEnumerable<T> entities);
	}
}
