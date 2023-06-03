using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Resume
{
    internal class AplicationContextForma2 : DbContext
    {
        public DbSet<UserResumeForma2> UserResumeForma { get; set; } = null;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=resume2.db");
        }
    }
}
