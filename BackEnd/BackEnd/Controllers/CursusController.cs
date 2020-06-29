using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using BackEnd.Data;
using BackEnd.Models;

namespace BackEnd.Controllers
{
    public class CursusController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Cursus
        public IQueryable<Cursus> GetCursussen()
        {
            return db.Cursussen;
        }

        // GET: api/Cursus/5
        [ResponseType(typeof(Cursus))]
        public IHttpActionResult GetCursus(int id)
        {
            Cursus cursus = db.Cursussen.Find(id);
            if (cursus == null)
            {
                return NotFound();
            }

            return Ok(cursus);
        }

        // PUT: api/Cursus/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCursus(int id, Cursus cursus)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cursus.Id)
            {
                return BadRequest();
            }

            db.Entry(cursus).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CursusExists(id))
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

        // POST: api/Cursus
        [ResponseType(typeof(Cursus))]
        public IHttpActionResult PostCursus(Cursus cursus)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Cursussen.Add(cursus);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = cursus.Id }, cursus);
        }

        // DELETE: api/Cursus/5
        [ResponseType(typeof(Cursus))]
        public IHttpActionResult DeleteCursus(int id)
        {
            Cursus cursus = db.Cursussen.Find(id);
            if (cursus == null)
            {
                return NotFound();
            }

            db.Cursussen.Remove(cursus);
            db.SaveChanges();

            return Ok(cursus);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CursusExists(int id)
        {
            return db.Cursussen.Count(e => e.Id == id) > 0;
        }
    }
}