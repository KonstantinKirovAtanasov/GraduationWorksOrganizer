﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GraduationWorksOrganizer.Database.Migrations
{
    public partial class Initial : Migration
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
                name: "MimeType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    MIMEType = table.Column<string>(nullable: true),
                    FileExtention = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MimeType", x => x.Id);
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
                        name: "FK_Theses_Subjects_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subjects",
                        principalColumn: "Id");
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

            migrationBuilder.CreateTable(
                name: "ThesesUserEntries",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ThesesId = table.Column<int>(nullable: false),
                    StudentId = table.Column<string>(nullable: true),
                    State = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThesesUserEntries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ThesesUserEntries_Theses_ThesesId",
                        column: x => x.ThesesId,
                        principalTable: "Theses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DefenceEvents",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DefenceDateId = table.Column<int>(nullable: false),
                    ThesesUserEntryId = table.Column<int>(nullable: false),
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
                        name: "FK_DefenceEvents_ThesesUserEntries_ThesesUserEntryId",
                        column: x => x.ThesesUserEntryId,
                        principalTable: "ThesesUserEntries",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DefenceEvents_Marks_ThesisMarkId",
                        column: x => x.ThesisMarkId,
                        principalTable: "Marks",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "FileContent",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<byte[]>(nullable: true),
                    Discriminator = table.Column<string>(nullable: false),
                    FileName = table.Column<string>(nullable: true),
                    UserEntryId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileContent", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FileContent_ThesesUserEntries_UserEntryId",
                        column: x => x.UserEntryId,
                        principalTable: "ThesesUserEntries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    ImageId = table.Column<int>(nullable: true),
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
                        name: "FK_AspNetUsers_FileContent_ImageId",
                        column: x => x.ImageId,
                        principalTable: "FileContent",
                        principalColumn: "Id");
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
                name: "ThesisApprovementRequest",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ThesesUserEntryId = table.Column<int>(nullable: false),
                    ThemeObserverId = table.Column<string>(nullable: true),
                    RequestDescription = table.Column<string>(nullable: true),
                    ResponseDescription = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThesisApprovementRequest", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ThesisApprovementRequest_AspNetUsers_ThemeObserverId",
                        column: x => x.ThemeObserverId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ThesisApprovementRequest_ThesesUserEntries_ThesesUserEntryId",
                        column: x => x.ThesesUserEntryId,
                        principalTable: "ThesesUserEntries",
                        principalColumn: "Id");
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
                    { 15, "тест", "sciencedegree", "Научна степен" },
                    { 14, "тест", "phonenumber", "Телефонен номер" },
                    { 13, "тест", "cabinet", "Кабинет" },
                    { 12, "Моля, попълнете полетата във формата за регистрация на преподавател и натиснете бутона 'Регистрация'. (за да се регистрирате успешно в системата, трябва да попълните полетата с верни данни, след което да потвърдите вашата регистрация на чрез имейл за потвърждение. Имейлът за потвърждение ще бъде изпратен на посочената от вас поща.).", "defaultregisterteacherhelpmessage", "Регистрация на преподавател" },
                    { 10, "Моля, попълнете вашия факултетен номер.", "facultynumber", "Факултетен Номер" },
                    { 9, "Моля, попълнете вашето ЕГН или ЛЧН.", "personalnumber", "ЕГН" },
                    { 8, "Моля, попълнете вашите имена.", "names", "Имена" },
                    { 11, "Моля, попълнете полетата във формата за регистрация на студент и натиснете бутона 'Регистрация'. (за да се регистрирате успешно в системата, трябва да попълните полетата с верни данни, след което да потвърдите вашата регистрация на чрез имейл за потвърждение. Имейлът за потвърждение ще бъде изпратен на посочената от вас поща.).", "defaultregisterstudenthelpmessage", "Регистрация на студент" },
                    { 6, "Изберете специалност от падащото меню.", "specialty", "Специалност" },
                    { 5, "Изберете катедра от падащото меню.", "department", "Катедра" },
                    { 4, "Изберете факултет от падащото меню.", "faculty", "Факултет" },
                    { 3, "Моля, повторете вашата парола.", "confirmpassword", "Потвърдажане на парола" },
                    { 2, "Моля попълнете вашата парола. (Паролата трябва да съдържа поне 8 символа, главна буква, малка буква както и поне едно число)", "password", "Парола" },
                    { 1, "Моля, попълнете имейл за потвърждение на регистрацията", "email", "Имейл" },
                    { 7, "Изберете група от падащото меню.", "group", "Група" }
                });

            migrationBuilder.InsertData(
                table: "MimeType",
                columns: new[] { "Id", "FileExtention", "MIMEType", "Name" },
                values: new object[,]
                {
                    { 463, ".odm", "application/vnd.oasis.opendocument.text-master", "OpenDocument Text Master" },
                    { 457, ".oti", "application/vnd.oasis.opendocument.image-template", "OpenDocument Image Template" },
                    { 458, ".odp", "application/vnd.oasis.opendocument.presentation", "OpenDocument Presentation" },
                    { 459, ".otp", "application/vnd.oasis.opendocument.presentation-template", "OpenDocument Presentation Template" },
                    { 460, ".ods", "application/vnd.oasis.opendocument.spreadsheet", "OpenDocument Spreadsheet" },
                    { 461, ".ots", "application/vnd.oasis.opendocument.spreadsheet-template", "OpenDocument Spreadsheet Template" },
                    { 462, ".odt", "application/vnd.oasis.opendocument.text", "OpenDocument Text" },
                    { 464, ".ott", "application/vnd.oasis.opendocument.text-template", "OpenDocument Text Template" },
                    { 473, ".sxw", "application/vnd.sun.xml.writer", "OpenOffice - Writer (Text - HTML)" },
                    { 466, ".sxc", "application/vnd.sun.xml.calc", "OpenOffice - Calc (Spreadsheet)" },
                    { 467, ".stc", "application/vnd.sun.xml.calc.template", "OpenOffice - Calc Template (Spreadsheet)" },
                    { 468, ".sxd", "application/vnd.sun.xml.draw", "OpenOffice - Draw (Graphics)" },
                    { 469, ".std", "application/vnd.sun.xml.draw.template", "OpenOffice - Draw Template (Graphics)" },
                    { 470, ".sxi", "application/vnd.sun.xml.impress", "OpenOffice - Impress (Presentation)" },
                    { 471, ".sti", "application/vnd.sun.xml.impress.template", "OpenOffice - Impress Template (Presentation)" },
                    { 472, ".sxm", "application/vnd.sun.xml.math", "OpenOffice - Math (Formula)" },
                    { 456, ".odi", "application/vnd.oasis.opendocument.image", "OpenDocument Image" },
                    { 465, ".ktx", "image/ktx", "OpenGL Textures (KTX)" },
                    { 455, ".otg", "application/vnd.oasis.opendocument.graphics-template", "OpenDocument Graphics Template" },
                    { 446, ".osf", "application/vnd.yamaha.openscoreformat", "Open Score Format" },
                    { 453, ".odft", "application/vnd.oasis.opendocument.formula-template", "OpenDocument Formula Template" },
                    { 435, ".ecelp7470", "audio/vnd.nuera.ecelp7470", "Nuera ECELP 7470" },
                    { 436, ".ecelp9600", "audio/vnd.nuera.ecelp9600", "Nuera ECELP 9600" },
                    { 437, ".oda", "application/oda", "Office Document Architecture" },
                    { 438, ".ogx", "application/ogg", "Ogg" },
                    { 439, ".oga", "audio/ogg", "Ogg Audio" },
                    { 440, ".ogv", "video/ogg", "Ogg Video" },
                    { 441, ".dd2", "application/vnd.oma.dd2+xml", "OMA Download Agents" },
                    { 442, ".oth", "application/vnd.oasis.opendocument.text-web", "Open Document Text Web" },
                    { 454, ".odg", "application/vnd.oasis.opendocument.graphics", "OpenDocument Graphics" },
                    { 443, ".opf", "application/oebps-package+xml", "Open eBook Publication Structure" },
                    { 445, ".oxt", "application/vnd.openofficeorg.extension", "Open Office Extension" },
                    { 474, ".sxg", "application/vnd.sun.xml.writer.global", "OpenOffice - Writer (Text - HTML)" },
                    { 447, ".weba", "audio/webm", "Open Web Media Project - Audio" },
                    { 448, ".webm", "video/webm", "Open Web Media Project - Video" },
                    { 449, ".odc", "application/vnd.oasis.opendocument.chart", "OpenDocument Chart" },
                    { 450, ".otc", "application/vnd.oasis.opendocument.chart-template", "OpenDocument Chart Template" },
                    { 451, ".odb", "application/vnd.oasis.opendocument.database", "OpenDocument Database" },
                    { 452, ".odf", "application/vnd.oasis.opendocument.formula", "OpenDocument Formula" },
                    { 444, ".qbo", "application/vnd.intu.qbo", "Open Financial Exchange" },
                    { 475, ".stw", "application/vnd.sun.xml.writer.template", "OpenOffice - Writer Template (Text - HTML)" },
                    { 483, ".efif", "application/vnd.picsel", "Pcsel eFIF File" },
                    { 477, ".osfpvg", "application/vnd.yamaha.openscoreformat.osfpvg+xml", "OSFPVG" },
                    { 500, ".pfr", "application/font-tdpfr", "Portable Font Resource" },
                    { 501, ".pgn", "application/x-chess-pgn", "Portable Game Notation (Chess Games)" },
                    { 502, ".pgm", "image/x-portable-graymap", "Portable Graymap Format" },
                    { 503, ".png", "image/png", "Portable Network Graphics (PNG)" },
                    { 504, ".png", "image/x-citrix-png", "Portable Network Graphics (PNG) (Citrix client)" },
                    { 505, ".png", "image/x-png", "Portable Network Graphics (PNG) (x-token)" },
                    { 506, ".ppm", "image/x-portable-pixmap", "Portable Pixmap Format" },
                    { 507, ".pskcxml", "application/pskc+xml", "Portable Symmetric Key Container" },
                    { 508, ".pml", "application/vnd.ctc-posml", "PosML" },
                    { 509, ".ai", "application/postscript", "PostScript" },
                    { 510, ".pfa", "application/x-font-type1", "PostScript Fonts" },
                    { 511, ".pbd", "application/vnd.powerbuilder6", "PowerBuilder" },
                    { 512, ".pgp", "application/pgp-encrypted", "Pretty Good Privacy" },
                    { 513, ".pgp", "application/pgp-signature", "Pretty Good Privacy - Signature" },
                    { 514, ".box", "application/vnd.previewsystems.box", "Preview Systems ZipLock/VBox" },
                    { 515, ".ptid", "application/vnd.pvi.ptid1", "Princeton Video Image" },
                    { 516, ".pls", "application/pls+xml", "Pronunciation Lexicon Specification" },
                    { 499, ".pcf", "application/x-font-pcf", "Portable Compiled Format" },
                    { 498, ".pbm", "image/x-portable-bitmap", "Portable Bitmap Format" },
                    { 497, ".pnm", "image/x-portable-anymap", "Portable Anymap Image" },
                    { 496, ".plf", "application/vnd.pocketlearn", "PocketLearn Viewers" },
                    { 478, ".dp", "application/vnd.osgi.dp", "OSGi Deployment Package" },
                    { 479, ".pdb", "application/vnd.palm", "PalmOS Data" },
                    { 480, ".p", "text/x-pascal", "Pascal Source File" },
                    { 481, ".paw", "application/vnd.pawaafile", "PawaaFILE" },
                    { 482, ".pclxl", "application/vnd.hp-pclxl", "PCL 6 Enhanced (Formely PCL XL)" },
                    { 434, ".ecelp4800", "audio/vnd.nuera.ecelp4800", "Nuera ECELP 4800" },
                    { 484, ".pcx", "image/x-pcx", "PCX Image" },
                    { 485, ".psd", "image/vnd.adobe.photoshop", "Photoshop Document" },
                    { 476, ".otf", "application/x-font-otf", "OpenType Font File" },
                    { 486, ".prf", "application/pics-rules", "PICSRules" },
                    { 488, ".chat", "application/x-chat", "pIRCh" },
                    { 489, ".p10", "application/pkcs10", "PKCS #10 - Certification Request Standard" },
                    { 490, ".p12", "application/x-pkcs12", "PKCS #12 - Personal Information Exchange Syntax Standard" },
                    { 491, ".p7m", "application/pkcs7-mime", "PKCS #7 - Cryptographic Message Syntax Standard" },
                    { 492, ".p7s", "application/pkcs7-signature", "PKCS #7 - Cryptographic Message Syntax Standard" },
                    { 493, ".p7r", "application/x-pkcs7-certreqresp", "PKCS #7 - Cryptographic Message Syntax Standard (Certificate Request Response)" },
                    { 494, ".p7b", "application/x-pkcs7-certificates", "PKCS #7 - Cryptographic Message Syntax Standard (Certificates)" },
                    { 495, ".p8", "application/pkcs8", "PKCS #8 - Private-Key Information Syntax Standard" },
                    { 487, ".pic", "image/x-pict", "PICT Image" },
                    { 433, ".gph", "application/vnd.flographit", "NpGraphIt" },
                    { 424, ".nnd", "application/vnd.noblenet-directory", "NobleNet Directory" },
                    { 431, ".edx", "application/vnd.novadigm.edx", "Novadigm's RADIA and EDM products" },
                    { 370, ".vsd", "application/vnd.visio", "Microsoft Visio" },
                    { 371, ".vsdx", "application/vnd.visio2013", "Microsoft Visio 2013" },
                    { 372, ".wm", "video/x-ms-wm", "Microsoft Windows Media" },
                    { 373, ".wma", "audio/x-ms-wma", "Microsoft Windows Media Audio" },
                    { 374, ".wax", "audio/x-ms-wax", "Microsoft Windows Media Audio Redirector" },
                    { 375, ".wmx", "video/x-ms-wmx", "Microsoft Windows Media Audio/Video Playlist" },
                    { 376, ".wmd", "application/x-ms-wmd", "Microsoft Windows Media Player Download Package" },
                    { 377, ".wpl", "application/vnd.ms-wpl", "Microsoft Windows Media Player Playlist" },
                    { 378, ".wmz", "application/x-ms-wmz", "Microsoft Windows Media Player Skin Package" },
                    { 379, ".wmv", "video/x-ms-wmv", "Microsoft Windows Media Video" },
                    { 380, ".wvx", "video/x-ms-wvx", "Microsoft Windows Media Video Playlist" },
                    { 381, ".wmf", "application/x-msmetafile", "Microsoft Windows Metafile" },
                    { 382, ".trm", "application/x-msterminal", "Microsoft Windows Terminal Services" },
                    { 383, ".doc", "application/msword", "Microsoft Word" },
                    { 384, ".docm", "application/vnd.ms-word.document.macroenabled.12", "Microsoft Word - Macro-Enabled Document" },
                    { 385, ".dotm", "application/vnd.ms-word.template.macroenabled.12", "Microsoft Word - Macro-Enabled Template" },
                    { 386, ".wri", "application/x-mswrite", "Microsoft Wordpad" },
                    { 369, ".cat", "application/vnd.ms-pki.seccat", "Microsoft Trust UI Provider - Security Catalog" },
                    { 368, ".stl", "application/vnd.ms-pki.stl", "Microsoft Trust UI Provider - Certificate Trust Link" },
                    { 367, ".xap", "application/x-silverlight-app", "Microsoft Silverlight" },
                    { 366, ".scd", "application/x-msschedule", "Microsoft Schedule+" },
                    { 348, ".potx", "application/vnd.openxmlformats-officedocument.presentationml.template", "Microsoft Office - OOXML - Presentation Template" },
                    { 349, ".xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Microsoft Office - OOXML - Spreadsheet" },
                    { 350, ".xltx", "application/vnd.openxmlformats-officedocument.spreadsheetml.template", "Microsoft Office - OOXML - Spreadsheet Template" },
                    { 351, ".docx", "application/vnd.openxmlformats-officedocument.wordprocessingml.document", "Microsoft Office - OOXML - Word Document" },
                    { 352, ".dotx", "application/vnd.openxmlformats-officedocument.wordprocessingml.template", "Microsoft Office - OOXML - Word Document Template" },
                    { 353, ".obd", "application/x-msbinder", "Microsoft Office Binder" },
                    { 354, ".thmx", "application/vnd.ms-officetheme", "Microsoft Office System Release Theme" },
                    { 355, ".onetoc", "application/onenote", "Microsoft OneNote" },
                    { 387, ".wps", "application/vnd.ms-works", "Microsoft Works" },
                    { 356, ".pya", "audio/vnd.ms-playready.media.pya", "Microsoft PlayReady Ecosystem" },
                    { 358, ".ppt", "application/vnd.ms-powerpoint", "Microsoft PowerPoint" },
                    { 359, ".ppam", "application/vnd.ms-powerpoint.addin.macroenabled.12", "Microsoft PowerPoint - Add-in file" },
                    { 360, ".sldm", "application/vnd.ms-powerpoint.slide.macroenabled.12", "Microsoft PowerPoint - Macro-Enabled Open XML Slide" },
                    { 361, ".pptm", "application/vnd.ms-powerpoint.presentation.macroenabled.12", "Microsoft PowerPoint - Macro-Enabled Presentation File" },
                    { 362, ".ppsm", "application/vnd.ms-powerpoint.slideshow.macroenabled.12", "Microsoft PowerPoint - Macro-Enabled Slide Show File" },
                    { 363, ".potm", "application/vnd.ms-powerpoint.template.macroenabled.12", "Microsoft PowerPoint - Macro-Enabled Template File" },
                    { 364, ".mpp", "application/vnd.ms-project", "Microsoft Project" },
                    { 365, ".pub", "application/x-mspublisher", "Microsoft Publisher" },
                    { 357, ".pyv", "video/vnd.ms-playready.media.pyv", "Microsoft PlayReady Ecosystem Video" },
                    { 388, ".xbap", "application/x-ms-xbap", "Microsoft XAML Browser Application" },
                    { 389, ".xps", "application/vnd.ms-xpsdocument", "Microsoft XML Paper Specification" },
                    { 390, ".mid", "audio/midi", "MIDI - Musical Instrument Digital Interface" },
                    { 413, ".mp4", "application/mp4", "MPEG4" },
                    { 414, ".m3u8", "application/vnd.apple.mpegurl", "Multimedia Playlist Unicode" },
                    { 415, ".mus", "application/vnd.musician", "MUsical Score Interpreted Code Invented for the ASCII designation of Notation" },
                    { 416, ".msty", "application/vnd.muvee.style", "Muvee Automatic Video Editing" },
                    { 417, ".mxml", "application/xv+xml", "MXML" },
                    { 418, ".ngdat", "application/vnd.nokia.n-gage.data", "N-Gage Game Data" },
                    { 419, ".n-gage", "application/vnd.nokia.n-gage.symbian.install", "N-Gage Game Installer" },
                    { 420, ".ncx", "application/x-dtbncx+xml", "Navigation Control file for XML (for ePub)" },
                    { 412, ".mp4", "video/mp4", "MPEG-4 Video" },
                    { 421, ".nc", "application/x-netcdf", "Network Common Data Form (NetCDF)" },
                    { 423, ".dna", "application/vnd.dna", "New Moon Liftoff/DNA" },
                    { 517, ".str", "application/vnd.pg.format", "Proprietary P&G Standard Reporting System" },
                    { 425, ".nns", "application/vnd.noblenet-sealer", "NobleNet Sealer" },
                    { 426, ".nnw", "application/vnd.noblenet-web", "NobleNet Web" },
                    { 427, ".rpst", "application/vnd.nokia.radio-preset", "Nokia Radio Application - Preset" },
                    { 428, ".rpss", "application/vnd.nokia.radio-presets", "Nokia Radio Application - Preset" },
                    { 429, ".n3", "text/n3", "Notation3" },
                    { 430, ".edm", "application/vnd.novadigm.edm", "Novadigm's RADIA and EDM products" },
                    { 422, ".nlu", "application/vnd.neurolanguage.nlu", "neuroLanguage" },
                    { 432, ".ext", "application/vnd.novadigm.ext", "Novadigm's RADIA and EDM products" },
                    { 411, ".mp4a", "audio/mp4", "MPEG-4 Audio" },
                    { 409, ".mpeg", "video/mpeg", "MPEG Video" },
                    { 391, ".mpy", "application/vnd.ibm.minipay", "MiniPay" },
                    { 392, ".afp", "application/vnd.ibm.modcap", "MO:DCA-P" },
                    { 393, ".rms", "application/vnd.jcp.javame.midlet-rms", "Mobile Information Device Profile" },
                    { 394, ".tmo", "application/vnd.tmobile-livetv", "MobileTV" },
                    { 395, ".prc", "application/x-mobipocket-ebook", "Mobipocket" },
                    { 396, ".mbk", "application/vnd.mobius.mbk", "Mobius Management Systems - Basket file" },
                    { 397, ".dis", "application/vnd.mobius.dis", "Mobius Management Systems - Distribution Database" },
                    { 398, ".plc", "application/vnd.mobius.plc", "Mobius Management Systems - Policy Definition Language File" },
                    { 410, ".m21", "application/mp21", "MPEG-21" },
                    { 399, ".mqy", "application/vnd.mobius.mqy", "Mobius Management Systems - Query File" },
                    { 401, ".txf", "application/vnd.mobius.txf", "Mobius Management Systems - Topic Index File" },
                    { 402, ".daf", "application/vnd.mobius.daf", "Mobius Management Systems - UniversalArchive" },
                    { 403, ".fly", "text/vnd.fly", "mod_fly / fly.cgi" },
                    { 404, ".mpc", "application/vnd.mophun.certificate", "Mophun Certificate" },
                    { 405, ".mpn", "application/vnd.mophun.application", "Mophun VM" },
                    { 406, ".mj2", "video/mj2", "Motion JPEG 2000" },
                    { 407, ".mpga", "audio/mpeg", "MPEG Audio" },
                    { 408, ".mxu", "video/vnd.mpegurl", "MPEG Url" },
                    { 400, ".msl", "application/vnd.mobius.msl", "Mobius Management Systems - Script Language" },
                    { 518, ".ei6", "application/vnd.pg.osasli", "Proprietary P&G Standard Reporting System" },
                    { 526, ".ssf", "application/vnd.epson.ssf", "QUASS Stream Player" },
                    { 520, ".psf", "application/x-font-linux-psf", "PSF Fonts" },
                    { 630, ".uoml", "application/vnd.uoml+xml", "Unique Object Markup Language" },
                    { 631, ".unityweb", "application/vnd.unity", "Unity 3d" },
                    { 632, ".ufd", "application/vnd.ufdl", "Universal Forms Description Language" },
                    { 633, ".uri", "text/uri-list", "URI Resolution Services" },
                    { 634, ".utz", "application/vnd.uiq.theme", "User Interface Quartz - Theme (Symbian)" },
                    { 635, ".ustar", "application/x-ustar", "Ustar (Uniform Standard Tape Archive)" },
                    { 636, ".uu", "text/x-uuencode", "UUEncode" },
                    { 637, ".vcs", "text/x-vcalendar", "vCalendar" },
                    { 638, ".vcf", "text/x-vcard", "vCard" },
                    { 639, ".vcd", "application/x-cdlink", "Video CD" },
                    { 640, ".vsf", "application/vnd.vsf", "Viewport+" },
                    { 641, ".wrl", "model/vrml", "Virtual Reality Modeling Language" },
                    { 642, ".vcx", "application/vnd.vcx", "VirtualCatalog" },
                    { 643, ".mts", "model/vnd.mts", "Virtue MTS" },
                    { 644, ".vtu", "model/vnd.vtu", "Virtue VTU" },
                    { 645, ".vis", "application/vnd.visionary", "Visionary" },
                    { 646, ".viv", "video/vnd.vivo", "Vivo" },
                    { 629, ".umj", "application/vnd.umajin", "UMAJIN" },
                    { 628, ".ttl", "text/turtle", "Turtle (Terse RDF Triple Language)" },
                    { 627, ".ttf", "application/x-font-ttf", "TrueType Font" },
                    { 626, ".tra", "application/vnd.trueapp", "True BASIC" },
                    { 608, ".sv4cpio", "application/x-sv4cpio", "System V Release 4 CPIO Archive" },
                    { 609, ".sv4crc", "application/x-sv4crc", "System V Release 4 CPIO Checksum Data" },
                    { 610, ".sbml", "application/sbml+xml", "Systems Biology Markup Language" },
                    { 611, ".tsv", "text/tab-separated-values", "Tab Seperated Values" },
                    { 612, ".tiff", "image/tiff", "Tagged Image File Format" },
                    { 613, ".tao", "application/vnd.tao.intent-module-archive", "Tao Intent" },
                    { 614, ".tar", "application/x-tar", "Tar File (Tape Archive)" },
                    { 615, ".tcl", "application/x-tcl", "Tcl Script" },
                    { 647, "\"", "\"application/ccxml+xml", "Voice Browser Call Control" },
                    { 616, ".tex", "application/x-tex", "TeX" },
                    { 618, ".tei", "application/tei+xml", "Text Encoding and Interchange" },
                    { 619, ".txt", "text/plain", "Text File" },
                    { 620, ".dxp", "application/vnd.spotfire.dxp", "TIBCO Spotfire" },
                    { 621, ".sfs", "application/vnd.spotfire.sfs", "TIBCO Spotfire" },
                    { 622, ".tsd", "application/timestamped-data", "Time Stamped Data Envelope" },
                    { 623, ".tpt", "application/vnd.trid.tpt", "TRI Systems Config" },
                    { 624, ".mxs", "application/vnd.triscape.mxs", "Triscape Map Explorer" },
                    { 625, ".t", "text/troff", "troff" },
                    { 617, ".tfm", "application/x-tex-tfm", "TeX Font Metric" },
                    { 607, ".xdm", "application/vnd.syncml.dm+xml", "SyncML - Device Management" },
                    { 648, ".vxml", "application/voicexml+xml", "VoiceXML" },
                    { 650, ".wbxml", "application/vnd.wap.wbxml", "WAP Binary XML (WBXML)" },
                    { 673, ".xdf", "application/xcap-diff+xml", "XML Configuration Access Protocol - XCAP Diff" },
                    { 674, ".xenc", "application/xenc+xml", "XML Encryption Syntax and Processing" },
                    { 675, ".xer", "application/patch-ops-error+xml", "XML Patch Framework" },
                    { 676, ".rl", "application/resource-lists+xml", "XML Resource Lists" },
                    { 677, ".rs", "application/rls-services+xml", "XML Resource Lists" },
                    { 678, ".rld", "application/resource-lists-diff+xml", "XML Resource Lists Diff" },
                    { 679, ".xslt", "application/xslt+xml", "XML Transformations" },
                    { 680, ".xop", "application/xop+xml", "XML-Binary Optimized Packaging" },
                    { 681, ".xpi", "application/x-xpinstall", "XPInstall - Mozilla" },
                    { 682, ".xspf", "application/xspf+xml", "XSPF - XML Shareable Playlist Format" },
                    { 683, ".xul", "application/vnd.mozilla.xul+xml", "XUL - XML User Interface Language" },
                    { 684, ".xyz", "chemical/x-xyz", "XYZ File Format" },
                    { 685, ".yaml", "text/yaml", "YAML Ain't Markup Language / Yet Another Markup Language" },
                    { 686, ".yang", "application/yang", "YANG Data Modeling Language" },
                    { 687, ".yin", "application/yin+xml", "YIN (YANG - XML)" },
                    { 688, ".zir", "application/vnd.zul", "Z.U.L. Geometry" },
                    { 689, ".zip", "application/zip", "Zip Archive" },
                    { 672, ".xml", "application/xml", "XML - Extensible Markup Language" },
                    { 671, ".xhtml", "application/xhtml+xml", "XHTML - The Extensible HyperText Markup Language" },
                    { 670, ".fig", "application/x-xfig", "Xfig" },
                    { 669, ".der", "application/x-x509-ca-cert", "X.509 Certificate" },
                    { 651, ".wbmp", "image/vnd.wap.wbmp", "WAP Bitamp (WBMP)" },
                    { 652, ".wav", "audio/x-wav", "Waveform Audio File Format (WAV)" },
                    { 653, ".davmount", "application/davmount+xml", "Web Distributed Authoring and Versioning" },
                    { 654, ".woff", "application/x-font-woff", "Web Open Font Format" },
                    { 655, ".wspolicy", "application/wspolicy+xml", "Web Services Policy" },
                    { 656, ".webp", "image/webp", "WebP Image" },
                    { 657, ".wtb", "application/vnd.webturbo", "WebTurbo" },
                    { 658, ".wgt", "application/widget", "Widget Packaging and XML Configuration" },
                    { 649, ".src", "application/x-wais-source", "WAIS Source" },
                    { 659, ".hlp", "application/winhlp", "WinHelp" },
                    { 661, ".wmls", "text/vnd.wap.wmlscript", "Wireless Markup Language Script (WMLScript)" },
                    { 662, ".wmlsc", "application/vnd.wap.wmlscriptc", "WMLScript" },
                    { 663, ".wpd", "application/vnd.wordperfect", "Wordperfect" },
                    { 664, ".stf", "application/vnd.wt.stf", "Worldtalk" },
                    { 665, ".wsdl", "application/wsdl+xml", "WSDL - Web Services Description Language" },
                    { 666, ".xbm", "image/x-xbitmap", "X BitMap" },
                    { 667, ".xpm", "image/x-xpixmap", "X PixMap" },
                    { 668, ".xwd", "image/x-xwindowdump", "X Window Dump" },
                    { 660, ".wml", "text/vnd.wap.wml", "Wireless Markup Language (WML)" },
                    { 606, ".bdm", "application/vnd.syncml.dm+wbxml", "SyncML - Device Management" },
                    { 605, ".xsm", "application/vnd.syncml+xml", "SyncML" },
                    { 604, ".smi", "application/smil+xml", "Synchronized Multimedia Integration Language" },
                    { 543, ".rtf", "application/rtf", "Rich Text Format" },
                    { 544, ".rtx", "text/richtext", "Rich Text Format (RTF)" },
                    { 545, ".link66", "application/vnd.route66.link66+xml", "ROUTE 66 Location Based Services" },
                    { 546, "\".rss", "application/rss+xml", "RSS - Really Simple Syndication" },
                    { 547, ".shf", "application/shf+xml", "S Hexdump Format" },
                    { 548, ".st", "application/vnd.sailingtracker.track", "SailingTracker" },
                    { 549, ".svg", "image/svg+xml", "Scalable Vector Graphics (SVG)" },
                    { 550, ".sus", "application/vnd.sus-calendar", "ScheduleUs" },
                    { 551, ".sru", "application/sru+xml", "Search/Retrieve via URL Response Format" },
                    { 552, ".setpay", "application/set-payment-initiation", "Secure Electronic Transaction - Payment" },
                    { 553, ".setreg", "application/set-registration-initiation", "Secure Electronic Transaction - Registration" },
                    { 554, ".sema", "application/vnd.sema", "Secured eMail" },
                    { 555, ".semd", "application/vnd.semd", "Secured eMail" },
                    { 556, ".semf", "application/vnd.semf", "Secured eMail" },
                    { 557, ".see", "application/vnd.seemail", "SeeMail" },
                    { 558, ".snf", "application/x-font-snf", "Server Normal Format" },
                    { 559, ".spq", "application/scvp-vp-request", "Server-Based Certificate Validation Protocol - Validation Policies - Request" },
                    { 542, ".jisp", "application/vnd.jisp", "RhymBox" },
                    { 541, ".rp9", "application/vnd.cloanto.rp9", "RetroPlatform Player" },
                    { 540, ".rdf", "application/rdf+xml", "Resource Description Framework" },
                    { 539, ".rdz", "application/vnd.data-vision.rdz", "RemoteDocs R-Viewer" },
                    { 521, ".qps", "application/vnd.publishare-delta-tree", "PubliShare Objects" },
                    { 522, ".wg", "application/vnd.pmi.widget", "Qualcomm's Plaza Mobile Internet" },
                    { 523, ".qxd", "application/vnd.quark.quarkxpress", "QuarkXpress" },
                    { 524, ".esf", "application/vnd.epson.esf", "QUASS Stream Player" },
                    { 525, ".msf", "application/vnd.epson.msf", "QUASS Stream Player" },
                    { 347, ".ppsx", "application/vnd.openxmlformats-officedocument.presentationml.slideshow", "Microsoft Office - OOXML - Presentation (Slideshow)" },
                    { 527, ".qam", "application/vnd.epson.quickanime", "QuickAnime Player" },
                    { 528, ".qfx", "application/vnd.intu.qfx", "Quicken" },
                    { 560, ".spp", "application/scvp-vp-response", "Server-Based Certificate Validation Protocol - Validation Policies - Response" },
                    { 529, ".qt", "video/quicktime", "Quicktime Video" },
                    { 531, ".ram", "audio/x-pn-realaudio", "Real Audio Sound" },
                    { 532, ".rmp", "audio/x-pn-realaudio-plugin", "Real Audio Sound" },
                    { 533, ".rsd", "application/rsd+xml", "Really Simple Discovery" },
                    { 534, ".rm", "application/vnd.rn-realmedia", "RealMedia" },
                    { 535, ".bed", "application/vnd.realvnc.bed", "RealVNC" },
                    { 536, ".mxl", "application/vnd.recordare.musicxml", "Recordare Applications" },
                    { 537, ".musicxml", "application/vnd.recordare.musicxml+xml", "Recordare Applications" },
                    { 538, ".rnc", "application/relax-ng-compact-syntax", "Relax NG Compact Syntax" },
                    { 530, ".rar", "application/x-rar-compressed", "RAR Archive" },
                    { 561, ".scq", "application/scvp-cv-request", "Server-Based Certificate Validation Protocol - Validation Request" },
                    { 562, ".scs", "application/scvp-cv-response", "Server-Based Certificate Validation Protocol - Validation Response" },
                    { 563, ".sdp", "application/sdp", "Session Description Protocol" },
                    { 586, ".grxml", "application/srgs+xml", "Speech Recognition Grammar Specification - XML" },
                    { 587, ".ssml", "application/ssml+xml", "Speech Synthesis Markup Language" },
                    { 588, ".skp", "application/vnd.koan", "SSEYO Koan Play File" },
                    { 589, ".sgml", "text/sgml", "Standard Generalized Markup Language (SGML)" },
                    { 590, ".sdc", "application/vnd.stardivision.calc", "StarOffice - Calc" },
                    { 591, ".sda", "application/vnd.stardivision.draw", "StarOffice - Draw" },
                    { 592, ".sdd", "application/vnd.stardivision.impress", "StarOffice - Impress" },
                    { 593, ".smf", "application/vnd.stardivision.math", "StarOffice - Math" },
                    { 585, ".gram", "application/srgs", "Speech Recognition Grammar Specification" },
                    { 594, ".sdw", "application/vnd.stardivision.writer", "StarOffice - Writer" },
                    { 596, ".sm", "application/vnd.stepmania.stepchart", "StepMania" },
                    { 597, ".sit", "application/x-stuffit", "Stuffit Archive" },
                    { 598, ".sitx", "application/x-stuffitx", "Stuffit Archive" },
                    { 599, ".sdkm", "application/vnd.solent.sdkm+xml", "SudokuMagic" },
                    { 600, ".xo", "application/vnd.olpc-sugar", "Sugar Linux Application Bundle" },
                    { 601, ".au", "audio/basic", "Sun Audio - Au file format" },
                    { 602, ".wqd", "application/vnd.wqd", "SundaHus WQ" },
                    { 603, ".sis", "application/vnd.symbian.install", "Symbian Install Package" },
                    { 595, ".sgl", "application/vnd.stardivision.writer-global", "StarOffice - Writer (Global)" },
                    { 519, ".dsc", "text/prs.lines.tag", "PRS Lines Tag" },
                    { 584, ".srx", "application/sparql-results+xml", "SPARQL - Results" },
                    { 582, ".svd", "application/vnd.svd", "SourceView Document" },
                    { 564, ".etx", "text/x-setext", "Setext" },
                    { 565, ".movie", "video/x-sgi-movie", "SGI Movie" },
                    { 566, ".ifm", "application/vnd.shana.informed.formdata", "Shana Informed Filler" },
                    { 567, ".itp", "application/vnd.shana.informed.formtemplate", "Shana Informed Filler" },
                    { 568, ".iif", "application/vnd.shana.informed.interchange", "Shana Informed Filler" },
                    { 569, ".ipk", "application/vnd.shana.informed.package", "Shana Informed Filler" },
                    { 570, ".tfi", "application/thraud+xml", "Sharing Transaction Fraud Data" },
                    { 571, ".shar", "application/x-shar", "Shell Archive" },
                    { 583, ".rq", "application/sparql-query", "SPARQL - Query" },
                    { 572, ".rgb", "image/x-rgb", "Silicon Graphics RGB Bitmap" },
                    { 574, ".aso", "application/vnd.accpac.simply.aso", "Simply Accounting" },
                    { 575, ".imp", "application/vnd.accpac.simply.imp", "Simply Accounting - Data Import" },
                    { 576, ".twd", "application/vnd.simtech-mindmapper", "SimTech MindMapper" },
                    { 577, ".csp", "application/vnd.commonspace", "Sixth Floor Media - CommonSpace" },
                    { 578, ".saf", "application/vnd.yamaha.smaf-audio", "SMAF Audio" },
                    { 579, ".mmf", "application/vnd.smaf", "SMAF File" },
                    { 580, ".spf", "application/vnd.yamaha.smaf-phrase", "SMAF Phrase" },
                    { 581, ".teacher", "application/vnd.smart.teacher", "SMART Technologies Apps" },
                    { 573, ".slt", "application/vnd.epson.salt", "SimpleAnimeLite Player" },
                    { 346, ".sldx", "application/vnd.openxmlformats-officedocument.presentationml.slide", "Microsoft Office - OOXML - Presentation (Slide)" },
                    { 337, ".xlsb", "application/vnd.ms-excel.sheet.binary.macroenabled.12", "Microsoft Excel - Binary Workbook" },
                    { 344, ".mny", "application/x-msmoney", "Microsoft Money" },
                    { 110, ".scurl", "text/vnd.curl.scurl", "Curl - Source Code" },
                    { 111, ".car", "application/vnd.curl.car", "CURL Applet" },
                    { 112, ".pcurl", "application/vnd.curl.pcurl", "CURL Applet" },
                    { 113, ".cmp", "application/vnd.yellowriver-custom-menu", "CustomMenu" },
                    { 114, ".dssc", "application/dssc+der", "Data Structure for the Security Suitability of Cryptographic Algorithms" },
                    { 115, ".xdssc", "application/dssc+xml", "Data Structure for the Security Suitability of Cryptographic Algorithms" },
                    { 116, ".deb", "application/x-debian-package", "Debian Package" },
                    { 117, ".uva", "audio/vnd.dece.audio", "DECE Audio" },
                    { 118, ".uvi", "image/vnd.dece.graphic", "DECE Graphic" },
                    { 119, ".uvh", "video/vnd.dece.hd", "DECE High Definition Video" },
                    { 120, ".uvm", "video/vnd.dece.mobile", "DECE Mobile Video" },
                    { 121, ".uvu", "video/vnd.uvvu.mp4", "DECE MP4" },
                    { 122, ".uvp", "video/vnd.dece.pd", "DECE PD Video" },
                    { 123, ".uvs", "video/vnd.dece.sd", "DECE SD Video" },
                    { 124, ".uvv", "video/vnd.dece.video", "DECE Video" },
                    { 125, ".dvi", "application/x-dvi", "Device Independent File Format (DVI)" },
                    { 126, ".seed", "application/vnd.fdsn.seed", "Digital Siesmograph Networks - SEED Datafiles" },
                    { 109, ".mcurl", "text/vnd.curl.mcurl", "Curl - Manifest File" },
                    { 108, ".dcurl", "text/vnd.curl.dcurl", "Curl - Detached Applet" },
                    { 107, ".curl", "text/vnd.curl", "Curl - Applet" },
                    { 106, ".cww", "application/prs.cww", "CU-Writer" },
                    { 88, ".cpt", "application/mac-compactpro", "Compact Pro" },
                    { 89, ".wmlc", "application/vnd.wap.wmlc", "Compiled Wireless Markup Language (WMLC)" },
                    { 90, ".cgm", "image/cgm", "Computer Graphics Metafile" },
                    { 91, ".ice", "x-conference/x-cooltalk", "CoolTalk" },
                    { 92, ".cmx", "image/x-cmx", "Corel Metafile Exchange (CMX)" },
                    { 93, ".xar", "application/vnd.xara", "CorelXARA" },
                    { 94, ".cmc", "application/vnd.cosmocaller", "CosmoCaller" },
                    { 95, ".cpio", "application/x-cpio", "CPIO Archive" },
                    { 127, ".dtb", "application/x-dtbook+xml", "Digital Talking Book" },
                    { 96, ".clkx", "application/vnd.crick.clicker", "CrickSoftware - Clicker" },
                    { 98, ".clkp", "application/vnd.crick.clicker.palette", "CrickSoftware - Clicker - Palette" },
                    { 99, ".clkt", "application/vnd.crick.clicker.template", "CrickSoftware - Clicker - Template" },
                    { 100, ".clkw", "application/vnd.crick.clicker.wordbank", "CrickSoftware - Clicker - Wordbank" },
                    { 101, ".wbs", "application/vnd.criticaltools.wbs+xml", "Critical Tools - PERT Chart EXPERT" },
                    { 102, ".cryptonote", "application/vnd.rig.cryptonote", "CryptoNote" },
                    { 103, ".cif", "chemical/x-cif", "Crystallographic Interchange Format" },
                    { 104, ".cmdf", "chemical/x-cmdf", "CrystalMaker Data Format" },
                    { 105, ".cu", "application/cu-seeme", "CU-SeeMe" },
                    { 97, ".clkk", "application/vnd.crick.clicker.keyboard", "CrickSoftware - Clicker - Keyboard" },
                    { 87, ".csv", "text/csv", "Comma-Seperated Values" },
                    { 128, ".res", "application/x-dtbresource+xml", "Digital Talking Book - Resource File" },
                    { 130, ".svc", "application/vnd.dvb.service", "Digital Video Broadcasting" },
                    { 153, ".xif", "image/vnd.xiff", "eXtended Image File Format (XIFF)" },
                    { 154, ".xfdl", "application/vnd.xfdl", "Extensible Forms Description Language" },
                    { 155, ".emma", "application/emma+xml", "Extensible MultiModal Annotation" },
                    { 156, ".ez2", "application/vnd.ezpix-album", "EZPix Secure Photo Album" },
                    { 157, ".ez3", "application/vnd.ezpix-package", "EZPix Secure Photo Album" },
                    { 158, ".fst", "image/vnd.fst", "FAST Search & Transfer ASA" },
                    { 159, ".fvt", "video/vnd.fvt", "FAST Search & Transfer ASA" },
                    { 160, ".fbs", "image/vnd.fastbidsheet", "FastBid Sheet" },
                    { 161, ".fe_launch", "application/vnd.denovo.fcselayout-link", "FCS Express Layout Link" },
                    { 162, ".f4v", "video/x-f4v", "Flash Video" },
                    { 163, ".flv", "video/x-flv", "Flash Video" },
                    { 164, ".fpx", "image/vnd.fpx", "FlashPix" },
                    { 165, ".npx", "image/vnd.net-fpx", "FlashPix" },
                    { 166, ".flx", "text/vnd.fmi.flexstor", "FLEXSTOR" },
                    { 167, ".fli", "video/x-fli", "FLI/FLC Animation Format" },
                    { 168, ".ftc", "application/vnd.fluxtime.clip", "FluxTime Clip" },
                    { 169, ".fdf", "application/vnd.fdf", "Forms Data Format" },
                    { 152, ".xpr", "application/vnd.is-xpr", "Express by Infoseek" },
                    { 151, ".nml", "application/vnd.enliven", "Enliven Viewer" },
                    { 150, ".eml", "message/rfc822", "Email Message" },
                    { 149, ".epub", "application/epub+zip", "Electronic Publication" },
                    { 131, ".eol", "audio/vnd.digital-winds", "Digital Winds Music" },
                    { 132, ".djvu", "image/vnd.djvu", "DjVu" },
                    { 133, ".dtd", "application/xml-dtd", "Document Type Definition" },
                    { 134, ".mlp", "application/vnd.dolby.mlp", "Dolby Meridian Lossless Packing" },
                    { 135, ".wad", "application/x-doom", "Doom Video Game" },
                    { 136, ".dpg", "application/vnd.dpgraph", "DPGraph" },
                    { 137, ".dra", "audio/vnd.dra", "DRA Audio" },
                    { 138, ".dfac", "application/vnd.dreamfactory", "DreamFactory" },
                    { 129, ".ait", "application/vnd.dvb.ait", "Digital Video Broadcasting" },
                    { 139, ".dts", "audio/vnd.dts", "DTS Audio" },
                    { 141, ".dwg", "image/vnd.dwg", "DWG Drawing" },
                    { 142, ".geo", "application/vnd.dynageo", "DynaGeo" },
                    { 143, ".es", "application/ecmascript", "ECMAScript" },
                    { 144, ".mag", "application/vnd.ecowin.chart", "EcoWin Chart" },
                    { 145, ".mmr", "image/vnd.fujixerox.edmics-mmr", "EDMICS 2000" },
                    { 146, ".rlc", "image/vnd.fujixerox.edmics-rlc", "EDMICS 2000" },
                    { 147, ".exi", "application/exi", "Efficient XML Interchange" },
                    { 148, ".mgz", "application/vnd.proteus.magazine", "EFI Proteus" },
                    { 140, ".dtshd", "audio/vnd.dts.hd", "DTS High Definition Audio" },
                    { 86, ".dae", "model/vnd.collada+xml", "COLLADA" },
                    { 85, ".ras", "image/x-cmu-raster", "CMU Image" },
                    { 84, ".c11amz", "application/vnd.cluetrust.cartomobile-config-pkg", "ClueTrust CartoMobile - Config Package" },
                    { 23, ".pdf", "application/pdf", "Adobe Portable Document Format" },
                    { 24, ".ppd", "application/vnd.cups-ppd", "Adobe PostScript Printer Description File Format" },
                    { 25, ".dir", "application/x-director", "Adobe Shockwave Player" },
                    { 26, ".xdp", "application/vnd.adobe.xdp+xml", "Adobe XML Data Package" },
                    { 27, ".xfdf", "application/vnd.adobe.xfdf", "Adobe XML Forms Data Format" },
                    { 28, ".aac", "audio/x-aac", "Advanced Audio Coding (AAC)" },
                    { 29, ".ahead", "application/vnd.ahead.space", "Ahead AIR Application" },
                    { 30, ".azf", "application/vnd.airzip.filesecure.azf", "AirZip FileSECURE" },
                    { 31, ".azs", "application/vnd.airzip.filesecure.azs", "AirZip FileSECURE" },
                    { 32, ".azw", "application/vnd.amazon.ebook", "Amazon Kindle eBook format" },
                    { 33, ".ami", "application/vnd.amiga.ami", "AmigaDE" },
                    { 34, "N/A", "application/andrew-inset", "Andrew Toolkit" },
                    { 35, ".apk", "application/vnd.android.package-archive", "Android Package Archive" },
                    { 36, ".cii", "application/vnd.anser-web-certificate-issue-initiation", "ANSER-WEB Terminal Client - Certificate Issue" },
                    { 37, ".fti", "application/vnd.anser-web-funds-transfer-initiation", "ANSER-WEB Terminal Client - Web Funds Transfer" },
                    { 38, ".atx", "application/vnd.antix.game-component", "Antix Game Player" },
                    { 39, ".dmg", "application/x-apple-diskimage", "Apple Disk Image" },
                    { 22, ".fxp", "application/vnd.adobe.fxp", "Adobe Flex Project" },
                    { 21, ".swf", "application/x-shockwave-flash", "Adobe Flash" },
                    { 20, ".air", "application/vnd.adobe.air-application-installer-package+zip", "Adobe AIR Application" },
                    { 19, ".aas", "application/x-authorware-seg", "Adobe (Macropedia) Authorware - Segment File" },
                    { 1, ".x3d", "application/vnd.hzn-3d-crossword", "3D Crossword Plugin" },
                    { 2, ".3gp", "video/3gpp", "3GP" },
                    { 3, ".3g2", "video/3gpp2", "3GP2" },
                    { 4, ".mseq", "application/vnd.mseq", "3GPP MSEQ File" },
                    { 5, ".pwn", "application/vnd.3m.post-it-notes", "3M Post It Notes" },
                    { 6, ".plb", "application/vnd.3gpp.pic-bw-large", "3rd Generation Partnership Project - Pic Large" },
                    { 7, ".psb", "application/vnd.3gpp.pic-bw-small", "3rd Generation Partnership Project - Pic Small" },
                    { 8, ".pvb", "application/vnd.3gpp.pic-bw-var", "3rd Generation Partnership Project - Pic Var" },
                    { 40, ".mpkg", "application/vnd.apple.installer+xml", "Apple Installer Package" },
                    { 9, ".tcap", "application/vnd.3gpp2.tcap", "3rd Generation Partnership Project - Transaction Capabilities Application Part" },
                    { 11, ".abw", "application/x-abiword", "AbiWord" },
                    { 12, ".ace", "application/x-ace-compressed", "Ace Archive" },
                    { 13, ".acc", "application/vnd.americandynamics.acc", "Active Content Compression" },
                    { 14, ".acu", "application/vnd.acucobol", "ACU Cobol" },
                    { 15, ".atc", "application/vnd.acucorp", "ACU Cobol" },
                    { 16, ".adp", "audio/adpcm", "Adaptive differential pulse-code modulation" },
                    { 17, ".aab", "application/x-authorware-bin", "Adobe (Macropedia) Authorware - Binary File" },
                    { 18, ".aam", "application/x-authorware-map", "Adobe (Macropedia) Authorware - Map" },
                    { 10, ".7z", "application/x-7z-compressed", "7-Zip" },
                    { 41, ".aw", "application/applixware", "Applixware" },
                    { 42, ".les", "application/vnd.hhe.lesson-player", "Archipelago Lesson Player" },
                    { 43, ".swi", "application/vnd.aristanetworks.swi", "Arista Networks Software Image" },
                    { 66, ".bz2", "application/x-bzip2", "Bzip2 Archive" },
                    { 67, ".csh", "application/x-csh", "C Shell Script" },
                    { 68, ".c", "text/x-c", "C Source File" },
                    { 69, ".cdxml", "application/vnd.chemdraw+xml", "CambridgeSoft Chem Draw" },
                    { 70, ".css", "text/css", "Cascading Style Sheets (CSS)" },
                    { 71, ".cdx", "chemical/x-cdx", "ChemDraw eXchange file" },
                    { 72, ".cml", "chemical/x-cml", "Chemical Markup Language" },
                    { 73, ".csml", "chemical/x-csml", "Chemical Style Markup Language" },
                    { 65, ".bz", "application/x-bzip", "Bzip Archive" },
                    { 74, ".cdbcmsg", "application/vnd.contact.cmsg", "CIM Database" },
                    { 76, ".c4g", "application/vnd.clonk.c4group", "Clonk Game" },
                    { 77, ".sub", "image/vnd.dvb.subtitle", "Close Captioning - Subtitle" },
                    { 78, ".cdmia", "application/cdmi-capability", "Cloud Data Management Interface (CDMI) - Capability" },
                    { 79, ".cdmic", "application/cdmi-container", "Cloud Data Management Interface (CDMI) - Contaimer" },
                    { 80, ".cdmid", "application/cdmi-domain", "Cloud Data Management Interface (CDMI) - Domain" },
                    { 81, ".cdmio", "application/cdmi-object", "Cloud Data Management Interface (CDMI) - Object" },
                    { 82, ".cdmiq", "application/cdmi-queue", "Cloud Data Management Interface (CDMI) - Queue" },
                    { 83, ".c11amc", "application/vnd.cluetrust.cartomobile-config", "ClueTrust CartoMobile - Config" },
                    { 75, ".cla", "application/vnd.claymore", "Claymore Data Files" },
                    { 170, ".f", "text/x-fortran", "Fortran Source File" },
                    { 64, ".rep", "application/vnd.businessobjects", "BusinessObjects" },
                    { 62, ".sh", "application/x-sh", "Bourne Shell Script" },
                    { 44, ".s", "text/x-asm", "Assembler Source File" },
                    { 45, ".atomcat", "application/atomcat+xml", "Atom Publishing Protocol" },
                    { 46, ".atomsvc", "application/atomsvc+xml", "Atom Publishing Protocol Service Document" },
                    { 47, "\".atom", "application/atom+xml", "Atom Syndication Format" },
                    { 48, ".ac", "application/pkix-attr-cert", "Attribute Certificate" },
                    { 49, ".aif", "audio/x-aiff", "Audio Interchange File Format" },
                    { 50, ".avi", "video/x-msvideo", "Audio Video Interleave (AVI)" },
                    { 51, ".aep", "application/vnd.audiograph", "Audiograph" },
                    { 63, ".btif", "image/prs.btif", "BTIF" },
                    { 52, ".dxf", "image/vnd.dxf", "AutoCAD DXF" },
                    { 54, ".par", "text/plain-bas", "BAS Partitur Format" }
                });

            migrationBuilder.InsertData(
                table: "MimeType",
                columns: new[] { "Id", "FileExtention", "MIMEType", "Name" },
                values: new object[,]
                {
                    { 55, ".bcpio", "application/x-bcpio", "Binary CPIO Archive" },
                    { 56, ".bin", "application/octet-stream", "Binary Data" },
                    { 57, ".bmp", "image/bmp", "Bitmap Image File" },
                    { 58, ".torrent", "application/x-bittorrent", "BitTorrent" },
                    { 59, ".cod", "application/vnd.rim.cod", "Blackberry COD File" },
                    { 60, ".mpm", "application/vnd.blueice.multipass", "Blueice Research Multipass" },
                    { 61, ".bmi", "application/vnd.bmi", "BMI Drawing Data Interchange" },
                    { 53, ".dwf", "model/vnd.dwf", "Autodesk Design Web Format (DWF)" },
                    { 171, ".mif", "application/vnd.mif", "FrameMaker Interchange Format" },
                    { 172, ".fm", "application/vnd.framemaker", "FrameMaker Normal Format" },
                    { 173, ".fh", "image/x-freehand", "FreeHand MX" },
                    { 283, ".kia", "application/vnd.kidspiration", "Kidspiration" },
                    { 284, ".kne", "application/vnd.kinar", "Kinar Applications" },
                    { 285, ".sse", "application/vnd.kodak-descriptor", "Kodak Storyshare" },
                    { 286, ".lasxml", "application/vnd.las.las+xml", "Laser App Enterprise" },
                    { 287, ".latex", "application/x-latex", "LaTeX" },
                    { 288, ".lbd", "application/vnd.llamagraphics.life-balance.desktop", "Life Balance - Desktop Edition" },
                    { 289, ".lbe", "application/vnd.llamagraphics.life-balance.exchange+xml", "Life Balance - Exchange Format" },
                    { 290, ".jam", "application/vnd.jam", "Lightspeed Audio Lab" },
                    { 291, "0.123", "application/vnd.lotus-1-2-3", "Lotus 1-2-3" },
                    { 292, ".apr", "application/vnd.lotus-approach", "Lotus Approach" },
                    { 293, ".pre", "application/vnd.lotus-freelance", "Lotus Freelance" },
                    { 294, ".nsf", "application/vnd.lotus-notes", "Lotus Notes" },
                    { 295, ".org", "application/vnd.lotus-organizer", "Lotus Organizer" },
                    { 296, ".scm", "application/vnd.lotus-screencam", "Lotus Screencam" },
                    { 297, ".lwp", "application/vnd.lotus-wordpro", "Lotus Wordpro" },
                    { 298, ".lvp", "audio/vnd.lucent.voice", "Lucent Voice" },
                    { 299, ".m3u", "audio/x-mpegurl", "M3U (Multimedia Playlist)" },
                    { 282, ".htke", "application/vnd.kenameaapp", "Kenamea App" },
                    { 281, ".kwd", "application/vnd.kde.kword", "KDE KOffice Office Suite - Kword" },
                    { 280, ".ksp", "application/vnd.kde.kspread", "KDE KOffice Office Suite - Kspread" },
                    { 279, ".kpr", "application/vnd.kde.kpresenter", "KDE KOffice Office Suite - Kpresenter" },
                    { 261, ".jnlp", "application/x-java-jnlp-file", "Java Network Launching Protocol" },
                    { 262, ".ser", "application/java-serialized-object", "Java Serialized Object" },
                    { 263, "java\"", "\"text/x-java-source", "Java Source File" },
                    { 264, ".js", "application/javascript", "JavaScript" },
                    { 265, ".json", "application/json", "JavaScript Object Notation (JSON)" },
                    { 266, ".joda", "application/vnd.joost.joda-archive", "Joda Archive" },
                    { 267, ".jpm", "video/jpm", "JPEG 2000 Compound Image File Format" },
                    { 268, "\".jpeg", "image/jpeg", "JPEG Image" },
                    { 300, ".m4v", "video/x-m4v", "M4v" },
                    { 269, "\".jpeg", "image/x-citrix-jpeg", "JPEG Image (Citrix client)" },
                    { 271, ".jpgv", "video/jpeg", "JPGVideo" },
                    { 272, ".ktz", "application/vnd.kahootz", "Kahootz" },
                    { 273, ".mmd", "application/vnd.chipnuts.karaoke-mmd", "Karaoke on Chipnuts Chipsets" },
                    { 274, ".karbon", "application/vnd.kde.karbon", "KDE KOffice Office Suite - Karbon" },
                    { 275, ".chrt", "application/vnd.kde.kchart", "KDE KOffice Office Suite - KChart" },
                    { 276, ".kfo", "application/vnd.kde.kformula", "KDE KOffice Office Suite - Kformula" },
                    { 277, ".flw", "application/vnd.kde.kivio", "KDE KOffice Office Suite - Kivio" },
                    { 278, ".kon", "application/vnd.kde.kontour", "KDE KOffice Office Suite - Kontour" },
                    { 270, ".pjpeg", "image/pjpeg", "JPEG Image (Progressive)" },
                    { 301, ".hqx", "application/mac-binhex40", "Macintosh BinHex 4.0" },
                    { 302, ".portpkg", "application/vnd.macports.portpkg", "MacPorts Port System" },
                    { 303, ".mgp", "application/vnd.osgeo.mapguide.package", "MapGuide DBXML" },
                    { 326, ".asf", "video/x-ms-asf", "Microsoft Advanced Systems Format (ASF)" },
                    { 327, ".exe", "application/x-msdownload", "Microsoft Application" },
                    { 328, ".cil", "application/vnd.ms-artgalry", "Microsoft Artgalry" },
                    { 329, ".cab", "application/vnd.ms-cab-compressed", "Microsoft Cabinet File" },
                    { 330, ".ims", "application/vnd.ms-ims", "Microsoft Class Server" },
                    { 331, ".application", "application/x-ms-application", "Microsoft ClickOnce" },
                    { 332, ".clp", "application/x-msclip", "Microsoft Clipboard Clip" },
                    { 333, ".mdi", "image/vnd.ms-modi", "Microsoft Document Imaging Format" },
                    { 325, ".mdb", "application/x-msaccess", "Microsoft Access" },
                    { 334, ".eot", "application/vnd.ms-fontobject", "Microsoft Embedded OpenType" },
                    { 336, ".xlam", "application/vnd.ms-excel.addin.macroenabled.12", "Microsoft Excel - Add-In File" },
                    { 690, ".zmm", "application/vnd.handheld-entertainment+xml", "ZVUE Media Manager" },
                    { 338, ".xltm", "application/vnd.ms-excel.template.macroenabled.12", "Microsoft Excel - Macro-Enabled Template File" },
                    { 339, ".xlsm", "application/vnd.ms-excel.sheet.macroenabled.12", "Microsoft Excel - Macro-Enabled Workbook" },
                    { 340, ".chm", "application/vnd.ms-htmlhelp", "Microsoft Html Help File" },
                    { 341, ".crd", "application/x-mscardfile", "Microsoft Information Card" },
                    { 342, ".lrm", "application/vnd.ms-lrm", "Microsoft Learning Resource Module" },
                    { 343, ".mvb", "application/x-msmediaview", "Microsoft MediaView" },
                    { 335, ".xls", "application/vnd.ms-excel", "Microsoft Excel" },
                    { 260, ".class", "application/java-vm", "Java Bytecode File" },
                    { 324, ".es3", "application/vnd.eszigno3+xml", "MICROSEC e-Szign¢" },
                    { 322, ".flo", "application/vnd.micrografx.flo", "Micrografx" },
                    { 304, ".mrc", "application/marc", "MARC Formats" },
                    { 305, ".mrcx", "application/marcxml+xml", "MARC21 XML Schema" },
                    { 306, ".mxf", "application/mxf", "Material Exchange Format" },
                    { 307, ".nbp", "application/vnd.wolfram.player", "Mathematica Notebook Player" },
                    { 308, ".ma", "application/mathematica", "Mathematica Notebooks" },
                    { 309, ".mathml", "application/mathml+xml", "Mathematical Markup Language" },
                    { 310, ".mbox", "application/mbox", "Mbox database files" },
                    { 311, ".mc1", "application/vnd.medcalcdata", "MedCalc" },
                    { 323, ".igx", "application/vnd.micrografx.igx", "Micrografx iGrafx Professional" },
                    { 312, ".mscml", "application/mediaservercontrol+xml", "Media Server Control Markup Language" },
                    { 314, ".mwf", "application/vnd.mfer", "Medical Waveform Encoding Format" },
                    { 315, ".mfm", "application/vnd.mfmp", "Melody Format for Mobile Platform" },
                    { 316, ".msh", "model/mesh", "Mesh Data Type" },
                    { 317, ".mads", "application/mads+xml", "Metadata Authority Description Schema" },
                    { 318, ".mets", "application/mets+xml", "Metadata Encoding and Transmission Standard" },
                    { 319, ".mods", "application/mods+xml", "Metadata Object Description Schema" },
                    { 320, ".meta4", "application/metalink4+xml", "Metalink" },
                    { 321, ".mcd", "application/vnd.mcd", "Micro CADAM Helix D&D" },
                    { 313, ".cdkey", "application/vnd.mediastation.cdkey", "MediaRemote" },
                    { 345, ".pptx", "application/vnd.openxmlformats-officedocument.presentationml.presentation", "Microsoft Office - OOXML - Presentation" },
                    { 259, ".jar", "application/java-archive", "Java Archive" },
                    { 257, ".irp", "application/vnd.irepository.package+xml", "iRepository / Lucidoc Editor" },
                    { 196, ".g2w", "application/vnd.geoplan", "GeoplanW" },
                    { 197, ".g3w", "application/vnd.geospace", "GeospacW" },
                    { 198, ".gsf", "application/x-font-ghostscript", "Ghostscript Font" },
                    { 199, ".bdf", "application/x-font-bdf", "Glyph Bitmap Distribution Format" },
                    { 200, ".gtar", "application/x-gtar", "GNU Tar Files" },
                    { 201, ".texinfo", "application/x-texinfo", "GNU Texinfo Document" },
                    { 202, ".gnumeric", "application/x-gnumeric", "Gnumeric" },
                    { 203, ".kml", "application/vnd.google-earth.kml+xml", "Google Earth - KML" },
                    { 204, ".kmz", "application/vnd.google-earth.kmz", "Google Earth - Zipped KML" },
                    { 205, ".gqf", "application/vnd.grafeq", "GrafEq" },
                    { 206, ".gif", "image/gif", "Graphics Interchange Format" },
                    { 207, ".gv", "text/vnd.graphviz", "Graphviz" },
                    { 208, ".gac", "application/vnd.groove-account", "Groove - Account" },
                    { 209, ".ghf", "application/vnd.groove-help", "Groove - Help" },
                    { 210, ".gim", "application/vnd.groove-identity-message", "Groove - Identity Message" },
                    { 211, ".grv", "application/vnd.groove-injector", "Groove - Injector" },
                    { 212, ".gtm", "application/vnd.groove-tool-message", "Groove - Tool Message" },
                    { 195, ".gxt", "application/vnd.geonext", "GEONExT and JSXGraph" },
                    { 194, ".gex", "application/vnd.geometry-explorer", "GeoMetry Explorer" },
                    { 193, ".gdl", "model/vnd.gdl", "Geometric Description Language (GDL)" },
                    { 192, ".ggt", "application/vnd.geogebra.tool", "GeoGebra" },
                    { 174, ".fsc", "application/vnd.fsc.weblaunch", "Friendly Software Corporation" },
                    { 175, ".fnc", "application/vnd.frogans.fnc", "Frogans Player" },
                    { 176, ".ltf", "application/vnd.frogans.ltf", "Frogans Player" },
                    { 177, ".ddd", "application/vnd.fujixerox.ddd", "Fujitsu - Xerox 2D CAD Data" },
                    { 178, ".xdw", "application/vnd.fujixerox.docuworks", "Fujitsu - Xerox DocuWorks" },
                    { 179, ".xbd", "application/vnd.fujixerox.docuworks.binder", "Fujitsu - Xerox DocuWorks Binder" },
                    { 180, ".oas", "application/vnd.fujitsu.oasys", "Fujitsu Oasys" },
                    { 181, ".oa2", "application/vnd.fujitsu.oasys2", "Fujitsu Oasys" },
                    { 213, ".tpl", "application/vnd.groove-tool-template", "Groove - Tool Template" },
                    { 182, ".oa3", "application/vnd.fujitsu.oasys3", "Fujitsu Oasys" },
                    { 184, ".bh2", "application/vnd.fujitsu.oasysprs", "Fujitsu Oasys" },
                    { 185, ".spl", "application/x-futuresplash", "FutureSplash Animator" },
                    { 186, ".fzs", "application/vnd.fuzzysheet", "FuzzySheet" },
                    { 187, ".g3", "image/g3fax", "G3 Fax Image" },
                    { 188, ".gmx", "application/vnd.gmx", "GameMaker ActiveX" },
                    { 189, ".gtw", "model/vnd.gtw", "Gen-Trix Studio" },
                    { 190, ".txd", "application/vnd.genomatix.tuxedo", "Genomatix Tuxedo Framework" },
                    { 191, ".ggb", "application/vnd.geogebra.file", "GeoGebra" },
                    { 183, ".fg5", "application/vnd.fujitsu.oasysgp", "Fujitsu Oasys" },
                    { 214, ".vcg", "application/vnd.groove-vcard", "Groove - Vcard" },
                    { 215, ".h261", "video/h261", "H.261" },
                    { 216, ".h263", "video/h263", "H.263" },
                    { 239, ".ief", "image/ief", "Image Exchange Format" },
                    { 240, ".ivp", "application/vnd.immervision-ivp", "ImmerVision PURE Players" },
                    { 241, ".ivu", "application/vnd.immervision-ivu", "ImmerVision PURE Players" },
                    { 242, ".rif", "application/reginfo+xml", "IMS Networks" },
                    { 243, ".3dml", "text/vnd.in3d.3dml", "In3D - 3DML" },
                    { 244, ".spot", "text/vnd.in3d.spot", "In3D - 3DML" },
                    { 245, ".igs", "model/iges", "Initial Graphics Exchange Specification (IGES)" },
                    { 246, ".i2g", "application/vnd.intergeo", "Interactive Geometry Software" },
                    { 238, ".igl", "application/vnd.igloader", "igLoader" },
                    { 247, ".cdy", "application/vnd.cinderella", "Interactive Geometry Software Cinderella" },
                    { 249, ".fcs", "application/vnd.isac.fcs", "International Society for Advancement of Cytometry" },
                    { 250, ".ipfix", "application/ipfix", "Internet Protocol Flow Information Export" },
                    { 251, ".cer", "application/pkix-cert", "Internet Public Key Infrastructure - Certificate" },
                    { 252, ".pki", "application/pkixcmp", "Internet Public Key Infrastructure - Certificate Management Protocole" },
                    { 253, ".crl", "application/pkix-crl", "Internet Public Key Infrastructure - Certificate Revocation Lists" },
                    { 254, ".pkipath", "application/pkix-pkipath", "Internet Public Key Infrastructure - Certification Path" },
                    { 255, ".igm", "application/vnd.insors.igm", "IOCOM Visimeet" },
                    { 256, ".rcprofile", "application/vnd.ipunplugged.rcprofile", "IP Unplugged Roaming Client" },
                    { 248, ".xpw", "application/vnd.intercon.formnet", "Intercon FormNet" },
                    { 258, ".jad", "text/vnd.sun.j2me.app-descriptor", "J2ME App Descriptor" },
                    { 237, ".ico", "image/x-icon", "Icon Image" },
                    { 235, ".ics", "text/calendar", "iCalendar" },
                    { 217, ".h264", "video/h264", "H.264" },
                    { 218, ".hpid", "application/vnd.hp-hpid", "Hewlett Packard Instant Delivery" },
                    { 219, ".hps", "application/vnd.hp-hps", "Hewlett-Packard's WebPrintSmart" },
                    { 220, ".hdf", "application/x-hdf", "Hierarchical Data Format" },
                    { 221, ".rip", "audio/vnd.rip", "Hit'n'Mix" },
                    { 222, ".hbci", "application/vnd.hbci", "Homebanking Computer Interface (HBCI)" },
                    { 223, ".jlt", "application/vnd.hp-jlyt", "HP Indigo Digital Press - Job Layout Languate" },
                    { 224, ".pcl", "application/vnd.hp-pcl", "HP Printer Command Language" },
                    { 236, ".icc", "application/vnd.iccprofile", "ICC profile" },
                    { 225, ".hpgl", "application/vnd.hp-hpgl", "HP-GL/2 and HP RTL" },
                    { 227, ".hvd", "application/vnd.yamaha.hv-dic", "HV Voice Dictionary" },
                    { 228, ".hvp", "application/vnd.yamaha.hv-voice", "HV Voice Parameter" },
                    { 229, ".sfd-hdstx", "application/vnd.hydrostatix.sof-data", "Hydrostatix Master Suite" },
                    { 230, ".stk", "application/hyperstudio", "Hyperstudio" },
                    { 231, ".hal", "application/vnd.hal+xml", "Hypertext Application Language" },
                    { 232, ".html", "text/html", "HyperText Markup Language (HTML)" },
                    { 233, ".irm", "application/vnd.ibm.rights-management", "IBM DB2 Rights Manager" },
                    { 234, ".sc", "application/vnd.ibm.secure-container", "IBM Electronic Media Management System - Secure Container" },
                    { 226, ".hvs", "application/vnd.yamaha.hv-script", "HV Script" },
                    { 691, ".zaz", "application/vnd.zzazz.deck+xml", "Zzazz Deck" }
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
                name: "IX_AspNetUsers_ImageId",
                table: "AspNetUsers",
                column: "ImageId",
                unique: true,
                filter: "[ImageId] IS NOT NULL");

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
                name: "IX_DefenceEvents_ThesesUserEntryId",
                table: "DefenceEvents",
                column: "ThesesUserEntryId",
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
                name: "IX_FileContent_UserEntryId",
                table: "FileContent",
                column: "UserEntryId");

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
                name: "IX_ThesesUserEntries_ThesesId",
                table: "ThesesUserEntries",
                column: "ThesesId");

            migrationBuilder.CreateIndex(
                name: "IX_ThesisApprovementRequest_ThemeObserverId",
                table: "ThesisApprovementRequest",
                column: "ThemeObserverId");

            migrationBuilder.CreateIndex(
                name: "IX_ThesisApprovementRequest_ThesesUserEntryId",
                table: "ThesisApprovementRequest",
                column: "ThesesUserEntryId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Theses_AspNetUsers_CreatorId",
                table: "Theses",
                column: "CreatorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ThesesUserEntries_AspNetUsers_StudentId",
                table: "ThesesUserEntries",
                column: "StudentId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Commissions_AspNetUsers_MainCommissionTeacherId",
                table: "Commissions");

            migrationBuilder.DropForeignKey(
                name: "FK_Theses_AspNetUsers_CreatorId",
                table: "Theses");

            migrationBuilder.DropForeignKey(
                name: "FK_ThesesUserEntries_AspNetUsers_StudentId",
                table: "ThesesUserEntries");

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
                name: "MimeType");

            migrationBuilder.DropTable(
                name: "ThesisApprovementRequest");

            migrationBuilder.DropTable(
                name: "ThesisRequerments");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "DefenceDates");

            migrationBuilder.DropTable(
                name: "Marks");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "FileContent");

            migrationBuilder.DropTable(
                name: "Groups");

            migrationBuilder.DropTable(
                name: "Commissions");

            migrationBuilder.DropTable(
                name: "ThesesUserEntries");

            migrationBuilder.DropTable(
                name: "Theses");

            migrationBuilder.DropTable(
                name: "Subjects");

            migrationBuilder.DropTable(
                name: "Specialties");

            migrationBuilder.DropTable(
                name: "Deparments");

            migrationBuilder.DropTable(
                name: "Faculties");
        }
    }
}
