namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SetMembershiptypes : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE MembershipTypes SET TypeOfMembership = 'Pay as you go' WHERE Id = 1");
            Sql("UPDATE MembershipTypes SET TypeOfMembership = 'Monthly' WHERE Id = 2");
            Sql("UPDATE MembershipTypes SET TypeOfMembership = 'Quarterly' WHERE Id = 3");
            Sql("UPDATE MembershipTypes SET TypeOfMembership = 'Annual' WHERE Id = 4");
        }
        
        public override void Down()
        {
        }
    }
}
