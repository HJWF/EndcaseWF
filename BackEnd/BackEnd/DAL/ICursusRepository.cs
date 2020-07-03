using System;
using System.Collections.Generic;
using BackEnd.Models;

namespace BackEnd.DAL
{
    public interface ICursusRepository : IDisposable
    {
        IEnumerable<CursusInstantie> GetCursusInstanties();

        IEnumerable<Cursus> GetCursussen();

        CursusInstantie GetCursusInstantieById(int id);

        Cursus GetCursusById(int id);

        void AddCursusInstantie(CursusInstantie cursusInstantie);

        void AddCursus(Cursus cursus);

        void Save();
    }
}
