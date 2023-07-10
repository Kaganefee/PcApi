using Core.Entities.Concrete;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class PcApiDbContext :DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=KANE\SQLEXPRESS;Initial Catalog=PcApiDb;Integrated Security=True;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }

        public DbSet<Pc> Pcs { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(new Category { CategoryName = "MacbookAir",CategoryId=1 });
            modelBuilder.Entity<Pc>().HasData(new Pc { CategoryId = 1 ,Description = "M1 çipli MacBook Air inanılmaz derecede kolay taşınabilen bir laptop.Hızlı ve dinamik olmasının yanı sıra sessiz, fansız bir tasarıma ve göz alıcı bir Retina ekrana sahip.İnce formu ve tüm gün süren pil ömrüyle MacBook Air hızı ve hafifliği bir arada sunuyor.",ProductName= "MacBook Air M1 2020" , ProductId=1 });
        }
    }
}
