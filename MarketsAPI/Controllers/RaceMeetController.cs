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

namespace Markets.Controllers
{
    public class RaceMeetController : ApiController
    {
        private MarketsContext db = new MarketsContext();

        // GET: api/RaceMeet
        public IQueryable<RaceMeet> GetRaceMeets()
        {
            return db.RaceMeets;
        }

        // GET: api/RaceMeet/5
        [ResponseType(typeof(RaceMeet))]
        public async Task<IHttpActionResult> GetRaceMeet(Guid id)
        {
            RaceMeet raceMeet = await db.RaceMeets.FindAsync(id);
            if (raceMeet == null)
            {
                return NotFound();
            }

            return Ok(raceMeet);
        }

        // PUT: api/RaceMeet/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutRaceMeet(Guid id, RaceMeet raceMeet)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != raceMeet.id)
            {
                return BadRequest();
            }

            db.Entry(raceMeet).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RaceMeetExists(id))
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

        // POST: api/RaceMeet
        [ResponseType(typeof(RaceMeet))]
        public async Task<IHttpActionResult> PostRaceMeet(RaceMeet raceMeet)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.RaceMeets.Add(raceMeet);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (RaceMeetExists(raceMeet.id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = raceMeet.id }, raceMeet);
        }

        // DELETE: api/RaceMeet/5
        [ResponseType(typeof(RaceMeet))]
        public async Task<IHttpActionResult> DeleteRaceMeet(Guid id)
        {
            RaceMeet raceMeet = await db.RaceMeets.FindAsync(id);
            if (raceMeet == null)
            {
                return NotFound();
            }

            db.RaceMeets.Remove(raceMeet);
            await db.SaveChangesAsync();

            return Ok(raceMeet);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RaceMeetExists(Guid id)
        {
            return db.RaceMeets.Count(e => e.id == id) > 0;
        }
    }
}