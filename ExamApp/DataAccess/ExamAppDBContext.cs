using ExamApp.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace ExamApp.DataAccess
{
    public class ExamAppDBContext : DbContext
    {
        //public DbSet<Class> Classes { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Exam> Exams { get; set; }

        public ExamAppDBContext(DbContextOptions<ExamAppDBContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Class>()
            //        .ToTable(name: "CLASSES", schema: "TBL")
            //        .HasKey(c => c.ID);

            //modelBuilder.Entity<Class>()
            //    .Property(c => c.ID)
            //    .HasColumnType("smallint")
            //    .HasColumnName("CLASS_ID");


            modelBuilder.Entity<Lesson>()
                    .ToTable(name: "LESSONS", schema: "TBL")
                    .HasKey(l => l.ID);

            modelBuilder.Entity<Lesson>()
                .Property(l => l.ID)
                .IsRequired()
                .HasColumnName("LESSON_ID");

            modelBuilder.Entity<Lesson>()
                .Property(l => l.LessonCode)
                .IsRequired()
                .HasColumnType("char(3)")
                .HasColumnName("LESSON_CODE");

            modelBuilder.Entity<Lesson>()
                .Property(l => l.LessonName)
                .IsRequired()
                .HasMaxLength(30)
                .HasColumnType("varchar(30)")
                .HasColumnName("LESSON_NAME");

            modelBuilder.Entity<Lesson>()
                .Property(l => l.ClassNumber)
                .IsRequired()
                .HasColumnType("smallint")
                .HasColumnName("CLASS_NUMBER");

            modelBuilder.Entity<Lesson>()
                .Property(l => l.TeacherName)
                .IsRequired()
                .HasMaxLength(20)
                .HasColumnType("varchar(20)")
                .HasColumnName("TEACHER_NAME");

            modelBuilder.Entity<Lesson>()
                .Property(l => l.TeacherSurname)
                .IsRequired()
                .HasMaxLength(20)
                .HasColumnType("varchar(20)")
                .HasColumnName("TEACHER_SURNAME");




            modelBuilder.Entity<Student>()
                    .ToTable(name: "STUDENTS", schema: "TBL")
                    .HasKey(s => s.ID);

            modelBuilder.Entity<Student>()
                .Property(s => s.ID)
                .IsRequired()
                .HasColumnName("STUDENT_ID");

            modelBuilder.Entity<Student>()
                .Property(s => s.StudentNumber)
                .IsRequired()
                .HasColumnType("SMALLINT")
                .HasColumnName("STUDENT_NUMBER");

            modelBuilder.Entity<Student>()
                .Property(s => s.StudentName)
                .IsRequired()
                .HasMaxLength(30)
                .HasColumnType("VARCHAR(30)")
                .HasColumnName("STUDENT_NAME");

            modelBuilder.Entity<Student>()
                .Property(s => s.StudentSurname)
                .IsRequired()
                .HasMaxLength(30)
                .HasColumnType("VARCHAR(30)")
                .HasColumnName("STUDENT_SURNAME");

            modelBuilder.Entity<Student>()
                .Property(s => s.ClassNumber)
                .IsRequired()
                .HasColumnType("SMALLINT")
                .HasColumnName("CLASS_NUMBER");




            modelBuilder.Entity<Exam>()
                    .ToTable(name: "EXAMS", schema: "TBL")
                    .HasKey(e => e.ID);

            modelBuilder.Entity<Exam>()
                .Property(s => s.ID)
                .IsRequired()
                .HasColumnName("EXAM_ID");

            modelBuilder.Entity<Exam>()
                .HasOne(e => e.Lesson)
                .WithMany(l => l.Exams)
                .HasForeignKey(e => e.LessonCode)
                .HasPrincipalKey(l => l.LessonCode);

            modelBuilder.Entity<Exam>()
                .HasOne(e => e.Student)
                .WithMany(s => s.Exams)
                .HasForeignKey(e => e.StudentNumber)
                .HasPrincipalKey(s => s.StudentNumber);

            modelBuilder.Entity<Exam>()
                .Property(e => e.LessonCode)
                .IsRequired()
                .HasColumnType("char(3)")
                .HasColumnName("LESSON_CODE");

            modelBuilder.Entity<Exam>()
                .Property(e => e.StudentNumber)
                .IsRequired()
                .HasColumnType("smallint")
                .HasColumnName("STUDENT_NUMBER");

            modelBuilder.Entity<Exam>()
                .Property(e => e.ExamDate)
                .IsRequired()
                .HasColumnType("DATE")
                .HasColumnName("EXAM_DATE");

            modelBuilder.Entity<Exam>()
                .Property(e => e.Grade)
                .IsRequired()
                .HasColumnType("smallint")
                .HasColumnName("GRADE");
        }
    }
}