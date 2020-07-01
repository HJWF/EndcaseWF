using System.Collections.Generic;
using System.Linq;
using BackEnd.DAL;
using BackEnd.Data;
using BackEnd.Models;

namespace BackEnd.Services
{
    public class CursusValidator
    {
        private ICursusRepository repository;

        public CursusValidator()
        {
            repository = new CursusRepository(new ApplicationDbContext());
        }

        public CursusValidator(ICursusRepository repository)
        {
            this.repository = repository;
        }

        public bool DoesCursusExist(List<Cursus> cursusses)
        {
            foreach (var cursusInstantie in cursusses)
            {
                bool alreadyExists = DoesCursusNotExist(cursusInstantie);
                if (alreadyExists == true)
                {
                    return true;
                }
            }

            return false;
        }

        public bool DoesCursusNotExist(Cursus cursus)
        {
            var existingCursusses = repository.GetCursussen();

            if (existingCursusses == null)
            {
                return false;
            }

            if (existingCursusses.Count(x => x.Code.Equals(cursus.Code)) > 0)
            {
                return false;
            }

            return true;
        }

        public bool DoesCursusHaveFilledAttributes(List<Cursus> cursusses)
        {
            foreach (var cursus in cursusses)
            {
                bool alreadyExists = DoesCursusHaveFilledAttributes(cursus);
                if (alreadyExists == true)
                {
                    return true;
                }
            }

            return false;
        }

        public bool DoesCursusHaveFilledAttributes(Cursus cursus)
        {
            foreach (var property in cursus.GetType().GetProperties())
            {
                if(property.PropertyType == typeof(string))
                {
                    string value = (string)property.GetValue(cursus);
                    if (string.IsNullOrWhiteSpace(value))
                    {
                        return false;
                    }
                    if (property.Name.Equals("duur", System.StringComparison.OrdinalIgnoreCase))
                    {
                        if (!value.Contains("dagen"))
                        {
                            return false;
                        }
                    }
                }
            }
            
            return true;
        }
    }
}