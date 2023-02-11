using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NatnaAgencyDigitalSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class ProcessManagement : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicantStatus_ApplicantProfiles_ApplicantProfileId",
                table: "ApplicantStatus");

            migrationBuilder.DropForeignKey(
                name: "FK_BenificiaryDeclaration_ApplicantProfiles_ApplicantProfileId",
                table: "BenificiaryDeclaration");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BenificiaryDeclaration",
                table: "BenificiaryDeclaration");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ApplicantStatus",
                table: "ApplicantStatus");

            migrationBuilder.RenameTable(
                name: "BenificiaryDeclaration",
                newName: "BenificiaryDeclarations");

            migrationBuilder.RenameTable(
                name: "ApplicantStatus",
                newName: "ApplicantStatuses",
                newSchema: "NatnaAgency");

            migrationBuilder.RenameIndex(
                name: "IX_BenificiaryDeclaration_ApplicantProfileId",
                table: "BenificiaryDeclarations",
                newName: "IX_BenificiaryDeclarations_ApplicantProfileId");

            migrationBuilder.RenameIndex(
                name: "IX_ApplicantStatus_ApplicantProfileId",
                schema: "NatnaAgency",
                table: "ApplicantStatuses",
                newName: "IX_ApplicantStatuses_ApplicantProfileId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BenificiaryDeclarations",
                table: "BenificiaryDeclarations",
                column: "BenificiaryDeclarationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ApplicantStatuses",
                schema: "NatnaAgency",
                table: "ApplicantStatuses",
                column: "ApplicantStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicantStatuses_ApplicantProfiles_ApplicantProfileId",
                schema: "NatnaAgency",
                table: "ApplicantStatuses",
                column: "ApplicantProfileId",
                principalSchema: "NatnaAgency",
                principalTable: "ApplicantProfiles",
                principalColumn: "ApplicantProfileId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BenificiaryDeclarations_ApplicantProfiles_ApplicantProfileId",
                table: "BenificiaryDeclarations",
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
                name: "FK_ApplicantStatuses_ApplicantProfiles_ApplicantProfileId",
                schema: "NatnaAgency",
                table: "ApplicantStatuses");

            migrationBuilder.DropForeignKey(
                name: "FK_BenificiaryDeclarations_ApplicantProfiles_ApplicantProfileId",
                table: "BenificiaryDeclarations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BenificiaryDeclarations",
                table: "BenificiaryDeclarations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ApplicantStatuses",
                schema: "NatnaAgency",
                table: "ApplicantStatuses");

            migrationBuilder.RenameTable(
                name: "BenificiaryDeclarations",
                newName: "BenificiaryDeclaration");

            migrationBuilder.RenameTable(
                name: "ApplicantStatuses",
                schema: "NatnaAgency",
                newName: "ApplicantStatus");

            migrationBuilder.RenameIndex(
                name: "IX_BenificiaryDeclarations_ApplicantProfileId",
                table: "BenificiaryDeclaration",
                newName: "IX_BenificiaryDeclaration_ApplicantProfileId");

            migrationBuilder.RenameIndex(
                name: "IX_ApplicantStatuses_ApplicantProfileId",
                table: "ApplicantStatus",
                newName: "IX_ApplicantStatus_ApplicantProfileId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BenificiaryDeclaration",
                table: "BenificiaryDeclaration",
                column: "BenificiaryDeclarationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ApplicantStatus",
                table: "ApplicantStatus",
                column: "ApplicantStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicantStatus_ApplicantProfiles_ApplicantProfileId",
                table: "ApplicantStatus",
                column: "ApplicantProfileId",
                principalSchema: "NatnaAgency",
                principalTable: "ApplicantProfiles",
                principalColumn: "ApplicantProfileId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BenificiaryDeclaration_ApplicantProfiles_ApplicantProfileId",
                table: "BenificiaryDeclaration",
                column: "ApplicantProfileId",
                principalSchema: "NatnaAgency",
                principalTable: "ApplicantProfiles",
                principalColumn: "ApplicantProfileId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
