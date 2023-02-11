using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NatnaAgencyDigitalSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddApplicantProfileGenderData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicantDocuments_ApplicantProfiles_ApplicantProfileApplicationRequestId",
                schema: "NatnaAgency",
                table: "ApplicantDocuments");

            migrationBuilder.DropForeignKey(
                name: "FK_ApplicantDocuments_ContactPersons_ContactPersonId",
                schema: "NatnaAgency",
                table: "ApplicantDocuments");

            migrationBuilder.DropForeignKey(
                name: "FK_ApplicantProfiles_ContactPersons_ContactPersonId",
                schema: "NatnaAgency",
                table: "ApplicantProfiles");

            migrationBuilder.DropForeignKey(
                name: "FK_ExperiencedJobs_ApplicantProfiles_ApplicantProfileApplicationRequestId",
                schema: "NatnaAgency",
                table: "ExperiencedJobs");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkExperiences_ApplicantProfiles_ApplicantProfileApplicationRequestId",
                schema: "NatnaAgency",
                table: "WorkExperiences");

            migrationBuilder.DropIndex(
                name: "IX_WorkExperiences_ApplicantProfileApplicationRequestId",
                schema: "NatnaAgency",
                table: "WorkExperiences");

            migrationBuilder.DropIndex(
                name: "IX_ExperiencedJobs_ApplicantProfileApplicationRequestId",
                schema: "NatnaAgency",
                table: "ExperiencedJobs");

            migrationBuilder.DropIndex(
                name: "IX_ApplicantProfiles_ContactPersonId",
                schema: "NatnaAgency",
                table: "ApplicantProfiles");

            migrationBuilder.DropIndex(
                name: "IX_ApplicantDocuments_ApplicantProfileApplicationRequestId",
                schema: "NatnaAgency",
                table: "ApplicantDocuments");

            migrationBuilder.DropIndex(
                name: "IX_ApplicantDocuments_ContactPersonId",
                schema: "NatnaAgency",
                table: "ApplicantDocuments");

            migrationBuilder.DropColumn(
                name: "ApplicantProfileApplicationRequestId",
                schema: "NatnaAgency",
                table: "WorkExperiences");

            migrationBuilder.DropColumn(
                name: "ApplicantProfileApplicationRequestId",
                schema: "NatnaAgency",
                table: "ExperiencedJobs");

            migrationBuilder.DropColumn(
                name: "ApplicantProfileApplicationRequestId",
                schema: "NatnaAgency",
                table: "ApplicantDocuments");

            migrationBuilder.DropColumn(
                name: "ContactPersonId",
                schema: "NatnaAgency",
                table: "ApplicantDocuments");

            migrationBuilder.RenameColumn(
                name: "ApplicationRequestId",
                schema: "NatnaAgency",
                table: "WorkExperiences",
                newName: "ApplicantProfileId");

            migrationBuilder.RenameColumn(
                name: "ApplicationRequestId",
                schema: "NatnaAgency",
                table: "ExperiencedJobs",
                newName: "ApplicantProfileId");

            migrationBuilder.RenameColumn(
                name: "ApplicationRequestId",
                schema: "NatnaAgency",
                table: "ContactPersons",
                newName: "ApplicantProfileId");

            migrationBuilder.RenameColumn(
                name: "ContactPersonId",
                schema: "NatnaAgency",
                table: "ApplicantProfiles",
                newName: "Gender");

            migrationBuilder.RenameColumn(
                name: "ApplicationRequestId",
                schema: "NatnaAgency",
                table: "ApplicantProfiles",
                newName: "ApplicantProfileId");

            migrationBuilder.RenameColumn(
                name: "ApplicationRequestId",
                schema: "NatnaAgency",
                table: "ApplicantDocuments",
                newName: "ApplicantProfileId");

            migrationBuilder.AddColumn<string>(
                name: "City",
                schema: "NatnaAgency",
                table: "ContactPersons",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Kebelle",
                schema: "NatnaAgency",
                table: "ContactPersons",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Wereda",
                schema: "NatnaAgency",
                table: "ContactPersons",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_WorkExperiences_ApplicantProfileId",
                schema: "NatnaAgency",
                table: "WorkExperiences",
                column: "ApplicantProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_ExperiencedJobs_ApplicantProfileId",
                schema: "NatnaAgency",
                table: "ExperiencedJobs",
                column: "ApplicantProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_ContactPersons_ApplicantProfileId",
                schema: "NatnaAgency",
                table: "ContactPersons",
                column: "ApplicantProfileId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ApplicantDocuments_ApplicantProfileId",
                schema: "NatnaAgency",
                table: "ApplicantDocuments",
                column: "ApplicantProfileId");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicantDocuments_ApplicantProfiles_ApplicantProfileId",
                schema: "NatnaAgency",
                table: "ApplicantDocuments",
                column: "ApplicantProfileId",
                principalSchema: "NatnaAgency",
                principalTable: "ApplicantProfiles",
                principalColumn: "ApplicantProfileId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ContactPersons_ApplicantProfiles_ApplicantProfileId",
                schema: "NatnaAgency",
                table: "ContactPersons",
                column: "ApplicantProfileId",
                principalSchema: "NatnaAgency",
                principalTable: "ApplicantProfiles",
                principalColumn: "ApplicantProfileId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ExperiencedJobs_ApplicantProfiles_ApplicantProfileId",
                schema: "NatnaAgency",
                table: "ExperiencedJobs",
                column: "ApplicantProfileId",
                principalSchema: "NatnaAgency",
                principalTable: "ApplicantProfiles",
                principalColumn: "ApplicantProfileId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkExperiences_ApplicantProfiles_ApplicantProfileId",
                schema: "NatnaAgency",
                table: "WorkExperiences",
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
                name: "FK_ApplicantDocuments_ApplicantProfiles_ApplicantProfileId",
                schema: "NatnaAgency",
                table: "ApplicantDocuments");

            migrationBuilder.DropForeignKey(
                name: "FK_ContactPersons_ApplicantProfiles_ApplicantProfileId",
                schema: "NatnaAgency",
                table: "ContactPersons");

            migrationBuilder.DropForeignKey(
                name: "FK_ExperiencedJobs_ApplicantProfiles_ApplicantProfileId",
                schema: "NatnaAgency",
                table: "ExperiencedJobs");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkExperiences_ApplicantProfiles_ApplicantProfileId",
                schema: "NatnaAgency",
                table: "WorkExperiences");

            migrationBuilder.DropIndex(
                name: "IX_WorkExperiences_ApplicantProfileId",
                schema: "NatnaAgency",
                table: "WorkExperiences");

            migrationBuilder.DropIndex(
                name: "IX_ExperiencedJobs_ApplicantProfileId",
                schema: "NatnaAgency",
                table: "ExperiencedJobs");

            migrationBuilder.DropIndex(
                name: "IX_ContactPersons_ApplicantProfileId",
                schema: "NatnaAgency",
                table: "ContactPersons");

            migrationBuilder.DropIndex(
                name: "IX_ApplicantDocuments_ApplicantProfileId",
                schema: "NatnaAgency",
                table: "ApplicantDocuments");

            migrationBuilder.DropColumn(
                name: "City",
                schema: "NatnaAgency",
                table: "ContactPersons");

            migrationBuilder.DropColumn(
                name: "Kebelle",
                schema: "NatnaAgency",
                table: "ContactPersons");

            migrationBuilder.DropColumn(
                name: "Wereda",
                schema: "NatnaAgency",
                table: "ContactPersons");

            migrationBuilder.RenameColumn(
                name: "ApplicantProfileId",
                schema: "NatnaAgency",
                table: "WorkExperiences",
                newName: "ApplicationRequestId");

            migrationBuilder.RenameColumn(
                name: "ApplicantProfileId",
                schema: "NatnaAgency",
                table: "ExperiencedJobs",
                newName: "ApplicationRequestId");

            migrationBuilder.RenameColumn(
                name: "ApplicantProfileId",
                schema: "NatnaAgency",
                table: "ContactPersons",
                newName: "ApplicationRequestId");

            migrationBuilder.RenameColumn(
                name: "Gender",
                schema: "NatnaAgency",
                table: "ApplicantProfiles",
                newName: "ContactPersonId");

            migrationBuilder.RenameColumn(
                name: "ApplicantProfileId",
                schema: "NatnaAgency",
                table: "ApplicantProfiles",
                newName: "ApplicationRequestId");

            migrationBuilder.RenameColumn(
                name: "ApplicantProfileId",
                schema: "NatnaAgency",
                table: "ApplicantDocuments",
                newName: "ApplicationRequestId");

            migrationBuilder.AddColumn<int>(
                name: "ApplicantProfileApplicationRequestId",
                schema: "NatnaAgency",
                table: "WorkExperiences",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ApplicantProfileApplicationRequestId",
                schema: "NatnaAgency",
                table: "ExperiencedJobs",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ApplicantProfileApplicationRequestId",
                schema: "NatnaAgency",
                table: "ApplicantDocuments",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ContactPersonId",
                schema: "NatnaAgency",
                table: "ApplicantDocuments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_WorkExperiences_ApplicantProfileApplicationRequestId",
                schema: "NatnaAgency",
                table: "WorkExperiences",
                column: "ApplicantProfileApplicationRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_ExperiencedJobs_ApplicantProfileApplicationRequestId",
                schema: "NatnaAgency",
                table: "ExperiencedJobs",
                column: "ApplicantProfileApplicationRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicantProfiles_ContactPersonId",
                schema: "NatnaAgency",
                table: "ApplicantProfiles",
                column: "ContactPersonId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicantDocuments_ApplicantProfileApplicationRequestId",
                schema: "NatnaAgency",
                table: "ApplicantDocuments",
                column: "ApplicantProfileApplicationRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicantDocuments_ContactPersonId",
                schema: "NatnaAgency",
                table: "ApplicantDocuments",
                column: "ContactPersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicantDocuments_ApplicantProfiles_ApplicantProfileApplicationRequestId",
                schema: "NatnaAgency",
                table: "ApplicantDocuments",
                column: "ApplicantProfileApplicationRequestId",
                principalSchema: "NatnaAgency",
                principalTable: "ApplicantProfiles",
                principalColumn: "ApplicationRequestId");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicantDocuments_ContactPersons_ContactPersonId",
                schema: "NatnaAgency",
                table: "ApplicantDocuments",
                column: "ContactPersonId",
                principalSchema: "NatnaAgency",
                principalTable: "ContactPersons",
                principalColumn: "ContactPersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicantProfiles_ContactPersons_ContactPersonId",
                schema: "NatnaAgency",
                table: "ApplicantProfiles",
                column: "ContactPersonId",
                principalSchema: "NatnaAgency",
                principalTable: "ContactPersons",
                principalColumn: "ContactPersonId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ExperiencedJobs_ApplicantProfiles_ApplicantProfileApplicationRequestId",
                schema: "NatnaAgency",
                table: "ExperiencedJobs",
                column: "ApplicantProfileApplicationRequestId",
                principalSchema: "NatnaAgency",
                principalTable: "ApplicantProfiles",
                principalColumn: "ApplicationRequestId");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkExperiences_ApplicantProfiles_ApplicantProfileApplicationRequestId",
                schema: "NatnaAgency",
                table: "WorkExperiences",
                column: "ApplicantProfileApplicationRequestId",
                principalSchema: "NatnaAgency",
                principalTable: "ApplicantProfiles",
                principalColumn: "ApplicationRequestId");
        }
    }
}
