using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tiket_Penerbangan_n_Kereta.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateTable(
                name: "Penumpang",
                columns: table => new
                {
                    IdPenumpang = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Username = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    Password = table.Column<string>(type: "TEXT", nullable: false),
                    Nama = table.Column<string>(type: "TEXT", nullable: true),
                    JenisKelamin = table.Column<char>(type: "TEXT", nullable: true),
                    AlamatPenumpang = table.Column<string>(type: "TEXT", nullable: true),
                    TanggalLahir = table.Column<DateTime>(type: "TEXT", nullable: true),
                    NoTelepon = table.Column<string>(type: "TEXT", nullable: true),
                    IdRole = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Penumpang", x => x.IdPenumpang);
                    table.ForeignKey(
                        name: "FK_Penumpang_Roles_IdRole",
                        column: x => x.IdRole,
                        principalTable: "Roles",
                        principalColumn: "IdRole",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Petugas",
                columns: table => new
                {
                    idPetugas = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Username = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    Password = table.Column<string>(type: "TEXT", nullable: false),
                    Nama = table.Column<string>(type: "TEXT", nullable: false),
                    idRole = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Petugas", x => x.idPetugas);
                    table.ForeignKey(
                        name: "FK_Petugas_Roles_idRole",
                        column: x => x.idRole,
                        principalTable: "Roles",
                        principalColumn: "IdRole",
                        onDelete: ReferentialAction.Cascade);
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
                    Keterangan = table.Column<string>(type: "TEXT", nullable: false, defaultValue: "Active"),
                    IdTypeTransportasi = table.Column<int>(type: "INTEGER", nullable: false),
                    NamaType = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transportasi", x => x.IdTransportasi);
                    table.ForeignKey(
                        name: "FK_Transportasi_TypeTransportasi_IdTypeTransportasi",
                        column: x => x.IdTypeTransportasi,
                        principalTable: "TypeTransportasi",
                        principalColumn: "IdTypeTransportasi",
                        onDelete: ReferentialAction.Cascade);
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
                    IdTransportasi = table.Column<int>(type: "INTEGER", nullable: false),
                    TransportasiIdTransportasi = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rute", x => x.IdRute);
                    table.ForeignKey(
                        name: "FK_Rute_Transportasi_TransportasiIdTransportasi",
                        column: x => x.TransportasiIdTransportasi,
                        principalTable: "Transportasi",
                        principalColumn: "IdTransportasi",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pemesanan",
                columns: table => new
                {
                    IdPemesanan = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    KodePemesanan = table.Column<string>(type: "TEXT", nullable: true),
                    TanggalPemesanan = table.Column<DateTime>(type: "TEXT", nullable: true),
                    TempatPemesanan = table.Column<string>(type: "TEXT", nullable: false),
                    idPenumpang = table.Column<int>(type: "INTEGER", nullable: false),
                    KodeKursi = table.Column<string>(type: "TEXT", nullable: false),
                    IdRute = table.Column<int>(type: "INTEGER", nullable: false),
                    TanggalBerangkat = table.Column<DateTime>(type: "TEXT", nullable: false),
                    JamTiba = table.Column<DateTime>(type: "TEXT", nullable: false),
                    JamBerangkat = table.Column<DateTime>(type: "TEXT", nullable: false),
                    TotalBayar = table.Column<decimal>(type: "TEXT", nullable: false),
                    idPetugas = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pemesanan", x => x.IdPemesanan);
                    table.ForeignKey(
                        name: "FK_Pemesanan_Penumpang_idPenumpang",
                        column: x => x.idPenumpang,
                        principalTable: "Penumpang",
                        principalColumn: "IdPenumpang",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pemesanan_Petugas_idPetugas",
                        column: x => x.idPetugas,
                        principalTable: "Petugas",
                        principalColumn: "idPetugas",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pemesanan_Rute_IdRute",
                        column: x => x.IdRute,
                        principalTable: "Rute",
                        principalColumn: "IdRute",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Penumpang_IdRole",
                table: "Penumpang",
                column: "IdRole");

            migrationBuilder.CreateIndex(
                name: "IX_Petugas_idRole",
                table: "Petugas",
                column: "idRole");

            migrationBuilder.CreateIndex(
                name: "IX_Rute_TransportasiIdTransportasi",
                table: "Rute",
                column: "TransportasiIdTransportasi");

            migrationBuilder.CreateIndex(
                name: "IX_Transportasi_IdTypeTransportasi",
                table: "Transportasi",
                column: "IdTypeTransportasi");
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
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Transportasi");

            migrationBuilder.DropTable(
                name: "TypeTransportasi");
        }
    }
}
