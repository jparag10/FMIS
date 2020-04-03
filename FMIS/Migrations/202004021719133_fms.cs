namespace FMIS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fms : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.DieticianDataEntries", "Dietician_did", "dbo.Dieticians");
            DropIndex("dbo.DieticianDataEntries", new[] { "Dietician_did" });
            AddColumn("dbo.DieticianDataEntries", "dieticianid", c => c.Int());
            AlterColumn("dbo.DieticianDataEntries", "Disease", c => c.String());
            DropColumn("dbo.DieticianDataEntries", "Dietician_did");
        }
        
        public override void Down()
        {
            AddColumn("dbo.DieticianDataEntries", "Dietician_did", c => c.Int());
            AlterColumn("dbo.DieticianDataEntries", "Disease", c => c.Int(nullable: false));
            DropColumn("dbo.DieticianDataEntries", "dieticianid");
            CreateIndex("dbo.DieticianDataEntries", "Dietician_did");
            AddForeignKey("dbo.DieticianDataEntries", "Dietician_did", "dbo.Dieticians", "did");
        }
    }
}
