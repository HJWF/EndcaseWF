using System;
using System.Collections.Generic;
using System.Linq;
using BackEnd.DAL;
using BackEnd.Data;
using BackEnd.Models;

namespace BackEnd.Services
{
    public class CursusInstantieValidator
    {
        private ICursusRepository repository;

        public CursusInstantieValidator()
        {
            repository = new CursusRepository(new ApplicationDbContext());
        }

        public CursusInstantieValidator(ICursusRepository repository)
        {
            this.repository = repository;
        }

        public bool DoesCursusInstantiesExist(List<CursusInstantie> cursusInstanties)
        {
            foreach (var cursusInstantie in cursusInstanties)
            {
                bool alreadyExists = DoesNotCursusInstantieExist(cursusInstantie);
                if (alreadyExists == true)
                {
                    return true;
                }
            }

            return false;
        }

        public bool DoesNotCursusInstantieExist(CursusInstantie cursusInstantie)
        {
            var existingCursusInstanties = repository.GetCursusInstanties();

            if (existingCursusInstanties == null)
            {
                return false;
            }

            if (existingCursusInstanties.Where(x => DateTime.Compare(x.StartDatum, cursusInstantie.StartDatum) == 0)
                .Count(x => x.Cursus.Code.Equals(cursusInstantie.Cursus.Code)) > 0)
            {
                return false;
            }

            return true;
        }
    }
}