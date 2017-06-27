using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PrescriptionManager.Data.Migrations
{
    public partial class NewMigration3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Set",
                columns: table => new
                {
                    SetID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TimeOfDay = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Set", x => x.SetID);
                });

            migrationBuilder.CreateTable(
                name: "MedSets",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    SetId = table.Column<int>(nullable: false),
                    ID = table.Column<int>(nullable: false),
                    UserId1 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedSets", x => new { x.UserId, x.SetId });
                    table.ForeignKey(
                        name: "FK_MedSets_Set_SetId",
                        column: x => x.SetId,
                        principalTable: "Set",
                        principalColumn: "SetID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MedSets_AspNetUsers_UserId1",
                        column: x => x.UserId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.AddColumn<int>(
                name: "RefillRate",
                table: "Medication",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SetID",
                table: "Medication",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserID",
                table: "Medication",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Medication_SetID",
                table: "Medication",
                column: "SetID");

            migrationBuilder.CreateIndex(
                name: "IX_MedSets_SetId",
                table: "MedSets",
                column: "SetId");

            migrationBuilder.CreateIndex(
                name: "IX_MedSets_UserId1",
                table: "MedSets",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Medication_Set_SetID",
                table: "Medication",
                column: "SetID",
                principalTable: "Set",
                principalColumn: "SetID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Medication_Set_SetID",
                table: "Medication");

            migrationBuilder.DropIndex(
                name: "IX_Medication_SetID",
                table: "Medication");

            migrationBuilder.DropColumn(
                name: "RefillRate",
                table: "Medication");

            migrationBuilder.DropColumn(
                name: "SetID",
                table: "Medication");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "Medication");

            migrationBuilder.DropTable(
                name: "MedSets");

            migrationBuilder.DropTable(
                name: "Set");
        }
    }
}
