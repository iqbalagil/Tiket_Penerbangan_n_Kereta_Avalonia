using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tiket_Penerbangan_n_Kereta.Migrations
{
    /// <inheritdoc />
    public partial class new4Table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<char>(
                name: "JenisKelamin",
                table: "Penumpang",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "JenisKelamin",
                table: "Penumpang",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(char),
                oldType: "TEXT");
        }
    }
}
