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
                    SubjectId = table.Column<Guid>(type: "uuid", nullable: true)
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
                name: "Subject",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    ProfessorId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subject", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Subject_Professors_ProfessorId",
                        column: x => x.ProfessorId,
                        principalTable: "Professors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "StudentSubject",
                columns: table => new
                {
                    StudentId = table.Column<Guid>(type: "uuid", nullable: false),
                    SubjectId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentSubject", x => new { x.StudentId, x.SubjectId });
                    table.ForeignKey(
                        name: "FK_StudentSubject_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentSubject_Subject_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "a3529bdd-913b-46e9-a204-c89bdc8640eb", null, "Admin", "ADMIN" },
                    { "b3dd4ff2-ac9f-4908-b889-16bf77c5facf", null, "Client", "CLIENT" }
                });

            migrationBuilder.InsertData(
                table: "Houses",
                columns: new[] { "Id", "Animal", "Element", "Founder", "Name" },
                values: new object[,]
                {
                    { new Guid("384c1d09-4117-4b8d-915c-156e0714957d"), "Eagle", "Air", "Rowena Ravenclaw", "Ravenclaw" },
                    { new Guid("7325de75-9112-4d2c-8280-74be7ee00bf1"), "Badger", "Earth", "Helga Hufflepuff", "Hufflepuff" },
                    { new Guid("97b63ba7-d78f-448f-b13f-72debe50bea9"), "Lion", "Fire", "Godric Gryffindor", "Gryffindor" },
                    { new Guid("b534bd09-0c6d-49b0-84c3-2c8150d4cc47"), "Serpent", "Water", "Salazar Slytherin", "Slytherin" }
                });

            migrationBuilder.InsertData(
                table: "Pictures",
                columns: new[] { "Id", "CharacterId", "Url" },
                values: new object[,]
                {
                    { new Guid("028b448a-acda-48e3-8c61-7f98cf13d419"), null, "https://picsum.photos/640/480/?image=1075" },
                    { new Guid("06d95a53-55e2-48f6-912e-68cbc3e65f0e"), null, "https://picsum.photos/640/480/?image=948" },
                    { new Guid("166effd7-f9c7-4ccd-a1a8-08ba0dc4ac95"), null, "https://picsum.photos/640/480/?image=17" },
                    { new Guid("25500d78-69eb-4667-8cbf-7e098df88618"), null, "https://picsum.photos/640/480/?image=189" },
                    { new Guid("2a3ee031-526c-4002-8b40-a78bf881e21f"), null, "https://picsum.photos/640/480/?image=765" },
                    { new Guid("2b62e0a8-02fa-41dc-bc19-91b9a05752c3"), null, "https://picsum.photos/640/480/?image=131" },
                    { new Guid("2d6d1f89-8790-4e05-9905-c05ad4925eb7"), null, "https://picsum.photos/640/480/?image=390" },
                    { new Guid("2e6c4960-6047-4fb7-8765-8f3a9b60f89c"), null, "https://picsum.photos/640/480/?image=782" },
                    { new Guid("3730235f-0b9a-4498-9596-443260c7fbd0"), null, "https://picsum.photos/640/480/?image=910" },
                    { new Guid("4543bd5a-b598-4f02-8ce8-bdcd65b07558"), null, "https://picsum.photos/640/480/?image=661" },
                    { new Guid("525d00fa-d561-4011-a7d1-d530e6dd5acb"), null, "https://picsum.photos/640/480/?image=734" },
                    { new Guid("55b6afa3-7e3f-41b1-9b36-0b7aa74f9ceb"), null, "https://picsum.photos/640/480/?image=45" },
                    { new Guid("5e4f57d8-891d-42cc-82d9-079870cbbfd8"), null, "https://picsum.photos/640/480/?image=858" },
                    { new Guid("5eb9d481-d716-4f33-a5d3-bea17aa48785"), null, "https://picsum.photos/640/480/?image=774" },
                    { new Guid("702c3c6c-6501-4680-b057-c5eabc1e4f8d"), null, "https://picsum.photos/640/480/?image=114" },
                    { new Guid("7b5a733f-672f-4626-a2f3-f1c7cdd7d75a"), null, "https://picsum.photos/640/480/?image=731" },
                    { new Guid("7f5f11b7-205f-408d-ab4f-24105e76a533"), null, "https://picsum.photos/640/480/?image=576" },
                    { new Guid("83141807-efce-4762-8688-7bc51978f36a"), null, "https://picsum.photos/640/480/?image=42" },
                    { new Guid("84b2e2a6-f1de-4c51-80b6-2590fbef90dc"), null, "https://picsum.photos/640/480/?image=963" },
                    { new Guid("89ce1eaa-e13b-4faa-98d8-e7d11b0a8cdd"), null, "https://picsum.photos/640/480/?image=965" },
                    { new Guid("8b27cd0b-89f4-4c8c-8f9f-5cc7b9de5ade"), null, "https://picsum.photos/640/480/?image=877" },
                    { new Guid("9737012f-27ad-4e90-9e22-a1d568f9462a"), null, "https://picsum.photos/640/480/?image=184" },
                    { new Guid("aa0d9359-3b47-48c9-952a-ca4828ece1d9"), null, "https://picsum.photos/640/480/?image=689" },
                    { new Guid("b07aba7f-5bd1-43c6-847b-53bc91629f22"), null, "https://picsum.photos/640/480/?image=64" },
                    { new Guid("b12650df-3f08-4b1e-8de4-962fe2ec3bb9"), null, "https://picsum.photos/640/480/?image=751" },
                    { new Guid("cbd23f44-53bd-4c9d-afc6-03299bf99d0a"), null, "https://picsum.photos/640/480/?image=755" },
                    { new Guid("d33f3270-c2b4-49e1-90a9-e1352cbf9f73"), null, "https://picsum.photos/640/480/?image=8" },
                    { new Guid("dfacad66-b3a7-4a56-b837-002e4b003999"), null, "https://picsum.photos/640/480/?image=668" },
                    { new Guid("e64b0984-01da-46a0-b8e8-fd7d0dd57ff8"), null, "https://picsum.photos/640/480/?image=648" },
                    { new Guid("e7455d47-a795-4d53-9060-cf9981bdbdf8"), null, "https://picsum.photos/640/480/?image=218" }
                });

            migrationBuilder.InsertData(
                table: "Subject",
                columns: new[] { "Id", "Description", "Name", "ProfessorId" },
                values: new object[,]
                {
                    { new Guid("07621e72-4041-4fc1-9b95-ab791cceb98a"), "Eligendi voluptates similique non est nisi cum.", "Charms", null },
                    { new Guid("08434c02-6507-4563-aae3-eea57027e8c9"), "Impedit quasi at exercitationem qui id et esse quia.", "Arithmancy", null },
                    { new Guid("3629fa29-3401-47c1-b073-b607de052325"), "Dolor molestias est fugit perspiciatis.", "Defense Against the Dark Arts", null },
                    { new Guid("3efc23ab-605b-4b3b-9991-43340654cfb8"), "Sint aut non.", "Defense Against the Dark Arts", null },
                    { new Guid("655003a3-9e65-46c5-8e94-29dea512929a"), "Est sunt consectetur repudiandae facere quas qui dolor.", "Herbology", null },
                    { new Guid("70d9043c-2d3f-4cde-823b-edbc57b31c3c"), "Qui expedita error eius quod quae laboriosam ut provident aliquid.", "Transfiguration", null },
                    { new Guid("7408a685-c6f2-414f-84ce-c76ae5495379"), "Sed consequatur nihil hic odit laudantium impedit qui officia.", "Charms", null },
                    { new Guid("bdda9344-b2fc-4700-b88c-13b2aebc2bb8"), "Expedita enim veritatis iure sapiente omnis quia sint.", "Charms", null },
                    { new Guid("bde6e9c4-bda0-4565-85b4-6f7742a5e1fc"), "Quam sit dignissimos et sed.", "Arithmancy", null },
                    { new Guid("c8e5f9b6-af49-4673-81e6-1d001116fcc2"), "Repudiandae voluptatem est et placeat vel unde dolorem voluptas.", "Divination", null }
                });

            migrationBuilder.InsertData(
                table: "AspNetRoleClaims",
                columns: new[] { "Id", "ClaimType", "ClaimValue", "RoleId" },
                values: new object[,]
                {
                    { 1, "POLICIES", "SUBJECT_CREATE", "a3529bdd-913b-46e9-a204-c89bdc8640eb" },
                    { 2, "POLICIES", "SUBJECT_READ", "a3529bdd-913b-46e9-a204-c89bdc8640eb" },
                    { 3, "POLICIES", "SUBJECT_UPDATE", "a3529bdd-913b-46e9-a204-c89bdc8640eb" },
                    { 4, "POLICIES", "SUBJECT_DELETE", "a3529bdd-913b-46e9-a204-c89bdc8640eb" },
                    { 5, "POLICIES", "PROFESSOR_READ", "a3529bdd-913b-46e9-a204-c89bdc8640eb" },
                    { 6, "POLICIES", "PROFESSOR_CREATE", "a3529bdd-913b-46e9-a204-c89bdc8640eb" },
                    { 7, "POLICIES", "PROFESSOR_UPDATE", "a3529bdd-913b-46e9-a204-c89bdc8640eb" },
                    { 8, "POLICIES", "PROFESSOR_DELETE", "a3529bdd-913b-46e9-a204-c89bdc8640eb" },
                    { 9, "POLICIES", "STUDENT_READ", "a3529bdd-913b-46e9-a204-c89bdc8640eb" },
                    { 10, "POLICIES", "STUDENT_CREATE", "a3529bdd-913b-46e9-a204-c89bdc8640eb" },
                    { 11, "POLICIES", "STUDENT_UPDATE", "a3529bdd-913b-46e9-a204-c89bdc8640eb" },
                    { 12, "POLICIES", "STUDENT_DELETE", "a3529bdd-913b-46e9-a204-c89bdc8640eb" },
                    { 13, "POLICIES", "SUBJECT_READ", "b3dd4ff2-ac9f-4908-b889-16bf77c5facf" },
                    { 14, "POLICIES", "PROFESSOR_READ", "b3dd4ff2-ac9f-4908-b889-16bf77c5facf" },
                    { 15, "POLICIES", "STUDENT_READ", "b3dd4ff2-ac9f-4908-b889-16bf77c5facf" }
                });

            migrationBuilder.InsertData(
                table: "Characters",
                columns: new[] { "Id", "Age", "BloodStatus", "DateOfBirth", "Description", "Discriminator", "FirstName", "LastName", "PictureId" },
                values: new object[,]
                {
                    { new Guid("0547a9e3-94c6-4f9c-a01a-2658421488b0"), 52, 4, new DateTime(1948, 2, 20, 1, 32, 38, 827, DateTimeKind.Utc).AddTicks(9755), "Consequuntur qui porro nesciunt eligendi dignissimos et ipsa nihil quia.", null, "Rocío", "Carvajal", new Guid("8b27cd0b-89f4-4c8c-8f9f-5cc7b9de5ade") },
                    { new Guid("0ea17444-ba33-4fc2-b42c-b50eb8492f20"), 16, 4, new DateTime(1999, 7, 17, 17, 7, 17, 195, DateTimeKind.Utc).AddTicks(6990), "Et est illum qui ullam quidem sit iure.", null, "Diego", "Zepeda", new Guid("166effd7-f9c7-4ccd-a1a8-08ba0dc4ac95") },
                    { new Guid("137afe9c-1a05-4802-afb4-8dbc1a5482d8"), 11, 2, new DateTime(2012, 3, 2, 23, 23, 11, 848, DateTimeKind.Utc).AddTicks(5683), "Voluptatum similique vel et consequatur nobis vero.", null, "Cristóbal", "Zúñiga", new Guid("89ce1eaa-e13b-4faa-98d8-e7d11b0a8cdd") },
                    { new Guid("1682f110-8b72-4b79-a5a4-6118a1640dd9"), 49, 0, new DateTime(1970, 4, 17, 18, 37, 26, 688, DateTimeKind.Utc).AddTicks(2457), "Ea consectetur ut sint aut corporis porro.", null, "Javier", "Vélez", new Guid("06d95a53-55e2-48f6-912e-68cbc3e65f0e") },
                    { new Guid("30f983b9-37a3-4e1d-86d8-844363df516f"), 16, 3, new DateTime(2003, 8, 21, 21, 36, 4, 799, DateTimeKind.Utc).AddTicks(9456), "Adipisci et fugiat cumque ipsum maiores consectetur beatae.", null, "Amalia", "Madera", new Guid("7f5f11b7-205f-408d-ab4f-24105e76a533") },
                    { new Guid("3e1f2045-eb30-46f3-9700-724b2a417b1b"), 12, 4, new DateTime(2010, 11, 10, 13, 26, 47, 529, DateTimeKind.Utc).AddTicks(8516), "Dolorem quidem possimus ducimus similique consequatur accusantium sequi sequi.", null, "Gregorio", "Durán", new Guid("9737012f-27ad-4e90-9e22-a1d568f9462a") },
                    { new Guid("61f67f12-258d-4a56-b70b-661ec3decef8"), 17, 4, new DateTime(1996, 3, 23, 18, 27, 13, 757, DateTimeKind.Utc).AddTicks(2251), "Tenetur nostrum quis.", null, "Octavio", "Pedroza", new Guid("e64b0984-01da-46a0-b8e8-fd7d0dd57ff8") },
                    { new Guid("631f644c-760d-4dc4-b388-606ed32686e9"), 17, 4, new DateTime(1997, 3, 24, 9, 7, 6, 943, DateTimeKind.Utc).AddTicks(5919), "Quaerat aliquam voluptates consequatur fugiat sed fuga.", null, "Enrique", "Gallegos", new Guid("cbd23f44-53bd-4c9d-afc6-03299bf99d0a") },
                    { new Guid("633e4120-21cb-4375-ba92-c831a16376d3"), 13, 4, new DateTime(2005, 8, 7, 19, 30, 27, 447, DateTimeKind.Utc).AddTicks(3153), "Cupiditate sint pariatur dolorem explicabo.", null, "Gustavo", "Heredia", new Guid("aa0d9359-3b47-48c9-952a-ca4828ece1d9") },
                    { new Guid("6421ee11-db05-433a-81ff-9a06781074f5"), 51, 1, new DateTime(1928, 7, 5, 18, 22, 20, 48, DateTimeKind.Utc).AddTicks(2524), "Ipsam repellat tempora eum perspiciatis expedita earum perspiciatis nam culpa.", null, "Inés", "Alcalá", new Guid("5e4f57d8-891d-42cc-82d9-079870cbbfd8") },
                    { new Guid("66e53835-8b70-4dda-af00-93734725332f"), 48, 2, new DateTime(1948, 6, 3, 22, 37, 9, 762, DateTimeKind.Utc).AddTicks(3963), "Impedit ipsum ut rerum fugit qui dicta nihil tenetur vero.", null, "Dorotea", "Griego", new Guid("4543bd5a-b598-4f02-8ce8-bdcd65b07558") },
                    { new Guid("780cf357-ff16-46e3-9775-7eaa9bb0c1bc"), 17, 2, new DateTime(1998, 11, 1, 6, 3, 42, 913, DateTimeKind.Utc).AddTicks(3224), "Aliquam molestiae aut officiis nulla tempore quasi labore odio est.", null, "Yolanda", "Badillo", new Guid("4543bd5a-b598-4f02-8ce8-bdcd65b07558") },
                    { new Guid("7d58bceb-37a7-4571-bc92-90c7e7167bd0"), 15, 0, new DateTime(1996, 5, 27, 20, 41, 59, 351, DateTimeKind.Utc).AddTicks(384), "Consequatur dolor sequi error.", null, "Alfonso", "Cuellar", new Guid("06d95a53-55e2-48f6-912e-68cbc3e65f0e") },
                    { new Guid("8b25cb1c-6f03-4b51-b529-b53aa713f69f"), 15, 2, new DateTime(2008, 8, 12, 21, 2, 24, 611, DateTimeKind.Utc).AddTicks(4454), "Sapiente tempore incidunt.", null, "Tomás", "Becerra", new Guid("028b448a-acda-48e3-8c61-7f98cf13d419") },
                    { new Guid("8df779df-d5d5-49fb-8b29-15ad33abf6e8"), 17, 1, new DateTime(1993, 6, 29, 7, 33, 6, 393, DateTimeKind.Utc).AddTicks(5200), "Qui quod error ut eum aut nesciunt illo et quibusdam.", null, "Lucas", "Escobedo", new Guid("55b6afa3-7e3f-41b1-9b36-0b7aa74f9ceb") },
                    { new Guid("953aaa20-84e3-4fde-aecb-ec09aa4c2740"), 45, 0, new DateTime(1950, 9, 18, 8, 15, 10, 298, DateTimeKind.Utc).AddTicks(1119), "Laborum qui laborum labore sint possimus harum aliquid dolorum nam.", null, "Sonia", "Alejandro", new Guid("5eb9d481-d716-4f33-a5d3-bea17aa48785") },
                    { new Guid("998db62e-059a-4a46-816f-1ce991b1820a"), 17, 2, new DateTime(2002, 10, 8, 2, 31, 18, 367, DateTimeKind.Utc).AddTicks(3097), "Nesciunt error possimus eum laborum laboriosam tenetur beatae sunt tempore.", null, "Arturo", "Heredia", new Guid("3730235f-0b9a-4498-9596-443260c7fbd0") },
                    { new Guid("9f73ca22-f479-4798-8261-2a7f2b6bce7f"), 13, 4, new DateTime(2003, 1, 7, 10, 40, 39, 684, DateTimeKind.Utc).AddTicks(8210), "Ut rerum commodi quo possimus illo consectetur fuga sunt.", null, "Graciela", "Atencio", new Guid("84b2e2a6-f1de-4c51-80b6-2590fbef90dc") },
                    { new Guid("9fbe7688-f448-4eff-a0c9-b1739ac615e8"), 40, 0, new DateTime(1980, 4, 2, 3, 47, 41, 594, DateTimeKind.Utc).AddTicks(3596), "Sint beatae est dicta unde.", null, "Luis", "Gurule", new Guid("166effd7-f9c7-4ccd-a1a8-08ba0dc4ac95") },
                    { new Guid("9ffb1598-0a33-47cb-a595-76eedef3223a"), 11, 4, new DateTime(2010, 5, 25, 19, 8, 43, 493, DateTimeKind.Utc).AddTicks(8499), "Pariatur quo rerum aliquid.", null, "María Teresa", "Pérez", new Guid("b07aba7f-5bd1-43c6-847b-53bc91629f22") },
                    { new Guid("a85eadd1-e30c-47d1-98ac-bc0878b23b02"), 16, 4, new DateTime(1993, 11, 6, 17, 38, 27, 680, DateTimeKind.Utc).AddTicks(7421), "Error dolore beatae nemo.", null, "María Elena", "Casares", new Guid("7b5a733f-672f-4626-a2f3-f1c7cdd7d75a") },
                    { new Guid("b5486669-8172-4f8f-8700-56e38d800937"), 55, 4, new DateTime(1965, 6, 11, 12, 11, 57, 186, DateTimeKind.Utc).AddTicks(5902), "Molestiae consequatur dignissimos totam maxime officia dolorem occaecati.", null, "Hugo", "Valle", new Guid("55b6afa3-7e3f-41b1-9b36-0b7aa74f9ceb") },
                    { new Guid("b82d66c8-d7b2-493c-9c37-4dd69b501ebc"), 16, 3, new DateTime(2002, 1, 14, 19, 22, 55, 302, DateTimeKind.Utc).AddTicks(2055), "Deserunt consequatur architecto possimus impedit asperiores ut qui qui.", null, "Andrea", "Terán", new Guid("702c3c6c-6501-4680-b057-c5eabc1e4f8d") },
                    { new Guid("bdc4ded5-2fe9-40e0-8455-cf9a179b60d0"), 25, 3, new DateTime(1998, 11, 19, 5, 43, 9, 959, DateTimeKind.Utc).AddTicks(832), "Illum et aut nemo.", null, "María Soledad", "Espinoza", new Guid("2e6c4960-6047-4fb7-8765-8f3a9b60f89c") },
                    { new Guid("ddc45d60-8af5-46cd-ac82-b4c731e2ed8c"), 13, 1, new DateTime(2006, 11, 2, 19, 50, 56, 873, DateTimeKind.Utc).AddTicks(7867), "Consequatur dolores ut perspiciatis sint in.", null, "Isabela", "Pedraza", new Guid("2e6c4960-6047-4fb7-8765-8f3a9b60f89c") },
                    { new Guid("e17d8b1b-2309-4202-bf8e-4f3c9204192e"), 12, 4, new DateTime(2008, 9, 4, 0, 57, 47, 201, DateTimeKind.Utc).AddTicks(612), "Et fuga debitis ut nihil.", null, "Gregorio", "Agosto", new Guid("25500d78-69eb-4667-8cbf-7e098df88618") },
                    { new Guid("eb68391c-9182-4e26-99bf-e73a2474730b"), 17, 4, new DateTime(1997, 3, 5, 8, 57, 44, 350, DateTimeKind.Utc).AddTicks(5832), "Eaque sed amet ad aut cumque qui eius delectus.", null, "Ramona", "Elizondo", new Guid("e7455d47-a795-4d53-9060-cf9981bdbdf8") },
                    { new Guid("f2342aed-f5f6-45bd-bd98-46e1facd32d0"), 65, 0, new DateTime(1957, 5, 18, 8, 33, 50, 537, DateTimeKind.Utc).AddTicks(9024), "Magnam est itaque repudiandae id et aut officia et.", null, "Fernando", "Pantoja", new Guid("b07aba7f-5bd1-43c6-847b-53bc91629f22") },
                    { new Guid("f64056b7-e6e7-4ed2-aa26-caf3c850bb6f"), 43, 4, new DateTime(1980, 1, 28, 17, 46, 50, 235, DateTimeKind.Utc).AddTicks(6802), "Quia aliquid veritatis error architecto voluptas aliquid.", null, "Miguel Ángel", "Carrillo", new Guid("2b62e0a8-02fa-41dc-bc19-91b9a05752c3") },
                    { new Guid("fcd07d50-5b21-43af-97eb-092f2cd351b5"), 15, 3, new DateTime(2004, 1, 20, 11, 55, 57, 193, DateTimeKind.Utc).AddTicks(7920), "Qui voluptas nihil modi quibusdam eius est alias incidunt neque.", null, "Lola", "Quiróz", new Guid("b12650df-3f08-4b1e-8de4-962fe2ec3bb9") }
                });

            migrationBuilder.InsertData(
                table: "Professors",
                columns: new[] { "Id", "SubjectId" },
                values: new object[,]
                {
                    { new Guid("0547a9e3-94c6-4f9c-a01a-2658421488b0"), new Guid("bdda9344-b2fc-4700-b88c-13b2aebc2bb8") },
                    { new Guid("1682f110-8b72-4b79-a5a4-6118a1640dd9"), new Guid("c8e5f9b6-af49-4673-81e6-1d001116fcc2") },
                    { new Guid("6421ee11-db05-433a-81ff-9a06781074f5"), new Guid("3efc23ab-605b-4b3b-9991-43340654cfb8") },
                    { new Guid("66e53835-8b70-4dda-af00-93734725332f"), new Guid("bde6e9c4-bda0-4565-85b4-6f7742a5e1fc") },
                    { new Guid("953aaa20-84e3-4fde-aecb-ec09aa4c2740"), new Guid("c8e5f9b6-af49-4673-81e6-1d001116fcc2") },
                    { new Guid("9fbe7688-f448-4eff-a0c9-b1739ac615e8"), new Guid("70d9043c-2d3f-4cde-823b-edbc57b31c3c") },
                    { new Guid("b5486669-8172-4f8f-8700-56e38d800937"), new Guid("c8e5f9b6-af49-4673-81e6-1d001116fcc2") },
                    { new Guid("bdc4ded5-2fe9-40e0-8455-cf9a179b60d0"), new Guid("08434c02-6507-4563-aae3-eea57027e8c9") },
                    { new Guid("f2342aed-f5f6-45bd-bd98-46e1facd32d0"), new Guid("3629fa29-3401-47c1-b073-b607de052325") },
                    { new Guid("f64056b7-e6e7-4ed2-aa26-caf3c850bb6f"), new Guid("07621e72-4041-4fc1-9b95-ab791cceb98a") }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "HouseId" },
                values: new object[,]
                {
                    { new Guid("0ea17444-ba33-4fc2-b42c-b50eb8492f20"), new Guid("b534bd09-0c6d-49b0-84c3-2c8150d4cc47") },
                    { new Guid("137afe9c-1a05-4802-afb4-8dbc1a5482d8"), new Guid("b534bd09-0c6d-49b0-84c3-2c8150d4cc47") },
                    { new Guid("30f983b9-37a3-4e1d-86d8-844363df516f"), new Guid("384c1d09-4117-4b8d-915c-156e0714957d") },
                    { new Guid("3e1f2045-eb30-46f3-9700-724b2a417b1b"), new Guid("384c1d09-4117-4b8d-915c-156e0714957d") },
                    { new Guid("61f67f12-258d-4a56-b70b-661ec3decef8"), new Guid("b534bd09-0c6d-49b0-84c3-2c8150d4cc47") },
                    { new Guid("631f644c-760d-4dc4-b388-606ed32686e9"), new Guid("7325de75-9112-4d2c-8280-74be7ee00bf1") },
                    { new Guid("633e4120-21cb-4375-ba92-c831a16376d3"), new Guid("b534bd09-0c6d-49b0-84c3-2c8150d4cc47") },
                    { new Guid("780cf357-ff16-46e3-9775-7eaa9bb0c1bc"), new Guid("384c1d09-4117-4b8d-915c-156e0714957d") },
                    { new Guid("7d58bceb-37a7-4571-bc92-90c7e7167bd0"), new Guid("7325de75-9112-4d2c-8280-74be7ee00bf1") },
                    { new Guid("8b25cb1c-6f03-4b51-b529-b53aa713f69f"), new Guid("384c1d09-4117-4b8d-915c-156e0714957d") },
                    { new Guid("8df779df-d5d5-49fb-8b29-15ad33abf6e8"), new Guid("97b63ba7-d78f-448f-b13f-72debe50bea9") },
                    { new Guid("998db62e-059a-4a46-816f-1ce991b1820a"), new Guid("7325de75-9112-4d2c-8280-74be7ee00bf1") },
                    { new Guid("9f73ca22-f479-4798-8261-2a7f2b6bce7f"), new Guid("b534bd09-0c6d-49b0-84c3-2c8150d4cc47") },
                    { new Guid("9ffb1598-0a33-47cb-a595-76eedef3223a"), new Guid("384c1d09-4117-4b8d-915c-156e0714957d") },
                    { new Guid("a85eadd1-e30c-47d1-98ac-bc0878b23b02"), new Guid("7325de75-9112-4d2c-8280-74be7ee00bf1") },
                    { new Guid("b82d66c8-d7b2-493c-9c37-4dd69b501ebc"), new Guid("97b63ba7-d78f-448f-b13f-72debe50bea9") },
                    { new Guid("ddc45d60-8af5-46cd-ac82-b4c731e2ed8c"), new Guid("384c1d09-4117-4b8d-915c-156e0714957d") },
                    { new Guid("e17d8b1b-2309-4202-bf8e-4f3c9204192e"), new Guid("7325de75-9112-4d2c-8280-74be7ee00bf1") },
                    { new Guid("eb68391c-9182-4e26-99bf-e73a2474730b"), new Guid("384c1d09-4117-4b8d-915c-156e0714957d") },
                    { new Guid("fcd07d50-5b21-43af-97eb-092f2cd351b5"), new Guid("7325de75-9112-4d2c-8280-74be7ee00bf1") }
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
                name: "IX_Students_HouseId",
                table: "Students",
                column: "HouseId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentSubject_SubjectId",
                table: "StudentSubject",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Subject_ProfessorId",
                table: "Subject",
                column: "ProfessorId",
                unique: true);
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
                name: "StudentSubject");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Subject");

            migrationBuilder.DropTable(
                name: "Houses");

            migrationBuilder.DropTable(
                name: "Professors");

            migrationBuilder.DropTable(
                name: "Characters");

            migrationBuilder.DropTable(
                name: "Pictures");
        }
    }
}
