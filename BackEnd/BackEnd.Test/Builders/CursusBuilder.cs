using System;
using BackEnd.Models;

namespace BackEnd.Test.Builders
{
    public class CursusBuilder
    {
        private Cursus _cursus;
        private readonly Random _random = new Random();

        private CursusBuilder()
        {

            _cursus = new Cursus
            {
                Id = _random.Next()
            };
        }

        public static CursusBuilder New()
        {
            return new CursusBuilder();
        }

        public CursusBuilder WithDuur(string duur)
        {
            _cursus.Duur = duur;

            return this;
        }

        public CursusBuilder WithCode(string code)
        {
            _cursus.Code = code;

            return this;
        }

        public CursusBuilder WithTitel(string titel)
        {
            _cursus.Titel = titel;

            return this;
        }

        public Cursus Build()
        {
            return _cursus;
        }
    }
}
