using HastaneOtomasyonAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace HastaneOtomasyonAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Poliklinik> polikliniks { get; set; }
        public DbSet<Doktor> doktors { get; set; }
        public DbSet<Randevu> randevus { get; set; }

    }
}