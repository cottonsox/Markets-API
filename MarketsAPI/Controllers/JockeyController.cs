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
    public class JockeyController : ApiController
    {
        
        private MarketsContext db = new MarketsContext();

        // GET: api/Jockey
        [HttpGet]        
        public string GetJockeys()
        {
            
            return SerialiseRaceJockeys(db.Jockeys);
        }

        // GET: api/Jockey/5
        [HttpGet]
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
        [HttpPut]
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutJockey([FromBody] Jockey jockey)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Entry(jockey).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JockeyExists(jockey.Id))
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
        [HttpPost]
        [ResponseType(typeof(Jockey))]
        public async Task<IHttpActionResult> PostJockey([FromBody] Jockey jockey)
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
                if (JockeyExists(jockey.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = jockey.Id }, jockey);
        }

        // DELETE: api/Jockey/5
        [HttpDelete]
        [ResponseType(typeof(Jockey))]
        public async Task<IHttpActionResult> DeleteJockey(Guid Id)
        {
            Jockey jockey = await db.Jockeys.FindAsync(Id);
            if (jockey == null)
            {
                return NotFound();
            }

            db.Jockeys.Remove(jockey);
            await db.SaveChangesAsync();

            return Ok(jockey);
        }

        private bool JockeyExists(Guid Id)
        {
            return db.Jockeys.Count(e => e.Id == Id) > 0;
        }

        private string SerialiseRaceJockeys(IEnumerable<Jockey> Jockeys)
        {
            return JsonConvert.SerializeObject(Jockeys);
        }
    }
}