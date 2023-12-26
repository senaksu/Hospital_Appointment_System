using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HastaneOtomasyonu.Data.Migrations
{
    public partial class duzetlmeeü : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "randevus");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "randevus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    doktorId = table.Column<int>(type: "int", nullable: false),
                    PoliklinikId = table.Column<int>(type: "int", nullable: true),
                    randevuzamani = table.Column<DateTime>(type: "datetime2", nullable: false),
                    tc = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_randevus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_randevus_doktors_doktorId",
                        column: x => x.doktorId,
                        principalTable: "doktors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_randevus_polikliniks_PoliklinikId",
                        column: x => x.PoliklinikId,
                        principalTable: "polikliniks",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_randevus_doktorId",
                table: "randevus",
                column: "doktorId");

            migrationBuilder.CreateIndex(
                name: "IX_randevus_PoliklinikId",
                table: "randevus",
                column: "PoliklinikId");
        }
    }
}
