namespace ConsoleDBTest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Authors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Surname = c.String(),
                        Patronymic = c.String(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        AuthorId = c.Int(nullable: false),
                        PublisherId = c.Int(nullable: false),
                        GenreId = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Authors", t => t.AuthorId, cascadeDelete: true)
                .ForeignKey("dbo.Genres", t => t.GenreId, cascadeDelete: true)
                .ForeignKey("dbo.Publishers", t => t.PublisherId, cascadeDelete: true)
                .Index(t => t.AuthorId)
                .Index(t => t.PublisherId)
                .Index(t => t.GenreId);
            
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.LibraryTransactions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TakeDate = c.DateTime(),
                        ReturnDate = c.DateTime(),
                        ClientCardId = c.Int(nullable: false),
                        WorkerId = c.Int(nullable: false),
                        BookId = c.Int(nullable: false),
                        IsReturnInTime = c.Boolean(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Books", t => t.BookId, cascadeDelete: true)
                .ForeignKey("dbo.ClientCards", t => t.ClientCardId, cascadeDelete: true)
                .ForeignKey("dbo.Workers", t => t.WorkerId, cascadeDelete: true)
                .Index(t => t.ClientCardId)
                .Index(t => t.WorkerId)
                .Index(t => t.BookId);
            
            CreateTable(
                "dbo.ClientCards",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateGiven = c.DateTime(),
                        StudentId = c.Int(),
                        TeacherId = c.Int(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Teachers", t => t.TeacherId)
                .ForeignKey("dbo.Students", t => t.StudentId)
                .Index(t => t.StudentId)
                .Index(t => t.TeacherId);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Surname = c.String(),
                        Patronymic = c.String(),
                        CityId = c.Int(nullable: false),
                        GroupId = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cities", t => t.CityId, cascadeDelete: true)
                .ForeignKey("dbo.Groups", t => t.GroupId, cascadeDelete: true)
                .Index(t => t.CityId)
                .Index(t => t.GroupId);
            
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CountryId = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Countries", t => t.CountryId, cascadeDelete: true)
                .Index(t => t.CountryId);
            
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LongName = c.String(),
                        ShortName = c.String(),
                        ISOCode = c.String(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Publishers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CityId = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cities", t => t.CityId, cascadeDelete: true)
                .Index(t => t.CityId);
            
            CreateTable(
                "dbo.Teachers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Surname = c.String(),
                        Patronymic = c.String(),
                        CityId = c.Int(nullable: false),
                        CathedraId = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cathedras", t => t.CathedraId, cascadeDelete: true)
                .ForeignKey("dbo.Cities", t => t.CityId, cascadeDelete: true)
                .Index(t => t.CityId)
                .Index(t => t.CathedraId);
            
            CreateTable(
                "dbo.Cathedras",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ShortName = c.String(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.FacultyAndSpecialtyAndCathedras",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FacultyAndSpecialtyId = c.Int(nullable: false),
                        CathedraId = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cathedras", t => t.CathedraId, cascadeDelete: true)
                .ForeignKey("dbo.FacultyAndSpecialties", t => t.FacultyAndSpecialtyId, cascadeDelete: true)
                .Index(t => t.FacultyAndSpecialtyId)
                .Index(t => t.CathedraId);
            
            CreateTable(
                "dbo.FacultyAndSpecialties",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FacultyId = c.Int(nullable: false),
                        SpecialtyId = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Faculties", t => t.FacultyId, cascadeDelete: true)
                .ForeignKey("dbo.Specialties", t => t.SpecialtyId, cascadeDelete: true)
                .Index(t => t.FacultyId)
                .Index(t => t.SpecialtyId);
            
            CreateTable(
                "dbo.Faculties",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ShortName = c.String(),
                        ShortLetter = c.String(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Specialties",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ShortLetter = c.String(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Groups",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Year = c.Int(nullable: false),
                        Serial = c.Int(nullable: false),
                        FacultyAndSpecialtyAndCathedraId = c.Int(nullable: false),
                        DegreeId = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Degrees", t => t.DegreeId, cascadeDelete: true)
                .ForeignKey("dbo.FacultyAndSpecialtyAndCathedras", t => t.FacultyAndSpecialtyAndCathedraId, cascadeDelete: true)
                .Index(t => t.FacultyAndSpecialtyAndCathedraId)
                .Index(t => t.DegreeId);
            
            CreateTable(
                "dbo.Degrees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ShortLetter = c.String(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Workers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Surname = c.String(),
                        Patronymic = c.String(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LibraryTransactions", "WorkerId", "dbo.Workers");
            DropForeignKey("dbo.LibraryTransactions", "ClientCardId", "dbo.ClientCards");
            DropForeignKey("dbo.ClientCards", "StudentId", "dbo.Students");
            DropForeignKey("dbo.ClientCards", "TeacherId", "dbo.Teachers");
            DropForeignKey("dbo.Teachers", "CityId", "dbo.Cities");
            DropForeignKey("dbo.Teachers", "CathedraId", "dbo.Cathedras");
            DropForeignKey("dbo.Students", "GroupId", "dbo.Groups");
            DropForeignKey("dbo.Groups", "FacultyAndSpecialtyAndCathedraId", "dbo.FacultyAndSpecialtyAndCathedras");
            DropForeignKey("dbo.Groups", "DegreeId", "dbo.Degrees");
            DropForeignKey("dbo.FacultyAndSpecialties", "SpecialtyId", "dbo.Specialties");
            DropForeignKey("dbo.FacultyAndSpecialties", "FacultyId", "dbo.Faculties");
            DropForeignKey("dbo.FacultyAndSpecialtyAndCathedras", "FacultyAndSpecialtyId", "dbo.FacultyAndSpecialties");
            DropForeignKey("dbo.FacultyAndSpecialtyAndCathedras", "CathedraId", "dbo.Cathedras");
            DropForeignKey("dbo.Students", "CityId", "dbo.Cities");
            DropForeignKey("dbo.Publishers", "CityId", "dbo.Cities");
            DropForeignKey("dbo.Books", "PublisherId", "dbo.Publishers");
            DropForeignKey("dbo.Cities", "CountryId", "dbo.Countries");
            DropForeignKey("dbo.LibraryTransactions", "BookId", "dbo.Books");
            DropForeignKey("dbo.Books", "GenreId", "dbo.Genres");
            DropForeignKey("dbo.Books", "AuthorId", "dbo.Authors");
            DropIndex("dbo.Groups", new[] { "DegreeId" });
            DropIndex("dbo.Groups", new[] { "FacultyAndSpecialtyAndCathedraId" });
            DropIndex("dbo.FacultyAndSpecialties", new[] { "SpecialtyId" });
            DropIndex("dbo.FacultyAndSpecialties", new[] { "FacultyId" });
            DropIndex("dbo.FacultyAndSpecialtyAndCathedras", new[] { "CathedraId" });
            DropIndex("dbo.FacultyAndSpecialtyAndCathedras", new[] { "FacultyAndSpecialtyId" });
            DropIndex("dbo.Teachers", new[] { "CathedraId" });
            DropIndex("dbo.Teachers", new[] { "CityId" });
            DropIndex("dbo.Publishers", new[] { "CityId" });
            DropIndex("dbo.Cities", new[] { "CountryId" });
            DropIndex("dbo.Students", new[] { "GroupId" });
            DropIndex("dbo.Students", new[] { "CityId" });
            DropIndex("dbo.ClientCards", new[] { "TeacherId" });
            DropIndex("dbo.ClientCards", new[] { "StudentId" });
            DropIndex("dbo.LibraryTransactions", new[] { "BookId" });
            DropIndex("dbo.LibraryTransactions", new[] { "WorkerId" });
            DropIndex("dbo.LibraryTransactions", new[] { "ClientCardId" });
            DropIndex("dbo.Books", new[] { "GenreId" });
            DropIndex("dbo.Books", new[] { "PublisherId" });
            DropIndex("dbo.Books", new[] { "AuthorId" });
            DropTable("dbo.Workers");
            DropTable("dbo.Degrees");
            DropTable("dbo.Groups");
            DropTable("dbo.Specialties");
            DropTable("dbo.Faculties");
            DropTable("dbo.FacultyAndSpecialties");
            DropTable("dbo.FacultyAndSpecialtyAndCathedras");
            DropTable("dbo.Cathedras");
            DropTable("dbo.Teachers");
            DropTable("dbo.Publishers");
            DropTable("dbo.Countries");
            DropTable("dbo.Cities");
            DropTable("dbo.Students");
            DropTable("dbo.ClientCards");
            DropTable("dbo.LibraryTransactions");
            DropTable("dbo.Genres");
            DropTable("dbo.Books");
            DropTable("dbo.Authors");
        }
    }
}
