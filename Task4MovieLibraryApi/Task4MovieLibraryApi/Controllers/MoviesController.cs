using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Task4MovieLibraryApi.Wrappers;
using Task4MovieLibraryApi.Repository;
using Task4MovieLibraryApi.Interfaces;

namespace Task4MovieLibraryApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly MovieContext _MovieContext;
        private readonly IUriService _UriService;
        //private readonly MovieRepository _MovieRepository;
        public MoviesController(MovieContext movieContext, IUriService uriService)//, MovieRepository movieRepository)
        {
            _MovieContext = movieContext;
            _UriService = uriService;
            //_MovieRepository = movieRepository;
        }
        
        // GET: api/Movies
        [HttpGet]
        public async ValueTask<ActionResult<IEnumerable<Movie>>> GetMovies([FromQuery] PaginationFilter filter)
        {
          if (_MovieContext.Movies == null)
          {
              return NotFound();
          }
            string? route = Request.Path.Value;
            PaginationFilter validFilter = new (filter.PageNumber, filter.PageSize);
            var pagedData = await _MovieContext.Movies.OrderBy(m => m.ID)
                .Skip((validFilter.PageNumber - 1) * validFilter.PageSize)
                .Take(validFilter.PageSize)
                .ToListAsync();
            int totalRecords = await _MovieContext.Movies.CountAsync();
            var pagedReponse = PaginationHelper.CreatePagedReponse(pagedData, validFilter, totalRecords, _UriService, route);
            return Ok(pagedReponse);

            //return await _MovieContext.Movies.ToListAsync();
        }

        // GET: api/Movies/5
        [HttpGet("{id}")]
        public async ValueTask<ActionResult<Movie>> GetMovie(int id)
        {
          if (_MovieContext.Movies == null)
          {
              return NotFound();
          }
            var movie = await _MovieContext.Movies.FindAsync(id);

            if (movie == null)
            {
                return NotFound();
            }

            return Ok(new Response<Movie>(movie));
        }

        // PUT: api/Movies/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async ValueTask<IActionResult> PutMovie(int id, Movie movie)
        {
            if (id != movie.ID)
            {
                return BadRequest();
            }

            _MovieContext.Entry(movie).State = EntityState.Modified;

            try
            {
                await _MovieContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MovieExists(id))
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

        // POST: api/Movies
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async ValueTask<ActionResult<Movie>> PostMovie(Movie movie)
        {
          if (_MovieContext.Movies == null)
          {
              return Problem("Entity set 'MovieContext.Movies'  is null.");
          }
            _MovieContext.Movies.Add(movie);
            await _MovieContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetMovie), new { id = movie.ID }, movie);
        }

        // DELETE: api/Movies/5
        [HttpDelete("{id}")]
        public async ValueTask<ActionResult<Movie>> DeleteMovie(int id)
        {
            if (_MovieContext.Movies == null)
            {
                return NotFound();
            }
            var movie = await _MovieContext.Movies.FindAsync(id);
            if (movie == null)
            {
                return NotFound();
            }

            _MovieContext.Movies.Remove(movie);
            await _MovieContext.SaveChangesAsync();

            return NoContent();
        }
        
        private bool MovieExists(int id)
        {
            return (_MovieContext.Movies?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
