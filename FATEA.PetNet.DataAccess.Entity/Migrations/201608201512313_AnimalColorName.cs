namespace FATEA.PetNet.DataAccess.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AnimalColorName : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.ANI_ANIMALS", name: "Color", newName: "ANI_COLOR");
        }
        
        public override void Down()
        {
            RenameColumn(table: "dbo.ANI_ANIMALS", name: "ANI_COLOR", newName: "Color");
        }
    }
}
