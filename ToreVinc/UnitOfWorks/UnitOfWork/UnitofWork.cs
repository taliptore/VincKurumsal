using KurumsalWebVinc.Models;
using KurumsalWebVinc.UnitOfWorks.IUnitOfWork;

namespace KurumsalWebVinc.UnitOfWorks.UnitOfWork
{
	public class UnitofWork : IUnitofWork
	{
		private readonly AppDbContext _context;

		public UnitofWork(AppDbContext context)
		{
			_context = context;
		}

		public void Commit()
		{
			_context.SaveChanges();
		}

		public async Task CommitAsycn()
		{
			await _context.SaveChangesAsync();

		}
	}
}
