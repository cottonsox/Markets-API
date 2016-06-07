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
    public class JockeyController : ApiController
    {
        private MarketsContext db = new MarketsContext();

        // GET: api/Jockey
        public IQueryable<Jockey> GetJockeys()
        {
            return db.Jockeys;
        }

        // GET: api/Jockey/5
        [ResponseType(typeof(Jockey))]
        public async Task<IHttpActionResult> GetJockey(Guid id)
        {
            Jockey jockey = await db.Jockeys.FindAsync(id);
            if (jockey == null)
            {
                return NotFound();
            }

            return Ok(jockey);
        }

        // PUT: api/Jockey/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutJockey(Guid id, Jockey jockey)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != jockey.id)
            {
                return BadRequest();
            }

            db.Entry(jockey).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JockeyExists(id))
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

        // POST: api/Jockey
        [ResponseType(typeof(Jockey))]
        public async Task<IHttpActionResult> PostJockey(Jockey jockey)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Jockeys.Add(jockey);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (JockeyExists(jockey.id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = jockey.id }, jockey);
        }

        // DELETE: api/Jockey/5
        [ResponseType(typeof(Jockey))]
        public async Task<IHttpActionResult> DeleteJockey(Guid id)
        {
            Jockey jockey = await db.Jockeys.FindAsync(id);
            if (jockey == null)
            {
                return NotFound();
            }

            db.Jockeys.Remove(jockey);
            await db.SaveChangesAsync();

            return Ok(jockey);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool JockeyExists(Guid id)
        {
            return db.Jockeys.Count(e => e.id == id) > 0;
        }
    }
}