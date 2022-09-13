using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EncodeSA.Dao.Migrations
{
    public partial class migracion2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Suscriptores_Suscripciones_SuscripcionId",
                table: "Suscriptores");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Suscriptores",
                table: "Suscriptores");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Suscripciones",
                table: "Suscripciones");

            migrationBuilder.DropColumn(
                name: "TipoDocumento",
                table: "Suscriptores");

            migrationBuilder.RenameTable(
                name: "Suscriptores",
                newName: "Suscriptor");

            migrationBuilder.RenameTable(
                name: "Suscripciones",
                newName: "Suscripcion");

            migrationBuilder.RenameIndex(
                name: "IX_Suscriptores_SuscripcionId",
                table: "Suscriptor",
                newName: "IX_Suscriptor_SuscripcionId");

            migrationBuilder.AddColumn<int>(
                name: "TipoDocId",
                table: "Suscriptor",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Suscriptor",
                table: "Suscriptor",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Suscripcion",
                table: "Suscripcion",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Tipo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoDocumento = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tipo", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Suscriptor_TipoDocId",
                table: "Suscriptor",
                column: "TipoDocId");

            migrationBuilder.AddForeignKey(
                name: "FK_Suscriptor_Suscripcion_SuscripcionId",
                table: "Suscriptor",
                column: "SuscripcionId",
                principalTable: "Suscripcion",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Suscriptor_Tipo_TipoDocId",
                table: "Suscriptor",
                column: "TipoDocId",
                principalTable: "Tipo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Suscriptor_Suscripcion_SuscripcionId",
                table: "Suscriptor");

            migrationBuilder.DropForeignKey(
                name: "FK_Suscriptor_Tipo_TipoDocId",
                table: "Suscriptor");

            migrationBuilder.DropTable(
                name: "Tipo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Suscriptor",
                table: "Suscriptor");

            migrationBuilder.DropIndex(
                name: "IX_Suscriptor_TipoDocId",
                table: "Suscriptor");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Suscripcion",
                table: "Suscripcion");

            migrationBuilder.DropColumn(
                name: "TipoDocId",
                table: "Suscriptor");

            migrationBuilder.RenameTable(
                name: "Suscriptor",
                newName: "Suscriptores");

            migrationBuilder.RenameTable(
                name: "Suscripcion",
                newName: "Suscripciones");

            migrationBuilder.RenameIndex(
                name: "IX_Suscriptor_SuscripcionId",
                table: "Suscriptores",
                newName: "IX_Suscriptores_SuscripcionId");

            migrationBuilder.AddColumn<string>(
                name: "TipoDocumento",
                table: "Suscriptores",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Suscriptores",
                table: "Suscriptores",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Suscripciones",
                table: "Suscripciones",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Suscriptores_Suscripciones_SuscripcionId",
                table: "Suscriptores",
                column: "SuscripcionId",
                principalTable: "Suscripciones",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
