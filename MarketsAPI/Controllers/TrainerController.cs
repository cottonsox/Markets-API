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
    public class TrainerController : ApiController
    {
        private MarketsContext db = new MarketsContext();

        // GET: api/Trainer
        [HttpGet]
        public IQueryable<Trainer> GetTrainers()
        {
            return db.Trainers;
        }

        // GET: api/Trainer/5
        [HttpGet]
        [ResponseType(typeof(Trainer))]
        public async Task<IHttpActionResult> GetTrainer(Guid id)
        {
            Trainer trainer = await db.Trainers.FindAsync(id);
            if (trainer == null)
            {
                return NotFound();
            }

            return Ok(trainer);
        }

        // PUT: api/Trainer/5
        [HttpPut]
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutTrainer(Guid id, Trainer trainer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != trainer.id)
            {
                return BadRequest();
            }

            db.Entry(trainer).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TrainerExists(id))
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
        public async Task<IHttpActionResult> PostTrainer(Trainer trainer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Trainers.Add(trainer);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TrainerExists(trainer.id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = trainer.id }, trainer);
        }

        // DELETE: api/Trainer/5
        [HttpDelete]
        [ResponseType(typeof(Trainer))]
        public async Task<IHttpActionResult> DeleteTrainer(Guid id)
        {
            Trainer trainer = await db.Trainers.FindAsync(id);
            if (trainer == null)
            {
                return NotFound();
            }

            db.Trainers.Remove(trainer);
            await db.SaveChangesAsync();

            return Ok(trainer);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TrainerExists(Guid id)
        {
            return db.Trainers.Count(e => e.id == id) > 0;
        }
    }
}