using System;
using System.Collections.Generic;
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
using BackEnd.DAL;
using BackEnd.Data;
using BackEnd.Models;
using BackEnd.Services;

namespace BackEnd.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class CursusController : ApiController
    {
        private ICursusRepository repository;
        private CursusInstantieValidator _cursusInstantieValidator = new CursusInstantieValidator();
        private CursusValidator _cursusValidator = new CursusValidator();

        public CursusController()
        {
            repository = new CursusRepository(new ApplicationDbContext());
        }

        public CursusController(ICursusRepository repository)
        {
            this.repository = repository;
        }

        // GET: api/CursusInstanties
        [Route("api/cursus")]
        public IEnumerable<CursusInstantie> GetCursussenInstanties()
        {
            Debug.Write("Get request");

            return repository.GetCursusInstanties();
        }

        // GET: api/Cursus/5
        public IHttpActionResult GetCursusInstantie(int id)
        {
            // NOT CORRECTLY IMPLEMENTED YET
            CursusInstantie cursusInstantie = repository.GetCursusInstantieById(id);
            if (cursusInstantie == null)
            {
                return NotFound();
            }

            return Ok(cursusInstantie);
        }

        // PUT: api/Cursus/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCursusInstantie(int id, CursusInstantie cursusInstantie)
        {
            // NOT CORRECTLY IMPLEMENTED YET
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cursusInstantie.Id)
            {
                return BadRequest();
            }

            repository.UpdateCursusInstantie(cursusInstantie);

            try
            {
                repository.Save();
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
        public HttpResponseMessage PostCursusInstantie()
        {
            var httpRequest = HttpContext.Current.Request;
            if (httpRequest.Files.Count < 1)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            try
            {
                var cursusDto = new CursusDto();
                var file = httpRequest.Files[0];
                using (var streamReader = new StreamReader(file.InputStream))
                {
                    var fileContent = streamReader.ReadToEnd();
                    cursusDto = FileProcessService.MapToCursusInstances(fileContent);
                }

                var succesFullAddedCursusCounter = 0;
                var succesFullAddedCursusInstantiesCounter = 0;

                foreach (var cursus in cursusDto.Cursussen)
                {
                    if (_cursusValidator.DoesCursusNotExist(cursus) && _cursusValidator.DoesCursusHaveFilledAttributes(cursus))
                    {
                        repository.AddCursus(cursus);
                        repository.Save();
                        succesFullAddedCursusCounter++;
                    }
                }

                foreach (var cursusInstantie in cursusDto.CursusInstanties)
                {
                    if (_cursusInstantieValidator.DoesNotCursusInstantieExist(cursusInstantie))
                    {
                        repository.AddCursusInstantie(cursusInstantie);
                        repository.Save();
                        succesFullAddedCursusInstantiesCounter++;
                    }
                }

                var requestBody = $"Cursussen toegevoegd: {succesFullAddedCursusCounter}. " +
                                  $"CursussenInstanties toegevoegd: {succesFullAddedCursusInstantiesCounter}." +
                                  $"Cursussen dubbel: {cursusDto.Cursussen.Count - succesFullAddedCursusCounter}." +
                                  $"CursussenInstanties dubbel: { cursusDto.CursusInstanties.Count - succesFullAddedCursusInstantiesCounter}";

                return Request.CreateResponse(HttpStatusCode.OK, requestBody, "application/json");
            }
            catch (ArgumentException ex)
            {
                var requestBody = $"Bestand is niet in correct formaat op regel {ex.Message}." +
                                  $"Er zijn geen cursus of cursusinstanties toegevoegd.";
                return Request.CreateResponse(HttpStatusCode.Accepted, requestBody, "application/json");
            }
            catch (Exception ex)
            {
                var requestBody = $"Bestand is niet in correct formaat op regel {ex.Message}." +
                                  $"Er zijn geen cursus of cursusinstanties toegevoegd.";
                return Request.CreateResponse(HttpStatusCode.BadRequest, requestBody, "application/json");
            }
        }

        // DELETE: api/Cursus/5
        [ResponseType(typeof(Cursus))]
        public IHttpActionResult DeleteCursusInstantie(int id)
        {
            // NOT CORRECTLY IMPLEMENTED YET
            CursusInstantie cursusInstantie = repository.GetCursusInstantieById(id);
            if (cursusInstantie == null)
            {
                return NotFound();
            }

            repository.DeleteCursusInstantie(id);
            repository.Save();

            return Ok(cursusInstantie);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                repository.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CursusExists(int id)
        {
            return repository.GetCursusInstanties().Count(e => e.Id == id) > 0;
        }
    }
}