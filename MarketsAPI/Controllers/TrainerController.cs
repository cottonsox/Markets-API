using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using MarketsAPI.Data;
using MarketsAPI.Models;
using Newtonsoft.Json;

namespace MarketsAPI.Controllers
{
    public class TrainerController : ApiController
    {
        private MarketsContext db = new MarketsContext();

        // GET: api/Trainer
        [HttpGet]
        public string GetTrainers()
        {            
            return SerialiseTrainers(db.Trainers);
        }

        // GET: api/Trainer/5
        [HttpGet]
        [ResponseType(typeof(Trainer))]
        public async Task<IHttpActionResult> GetTrainer(Guid Id)
        {
            Trainer trainer = await db.Trainers.FindAsync(Id);
            if (trainer == null)
            {
                return NotFound();
            }

            return Ok(trainer);
        }

        // PUT: api/Trainer/5
        [HttpPut]
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutTrainer([FromBody] Trainer Trainer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            db.Entry(Trainer).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TrainerExists(Trainer.Id))
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

        // POST: api/Trainer
        [HttpPost]
        [ResponseType(typeof(Trainer))]
        public async Task<IHttpActionResult> PostTrainer([FromBody] Trainer Trainer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Trainers.Add(Trainer);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TrainerExists(Trainer.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = Trainer.Id }, Trainer);
        }

        // DELETE: api/Trainer/5
        [HttpDelete]
        [ResponseType(typeof(Trainer))]
        public async Task<IHttpActionResult> DeleteTrainer(Guid Id)
        {
            Trainer trainer = await db.Trainers.FindAsync(Id);
            if (trainer == null)
            {
                return NotFound();
            }

            db.Trainers.Remove(trainer);
            await db.SaveChangesAsync();

            return Ok(trainer);
        }



        private bool TrainerExists(Guid id)
        {
            return db.Trainers.Count(e => e.Id == id) > 0;
        }

        private string SerialiseTrainers(IEnumerable<Trainer> Trainers)
        {
            return JsonConvert.SerializeObject(Trainers);
        }
    }
}