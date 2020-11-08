using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BookApp2.Repository.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Catalogues",
                columns: table => new
                {
                    CatalogueId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Catalogues", x => x.CatalogueId);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: true),
                    Author = table.Column<string>(nullable: true),
                    Publisher = table.Column<string>(nullable: true),
                    Genre = table.Column<string>(nullable: true),
                    Price = table.Column<int>(nullable: false),
                    CatalogueId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Books_Catalogues_CatalogueId",
                        column: x => x.CatalogueId,
                        principalTable: "Catalogues",
                        principalColumn: "CatalogueId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Catalogues",
                columns: new[] { "CatalogueId", "Name" },
                values: new object[] { 1, "CSE" });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "CatalogueId", "Genre", "Price", "Publisher", "Title" },
                values: new object[] { 1, "Joe", 1, "Programmoig", 200, "Aprex", "C# Learing" });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "CatalogueId", "Genre", "Price", "Publisher", "Title" },
                values: new object[] { 2, "Alex", 1, "Database", 220, "Oracle Publication", "PL/SQL Learing" });

            migrationBuilder.CreateIndex(
                name: "IX_Books_CatalogueId",
                table: "Books",
                column: "CatalogueId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Catalogues");
        }
    }
}
