using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NatnaAgencyDigitalSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddressAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "PassportIssueDate",
                schema: "NatnaAgency",
                table: "ApplicantProfiles",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "PassportExpiryDate",
                schema: "NatnaAgency",
                table: "ApplicantProfiles",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "City",
                schema: "NatnaAgency",
                table: "ApplicantProfiles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Kebelle",
                schema: "NatnaAgency",
                table: "ApplicantProfiles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Wereda",
                schema: "NatnaAgency",
                table: "ApplicantProfiles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                schema: "NatnaAgency",
                table: "ApplicantProfiles");

            migrationBuilder.DropColumn(
                name: "Kebelle",
                schema: "NatnaAgency",
                table: "ApplicantProfiles");

            migrationBuilder.DropColumn(
                name: "Wereda",
                schema: "NatnaAgency",
                table: "ApplicantProfiles");

            migrationBuilder.AlterColumn<string>(
                name: "PassportIssueDate",
                schema: "NatnaAgency",
                table: "ApplicantProfiles",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "PassportExpiryDate",
                schema: "NatnaAgency",
                table: "ApplicantProfiles",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");
        }
    }
}
