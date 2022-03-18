using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCodeFirst_Giris
{
    public class UygulamaDbContext : DbContext
    {
        public DbSet<Kisi> Kisiler { get; set; }
    }
}
