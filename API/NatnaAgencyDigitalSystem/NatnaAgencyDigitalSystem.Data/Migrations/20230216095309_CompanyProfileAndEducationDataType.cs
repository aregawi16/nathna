using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NatnaAgencyDigitalSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class CompanyProfileAndEducationDataType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_EducationHistorys_ApplicantProfileId",
                schema: "NatnaAgency",
                table: "EducationHistorys",
                column: "ApplicantProfileId");

            migrationBuilder.AddForeignKey(
                name: "FK_EducationHistorys_ApplicantProfiles_ApplicantProfileId",
                schema: "NatnaAgency",
                table: "EducationHistorys",
                column: "ApplicantProfileId",
                principalSchema: "NatnaAgency",
                principalTable: "ApplicantProfiles",
                principalColumn: "ApplicantProfileId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EducationHistorys_ApplicantProfiles_ApplicantProfileId",
                schema: "NatnaAgency",
                table: "EducationHistorys");

            migrationBuilder.DropIndex(
                name: "IX_EducationHistorys_ApplicantProfileId",
                schema: "NatnaAgency",
                table: "EducationHistorys");
        }
    }
}
