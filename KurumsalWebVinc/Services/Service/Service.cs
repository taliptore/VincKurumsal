using KurumsalWebVinc.Models;
using KurumsalWebVinc.Repo.IRepositories;
using KurumsalWebVinc.Services.IService;
using KurumsalWebVinc.UnitOfWorks.IUnitOfWork;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace KurumsalWebVinc.Services.Service
{
	public class Service<T> : IService<T> where T : class
	{
		private readonly IGenericRepository<T> _repository;
		private readonly IUnitofWork _unitOfWork;

		public Service(IGenericRepository<T> repository, IUnitofWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
			_repository = repository;
		}

		public async Task<T> AddAsync(T entity)
		{

			await _repository.AddAsync(entity);
			await _unitOfWork.CommitAsycn();
			return entity;
		}


		public async Task<IEnumerable<T>> AddRangeAsycn(IEnumerable<T> entities)
		{
			await _repository.AddRangeAsycn(entities);
			await _unitOfWork.CommitAsycn();
			return entities;
		}

		public async Task<bool> AnyAsync(Expression<Func<T, bool>> expression)
		{
			return await _repository.AnyAsync(expression);
		}


		public async Task<IEnumerable<T>> GetAllAsycn()
		{
			return await _repository.GetAll().ToListAsync();
		}

		public async Task<IEnumerable<T>> GetAllIncluding(
			params Expression<Func<T, object>>[] includeProperties)
		{
			return await _repository.GetAllIncluding(includeProperties).ToListAsync();
		}

		public async Task<T> GetByIdAscy(int id)
		{
			var hasProduct = await _repository.GetByIdAscy(id);
			if (hasProduct == null)
			{
				//api için burası
				//  throw new NotFoundException($"{typeof(T).Name} ({id}) Kayıt Bulunamadı. Not Found");


			}
			return hasProduct;
		}

		public async Task RomeveAsync(T entity)
		{
			_repository.Romeve(entity);
			await _unitOfWork.CommitAsycn();
		}

		public async Task RomeveRangeAsync(IEnumerable<T> entities)
		{
			_repository.RomeveRange(entities);
			await _unitOfWork.CommitAsycn();
		}

		public async Task UpdateAsync(T entity)
		{

			_repository.Update(entity);
			await _unitOfWork.CommitAsycn();


		}

		public IQueryable<T> Where(Expression<Func<T, bool>> expression)
		{
			return _repository.Where(expression);
		}
	}
}
