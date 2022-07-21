using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using  STW_Spark.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace  STW_Spark.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<ServiceType> ServiceType { get; set; }
        public DbSet<Car> car { get; set; }
        public DbSet<ServiceShopingCart> serviceShopingCart { get; set; }
        public DbSet<ServiceDetails> serviceDetails { get; set; }
        public DbSet<ServiceHeader> serviceHeader { get; set; }
        public DbSet<ApplicationUser> ApplicationUser { get; set; }
    }
}
