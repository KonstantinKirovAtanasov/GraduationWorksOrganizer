using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GraduationWorksOrganizer.Database.Migrations
{
    public partial class SecondInitial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Faculties",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faculties", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HelpMessages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Key = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    Content = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HelpMessages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Marks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Mark = table.Column<double>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Marks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Deparments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    FacultyId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deparments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Deparments_Faculties_FacultyId",
                        column: x => x.FacultyId,
                        principalTable: "Faculties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Specialties",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    SpecialtyType = table.Column<int>(nullable: false),
                    DepartmentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specialties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Specialties_Deparments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Deparments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SpecialtyId = table.Column<int>(nullable: false),
                    FromYear = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Groups_Specialties_SpecialtyId",
                        column: x => x.SpecialtyId,
                        principalTable: "Specialties",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Subjects",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SpecialtyId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subjects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Subjects_Specialties_SpecialtyId",
                        column: x => x.SpecialtyId,
                        principalTable: "Specialties",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                });

            migrationBuilder.CreateTable(
                name: "Commissions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentId = table.Column<int>(nullable: false),
                    MainCommissionTeacherId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Commissions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Commissions_Deparments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Deparments",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Image = table.Column<byte[]>(nullable: true),
                    SpecialtyId = table.Column<int>(nullable: true),
                    GroupId = table.Column<int>(nullable: true),
                    PersonalNumber = table.Column<string>(nullable: true),
                    FacultyNumber = table.Column<string>(nullable: true),
                    DepartmentId = table.Column<int>(nullable: true),
                    Cabinet = table.Column<string>(nullable: true),
                    ScienceDegree = table.Column<string>(nullable: true),
                    CommissionId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Specialties_SpecialtyId",
                        column: x => x.SpecialtyId,
                        principalTable: "Specialties",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Commissions_CommissionId",
                        column: x => x.CommissionId,
                        principalTable: "Commissions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Deparments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Deparments",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DefenceDates",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HallNumber = table.Column<string>(nullable: true),
                    StartingDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    MaxThesisCount = table.Column<int>(nullable: false),
                    CommissionId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DefenceDates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DefenceDates_Commissions_CommissionId",
                        column: x => x.CommissionId,
                        principalTable: "Commissions",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Theses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    CreatorId = table.Column<string>(nullable: true),
                    SubjectId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Theses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Theses_AspNetUsers_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Theses_Subjects_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subjects",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DefenceEvents",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DefenceDateId = table.Column<int>(nullable: false),
                    StudentId = table.Column<string>(nullable: true),
                    ThesisId = table.Column<int>(nullable: false),
                    ThesisMarkId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DefenceEvents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DefenceEvents_DefenceDates_DefenceDateId",
                        column: x => x.DefenceDateId,
                        principalTable: "DefenceDates",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DefenceEvents_AspNetUsers_StudentId",
                        column: x => x.StudentId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DefenceEvents_Theses_ThesisId",
                        column: x => x.ThesisId,
                        principalTable: "Theses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DefenceEvents_Marks_ThesisMarkId",
                        column: x => x.ThesisMarkId,
                        principalTable: "Marks",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ThesesUserEntries",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ThesesId = table.Column<int>(nullable: false),
                    StudentId = table.Column<string>(nullable: true),
                    State = table.Column<int>(nullable: false),
                    ThemeObserverId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThesesUserEntries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ThesesUserEntries_AspNetUsers_StudentId",
                        column: x => x.StudentId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ThesesUserEntries_AspNetUsers_ThemeObserverId",
                        column: x => x.ThemeObserverId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ThesesUserEntries_Theses_ThesesId",
                        column: x => x.ThesesId,
                        principalTable: "Theses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ThesisRequerments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(nullable: true),
                    ThesesId = table.Column<int>(nullable: false),
                    MaxPointsCount = table.Column<decimal>(nullable: false),
                    MarkPoints = table.Column<decimal>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThesisRequerments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ThesisRequerments_Theses_ThesesId",
                        column: x => x.ThesesId,
                        principalTable: "Theses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Faculties",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Факултет Компютърни системи и технологии" },
                    { 2, "Факултет по телекомуникации" }
                });

            migrationBuilder.InsertData(
                table: "HelpMessages",
                columns: new[] { "Id", "Content", "Key", "Title" },
                values: new object[,]
                {
                    { 13, "тест", "cabinet", "Кабинет" },
                    { 12, "Моля, попълнете полетата във формата за регистрация на преподавател и натиснете бутона 'Регистрация'. (за да се регистрирате успешно в системата, трябва да попълните полетата с верни данни, след което да потвърдите вашата регистрация на чрез имейл за потвърждение. Имейлът за потвърждение ще бъде изпратен на посочената от вас поща.).", "defaultregisterteacherhelpmessage", "Регистрация на преподавател" },
                    { 11, "Моля, попълнете полетата във формата за регистрация на студент и натиснете бутона 'Регистрация'. (за да се регистрирате успешно в системата, трябва да попълните полетата с верни данни, след което да потвърдите вашата регистрация на чрез имейл за потвърждение. Имейлът за потвърждение ще бъде изпратен на посочената от вас поща.).", "defaultregisterstudenthelpmessage", "Регистрация на студент" },
                    { 10, "Моля, попълнете вашия факултетен номер.", "facultynumber", "Факултетен Номер" },
                    { 9, "Моля, попълнете вашето ЕГН или ЛЧН.", "personalnumber", "ЕГН" },
                    { 8, "Моля, попълнете вашите имена.", "names", "Имена" },
                    { 7, "Изберете група от падащото меню.", "group", "Група" },
                    { 6, "Изберете специалност от падащото меню.", "specialty", "Специалност" },
                    { 5, "Изберете катедра от падащото меню.", "department", "Катедра" },
                    { 4, "Изберете факултет от падащото меню.", "faculty", "Факултет" },
                    { 3, "Моля, повторете вашата парола.", "confirmpassword", "Потвърдажане на парола" },
                    { 2, "Моля попълнете вашата парола. (Паролата трябва да съдържа поне 8 символа, главна буква, малка буква както и поне едно число)", "password", "Парола" },
                    { 1, "Моля, попълнете имейл за потвърждение на регистрацията", "email", "Имейл" },
                    { 14, "тест", "phonenumber", "Телефонен номер" },
                    { 15, "тест", "sciencedegree", "Научна степен" }
                });

            migrationBuilder.InsertData(
                table: "Deparments",
                columns: new[] { "Id", "FacultyId", "Name" },
                values: new object[] { 1, 1, "Програмиране и компютърни технологии" });

            migrationBuilder.InsertData(
                table: "Deparments",
                columns: new[] { "Id", "FacultyId", "Name" },
                values: new object[] { 2, 1, "Компютърни системи" });

            migrationBuilder.InsertData(
                table: "Deparments",
                columns: new[] { "Id", "FacultyId", "Name" },
                values: new object[] { 3, 2, "Радиокомуникации и видеотехнологии" });

            migrationBuilder.InsertData(
                table: "Specialties",
                columns: new[] { "Id", "DepartmentId", "Name", "SpecialtyType" },
                values: new object[,]
                {
                    { 1, 1, "Графичен и web дизайн", 0 },
                    { 2, 2, "Компютърно и софтуерно инженерство", 0 },
                    { 3, 2, "Компютърно и софтуерно инженерство", 1 },
                    { 4, 3, "Телекомуникации", 0 },
                    { 5, 3, "Телекомуникационно инженерство", 2 }
                });

            migrationBuilder.InsertData(
                table: "Groups",
                columns: new[] { "Id", "FromYear", "Name", "SpecialtyId" },
                values: new object[,]
                {
                    { 1, 2020, "39", 1 },
                    { 2, 2020, "40", 1 },
                    { 3, 2020, "41", 2 },
                    { 4, 2020, "42", 2 },
                    { 5, 2020, "43", 2 }
                });

            migrationBuilder.InsertData(
                table: "Subjects",
                columns: new[] { "Id", "Name", "SpecialtyId" },
                values: new object[,]
                {
                    { 17, "Компютърни архитектури", 5 },
                    { 16, "Основи на сигурността", 4 },
                    { 15, "Инженерна математика 1", 4 },
                    { 14, "Електроника", 4 },
                    { 13, "Операционни системи", 4 },
                    { 12, "Бази от данни", 3 },
                    { 11, "Управление и документиране на софтуерни проекти", 3 },
                    { 10, "Kомпютърна и мрежова сигурност", 3 },
                    { 7, "Програмиране за мобилни устройства", 2 },
                    { 8, "Функционално програмиране", 2 },
                    { 18, "Материали и електронни компоненти", 5 },
                    { 6, "Web програмиране", 2 },
                    { 5, "Обектно-ориентирано програмиране", 2 },
                    { 4, "Оформление на страница", 1 },
                    { 3, "Корпоративен дизайн І част", 1 },
                    { 2, "WEB  дизайн І (Техники на програмиране)", 1 },
                    { 1, "Шрифт и типография ІI част", 1 },
                    { 9, "Проектиране и реализация на големи софтуерни проекти", 3 },
                    { 19, "Основи на сигурността", 5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_GroupId",
                table: "AspNetUsers",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_SpecialtyId",
                table: "AspNetUsers",
                column: "SpecialtyId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_CommissionId",
                table: "AspNetUsers",
                column: "CommissionId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_DepartmentId",
                table: "AspNetUsers",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Commissions_DepartmentId",
                table: "Commissions",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Commissions_MainCommissionTeacherId",
                table: "Commissions",
                column: "MainCommissionTeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_DefenceDates_CommissionId",
                table: "DefenceDates",
                column: "CommissionId");

            migrationBuilder.CreateIndex(
                name: "IX_DefenceEvents_DefenceDateId",
                table: "DefenceEvents",
                column: "DefenceDateId");

            migrationBuilder.CreateIndex(
                name: "IX_DefenceEvents_StudentId",
                table: "DefenceEvents",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_DefenceEvents_ThesisId",
                table: "DefenceEvents",
                column: "ThesisId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DefenceEvents_ThesisMarkId",
                table: "DefenceEvents",
                column: "ThesisMarkId",
                unique: true,
                filter: "[ThesisMarkId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Deparments_FacultyId",
                table: "Deparments",
                column: "FacultyId");

            migrationBuilder.CreateIndex(
                name: "IX_Groups_SpecialtyId",
                table: "Groups",
                column: "SpecialtyId");

            migrationBuilder.CreateIndex(
                name: "IX_Specialties_DepartmentId",
                table: "Specialties",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_SpecialtyId",
                table: "Subjects",
                column: "SpecialtyId");

            migrationBuilder.CreateIndex(
                name: "IX_Theses_CreatorId",
                table: "Theses",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Theses_SubjectId",
                table: "Theses",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ThesesUserEntries_StudentId",
                table: "ThesesUserEntries",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_ThesesUserEntries_ThemeObserverId",
                table: "ThesesUserEntries",
                column: "ThemeObserverId");

            migrationBuilder.CreateIndex(
                name: "IX_ThesesUserEntries_ThesesId",
                table: "ThesesUserEntries",
                column: "ThesesId");

            migrationBuilder.CreateIndex(
                name: "IX_ThesisRequerments_ThesesId",
                table: "ThesisRequerments",
                column: "ThesesId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Commissions_AspNetUsers_MainCommissionTeacherId",
                table: "Commissions",
                column: "MainCommissionTeacherId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Commissions_AspNetUsers_MainCommissionTeacherId",
                table: "Commissions");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "DefenceEvents");

            migrationBuilder.DropTable(
                name: "HelpMessages");

            migrationBuilder.DropTable(
                name: "ThesesUserEntries");

            migrationBuilder.DropTable(
                name: "ThesisRequerments");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "DefenceDates");

            migrationBuilder.DropTable(
                name: "Marks");

            migrationBuilder.DropTable(
                name: "Theses");

            migrationBuilder.DropTable(
                name: "Subjects");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Groups");

            migrationBuilder.DropTable(
                name: "Commissions");

            migrationBuilder.DropTable(
                name: "Specialties");

            migrationBuilder.DropTable(
                name: "Deparments");

            migrationBuilder.DropTable(
                name: "Faculties");
        }
    }
}
