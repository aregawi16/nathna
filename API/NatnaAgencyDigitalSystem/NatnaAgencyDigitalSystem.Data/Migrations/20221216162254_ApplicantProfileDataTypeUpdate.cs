using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NatnaAgencyDigitalSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class ApplicantProfileDataTypeUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FullName",
                schema: "NatnaAgency",
                table: "ApplicantProfiles");

            migrationBuilder.RenameColumn(
                name: "PassportExpireDate",
                schema: "NatnaAgency",
                table: "ApplicantProfiles",
                newName: "PassportExpiryDate");

            migrationBuilder.RenameColumn(
                name: "LastlName",
                schema: "NatnaAgency",
                table: "ApplicantProfiles",
                newName: "LastName");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                schema: "NatnaAgency",
                table: "ApplicantProfiles",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PassportExpiryDate",
                schema: "NatnaAgency",
                table: "ApplicantProfiles",
                newName: "PassportExpireDate");

            migrationBuilder.RenameColumn(
                name: "LastName",
                schema: "NatnaAgency",
                table: "ApplicantProfiles",
                newName: "LastlName");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                schema: "NatnaAgency",
                table: "ApplicantProfiles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FullName",
                schema: "NatnaAgency",
                table: "ApplicantProfiles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
