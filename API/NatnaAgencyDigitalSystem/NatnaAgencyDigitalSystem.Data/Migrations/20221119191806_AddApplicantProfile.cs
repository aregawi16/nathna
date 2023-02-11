using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NatnaAgencyDigitalSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddApplicantProfile : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "NatnaAgency");

            migrationBuilder.CreateTable(
                name: "CommonJobs",
                schema: "NatnaAgency",
                columns: table => new
                {
                    CommonJobId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommonJobs", x => x.CommonJobId);
                });

            migrationBuilder.CreateTable(
                name: "ContactPersons",
                schema: "NatnaAgency",
                columns: table => new
                {
                    ContactPersonId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationRequestId = table.Column<int>(type: "int", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactPersons", x => x.ContactPersonId);
                });

            migrationBuilder.CreateTable(
                name: "ApplicantProfiles",
                schema: "NatnaAgency",
                columns: table => new
                {
                    ApplicationRequestId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MiddleName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastlName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nationality = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReferenceNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MaritalStatus = table.Column<int>(type: "int", nullable: false),
                    PassportNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DoB = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PassportIssueDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PassportExpireDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AvailableYear = table.Column<int>(type: "int", nullable: false),
                    Religion = table.Column<int>(type: "int", nullable: false),
                    NoOfChildren = table.Column<int>(type: "int", nullable: true),
                    Height = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Weight = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ContactPersonId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicantProfiles", x => x.ApplicationRequestId);
                    table.ForeignKey(
                        name: "FK_ApplicantProfiles_ContactPersons_ContactPersonId",
                        column: x => x.ContactPersonId,
                        principalSchema: "NatnaAgency",
                        principalTable: "ContactPersons",
                        principalColumn: "ContactPersonId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExperiencedJobs",
                schema: "NatnaAgency",
                columns: table => new
                {
                    ExperiencedJobId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationRequestId = table.Column<int>(type: "int", nullable: false),
                    CommonJobId = table.Column<int>(type: "int", nullable: false),
                    HaveExperience = table.Column<bool>(type: "bit", nullable: false),
                    ApplicantProfileApplicationRequestId = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExperiencedJobs", x => x.ExperiencedJobId);
                    table.ForeignKey(
                        name: "FK_ExperiencedJobs_ApplicantProfiles_ApplicantProfileApplicationRequestId",
                        column: x => x.ApplicantProfileApplicationRequestId,
                        principalSchema: "NatnaAgency",
                        principalTable: "ApplicantProfiles",
                        principalColumn: "ApplicationRequestId");
                });

            migrationBuilder.CreateTable(
                name: "NatnaDocuments",
                schema: "NatnaAgency",
                columns: table => new
                {
                    NatnaDocumentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReferenceId = table.Column<int>(type: "int", nullable: false),
                    DocumentUserType = table.Column<int>(type: "int", nullable: false),
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

            migrationBuilder.CreateTable(
                name: "WorkExperiences",
                schema: "NatnaAgency",
                columns: table => new
                {
                    WorkExperienceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationRequestId = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JobDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApplicantProfileApplicationRequestId = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkExperiences", x => x.WorkExperienceId);
                    table.ForeignKey(
                        name: "FK_WorkExperiences_ApplicantProfiles_ApplicantProfileApplicationRequestId",
                        column: x => x.ApplicantProfileApplicationRequestId,
                        principalSchema: "NatnaAgency",
                        principalTable: "ApplicantProfiles",
                        principalColumn: "ApplicationRequestId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicantProfiles_ContactPersonId",
                schema: "NatnaAgency",
                table: "ApplicantProfiles",
                column: "ContactPersonId");

            migrationBuilder.CreateIndex(
                name: "IX_ExperiencedJobs_ApplicantProfileApplicationRequestId",
                schema: "NatnaAgency",
                table: "ExperiencedJobs",
                column: "ApplicantProfileApplicationRequestId");

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

            migrationBuilder.CreateIndex(
                name: "IX_WorkExperiences_ApplicantProfileApplicationRequestId",
                schema: "NatnaAgency",
                table: "WorkExperiences",
                column: "ApplicantProfileApplicationRequestId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CommonJobs",
                schema: "NatnaAgency");

            migrationBuilder.DropTable(
                name: "ExperiencedJobs",
                schema: "NatnaAgency");

            migrationBuilder.DropTable(
                name: "NatnaDocuments",
                schema: "NatnaAgency");

            migrationBuilder.DropTable(
                name: "WorkExperiences",
                schema: "NatnaAgency");

            migrationBuilder.DropTable(
                name: "ApplicantProfiles",
                schema: "NatnaAgency");

            migrationBuilder.DropTable(
                name: "ContactPersons",
                schema: "NatnaAgency");
        }
    }
}
