using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using APIFILME.models;

namespace APIFILME.Data
{
    public class DbFilmesContext : DbContext
    {
        public DbFilmesContext (DbContextOptions<DbFilmesContext> options)
            : base(options)
        {
        }

        public DbSet<APIFILME.models.FILME> FILME { get; set; } = default!;
    }
}
