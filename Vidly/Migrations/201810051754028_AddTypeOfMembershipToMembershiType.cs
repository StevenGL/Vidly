namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTypeOfMembershipToMembershiType : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MembershipTypes", "TypeOfMembership", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.MembershipTypes", "TypeOfMembership");
        }
    }
}
