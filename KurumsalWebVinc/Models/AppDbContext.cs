using KurumsalWebVinc.Models.ModelArac;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace KurumsalWebVinc.Models
{
	public class AppDbContext : IdentityDbContext<AppUser, AppRole, string>
	{
		public AppDbContext(DbContextOptions<AppDbContext> dbContext) : base(dbContext)
		{ }
		/* alt kısımlar alınacak*/
		public DbSet<AltMenu> AltMenu { get; set; }
		public DbSet<Menu> Menus { get; set; }
		public DbSet<SlideModel> SlideModels { get; set; }
		public DbSet<Departman> Departmens { get; set; }
		public DbSet<CalismaSaatleri> CalismaSaatleris { get; set; }
		public DbSet<Kadromuz> Kadromuzs { get; set; }
		public DbSet<Servisler> Servislers { get; set; }
		public DbSet<ServisTalep> ServisTaleps { get; set; }
		public DbSet<GenelBilgiler> GenelBilgilers { get; set; }
		public DbSet<Icerik> Iceriks { get; set; }
		public DbSet<IletisimBilgisi> IletisimBilgisis { get; set; }
		public DbSet<MailAyarlari> MailAyarlaris { get; set; }
		public DbSet<SosyalMedyaBilgileri> SosyalMedyaBilgileris { get; set; }
		public DbSet<Resimler> Resimlers { get; set; }
		public DbSet<Videolar> Videolars { get; set; }

		public DbSet<Hakkimizda> Hakkimizdas { get; set; }
		public DbSet<Vizyon> Vizyons { get; set; }
		public DbSet<TalepFormu> TalepFormus { get; set; }
		public DbSet<SSS> SSSes { get; set; }
		public DbSet<Blog> Blogs { get; set; }
		public DbSet<BlogKategory> BlogKategories { get; set; }
		public DbSet<AppRole> AppRoles { get; set; }
		#region Aracparametreler
		public DbSet<AracMarka> AracMarkas { get; set; }
		public DbSet<AracModel> AracModels { get; set; }
		public DbSet<VitesTip> VitesTips { get; set; }
		public DbSet<YakitTipi> YakitTipis { get; set; }
		public DbSet<AracDurum> AracDurums { get; set; }
		public DbSet<MotorGucu> MotorGucus { get; set; }
		public DbSet<Kimden> Kimdens { get; set; }
		public DbSet<SehirilceBilgisi> SehirilceBilgisis { get; set; }
		public DbSet<SehirilBilgisi> SehirilBilgisis { get; set; }
		public DbSet<KasaTipi> kasaTipis { get; set; }
		public DbSet<AracRenk> AracRenks { get; set; }
		public DbSet<AracBilgisi> AracBilgisis { get; set; }
		public DbSet<AracResim> AracResims { get; set; }
		public DbSet<AracRapor> AracRapors { get; set; }
		public DbSet<Mesaj> Mesajs { get; set; }



		#endregion




		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{


			//model oluşurken yapılacaklar burada yazılır
			// tüm modellere bir seferede okuyup yazsın istersek 
			modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
			//eğer tek tek ben eklerim dersek
			//modelBuilder.ApplyConfiguration(new CategoryConfigration());
			// ama en iyisi yukardaki kendi hepsini bulup yapsın 



			base.OnModelCreating(modelBuilder);


		}

		public void CreateAndUpdateTime()
		{
			foreach (var item in ChangeTracker.Entries())
			{
				if (item.Entity is BaseEntity entityReference)//tipi tespşt ettik
				{
					switch (item.State)
					{
						case EntityState.Added:
							{
								entityReference.CreateDate = DateTime.Now;
								break;
							}
						case EntityState.Modified:
							{
								Entry(entityReference).Property(x => x.CreateDate).IsModified = false;
								entityReference.UpdateDate = DateTime.Now;
								break;
							}
					}

				}
			}
		}
		public override int SaveChanges()
		{
			CreateAndUpdateTime();
			return base.SaveChanges();
		}

		public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
		{// save cahnges model update veye crete olduğunu burda yakalarız

			CreateAndUpdateTime();
			return base.SaveChangesAsync(cancellationToken);
		}


	}
}
