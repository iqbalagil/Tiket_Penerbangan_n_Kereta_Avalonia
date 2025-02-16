using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tiket_Penerbangan_n_Kereta.Migrations
{
    /// <inheritdoc />
    public partial class updateTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NamaType",
                table: "Transportasi");

            migrationBuilder.AlterColumn<string>(
                name: "Keterangan",
                table: "Transportasi",
                type: "TEXT",
                nullable: false,
                defaultValue: "Active",
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AddColumn<int>(
                name: "IdTypeTransportasi",
                table: "Transportasi",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Transportasi_IdTypeTransportasi",
                table: "Transportasi",
                column: "IdTypeTransportasi");

            migrationBuilder.AddForeignKey(
                name: "FK_Transportasi_TypeTransportasi_IdTypeTransportasi",
                table: "Transportasi",
                column: "IdTypeTransportasi",
                principalTable: "TypeTransportasi",
                principalColumn: "IdTypeTransportasi",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transportasi_TypeTransportasi_IdTypeTransportasi",
                table: "Transportasi");

            migrationBuilder.DropIndex(
                name: "IX_Transportasi_IdTypeTransportasi",
                table: "Transportasi");

            migrationBuilder.DropColumn(
                name: "IdTypeTransportasi",
                table: "Transportasi");

            migrationBuilder.AlterColumn<string>(
                name: "Keterangan",
                table: "Transportasi",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldDefaultValue: "Active");

            migrationBuilder.AddColumn<string>(
                name: "NamaType",
                table: "Transportasi",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }
    }
}
