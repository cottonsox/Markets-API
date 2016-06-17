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
    public class HorseController : ApiController
    {
        private MarketsContext db = new MarketsContext();

        // GET: api/Horse
        [HttpGet]
        //[Authorize]  for later.
        public string GetHorses()
        {
            return SerialiseHorses(db.Horses);
        }

        // GET: api/Horse/5
        [HttpGet]
        [ResponseType(typeof(Horse))]
        public async Task<IHttpActionResult> GetHorse(Guid Id)
        {
            Horse horse = await db.Horses.FindAsync(Id);
            if (horse == null)
            {
                return NotFound();
            }

            return Ok(horse);
        }

        // PUT: api/Horse/5
        [HttpPut]
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutHorse([FromBody] Horse Horse)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Entry(Horse).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HorseExists(Horse.Id))
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
        [HttpPost]
        [ResponseType(typeof(Horse))]
        public async Task<IHttpActionResult> PostHorse([FromBody] Horse Horse)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Horses.Add(Horse);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (HorseExists(Horse.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = Horse.Id }, Horse);
        }

        // DELETE: api/Horse/5
        [HttpDelete]
        [ResponseType(typeof(Horse))]
        public async Task<IHttpActionResult> DeleteHorse(Guid Id)
        {
            Horse horse = await db.Horses.FindAsync(Id);
            if (horse == null)
            {
                return NotFound();
            }

            db.Horses.Remove(horse);
            await db.SaveChangesAsync();

            return Ok(horse);
        }
                
        private bool HorseExists(Guid id)
        {
            return db.Horses.Count(e => e.Id == id) > 0;
        }
        
        private string SerialiseHorses(IEnumerable<Horse> Horses)
        {
            return JsonConvert.SerializeObject(Horses);
        }
    }
}