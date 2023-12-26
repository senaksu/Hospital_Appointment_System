using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HastaneOtomasyonu.Data.Migrations
{
    public partial class deneme54 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "randevuZamani",
                table: "randevus",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_randevus_doktorId",
                table: "randevus",
                column: "doktorId");

            migrationBuilder.AddForeignKey(
                name: "FK_randevus_doktors_doktorId",
                table: "randevus",
                column: "doktorId",
                principalTable: "doktors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_randevus_doktors_doktorId",
                table: "randevus");

            migrationBuilder.DropIndex(
                name: "IX_randevus_doktorId",
                table: "randevus");

            migrationBuilder.DropColumn(
                name: "randevuZamani",
                table: "randevus");
        }
    }
}
