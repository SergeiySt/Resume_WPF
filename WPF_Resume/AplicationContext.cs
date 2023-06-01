using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WPF_Resume
{
    internal class AplicationContext : DbContext
    {
        public DbSet<UserResume> userResumes { get; set; } = null;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Date Source = helloapp.db");
        }
    }
}
