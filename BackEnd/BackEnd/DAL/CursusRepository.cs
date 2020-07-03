using System;
using System.Collections.Generic;
using System.Data.Entity;
using BackEnd.Data;
using BackEnd.Models;

namespace BackEnd.DAL
{
    public class CursusRepository : ICursusRepository, IDisposable
    {
        private readonly ApplicationDbContext context;

        public CursusRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<CursusInstantie> GetCursusInstanties()
        {
            var cursussen = context.CursusInstanties.Include(x => x.Cursus);

            return cursussen;
        }

        public IEnumerable<Cursus> GetCursussen()
        {
            var cursussen = context.Cursussen;

            return cursussen;
        }

        public void AddCursusInstantie(CursusInstantie cursusInstantie)
        {
            context.CursusInstanties.Add(cursusInstantie);
        }

        public void AddCursus(Cursus cursus)
        {
            context.Cursussen.Add(cursus);
        }

        public CursusInstantie GetCursusInstantieById(int id)
        {
            return context.CursusInstanties.Find(id);
        }

        public Cursus GetCursusById(int id)
        {
            return context.Cursussen.Find(id);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}