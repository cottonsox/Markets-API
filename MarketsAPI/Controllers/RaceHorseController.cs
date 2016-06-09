using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using MarketsAPI.DAL;
using MarketsAPI.Models;

namespace MarketsAPI.Controllers
{
    public class RaceHorseController : ApiController
    {
        private MarketsContext db = new MarketsContext();

        // GET: api/RaceHorse
        [HttpGet]
        public IQueryable<RaceHorse> GetRaceHorses()
        {
            return db.RaceHorses;
        }

        // GET: api/RaceHorse/5
        [HttpGet]
        [ResponseType(typeof(RaceHorse))]
        public async Task<IHttpActionResult> GetRaceHorse(Guid id)
        {
            RaceHorse raceHorse = await db.RaceHorses.FindAsync(id);
            if (raceHorse == null)
            {
                return NotFound();
            }

            return Ok(raceHorse);
        }

        // PUT: api/RaceHorse/5
        [HttpPut]
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutRaceHorse(Guid id, RaceHorse raceHorse)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != raceHorse.id)
            {
                return BadRequest();
            }

            db.Entry(raceHorse).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RaceHorseExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/RaceHorse
        [HttpPost]
        [ResponseType(typeof(RaceHorse))]
        public async Task<IHttpActionResult> PostRaceHorse(RaceHorse raceHorse)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.RaceHorses.Add(raceHorse);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (RaceHorseExists(raceHorse.id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = raceHorse.id }, raceHorse);
        }

        // DELETE: api/RaceHorse/5
        [HttpDelete]
        [ResponseType(typeof(RaceHorse))]
        public async Task<IHttpActionResult> DeleteRaceHorse(Guid id)
        {
            RaceHorse raceHorse = await db.RaceHorses.FindAsync(id);
            if (raceHorse == null)
            {
                return NotFound();
            }

            db.RaceHorses.Remove(raceHorse);
            await db.SaveChangesAsync();

            return Ok(raceHorse);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RaceHorseExists(Guid id)
        {
            return db.RaceHorses.Count(e => e.id == id) > 0;
        }
    }
}