using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EncodeSA.Dao.Migrations
{
    public partial class migracion4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Suscriptor",
                newName: "s_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "s_Id",
                table: "Suscriptor",
                newName: "Id");
        }
    }
}
