using Microsoft.EntityFrameworkCore;
using ProjectDobavljac.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectDobavljac
{
    public class DomainModelPostgreSqlContext : DbContext
    {
        public DomainModelPostgreSqlContext(DbContextOptions<DomainModelPostgreSqlContext> options) : base(options)
        {
        }

        public DbSet<Dobavljac> Dobavljac { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Dobavljac>().HasKey(d => d.dobavljacId);

            base.OnModelCreating(builder);
        }
    }
}
