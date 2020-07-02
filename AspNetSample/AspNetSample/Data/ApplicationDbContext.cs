using System;
using System.Collections.Generic;
using System.Text;
using AspNetSample.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AspNetSample.Data
{
    public class ApplicationDbContext : IdentityDbContext<MyApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<TravelDestination> TravelDestinations { get; set; }

        public DbSet<TravelMemory> TravelMemories { get; set; }
    }
}
