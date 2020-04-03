using System;
using System.Collections.Generic;
using System.Text;
using DotNetCoreJWTAuth.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DotNetCoreJWTAuth.Data
{
    public class MSSQLDBContext : IdentityDbContext
    {
        public MSSQLDBContext(DbContextOptions<MSSQLDBContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
    }
}
