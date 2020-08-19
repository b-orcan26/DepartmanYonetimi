using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class initialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "departmans",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ad = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_departmans", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "personels",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ad = table.Column<string>(nullable: true),
                    soyad = table.Column<string>(nullable: true),
                    DepartmanID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_personels", x => x.id);
                    table.ForeignKey(
                        name: "FK_personels_departmans_DepartmanID",
                        column: x => x.DepartmanID,
                        principalTable: "departmans",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_personels_DepartmanID",
                table: "personels",
                column: "DepartmanID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "personels");

            migrationBuilder.DropTable(
                name: "departmans");
        }
    }
}
