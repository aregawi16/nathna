using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NatnaAgencyDigitalSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class UserAndApplicantUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FirstNameAm",
                schema: "NatnaAgency",
                table: "ApplicantProfiles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastNameAm",
                schema: "NatnaAgency",
                table: "ApplicantProfiles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MiddleNameAm",
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
                name: "FirstNameAm",
                schema: "NatnaAgency",
                table: "ApplicantProfiles");

            migrationBuilder.DropColumn(
                name: "LastNameAm",
                schema: "NatnaAgency",
                table: "ApplicantProfiles");

            migrationBuilder.DropColumn(
                name: "MiddleNameAm",
                schema: "NatnaAgency",
                table: "ApplicantProfiles");
        }
    }
}
