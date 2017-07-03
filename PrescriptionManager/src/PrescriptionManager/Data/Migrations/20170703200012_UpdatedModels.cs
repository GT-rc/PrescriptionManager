using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PrescriptionManager.Data.Migrations
{
    public partial class UpdatedModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MedSets");

            migrationBuilder.CreateTable(
                name: "UserMeds",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    MedID = table.Column<int>(nullable: false),
                    MedicationID = table.Column<int>(nullable: true),
                    UserId1 = table.Column<string>(nullable: true),
                    UserMedID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserMeds", x => new { x.UserId, x.MedID });
                    table.ForeignKey(
                        name: "FK_UserMeds_Medication_MedicationID",
                        column: x => x.MedicationID,
                        principalTable: "Medication",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserMeds_AspNetUsers_UserId1",
                        column: x => x.UserId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.AddColumn<int>(
                name: "UserMedIDMedID",
                table: "Set",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserMedIDUserId",
                table: "Set",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Pharmacy",
                table: "Medication",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PillsPerDose",
                table: "Medication",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "PrescribingDoctor",
                table: "Medication",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ScripNumber",
                table: "Medication",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Set_UserMedIDUserId_UserMedIDMedID",
                table: "Set",
                columns: new[] { "UserMedIDUserId", "UserMedIDMedID" });

            migrationBuilder.CreateIndex(
                name: "IX_UserMeds_MedicationID",
                table: "UserMeds",
                column: "MedicationID");

            migrationBuilder.CreateIndex(
                name: "IX_UserMeds_UserId1",
                table: "UserMeds",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Set_UserMeds_UserMedIDUserId_UserMedIDMedID",
                table: "Set",
                columns: new[] { "UserMedIDUserId", "UserMedIDMedID" },
                principalTable: "UserMeds",
                principalColumns: new[] { "UserId", "MedID" },
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Set_UserMeds_UserMedIDUserId_UserMedIDMedID",
                table: "Set");

            migrationBuilder.DropIndex(
                name: "IX_Set_UserMedIDUserId_UserMedIDMedID",
                table: "Set");

            migrationBuilder.DropColumn(
                name: "UserMedIDMedID",
                table: "Set");

            migrationBuilder.DropColumn(
                name: "UserMedIDUserId",
                table: "Set");

            migrationBuilder.DropColumn(
                name: "Pharmacy",
                table: "Medication");

            migrationBuilder.DropColumn(
                name: "PillsPerDose",
                table: "Medication");

            migrationBuilder.DropColumn(
                name: "PrescribingDoctor",
                table: "Medication");

            migrationBuilder.DropColumn(
                name: "ScripNumber",
                table: "Medication");

            migrationBuilder.DropTable(
                name: "UserMeds");

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

            migrationBuilder.CreateIndex(
                name: "IX_MedSets_SetId",
                table: "MedSets",
                column: "SetId");

            migrationBuilder.CreateIndex(
                name: "IX_MedSets_UserId1",
                table: "MedSets",
                column: "UserId1");
        }
    }
}
