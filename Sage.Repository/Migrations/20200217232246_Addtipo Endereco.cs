using Microsoft.EntityFrameworkCore.Migrations;

namespace Sage.Repository.Migrations
{
    public partial class AddtipoEndereco : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TipoEndereco",
                table: "Enderecos",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TipoEndereco",
                table: "Enderecos");
        }
    }
}
