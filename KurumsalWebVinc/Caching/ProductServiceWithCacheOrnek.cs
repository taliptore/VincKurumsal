namespace KurumsalWebVinc.Caching
{
	public class ProductServiceWithCacheOrnek//:IProductService
	{
		/// <summary>
		/// nottt  **** cache data çok sık değişmeyecek ama çok sık kullanılacak data olması lazım **************** sık değişen datayı keşlemek mantıklı değil
		/// </summary>
		/* private const string CacheProductKey = "productsCache";
		 private readonly IMapper _mapper;
		 private readonly IMemoryCache _MemoryCache;
		 private readonly IProductRepository _repository;
		 private readonly IUnitOfWork _unitOfWork;

		 public ProductServiceWithCache(IMapper mapper, IMemoryCache memoryCache, IProductRepository repository, IUnitOfWork unitOfWork)
		 {
			 _mapper = mapper;
			 _MemoryCache = memoryCache;
			 _repository = repository;
			 _unitOfWork = unitOfWork;

			 //PROJE AYAĞA KALKERKEN KEŞLE
			 if (!_MemoryCache.TryGetValue(CacheProductKey, out _))
			 {
				 // kategoriz çekme
				 //_MemoryCache.Set(CacheProductKey, _repository.GetAll().ToList());
				 //kategorileri ile beraber kaşle
				 _MemoryCache.Set(CacheProductKey, _repository
					 .GetProductsWithCategory().Result);
			 }

		 }

		 public async Task<Product> AddAsync(Product entity)
		 {
			 await _repository.AddAsync(entity);
			 await _unitOfWork.CommitAsycn();
			 await CacheAllProductsAsync();
			 return entity;

		 }

		 public async Task<IEnumerable<Product>> AddRangeAsycn(IEnumerable<Product> entities)
		 {
			 await _repository.AddRangeAsycn(entities);
			 await _unitOfWork.CommitAsycn();
			 await CacheAllProductsAsync();
			 return entities;
		 }

		 public Task<bool> AnyAsync(Expression<Func<Product, bool>> expression)
		 {
			 throw new NotImplementedException();
		 }

		 public Task<IEnumerable<Product>> GetAllAsycn()
		 {
			 return Task.FromResult(_MemoryCache.Get<IEnumerable<Product>>(CacheProductKey));
		 }

		 public Task<Product> GetByIdAscy(int id)
		 {
			 var product = _MemoryCache.Get<List<Product>>(CacheProductKey)
				 .FirstOrDefault(x => x.Id == id);
			 if (product == null)
			 {
				 throw new NotFoundException($"{typeof(Product).Name} ({id}) Data Yok. (not found) - hata konumu:" +
					 $" {Assembly.GetExecutingAssembly().Location}  ");
			 }
			 return Task.FromResult(product);
		 }

		 public Task<CustomResponseDto<List<ProductsWithCategoryDto>>> GetProductsWithCategory()
		 {
			 var products = _MemoryCache.Get<IEnumerable<Product>>(CacheProductKey);
			 var productWithCategory = _mapper.Map<List<ProductsWithCategoryDto>>(products);
			 return Task.FromResult(CustomResponseDto<List<ProductsWithCategoryDto>>.Success(200, productWithCategory));
		 }

		 public async Task RomeveAsync(Product entity)
		 {
			 _repository.Romeve(entity);
			 await _unitOfWork.CommitAsycn();
			 await CacheAllProductsAsync();
		 }

		 public async Task RomeveRangeAsync(IEnumerable<Product> entities)
		 {
			 _repository.RomeveRange(entities);
			 await _unitOfWork.CommitAsycn();
			 await CacheAllProductsAsync();
		 }

		 public async Task UpdateAsync(Product entity)
		 {
			 _repository.Update(entity);
			 await _unitOfWork.CommitAsycn();
			 await CacheAllProductsAsync();
		 }

		 public IQueryable<Product> Where(Expression<Func<Product, bool>> expression)
		 {
			 return _MemoryCache.Get<List<Product>>(CacheProductKey)
				  .Where(expression.Compile()).AsQueryable();
		 }

		 public async Task CacheAllProductsAsync()
		 {
			 _MemoryCache.Set(CacheProductKey, await _repository.GetAll().ToListAsync());
		 }

		 public Task<List<ProductsWithCategoryDto>> GetProductsWithCategoryWeb()
		 {
			 var products = _MemoryCache.Get<IEnumerable<Product>>(CacheProductKey);
			 var productWithCategory = _mapper.Map<List<ProductsWithCategoryDto>>(products);
			 return Task.FromResult(productWithCategory);
		 }

		 public Task<IEnumerable<Product>> GetAllIncluding(params Expression<Func<Product, object>>[] includeProperties)
		 {
			 throw new NotImplementedException();
		 }
		*/
	}
}
