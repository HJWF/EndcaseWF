namespace BackEnd.Migrations
{
    using System.Data.Entity.Migrations;
    using BackEnd.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<BackEnd.Data.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(BackEnd.Data.ApplicationDbContext context)
        {
            context.Cursussen.AddOrUpdate(x => x.Id,
                new Cursus { Id = 1, Duur = "5 dagen", Code = "ABC", Titel = "cursus 1" },
                new Cursus { Id = 2, Duur = "3 dagen", Code = "KLM", Titel = "cursus 2" },
                new Cursus { Id = 3, Duur = "2 dagen", Code = "XYZ", Titel = "cursus 3" }
                );
        }
    }
}
