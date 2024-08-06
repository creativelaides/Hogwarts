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
                    { "0849e8f0-5d5d-422f-8fe5-14ca51cce10b", null, "Client", "CLIENT" },
                    { "4f2e0863-e7ba-4ce8-b268-abb12148a718", null, "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "Houses",
                columns: new[] { "Id", "Animal", "Element", "Founder", "Name" },
                values: new object[,]
                {
                    { new Guid("02b1b2d3-9b14-4dd9-8c76-35ef470ce651"), "Eagle", "Air", "Rowena Ravenclaw", "Ravenclaw" },
                    { new Guid("2f30c323-0c50-41ca-bfd5-2525af1f1be9"), "Lion", "Fire", "Godric Gryffindor", "Gryffindor" },
                    { new Guid("803b7918-91a9-46f7-a5d9-5074f79ba946"), "Badger", "Earth", "Helga Hufflepuff", "Hufflepuff" },
                    { new Guid("bf902b43-faed-42ca-97b8-aa1c67acd8ca"), "Serpent", "Water", "Salazar Slytherin", "Slytherin" }
                });

            migrationBuilder.InsertData(
                table: "Pictures",
                columns: new[] { "Id", "CharacterId", "Url" },
                values: new object[,]
                {
                    { new Guid("01a52a03-4d4a-4db3-83ff-50b2aee22f9f"), new Guid("37d0e30d-f8e6-49d9-b8ee-eab54f552064"), "https://picsum.photos/640/480/?image=0" },
                    { new Guid("23cbf5d0-9e29-4046-a221-7fa6cc54fc32"), new Guid("5203e0e4-ec98-4d54-890d-0b3b6bc9090f"), "https://picsum.photos/640/480/?image=105" },
                    { new Guid("274f5101-03f6-45ea-9247-9ec159d5b660"), new Guid("27609a7c-4ce8-41b3-a252-5208dd3edf5a"), "https://picsum.photos/640/480/?image=226" },
                    { new Guid("2af32132-0740-4923-bb73-3c2296231d26"), new Guid("f0e36503-ca55-46d2-9899-444bda9da567"), "https://picsum.photos/640/480/?image=765" },
                    { new Guid("3022baec-cf7b-4e28-9ccf-83af7177cb49"), new Guid("7418e34e-cf82-4b61-8f06-bd87e809b732"), "https://picsum.photos/640/480/?image=590" },
                    { new Guid("30fd2ff0-ed86-448e-85a6-034fb3e388ef"), new Guid("cc7105aa-51f5-489a-be3e-279f95d3e518"), "https://picsum.photos/640/480/?image=649" },
                    { new Guid("31d9c3fd-05a6-4e86-ab75-4d4cfc564dda"), new Guid("27f6b61f-42ce-4b38-a983-75a6838d751c"), "https://picsum.photos/640/480/?image=947" },
                    { new Guid("33d84a92-eca5-4b3a-8000-63fb23f5d381"), new Guid("bc142fbd-7a29-4280-ab36-6e2e5a427c47"), "https://picsum.photos/640/480/?image=380" },
                    { new Guid("3fb8e9d0-a3fe-4881-9804-f1dcfb045f49"), new Guid("6eee5a2a-3d65-41f0-aadd-a58bdfb1c9a2"), "https://picsum.photos/640/480/?image=821" },
                    { new Guid("41435b4a-c060-43ec-bf77-232d7ceec2d3"), new Guid("60031c17-23da-40fd-b98f-88564796f289"), "https://picsum.photos/640/480/?image=214" },
                    { new Guid("43cb966a-9e47-4625-bee7-979b2ce91ead"), new Guid("4e913452-1f25-4d58-a79e-38778c1a7512"), "https://picsum.photos/640/480/?image=527" },
                    { new Guid("516a3c6c-55e1-4ffa-a67f-3c1573ff0079"), new Guid("cd7d42b6-4059-497f-9539-b0f5a083f8bf"), "https://picsum.photos/640/480/?image=191" },
                    { new Guid("5c52fa2f-817d-4d99-9ef0-d9e385a5f62c"), new Guid("41b03c4c-1bc5-4a39-86a7-4636030670b2"), "https://picsum.photos/640/480/?image=75" },
                    { new Guid("68cc589b-ca7c-4236-9bf6-40bd6bb7e5ca"), new Guid("f85e0f5b-e124-4f90-8a0f-6c7152152b14"), "https://picsum.photos/640/480/?image=990" },
                    { new Guid("768a7e4a-df7c-46c8-830e-459ff6b8e55a"), new Guid("bcbc4038-4a9f-4c20-8242-9f0f8a0933c0"), "https://picsum.photos/640/480/?image=173" },
                    { new Guid("7adb817c-d359-4c20-869e-d93d9d8e9dd2"), new Guid("950b9baa-05b2-4ebb-8394-adeae4552a30"), "https://picsum.photos/640/480/?image=989" },
                    { new Guid("8312bf62-ebd1-42e5-8398-ddbc76ed666e"), new Guid("0a0aa4a1-6748-404c-a046-947ea7864c43"), "https://picsum.photos/640/480/?image=704" },
                    { new Guid("84b38a4d-f3f7-4cbe-ac95-33f6f23a212c"), new Guid("bf9dbe8b-63d9-447c-9772-7ba915118e08"), "https://picsum.photos/640/480/?image=242" },
                    { new Guid("90f26602-3842-4bf6-b669-2f8221729add"), new Guid("13a78a3c-9472-4453-9b1f-d3c8879b57c9"), "https://picsum.photos/640/480/?image=1044" },
                    { new Guid("949868c0-d154-4932-b953-fe87367cfdf9"), new Guid("3431da91-11a1-4d44-8758-bf227a41453f"), "https://picsum.photos/640/480/?image=800" },
                    { new Guid("adde71af-a544-4bd4-a49a-94ea5d76ff00"), new Guid("93366cef-84f4-49a3-93a4-5ce413f0725b"), "https://picsum.photos/640/480/?image=915" },
                    { new Guid("b4ff8d82-e01f-4b1e-963e-6df648cd06a5"), new Guid("978a1a89-6ed7-4865-9622-ce6f295d9510"), "https://picsum.photos/640/480/?image=39" },
                    { new Guid("b6518dd1-0624-490c-9c17-311d4cc700a2"), new Guid("db030056-0ed6-4e3d-a7c3-46d586d61e15"), "https://picsum.photos/640/480/?image=1069" },
                    { new Guid("cbe5943e-c9b9-432e-a5dd-f61a71ddd3b2"), new Guid("75f724fc-8732-4e4b-89a5-456d852d7bc4"), "https://picsum.photos/640/480/?image=543" },
                    { new Guid("d350f495-7b2c-4a29-ad57-9574a7db51ea"), new Guid("8576eed3-5912-4b62-b2e7-b82673c93d0c"), "https://picsum.photos/640/480/?image=809" },
                    { new Guid("d44b0265-3715-4440-a697-a3079f5f3694"), new Guid("5c077fb3-5636-45ce-aacc-ef2d80234b49"), "https://picsum.photos/640/480/?image=616" },
                    { new Guid("d9175b5e-91af-451c-8fff-79d43741528e"), new Guid("6a2658cc-8085-4210-a8d8-dc980836e02b"), "https://picsum.photos/640/480/?image=566" },
                    { new Guid("d97d9548-c5c4-4bfc-936e-d1449d5629e8"), new Guid("0e34e2b7-dc7e-484a-9639-3b8f94716770"), "https://picsum.photos/640/480/?image=342" },
                    { new Guid("e0b78d72-e6d0-4a60-afe3-945ab9162f6c"), new Guid("703982ae-85cb-4c6f-ae1b-b0ce653a3524"), "https://picsum.photos/640/480/?image=892" },
                    { new Guid("f1120108-2c4d-48cd-af34-27b59bcb2a22"), new Guid("9d9afdd6-367a-4e96-b24e-5f2ee0539a3d"), "https://picsum.photos/640/480/?image=1007" }
                });

            migrationBuilder.InsertData(
                table: "AspNetRoleClaims",
                columns: new[] { "Id", "ClaimType", "ClaimValue", "RoleId" },
                values: new object[,]
                {
                    { 1, "POLICIES", "COURSE_CREATE", "4f2e0863-e7ba-4ce8-b268-abb12148a718" },
                    { 2, "POLICIES", "COURSE_READ", "4f2e0863-e7ba-4ce8-b268-abb12148a718" },
                    { 3, "POLICIES", "COURSE_UPDATE", "4f2e0863-e7ba-4ce8-b268-abb12148a718" },
                    { 4, "POLICIES", "COURSE_DELETE", "4f2e0863-e7ba-4ce8-b268-abb12148a718" },
                    { 5, "POLICIES", "PROFESSOR_READ", "4f2e0863-e7ba-4ce8-b268-abb12148a718" },
                    { 6, "POLICIES", "PROFESSOR_CREATE", "4f2e0863-e7ba-4ce8-b268-abb12148a718" },
                    { 7, "POLICIES", "PROFESSOR_UPDATE", "4f2e0863-e7ba-4ce8-b268-abb12148a718" },
                    { 8, "POLICIES", "PROFESSOR_DELETE", "4f2e0863-e7ba-4ce8-b268-abb12148a718" },
                    { 9, "POLICIES", "STUDENT_READ", "4f2e0863-e7ba-4ce8-b268-abb12148a718" },
                    { 10, "POLICIES", "STUDENT_CREATE", "4f2e0863-e7ba-4ce8-b268-abb12148a718" },
                    { 11, "POLICIES", "STUDENT_UPDATE", "4f2e0863-e7ba-4ce8-b268-abb12148a718" },
                    { 12, "POLICIES", "STUDENT_DELETE", "4f2e0863-e7ba-4ce8-b268-abb12148a718" },
                    { 13, "POLICIES", "COURSE_READ", "0849e8f0-5d5d-422f-8fe5-14ca51cce10b" },
                    { 14, "POLICIES", "PROFESSOR_READ", "0849e8f0-5d5d-422f-8fe5-14ca51cce10b" },
                    { 15, "POLICIES", "STUDENT_READ", "0849e8f0-5d5d-422f-8fe5-14ca51cce10b" }
                });

            migrationBuilder.InsertData(
                table: "Characters",
                columns: new[] { "Id", "Age", "BloodStatus", "DateOfBirth", "Description", "Discriminator", "FirstName", "LastName", "PictureId" },
                values: new object[,]
                {
                    { new Guid("0a0aa4a1-6748-404c-a046-947ea7864c43"), 11, 2, new DateTime(2010, 3, 3, 12, 9, 28, 462, DateTimeKind.Utc).AddTicks(3033), "Praesentium qui pariatur ut sunt a consequatur exercitationem ad quas.", null, "José Emilio", "Arteaga", new Guid("8312bf62-ebd1-42e5-8398-ddbc76ed666e") },
                    { new Guid("0e34e2b7-dc7e-484a-9639-3b8f94716770"), 17, 2, new DateTime(1995, 1, 31, 18, 6, 13, 92, DateTimeKind.Utc).AddTicks(1901), "Voluptatem rem dicta.", null, "Irene", "Tórrez", new Guid("d97d9548-c5c4-4bfc-936e-d1449d5629e8") },
                    { new Guid("13a78a3c-9472-4453-9b1f-d3c8879b57c9"), 45, 0, new DateTime(1959, 6, 11, 22, 43, 46, 698, DateTimeKind.Utc).AddTicks(2412), "Hic voluptas voluptatem animi in tempora consectetur beatae quisquam.", null, "Andrés", "Mateo", new Guid("90f26602-3842-4bf6-b669-2f8221729add") },
                    { new Guid("27609a7c-4ce8-41b3-a252-5208dd3edf5a"), 12, 4, new DateTime(2005, 3, 23, 20, 4, 2, 96, DateTimeKind.Utc).AddTicks(1524), "Earum libero corrupti maiores vel sapiente omnis harum.", null, "Natalia", "Díaz", new Guid("274f5101-03f6-45ea-9247-9ec159d5b660") },
                    { new Guid("27f6b61f-42ce-4b38-a983-75a6838d751c"), 15, 4, new DateTime(1994, 12, 23, 2, 42, 53, 923, DateTimeKind.Utc).AddTicks(8574), "Et sunt expedita ut esse dolor est quisquam laborum.", null, "Estela", "Robledo", new Guid("31d9c3fd-05a6-4e86-ab75-4d4cfc564dda") },
                    { new Guid("3431da91-11a1-4d44-8758-bf227a41453f"), 13, 0, new DateTime(2004, 1, 31, 9, 34, 23, 788, DateTimeKind.Utc).AddTicks(5344), "Voluptatem placeat necessitatibus est quis.", null, "Benjamín", "Barreto", new Guid("949868c0-d154-4932-b953-fe87367cfdf9") },
                    { new Guid("37d0e30d-f8e6-49d9-b8ee-eab54f552064"), 15, 2, new DateTime(1997, 11, 22, 13, 49, 23, 283, DateTimeKind.Utc).AddTicks(7826), "Inventore ipsum cumque ratione non et.", null, "Ariadna", "Oquendo", new Guid("01a52a03-4d4a-4db3-83ff-50b2aee22f9f") },
                    { new Guid("41b03c4c-1bc5-4a39-86a7-4636030670b2"), 17, 4, new DateTime(1998, 4, 21, 21, 6, 50, 799, DateTimeKind.Utc).AddTicks(4786), "Nam corporis est tenetur explicabo ullam nulla voluptatem consequuntur veritatis.", null, "Andrés", "Quiñónez", new Guid("5c52fa2f-817d-4d99-9ef0-d9e385a5f62c") },
                    { new Guid("4e913452-1f25-4d58-a79e-38778c1a7512"), 14, 2, new DateTime(2005, 6, 15, 20, 45, 38, 478, DateTimeKind.Utc).AddTicks(4678), "Quo architecto dolores quidem illo.", null, "Clemente", "Canales", new Guid("43cb966a-9e47-4625-bee7-979b2ce91ead") },
                    { new Guid("5203e0e4-ec98-4d54-890d-0b3b6bc9090f"), 31, 4, new DateTime(1981, 10, 22, 4, 17, 10, 876, DateTimeKind.Utc).AddTicks(6041), "In quaerat eos et ut laudantium.", null, "Carmen", "Laboy", new Guid("23cbf5d0-9e29-4046-a221-7fa6cc54fc32") },
                    { new Guid("5c077fb3-5636-45ce-aacc-ef2d80234b49"), 12, 2, new DateTime(2005, 9, 20, 7, 1, 6, 793, DateTimeKind.Utc).AddTicks(8178), "Possimus qui assumenda unde.", null, "Agustín", "Pacheco", new Guid("d44b0265-3715-4440-a697-a3079f5f3694") },
                    { new Guid("60031c17-23da-40fd-b98f-88564796f289"), 50, 2, new DateTime(1967, 11, 28, 22, 19, 19, 861, DateTimeKind.Utc).AddTicks(9420), "Consectetur enim at occaecati explicabo.", null, "José Luis", "Meraz", new Guid("41435b4a-c060-43ec-bf77-232d7ceec2d3") },
                    { new Guid("6a2658cc-8085-4210-a8d8-dc980836e02b"), 14, 0, new DateTime(2005, 8, 18, 15, 4, 7, 598, DateTimeKind.Utc).AddTicks(4371), "Nihil est ducimus harum qui neque.", null, "José Eduardo", "Barrera", new Guid("d9175b5e-91af-451c-8fff-79d43741528e") },
                    { new Guid("6eee5a2a-3d65-41f0-aadd-a58bdfb1c9a2"), 45, 1, new DateTime(1947, 11, 21, 21, 15, 31, 567, DateTimeKind.Utc).AddTicks(2783), "Fugit est in id voluptas voluptatem.", null, "Marisol", "Griego", new Guid("3fb8e9d0-a3fe-4881-9804-f1dcfb045f49") },
                    { new Guid("703982ae-85cb-4c6f-ae1b-b0ce653a3524"), 65, 1, new DateTime(1908, 4, 19, 4, 12, 5, 183, DateTimeKind.Utc).AddTicks(4649), "Eveniet ab dolor animi consequuntur temporibus consequatur est.", null, "Jorge", "Cintrón", new Guid("e0b78d72-e6d0-4a60-afe3-945ab9162f6c") },
                    { new Guid("7418e34e-cf82-4b61-8f06-bd87e809b732"), 17, 0, new DateTime(1990, 10, 10, 20, 36, 53, 871, DateTimeKind.Utc).AddTicks(4866), "Maiores error cumque magnam ut ut est eveniet quia et.", null, "Francisca", "Rentería", new Guid("3022baec-cf7b-4e28-9ccf-83af7177cb49") },
                    { new Guid("75f724fc-8732-4e4b-89a5-456d852d7bc4"), 43, 3, new DateTime(1976, 1, 23, 8, 41, 24, 411, DateTimeKind.Utc).AddTicks(6132), "Est autem dicta accusantium illo omnis provident.", null, "Ramiro", "Casillas", new Guid("cbe5943e-c9b9-432e-a5dd-f61a71ddd3b2") },
                    { new Guid("8576eed3-5912-4b62-b2e7-b82673c93d0c"), 36, 4, new DateTime(1965, 7, 29, 19, 44, 1, 810, DateTimeKind.Utc).AddTicks(5024), "Mollitia quis dolor pariatur.", null, "Alberto", "Zúñiga", new Guid("d350f495-7b2c-4a29-ad57-9574a7db51ea") },
                    { new Guid("93366cef-84f4-49a3-93a4-5ce413f0725b"), 15, 2, new DateTime(2005, 1, 25, 22, 16, 16, 469, DateTimeKind.Utc).AddTicks(2138), "Voluptatum qui voluptas expedita.", null, "César", "Badillo", new Guid("adde71af-a544-4bd4-a49a-94ea5d76ff00") },
                    { new Guid("950b9baa-05b2-4ebb-8394-adeae4552a30"), 12, 3, new DateTime(2005, 3, 12, 18, 14, 46, 329, DateTimeKind.Utc).AddTicks(3615), "Itaque laboriosam dolor officia sunt.", null, "Pablo", "Crespo", new Guid("7adb817c-d359-4c20-869e-d93d9d8e9dd2") },
                    { new Guid("978a1a89-6ed7-4865-9622-ce6f295d9510"), 15, 4, new DateTime(1994, 10, 15, 23, 10, 26, 932, DateTimeKind.Utc).AddTicks(3607), "Nihil sint cum repudiandae soluta mollitia velit non voluptatem.", null, "Mónica", "Soliz", new Guid("b4ff8d82-e01f-4b1e-963e-6df648cd06a5") },
                    { new Guid("9d9afdd6-367a-4e96-b24e-5f2ee0539a3d"), 13, 0, new DateTime(2010, 2, 10, 22, 50, 5, 486, DateTimeKind.Utc).AddTicks(5851), "Magnam et est corporis consequatur placeat.", null, "Leonor", "Vallejo", new Guid("f1120108-2c4d-48cd-af34-27b59bcb2a22") },
                    { new Guid("bc142fbd-7a29-4280-ab36-6e2e5a427c47"), 28, 2, new DateTime(1971, 12, 20, 5, 29, 0, 202, DateTimeKind.Utc).AddTicks(167), "Facere eos voluptas ipsum.", null, "Josefina", "Delafuente", new Guid("33d84a92-eca5-4b3a-8000-63fb23f5d381") },
                    { new Guid("bcbc4038-4a9f-4c20-8242-9f0f8a0933c0"), 17, 0, new DateTime(2004, 5, 9, 11, 59, 28, 366, DateTimeKind.Utc).AddTicks(7041), "Odio adipisci sint cumque sed illo porro ratione.", null, "Graciela", "Viera", new Guid("768a7e4a-df7c-46c8-830e-459ff6b8e55a") },
                    { new Guid("bf9dbe8b-63d9-447c-9772-7ba915118e08"), 14, 4, new DateTime(2008, 10, 4, 7, 42, 19, 501, DateTimeKind.Utc).AddTicks(3647), "Incidunt voluptatem voluptate.", null, "Pedro", "Dueñas", new Guid("84b38a4d-f3f7-4cbe-ac95-33f6f23a212c") },
                    { new Guid("cc7105aa-51f5-489a-be3e-279f95d3e518"), 11, 0, new DateTime(2010, 4, 21, 20, 32, 17, 709, DateTimeKind.Utc).AddTicks(2511), "Minima eveniet inventore nostrum est.", null, "Carlota", "Pedraza", new Guid("30fd2ff0-ed86-448e-85a6-034fb3e388ef") },
                    { new Guid("cd7d42b6-4059-497f-9539-b0f5a083f8bf"), 34, 0, new DateTime(1969, 11, 14, 7, 42, 28, 213, DateTimeKind.Utc).AddTicks(353), "Est officia quia voluptatem.", null, "Lorena", "Montaño", new Guid("516a3c6c-55e1-4ffa-a67f-3c1573ff0079") },
                    { new Guid("db030056-0ed6-4e3d-a7c3-46d586d61e15"), 40, 4, new DateTime(1972, 4, 10, 13, 36, 7, 469, DateTimeKind.Utc).AddTicks(8496), "Distinctio eveniet eveniet adipisci cumque doloribus.", null, "María Soledad", "Zúñiga", new Guid("b6518dd1-0624-490c-9c17-311d4cc700a2") },
                    { new Guid("f0e36503-ca55-46d2-9899-444bda9da567"), 14, 2, new DateTime(2010, 5, 11, 1, 42, 29, 340, DateTimeKind.Utc).AddTicks(4842), "Sunt sapiente et voluptatem nostrum.", null, "Ana Luisa", "Brito", new Guid("2af32132-0740-4923-bb73-3c2296231d26") },
                    { new Guid("f85e0f5b-e124-4f90-8a0f-6c7152152b14"), 17, 2, new DateTime(2005, 5, 3, 14, 0, 48, 94, DateTimeKind.Utc).AddTicks(4147), "Consequuntur eligendi delectus.", null, "Verónica", "Jurado", new Guid("68cc589b-ca7c-4236-9bf6-40bd6bb7e5ca") }
                });

            migrationBuilder.InsertData(
                table: "Professors",
                columns: new[] { "Id", "CourseId" },
                values: new object[,]
                {
                    { new Guid("13a78a3c-9472-4453-9b1f-d3c8879b57c9"), new Guid("e536896f-fe74-4b11-86d6-c1a191a16b11") },
                    { new Guid("5203e0e4-ec98-4d54-890d-0b3b6bc9090f"), new Guid("4a9beba4-d0e3-486c-8d60-6d372b1b0da9") },
                    { new Guid("60031c17-23da-40fd-b98f-88564796f289"), new Guid("fcf889c5-2c34-4ce7-92bc-d76afd69cfa8") },
                    { new Guid("6eee5a2a-3d65-41f0-aadd-a58bdfb1c9a2"), new Guid("6674d8f1-6bb2-467c-b865-4b3218400204") },
                    { new Guid("703982ae-85cb-4c6f-ae1b-b0ce653a3524"), new Guid("594b6ea2-8673-4907-af27-f4134e7d0286") },
                    { new Guid("75f724fc-8732-4e4b-89a5-456d852d7bc4"), new Guid("5de388f6-f352-4f25-a51a-a3ffa4b16652") },
                    { new Guid("8576eed3-5912-4b62-b2e7-b82673c93d0c"), new Guid("c7e8c92d-07ac-4b70-ac85-51893fa639b7") },
                    { new Guid("bc142fbd-7a29-4280-ab36-6e2e5a427c47"), new Guid("a3ce5b6c-1e86-4882-857e-2c5edca7165c") },
                    { new Guid("cd7d42b6-4059-497f-9539-b0f5a083f8bf"), new Guid("257f0993-7158-499a-a453-49ce2617757c") },
                    { new Guid("db030056-0ed6-4e3d-a7c3-46d586d61e15"), new Guid("505fbebc-3e0d-44ea-9be1-ebb7ed7c449a") }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "HouseId" },
                values: new object[,]
                {
                    { new Guid("0a0aa4a1-6748-404c-a046-947ea7864c43"), new Guid("bf902b43-faed-42ca-97b8-aa1c67acd8ca") },
                    { new Guid("0e34e2b7-dc7e-484a-9639-3b8f94716770"), new Guid("803b7918-91a9-46f7-a5d9-5074f79ba946") },
                    { new Guid("27609a7c-4ce8-41b3-a252-5208dd3edf5a"), new Guid("bf902b43-faed-42ca-97b8-aa1c67acd8ca") },
                    { new Guid("27f6b61f-42ce-4b38-a983-75a6838d751c"), new Guid("02b1b2d3-9b14-4dd9-8c76-35ef470ce651") },
                    { new Guid("3431da91-11a1-4d44-8758-bf227a41453f"), new Guid("803b7918-91a9-46f7-a5d9-5074f79ba946") },
                    { new Guid("37d0e30d-f8e6-49d9-b8ee-eab54f552064"), new Guid("803b7918-91a9-46f7-a5d9-5074f79ba946") },
                    { new Guid("41b03c4c-1bc5-4a39-86a7-4636030670b2"), new Guid("bf902b43-faed-42ca-97b8-aa1c67acd8ca") },
                    { new Guid("4e913452-1f25-4d58-a79e-38778c1a7512"), new Guid("02b1b2d3-9b14-4dd9-8c76-35ef470ce651") },
                    { new Guid("5c077fb3-5636-45ce-aacc-ef2d80234b49"), new Guid("803b7918-91a9-46f7-a5d9-5074f79ba946") },
                    { new Guid("6a2658cc-8085-4210-a8d8-dc980836e02b"), new Guid("803b7918-91a9-46f7-a5d9-5074f79ba946") },
                    { new Guid("7418e34e-cf82-4b61-8f06-bd87e809b732"), new Guid("2f30c323-0c50-41ca-bfd5-2525af1f1be9") },
                    { new Guid("93366cef-84f4-49a3-93a4-5ce413f0725b"), new Guid("02b1b2d3-9b14-4dd9-8c76-35ef470ce651") },
                    { new Guid("950b9baa-05b2-4ebb-8394-adeae4552a30"), new Guid("803b7918-91a9-46f7-a5d9-5074f79ba946") },
                    { new Guid("978a1a89-6ed7-4865-9622-ce6f295d9510"), new Guid("2f30c323-0c50-41ca-bfd5-2525af1f1be9") },
                    { new Guid("9d9afdd6-367a-4e96-b24e-5f2ee0539a3d"), new Guid("bf902b43-faed-42ca-97b8-aa1c67acd8ca") },
                    { new Guid("bcbc4038-4a9f-4c20-8242-9f0f8a0933c0"), new Guid("bf902b43-faed-42ca-97b8-aa1c67acd8ca") },
                    { new Guid("bf9dbe8b-63d9-447c-9772-7ba915118e08"), new Guid("803b7918-91a9-46f7-a5d9-5074f79ba946") },
                    { new Guid("cc7105aa-51f5-489a-be3e-279f95d3e518"), new Guid("bf902b43-faed-42ca-97b8-aa1c67acd8ca") },
                    { new Guid("f0e36503-ca55-46d2-9899-444bda9da567"), new Guid("2f30c323-0c50-41ca-bfd5-2525af1f1be9") },
                    { new Guid("f85e0f5b-e124-4f90-8a0f-6c7152152b14"), new Guid("2f30c323-0c50-41ca-bfd5-2525af1f1be9") }
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "Description", "Name", "ProfessorId" },
                values: new object[,]
                {
                    { new Guid("257f0993-7158-499a-a453-49ce2617757c"), "Eveniet qui amet consequatur dicta rerum dignissimos provident tempore.", "Transfiguration", new Guid("cd7d42b6-4059-497f-9539-b0f5a083f8bf") },
                    { new Guid("4a9beba4-d0e3-486c-8d60-6d372b1b0da9"), "Voluptatem ullam ipsa nemo accusamus at.", "Transfiguration", new Guid("5203e0e4-ec98-4d54-890d-0b3b6bc9090f") },
                    { new Guid("505fbebc-3e0d-44ea-9be1-ebb7ed7c449a"), "Qui cupiditate delectus et voluptatem deserunt nostrum cumque tenetur.", "Potions", new Guid("db030056-0ed6-4e3d-a7c3-46d586d61e15") },
                    { new Guid("594b6ea2-8673-4907-af27-f4134e7d0286"), "Eligendi est occaecati ut quasi veniam aliquid saepe quasi.", "Defense Against the Dark Arts", new Guid("703982ae-85cb-4c6f-ae1b-b0ce653a3524") },
                    { new Guid("5de388f6-f352-4f25-a51a-a3ffa4b16652"), "Voluptatem ut quis.", "Herbology", new Guid("75f724fc-8732-4e4b-89a5-456d852d7bc4") },
                    { new Guid("6674d8f1-6bb2-467c-b865-4b3218400204"), "Nulla quia unde.", "Arithmancy", new Guid("6eee5a2a-3d65-41f0-aadd-a58bdfb1c9a2") },
                    { new Guid("a3ce5b6c-1e86-4882-857e-2c5edca7165c"), "Beatae ut perspiciatis accusantium dignissimos omnis ducimus.", "Divination", new Guid("bc142fbd-7a29-4280-ab36-6e2e5a427c47") },
                    { new Guid("c7e8c92d-07ac-4b70-ac85-51893fa639b7"), "Explicabo aliquid dolores.", "Potions", new Guid("8576eed3-5912-4b62-b2e7-b82673c93d0c") },
                    { new Guid("e536896f-fe74-4b11-86d6-c1a191a16b11"), "In quam voluptatum iure rerum accusantium consequatur et.", "Transfiguration", new Guid("13a78a3c-9472-4453-9b1f-d3c8879b57c9") },
                    { new Guid("fcf889c5-2c34-4ce7-92bc-d76afd69cfa8"), "Exercitationem qui aut id voluptas molestias laudantium.", "Divination", new Guid("60031c17-23da-40fd-b98f-88564796f289") }
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
