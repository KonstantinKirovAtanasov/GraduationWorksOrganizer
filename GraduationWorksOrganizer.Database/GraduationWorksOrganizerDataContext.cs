using GraduationWorksOrganizer.Common;
using GraduationWorksOrganizer.Database.Models;
using GraduationWorksOrganizer.Database.Seeds;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GraduationWorksOrganizer.Database
{
    public class GraduationWorksOrganizerDataContext : IdentityDbContext
    {
        #region DbSets

        /// <summary>
        /// Преподаватели
        /// </summary>
        public DbSet<Teacher> Teachers { get; set; }

        /// <summary>
        /// Студенти
        /// </summary>
        public DbSet<Student> Students { get; set; }

        /// <summary>
        /// Request за одобрение на дипломна тема и работа
        /// </summary>
        public DbSet<GraduationWorkBlanckRequest> GraduationWorkBlanckRequests { get; set; }

        /// <summary>
        /// Факултети
        /// </summary>
        public DbSet<Faculty> Faculties { get; set; }

        /// <summary>
        /// Катедри
        /// </summary>
        public DbSet<Department> Deparments { get; set; }

        /// <summary>
        /// Специалности
        /// </summary>
        public DbSet<Specialty> Specialties { get; set; }

        /// <summary>
        /// Групи
        /// </summary>
        public DbSet<Group> Groups { get; set; }

        /// <summary>
        /// таблица с помощни съобщения
        /// </summary>
        public DbSet<HelpMessage> HelpMessages { get; set; }

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
            builder.Entity<Faculty>().HasKey(f => f.Id);
            builder.Entity<Department>().HasKey(d => d.Id);
            builder.Entity<Specialty>().HasKey(s => s.Id);
            builder.Entity<Group>().HasKey(g => g.Id);
            builder.Entity<HelpMessage>().HasKey(hm => hm.Id);

            // Relations
            builder.Entity<Faculty>().HasMany(f => f.Departments).WithOne(d => d.Faculty).HasForeignKey(d => d.FacultyId).OnDelete(DeleteBehavior.Cascade);
            builder.Entity<Department>().HasMany(d => d.Specialties).WithOne(s => s.Department).HasForeignKey(s => s.DepartmentId).OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Teacher>().HasOne(t => t.Department).WithMany().HasForeignKey(t => t.DepartmentId).OnDelete(DeleteBehavior.NoAction);
            builder.Entity<Student>().HasOne(s => s.Specialty).WithMany().HasForeignKey(s => s.SpecialtyId).OnDelete(DeleteBehavior.NoAction);
            builder.Entity<Student>().HasOne(s => s.Group).WithMany(g => g.Students).HasForeignKey(s => s.GroupId).OnDelete(DeleteBehavior.NoAction);

            builder.Entity<Group>().HasOne(g => g.Specialty).WithMany().HasForeignKey(g => g.SpecialtyId).OnDelete(DeleteBehavior.NoAction);
            // Seeds
            builder.Entity<HelpMessage>().SeedData();
            builder.Entity<Faculty>().HasData(new object[]
            {
                new Faculty(){Id = 1, Name = "Факултет Компютърни системи и технологии"},
                new Faculty(){Id = 2, Name = "Факултет по телекомуникации"},
            });
            builder.Entity<Department>().HasData(new object[]
            {
                new Department(){Id = 1, Name = "Програмиране и компютърни технологии",FacultyId = 1},
                new Department(){Id = 2, Name = "Компютърни системи",FacultyId = 1},

                new Department(){Id = 3, Name = "Радиокомуникации и видеотехнологии",FacultyId = 2},
            });
            builder.Entity<Specialty>().HasData(new object[]
            {
                new Specialty(){Id = 1, Name = "Графичен и web дизайн", DepartmentId = 1, SpecialtyType = SpecialtyType.Bachelor},

                new Specialty(){Id = 2, Name = "Компютърно и софтуерно инженерство", DepartmentId = 2, SpecialtyType = SpecialtyType.Bachelor},
                new Specialty(){Id = 3, Name = "Компютърно и софтуерно инженерство", DepartmentId = 2, SpecialtyType = SpecialtyType.Master},

                new Specialty(){Id = 4, Name = "Телекомуникации", DepartmentId = 3, SpecialtyType = SpecialtyType.Bachelor},
                new Specialty(){Id = 5, Name = "Телекомуникационно инженерство", DepartmentId = 3, SpecialtyType = SpecialtyType.MasterAfterBachelor},
            });
            builder.Entity<Group>().HasData(new object[]
            {
                new Group(){Id = 1, FromYear = 2020, Name= "39", SpecialtyId = 1},
                new Group(){Id = 2, FromYear = 2020, Name= "40", SpecialtyId = 1},
                new Group(){Id = 3, FromYear = 2020, Name= "41", SpecialtyId = 2},
                new Group(){Id = 4, FromYear = 2020, Name= "42", SpecialtyId = 2},
                new Group(){Id = 5, FromYear = 2020, Name= "43", SpecialtyId = 2}
            });
        }
    }
}
