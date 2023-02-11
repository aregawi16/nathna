using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NatnaAgencyDigitalSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddApplicantProfileUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NatnaDocuments",
                schema: "NatnaAgency");

            migrationBuilder.DropColumn(
                name: "AvailableYear",
                schema: "NatnaAgency",
                table: "ApplicantProfiles");

            migrationBuilder.CreateTable(
                name: "ApplicantDocuments",
                schema: "NatnaAgency",
                columns: table => new
                {
                    ApplicantDocumentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationRequestId = table.Column<int>(type: "int", nullable: false),
                    DocumentType = table.Column<int>(type: "int", nullable: false),
                    FilePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FileExtension = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApplicantProfileApplicationRequestId = table.Column<int>(type: "int", nullable: true),
                    ContactPersonId = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicantDocuments", x => x.ApplicantDocumentId);
                    table.ForeignKey(
                        name: "FK_ApplicantDocuments_ApplicantProfiles_ApplicantProfileApplicationRequestId",
                        column: x => x.ApplicantProfileApplicationRequestId,
                        principalSchema: "NatnaAgency",
                        principalTable: "ApplicantProfiles",
                        principalColumn: "ApplicationRequestId");
                    table.ForeignKey(
                        name: "FK_ApplicantDocuments_ContactPersons_ContactPersonId",
                        column: x => x.ContactPersonId,
                        principalSchema: "NatnaAgency",
                        principalTable: "ContactPersons",
                        principalColumn: "ContactPersonId");
                });

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicantDocuments",
                schema: "NatnaAgency");

            migrationBuilder.AddColumn<int>(
                name: "AvailableYear",
                schema: "NatnaAgency",
                table: "ApplicantProfiles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "NatnaDocuments",
                schema: "NatnaAgency",
                columns: table => new
                {
                    NatnaDocumentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicantProfileApplicationRequestId = table.Column<int>(type: "int", nullable: true),
                    ContactPersonId = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DocumentType = table.Column<int>(type: "int", nullable: false),
                    DocumentUserType = table.Column<int>(type: "int", nullable: false),
                    FileExtension = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FilePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReferenceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NatnaDocuments", x => x.NatnaDocumentId);
                    table.ForeignKey(
                        name: "FK_NatnaDocuments_ApplicantProfiles_ApplicantProfileApplicationRequestId",
                        column: x => x.ApplicantProfileApplicationRequestId,
                        principalSchema: "NatnaAgency",
                        principalTable: "ApplicantProfiles",
                        principalColumn: "ApplicationRequestId");
                    table.ForeignKey(
                        name: "FK_NatnaDocuments_ContactPersons_ContactPersonId",
                        column: x => x.ContactPersonId,
                        principalSchema: "NatnaAgency",
                        principalTable: "ContactPersons",
                        principalColumn: "ContactPersonId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_NatnaDocuments_ApplicantProfileApplicationRequestId",
                schema: "NatnaAgency",
                table: "NatnaDocuments",
                column: "ApplicantProfileApplicationRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_NatnaDocuments_ContactPersonId",
                schema: "NatnaAgency",
                table: "NatnaDocuments",
                column: "ContactPersonId");
        }
    }
}
