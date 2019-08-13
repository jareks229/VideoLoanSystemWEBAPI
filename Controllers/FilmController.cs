using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VideoLoanWebAPI.Models;

namespace VideoLoanWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmController : ControllerBase
    {
        private readonly VideoLoanContext _context;

        public FilmController(VideoLoanContext context)
        {
            _context = context;
        }

        //for tests
        //FilmModel[] Films = new FilmModel[]
        //{
        //    new FilmModel { ID = 1, Name = "Alien", Director="Ridley Scott", Gendre="Horror", Restrictions="18" },
        //    new FilmModel { ID = 2, Name = "Blade Runner", Director="Ridley Scott", Gendre="Horror", Restrictions="18" },
        //    new FilmModel { ID = 3, Name = "Gladiator", Director="Ridley Scott", Gendre="Horror", Restrictions="18" },
        //};

        [EnableCors("MyCors")]
        [HttpGet]
        public async  Task<ActionResult<IEnumerable<FilmModel>>> GetAllFilms()
        {
            return await _context.Films.ToListAsync();
        }

        [EnableCors("MyCors")]
        [HttpGet("{id}")]
        public async Task<ActionResult<FilmModel>> GetFilm(int id)
        {
            var result = _context.Films.FindAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            else
            {
                return await result;
            }
        }

        [EnableCors("MyCors")]
        [HttpPost]
        public async Task<ActionResult<FilmModel>> AddFilm(FilmModel model)
        {
            _context.Films.Add(model);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetFilm), new { id = model.ID }, model);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateFilm(int id, FilmModel model)
        {
            if (id != model.ID)
            {
                return BadRequest();
            }

            _context.Entry(model).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFilm(int id)
        {
            var film = await _context.Films.FindAsync(id);

            if (film == null)
            {
                return NotFound();
            }

            _context.Films.Remove(film);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> LoanFilm(int filmId, int customerId )
        {
            var film = await _context.Films.FindAsync(filmId);
            var customer = await _context.Customers.FindAsync(customerId);
            

            if(film == null)
            {
                return NotFound();
            }
            else
            {
                film.Avalibility = false;
                _context.Films.Update(film);
                customer.FilmsLoaned.Add(film);
                _context.Customers.Update(customer);
                await _context.SaveChangesAsync();
                return NoContent();
            }
        }
    }
}