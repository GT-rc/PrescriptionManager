using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;
using PrescriptionManager.Models;

namespace PrescriptionManager.Data.Migrations
{
    public partial class ModelRealignment3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Medication_Set_SetID",
                table: "Medication");

            migrationBuilder.DropForeignKey(
                name: "FK_Set_UserMeds_UserMedIDUserId_UserMedIDMedID",
                table: "Set");

            migrationBuilder.DropIndex(
                name: "IX_Set_UserMedIDUserId_UserMedIDMedID",
                table: "Set");

            migrationBuilder.DropIndex(
                name: "IX_Medication_SetID",
                table: "Medication");

            migrationBuilder.DropColumn(
                name: "TimeOfDay",
                table: "Set");

            migrationBuilder.DropColumn(
                name: "UserMedIDMedID",
                table: "Set");

            migrationBuilder.DropColumn(
                name: "UserMedIDUserId",
                table: "Set");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Medication");

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

            migrationBuilder.DropColumn(
                name: "SetID",
                table: "Medication");

            migrationBuilder.DropColumn(
                name: "TimeOfDay",
                table: "Medication");

            migrationBuilder.CreateTable(
                name: "Doses",
                columns: table => new
                {
                    DoseID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PillsXDose = table.Column<int>(nullable: false),
                    SetID = table.Column<int>(nullable: true),
                    TimeOfDose = table.Column<int>(nullable: false),
                    UserMedMedID = table.Column<int>(nullable: false),
                    UserMedUserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doses", x => x.DoseID);
                    table.ForeignKey(
                        name: "FK_Doses_Set_SetID",
                        column: x => x.SetID,
                        principalTable: "Set",
                        principalColumn: "SetID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Doses_UserMeds_UserMedUserId_UserMedMedID",
                        columns: x => new { x.UserMedUserId, x.UserMedMedID },
                        principalTable: "UserMeds",
                        principalColumns: new[] { "UserId", "MedID" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.AddColumn<int>(
                name: "TimeOfSet",
                table: "Set",
                nullable: false,
                defaultValue: ToD.morning);

            migrationBuilder.AddColumn<int>(
                name: "TimesXDay",
                table: "Medication",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Medication",
                nullable: false);

            migrationBuilder.CreateIndex(
                name: "IX_Doses_SetID",
                table: "Doses",
                column: "SetID");

            migrationBuilder.CreateIndex(
                name: "IX_Doses_UserMedUserId_UserMedMedID",
                table: "Doses",
                columns: new[] { "UserMedUserId", "UserMedMedID" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TimeOfSet",
                table: "Set");

            migrationBuilder.DropColumn(
                name: "TimesXDay",
                table: "Medication");

            migrationBuilder.DropTable(
                name: "Doses");

            migrationBuilder.AddColumn<int>(
                name: "TimeOfDay",
                table: "Set",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserMedIDMedID",
                table: "Set",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserMedIDUserId",
                table: "Set",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Medication",
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

            migrationBuilder.AddColumn<string>(
                name: "ScripNumber",
                table: "Medication",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SetID",
                table: "Medication",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TimeOfDay",
                table: "Medication",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Set_UserMedIDUserId_UserMedIDMedID",
                table: "Set",
                columns: new[] { "UserMedIDUserId", "UserMedIDMedID" });

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Medication",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Medication_SetID",
                table: "Medication",
                column: "SetID");

            migrationBuilder.AddForeignKey(
                name: "FK_Medication_Set_SetID",
                table: "Medication",
                column: "SetID",
                principalTable: "Set",
                principalColumn: "SetID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Set_UserMeds_UserMedIDUserId_UserMedIDMedID",
                table: "Set",
                columns: new[] { "UserMedIDUserId", "UserMedIDMedID" },
                principalTable: "UserMeds",
                principalColumns: new[] { "UserId", "MedID" },
                onDelete: ReferentialAction.Restrict);
        }
    }
}
