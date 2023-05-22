using Autofac;
using KurumsalWebVinc.Models;
using KurumsalWebVinc.Repo.IRepositories;
using KurumsalWebVinc.Repo.Repositories;
using KurumsalWebVinc.Services.IService;
using KurumsalWebVinc.Services.Mapping;
using KurumsalWebVinc.Services.Service;
using KurumsalWebVinc.UnitOfWorks.IUnitOfWork;
using KurumsalWebVinc.UnitOfWorks.UnitOfWork;
using System.Reflection;
using Module = Autofac.Module;

namespace KurumsalWebVinc.AutofacModules
{
	public class RepoServiceModule : Module
	{
		protected override void Load(ContainerBuilder builder)
		{

			// builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
			builder.RegisterGeneric(typeof(GenericRepository<>)).As(typeof(IGenericRepository<>))
				 .InstancePerLifetimeScope();
			//builder.Services.AddScoped(typeof(IService<>), typeof(Service<>));
			builder.RegisterGeneric(typeof(Service<>)).As(typeof(IService<>))
				 .InstancePerLifetimeScope();
			//bunları aç sonra
			//builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
			builder.RegisterType<UnitofWork>().As<IUnitofWork>();


			var apiAssembly = Assembly.GetExecutingAssembly();
			var repoAssembly = Assembly.GetAssembly(typeof(AppDbContext));
			var serviceAssembly = Assembly.GetAssembly(typeof(MapProfile));


			builder.RegisterAssemblyTypes(apiAssembly, repoAssembly, serviceAssembly)
				.Where(x => x.Name.EndsWith("Repository"))
				.AsImplementedInterfaces()
				.InstancePerLifetimeScope();
			//InstancePerLifetimeScope=>scope
			//InstancePerDependency=>Transient
			builder.RegisterAssemblyTypes(apiAssembly, repoAssembly, serviceAssembly)
			   .Where(x => x.Name.EndsWith("Service"))
			   .AsImplementedInterfaces()
			   .InstancePerLifetimeScope();

			//builder.RegisterType<ProductServiceWithCache>()
			//    .As<IProductService>();
			// keşleme iptal 
		}
	}
}
