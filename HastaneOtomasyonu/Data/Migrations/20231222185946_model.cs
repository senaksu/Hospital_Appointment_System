using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HastaneOtomasyonu.Data.Migrations
{
    public partial class model : Migration
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
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    doktoradi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PoliklinikID = table.Column<int>(type: "int", nullable: false),
                    muayeneucreti = table.Column<int>(type: "int", nullable: false)
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
                name: "randevu",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tc = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    doktorId = table.Column<int>(type: "int", nullable: false),
                    doktorId1 = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    randevuzamani = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_randevu", x => x.Id);
                    table.ForeignKey(
                        name: "FK_randevu_doktors_doktorId1",
                        column: x => x.doktorId1,
                        principalTable: "doktors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_doktors_PoliklinikID",
                table: "doktors",
                column: "PoliklinikID");

            migrationBuilder.CreateIndex(
                name: "IX_randevu_doktorId1",
                table: "randevu",
                column: "doktorId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "randevu");

            migrationBuilder.DropTable(
                name: "doktors");

            migrationBuilder.DropTable(
                name: "polikliniks");
        }
    }
}
