using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NatnaAgencyDigitalSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class StatusUpdateAndRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ApplicantPlacements_ApplicantProfileId",
                schema: "NatnaAgency",
                table: "ApplicantPlacements");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                schema: "NatnaAgency",
                table: "ApplicantProfiles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ApplicantPlacements_ApplicantProfileId",
                schema: "NatnaAgency",
                table: "ApplicantPlacements",
                column: "ApplicantProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicantLabourOffices_ApplicantProfileId",
                schema: "NatnaAgency",
                table: "ApplicantLabourOffices",
                column: "ApplicantProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicantInsurances_ApplicantProfileId",
                schema: "NatnaAgency",
                table: "ApplicantInsurances",
                column: "ApplicantProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicantFlightTickets_ApplicantProfileId",
                schema: "NatnaAgency",
                table: "ApplicantFlightTickets",
                column: "ApplicantProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicantContractAgreements_ApplicantProfileId",
                schema: "NatnaAgency",
                table: "ApplicantContractAgreements",
                column: "ApplicantProfileId");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicantContractAgreements_ApplicantProfiles_ApplicantProfileId",
                schema: "NatnaAgency",
                table: "ApplicantContractAgreements",
                column: "ApplicantProfileId",
                principalSchema: "NatnaAgency",
                principalTable: "ApplicantProfiles",
                principalColumn: "ApplicantProfileId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicantFlightTickets_ApplicantProfiles_ApplicantProfileId",
                schema: "NatnaAgency",
                table: "ApplicantFlightTickets",
                column: "ApplicantProfileId",
                principalSchema: "NatnaAgency",
                principalTable: "ApplicantProfiles",
                principalColumn: "ApplicantProfileId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicantInsurances_ApplicantProfiles_ApplicantProfileId",
                schema: "NatnaAgency",
                table: "ApplicantInsurances",
                column: "ApplicantProfileId",
                principalSchema: "NatnaAgency",
                principalTable: "ApplicantProfiles",
                principalColumn: "ApplicantProfileId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicantLabourOffices_ApplicantProfiles_ApplicantProfileId",
                schema: "NatnaAgency",
                table: "ApplicantLabourOffices",
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
                name: "FK_ApplicantContractAgreements_ApplicantProfiles_ApplicantProfileId",
                schema: "NatnaAgency",
                table: "ApplicantContractAgreements");

            migrationBuilder.DropForeignKey(
                name: "FK_ApplicantFlightTickets_ApplicantProfiles_ApplicantProfileId",
                schema: "NatnaAgency",
                table: "ApplicantFlightTickets");

            migrationBuilder.DropForeignKey(
                name: "FK_ApplicantInsurances_ApplicantProfiles_ApplicantProfileId",
                schema: "NatnaAgency",
                table: "ApplicantInsurances");

            migrationBuilder.DropForeignKey(
                name: "FK_ApplicantLabourOffices_ApplicantProfiles_ApplicantProfileId",
                schema: "NatnaAgency",
                table: "ApplicantLabourOffices");

            migrationBuilder.DropIndex(
                name: "IX_ApplicantPlacements_ApplicantProfileId",
                schema: "NatnaAgency",
                table: "ApplicantPlacements");

            migrationBuilder.DropIndex(
                name: "IX_ApplicantLabourOffices_ApplicantProfileId",
                schema: "NatnaAgency",
                table: "ApplicantLabourOffices");

            migrationBuilder.DropIndex(
                name: "IX_ApplicantInsurances_ApplicantProfileId",
                schema: "NatnaAgency",
                table: "ApplicantInsurances");

            migrationBuilder.DropIndex(
                name: "IX_ApplicantFlightTickets_ApplicantProfileId",
                schema: "NatnaAgency",
                table: "ApplicantFlightTickets");

            migrationBuilder.DropIndex(
                name: "IX_ApplicantContractAgreements_ApplicantProfileId",
                schema: "NatnaAgency",
                table: "ApplicantContractAgreements");

            migrationBuilder.DropColumn(
                name: "Status",
                schema: "NatnaAgency",
                table: "ApplicantProfiles");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicantPlacements_ApplicantProfileId",
                schema: "NatnaAgency",
                table: "ApplicantPlacements",
                column: "ApplicantProfileId",
                unique: true);
        }
    }
}
