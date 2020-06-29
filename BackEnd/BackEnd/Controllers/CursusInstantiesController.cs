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
using BackEnd.Data;
using BackEnd.Models;

namespace BackEnd.Controllers
{
    public class CursusInstantiesController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/CursusInstanties
        public IQueryable<CursusInstantie> GetCursusInstanties()
        {
            return db.CursusInstanties;
        }

        // GET: api/CursusInstanties/5
        [ResponseType(typeof(CursusInstantie))]
        public async Task<IHttpActionResult> GetCursusInstantie(int id)
        {
            CursusInstantie cursusInstantie = await db.CursusInstanties.FindAsync(id);
            if (cursusInstantie == null)
            {
                return NotFound();
            }

            return Ok(cursusInstantie);
        }

        // PUT: api/CursusInstanties/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutCursusInstantie(int id, CursusInstantie cursusInstantie)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cursusInstantie.Id)
            {
                return BadRequest();
            }

            db.Entry(cursusInstantie).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CursusInstantieExists(id))
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

        // POST: api/CursusInstanties
        [ResponseType(typeof(CursusInstantie))]
        public async Task<IHttpActionResult> PostCursusInstantie(CursusInstantie cursusInstantie)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CursusInstanties.Add(cursusInstantie);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = cursusInstantie.Id }, cursusInstantie);
        }

        // DELETE: api/CursusInstanties/5
        [ResponseType(typeof(CursusInstantie))]
        public async Task<IHttpActionResult> DeleteCursusInstantie(int id)
        {
            CursusInstantie cursusInstantie = await db.CursusInstanties.FindAsync(id);
            if (cursusInstantie == null)
            {
                return NotFound();
            }

            db.CursusInstanties.Remove(cursusInstantie);
            await db.SaveChangesAsync();

            return Ok(cursusInstantie);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CursusInstantieExists(int id)
        {
            return db.CursusInstanties.Count(e => e.Id == id) > 0;
        }
    }
}