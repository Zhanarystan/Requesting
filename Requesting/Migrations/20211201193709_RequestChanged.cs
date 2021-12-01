using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Requesting.Migrations
{
    public partial class RequestChanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RequestDate",
                table: "Requests",
                newName: "Date");

            migrationBuilder.RenameColumn(
                name: "RequestCode",
                table: "Requests",
                newName: "Status");

            migrationBuilder.AddColumn<Guid>(
                name: "Code",
                table: "Requests",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Code",
                table: "Requests");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Requests",
                newName: "RequestCode");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Requests",
                newName: "RequestDate");
        }
    }
}
