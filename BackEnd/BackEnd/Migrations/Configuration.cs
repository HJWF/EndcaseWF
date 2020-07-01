namespace BackEnd.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using BackEnd.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<BackEnd.Data.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Data.ApplicationDbContext context)
        {
            var cursus1 = new Cursus { Id = 1, Duur = "5 dagen", Code = "ABC", Titel = "cursus 1" };
            var cursus2 = new Cursus { Id = 2, Duur = "3 dagen", Code = "KLM", Titel = "cursus 2" };
            var cursus3 = new Cursus { Id = 3, Duur = "2 dagen", Code = "XYZ", Titel = "cursus 3" };

            context.Cursussen.AddOrUpdate(x => x.Id,
                cursus1, cursus2, cursus3
                );

            context.CursusInstanties.AddOrUpdate(x => x.Id,
                new CursusInstantie { Id = 1, StartDatum = new DateTime(2010, 10, 10), Cursus = cursus1 },
                new CursusInstantie { Id = 2, StartDatum = new DateTime(2011, 11, 11), Cursus = cursus1 },
                new CursusInstantie { Id = 3, StartDatum = new DateTime(2010, 05, 05), Cursus = cursus2 },
                new CursusInstantie { Id = 4, StartDatum = new DateTime(2010, 08, 08), Cursus = cursus3 },
                new CursusInstantie { Id = 5, StartDatum = new DateTime(2012, 12, 12), Cursus = cursus2 }
                );
        }
    }
}
