namespace FATEA.PetNet.DataAccess.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AnimalTableCreation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ANI_ANIMALS",
                c => new
                    {
                        ANI_ID = c.Long(nullable: false, identity: true),
                        ANI_NAME = c.String(nullable: false, maxLength: 50),
                        ANI_BREED = c.String(nullable: false, maxLength: 20),
                        ANI_AGE = c.Int(nullable: false),
                        Color = c.String(nullable: false, maxLength: 25),
                        ANI_BIRTH_DATE = c.DateTime(nullable: false),
                        ANI_IS_CASTRADE = c.Boolean(nullable: false),
                        ANI_GENDER = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ANI_ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ANI_ANIMALS");
        }
    }
}
