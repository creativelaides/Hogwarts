using System;
using Microsoft.EntityFrameworkCore.Migrations;

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
                table: "Houses",
                columns: new[] { "Id", "Animal", "Element", "Founder", "Name" },
                values: new object[,]
                {
                    { new Guid("cc1ff1df-9e44-4152-9b76-af1785201569"), "Eagle", "Air", "Rowena Ravenclaw", "Ravenclaw" },
                    { new Guid("d2ad1b4a-c1ed-47f7-bfc2-feb2a6782bc7"), "Badger", "Earth", "Helga Hufflepuff", "Hufflepuff" },
                    { new Guid("d35cdb01-f1bb-401d-b661-0069aa16176c"), "Serpent", "Water", "Salazar Slytherin", "Slytherin" },
                    { new Guid("fdb80638-8219-42a3-8434-a4ed5a8e6290"), "Lion", "Fire", "Godric Gryffindor", "Gryffindor" }
                });

            migrationBuilder.InsertData(
                table: "Pictures",
                columns: new[] { "Id", "CharacterId", "Url" },
                values: new object[,]
                {
                    { new Guid("023950ff-1bb8-4635-b9ae-c37d5d587b92"), null, "https://picsum.photos/640/480/?image=135" },
                    { new Guid("094322d3-f0f0-4e3e-a729-be056e16eb3e"), null, "https://picsum.photos/640/480/?image=370" },
                    { new Guid("09ae35e2-b068-4830-b0f9-b573d79ff838"), null, "https://picsum.photos/640/480/?image=1043" },
                    { new Guid("0e302370-ac2b-4066-9afb-686db6adb627"), null, "https://picsum.photos/640/480/?image=436" },
                    { new Guid("142025cc-de46-4997-be6e-c78da6e725ee"), null, "https://picsum.photos/640/480/?image=523" },
                    { new Guid("1bdc080c-e2f3-47ab-a59a-52a78c36281e"), null, "https://picsum.photos/640/480/?image=360" },
                    { new Guid("1ed9fb1c-5cc9-4d9b-9809-c9292c8fa5e6"), null, "https://picsum.photos/640/480/?image=915" },
                    { new Guid("214239d4-dc2b-4133-929d-950fe5b91f8b"), null, "https://picsum.photos/640/480/?image=291" },
                    { new Guid("2695afa2-2209-4719-8c6b-b2653bac3843"), null, "https://picsum.photos/640/480/?image=906" },
                    { new Guid("28410601-64d6-4888-8a04-069804594cef"), null, "https://picsum.photos/640/480/?image=747" },
                    { new Guid("37c74758-ba49-458f-9d81-cf57a2173d2c"), null, "https://picsum.photos/640/480/?image=625" },
                    { new Guid("561b36f8-d4b3-4d6d-bc89-6c5a024f212d"), null, "https://picsum.photos/640/480/?image=639" },
                    { new Guid("7360ca89-fd9a-4881-b81f-4f92537d6639"), null, "https://picsum.photos/640/480/?image=228" },
                    { new Guid("75b43082-c11e-4b9a-96f4-88c19c5d1fcb"), null, "https://picsum.photos/640/480/?image=364" },
                    { new Guid("787afeea-6b77-433a-b624-bec108aee579"), null, "https://picsum.photos/640/480/?image=1068" },
                    { new Guid("7dddb336-2d40-421f-bd23-aeb4bd47b275"), null, "https://picsum.photos/640/480/?image=590" },
                    { new Guid("7e38c40b-e861-4a0f-b1ef-b22f905f5400"), null, "https://picsum.photos/640/480/?image=351" },
                    { new Guid("86704e16-9f4f-44bc-90d2-b40f30938c28"), null, "https://picsum.photos/640/480/?image=681" },
                    { new Guid("86cc7eb4-689d-4805-bf90-fad3a53278c9"), null, "https://picsum.photos/640/480/?image=1002" },
                    { new Guid("993e6cda-f6ed-4efd-94dd-88f2d60cd137"), null, "https://picsum.photos/640/480/?image=886" },
                    { new Guid("9aba3543-4227-4d0e-83a9-105d7e7857cb"), null, "https://picsum.photos/640/480/?image=381" },
                    { new Guid("a0ef4cda-ba5d-4b65-97f3-ccd118a751a4"), null, "https://picsum.photos/640/480/?image=844" },
                    { new Guid("a8015c92-03f4-4e23-88e7-3e672a460c5e"), null, "https://picsum.photos/640/480/?image=1068" },
                    { new Guid("abb49858-6f42-4ee0-9c7c-408e44090790"), null, "https://picsum.photos/640/480/?image=277" },
                    { new Guid("b4ae69a9-7fc1-447f-8189-2c8fc80b750d"), null, "https://picsum.photos/640/480/?image=277" },
                    { new Guid("d109ecc7-353e-412a-a6ec-adb58ffb3149"), null, "https://picsum.photos/640/480/?image=821" },
                    { new Guid("dcdc5019-5916-46a4-bd50-e501a09722f5"), null, "https://picsum.photos/640/480/?image=126" },
                    { new Guid("e20fe47d-2b62-4564-9fbf-ecc944843f1d"), null, "https://picsum.photos/640/480/?image=807" },
                    { new Guid("e634e74e-9e74-4f99-9a04-616f6a032ee3"), null, "https://picsum.photos/640/480/?image=484" },
                    { new Guid("f4baf971-e748-4a49-8723-0089f8bf8252"), null, "https://picsum.photos/640/480/?image=1083" }
                });

            migrationBuilder.InsertData(
                table: "Subject",
                columns: new[] { "Id", "Description", "Name", "ProfessorId" },
                values: new object[,]
                {
                    { new Guid("1cf04042-d970-4add-a6d2-c3bcb1b22455"), "Expedita dignissimos sed repudiandae architecto dolores.", "Potions", null },
                    { new Guid("4d9113d0-6fbd-4752-a906-d499154fdc8e"), "Nemo rerum omnis quia similique est facere.", "Arithmancy", null },
                    { new Guid("51ac0798-6578-4d07-a310-3f5922fb379f"), "Alias molestias exercitationem eos non.", "Transfiguration", null },
                    { new Guid("550536db-2a98-4fa4-890b-87e156f987b0"), "Deserunt blanditiis in illum adipisci.", "Arithmancy", null },
                    { new Guid("9ef30af7-bea9-4636-9f74-7f14d041fb65"), "Odio voluptas ipsam consequatur assumenda neque soluta voluptatem.", "Potions", null },
                    { new Guid("a2ea116f-337d-4fdf-8a8f-01adf62144ea"), "Voluptates officia perferendis dolores sint voluptatibus soluta et autem.", "Divination", null },
                    { new Guid("c7974e1d-bedd-4222-aa5f-7c2f41840f87"), "Perspiciatis reprehenderit impedit id.", "Charms", null },
                    { new Guid("e55bb2fc-0e48-4340-beba-c8f32421b4d2"), "Repudiandae vero voluptas rerum esse ex enim deleniti.", "Arithmancy", null },
                    { new Guid("ee1d1160-dafc-4999-a261-650430523835"), "Neque nemo itaque rerum eum labore.", "Divination", null },
                    { new Guid("f278179e-943a-4994-ac2f-e8d1d3ef66bd"), "Distinctio vel voluptas eos explicabo fugiat quas dolore.", "History of Magic", null }
                });

            migrationBuilder.InsertData(
                table: "Characters",
                columns: new[] { "Id", "Age", "BloodStatus", "DateOfBirth", "Description", "Discriminator", "FirstName", "LastName", "PictureId" },
                values: new object[,]
                {
                    { new Guid("0019faed-230e-4e8b-b822-9f05d12abf2c"), 17, 3, new DateTime(2001, 4, 17, 17, 6, 19, 825, DateTimeKind.Utc).AddTicks(9511), "Et dolores eaque harum consequuntur ratione inventore ullam qui.", null, "Rafael", "Montemayor", new Guid("1ed9fb1c-5cc9-4d9b-9809-c9292c8fa5e6") },
                    { new Guid("0399dc0d-f475-46f7-af7a-1b3fcf045b13"), 13, 3, new DateTime(2009, 2, 13, 3, 1, 15, 589, DateTimeKind.Utc).AddTicks(8833), "Modi commodi blanditiis.", null, "Rodrigo", "Vigil", new Guid("a0ef4cda-ba5d-4b65-97f3-ccd118a751a4") },
                    { new Guid("0566e3d2-1da5-41c5-a402-40310b072e70"), 51, 4, new DateTime(1942, 12, 7, 12, 56, 44, 55, DateTimeKind.Utc).AddTicks(1044), "Dolorem et a expedita est voluptatum ut.", null, "Magdalena", "Cortés", new Guid("7e38c40b-e861-4a0f-b1ef-b22f905f5400") },
                    { new Guid("21674414-ede2-4dc4-b2ff-33716f0c4dc4"), 14, 4, new DateTime(2004, 1, 20, 15, 50, 28, 24, DateTimeKind.Utc).AddTicks(435), "Cum nihil ducimus ab quia laborum.", null, "Lorenzo", "Pedraza", new Guid("f4baf971-e748-4a49-8723-0089f8bf8252") },
                    { new Guid("222cbc22-7e5a-486d-9a71-36593669f618"), 12, 1, new DateTime(2004, 9, 22, 21, 18, 1, 427, DateTimeKind.Utc).AddTicks(9554), "Quos amet eligendi commodi fugit recusandae dolores aut aut.", null, "Caridad", "Vázquez", new Guid("d109ecc7-353e-412a-a6ec-adb58ffb3149") },
                    { new Guid("25f5723d-a9e7-4954-bf4b-9e6f4100652b"), 38, 3, new DateTime(1956, 3, 20, 1, 27, 55, 158, DateTimeKind.Utc).AddTicks(4283), "Assumenda delectus accusamus occaecati dolorem modi inventore rerum et.", null, "Rocío", "Benítez", new Guid("561b36f8-d4b3-4d6d-bc89-6c5a024f212d") },
                    { new Guid("2d2cf8c7-9608-4b18-bd8e-78f50c33d09a"), 31, 0, new DateTime(1972, 3, 3, 15, 3, 12, 444, DateTimeKind.Utc).AddTicks(2021), "Non rem voluptas veniam nobis mollitia vitae.", null, "Carlota", "Fuentes", new Guid("86704e16-9f4f-44bc-90d2-b40f30938c28") },
                    { new Guid("3442d3f2-79b0-416c-85ff-c1bd2b32431f"), 13, 4, new DateTime(2002, 6, 22, 6, 57, 16, 13, DateTimeKind.Utc).AddTicks(433), "Voluptatibus aut culpa deleniti eum in.", null, "María del Carmen", "Galindo", new Guid("dcdc5019-5916-46a4-bd50-e501a09722f5") },
                    { new Guid("39c6dff2-edb7-41ea-999b-c58b9e28cd08"), 16, 2, new DateTime(2006, 12, 31, 8, 47, 23, 228, DateTimeKind.Utc).AddTicks(4274), "Veritatis tempora eum fugit omnis.", null, "Marcos", "Flórez", new Guid("abb49858-6f42-4ee0-9c7c-408e44090790") },
                    { new Guid("3c70970a-a90b-4e05-af09-65723274df16"), 41, 0, new DateTime(1949, 3, 7, 19, 43, 49, 828, DateTimeKind.Utc).AddTicks(8464), "Id odio qui et.", null, "Alejandro", "Ferrer", new Guid("214239d4-dc2b-4133-929d-950fe5b91f8b") },
                    { new Guid("3da14e16-b562-44a1-bcf2-d3167154293c"), 46, 3, new DateTime(1951, 4, 15, 13, 21, 51, 685, DateTimeKind.Utc).AddTicks(7159), "Aut et est temporibus iusto voluptas eaque quia.", null, "Pilar", "Casanova", new Guid("abb49858-6f42-4ee0-9c7c-408e44090790") },
                    { new Guid("48e84ce6-9e1e-45d9-8e0f-8ae4dddfd161"), 11, 3, new DateTime(2010, 1, 9, 3, 5, 34, 984, DateTimeKind.Utc).AddTicks(7465), "Enim sapiente sit.", null, "Jorge Luis", "Solís", new Guid("75b43082-c11e-4b9a-96f4-88c19c5d1fcb") },
                    { new Guid("59e33904-b1d9-421f-847b-fcd91a7928ee"), 12, 3, new DateTime(2010, 9, 30, 4, 58, 12, 961, DateTimeKind.Utc).AddTicks(8047), "Animi corporis fuga veritatis.", null, "César", "Naranjo", new Guid("86704e16-9f4f-44bc-90d2-b40f30938c28") },
                    { new Guid("5b46a625-445c-4b28-8c26-5d16001f82e6"), 12, 1, new DateTime(2005, 1, 1, 8, 1, 14, 202, DateTimeKind.Utc).AddTicks(9802), "Iure sit cupiditate eum sapiente.", null, "Mateo", "Urrutia", new Guid("28410601-64d6-4888-8a04-069804594cef") },
                    { new Guid("6fc8a086-8b8a-4650-aa7c-9090546e9a7b"), 13, 2, new DateTime(2002, 3, 8, 14, 9, 43, 875, DateTimeKind.Utc).AddTicks(3564), "Ut odit quam ducimus iste adipisci culpa.", null, "Jerónimo", "Guzmán", new Guid("214239d4-dc2b-4133-929d-950fe5b91f8b") },
                    { new Guid("7798cb8b-b94a-46e2-9d43-fa158e7db8a4"), 13, 3, new DateTime(2000, 1, 1, 9, 29, 49, 475, DateTimeKind.Utc).AddTicks(9362), "Ipsam consequatur explicabo pariatur perspiciatis.", null, "Carlota", "Tejada", new Guid("86cc7eb4-689d-4805-bf90-fad3a53278c9") },
                    { new Guid("79260a12-a269-4b6c-9d14-5ac6eb6896e8"), 13, 3, new DateTime(1998, 8, 24, 11, 14, 47, 45, DateTimeKind.Utc).AddTicks(6371), "Et ullam quibusdam deleniti maiores dolorem.", null, "Marisol", "Ruelas", new Guid("094322d3-f0f0-4e3e-a729-be056e16eb3e") },
                    { new Guid("854d1fd6-ac3d-42e7-a4c5-17f5c14a94de"), 14, 0, new DateTime(2000, 9, 25, 23, 27, 53, 707, DateTimeKind.Utc).AddTicks(3014), "Quis cupiditate aliquid.", null, "María Elena", "Lebrón", new Guid("2695afa2-2209-4719-8c6b-b2653bac3843") },
                    { new Guid("916e4d8a-08e4-4f5a-8e70-8436aff32b3a"), 17, 3, new DateTime(1995, 2, 15, 23, 8, 18, 854, DateTimeKind.Utc).AddTicks(8922), "Voluptas laboriosam et nulla sed voluptatem nisi.", null, "Alicia", "Cruz", new Guid("142025cc-de46-4997-be6e-c78da6e725ee") },
                    { new Guid("92af5af1-5429-4c7d-ad4d-13dd1f51205e"), 13, 4, new DateTime(2000, 12, 26, 3, 19, 59, 423, DateTimeKind.Utc).AddTicks(4108), "Voluptatem ipsam itaque iste nulla ullam nostrum natus.", null, "Federico", "Almonte", new Guid("09ae35e2-b068-4830-b0f9-b573d79ff838") },
                    { new Guid("b623df1b-ba1a-4166-9c35-b59c4f735f0b"), 12, 1, new DateTime(2007, 4, 6, 6, 30, 43, 866, DateTimeKind.Utc).AddTicks(5136), "Magni et nisi sed in.", null, "Vicente", "Ávila", new Guid("787afeea-6b77-433a-b624-bec108aee579") },
                    { new Guid("b6f6f473-4908-4bc5-987a-4ddea366ff65"), 15, 3, new DateTime(2008, 1, 20, 22, 55, 53, 826, DateTimeKind.Utc).AddTicks(2044), "Et et quo et ut eum quod dolorem magni nesciunt.", null, "Emilia", "López", new Guid("7360ca89-fd9a-4881-b81f-4f92537d6639") },
                    { new Guid("ba315104-b3cf-4b1a-b0cf-a5581db39d86"), 16, 0, new DateTime(2006, 5, 20, 10, 48, 44, 486, DateTimeKind.Utc).AddTicks(9251), "Est molestias optio.", null, "Ana María", "Ceja", new Guid("b4ae69a9-7fc1-447f-8189-2c8fc80b750d") },
                    { new Guid("bcd93706-d26c-41ea-8761-8aebbb46cc55"), 63, 0, new DateTime(1946, 10, 14, 15, 14, 25, 676, DateTimeKind.Utc).AddTicks(3771), "Adipisci velit odit aliquid ab consequatur.", null, "Rebeca", "Carreón", new Guid("142025cc-de46-4997-be6e-c78da6e725ee") },
                    { new Guid("c6cfd637-ac07-40f0-ba9b-5ad29a81911b"), 58, 4, new DateTime(1927, 9, 16, 23, 31, 27, 85, DateTimeKind.Utc).AddTicks(3571), "Sint eos ea.", null, "Antonia", "Arriaga", new Guid("7360ca89-fd9a-4881-b81f-4f92537d6639") },
                    { new Guid("dcf8e90d-3630-4ec1-b7eb-f113fe74b043"), 51, 4, new DateTime(1935, 3, 5, 10, 5, 21, 56, DateTimeKind.Utc).AddTicks(2072), "Architecto adipisci beatae.", null, "Marcos", "Argüello", new Guid("09ae35e2-b068-4830-b0f9-b573d79ff838") },
                    { new Guid("e97eb981-df08-428e-8985-443ce96dfb8d"), 33, 0, new DateTime(1976, 7, 16, 13, 54, 7, 925, DateTimeKind.Utc).AddTicks(3779), "Quo voluptatem soluta eligendi dolor tenetur modi.", null, "Samuel", "Ybarra", new Guid("787afeea-6b77-433a-b624-bec108aee579") },
                    { new Guid("ec417b3f-5048-44b4-8ebd-1165d90f5ad7"), 12, 3, new DateTime(2005, 1, 14, 16, 2, 51, 66, DateTimeKind.Utc).AddTicks(7611), "Cum et tempore consectetur ipsum alias quaerat.", null, "Barbara", "Rosado", new Guid("0e302370-ac2b-4066-9afb-686db6adb627") },
                    { new Guid("f1a30b59-bcc6-41c1-9d64-8e42be42f8f6"), 15, 0, new DateTime(2007, 7, 27, 5, 24, 19, 160, DateTimeKind.Utc).AddTicks(4206), "Et et maxime unde qui debitis aut voluptas.", null, "Nicolás", "Malave", new Guid("e20fe47d-2b62-4564-9fbf-ecc944843f1d") },
                    { new Guid("f31ce936-9e9e-4b60-b77d-0619dfff1cb2"), 27, 4, new DateTime(1972, 7, 18, 6, 44, 8, 397, DateTimeKind.Utc).AddTicks(6026), "Minima debitis perferendis et exercitationem maxime illo.", null, "Hernán", "Casarez", new Guid("28410601-64d6-4888-8a04-069804594cef") }
                });

            migrationBuilder.InsertData(
                table: "Professors",
                columns: new[] { "Id", "SubjectId" },
                values: new object[,]
                {
                    { new Guid("0566e3d2-1da5-41c5-a402-40310b072e70"), new Guid("9ef30af7-bea9-4636-9f74-7f14d041fb65") },
                    { new Guid("25f5723d-a9e7-4954-bf4b-9e6f4100652b"), new Guid("9ef30af7-bea9-4636-9f74-7f14d041fb65") },
                    { new Guid("2d2cf8c7-9608-4b18-bd8e-78f50c33d09a"), new Guid("c7974e1d-bedd-4222-aa5f-7c2f41840f87") },
                    { new Guid("3c70970a-a90b-4e05-af09-65723274df16"), new Guid("4d9113d0-6fbd-4752-a906-d499154fdc8e") },
                    { new Guid("3da14e16-b562-44a1-bcf2-d3167154293c"), new Guid("4d9113d0-6fbd-4752-a906-d499154fdc8e") },
                    { new Guid("bcd93706-d26c-41ea-8761-8aebbb46cc55"), new Guid("f278179e-943a-4994-ac2f-e8d1d3ef66bd") },
                    { new Guid("c6cfd637-ac07-40f0-ba9b-5ad29a81911b"), new Guid("1cf04042-d970-4add-a6d2-c3bcb1b22455") },
                    { new Guid("dcf8e90d-3630-4ec1-b7eb-f113fe74b043"), new Guid("1cf04042-d970-4add-a6d2-c3bcb1b22455") },
                    { new Guid("e97eb981-df08-428e-8985-443ce96dfb8d"), new Guid("9ef30af7-bea9-4636-9f74-7f14d041fb65") },
                    { new Guid("f31ce936-9e9e-4b60-b77d-0619dfff1cb2"), new Guid("c7974e1d-bedd-4222-aa5f-7c2f41840f87") }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "HouseId" },
                values: new object[,]
                {
                    { new Guid("0019faed-230e-4e8b-b822-9f05d12abf2c"), new Guid("d2ad1b4a-c1ed-47f7-bfc2-feb2a6782bc7") },
                    { new Guid("0399dc0d-f475-46f7-af7a-1b3fcf045b13"), new Guid("cc1ff1df-9e44-4152-9b76-af1785201569") },
                    { new Guid("21674414-ede2-4dc4-b2ff-33716f0c4dc4"), new Guid("cc1ff1df-9e44-4152-9b76-af1785201569") },
                    { new Guid("222cbc22-7e5a-486d-9a71-36593669f618"), new Guid("fdb80638-8219-42a3-8434-a4ed5a8e6290") },
                    { new Guid("3442d3f2-79b0-416c-85ff-c1bd2b32431f"), new Guid("fdb80638-8219-42a3-8434-a4ed5a8e6290") },
                    { new Guid("39c6dff2-edb7-41ea-999b-c58b9e28cd08"), new Guid("cc1ff1df-9e44-4152-9b76-af1785201569") },
                    { new Guid("48e84ce6-9e1e-45d9-8e0f-8ae4dddfd161"), new Guid("d2ad1b4a-c1ed-47f7-bfc2-feb2a6782bc7") },
                    { new Guid("59e33904-b1d9-421f-847b-fcd91a7928ee"), new Guid("d2ad1b4a-c1ed-47f7-bfc2-feb2a6782bc7") },
                    { new Guid("5b46a625-445c-4b28-8c26-5d16001f82e6"), new Guid("d35cdb01-f1bb-401d-b661-0069aa16176c") },
                    { new Guid("6fc8a086-8b8a-4650-aa7c-9090546e9a7b"), new Guid("fdb80638-8219-42a3-8434-a4ed5a8e6290") },
                    { new Guid("7798cb8b-b94a-46e2-9d43-fa158e7db8a4"), new Guid("fdb80638-8219-42a3-8434-a4ed5a8e6290") },
                    { new Guid("79260a12-a269-4b6c-9d14-5ac6eb6896e8"), new Guid("d2ad1b4a-c1ed-47f7-bfc2-feb2a6782bc7") },
                    { new Guid("854d1fd6-ac3d-42e7-a4c5-17f5c14a94de"), new Guid("d2ad1b4a-c1ed-47f7-bfc2-feb2a6782bc7") },
                    { new Guid("916e4d8a-08e4-4f5a-8e70-8436aff32b3a"), new Guid("fdb80638-8219-42a3-8434-a4ed5a8e6290") },
                    { new Guid("92af5af1-5429-4c7d-ad4d-13dd1f51205e"), new Guid("fdb80638-8219-42a3-8434-a4ed5a8e6290") },
                    { new Guid("b623df1b-ba1a-4166-9c35-b59c4f735f0b"), new Guid("d2ad1b4a-c1ed-47f7-bfc2-feb2a6782bc7") },
                    { new Guid("b6f6f473-4908-4bc5-987a-4ddea366ff65"), new Guid("cc1ff1df-9e44-4152-9b76-af1785201569") },
                    { new Guid("ba315104-b3cf-4b1a-b0cf-a5581db39d86"), new Guid("d2ad1b4a-c1ed-47f7-bfc2-feb2a6782bc7") },
                    { new Guid("ec417b3f-5048-44b4-8ebd-1165d90f5ad7"), new Guid("d2ad1b4a-c1ed-47f7-bfc2-feb2a6782bc7") },
                    { new Guid("f1a30b59-bcc6-41c1-9d64-8e42be42f8f6"), new Guid("cc1ff1df-9e44-4152-9b76-af1785201569") }
                });

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
                name: "StudentSubject");

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
