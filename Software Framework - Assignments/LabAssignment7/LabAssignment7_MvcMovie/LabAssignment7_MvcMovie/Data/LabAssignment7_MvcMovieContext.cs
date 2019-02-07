using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace LabAssignment7_MvcMovie.Models
{
    public class LabAssignment7_MvcMovieContext : DbContext
    {
        public LabAssignment7_MvcMovieContext (DbContextOptions<LabAssignment7_MvcMovieContext> options)
            : base(options)
        {
        }

        public DbSet<LabAssignment7_MvcMovie.Models.Movie> Movie { get; set; }
    }
}
