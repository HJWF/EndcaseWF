namespace BackEnd.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class startDatumNuDateTime : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.CursusInstanties", "StartDatum", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.CursusInstanties", "StartDatum", c => c.String(nullable: false));
        }
    }
}
