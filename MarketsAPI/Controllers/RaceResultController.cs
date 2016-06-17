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
    public class RaceResultController : ApiController
    {
        private MarketsContext db = new MarketsContext();

        // GET: api/RaceResult
        [HttpGet]
        public string GetRaceResults()
        {
            return SerialiseRaceResult(db.RaceResult);
        }

        // GET: api/RaceResult/5
        [HttpGet]
        [ResponseType(typeof(RaceResult))]
        public async Task<IHttpActionResult> GetRaceResult(Guid id)
        {
            RaceResult RaceResult = await db.RaceResult.FindAsync(id);
            if (RaceResult == null)
            {
                return NotFound();
            }

            return Ok(RaceResult);
        }

        // PUT: api/RaceResult/5
        [HttpPut]
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutRaceResult([FromBody] RaceResult RaceResult)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Entry(RaceResult).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RaceResultExists(RaceResult.Id))
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

        // POST: api/RaceResult
        [HttpPost]
        [ResponseType(typeof(RaceResult))]
        public async Task<IHttpActionResult> PostRaceResult([FromBody] RaceResult RaceResult)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.RaceResult.Add(RaceResult);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (RaceResultExists(RaceResult.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = RaceResult.Id }, RaceResult);
        }

        // DELETE: api/RaceResult/5
        [HttpDelete]
        [ResponseType(typeof(RaceResult))]
        public async Task<IHttpActionResult> DeleteRaceResult(Guid Id)
        {
            RaceResult RaceResult = await db.RaceResult.FindAsync(Id);
            if (RaceResult == null)
            {
                return NotFound();
            }

            db.RaceResult.Remove(RaceResult);
            await db.SaveChangesAsync();

            return Ok(RaceResult);
        }

        private bool RaceResultExists(Guid Id)
        {
            return db.RaceResult.Count(e => e.Id == Id) > 0;
        }

        private string SerialiseRaceResult(IEnumerable<RaceResult> RaceResults)
        {
            return JsonConvert.SerializeObject(RaceResults);
        }
    }
}
