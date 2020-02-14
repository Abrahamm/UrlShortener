using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UrlShortener.Migrations
{
    public partial class UrlsDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(maxLength: 50, nullable: false),
                    LastName = table.Column<string>(maxLength: 50, nullable: false),
                    BirthDate = table.Column<DateTime>(type: "Date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Urls",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LongUrl = table.Column<string>(maxLength: 255, nullable: false),
                    ShortUrl = table.Column<string>(maxLength: 5, nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateExpires = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Urls", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Urls_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Taggeds",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UrlId = table.Column<int>(nullable: false),
                    TagId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Taggeds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Taggeds_Tags_TagId",
                        column: x => x.TagId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Taggeds_Urls_UrlId",
                        column: x => x.UrlId,
                        principalTable: "Urls",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Web Search" },
                    { 2, "Web Portal" },
                    { 3, "Tutorial" },
                    { 4, "EF Core" },
                    { 5, "DB Context" },
                    { 6, "LINQ" },
                    { 7, "C#" },
                    { 8, "News" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "BirthDate", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, new DateTime(1990, 2, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Luka", "Nuic" },
                    { 2, new DateTime(1980, 6, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "Davor", "Lozic" },
                    { 3, new DateTime(1986, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Antun", "Tun" }
                });

            migrationBuilder.InsertData(
                table: "Urls",
                columns: new[] { "Id", "DateCreated", "DateExpires", "LongUrl", "ShortUrl", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2020, 1, 12, 15, 32, 46, 0, DateTimeKind.Unspecified), new DateTime(2020, 2, 12, 15, 32, 46, 0, DateTimeKind.Unspecified), "https://www.google.com", "gogle", 1 },
                    { 2, new DateTime(2020, 1, 24, 12, 1, 7, 0, DateTimeKind.Unspecified), new DateTime(2020, 2, 24, 12, 1, 7, 0, DateTimeKind.Unspecified), "https://www.index.hr", "index", 1 },
                    { 3, new DateTime(2020, 1, 20, 13, 17, 21, 0, DateTimeKind.Unspecified), new DateTime(2020, 2, 20, 13, 17, 21, 0, DateTimeKind.Unspecified), "https://www.net.hr", "nethr", 2 },
                    { 4, new DateTime(2020, 1, 17, 1, 36, 59, 0, DateTimeKind.Unspecified), new DateTime(2020, 2, 17, 1, 36, 59, 0, DateTimeKind.Unspecified), "https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/linq/basic-linq-query-operations", "linqq", 2 },
                    { 5, new DateTime(2020, 1, 31, 23, 59, 59, 0, DateTimeKind.Unspecified), new DateTime(2020, 2, 29, 23, 59, 59, 0, DateTimeKind.Unspecified), "https://www.entityframeworktutorial.net/efcore/entity-framework-core-dbcontext.aspx", "dbctx", 3 }
                });

            migrationBuilder.InsertData(
                table: "Taggeds",
                columns: new[] { "Id", "TagId", "UrlId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 2 },
                    { 3, 8, 2 },
                    { 4, 2, 3 },
                    { 5, 8, 3 },
                    { 6, 3, 4 },
                    { 7, 6, 4 },
                    { 8, 7, 4 },
                    { 9, 3, 5 },
                    { 10, 4, 5 },
                    { 11, 5, 5 },
                    { 12, 7, 5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Taggeds_TagId",
                table: "Taggeds",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_Taggeds_UrlId",
                table: "Taggeds",
                column: "UrlId");

            migrationBuilder.CreateIndex(
                name: "IX_Urls_UserId",
                table: "Urls",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Taggeds");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "Urls");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
