namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifyForeignkey : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Customers", "MembershipTypes_Id", "dbo.MembershipTypes");
            DropIndex("dbo.Customers", new[] { "MembershipTypes_Id" });
            RenameColumn(table: "dbo.Customers", name: "MembershipTypes_Id", newName: "MembershipTypesId");
            AlterColumn("dbo.Customers", "MembershipTypesId", c => c.Int(nullable: false));
            CreateIndex("dbo.Customers", "MembershipTypesId");
            AddForeignKey("dbo.Customers", "MembershipTypesId", "dbo.MembershipTypes", "Id", cascadeDelete: true);
            DropColumn("dbo.Customers", "MembershipTypeId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "MembershipTypeId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Customers", "MembershipTypesId", "dbo.MembershipTypes");
            DropIndex("dbo.Customers", new[] { "MembershipTypesId" });
            AlterColumn("dbo.Customers", "MembershipTypesId", c => c.Int());
            RenameColumn(table: "dbo.Customers", name: "MembershipTypesId", newName: "MembershipTypes_Id");
            CreateIndex("dbo.Customers", "MembershipTypes_Id");
            AddForeignKey("dbo.Customers", "MembershipTypes_Id", "dbo.MembershipTypes", "Id");
        }
    }
}
