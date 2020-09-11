using GraduationWorksOrganizer.Database.Models;
using GraduationWorksOrganizer.Database.Models.Base;
using GraduationWorksOrganizer.Database.Seeds;
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

        /// <summary>
        /// таблица с теми
        /// </summary>
        public DbSet<Theses> Theses { get; set; }

        /// <summary>
        /// таблица с теми
        /// </summary>
        public DbSet<Commission> Commissions { get; set; }

        /// <summary>
        /// таблица с теми
        /// </summary>
        public DbSet<CommissionDefencesDates> DefenceDates { get; set; }

        /// <summary>
        /// таблица с теми
        /// </summary>
        public DbSet<ThesisDefenceEvent> DefenceEvents { get; set; }

        /// <summary>
        /// таблица с теми
        /// </summary>
        public DbSet<ThesisMark> Marks { get; set; }

        /// <summary>
        /// таблица с изисквания към теми
        /// </summary>
        public DbSet<ThesisRequerment> ThesisRequerments { get; set; }

        /// <summary>
        /// таблица с изисквания към теми
        /// </summary>
        public DbSet<ThesesUserEntry> ThesesUserEntries { get; set; }

        /// <summary>
        /// таблица с изисквания към теми
        /// </summary>
        public DbSet<Subject> Subjects { get; set; }

        /// <summary>
        /// таблица с файлове към теми
        /// </summary>
        public DbSet<ThesisUserEntryFileContent> UserEntryFileContent { get; set; }
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
            builder.Entity<Teacher>().HasBaseType<ApplicationIdentityBase>();
            builder.Entity<Student>().HasBaseType<ApplicationIdentityBase>();
            builder.Entity<ThesisUserEntryFileContent>().HasBaseType<FileContent>();

            #region PrimaryKeys

            builder.Entity<Faculty>().HasKey(f => f.Id);
            builder.Entity<Department>().HasKey(d => d.Id);
            builder.Entity<Specialty>().HasKey(s => s.Id);
            builder.Entity<Subject>().HasKey(s => s.Id);
            builder.Entity<Group>().HasKey(g => g.Id);
            builder.Entity<HelpMessage>().HasKey(hm => hm.Id);
            builder.Entity<Theses>().HasKey(t => t.Id);
            builder.Entity<Commission>().HasKey(c => c.Id);
            builder.Entity<CommissionDefencesDates>().HasKey(cd => cd.Id);
            builder.Entity<ThesisDefenceEvent>().HasKey(td => td.Id);
            builder.Entity<ThesisMark>().HasKey(tm => tm.Id);
            builder.Entity<ThesisRequerment>().HasKey(tr => tr.Id);
            builder.Entity<ThesesUserEntry>().HasKey(tue => tue.Id);
            builder.Entity<FileContent>().HasKey(fc => fc.Id);
            builder.Entity<MimeType>().HasKey(mt => mt.Id);

            #endregion

            // Relations
            builder.Entity<Faculty>().HasMany(f => f.Departments).WithOne(d => d.Faculty).HasForeignKey(d => d.FacultyId).OnDelete(DeleteBehavior.Cascade);
            builder.Entity<Department>().HasMany(d => d.Specialties).WithOne(s => s.Department).HasForeignKey(s => s.DepartmentId).OnDelete(DeleteBehavior.Cascade);

            builder.Entity<ApplicationIdentityBase>().HasOne(u => u.Image).WithOne().HasForeignKey<ApplicationIdentityBase>(u => u.ImageId).OnDelete(DeleteBehavior.NoAction);

            builder.Entity<Teacher>().HasOne(t => t.Department).WithMany().HasForeignKey(t => t.DepartmentId).OnDelete(DeleteBehavior.NoAction);
            builder.Entity<Student>().HasOne(s => s.Specialty).WithMany().HasForeignKey(s => s.SpecialtyId).OnDelete(DeleteBehavior.NoAction);
            builder.Entity<Student>().HasOne(s => s.Group).WithMany(g => g.Students).HasForeignKey(s => s.GroupId).OnDelete(DeleteBehavior.NoAction);
            builder.Entity<Student>().HasMany(s => s.ThesisEntries).WithOne(tue => tue.Student).HasForeignKey(tue => tue.StudentId).OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Theses>().HasOne(t => t.Creator).WithMany().HasForeignKey(t => t.CreatorId).OnDelete(DeleteBehavior.NoAction);
            builder.Entity<Theses>().HasOne(t => t.Subject).WithMany().HasForeignKey(t => t.SubjectId).OnDelete(DeleteBehavior.NoAction);
            builder.Entity<Theses>().HasMany(t => t.Requerments).WithOne(r => r.Theses).HasForeignKey(t => t.ThesesId).OnDelete(DeleteBehavior.Cascade);
            builder.Entity<Theses>().HasMany(t => t.UserEntries).WithOne(tue => tue.Theses).HasForeignKey(tue => tue.ThesesId).OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Group>().HasOne(g => g.Specialty).WithMany().HasForeignKey(g => g.SpecialtyId).OnDelete(DeleteBehavior.NoAction);
            builder.Entity<Subject>().HasOne(d => d.Specialty).WithMany().HasForeignKey(s => s.SpecialtyId).OnDelete(DeleteBehavior.NoAction);

            builder.Entity<Commission>().HasOne(c => c.Department).WithMany().HasForeignKey(c => c.DepartmentId).OnDelete(DeleteBehavior.NoAction);
            builder.Entity<Commission>().HasOne(c => c.MainCommissionTeacher).WithMany().HasForeignKey(c => c.MainCommissionTeacherId).OnDelete(DeleteBehavior.NoAction);
            builder.Entity<Commission>().HasMany(c => c.CommissionTeachers).WithOne().OnDelete(DeleteBehavior.NoAction);
            builder.Entity<Commission>().HasMany(c => c.CommissionDefencesDates).WithOne().OnDelete(DeleteBehavior.NoAction);

            builder.Entity<CommissionDefencesDates>().HasMany(cd => cd.Defences).WithOne(td => td.DefencesDate).OnDelete(DeleteBehavior.Cascade);

            builder.Entity<ThesisDefenceEvent>().HasOne(td => td.DefencesDate).WithMany(cd => cd.Defences).HasForeignKey(td => td.DefenceDateId).OnDelete(DeleteBehavior.NoAction);
            builder.Entity<ThesisDefenceEvent>().HasOne(td => td.Student).WithMany().HasForeignKey(td => td.StudentId).OnDelete(DeleteBehavior.NoAction);
            builder.Entity<ThesisDefenceEvent>().HasOne(td => td.Thesis).WithOne().HasForeignKey<ThesisDefenceEvent>(td => td.ThesisId).OnDelete(DeleteBehavior.NoAction);
            builder.Entity<ThesisDefenceEvent>().HasOne(td => td.ThesisMark).WithOne().HasForeignKey<ThesisDefenceEvent>(td => td.ThesisMarkId).OnDelete(DeleteBehavior.NoAction);

            builder.Entity<ThesisUserEntryFileContent>().HasOne(tfc => tfc.UserEntry).WithMany().HasForeignKey(tfc => tfc.UserEntryId).OnDelete(DeleteBehavior.Cascade);

            #region Seeds

            builder.Entity<MimeType>().SeedData();
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
            builder.Entity<Subject>().HasData(new object[]
            {
                new Subject(){Id=1, SpecialtyId = 1,Name="Шрифт и типография ІI част"},
                new Subject(){Id=2, SpecialtyId = 1,Name="WEB  дизайн І (Техники на програмиране)"},
                new Subject(){Id=3, SpecialtyId = 1,Name="Корпоративен дизайн І част"},
                new Subject(){Id=4, SpecialtyId = 1,Name="Оформление на страница"},

                new Subject(){Id=5, SpecialtyId = 2,Name="Обектно-ориентирано програмиране"},
                new Subject(){Id=6, SpecialtyId = 2,Name="Web програмиране"},
                new Subject(){Id=7, SpecialtyId = 2,Name="Програмиране за мобилни устройства"},
                new Subject(){Id=8, SpecialtyId = 2,Name="Функционално програмиране"},

                new Subject(){Id=9, SpecialtyId = 3,Name="Проектиране и реализация на големи софтуерни проекти"},
                new Subject(){Id=10, SpecialtyId = 3,Name="Kомпютърна и мрежова сигурност"},
                new Subject(){Id=11, SpecialtyId = 3,Name="Управление и документиране на софтуерни проекти"},
                new Subject(){Id=12, SpecialtyId = 3,Name="Бази от данни"},

                new Subject(){Id=13, SpecialtyId = 4,Name="Операционни системи"},
                new Subject(){Id=14, SpecialtyId = 4,Name="Електроника"},
                new Subject(){Id=15, SpecialtyId = 4,Name="Инженерна математика 1"},
                new Subject(){Id=16, SpecialtyId = 4,Name="Основи на сигурността"},

                new Subject(){Id=17, SpecialtyId = 5,Name="Компютърни архитектури"},
                new Subject(){Id=18, SpecialtyId = 5,Name="Материали и електронни компоненти"},
                new Subject(){Id=19, SpecialtyId = 5,Name="Основи на сигурността"},
            });

            #endregion // Seeds
        }
    }
}
