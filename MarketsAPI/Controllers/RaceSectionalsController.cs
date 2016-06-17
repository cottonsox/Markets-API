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
    public class RaceSectionalsController : ApiController
    {
        private MarketsContext db = new MarketsContext();

        // GET: api/RaceSectional
        [HttpGet]
        public string GetRaceSectionals()
        {
            return SerialiseRaceSectional(db.RaceSectionals);
        }

        // GET: api/RaceSectional/5
        [HttpGet]
        [ResponseType(typeof(RaceSectionals))]
        public async Task<IHttpActionResult> GetRaceSectional(Guid id)
        {
            RaceSectionals RaceSectionals = await db.RaceSectionals.FindAsync(id);
            if (RaceSectionals == null)
            {
                return NotFound();
            }

            return Ok(RaceSectionals);
        }

        // PUT: api/RaceSectional/5
        [HttpPut]
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutRaceSectional([FromBody] RaceSectionals RaceSectionals)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Entry(RaceSectionals).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RaceSectionalExists(RaceSectionals.Id))
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

        // POST: api/RaceSectional
        [HttpPost]
        [ResponseType(typeof(RaceSectionals))]
        public async Task<IHttpActionResult> PostRaceSectional([FromBody] RaceSectionals RaceSectionals)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.RaceSectionals.Add(RaceSectionals);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (RaceSectionalExists(RaceSectionals.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = RaceSectionals.Id }, RaceSectionals);
        }

        // DELETE: api/RaceSectional/5
        [HttpDelete]
        [ResponseType(typeof(RaceSectionals))]
        public async Task<IHttpActionResult> DeleteRaceSectional(Guid Id)
        {
            RaceSectionals RaceSectional = await db.RaceSectionals.FindAsync(Id);
            if (RaceSectional == null)
            {
                return NotFound();
            }

            db.RaceSectionals.Remove(RaceSectional);
            await db.SaveChangesAsync();

            return Ok(RaceSectional);
        }

        private bool RaceSectionalExists(Guid Id)
        {
            return db.RaceSectionals.Count(e => e.Id == Id) > 0;
        }

        private string SerialiseRaceSectional(IEnumerable<RaceSectionals> RaceSectionals)
        {
            return JsonConvert.SerializeObject(RaceSectionals);
        }
    }
}

