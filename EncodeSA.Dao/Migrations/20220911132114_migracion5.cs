using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EncodeSA.Dao.Migrations
{
    public partial class migracion5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "NumeroDocumento",
                table: "Suscriptor",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "NumeroDocumento",
                table: "Suscriptor",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
