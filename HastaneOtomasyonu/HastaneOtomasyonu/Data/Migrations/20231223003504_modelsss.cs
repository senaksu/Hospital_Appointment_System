using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HastaneOtomasyonu.Data.Migrations
{
    public partial class modelsss : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "polikliniks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    adi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_polikliniks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "doktors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    doktoradi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    muayeneucreti = table.Column<int>(type: "int", nullable: false),
                    PoliklinikID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_doktors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_doktors_polikliniks_PoliklinikID",
                        column: x => x.PoliklinikID,
                        principalTable: "polikliniks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "randevus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tc = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    randevuzamani = table.Column<DateTime>(type: "datetime2", nullable: false),
                    doktorId = table.Column<int>(type: "int", nullable: false)
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
                });

            migrationBuilder.CreateIndex(
                name: "IX_doktors_PoliklinikID",
                table: "doktors",
                column: "PoliklinikID");

            migrationBuilder.CreateIndex(
                name: "IX_randevus_doktorId",
                table: "randevus",
                column: "doktorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "randevus");

            migrationBuilder.DropTable(
                name: "doktors");

            migrationBuilder.DropTable(
                name: "polikliniks");
        }
    }
}
