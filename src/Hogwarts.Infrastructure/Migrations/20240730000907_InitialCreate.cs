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
                    { new Guid("0d046f3c-132c-4600-83c4-dc8ab34032b1"), "Badger", "Earth", "Helga Hufflepuff", "Hufflepuff" },
                    { new Guid("7e8d6e4b-0aa5-4ffd-9707-41bc49c438dd"), "Lion", "Fire", "Godric Gryffindor", "Gryffindor" },
                    { new Guid("9b2a78b1-dd4a-4543-a9d0-f3063ae5a8a9"), "Eagle", "Air", "Rowena Ravenclaw", "Ravenclaw" },
                    { new Guid("ba18e1d7-82d6-4e6e-b17a-35e390ceec86"), "Serpent", "Water", "Salazar Slytherin", "Slytherin" }
                });

            migrationBuilder.InsertData(
                table: "Pictures",
                columns: new[] { "Id", "CharacterId", "Url" },
                values: new object[,]
                {
                    { new Guid("0163e086-1bb6-4cc9-baf5-8391a675acdf"), null, "https://picsum.photos/640/480/?image=972" },
                    { new Guid("078bb06e-d3af-4d6a-b7eb-524dab18dc5b"), null, "https://picsum.photos/640/480/?image=644" },
                    { new Guid("0de5fd33-50d8-4aec-a5da-15773aed5520"), null, "https://picsum.photos/640/480/?image=525" },
                    { new Guid("10857bf8-bb93-4baa-8d58-4af63904fa80"), null, "https://picsum.photos/640/480/?image=943" },
                    { new Guid("10f0c552-2db8-4df1-beac-cf01d32af47e"), null, "https://picsum.photos/640/480/?image=373" },
                    { new Guid("140ed3e5-b17a-45fe-bac9-7833930af2ea"), null, "https://picsum.photos/640/480/?image=570" },
                    { new Guid("1fa61d94-befb-4a05-aa4b-38e281b631ee"), null, "https://picsum.photos/640/480/?image=62" },
                    { new Guid("2a964815-59b1-49b8-b3ad-6dc59dd9acf8"), null, "https://picsum.photos/640/480/?image=573" },
                    { new Guid("382f477a-eea7-4992-9d70-6f95e6e882a1"), null, "https://picsum.photos/640/480/?image=629" },
                    { new Guid("398fd7c9-f366-4f5e-af23-7abbe3fafee4"), null, "https://picsum.photos/640/480/?image=338" },
                    { new Guid("3daa51e5-934b-477c-a063-86654a15880d"), null, "https://picsum.photos/640/480/?image=850" },
                    { new Guid("4b19ab10-36dd-4776-96db-ca100408764b"), null, "https://picsum.photos/640/480/?image=1037" },
                    { new Guid("64f8d0c1-86da-4efc-8fad-1d4f545daa35"), null, "https://picsum.photos/640/480/?image=475" },
                    { new Guid("683cc819-be69-43a7-b266-b599139cc1ca"), null, "https://picsum.photos/640/480/?image=88" },
                    { new Guid("68e76832-7e4b-45ff-8ec1-50e7c7d4215f"), null, "https://picsum.photos/640/480/?image=27" },
                    { new Guid("694366fc-f320-4cc8-9b40-d09b9c0ed507"), null, "https://picsum.photos/640/480/?image=372" },
                    { new Guid("6cca7071-6bd0-40fd-9d37-971341ff01d8"), null, "https://picsum.photos/640/480/?image=371" },
                    { new Guid("6fc67442-7ece-44b1-9013-28bd59fe28f6"), null, "https://picsum.photos/640/480/?image=991" },
                    { new Guid("84e8aa2e-fac5-4cf3-8086-2b2bd48a419c"), null, "https://picsum.photos/640/480/?image=593" },
                    { new Guid("864ead2b-694a-4e41-b479-b99b6fea46cf"), null, "https://picsum.photos/640/480/?image=200" },
                    { new Guid("91460151-76f4-4b1a-ab80-070a55323d73"), null, "https://picsum.photos/640/480/?image=256" },
                    { new Guid("97876e18-9e16-435c-981d-7e730633d205"), null, "https://picsum.photos/640/480/?image=662" },
                    { new Guid("97f64641-0e7b-4690-acc8-9b935b315e12"), null, "https://picsum.photos/640/480/?image=206" },
                    { new Guid("bbec7b32-c39f-4a6e-9cbb-149d43d8ee8e"), null, "https://picsum.photos/640/480/?image=445" },
                    { new Guid("cc9aa96e-5359-470f-92b8-f0bc01ddd4c1"), null, "https://picsum.photos/640/480/?image=87" },
                    { new Guid("d494ce78-8b59-4e99-80f4-0846539056b4"), null, "https://picsum.photos/640/480/?image=193" },
                    { new Guid("d8d3d1ac-6e91-45f4-85c5-82211b426733"), null, "https://picsum.photos/640/480/?image=736" },
                    { new Guid("dd759bde-0501-4a41-83f7-58212a099c72"), null, "https://picsum.photos/640/480/?image=423" },
                    { new Guid("e8b34fde-2816-4264-b1aa-947029515186"), null, "https://picsum.photos/640/480/?image=349" },
                    { new Guid("f8843611-6b34-47ba-a709-7dc5ddadb766"), null, "https://picsum.photos/640/480/?image=425" }
                });

            migrationBuilder.InsertData(
                table: "Subject",
                columns: new[] { "Id", "Description", "Name", "ProfessorId" },
                values: new object[,]
                {
                    { new Guid("2ca29bdd-5162-436a-b593-ec2e8e1a8b87"), "Vero magnam similique et aut debitis dolor dolore libero dolore.", "Arithmancy", null },
                    { new Guid("73869e37-b342-43a9-b5cd-01bd231ba809"), "Ab nihil reprehenderit ut id rerum aliquid iusto iure qui.", "Defense Against the Dark Arts", null },
                    { new Guid("76f6e76f-6fad-49ef-b1ba-5aa85e64d1a1"), "Eligendi voluptatum quas voluptatem consequatur illum et perferendis.", "Defense Against the Dark Arts", null },
                    { new Guid("9d32f6bb-584c-4c78-ab1b-1106e9723770"), "Possimus quibusdam consequatur veniam et illo.", "Flying", null },
                    { new Guid("a0a6ddf4-bc6c-4e7d-808c-6437ff2de44d"), "Non vel qui enim et vero sapiente et doloremque voluptatem.", "Astronomy", null },
                    { new Guid("ac2fcd53-6914-48cf-bd8d-8fb0ab714918"), "Eum aliquid soluta consequatur enim quisquam reiciendis.", "Divination", null },
                    { new Guid("d22da823-c93e-4320-be3d-e7bcc5896ac6"), "Eum excepturi fugit odit suscipit sint.", "Defense Against the Dark Arts", null },
                    { new Guid("d7d4fe9b-a7e5-486f-a905-457f48b5c4b3"), "Sunt officia ducimus doloremque temporibus.", "Potions", null },
                    { new Guid("efc43e2e-aae5-4167-afe7-684db0701dfd"), "Culpa amet magnam iusto aut.", "Flying", null },
                    { new Guid("f115bf2c-63c2-4266-aac2-0963099eefa0"), "Autem autem velit nesciunt.", "History of Magic", null }
                });

            migrationBuilder.InsertData(
                table: "Characters",
                columns: new[] { "Id", "Age", "BloodStatus", "DateOfBirth", "Description", "Discriminator", "FirstName", "LastName", "PictureId" },
                values: new object[,]
                {
                    { new Guid("04a1a23f-8671-47d9-a70b-848e27f0fe98"), 15, 0, new DateTime(2003, 10, 23, 3, 18, 49, 89, DateTimeKind.Utc).AddTicks(6916), "Similique soluta aut asperiores provident.", null, "Daniel", "Apodaca", new Guid("683cc819-be69-43a7-b266-b599139cc1ca") },
                    { new Guid("1086c854-f019-46d3-9afb-c2f563990f76"), 60, 0, new DateTime(1915, 9, 29, 1, 35, 5, 301, DateTimeKind.Utc).AddTicks(6139), "Est voluptas optio harum animi amet assumenda et.", null, "Elvira", "Razo", new Guid("0de5fd33-50d8-4aec-a5da-15773aed5520") },
                    { new Guid("11793a82-e532-4d72-acca-99279c890de7"), 44, 3, new DateTime(1938, 12, 4, 2, 18, 53, 927, DateTimeKind.Utc).AddTicks(9901), "Enim hic veniam.", null, "Beatriz", "Naranjo", new Guid("864ead2b-694a-4e41-b479-b99b6fea46cf") },
                    { new Guid("1346719a-a3d4-4e6a-9399-e97ee32325d7"), 13, 0, new DateTime(2001, 4, 9, 2, 20, 25, 115, DateTimeKind.Utc).AddTicks(7700), "Est facere harum qui necessitatibus dolor et cupiditate enim.", null, "Olivia", "Raya", new Guid("91460151-76f4-4b1a-ab80-070a55323d73") },
                    { new Guid("15b6abcd-1cb7-4b5f-a960-bd8cadbbf151"), 14, 3, new DateTime(2006, 1, 1, 2, 18, 19, 984, DateTimeKind.Utc).AddTicks(3876), "Incidunt commodi vero commodi aperiam modi qui.", null, "María Teresa", "Alicea", new Guid("382f477a-eea7-4992-9d70-6f95e6e882a1") },
                    { new Guid("176cd48e-a995-4351-a734-9d4e8df4f529"), 53, 3, new DateTime(1938, 11, 14, 16, 3, 22, 488, DateTimeKind.Utc).AddTicks(3476), "Repellendus praesentium similique excepturi velit sunt velit explicabo dolores.", null, "Eva", "Prieto", new Guid("bbec7b32-c39f-4a6e-9cbb-149d43d8ee8e") },
                    { new Guid("202b121c-512d-45c2-a3a9-0491e9c8e2d6"), 12, 0, new DateTime(2000, 12, 31, 15, 17, 24, 302, DateTimeKind.Utc).AddTicks(8242), "Omnis excepturi est et aliquid delectus sint eum atque.", null, "Gloria", "de Anda", new Guid("140ed3e5-b17a-45fe-bac9-7833930af2ea") },
                    { new Guid("2371887a-7d5b-40c0-8cb9-5113ea02edba"), 16, 2, new DateTime(2007, 11, 27, 22, 34, 27, 454, DateTimeKind.Utc).AddTicks(8823), "Corrupti mollitia dignissimos ad.", null, "Ramona", "Almonte", new Guid("398fd7c9-f366-4f5e-af23-7abbe3fafee4") },
                    { new Guid("37ab4aa0-2213-4c89-a025-7097cbad2cb2"), 13, 4, new DateTime(2002, 11, 4, 10, 22, 16, 466, DateTimeKind.Utc).AddTicks(461), "Dolor aspernatur consequuntur rerum laboriosam quas sed ut natus nobis.", null, "Gonzalo", "Granados", new Guid("bbec7b32-c39f-4a6e-9cbb-149d43d8ee8e") },
                    { new Guid("37b719c7-5fa1-4f17-bce7-b25d4d0efcae"), 14, 3, new DateTime(1997, 3, 23, 19, 38, 19, 582, DateTimeKind.Utc).AddTicks(1768), "Velit sequi dolores doloremque error odio voluptate.", null, "Sonia", "Alaníz", new Guid("3daa51e5-934b-477c-a063-86654a15880d") },
                    { new Guid("4158ebab-c272-4139-9e6f-52079e0e02ba"), 41, 3, new DateTime(1982, 7, 13, 16, 6, 59, 102, DateTimeKind.Utc).AddTicks(8349), "Dignissimos quisquam velit eligendi modi dicta sequi.", null, "Ana María", "Raya", new Guid("97876e18-9e16-435c-981d-7e730633d205") },
                    { new Guid("4ea09390-2361-4d43-91e4-c0b3630fb144"), 57, 4, new DateTime(1924, 1, 11, 3, 58, 34, 62, DateTimeKind.Utc).AddTicks(541), "Perferendis sint quia in nihil id.", null, "Laura", "Ferrer", new Guid("91460151-76f4-4b1a-ab80-070a55323d73") },
                    { new Guid("585c0152-1204-4258-a2d5-ddf114ddea21"), 14, 2, new DateTime(1999, 9, 17, 17, 18, 23, 74, DateTimeKind.Utc).AddTicks(6384), "Numquam eum deserunt.", null, "Alfonso", "Leyva", new Guid("64f8d0c1-86da-4efc-8fad-1d4f545daa35") },
                    { new Guid("5d61fc48-79d8-4f97-b957-a8ea31d926d7"), 13, 0, new DateTime(2007, 4, 11, 18, 29, 46, 510, DateTimeKind.Utc).AddTicks(5117), "Quo sint et eveniet fuga omnis nulla.", null, "Mariana", "Lugo", new Guid("0163e086-1bb6-4cc9-baf5-8391a675acdf") },
                    { new Guid("63eae216-e964-4fdd-9f1a-d0ad28fa4b03"), 65, 0, new DateTime(1906, 7, 8, 14, 2, 4, 985, DateTimeKind.Utc).AddTicks(1469), "Cupiditate id est sint eos est molestiae.", null, "Lorenzo", "Páez", new Guid("382f477a-eea7-4992-9d70-6f95e6e882a1") },
                    { new Guid("648b2598-956b-4b90-8df7-43a5657dfff1"), 14, 1, new DateTime(2001, 10, 14, 8, 2, 27, 469, DateTimeKind.Utc).AddTicks(3521), "At et aliquid.", null, "Jorge Luis", "Esparza", new Guid("1fa61d94-befb-4a05-aa4b-38e281b631ee") },
                    { new Guid("80c28916-037b-42c3-9764-51b03ffda119"), 64, 3, new DateTime(1898, 12, 23, 1, 12, 56, 206, DateTimeKind.Utc).AddTicks(230), "Dignissimos suscipit est explicabo.", null, "Conchita", "Tamez", new Guid("10857bf8-bb93-4baa-8d58-4af63904fa80") },
                    { new Guid("8ddd6da0-a0aa-4427-984a-cfeaa21dce87"), 13, 1, new DateTime(2002, 3, 27, 11, 52, 46, 228, DateTimeKind.Utc).AddTicks(4286), "Magnam libero ratione iusto.", null, "Jorge", "Guevara", new Guid("84e8aa2e-fac5-4cf3-8086-2b2bd48a419c") },
                    { new Guid("97430eed-52cf-4649-b7dc-f8cd660c4688"), 35, 3, new DateTime(1964, 1, 16, 22, 12, 48, 735, DateTimeKind.Utc).AddTicks(3262), "Et quae officia aliquid consectetur repudiandae nam quod quod.", null, "Sara", "Trujillo", new Guid("1fa61d94-befb-4a05-aa4b-38e281b631ee") },
                    { new Guid("9a8dcfd6-e2d5-44c6-998a-b507559be833"), 12, 2, new DateTime(2005, 1, 16, 6, 11, 55, 481, DateTimeKind.Utc).AddTicks(4618), "Reprehenderit veritatis deserunt cum.", null, "Barbara", "Torres", new Guid("10f0c552-2db8-4df1-beac-cf01d32af47e") },
                    { new Guid("a31691e7-548c-4025-8080-64f61e8e51db"), 49, 1, new DateTime(1949, 10, 13, 5, 17, 0, 442, DateTimeKind.Utc).AddTicks(663), "Officia quas ipsa nihil error nesciunt tempora.", null, "Lucía", "Banda", new Guid("078bb06e-d3af-4d6a-b7eb-524dab18dc5b") },
                    { new Guid("ac93d46a-f10b-4ba5-87f3-27720c169ee1"), 14, 1, new DateTime(1999, 3, 19, 2, 1, 0, 788, DateTimeKind.Utc).AddTicks(9534), "Repellendus eveniet sit iure totam nesciunt.", null, "Rosa", "Uribe", new Guid("4b19ab10-36dd-4776-96db-ca100408764b") },
                    { new Guid("bccbedd2-e0b6-463c-ac5c-f232aaf90883"), 16, 0, new DateTime(2005, 12, 18, 11, 14, 59, 13, DateTimeKind.Utc).AddTicks(1810), "Adipisci omnis aut et.", null, "Gabriel", "Valencia", new Guid("694366fc-f320-4cc8-9b40-d09b9c0ed507") },
                    { new Guid("bd7327d2-fe58-4abc-a28d-3eb7a03fe60b"), 13, 4, new DateTime(1999, 4, 12, 15, 59, 8, 675, DateTimeKind.Utc).AddTicks(3453), "Accusantium voluptatum pariatur ut soluta architecto.", null, "María Soledad", "Zarate", new Guid("cc9aa96e-5359-470f-92b8-f0bc01ddd4c1") },
                    { new Guid("c95d0700-0b33-4b9d-a8f1-fa3f6d1adadf"), 11, 0, new DateTime(2004, 5, 4, 19, 28, 10, 548, DateTimeKind.Utc).AddTicks(5134), "Enim eius non.", null, "Mariana", "Barajas", new Guid("d494ce78-8b59-4e99-80f4-0846539056b4") },
                    { new Guid("cdc117f6-8807-4014-9cd5-f25d5ffdb738"), 12, 1, new DateTime(2005, 1, 8, 13, 56, 50, 965, DateTimeKind.Utc).AddTicks(7444), "A quaerat quae autem doloremque et.", null, "Ana María", "Tamayo", new Guid("864ead2b-694a-4e41-b479-b99b6fea46cf") },
                    { new Guid("d7c13968-3e86-4fb9-85b9-e96e568af9da"), 15, 4, new DateTime(2008, 12, 2, 21, 10, 6, 891, DateTimeKind.Utc).AddTicks(2419), "Maiores voluptas id qui est.", null, "Eloisa", "Avilés", new Guid("e8b34fde-2816-4264-b1aa-947029515186") },
                    { new Guid("e2711673-9c97-417f-ae17-b81c6ac6b95f"), 45, 4, new DateTime(1945, 2, 21, 6, 8, 33, 519, DateTimeKind.Utc).AddTicks(2557), "Nihil numquam quos consequuntur itaque ullam est omnis.", null, "Micaela", "Montes", new Guid("dd759bde-0501-4a41-83f7-58212a099c72") },
                    { new Guid("ea979c96-912b-42a7-ba85-a844e3b71a0a"), 11, 2, new DateTime(2009, 2, 7, 10, 14, 46, 329, DateTimeKind.Utc).AddTicks(5760), "Voluptatibus sint in ipsum perspiciatis et quam autem quisquam.", null, "Emilio", "Concepción", new Guid("6fc67442-7ece-44b1-9013-28bd59fe28f6") },
                    { new Guid("fad54602-5fb5-40e5-8c21-d30b98861c30"), 14, 1, new DateTime(2006, 3, 5, 6, 46, 57, 169, DateTimeKind.Utc).AddTicks(1314), "Illo aperiam omnis quaerat delectus similique eius.", null, "Miguel Ángel", "Medina", new Guid("2a964815-59b1-49b8-b3ad-6dc59dd9acf8") }
                });

            migrationBuilder.InsertData(
                table: "Professors",
                columns: new[] { "Id", "SubjectId" },
                values: new object[,]
                {
                    { new Guid("1086c854-f019-46d3-9afb-c2f563990f76"), new Guid("efc43e2e-aae5-4167-afe7-684db0701dfd") },
                    { new Guid("11793a82-e532-4d72-acca-99279c890de7"), new Guid("9d32f6bb-584c-4c78-ab1b-1106e9723770") },
                    { new Guid("176cd48e-a995-4351-a734-9d4e8df4f529"), new Guid("ac2fcd53-6914-48cf-bd8d-8fb0ab714918") },
                    { new Guid("4158ebab-c272-4139-9e6f-52079e0e02ba"), new Guid("d7d4fe9b-a7e5-486f-a905-457f48b5c4b3") },
                    { new Guid("4ea09390-2361-4d43-91e4-c0b3630fb144"), new Guid("d22da823-c93e-4320-be3d-e7bcc5896ac6") },
                    { new Guid("63eae216-e964-4fdd-9f1a-d0ad28fa4b03"), new Guid("ac2fcd53-6914-48cf-bd8d-8fb0ab714918") },
                    { new Guid("80c28916-037b-42c3-9764-51b03ffda119"), new Guid("efc43e2e-aae5-4167-afe7-684db0701dfd") },
                    { new Guid("97430eed-52cf-4649-b7dc-f8cd660c4688"), new Guid("d22da823-c93e-4320-be3d-e7bcc5896ac6") },
                    { new Guid("a31691e7-548c-4025-8080-64f61e8e51db"), new Guid("76f6e76f-6fad-49ef-b1ba-5aa85e64d1a1") },
                    { new Guid("e2711673-9c97-417f-ae17-b81c6ac6b95f"), new Guid("2ca29bdd-5162-436a-b593-ec2e8e1a8b87") }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "HouseId" },
                values: new object[,]
                {
                    { new Guid("04a1a23f-8671-47d9-a70b-848e27f0fe98"), new Guid("ba18e1d7-82d6-4e6e-b17a-35e390ceec86") },
                    { new Guid("1346719a-a3d4-4e6a-9399-e97ee32325d7"), new Guid("7e8d6e4b-0aa5-4ffd-9707-41bc49c438dd") },
                    { new Guid("15b6abcd-1cb7-4b5f-a960-bd8cadbbf151"), new Guid("7e8d6e4b-0aa5-4ffd-9707-41bc49c438dd") },
                    { new Guid("202b121c-512d-45c2-a3a9-0491e9c8e2d6"), new Guid("7e8d6e4b-0aa5-4ffd-9707-41bc49c438dd") },
                    { new Guid("2371887a-7d5b-40c0-8cb9-5113ea02edba"), new Guid("9b2a78b1-dd4a-4543-a9d0-f3063ae5a8a9") },
                    { new Guid("37ab4aa0-2213-4c89-a025-7097cbad2cb2"), new Guid("ba18e1d7-82d6-4e6e-b17a-35e390ceec86") },
                    { new Guid("37b719c7-5fa1-4f17-bce7-b25d4d0efcae"), new Guid("9b2a78b1-dd4a-4543-a9d0-f3063ae5a8a9") },
                    { new Guid("585c0152-1204-4258-a2d5-ddf114ddea21"), new Guid("7e8d6e4b-0aa5-4ffd-9707-41bc49c438dd") },
                    { new Guid("5d61fc48-79d8-4f97-b957-a8ea31d926d7"), new Guid("9b2a78b1-dd4a-4543-a9d0-f3063ae5a8a9") },
                    { new Guid("648b2598-956b-4b90-8df7-43a5657dfff1"), new Guid("ba18e1d7-82d6-4e6e-b17a-35e390ceec86") },
                    { new Guid("8ddd6da0-a0aa-4427-984a-cfeaa21dce87"), new Guid("9b2a78b1-dd4a-4543-a9d0-f3063ae5a8a9") },
                    { new Guid("9a8dcfd6-e2d5-44c6-998a-b507559be833"), new Guid("9b2a78b1-dd4a-4543-a9d0-f3063ae5a8a9") },
                    { new Guid("ac93d46a-f10b-4ba5-87f3-27720c169ee1"), new Guid("9b2a78b1-dd4a-4543-a9d0-f3063ae5a8a9") },
                    { new Guid("bccbedd2-e0b6-463c-ac5c-f232aaf90883"), new Guid("9b2a78b1-dd4a-4543-a9d0-f3063ae5a8a9") },
                    { new Guid("bd7327d2-fe58-4abc-a28d-3eb7a03fe60b"), new Guid("9b2a78b1-dd4a-4543-a9d0-f3063ae5a8a9") },
                    { new Guid("c95d0700-0b33-4b9d-a8f1-fa3f6d1adadf"), new Guid("7e8d6e4b-0aa5-4ffd-9707-41bc49c438dd") },
                    { new Guid("cdc117f6-8807-4014-9cd5-f25d5ffdb738"), new Guid("7e8d6e4b-0aa5-4ffd-9707-41bc49c438dd") },
                    { new Guid("d7c13968-3e86-4fb9-85b9-e96e568af9da"), new Guid("0d046f3c-132c-4600-83c4-dc8ab34032b1") },
                    { new Guid("ea979c96-912b-42a7-ba85-a844e3b71a0a"), new Guid("9b2a78b1-dd4a-4543-a9d0-f3063ae5a8a9") },
                    { new Guid("fad54602-5fb5-40e5-8c21-d30b98861c30"), new Guid("9b2a78b1-dd4a-4543-a9d0-f3063ae5a8a9") }
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
