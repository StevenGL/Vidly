namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'56c048d2-da1a-4401-885c-607054fac464', N'admin@vidly.com', 0, N'AEaLgcVmohxDpbv/zsZ+SIaHvmOGgJesQEYLr614K0rG2fb9eJ8FqoDf8KEVjCyR2Q==', N'4fc9903e-6476-4fb8-ab9f-d939c154abf3', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'5aed5f0d-7b64-427a-b51d-771868046215', N'guest@vidly.com', 0, N'AFM8uAZAJ/zgGLIG3JJEbTxkDtaYvETf47tPgIXJGeA2zfmjExBFFNv0UoHRGlOCzw==', N'413ef86c-6e30-4cd6-8e63-996d7a1b3ede', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'c8ed3636-0e9a-4b0a-b9fa-d87bbc4b58c8', N'CanManageMovies')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'56c048d2-da1a-4401-885c-607054fac464', N'c8ed3636-0e9a-4b0a-b9fa-d87bbc4b58c8')

");
        }
        
        public override void Down()
        {
        }
    }
}
