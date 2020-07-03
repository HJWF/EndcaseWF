using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using BackEnd.DAL;
using BackEnd.Data;
using BackEnd.Models;
using BackEnd.Services;

namespace BackEnd.Controllers
{
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "GET, POST")]
    public class CursusController : ApiController
    {
        private readonly ICursusRepository _repository;
        private CursusInstantieValidator _cursusInstantieValidator = new CursusInstantieValidator();
        private CursusValidator _cursusValidator = new CursusValidator();

        public CursusController()
        {
            _repository = new CursusRepository(new ApplicationDbContext());
        }

        public CursusController(ICursusRepository repository)
        {
            _repository = repository;
        }

        // GET: api/Cursussen
        [Route("api/cursus")]
        [HttpGet]
        public IEnumerable<CursusInstantie> GetCursussen()
        {
            return _repository.GetCursusInstanties();
        }

        // GET: api/Cursus/5
        public IEnumerable<CursusInstantie> GetCursusById(int id)
        {
            var cursussen = _repository.GetCursusInstanties();
            var cursussenForSpecificWeek = DateFilteringService.FilterOnWeek(cursussen, id);

            return cursussenForSpecificWeek;
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
                        _repository.AddCursus(cursus);
                        _repository.Save();
                        succesFullAddedCursusCounter++;
                    }
                }

                foreach (var cursusInstantie in cursusDto.CursusInstanties)
                {
                    if (_cursusInstantieValidator.DoesNotCursusInstantieExist(cursusInstantie))
                    {
                        _repository.AddCursusInstantie(cursusInstantie);
                        _repository.Save();
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

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _repository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}