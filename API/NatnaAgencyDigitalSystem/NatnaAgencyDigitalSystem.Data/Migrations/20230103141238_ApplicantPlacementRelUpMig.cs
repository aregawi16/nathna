using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NatnaAgencyDigitalSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class ApplicantPlacementRelUpMig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_ApplicantPlacements_ApplicantProfileId",
                table: "ApplicantPlacements",
                column: "ApplicantProfileId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicantPlacements_ApplicantProfiles_ApplicantProfileId",
                table: "ApplicantPlacements",
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
                name: "FK_ApplicantPlacements_ApplicantProfiles_ApplicantProfileId",
                table: "ApplicantPlacements");

            migrationBuilder.DropIndex(
                name: "IX_ApplicantPlacements_ApplicantProfileId",
                table: "ApplicantPlacements");
        }
    }
}
