using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API_FILMES.Models;

namespace API_FILMES.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieDetailsController : ControllerBase
    {
        private readonly MovieDetailContext _context;

        public MovieDetailsController(MovieDetailContext context)
        {
            _context = context;
        }

        // GET: api/MovieDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MovieDetail>>> GetMovieDetails()
        {
            return await _context.MovieDetails.ToListAsync();
        }

        // GET: api/MovieDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MovieDetail>> GetMovieDetail(int id)
        {
            var movieDetail = await _context.MovieDetails.FindAsync(id);

            if (movieDetail == null)
            {
                return NotFound();
            }

            return movieDetail;
        }

        // PUT: api/MovieDetails/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMovieDetail(int id, MovieDetail movieDetail)
        {
            // Necessario passar id no body da request
            if (id != movieDetail.MVId)
            {
                return BadRequest();
            }

            _context.Entry(movieDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MovieDetailExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/MovieDetails
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<MovieDetail>> PostMovieDetail(MovieDetail movieDetail)
        {
            _context.MovieDetails.Add(movieDetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMovieDetail", new { id = movieDetail.MVId }, movieDetail);
        }

        // DELETE: api/MovieDetails/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<MovieDetail>> DeleteMovieDetail(int id)
        {
            var movieDetail = await _context.MovieDetails.FindAsync(id);
            if (movieDetail == null)
            {
                return NotFound();
            }

            _context.MovieDetails.Remove(movieDetail);
            await _context.SaveChangesAsync();

            return movieDetail;
        }

        private bool MovieDetailExists(int id)
        {
            return _context.MovieDetails.Any(e => e.MVId == id);
        }
    }
}
