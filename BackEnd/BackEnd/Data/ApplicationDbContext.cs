using System.Data.Entity;
using BackEnd.Models;

namespace BackEnd.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext() : base("EndCaseWFConnectionString")
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public DbSet<Cursus> Cursussen { get; set; }
        public DbSet<CursusInstantie> CursusInstanties { get; set; }
    }
}