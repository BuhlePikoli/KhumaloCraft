using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuthAPI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AuthAPI.Data
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {

        }
        public DbSet<ApplicationUser> applicationUsers {get;set;}
        protected override void  OnModelCreating(ModelBuilder modelBuilder){

            base.OnModelCreating(modelBuilder);
        }
    }
}