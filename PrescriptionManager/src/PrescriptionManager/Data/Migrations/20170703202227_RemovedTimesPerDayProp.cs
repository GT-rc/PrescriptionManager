using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PrescriptionManager.Data.Migrations
{
    public partial class RemovedTimesPerDayProp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TimesXDay",
                table: "Medication");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TimesXDay",
                table: "Medication",
                nullable: false,
                defaultValue: 0);
        }
    }
}
