using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Studenti.Models;

namespace Studenti.Data
{
    public class StudentiContext : DbContext
    {
        public StudentiContext(DbContextOptions<StudentiContext> options)
            : base(options) {}



        public DbSet<Studenti.Models.Student> Student { get; set; }

        public DbSet<Studenti.Models.Facultate> Facultate { get; set; }

        public DbSet<Studenti.Models.Specializare> Specializare { get; set; } 
    }
}
