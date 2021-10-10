namespace Web1.EF.TrainingMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Course", "Description", c => c.String(nullable: false));
            AddColumn("dbo.Trainee", "UserName", c => c.String(maxLength: 50, unicode: false));
            AddColumn("dbo.Trainee", "Age", c => c.Int(nullable: false));
            AddColumn("dbo.Trainee", "DOB", c => c.DateTime(nullable: false));
            AddColumn("dbo.Trainee", "Edu", c => c.String(maxLength: 50, unicode: false));
            AddColumn("dbo.Trainee", "Language", c => c.String(maxLength: 30, unicode: false));
            AddColumn("dbo.Trainee", "Toeic", c => c.Int(nullable: false));
            AddColumn("dbo.Trainee", "Exp", c => c.String());
            AddColumn("dbo.Trainee", "Department", c => c.String(maxLength: 50, unicode: false));
            AddColumn("dbo.Trainee", "Location", c => c.String(maxLength: 50, unicode: false));
            AddColumn("dbo.Trainer", "Type", c => c.Boolean(nullable: false));
            AddColumn("dbo.Trainer", "Workplace", c => c.String(nullable: false, maxLength: 15, unicode: false));
            AddColumn("dbo.Trainer", "Email", c => c.String(nullable: false, maxLength: 30, unicode: false));
            AddColumn("dbo.Trainer", "Phonenumber", c => c.String(nullable: false, maxLength: 12, unicode: false));
            AlterColumn("dbo.Category", "Name", c => c.String(nullable: false, maxLength: 50, unicode: false));
            AlterColumn("dbo.Category", "Describe", c => c.String(nullable: false));
            DropColumn("dbo.Course", "Date");
            DropColumn("dbo.Course", "Size");
            DropColumn("dbo.Trainee", "Email");
            DropColumn("dbo.Trainee", "Contact");
            DropColumn("dbo.Trainer", "DOB");
            DropColumn("dbo.Trainer", "SSID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Trainer", "SSID", c => c.String(nullable: false, maxLength: 15, unicode: false));
            AddColumn("dbo.Trainer", "DOB", c => c.DateTime(nullable: false));
            AddColumn("dbo.Trainee", "Contact", c => c.String(nullable: false, maxLength: 50, unicode: false));
            AddColumn("dbo.Trainee", "Email", c => c.String(nullable: false, maxLength: 50, unicode: false));
            AddColumn("dbo.Course", "Size", c => c.Int(nullable: false));
            AddColumn("dbo.Course", "Date", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Category", "Describe", c => c.String());
            AlterColumn("dbo.Category", "Name", c => c.String(maxLength: 50, unicode: false));
            DropColumn("dbo.Trainer", "Phonenumber");
            DropColumn("dbo.Trainer", "Email");
            DropColumn("dbo.Trainer", "Workplace");
            DropColumn("dbo.Trainer", "Type");
            DropColumn("dbo.Trainee", "Location");
            DropColumn("dbo.Trainee", "Department");
            DropColumn("dbo.Trainee", "Exp");
            DropColumn("dbo.Trainee", "Toeic");
            DropColumn("dbo.Trainee", "Language");
            DropColumn("dbo.Trainee", "Edu");
            DropColumn("dbo.Trainee", "DOB");
            DropColumn("dbo.Trainee", "Age");
            DropColumn("dbo.Trainee", "UserName");
            DropColumn("dbo.Course", "Description");
        }
    }
}
