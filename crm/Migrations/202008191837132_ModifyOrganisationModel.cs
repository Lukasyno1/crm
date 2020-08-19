namespace crm.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifyOrganisationModel : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Organisations", newName: "OrganisationModels");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.OrganisationModels", newName: "Organisations");
        }
    }
}
