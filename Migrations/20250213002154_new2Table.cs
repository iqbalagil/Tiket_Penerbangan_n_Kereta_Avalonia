using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tiket_Penerbangan_n_Kereta.Migrations
{
    /// <inheritdoc />
    public partial class new2Table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "Roles",
                table: "Petugas");

            migrationBuilder.AddColumn<int>(
                name: "TransportasiIdTransportasi",
                table: "Rute",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    IdRole = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RoleName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.IdRole);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Rute_TransportasiIdTransportasi",
                table: "Rute",
                column: "TransportasiIdTransportasi");

            migrationBuilder.CreateIndex(
                name: "IX_Petugas_idRole",
                table: "Petugas",
                column: "idRole");

            migrationBuilder.CreateIndex(
                name: "IX_Pemesanan_idPenumpang",
                table: "Pemesanan",
                column: "idPenumpang");

            migrationBuilder.CreateIndex(
                name: "IX_Pemesanan_idPetugas",
                table: "Pemesanan",
                column: "idPetugas");

            migrationBuilder.CreateIndex(
                name: "IX_Pemesanan_IdRute",
                table: "Pemesanan",
                column: "IdRute");

            migrationBuilder.AddForeignKey(
                name: "FK_Pemesanan_Penumpang_idPenumpang",
                table: "Pemesanan",
                column: "idPenumpang",
                principalTable: "Penumpang",
                principalColumn: "IdPenumpang",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pemesanan_Petugas_idPetugas",
                table: "Pemesanan",
                column: "idPetugas",
                principalTable: "Petugas",
                principalColumn: "idPetugas",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pemesanan_Rute_IdRute",
                table: "Pemesanan",
                column: "IdRute",
                principalTable: "Rute",
                principalColumn: "IdRute",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Petugas_Roles_idRole",
                table: "Petugas",
                column: "idRole",
                principalTable: "Roles",
                principalColumn: "IdRole",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Rute_Transportasi_TransportasiIdTransportasi",
                table: "Rute",
                column: "TransportasiIdTransportasi",
                principalTable: "Transportasi",
                principalColumn: "IdTransportasi",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pemesanan_Penumpang_idPenumpang",
                table: "Pemesanan");

            migrationBuilder.DropForeignKey(
                name: "FK_Pemesanan_Petugas_idPetugas",
                table: "Pemesanan");

            migrationBuilder.DropForeignKey(
                name: "FK_Pemesanan_Rute_IdRute",
                table: "Pemesanan");

            migrationBuilder.DropForeignKey(
                name: "FK_Petugas_Roles_idRole",
                table: "Petugas");

            migrationBuilder.DropForeignKey(
                name: "FK_Rute_Transportasi_TransportasiIdTransportasi",
                table: "Rute");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropIndex(
                name: "IX_Rute_TransportasiIdTransportasi",
                table: "Rute");

            migrationBuilder.DropIndex(
                name: "IX_Petugas_idRole",
                table: "Petugas");

            migrationBuilder.DropIndex(
                name: "IX_Pemesanan_idPenumpang",
                table: "Pemesanan");

            migrationBuilder.DropIndex(
                name: "IX_Pemesanan_idPetugas",
                table: "Pemesanan");

            migrationBuilder.DropIndex(
                name: "IX_Pemesanan_IdRute",
                table: "Pemesanan");

            migrationBuilder.DropColumn(
                name: "TransportasiIdTransportasi",
                table: "Rute");

            migrationBuilder.AddColumn<int>(
                name: "PemesananIdPemesanan",
                table: "Rute",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Roles",
                table: "Petugas",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

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
    }
}
