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
    public class HorseController : ApiController
    {
        private MarketsContext db = new MarketsContext();

        // GET: api/Horse
        public IQueryable<Horse> GetHorses()
        {
            return db.Horses;
        }

        // GET: api/Horse/5
        [ResponseType(typeof(Horse))]
        public async Task<IHttpActionResult> GetHorse(Guid id)
        {
            Horse horse = await db.Horses.FindAsync(id);
            if (horse == null)
            {
                return NotFound();
            }

            return Ok(horse);
        }

        // PUT: api/Horse/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutHorse(Guid id, Horse horse)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != horse.id)
            {
                return BadRequest();
            }

            db.Entry(horse).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HorseExists(id))
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

        // POST: api/Horse
        [ResponseType(typeof(Horse))]
        public async Task<IHttpActionResult> PostHorse(Horse horse)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Horses.Add(horse);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (HorseExists(horse.id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = horse.id }, horse);
        }

        // DELETE: api/Horse/5
        [ResponseType(typeof(Horse))]
        public async Task<IHttpActionResult> DeleteHorse(Guid id)
        {
            Horse horse = await db.Horses.FindAsync(id);
            if (horse == null)
            {
                return NotFound();
            }

            db.Horses.Remove(horse);
            await db.SaveChangesAsync();

            return Ok(horse);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool HorseExists(Guid id)
        {
            return db.Horses.Count(e => e.id == id) > 0;
        }
    }
}