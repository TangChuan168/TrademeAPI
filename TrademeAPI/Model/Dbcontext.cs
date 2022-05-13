using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrademeAPI.Model
{
    public class Dbcontext: DbContext
    {
        public virtual DbSet<Categories> Categories { get; set; }
        //public virtual DbSet<Product> Products { get; set; }

        public virtual DbSet<User> Users { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql("server=47.74.86.28;port=3306;user=dbuser;password=MI4m481OuUJ1D9KijI921KFMRFHndvNi;database=TradeMeCrawler", Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.1.48-mariadb"));
            }

        }
    }
}
