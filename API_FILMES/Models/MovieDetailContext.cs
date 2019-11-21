using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_FILMES.Models
{
    public class MovieDetailContext: DbContext
    {
        public MovieDetailContext(DbContextOptions<MovieDetailContext> options) : base(options)
        {

        }

        public DbSet<MovieDetail> MovieDetails { get; set; }
    }
}
