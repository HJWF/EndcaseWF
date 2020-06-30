using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using BackEnd.Data;
using BackEnd.Models;
using BackEnd.Services;
using Newtonsoft.Json;

namespace BackEnd.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class CursusController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/CursusInstanties
        [Route("api/cursus")]
        public IQueryable<CursusInstantie> GetCursussen()
        {
            Debug.Write("Get request");
            var cursussen = db.CursusInstanties.Include(c => c.Cursus);

            return cursussen;
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
        //[ResponseType(typeof(Cursus))]
        [Route("api/cursus")]
        [HttpPost]
        public HttpResponseMessage PostCursus()
        {

            var httpRequest = HttpContext.Current.Request;
            if (httpRequest.Files.Count < 1)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            try
            {
                var file = httpRequest.Files[0];
                var fileContent = new StreamReader(file.InputStream).ReadToEnd();

                var cursusInstanties = FileProcessService.MapToCursusInstances(fileContent);

                foreach (var cursusInstantie in cursusInstanties)
                {
                    db.CursusInstanties.Add(cursusInstantie);
                }

                db.SaveChanges();

                return Request.CreateResponse(HttpStatusCode.OK, cursusInstanties.Count, "application/json");
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
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