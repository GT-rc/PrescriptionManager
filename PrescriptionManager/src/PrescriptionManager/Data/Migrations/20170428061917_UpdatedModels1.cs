using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PrescriptionManager.Data.Migrations
{
    public partial class UpdatedModels1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Medication",
                table: "Medication");

            migrationBuilder.DropColumn(
                name: "ID",
                table: "Medication");

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
                    UserID = table.Column<int>(nullable: false),
                    SetID = table.Column<int>(nullable: false),
                    ID = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedSets", x => new { x.UserID, x.SetID });
                    table.ForeignKey(
                        name: "FK_MedSets_Set_SetID",
                        column: x => x.SetID,
                        principalTable: "Set",
                        principalColumn: "SetID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MedSets_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.AddColumn<int>(
                name: "MedID",
                table: "Medication",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<int>(
                name: "SetID",
                table: "Medication",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Medication",
                table: "Medication",
                column: "MedID");

            migrationBuilder.CreateIndex(
                name: "IX_Medication_SetID",
                table: "Medication",
                column: "SetID");

            migrationBuilder.CreateIndex(
                name: "IX_MedSets_SetID",
                table: "MedSets",
                column: "SetID");

            migrationBuilder.CreateIndex(
                name: "IX_MedSets_UserId",
                table: "MedSets",
                column: "UserId");

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

            migrationBuilder.DropPrimaryKey(
                name: "PK_Medication",
                table: "Medication");

            migrationBuilder.DropIndex(
                name: "IX_Medication_SetID",
                table: "Medication");

            migrationBuilder.DropColumn(
                name: "MedID",
                table: "Medication");

            migrationBuilder.DropColumn(
                name: "SetID",
                table: "Medication");

            migrationBuilder.DropTable(
                name: "MedSets");

            migrationBuilder.DropTable(
                name: "Set");

            migrationBuilder.AddColumn<int>(
                name: "ID",
                table: "Medication",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Medication",
                table: "Medication",
                column: "ID");
        }
    }
}
