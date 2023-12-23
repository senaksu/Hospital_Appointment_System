﻿using HastaneOtomasyonu.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HastaneOtomasyonu.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Doktor> doktors { get; set; }
        public DbSet<Poliklinik> polikliniks { get; set; }
        public DbSet<Randevu> randevu { get; set; }



    }
}