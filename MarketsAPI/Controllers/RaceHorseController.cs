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
using MarketsAPI.Data;
using MarketsAPI.Models;
using Newtonsoft.Json;


namespace MarketsAPI.Controllers
{
    public class RaceHorseController : ApiController
    {
        private MarketsContext db = new MarketsContext();

        // GET: api/RaceHorse
        [HttpGet]
        public string GetRaceHorses()
        {            
            return SerialiseRaceHorse(db.RaceHorses);
        }

        // GET: api/RaceHorse/5
        [HttpGet]
        [ResponseType(typeof(RaceHorse))]
        public async Task<IHttpActionResult> GetRaceHorse(Guid Id)
        {
            RaceHorse raceHorse = await db.RaceHorses.FindAsync(Id);
            if (raceHorse == null)
            {
                return NotFound();
            }

            return Ok(raceHorse);
        }

        // PUT: api/RaceHorse/5
        [HttpPut]
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutRaceHorse([FromBody] RaceHorse RaceHorse)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Entry(RaceHorse).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RaceHorseExists(RaceHorse.id))
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
        public async Task<IHttpActionResult> PostRaceHorse([FromBody] RaceHorse RaceHorse)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.RaceHorses.Add(RaceHorse);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (RaceHorseExists(RaceHorse.id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = RaceHorse.id }, RaceHorse);
        }

        // DELETE: api/RaceHorse/5
        [HttpDelete]
        [ResponseType(typeof(RaceHorse))]
        public async Task<IHttpActionResult> DeleteRaceHorse(Guid Id)
        {
            RaceHorse raceHorse = await db.RaceHorses.FindAsync(Id);
            if (raceHorse == null)
            {
                return NotFound();
            }

            db.RaceHorses.Remove(raceHorse);
            await db.SaveChangesAsync();

            return Ok(raceHorse);
        }


        private bool RaceHorseExists(Guid Id)
        {
            return db.RaceHorses.Count(e => e.id == Id) > 0;
        }

        private string SerialiseRaceHorse(IEnumerable<RaceHorse> Racehorses)
        {
            return JsonConvert.SerializeObject(Racehorses);
        }
    }
}