using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tiket_Penerbangan_n_Kereta.Migrations
{
    /// <inheritdoc />
    public partial class newTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Tujuan",
                table: "Pemesanan");

            migrationBuilder.AddColumn<int>(
                name: "PemesananIdPemesanan",
                table: "Rute",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Rute_PemesananIdPemesanan",
                table: "Rute",
                column: "PemesananIdPemesanan");

            migrationBuilder.AddForeignKey(
                name: "FK_Rute_Pemesanan_PemesananIdPemesanan",
                table: "Rute",
                column: "PemesananIdPemesanan",
                principalTable: "Pemesanan",
                principalColumn: "IdPemesanan");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rute_Pemesanan_PemesananIdPemesanan",
                table: "Rute");

            migrationBuilder.DropIndex(
                name: "IX_Rute_PemesananIdPemesanan",
                table: "Rute");

            migrationBuilder.DropColumn(
                name: "PemesananIdPemesanan",
                table: "Rute");

            migrationBuilder.AddColumn<string>(
                name: "Tujuan",
                table: "Pemesanan",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }
    }
}
