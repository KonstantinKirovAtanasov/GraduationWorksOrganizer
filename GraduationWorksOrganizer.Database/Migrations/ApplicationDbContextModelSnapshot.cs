﻿// <auto-generated />
using System;
using GraduationWorksOrganizer.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GraduationWorksOrganizer.Database.Migrations
{
    [DbContext(typeof(GraduationWorksOrganizerDataContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("GraduationWorksOrganizer.Database.Models.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("FacultyId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("FacultyId");

                    b.ToTable("Deparments");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FacultyId = 1,
                            Name = "Програмиране и компютърни технологии"
                        },
                        new
                        {
                            Id = 2,
                            FacultyId = 1,
                            Name = "Компютърни системи"
                        },
                        new
                        {
                            Id = 3,
                            FacultyId = 2,
                            Name = "Радиокомуникации и видеотехнологии"
                        });
                });

            modelBuilder.Entity("GraduationWorksOrganizer.Database.Models.Faculty", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Faculties");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Факултет Компютърни системи и технологии"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Факултет по телекомуникации"
                        });
                });

            modelBuilder.Entity("GraduationWorksOrganizer.Database.Models.GraduationWorkBlanckRequest", b =>
                {
                    b.Property<int>("GraduationWorkBlanckRequestId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.HasKey("GraduationWorkBlanckRequestId");

                    b.ToTable("GraduationWorkBlanckRequests");
                });

            modelBuilder.Entity("GraduationWorksOrganizer.Database.Models.Group", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("FromYear")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SpecialtyId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SpecialtyId");

                    b.ToTable("Groups");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FromYear = 2020,
                            Name = "39",
                            SpecialtyId = 1
                        },
                        new
                        {
                            Id = 2,
                            FromYear = 2020,
                            Name = "40",
                            SpecialtyId = 1
                        },
                        new
                        {
                            Id = 3,
                            FromYear = 2020,
                            Name = "41",
                            SpecialtyId = 2
                        },
                        new
                        {
                            Id = 4,
                            FromYear = 2020,
                            Name = "42",
                            SpecialtyId = 2
                        },
                        new
                        {
                            Id = 5,
                            FromYear = 2020,
                            Name = "43",
                            SpecialtyId = 2
                        });
                });

            modelBuilder.Entity("GraduationWorksOrganizer.Database.Models.HelpMessage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Key")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("HelpMessages");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Content = "Моля, попълнете имейл за потвърждение на регистрацията",
                            Key = "email",
                            Title = "Имейл"
                        },
                        new
                        {
                            Id = 2,
                            Content = "Моля попълнете вашата парола. (Паролата трябва да съдържа поне 8 символа, главна буква, малка буква както и поне едно число)",
                            Key = "password",
                            Title = "Парола"
                        },
                        new
                        {
                            Id = 3,
                            Content = "Моля, повторете вашата парола.",
                            Key = "confirmpassword",
                            Title = "Потвърдажане на парола"
                        },
                        new
                        {
                            Id = 4,
                            Content = "Изберете факултет от падащото меню.",
                            Key = "faculty",
                            Title = "Факултет"
                        },
                        new
                        {
                            Id = 5,
                            Content = "Изберете катедра от падащото меню.",
                            Key = "department",
                            Title = "Катедра"
                        },
                        new
                        {
                            Id = 6,
                            Content = "Изберете специалност от падащото меню.",
                            Key = "specialty",
                            Title = "Специалност"
                        },
                        new
                        {
                            Id = 7,
                            Content = "Изберете група от падащото меню.",
                            Key = "group",
                            Title = "Група"
                        },
                        new
                        {
                            Id = 8,
                            Content = "Моля, попълнете вашите имена.",
                            Key = "names",
                            Title = "Имена"
                        },
                        new
                        {
                            Id = 9,
                            Content = "Моля, попълнете вашето ЕГН или ЛЧН.",
                            Key = "personalnumber",
                            Title = "ЕГН"
                        },
                        new
                        {
                            Id = 10,
                            Content = "Моля, попълнете вашия факултетен номер.",
                            Key = "facultynumber",
                            Title = "Факултетен Номер"
                        },
                        new
                        {
                            Id = 11,
                            Content = "Моля, попълнете полетата във формата за регистрация на студент и натиснете бутона 'Регистрация'. (за да се регистрирате успешно в системата, трябва да попълните полетата с верни данни, след което да потвърдите вашата регистрация на чрез имейл за потвърждение. Имейлът за потвърждение ще бъде изпратен на посочената от вас поща.).",
                            Key = "defaultregisterstudenthelpmessage",
                            Title = "Регистрация на студент"
                        },
                        new
                        {
                            Id = 12,
                            Content = "Моля, попълнете полетата във формата за регистрация на преподавател и натиснете бутона 'Регистрация'. (за да се регистрирате успешно в системата, трябва да попълните полетата с верни данни, след което да потвърдите вашата регистрация на чрез имейл за потвърждение. Имейлът за потвърждение ще бъде изпратен на посочената от вас поща.).",
                            Key = "defaultregisterteacherhelpmessage",
                            Title = "Регистрация на преподавател"
                        },
                        new
                        {
                            Id = 13,
                            Content = "тест",
                            Key = "cabinet",
                            Title = "Кабинет"
                        },
                        new
                        {
                            Id = 14,
                            Content = "тест",
                            Key = "phonenumber",
                            Title = "Телефонен номер"
                        },
                        new
                        {
                            Id = 15,
                            Content = "тест",
                            Key = "sciencedegree",
                            Title = "Научна степен"
                        });
                });

            modelBuilder.Entity("GraduationWorksOrganizer.Database.Models.Specialty", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SpecialtyType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Specialties");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DepartmentId = 1,
                            Name = "Графичен и web дизайн",
                            SpecialtyType = 0
                        },
                        new
                        {
                            Id = 2,
                            DepartmentId = 2,
                            Name = "Компютърно и софтуерно инженерство",
                            SpecialtyType = 0
                        },
                        new
                        {
                            Id = 3,
                            DepartmentId = 2,
                            Name = "Компютърно и софтуерно инженерство",
                            SpecialtyType = 1
                        },
                        new
                        {
                            Id = 4,
                            DepartmentId = 3,
                            Name = "Телекомуникации",
                            SpecialtyType = 0
                        },
                        new
                        {
                            Id = 5,
                            DepartmentId = 3,
                            Name = "Телекомуникационно инженерство",
                            SpecialtyType = 2
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");

                    b.HasData(
                        new
                        {
                            Id = "f9f64a38-a798-42a8-9d7c-f52da489cfbb",
                            ConcurrencyStamp = "4033e4da-d94b-4c76-afc6-077e529d9eb8",
                            Name = "Teacher"
                        },
                        new
                        {
                            Id = "9fe665ab-dbd4-4dd9-8683-f704729a5f87",
                            ConcurrencyStamp = "a1141fd0-0b36-441f-90c1-944e731e8e1b",
                            Name = "Student"
                        },
                        new
                        {
                            Id = "fa380cf7-756d-446e-82ec-240e53466fd4",
                            ConcurrencyStamp = "970c7f68-8af0-4f88-8f0c-68b00f809b84",
                            Name = "PromotedTeacher"
                        },
                        new
                        {
                            Id = "7550788a-eda8-459f-9964-55d0ecc70301",
                            ConcurrencyStamp = "7a1fd821-9f34-4ae8-b626-c2933ad8595e",
                            Name = "Admin"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityUser");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("GraduationWorksOrganizer.Database.Models.Student", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityUser");

                    b.Property<string>("FacultyNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("GroupId")
                        .HasColumnType("int");

                    b.Property<string>("PersonalNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SpecialtyId")
                        .HasColumnType("int");

                    b.Property<string>("StudentName")
                        .HasColumnType("nvarchar(max)");

                    b.HasIndex("GroupId");

                    b.HasIndex("SpecialtyId");

                    b.HasDiscriminator().HasValue("Student");
                });

            modelBuilder.Entity("GraduationWorksOrganizer.Database.Models.Teacher", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityUser");

                    b.Property<string>("Cabinet")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<string>("ScienceDegree")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TeacherName")
                        .HasColumnType("nvarchar(max)");

                    b.HasIndex("DepartmentId");

                    b.HasDiscriminator().HasValue("Teacher");
                });

            modelBuilder.Entity("GraduationWorksOrganizer.Database.Models.Department", b =>
                {
                    b.HasOne("GraduationWorksOrganizer.Database.Models.Faculty", "Faculty")
                        .WithMany("Departments")
                        .HasForeignKey("FacultyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GraduationWorksOrganizer.Database.Models.Group", b =>
                {
                    b.HasOne("GraduationWorksOrganizer.Database.Models.Specialty", "Specialty")
                        .WithMany()
                        .HasForeignKey("SpecialtyId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("GraduationWorksOrganizer.Database.Models.Specialty", b =>
                {
                    b.HasOne("GraduationWorksOrganizer.Database.Models.Department", "Department")
                        .WithMany("Specialties")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GraduationWorksOrganizer.Database.Models.Student", b =>
                {
                    b.HasOne("GraduationWorksOrganizer.Database.Models.Group", "Group")
                        .WithMany("Students")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("GraduationWorksOrganizer.Database.Models.Specialty", "Specialty")
                        .WithMany()
                        .HasForeignKey("SpecialtyId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("GraduationWorksOrganizer.Database.Models.Teacher", b =>
                {
                    b.HasOne("GraduationWorksOrganizer.Database.Models.Department", "Department")
                        .WithMany()
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
