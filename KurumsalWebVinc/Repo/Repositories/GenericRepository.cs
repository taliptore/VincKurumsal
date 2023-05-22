using KurumsalWebVinc.Models;
using KurumsalWebVinc.Repo.IRepositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.Linq.Expressions;

namespace KurumsalWebVinc.Repo.Repositories
{
	public class GenericRepository<T> : IGenericRepository<T> where T : class
	{
		protected readonly AppDbContext _context;
		private readonly DbSet<T> _dbset;

		public GenericRepository(AppDbContext context)
		{
			_context = context;
			_dbset = _context.Set<T>();
		}

		public async Task AddAsync(T entity)
		{
			await _dbset.AddAsync(entity);

		}

		public async Task AddRangeAsycn(IEnumerable<T> entities)
		{
			await _dbset.AddRangeAsync(entities);
		}

		public async Task<bool> AnyAsync(Expression<Func<T, bool>> expression)
		{
			return await _dbset.AnyAsync(expression);
		}

		public IQueryable<T> GetAll()
		{
			/*AsNoTracking yazma amacı veriye çek ama ram alma ram alırsa sürekli takip ettiği için performans düşüklüğü oluyor. */
			return _dbset.AsNoTracking().AsQueryable();
		}

		public IQueryable<T> GetAllIncluding(
			params Expression<Func<T, object>>[] includeProperties)
		{
			IQueryable<T> queryable = _dbset;
			if (includeProperties != null)
			{
				foreach (Expression<Func<T, object>> includeProperty in includeProperties)
				{

					queryable = queryable.Include(includeProperty);
				}
			}

			/*AsNoTracking yazma amacı veriye çek ama ram alma ram alırsa sürekli takip ettiği için performans düşüklüğü oluyor. */
			return queryable.AsNoTracking().AsQueryable();
		}




		public async Task<T> GetByIdAscy(int id)
		{
			return await _dbset.FindAsync(id);
		}


		public void Romeve(T entity)
		{
			_dbset.Remove(entity);
		}

		public void RomeveRange(IEnumerable<T> entities)
		{
			_dbset.RemoveRange(entities);
		}

		public void Update(T entity)
		{
			_dbset.Update(entity);
		}

		public IQueryable<T> Where(Expression<Func<T, bool>> expression)
		{
			return _dbset.Where(expression);
		}

	}
}
