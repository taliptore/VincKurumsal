using KurumsalWebVinc.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KurumsalWebVinc.Repo.Configurations
{
	internal class MenuConfigurations : IEntityTypeConfiguration<Menu>
	{// ef core detaylı tablo ayarlama işlemi
		public void Configure(EntityTypeBuilder<Menu> builder)
		{
			builder.HasKey(x => x.Id);
			builder.Property(x => x.Id).UseIdentityColumn();
			builder.Property(x => x.MenuAdi).IsRequired().HasMaxLength(100);
			builder.ToTable("Menus");
		}

	}
}
