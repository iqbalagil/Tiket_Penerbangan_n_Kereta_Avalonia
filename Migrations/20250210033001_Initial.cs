using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tiket_Penerbangan_n_Kereta.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pemesanan",
                columns: table => new
                {
                    IdPemesanan = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    KodePemesanan = table.Column<string>(type: "TEXT", nullable: false),
                    TanggalPemesanan = table.Column<DateTime>(type: "TEXT", nullable: false),
                    TempatPemesanan = table.Column<string>(type: "TEXT", nullable: false),
                    idPenumpang = table.Column<int>(type: "INTEGER", nullable: false),
                    KodeKursi = table.Column<string>(type: "TEXT", nullable: false),
                    IdRute = table.Column<int>(type: "INTEGER", nullable: false),
                    Tujuan = table.Column<string>(type: "TEXT", nullable: false),
                    TanggalBerangkat = table.Column<DateTime>(type: "TEXT", nullable: false),
                    TotalBayar = table.Column<decimal>(type: "TEXT", nullable: false),
                    idPetugas = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pemesanan", x => x.IdPemesanan);
                });

            migrationBuilder.CreateTable(
                name: "Penumpang",
                columns: table => new
                {
                    IdPenumpang = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Username = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    Password = table.Column<string>(type: "TEXT", nullable: false),
                    Nama = table.Column<string>(type: "TEXT", nullable: false),
                    JenisKelamin = table.Column<int>(type: "INTEGER", nullable: false),
                    AlamatPenumpang = table.Column<string>(type: "TEXT", nullable: false),
                    TanggalLahir = table.Column<DateTime>(type: "TEXT", nullable: false),
                    NoTelepon = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Penumpang", x => x.IdPenumpang);
                });

            migrationBuilder.CreateTable(
                name: "Petugas",
                columns: table => new
                {
                    idPetugas = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Username = table.Column<string>(type: "TEXT", nullable: false),
                    Password = table.Column<string>(type: "TEXT", nullable: false),
                    Nama = table.Column<string>(type: "TEXT", nullable: false),
                    idRole = table.Column<int>(type: "INTEGER", nullable: false),
                    Roles = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Petugas", x => x.idPetugas);
                });

            migrationBuilder.CreateTable(
                name: "Rute",
                columns: table => new
                {
                    IdRute = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Tujuan = table.Column<string>(type: "TEXT", nullable: false),
                    RuteAwal = table.Column<string>(type: "TEXT", nullable: false),
                    RuteAkhri = table.Column<string>(type: "TEXT", nullable: false),
                    IdTransportasi = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rute", x => x.IdRute);
                });

            migrationBuilder.CreateTable(
                name: "Transportasi",
                columns: table => new
                {
                    IdTransportasi = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Imagedata = table.Column<byte[]>(type: "BLOB", nullable: false),
                    Kode = table.Column<string>(type: "TEXT", nullable: false),
                    JumlahKursi = table.Column<int>(type: "INTEGER", nullable: false),
                    Keterangan = table.Column<string>(type: "TEXT", nullable: false),
                    NamaType = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transportasi", x => x.IdTransportasi);
                });

            migrationBuilder.CreateTable(
                name: "TypeTransportasi",
                columns: table => new
                {
                    IdTypeTransportasi = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NamaType = table.Column<string>(type: "TEXT", nullable: false),
                    Keterangan = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeTransportasi", x => x.IdTypeTransportasi);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pemesanan");

            migrationBuilder.DropTable(
                name: "Penumpang");

            migrationBuilder.DropTable(
                name: "Petugas");

            migrationBuilder.DropTable(
                name: "Rute");

            migrationBuilder.DropTable(
                name: "Transportasi");

            migrationBuilder.DropTable(
                name: "TypeTransportasi");
        }
    }
}
