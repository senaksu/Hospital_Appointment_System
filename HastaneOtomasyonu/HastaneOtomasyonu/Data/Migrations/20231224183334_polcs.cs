using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HastaneOtomasyonu.Data.Migrations
{
    public partial class polcs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_doktors_polikliniks_PoliklinikID",
                table: "doktors");

            migrationBuilder.RenameColumn(
                name: "PoliklinikID",
                table: "doktors",
                newName: "PoliklinikId");

            migrationBuilder.RenameIndex(
                name: "IX_doktors_PoliklinikID",
                table: "doktors",
                newName: "IX_doktors_PoliklinikId");

            migrationBuilder.AddColumn<int>(
                name: "PoliklinikId",
                table: "randevus",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_randevus_PoliklinikId",
                table: "randevus",
                column: "PoliklinikId");

            migrationBuilder.AddForeignKey(
                name: "FK_doktors_polikliniks_PoliklinikId",
                table: "doktors",
                column: "PoliklinikId",
                principalTable: "polikliniks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_randevus_polikliniks_PoliklinikId",
                table: "randevus",
                column: "PoliklinikId",
                principalTable: "polikliniks",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_doktors_polikliniks_PoliklinikId",
                table: "doktors");

            migrationBuilder.DropForeignKey(
                name: "FK_randevus_polikliniks_PoliklinikId",
                table: "randevus");

            migrationBuilder.DropIndex(
                name: "IX_randevus_PoliklinikId",
                table: "randevus");

            migrationBuilder.DropColumn(
                name: "PoliklinikId",
                table: "randevus");

            migrationBuilder.RenameColumn(
                name: "PoliklinikId",
                table: "doktors",
                newName: "PoliklinikID");

            migrationBuilder.RenameIndex(
                name: "IX_doktors_PoliklinikId",
                table: "doktors",
                newName: "IX_doktors_PoliklinikID");

            migrationBuilder.AddForeignKey(
                name: "FK_doktors_polikliniks_PoliklinikID",
                table: "doktors",
                column: "PoliklinikID",
                principalTable: "polikliniks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
