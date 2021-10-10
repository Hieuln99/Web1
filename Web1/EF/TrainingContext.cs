using Web1.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Web1.EF
{
    public class TrainingContext: DbContext
    {
        public TrainingContext() : base("BwConnection")
        {

        }

        public DbSet<CourseCategory> category { get; set; }
        public DbSet<Course> course { get; set; }
        public DbSet<Trainer> trainer { get; set; }
        public DbSet<Trainee> trainee { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Trainer>().ToTable("Trainer");
            modelBuilder.Entity<Trainer>().HasKey<int>(b => b.id);
            modelBuilder.Entity<Trainer>().Property(b => b.Name).HasColumnType("varchar").HasMaxLength(50);
            modelBuilder.Entity<Trainer>().Property(b => b.Email).HasColumnType("varchar").HasMaxLength(30);
            modelBuilder.Entity<Trainer>().Property(b => b.Phonenumber).HasColumnType("varchar").HasMaxLength(12);
            modelBuilder.Entity<Trainer>().Property(b => b.Workplace).HasColumnType("varchar").HasMaxLength(15);

            modelBuilder.Entity<Course>().ToTable("Course");
            modelBuilder.Entity<Course>().HasKey<int>(r => r.id);
            modelBuilder.Entity<Course>().Property(r => r.Name).HasColumnType("varchar").HasMaxLength(50);

            modelBuilder.Entity<CourseCategory>().ToTable("Category");
            modelBuilder.Entity<CourseCategory>().HasKey<int>(r => r.id);
            modelBuilder.Entity<CourseCategory>().Property(r => r.Name).HasColumnType("varchar").HasMaxLength(50);

            modelBuilder.Entity<Trainee>().ToTable("Trainee");
            modelBuilder.Entity<Trainee>().HasKey<int>(s => s.id);
            modelBuilder.Entity<Trainee>().Property(s => s.Name).HasColumnType("varchar").HasMaxLength(50);
            modelBuilder.Entity<Trainee>().Property(s => s.UserName).HasColumnType("varchar").HasMaxLength(50);
            modelBuilder.Entity<Trainee>().Property(s => s.Edu).HasColumnType("varchar").HasMaxLength(50);
            modelBuilder.Entity<Trainee>().Property(s => s.Language).HasColumnType("varchar").HasMaxLength(30);
            modelBuilder.Entity<Trainee>().Property(s => s.Location).HasColumnType("varchar").HasMaxLength(50);
            modelBuilder.Entity<Trainee>().Property(s => s.Department).HasColumnType("varchar").HasMaxLength(50);
        }

    }
}