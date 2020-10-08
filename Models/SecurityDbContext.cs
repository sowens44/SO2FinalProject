using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace SO2FinalProject.Models
{



    public class SecurityDbContext : IdentityDbContext

    {
        public SecurityDbContext()
        {
            
        }
        public SecurityDbContext(DbContextOptions<SecurityDbContext> options)
            : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseSqlServer("Data Source=.\\sqlexpress;Initial Catalog=OWENSDB;Integrated Security=True");

            }

        }
    }
}
