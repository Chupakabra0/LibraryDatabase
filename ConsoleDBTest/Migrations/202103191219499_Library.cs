namespace ConsoleDBTest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Library : DbMigration
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
                        IsActive = c.Boolean(nullable: false),
                        AuthorId = c.Int(nullable: false),
                        PublisherId = c.Int(nullable: false),
                        GenreId = c.Int(nullable: false),
                        LibraryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Authors", t => t.AuthorId, cascadeDelete: true)
                .ForeignKey("dbo.Publishers", t => t.PublisherId, cascadeDelete: true)
                .ForeignKey("dbo.Genres", t => t.GenreId, cascadeDelete: true)
                .ForeignKey("dbo.Libraries", t => t.LibraryId, cascadeDelete: true)
                .Index(t => t.AuthorId)
                .Index(t => t.PublisherId)
                .Index(t => t.GenreId)
                .Index(t => t.LibraryId);
            
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
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cathedras", t => t.CathedraId, cascadeDelete: true)
                .ForeignKey("dbo.FacultyAndSpecialties", t => t.FacultyAndSpecialtyId, cascadeDelete: true)
                .Index(t => t.FacultyAndSpecialtyId)
                .Index(t => t.CathedraId);
            
            CreateTable(
                "dbo.Groups",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Year = c.Int(nullable: false),
                        Serial = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        FacultyAndSpecialtyAndCathedraId = c.Int(nullable: false),
                        DegreeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.FacultyAndSpecialtyAndCathedras", t => t.FacultyAndSpecialtyAndCathedraId, cascadeDelete: true)
                .ForeignKey("dbo.Degrees", t => t.DegreeId, cascadeDelete: true)
                .Index(t => t.FacultyAndSpecialtyAndCathedraId)
                .Index(t => t.DegreeId);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Surname = c.String(),
                        Patronymic = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        CityId = c.Int(nullable: false),
                        GroupId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Groups", t => t.GroupId, cascadeDelete: true)
                .ForeignKey("dbo.Cities", t => t.CityId, cascadeDelete: true)
                .Index(t => t.CityId)
                .Index(t => t.GroupId);
            
            CreateTable(
                "dbo.ClientCards",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateGiven = c.DateTime(),
                        IsActive = c.Boolean(nullable: false),
                        Student_Id = c.Int(),
                        Teacher_Id = c.Int(),
                        Library_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Students", t => t.Student_Id)
                .ForeignKey("dbo.Teachers", t => t.Teacher_Id)
                .ForeignKey("dbo.Libraries", t => t.Library_Id)
                .Index(t => t.Student_Id)
                .Index(t => t.Teacher_Id)
                .Index(t => t.Library_Id);
            
            CreateTable(
                "dbo.Teachers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Surname = c.String(),
                        Patronymic = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        CityId = c.Int(nullable: false),
                        CathedraId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cathedras", t => t.CathedraId, cascadeDelete: true)
                .ForeignKey("dbo.Cities", t => t.CityId, cascadeDelete: true)
                .Index(t => t.CityId)
                .Index(t => t.CathedraId);
            
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
                "dbo.Cities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        CountryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Countries", t => t.CountryId, cascadeDelete: true)
                .Index(t => t.CountryId);
            
            CreateTable(
                "dbo.Publishers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        CityId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cities", t => t.CityId, cascadeDelete: true)
                .Index(t => t.CityId);
            
            CreateTable(
                "dbo.Degrees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Faculties",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ShortName = c.String(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.FacultyAndSpecialties",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsActive = c.Boolean(nullable: false),
                        FacultyId = c.Int(nullable: false),
                        SpecialtyId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Faculties", t => t.FacultyId, cascadeDelete: true)
                .ForeignKey("dbo.Specialties", t => t.SpecialtyId, cascadeDelete: true)
                .Index(t => t.FacultyId)
                .Index(t => t.SpecialtyId);
            
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
                "dbo.Libraries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TakeDate = c.DateTime(),
                        ReturnDate = c.DateTime(),
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
                        LibraryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Libraries", t => t.LibraryId, cascadeDelete: true)
                .Index(t => t.LibraryId);
            
            CreateTable(
                "dbo.Specialties",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FacultyAndSpecialties", "SpecialtyId", "dbo.Specialties");
            DropForeignKey("dbo.Workers", "LibraryId", "dbo.Libraries");
            DropForeignKey("dbo.ClientCards", "Library_Id", "dbo.Libraries");
            DropForeignKey("dbo.Books", "LibraryId", "dbo.Libraries");
            DropForeignKey("dbo.Books", "GenreId", "dbo.Genres");
            DropForeignKey("dbo.FacultyAndSpecialties", "FacultyId", "dbo.Faculties");
            DropForeignKey("dbo.FacultyAndSpecialtyAndCathedras", "FacultyAndSpecialtyId", "dbo.FacultyAndSpecialties");
            DropForeignKey("dbo.Groups", "DegreeId", "dbo.Degrees");
            DropForeignKey("dbo.Cities", "CountryId", "dbo.Countries");
            DropForeignKey("dbo.Teachers", "CityId", "dbo.Cities");
            DropForeignKey("dbo.Students", "CityId", "dbo.Cities");
            DropForeignKey("dbo.Publishers", "CityId", "dbo.Cities");
            DropForeignKey("dbo.Books", "PublisherId", "dbo.Publishers");
            DropForeignKey("dbo.Teachers", "CathedraId", "dbo.Cathedras");
            DropForeignKey("dbo.ClientCards", "Teacher_Id", "dbo.Teachers");
            DropForeignKey("dbo.FacultyAndSpecialtyAndCathedras", "CathedraId", "dbo.Cathedras");
            DropForeignKey("dbo.Groups", "FacultyAndSpecialtyAndCathedraId", "dbo.FacultyAndSpecialtyAndCathedras");
            DropForeignKey("dbo.Students", "GroupId", "dbo.Groups");
            DropForeignKey("dbo.ClientCards", "Student_Id", "dbo.Students");
            DropForeignKey("dbo.Books", "AuthorId", "dbo.Authors");
            DropIndex("dbo.Workers", new[] { "LibraryId" });
            DropIndex("dbo.FacultyAndSpecialties", new[] { "SpecialtyId" });
            DropIndex("dbo.FacultyAndSpecialties", new[] { "FacultyId" });
            DropIndex("dbo.Publishers", new[] { "CityId" });
            DropIndex("dbo.Cities", new[] { "CountryId" });
            DropIndex("dbo.Teachers", new[] { "CathedraId" });
            DropIndex("dbo.Teachers", new[] { "CityId" });
            DropIndex("dbo.ClientCards", new[] { "Library_Id" });
            DropIndex("dbo.ClientCards", new[] { "Teacher_Id" });
            DropIndex("dbo.ClientCards", new[] { "Student_Id" });
            DropIndex("dbo.Students", new[] { "GroupId" });
            DropIndex("dbo.Students", new[] { "CityId" });
            DropIndex("dbo.Groups", new[] { "DegreeId" });
            DropIndex("dbo.Groups", new[] { "FacultyAndSpecialtyAndCathedraId" });
            DropIndex("dbo.FacultyAndSpecialtyAndCathedras", new[] { "CathedraId" });
            DropIndex("dbo.FacultyAndSpecialtyAndCathedras", new[] { "FacultyAndSpecialtyId" });
            DropIndex("dbo.Books", new[] { "LibraryId" });
            DropIndex("dbo.Books", new[] { "GenreId" });
            DropIndex("dbo.Books", new[] { "PublisherId" });
            DropIndex("dbo.Books", new[] { "AuthorId" });
            DropTable("dbo.Specialties");
            DropTable("dbo.Workers");
            DropTable("dbo.Libraries");
            DropTable("dbo.Genres");
            DropTable("dbo.FacultyAndSpecialties");
            DropTable("dbo.Faculties");
            DropTable("dbo.Degrees");
            DropTable("dbo.Publishers");
            DropTable("dbo.Cities");
            DropTable("dbo.Countries");
            DropTable("dbo.Teachers");
            DropTable("dbo.ClientCards");
            DropTable("dbo.Students");
            DropTable("dbo.Groups");
            DropTable("dbo.FacultyAndSpecialtyAndCathedras");
            DropTable("dbo.Cathedras");
            DropTable("dbo.Books");
            DropTable("dbo.Authors");
        }
    }
}
