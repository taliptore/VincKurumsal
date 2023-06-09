using KurumsalWebVinc.Models;
using Microsoft.EntityFrameworkCore;
using ToreVinc.Models.Muhasebe;

namespace ToreVinc.Models
{
    public class DbContextMuhasebe:DbContext
    {
        public DbContextMuhasebe(DbContextOptions<DbContextMuhasebe> dbContext): base(dbContext)
        {
            
        }
        public DbSet<TBL_KULLANICIBILGI> TBL_KULLANICIBILGI { get; set; }
    }
}
