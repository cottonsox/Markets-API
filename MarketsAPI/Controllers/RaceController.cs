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
    public class RaceController : ApiController
    {
        private MarketsContext db = new MarketsContext();

        // GET: api/Race
        [HttpGet]
        public string GetRaces()
        {
            return SerialiseRaces(db.Races);
        }

        // GET: api/Race/5
        [HttpGet]
        [ResponseType(typeof(Race))]
        public async Task<IHttpActionResult> GetRace(Guid id)
        {
            Race race = await db.Races.FindAsync(id);
            if (race == null)
            {
                return NotFound();
            }

            return Ok(race);
        }

        // PUT: api/Race/5
        [HttpPut]
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutRace([FromBody] Race Race)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Entry(Race).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RaceExists(Race.Id))
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

        // POST: api/Race
        [HttpPost]
        [ResponseType(typeof(Race))]
        public async Task<IHttpActionResult> PostRace([FromBody] Race race)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Races.Add(race);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (RaceExists(race.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = race.Id }, race);
        }

        // DELETE: api/Race/5
        [HttpDelete]
        [ResponseType(typeof(Race))]
        public async Task<IHttpActionResult> DeleteRace(Guid id)
        {
            Race race = await db.Races.FindAsync(id);
            if (race == null)
            {
                return NotFound();
            }

            db.Races.Remove(race);
            await db.SaveChangesAsync();

            return Ok(race);
        }


        private bool RaceExists(Guid id)
        {
            return db.Races.Count(e => e.Id == id) > 0;
        }

        private string SerialiseRaces(IEnumerable<Race> Race)
        {
            return JsonConvert.SerializeObject(Race);
        }
    }
}