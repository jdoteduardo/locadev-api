using Microsoft.EntityFrameworkCore.Migrations;

namespace Locadora.Infra.Migrations
{
    public partial class UpdatePlaca2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Placa",
                table: "Carro",
                type: "VARCHAR(7)",
                fixedLength: true,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(8)",
                oldFixedLength: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Placa",
                table: "Carro",
                type: "VARCHAR(8)",
                fixedLength: true,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(7)",
                oldFixedLength: true);
        }
    }
}
