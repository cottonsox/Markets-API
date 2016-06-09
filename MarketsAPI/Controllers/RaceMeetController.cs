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
    public class RaceMeetController : ApiController
    {
        private MarketsContext db = new MarketsContext();

        // GET: api/RaceMeet
        [HttpGet]
        public string GetRaceMeets()
        {
            return SerialiseRaceMeets(db.RaceMeets);
        }

        // GET: api/RaceMeet/5
        [HttpGet]
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
        [HttpPut]
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutRaceMeet([FromBody] RaceMeet RaceMeet)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            db.Entry(RaceMeet).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RaceMeetExists(RaceMeet.Id))
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
        [HttpPost]
        [ResponseType(typeof(RaceMeet))]
        public async Task<IHttpActionResult> PostRaceMeet([FromBody] RaceMeet RaceMeet)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.RaceMeets.Add(RaceMeet);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (RaceMeetExists(RaceMeet.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = RaceMeet.Id }, RaceMeet);
        }

        // DELETE: api/RaceMeet/5
        [HttpDelete]
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

        private bool RaceMeetExists(Guid id)
        {
            return db.RaceMeets.Count(e => e.Id == id) > 0;
        }

        private string SerialiseRaceMeets(IEnumerable<RaceMeet> RaceMeet)
        {
            return JsonConvert.SerializeObject(RaceMeet);
        }
    }
}