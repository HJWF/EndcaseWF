using System;
using BackEnd.Models;

namespace BackEnd.Test.Builders
{
    public class CursusInstantieBuilder
    {
        private readonly CursusInstantie _cursusInstantie;
        private readonly Random _random = new Random();

        private CursusInstantieBuilder()
        {
            _cursusInstantie = new CursusInstantie
            {
                Id = _random.Next()
            };
        }

        public static CursusInstantieBuilder New()
        {
            return new CursusInstantieBuilder();
        }

        public CursusInstantieBuilder WithStartDate(DateTime startDate)
        {
            _cursusInstantie.StartDatum = startDate;

            return this;
        }

        public CursusInstantie Build()
        {
            return _cursusInstantie;
        }
    }
}
