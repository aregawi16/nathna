using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NatnaAgencyDigitalSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class ApplicantGovDocAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ApplicantContractAgreementPath",
                schema: "NatnaAgency",
                table: "ApplicantDocuments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicantCrimeCheckfreeDocumentPath",
                schema: "NatnaAgency",
                table: "ApplicantDocuments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicantMedicalDocumentPath",
                schema: "NatnaAgency",
                table: "ApplicantDocuments",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApplicantContractAgreementPath",
                schema: "NatnaAgency",
                table: "ApplicantDocuments");

            migrationBuilder.DropColumn(
                name: "ApplicantCrimeCheckfreeDocumentPath",
                schema: "NatnaAgency",
                table: "ApplicantDocuments");

            migrationBuilder.DropColumn(
                name: "ApplicantMedicalDocumentPath",
                schema: "NatnaAgency",
                table: "ApplicantDocuments");
        }
    }
}
