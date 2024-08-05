using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Hogwarts.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    FirstName = table.Column<string>(type: "text", nullable: true),
                    LastName = table.Column<string>(type: "text", nullable: true),
                    Career = table.Column<string>(type: "text", nullable: true),
                    UserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    SecurityStamp = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Houses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Founder = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Animal = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Element = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Houses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pictures",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Url = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    CharacterId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pictures", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
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
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    ProviderKey = table.Column<string>(type: "text", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    RoleId = table.Column<string>(type: "text", nullable: false)
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
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Characters",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FirstName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    Age = table.Column<int>(type: "integer", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "timestamptz", nullable: false),
                    BloodStatus = table.Column<int>(type: "integer", nullable: false),
                    PictureId = table.Column<Guid>(type: "uuid", nullable: false),
                    Discriminator = table.Column<string>(type: "character varying(13)", maxLength: 13, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Characters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Characters_Pictures_PictureId",
                        column: x => x.PictureId,
                        principalTable: "Pictures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Professors",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CourseId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Professors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Professors_Characters_Id",
                        column: x => x.Id,
                        principalTable: "Characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    HouseId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Students_Characters_Id",
                        column: x => x.Id,
                        principalTable: "Characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Students_Houses_HouseId",
                        column: x => x.HouseId,
                        principalTable: "Houses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    ProfessorId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Courses_Professors_ProfessorId",
                        column: x => x.ProfessorId,
                        principalTable: "Professors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "StudentCourse",
                columns: table => new
                {
                    StudentId = table.Column<Guid>(type: "uuid", nullable: false),
                    CourseId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentCourse", x => new { x.StudentId, x.CourseId });
                    table.ForeignKey(
                        name: "FK_StudentCourse_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentCourse_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "27ccf3eb-1430-47ee-86cf-c6d52a9ee3a0", null, "Client", "CLIENT" },
                    { "ee478e3c-43d8-494b-a7b6-52e70a04b1af", null, "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "Houses",
                columns: new[] { "Id", "Animal", "Element", "Founder", "Name" },
                values: new object[,]
                {
                    { new Guid("109dd5e7-164c-4cec-b623-d28be70cc2c2"), "Lion", "Fire", "Godric Gryffindor", "Gryffindor" },
                    { new Guid("24248a2a-d323-47fd-8be7-3b9e415d9a91"), "Serpent", "Water", "Salazar Slytherin", "Slytherin" },
                    { new Guid("40f4b844-b0a4-4178-a5d9-c2ae70a8932b"), "Eagle", "Air", "Rowena Ravenclaw", "Ravenclaw" },
                    { new Guid("a784a261-3009-484a-9ca5-d141630c932f"), "Badger", "Earth", "Helga Hufflepuff", "Hufflepuff" }
                });

            migrationBuilder.InsertData(
                table: "Pictures",
                columns: new[] { "Id", "CharacterId", "Url" },
                values: new object[,]
                {
                    { new Guid("01961b12-3bc9-40df-b700-085730a85346"), new Guid("4a5ef299-cb93-414f-ab79-9a68a8fca29a"), "https://picsum.photos/640/480/?image=629" },
                    { new Guid("0890ce8e-4df3-43e8-8ea5-37cc9c2ffaf0"), new Guid("2056f277-04a5-4993-b42b-b95409861339"), "https://picsum.photos/640/480/?image=589" },
                    { new Guid("0b2f9612-cfc0-4164-8a99-b31f697b1b43"), new Guid("96022ed7-22c6-4ddc-b519-64418afd3b17"), "https://picsum.photos/640/480/?image=753" },
                    { new Guid("0c4ed495-86c1-4fec-9942-71d6c32bb552"), new Guid("f26e87b8-c04e-4952-9ec4-7f1dd7553dbf"), "https://picsum.photos/640/480/?image=147" },
                    { new Guid("0f57f8a3-3576-4738-941c-09d2a1af3df7"), new Guid("e0bb8237-4c88-4260-8b97-37cc9d36dab4"), "https://picsum.photos/640/480/?image=180" },
                    { new Guid("130b48a8-4ffb-4c4b-8917-7fd7a5d475e1"), new Guid("b8c94937-5f78-4684-9b0c-1372acb80cef"), "https://picsum.photos/640/480/?image=731" },
                    { new Guid("19a3455f-96cf-4aed-a37b-f90e34df0fcf"), new Guid("45326cf2-d2fd-436b-8467-3a42a7526ff4"), "https://picsum.photos/640/480/?image=431" },
                    { new Guid("1e33eb0f-ab78-437e-8437-f8d4080d014c"), new Guid("40642373-111c-477c-b9bc-2262b98bd46d"), "https://picsum.photos/640/480/?image=131" },
                    { new Guid("26983c54-ce47-444f-9c7f-b945466ef5cd"), new Guid("dd77d8e5-841d-497e-8d49-12add2937745"), "https://picsum.photos/640/480/?image=893" },
                    { new Guid("27570a3f-0958-4cf4-95cc-b4e41ce69e24"), new Guid("f3823bd4-ff2c-492b-b350-384eacdacc73"), "https://picsum.photos/640/480/?image=486" },
                    { new Guid("31320530-ceb3-4571-864e-8c34b747b924"), new Guid("13b2c9c6-6d59-4c7c-be24-9ab380a2f1fa"), "https://picsum.photos/640/480/?image=85" },
                    { new Guid("40ad5a79-dfff-4c30-b75e-451a5b84cedb"), new Guid("d11bc147-af2f-4ffb-bec5-e23e78ecf69c"), "https://picsum.photos/640/480/?image=769" },
                    { new Guid("4a14947b-ed67-4957-b9f8-8e6bc03e621c"), new Guid("bcca110f-4d47-4464-acf3-be4d19f9bbe7"), "https://picsum.photos/640/480/?image=417" },
                    { new Guid("5ad0a7ff-e61c-4654-9aea-09b50f4f72b1"), new Guid("570d8591-fa0a-4320-80fd-60e6923b88d4"), "https://picsum.photos/640/480/?image=268" },
                    { new Guid("6cd7ed15-c8f8-413f-9ca2-26a51a9f5696"), new Guid("2d2ee102-93ff-4bcd-9585-44935c1bebf5"), "https://picsum.photos/640/480/?image=624" },
                    { new Guid("71d18bfd-426e-45e7-974e-15c4646f5391"), new Guid("89cdf4ee-480d-4fdc-a241-2648bf12edca"), "https://picsum.photos/640/480/?image=56" },
                    { new Guid("7d762647-a6f7-40ae-8ef5-dd09e035533e"), new Guid("7d89bc90-0d93-4ef4-bdab-10d246056524"), "https://picsum.photos/640/480/?image=758" },
                    { new Guid("7fd2381b-8139-4e3b-afa1-a11284082781"), new Guid("c92e4206-5682-4cba-8e74-6cc289adbaad"), "https://picsum.photos/640/480/?image=685" },
                    { new Guid("832220bb-0e09-48c4-a5ad-e13d62719654"), new Guid("35d5e574-b5c6-476c-b64f-c6afff2f216f"), "https://picsum.photos/640/480/?image=815" },
                    { new Guid("84978f33-1faf-41eb-b815-2366962d0806"), new Guid("6e71a59c-e1fe-4475-85a8-8ae7eadd0b1c"), "https://picsum.photos/640/480/?image=727" },
                    { new Guid("911bd40e-fa45-4ba8-918f-90cf10bc2bb5"), new Guid("a9df18cc-d325-4030-97af-1d89d0ebbe39"), "https://picsum.photos/640/480/?image=943" },
                    { new Guid("92b9be95-712b-4bcc-9ba4-be31e7a7d12e"), new Guid("e2e07556-0189-41a2-ae8d-7cd046628a10"), "https://picsum.photos/640/480/?image=851" },
                    { new Guid("9a2c71d6-5f21-4ff6-bbd0-746a42880da2"), new Guid("d8d74e5f-2243-49bc-ad52-09dbbc241143"), "https://picsum.photos/640/480/?image=177" },
                    { new Guid("b89b05b8-ebdf-4862-aca3-7b5e83ecea69"), new Guid("e6eb03f6-3127-49f1-b04b-20b436a9de53"), "https://picsum.photos/640/480/?image=375" },
                    { new Guid("b8da827f-f045-4098-ba3a-db3fd7dcc520"), new Guid("050cb727-0eed-49d8-85eb-d73fe591db8e"), "https://picsum.photos/640/480/?image=202" },
                    { new Guid("c300d4ca-aa33-4789-bde4-8590e09270f4"), new Guid("daaebe41-85ce-40c2-b7dd-1d10c819ca58"), "https://picsum.photos/640/480/?image=419" },
                    { new Guid("e022c7ee-03ec-4eb3-b391-4a59a74501c1"), new Guid("dfb80e7b-1d9a-4db5-9b5f-6b0f5f147f44"), "https://picsum.photos/640/480/?image=732" },
                    { new Guid("f184d732-805a-4d97-81db-e3a935e84278"), new Guid("afcdd9d2-8eca-4b8d-8d3e-25b558fa20b0"), "https://picsum.photos/640/480/?image=985" },
                    { new Guid("f6fb37f8-b57e-4b03-a4f7-256113ec4f5f"), new Guid("bf078d20-2627-43f1-b030-4fc08ee12942"), "https://picsum.photos/640/480/?image=873" },
                    { new Guid("fcebf517-7d51-462b-be46-edad1a296a5f"), new Guid("42bad019-adf0-4cd9-945a-0fb4d544b560"), "https://picsum.photos/640/480/?image=1061" }
                });

            migrationBuilder.InsertData(
                table: "AspNetRoleClaims",
                columns: new[] { "Id", "ClaimType", "ClaimValue", "RoleId" },
                values: new object[,]
                {
                    { 1, "POLICIES", "COURSE_CREATE", "ee478e3c-43d8-494b-a7b6-52e70a04b1af" },
                    { 2, "POLICIES", "COURSE_READ", "ee478e3c-43d8-494b-a7b6-52e70a04b1af" },
                    { 3, "POLICIES", "COURSE_UPDATE", "ee478e3c-43d8-494b-a7b6-52e70a04b1af" },
                    { 4, "POLICIES", "COURSE_DELETE", "ee478e3c-43d8-494b-a7b6-52e70a04b1af" },
                    { 5, "POLICIES", "PROFESSOR_READ", "ee478e3c-43d8-494b-a7b6-52e70a04b1af" },
                    { 6, "POLICIES", "PROFESSOR_CREATE", "ee478e3c-43d8-494b-a7b6-52e70a04b1af" },
                    { 7, "POLICIES", "PROFESSOR_UPDATE", "ee478e3c-43d8-494b-a7b6-52e70a04b1af" },
                    { 8, "POLICIES", "PROFESSOR_DELETE", "ee478e3c-43d8-494b-a7b6-52e70a04b1af" },
                    { 9, "POLICIES", "STUDENT_READ", "ee478e3c-43d8-494b-a7b6-52e70a04b1af" },
                    { 10, "POLICIES", "STUDENT_CREATE", "ee478e3c-43d8-494b-a7b6-52e70a04b1af" },
                    { 11, "POLICIES", "STUDENT_UPDATE", "ee478e3c-43d8-494b-a7b6-52e70a04b1af" },
                    { 12, "POLICIES", "STUDENT_DELETE", "ee478e3c-43d8-494b-a7b6-52e70a04b1af" },
                    { 13, "POLICIES", "COURSE_READ", "27ccf3eb-1430-47ee-86cf-c6d52a9ee3a0" },
                    { 14, "POLICIES", "PROFESSOR_READ", "27ccf3eb-1430-47ee-86cf-c6d52a9ee3a0" },
                    { 15, "POLICIES", "STUDENT_READ", "27ccf3eb-1430-47ee-86cf-c6d52a9ee3a0" }
                });

            migrationBuilder.InsertData(
                table: "Characters",
                columns: new[] { "Id", "Age", "BloodStatus", "DateOfBirth", "Description", "Discriminator", "FirstName", "LastName", "PictureId" },
                values: new object[,]
                {
                    { new Guid("050cb727-0eed-49d8-85eb-d73fe591db8e"), 55, 2, new DateTime(1957, 9, 22, 21, 39, 24, 617, DateTimeKind.Utc).AddTicks(8895), "Nihil ea ducimus molestias.", null, "Adriana", "Cervántez", new Guid("b8da827f-f045-4098-ba3a-db3fd7dcc520") },
                    { new Guid("13b2c9c6-6d59-4c7c-be24-9ab380a2f1fa"), 11, 2, new DateTime(2005, 7, 16, 11, 41, 32, 935, DateTimeKind.Utc).AddTicks(3254), "Nobis aliquam nulla laboriosam fugiat consequuntur sapiente eligendi sint.", null, "Guadalupe", "Ureña", new Guid("31320530-ceb3-4571-864e-8c34b747b924") },
                    { new Guid("2056f277-04a5-4993-b42b-b95409861339"), 13, 0, new DateTime(2008, 7, 30, 19, 5, 36, 265, DateTimeKind.Utc).AddTicks(2565), "Est velit temporibus.", null, "Roberto", "Rascón", new Guid("0890ce8e-4df3-43e8-8ea5-37cc9c2ffaf0") },
                    { new Guid("2d2ee102-93ff-4bcd-9585-44935c1bebf5"), 12, 1, new DateTime(2002, 8, 5, 22, 3, 33, 718, DateTimeKind.Utc).AddTicks(4108), "Atque rem qui quis esse quia dolorem dolorem soluta quas.", null, "Inés", "Narváez", new Guid("6cd7ed15-c8f8-413f-9ca2-26a51a9f5696") },
                    { new Guid("35d5e574-b5c6-476c-b64f-c6afff2f216f"), 15, 4, new DateTime(2003, 7, 28, 6, 14, 38, 236, DateTimeKind.Utc).AddTicks(9287), "Itaque ipsa nihil velit at et aperiam.", null, "Cristina", "Vergara", new Guid("832220bb-0e09-48c4-a5ad-e13d62719654") },
                    { new Guid("40642373-111c-477c-b9bc-2262b98bd46d"), 13, 1, new DateTime(2007, 3, 23, 22, 35, 26, 99, DateTimeKind.Utc).AddTicks(2198), "Doloribus enim qui cumque soluta nam asperiores sit quo quia.", null, "Elena", "Ávalos", new Guid("1e33eb0f-ab78-437e-8437-f8d4080d014c") },
                    { new Guid("42bad019-adf0-4cd9-945a-0fb4d544b560"), 13, 2, new DateTime(2001, 7, 3, 17, 29, 10, 595, DateTimeKind.Utc).AddTicks(2784), "Asperiores veritatis quis dolores placeat sint qui quia.", null, "Octavio", "Cervántez", new Guid("fcebf517-7d51-462b-be46-edad1a296a5f") },
                    { new Guid("45326cf2-d2fd-436b-8467-3a42a7526ff4"), 41, 1, new DateTime(1975, 6, 25, 15, 25, 20, 417, DateTimeKind.Utc).AddTicks(168), "Dolore similique natus eum illum eligendi.", null, "Gregorio", "Coronado", new Guid("19a3455f-96cf-4aed-a37b-f90e34df0fcf") },
                    { new Guid("4a5ef299-cb93-414f-ab79-9a68a8fca29a"), 11, 4, new DateTime(2003, 5, 28, 6, 8, 36, 502, DateTimeKind.Utc).AddTicks(1543), "Autem perspiciatis cum est officia qui sit perferendis.", null, "Antonio", "Raya", new Guid("01961b12-3bc9-40df-b700-085730a85346") },
                    { new Guid("570d8591-fa0a-4320-80fd-60e6923b88d4"), 56, 1, new DateTime(1932, 10, 24, 17, 50, 20, 662, DateTimeKind.Utc).AddTicks(1371), "Non ea earum iste rerum animi.", null, "Gregorio", "Montenegro", new Guid("5ad0a7ff-e61c-4654-9aea-09b50f4f72b1") },
                    { new Guid("6e71a59c-e1fe-4475-85a8-8ae7eadd0b1c"), 17, 0, new DateTime(2005, 4, 10, 14, 31, 12, 481, DateTimeKind.Utc).AddTicks(2991), "Occaecati tempore consequatur alias repellendus harum corrupti excepturi cupiditate.", null, "Lucía", "Domínguez", new Guid("84978f33-1faf-41eb-b815-2366962d0806") },
                    { new Guid("7d89bc90-0d93-4ef4-bdab-10d246056524"), 13, 0, new DateTime(2006, 1, 30, 8, 42, 19, 861, DateTimeKind.Utc).AddTicks(9294), "Natus asperiores voluptas quia laudantium quas facere.", null, "Felipe", "Alba", new Guid("7d762647-a6f7-40ae-8ef5-dd09e035533e") },
                    { new Guid("89cdf4ee-480d-4fdc-a241-2648bf12edca"), 13, 0, new DateTime(2006, 2, 8, 9, 24, 37, 508, DateTimeKind.Utc).AddTicks(9545), "Maiores eos laboriosam doloribus.", null, "Natalia", "Rosas", new Guid("71d18bfd-426e-45e7-974e-15c4646f5391") },
                    { new Guid("96022ed7-22c6-4ddc-b519-64418afd3b17"), 30, 1, new DateTime(1972, 4, 12, 5, 36, 9, 6, DateTimeKind.Utc).AddTicks(2619), "Necessitatibus est est natus architecto assumenda dolores et qui.", null, "Laura", "Dávila", new Guid("0b2f9612-cfc0-4164-8a99-b31f697b1b43") },
                    { new Guid("a9df18cc-d325-4030-97af-1d89d0ebbe39"), 64, 1, new DateTime(1949, 12, 30, 19, 43, 31, 721, DateTimeKind.Utc).AddTicks(2820), "Perspiciatis ratione est.", null, "Rosalia", "Rael", new Guid("911bd40e-fa45-4ba8-918f-90cf10bc2bb5") },
                    { new Guid("afcdd9d2-8eca-4b8d-8d3e-25b558fa20b0"), 13, 3, new DateTime(1998, 12, 11, 10, 25, 20, 804, DateTimeKind.Utc).AddTicks(4055), "Accusantium autem aut dolores ipsum qui hic sunt cum.", null, "Ricardo", "Almaráz", new Guid("f184d732-805a-4d97-81db-e3a935e84278") },
                    { new Guid("b8c94937-5f78-4684-9b0c-1372acb80cef"), 64, 4, new DateTime(1944, 8, 23, 14, 3, 17, 580, DateTimeKind.Utc).AddTicks(6682), "Vero aut dolore voluptates nulla consequatur quas voluptatem est et.", null, "Beatriz", "Godoy", new Guid("130b48a8-4ffb-4c4b-8917-7fd7a5d475e1") },
                    { new Guid("bcca110f-4d47-4464-acf3-be4d19f9bbe7"), 32, 1, new DateTime(1984, 3, 25, 12, 49, 44, 622, DateTimeKind.Utc).AddTicks(5497), "Eius explicabo quia distinctio sed est temporibus voluptas labore.", null, "Guadalupe", "Polanco", new Guid("4a14947b-ed67-4957-b9f8-8e6bc03e621c") },
                    { new Guid("bf078d20-2627-43f1-b030-4fc08ee12942"), 49, 1, new DateTime(1973, 9, 15, 19, 4, 25, 605, DateTimeKind.Utc).AddTicks(7054), "Et voluptatem illo numquam.", null, "Agustín", "Magaña", new Guid("f6fb37f8-b57e-4b03-a4f7-256113ec4f5f") },
                    { new Guid("c92e4206-5682-4cba-8e74-6cc289adbaad"), 11, 4, new DateTime(2012, 2, 27, 12, 51, 25, 537, DateTimeKind.Utc).AddTicks(3531), "Rerum ducimus modi quos necessitatibus.", null, "José Emilio", "Mireles", new Guid("7fd2381b-8139-4e3b-afa1-a11284082781") },
                    { new Guid("d11bc147-af2f-4ffb-bec5-e23e78ecf69c"), 58, 3, new DateTime(1936, 2, 23, 16, 19, 38, 668, DateTimeKind.Utc).AddTicks(9764), "Quas quae recusandae sunt aut voluptatibus sequi.", null, "Luisa", "Carrillo", new Guid("40ad5a79-dfff-4c30-b75e-451a5b84cedb") },
                    { new Guid("d8d74e5f-2243-49bc-ad52-09dbbc241143"), 11, 1, new DateTime(2004, 4, 5, 3, 51, 33, 137, DateTimeKind.Utc).AddTicks(3870), "Quasi cum vel nihil nemo sed blanditiis.", null, "Antonia", "Chávez", new Guid("9a2c71d6-5f21-4ff6-bbd0-746a42880da2") },
                    { new Guid("daaebe41-85ce-40c2-b7dd-1d10c819ca58"), 12, 2, new DateTime(2006, 7, 6, 18, 22, 5, 790, DateTimeKind.Utc).AddTicks(2936), "Dolores provident quam voluptates accusamus.", null, "Antonia", "Esparza", new Guid("c300d4ca-aa33-4789-bde4-8590e09270f4") },
                    { new Guid("dd77d8e5-841d-497e-8d49-12add2937745"), 14, 1, new DateTime(1997, 8, 8, 9, 23, 23, 197, DateTimeKind.Utc).AddTicks(3172), "Id expedita aliquid dignissimos quae harum.", null, "Gabriela", "de Jesús", new Guid("26983c54-ce47-444f-9c7f-b945466ef5cd") },
                    { new Guid("dfb80e7b-1d9a-4db5-9b5f-6b0f5f147f44"), 17, 0, new DateTime(1996, 1, 31, 23, 53, 51, 811, DateTimeKind.Utc).AddTicks(7756), "Doloremque voluptates quam libero nemo ut id illo.", null, "Martín", "Espino", new Guid("e022c7ee-03ec-4eb3-b391-4a59a74501c1") },
                    { new Guid("e0bb8237-4c88-4260-8b97-37cc9d36dab4"), 37, 4, new DateTime(1959, 9, 20, 7, 9, 0, 891, DateTimeKind.Utc).AddTicks(7255), "Voluptatum sed voluptatem nisi ut magni ut voluptates officiis culpa.", null, "Caridad", "Urbina", new Guid("0f57f8a3-3576-4738-941c-09d2a1af3df7") },
                    { new Guid("e2e07556-0189-41a2-ae8d-7cd046628a10"), 15, 1, new DateTime(1998, 1, 26, 7, 17, 40, 172, DateTimeKind.Utc).AddTicks(6867), "Suscipit repellendus accusantium sit.", null, "Beatriz", "Alejandro", new Guid("92b9be95-712b-4bcc-9ba4-be31e7a7d12e") },
                    { new Guid("e6eb03f6-3127-49f1-b04b-20b436a9de53"), 11, 0, new DateTime(2009, 5, 2, 14, 36, 55, 773, DateTimeKind.Utc).AddTicks(6721), "Aspernatur est ut.", null, "María Cristina", "Tirado", new Guid("b89b05b8-ebdf-4862-aca3-7b5e83ecea69") },
                    { new Guid("f26e87b8-c04e-4952-9ec4-7f1dd7553dbf"), 11, 0, new DateTime(2006, 9, 16, 2, 15, 6, 81, DateTimeKind.Utc).AddTicks(4624), "Aut pariatur aut incidunt sed nesciunt nulla rerum.", null, "Octavio", "Colunga", new Guid("0c4ed495-86c1-4fec-9942-71d6c32bb552") },
                    { new Guid("f3823bd4-ff2c-492b-b350-384eacdacc73"), 12, 2, new DateTime(2004, 11, 16, 20, 53, 29, 197, DateTimeKind.Utc).AddTicks(7338), "Tenetur nesciunt nihil id nulla voluptate vel quia ipsum.", null, "Rafael", "Ocasio", new Guid("27570a3f-0958-4cf4-95cc-b4e41ce69e24") }
                });

            migrationBuilder.InsertData(
                table: "Professors",
                columns: new[] { "Id", "CourseId" },
                values: new object[,]
                {
                    { new Guid("050cb727-0eed-49d8-85eb-d73fe591db8e"), new Guid("a2d2f532-f931-428a-b777-8ab00ef28234") },
                    { new Guid("45326cf2-d2fd-436b-8467-3a42a7526ff4"), new Guid("4bdf89fb-fe52-4d0c-b4af-e285e8d57fc6") },
                    { new Guid("570d8591-fa0a-4320-80fd-60e6923b88d4"), new Guid("6c47a25e-4dc0-440a-847b-c8387f6ef877") },
                    { new Guid("96022ed7-22c6-4ddc-b519-64418afd3b17"), new Guid("750b7b2f-fcb3-4b2a-aa3e-c3820c918d8f") },
                    { new Guid("a9df18cc-d325-4030-97af-1d89d0ebbe39"), new Guid("b9df4ade-39ae-424c-8271-133cf6bef19b") },
                    { new Guid("b8c94937-5f78-4684-9b0c-1372acb80cef"), new Guid("d9e159ed-a3b7-485d-9569-73a733eefa12") },
                    { new Guid("bcca110f-4d47-4464-acf3-be4d19f9bbe7"), new Guid("7451bceb-6aa7-406f-9a55-870906df7eaa") },
                    { new Guid("bf078d20-2627-43f1-b030-4fc08ee12942"), new Guid("bb335af0-bb41-4f01-932f-c2b853a3b9b0") },
                    { new Guid("d11bc147-af2f-4ffb-bec5-e23e78ecf69c"), new Guid("7c7bdae7-3295-4788-bc9a-c309864d0548") },
                    { new Guid("e0bb8237-4c88-4260-8b97-37cc9d36dab4"), new Guid("54b4588f-9516-4184-8d9c-f749c6754d6a") }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "HouseId" },
                values: new object[,]
                {
                    { new Guid("13b2c9c6-6d59-4c7c-be24-9ab380a2f1fa"), new Guid("24248a2a-d323-47fd-8be7-3b9e415d9a91") },
                    { new Guid("2056f277-04a5-4993-b42b-b95409861339"), new Guid("a784a261-3009-484a-9ca5-d141630c932f") },
                    { new Guid("2d2ee102-93ff-4bcd-9585-44935c1bebf5"), new Guid("109dd5e7-164c-4cec-b623-d28be70cc2c2") },
                    { new Guid("35d5e574-b5c6-476c-b64f-c6afff2f216f"), new Guid("24248a2a-d323-47fd-8be7-3b9e415d9a91") },
                    { new Guid("40642373-111c-477c-b9bc-2262b98bd46d"), new Guid("a784a261-3009-484a-9ca5-d141630c932f") },
                    { new Guid("42bad019-adf0-4cd9-945a-0fb4d544b560"), new Guid("a784a261-3009-484a-9ca5-d141630c932f") },
                    { new Guid("4a5ef299-cb93-414f-ab79-9a68a8fca29a"), new Guid("40f4b844-b0a4-4178-a5d9-c2ae70a8932b") },
                    { new Guid("6e71a59c-e1fe-4475-85a8-8ae7eadd0b1c"), new Guid("a784a261-3009-484a-9ca5-d141630c932f") },
                    { new Guid("7d89bc90-0d93-4ef4-bdab-10d246056524"), new Guid("40f4b844-b0a4-4178-a5d9-c2ae70a8932b") },
                    { new Guid("89cdf4ee-480d-4fdc-a241-2648bf12edca"), new Guid("24248a2a-d323-47fd-8be7-3b9e415d9a91") },
                    { new Guid("afcdd9d2-8eca-4b8d-8d3e-25b558fa20b0"), new Guid("a784a261-3009-484a-9ca5-d141630c932f") },
                    { new Guid("c92e4206-5682-4cba-8e74-6cc289adbaad"), new Guid("a784a261-3009-484a-9ca5-d141630c932f") },
                    { new Guid("d8d74e5f-2243-49bc-ad52-09dbbc241143"), new Guid("a784a261-3009-484a-9ca5-d141630c932f") },
                    { new Guid("daaebe41-85ce-40c2-b7dd-1d10c819ca58"), new Guid("a784a261-3009-484a-9ca5-d141630c932f") },
                    { new Guid("dd77d8e5-841d-497e-8d49-12add2937745"), new Guid("109dd5e7-164c-4cec-b623-d28be70cc2c2") },
                    { new Guid("dfb80e7b-1d9a-4db5-9b5f-6b0f5f147f44"), new Guid("a784a261-3009-484a-9ca5-d141630c932f") },
                    { new Guid("e2e07556-0189-41a2-ae8d-7cd046628a10"), new Guid("a784a261-3009-484a-9ca5-d141630c932f") },
                    { new Guid("e6eb03f6-3127-49f1-b04b-20b436a9de53"), new Guid("109dd5e7-164c-4cec-b623-d28be70cc2c2") },
                    { new Guid("f26e87b8-c04e-4952-9ec4-7f1dd7553dbf"), new Guid("109dd5e7-164c-4cec-b623-d28be70cc2c2") },
                    { new Guid("f3823bd4-ff2c-492b-b350-384eacdacc73"), new Guid("a784a261-3009-484a-9ca5-d141630c932f") }
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "Description", "Name", "ProfessorId" },
                values: new object[,]
                {
                    { new Guid("4bdf89fb-fe52-4d0c-b4af-e285e8d57fc6"), "Itaque quidem accusamus minus.", "Divination", new Guid("45326cf2-d2fd-436b-8467-3a42a7526ff4") },
                    { new Guid("54b4588f-9516-4184-8d9c-f749c6754d6a"), "Facere inventore ut.", "Charms", new Guid("e0bb8237-4c88-4260-8b97-37cc9d36dab4") },
                    { new Guid("6c47a25e-4dc0-440a-847b-c8387f6ef877"), "Voluptate sit ipsa.", "Divination", new Guid("570d8591-fa0a-4320-80fd-60e6923b88d4") },
                    { new Guid("7451bceb-6aa7-406f-9a55-870906df7eaa"), "Est error id aut a.", "Arithmancy", new Guid("bcca110f-4d47-4464-acf3-be4d19f9bbe7") },
                    { new Guid("750b7b2f-fcb3-4b2a-aa3e-c3820c918d8f"), "Ipsum tempore consectetur ut voluptas omnis molestias.", "Potions", new Guid("96022ed7-22c6-4ddc-b519-64418afd3b17") },
                    { new Guid("7c7bdae7-3295-4788-bc9a-c309864d0548"), "Atque et vel non est.", "Herbology", new Guid("d11bc147-af2f-4ffb-bec5-e23e78ecf69c") },
                    { new Guid("a2d2f532-f931-428a-b777-8ab00ef28234"), "Eos nobis dolores consequatur qui quia non voluptatem.", "Flying", new Guid("050cb727-0eed-49d8-85eb-d73fe591db8e") },
                    { new Guid("b9df4ade-39ae-424c-8271-133cf6bef19b"), "Nisi autem occaecati voluptates iste ea eius dolor.", "Charms", new Guid("a9df18cc-d325-4030-97af-1d89d0ebbe39") },
                    { new Guid("bb335af0-bb41-4f01-932f-c2b853a3b9b0"), "Ex voluptas nemo velit et voluptates ea quaerat dolorem.", "History of Magic", new Guid("bf078d20-2627-43f1-b030-4fc08ee12942") },
                    { new Guid("d9e159ed-a3b7-485d-9569-73a733eefa12"), "Illum alias nam quisquam eius pariatur vero quam commodi.", "Arithmancy", new Guid("b8c94937-5f78-4684-9b0c-1372acb80cef") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

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
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Characters_PictureId",
                table: "Characters",
                column: "PictureId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_ProfessorId",
                table: "Courses",
                column: "ProfessorId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StudentCourse_CourseId",
                table: "StudentCourse",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_HouseId",
                table: "Students",
                column: "HouseId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                name: "StudentCourse");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Professors");

            migrationBuilder.DropTable(
                name: "Houses");

            migrationBuilder.DropTable(
                name: "Characters");

            migrationBuilder.DropTable(
                name: "Pictures");
        }
    }
}
