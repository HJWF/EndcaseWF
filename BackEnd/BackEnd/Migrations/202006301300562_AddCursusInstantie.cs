namespace BackEnd.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AddCursusInstantie : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CursusInstanties", "Cursus_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.CursusInstanties", "Cursus_Id");
            AddForeignKey("dbo.CursusInstanties", "Cursus_Id", "dbo.Cursus", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CursusInstanties", "Cursus_Id", "dbo.Cursus");
            DropIndex("dbo.CursusInstanties", new[] { "Cursus_Id" });
            DropColumn("dbo.CursusInstanties", "Cursus_Id");
        }
    }
}
