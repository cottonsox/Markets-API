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
    public class TrackController : ApiController
    {
        private MarketsContext db = new MarketsContext();

        // GET: api/Track
        public IQueryable<Track> GetTracks()
        {
            return db.Tracks;
        }

        // GET: api/Track/5
        [ResponseType(typeof(Track))]
        public async Task<IHttpActionResult> GetTrack(Guid id)
        {
            Track track = await db.Tracks.FindAsync(id);
            if (track == null)
            {
                return NotFound();
            }

            return Ok(track);
        }

        // PUT: api/Track/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutTrack(Guid id, Track track)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != track.id)
            {
                return BadRequest();
            }

            db.Entry(track).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TrackExists(id))
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

        // POST: api/Track
        [ResponseType(typeof(Track))]
        public async Task<IHttpActionResult> PostTrack(Track track)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Tracks.Add(track);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TrackExists(track.id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = track.id }, track);
        }

        // DELETE: api/Track/5
        [ResponseType(typeof(Track))]
        public async Task<IHttpActionResult> DeleteTrack(Guid id)
        {
            Track track = await db.Tracks.FindAsync(id);
            if (track == null)
            {
                return NotFound();
            }

            db.Tracks.Remove(track);
            await db.SaveChangesAsync();

            return Ok(track);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TrackExists(Guid id)
        {
            return db.Tracks.Count(e => e.id == id) > 0;
        }
    }
}