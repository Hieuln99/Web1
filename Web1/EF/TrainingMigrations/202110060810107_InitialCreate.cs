namespace Web1.EF.TrainingMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50, unicode: false),
                        Describe = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Course",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50, unicode: false),
                        Date = c.DateTime(nullable: false),
                        Size = c.Int(nullable: false),
                        categoryid = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Category", t => t.categoryid, cascadeDelete: true)
                .Index(t => t.categoryid);
            
            CreateTable(
                "dbo.Trainee",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50, unicode: false),
                        Email = c.String(nullable: false, maxLength: 50, unicode: false),
                        Contact = c.String(nullable: false, maxLength: 50, unicode: false),
                        courseid = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Course", t => t.courseid, cascadeDelete: true)
                .Index(t => t.courseid);
            
            CreateTable(
                "dbo.Trainer",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50, unicode: false),
                        DOB = c.DateTime(nullable: false),
                        SSID = c.String(nullable: false, maxLength: 15, unicode: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.TrainerCourses",
                c => new
                    {
                        Trainer_id = c.Int(nullable: false),
                        Course_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Trainer_id, t.Course_id })
                .ForeignKey("dbo.Trainer", t => t.Trainer_id, cascadeDelete: true)
                .ForeignKey("dbo.Course", t => t.Course_id, cascadeDelete: true)
                .Index(t => t.Trainer_id)
                .Index(t => t.Course_id);
            

        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TrainerCourses", "Course_id", "dbo.Course");
            DropForeignKey("dbo.TrainerCourses", "Trainer_id", "dbo.Trainer");
            DropForeignKey("dbo.Trainee", "courseid", "dbo.Course");
            DropForeignKey("dbo.Course", "categoryid", "dbo.Category");
            DropIndex("dbo.TrainerCourses", new[] { "Course_id" });
            DropIndex("dbo.TrainerCourses", new[] { "Trainer_id" });
            DropIndex("dbo.Trainee", new[] { "courseid" });
            DropIndex("dbo.Course", new[] { "categoryid" });
            DropTable("dbo.TrainerCourses");
            DropTable("dbo.Trainer");
            DropTable("dbo.Trainee");
            DropTable("dbo.Course");
            DropTable("dbo.Category");
        }
    }
}
