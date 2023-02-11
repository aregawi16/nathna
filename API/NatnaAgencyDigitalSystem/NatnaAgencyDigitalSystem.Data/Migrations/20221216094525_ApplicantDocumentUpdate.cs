using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NatnaAgencyDigitalSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class ApplicantDocumentUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicantDocuments_ApplicantProfiles_ApplicantProfileId",
                schema: "NatnaAgency",
                table: "ApplicantDocuments");

            migrationBuilder.DropIndex(
                name: "IX_ApplicantDocuments_ApplicantProfileId",
                schema: "NatnaAgency",
                table: "ApplicantDocuments");

            migrationBuilder.DropColumn(
                name: "DocumentType",
                schema: "NatnaAgency",
                table: "ApplicantDocuments");

            migrationBuilder.RenameColumn(
                name: "FilePath",
                schema: "NatnaAgency",
                table: "ApplicantDocuments",
                newName: "ApplicantVideoPath");

            migrationBuilder.RenameColumn(
                name: "FileName",
                schema: "NatnaAgency",
                table: "ApplicantDocuments",
                newName: "ApplicantSmallPhotoPath");

            migrationBuilder.RenameColumn(
                name: "FileExtension",
                schema: "NatnaAgency",
                table: "ApplicantDocuments",
                newName: "ApplicantPassportFilePath");

            migrationBuilder.AddColumn<string>(
                name: "ContactPersonDocumentPath",
                schema: "NatnaAgency",
                table: "ContactPersons",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ApplicantFullPhotoPath",
                schema: "NatnaAgency",
                table: "ApplicantDocuments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ApplicantIdFilePath",
                schema: "NatnaAgency",
                table: "ApplicantDocuments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContactPersonDocumentPath",
                schema: "NatnaAgency",
                table: "ContactPersons");

            migrationBuilder.DropColumn(
                name: "ApplicantFullPhotoPath",
                schema: "NatnaAgency",
                table: "ApplicantDocuments");

            migrationBuilder.DropColumn(
                name: "ApplicantIdFilePath",
                schema: "NatnaAgency",
                table: "ApplicantDocuments");

            migrationBuilder.RenameColumn(
                name: "ApplicantVideoPath",
                schema: "NatnaAgency",
                table: "ApplicantDocuments",
                newName: "FilePath");

            migrationBuilder.RenameColumn(
                name: "ApplicantSmallPhotoPath",
                schema: "NatnaAgency",
                table: "ApplicantDocuments",
                newName: "FileName");

            migrationBuilder.RenameColumn(
                name: "ApplicantPassportFilePath",
                schema: "NatnaAgency",
                table: "ApplicantDocuments",
                newName: "FileExtension");

            migrationBuilder.AddColumn<int>(
                name: "DocumentType",
                schema: "NatnaAgency",
                table: "ApplicantDocuments",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
        }
    }
}
