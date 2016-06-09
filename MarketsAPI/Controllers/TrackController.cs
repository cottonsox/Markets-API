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
using Newtonsoft.Json;

namespace MarketsAPI.Controllers
{
    public class TrackController : ApiController
    {
        private MarketsContext db = new MarketsContext();

        // GET: api/Track
        [HttpGet]
        public string GetTracks()
        {
            
            return SerialiseTracks(db.Tracks);
        }

        // GET: api/Track/5
        [HttpGet]
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
        [HttpPut]
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutTrack([FromBody] Track Track)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Entry(Track).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TrackExists(Track.Id))
                {
                    return base.NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Track
        [HttpPost]
        [ResponseType(typeof(Track))]
        public async Task<IHttpActionResult> PostTrack(Track Track)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Tracks.Add(Track);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TrackExists(Track.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = Track.Id }, Track);
        }

        // DELETE: api/Track/5
        [HttpDelete]
        [ResponseType(typeof(Track))]
        public async Task<IHttpActionResult> DeleteTrack(Guid Id)
        {
            Track track = await db.Tracks.FindAsync(Id);
            if (track == null)
            {
                return NotFound();
            }

            db.Tracks.Remove(track);
            await db.SaveChangesAsync();

            return Ok(track);
        }


        private bool TrackExists(Guid id)
        {
            return db.Tracks.Count(e => e.Id == id) > 0;
        }

        private string SerialiseTracks(IEnumerable<Track> Tracks)
        {
            return JsonConvert.SerializeObject(Tracks);
        }
    }
}