using GraduationWorksOrganizer.Database.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GraduationWorksOrganizer.Database
{
    public class GraduationWorksOrganizerDataContext : IdentityDbContext
    {
        #region DbSets

        public DbSet<Teacher> Teachers { get; set; }

        public DbSet<Student> Students { get; set; }

        public DbSet<GraduationWorkBlanckRequest> GraduationWorkBlanckRequests { get; set; }

        public DbSet<Faculty> Faculties { get; set; }

        public DbSet<Department> Deparments { get; set; }

        public DbSet<Specialty> Specialties { get; set; }

        #endregion // DbSets

        #region Constructor

        public GraduationWorksOrganizerDataContext(DbContextOptions<GraduationWorksOrganizerDataContext> options)
            : base(options)
        {
        }

        #endregion // Constructor

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Graph types
            builder.Entity<Teacher>().HasBaseType<IdentityUser>();
            builder.Entity<Student>().HasBaseType<IdentityUser>();

            // PrimaryKeys
            builder.Entity<GraduationWorkBlanckRequest>().HasKey(gwbr => gwbr.GraduationWorkBlanckRequestId);
            builder.Entity<Faculty>().HasKey(f => f.FacultyId);
            builder.Entity<Department>().HasKey(d => d.DepartmentId);
            builder.Entity<Specialty>().HasKey(s => s.SpecialtyId);

            // Relations
            builder.Entity<Faculty>().HasMany(f => f.Departments).WithOne(d => d.Faculty).HasForeignKey(d => d.FacultyId).OnDelete(DeleteBehavior.Cascade);
            builder.Entity<Department>().HasMany(d => d.Specialties).WithOne(s => s.Department).HasForeignKey(s => s.DepartmentId).OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Teacher>().HasOne(t => t.Department).WithMany().HasForeignKey(t => t.DepartmentId).OnDelete(DeleteBehavior.NoAction);
            builder.Entity<Student>().HasOne(s => s.Specialty).WithMany().HasForeignKey(s => s.SpecialtyId).OnDelete(DeleteBehavior.NoAction);

            // Seeds
            builder.Entity<Faculty>().HasData(new object[]
            {
                new Faculty(){FacultyId = 1, FacultyName = "Факултет Компютърни системи и технологии"},
                new Faculty(){FacultyId = 2, FacultyName = "Факултет по телекомуникации"},
            });
            builder.Entity<Department>().HasData(new object[]
            {
                new Department(){DepartmentId = 1, DepartmentName = "Програмиране и компютърни технологии",FacultyId = 1},
                new Department(){DepartmentId = 2, DepartmentName = "Компютърни системи",FacultyId = 1},

                new Department(){DepartmentId = 3, DepartmentName = "Радиокомуникации и видеотехнологии",FacultyId = 2},
            });
            builder.Entity<Specialty>().HasData(new object[]
            {
                new Specialty(){SpecialtyId = 1, SpecialtyName = "Графичен и web дизайн", DepartmentId = 1, SpecialtyType = SpecialtyType.Bachelor},

                new Specialty(){SpecialtyId = 2, SpecialtyName = "Компютърно и софтуерно инженерство", DepartmentId = 2, SpecialtyType = SpecialtyType.Bachelor},
                new Specialty(){SpecialtyId = 3, SpecialtyName = "Компютърно и софтуерно инженерство", DepartmentId = 2, SpecialtyType = SpecialtyType.Master},

                new Specialty(){SpecialtyId = 4, SpecialtyName = "Телекомуникации", DepartmentId = 3, SpecialtyType = SpecialtyType.Bachelor},
                new Specialty(){SpecialtyId = 5, SpecialtyName = "Телекомуникационно инженерство", DepartmentId = 3, SpecialtyType = SpecialtyType.MasterAfterBachelor},
            });

        }
    }
}
