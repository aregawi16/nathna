using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NatnaAgencyDigitalSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class CocAndPreflightTraining : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CoCs",
                schema: "NatnaAgency",
                columns: table => new
                {
                    CoCId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrainedPlaceName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrainedPlaceAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrainedSkill = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CertificateTakenPlaceName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CertificateTakenAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoCs", x => x.CoCId);
                });

            migrationBuilder.CreateTable(
                name: "FingerPrintInvestigations",
                schema: "NatnaAgency",
                columns: table => new
                {
                    FingerPrintInvestigationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FingerPrintInvestigations", x => x.FingerPrintInvestigationId);
                });

            migrationBuilder.CreateTable(
                name: "PreFlightTrainings",
                schema: "NatnaAgency",
                columns: table => new
                {
                    PreFlightTrainingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ScheduledDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Place = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PreFlightTrainings", x => x.PreFlightTrainingId);
                });

            migrationBuilder.CreateTable(
                name: "FingerPrintInvestigationPeople",
                schema: "NatnaAgency",
                columns: table => new
                {
                    FingerPrintInvestigationPersonId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FingerPrintInvestigationId = table.Column<int>(type: "int", nullable: false),
                    ApplicantProfileId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FingerPrintInvestigationPeople", x => x.FingerPrintInvestigationPersonId);
                    table.ForeignKey(
                        name: "FK_FingerPrintInvestigationPeople_ApplicantProfiles_ApplicantProfileId",
                        column: x => x.ApplicantProfileId,
                        principalSchema: "NatnaAgency",
                        principalTable: "ApplicantProfiles",
                        principalColumn: "ApplicantProfileId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FingerPrintInvestigationPeople_FingerPrintInvestigations_FingerPrintInvestigationId",
                        column: x => x.FingerPrintInvestigationId,
                        principalSchema: "NatnaAgency",
                        principalTable: "FingerPrintInvestigations",
                        principalColumn: "FingerPrintInvestigationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PreFlightTrainingPeople",
                schema: "NatnaAgency",
                columns: table => new
                {
                    PreFlightTrainingPersonId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PreFlightTrainingId = table.Column<int>(type: "int", nullable: false),
                    ApplicantProfileId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PreFlightTrainingPeople", x => x.PreFlightTrainingPersonId);
                    table.ForeignKey(
                        name: "FK_PreFlightTrainingPeople_ApplicantProfiles_ApplicantProfileId",
                        column: x => x.ApplicantProfileId,
                        principalSchema: "NatnaAgency",
                        principalTable: "ApplicantProfiles",
                        principalColumn: "ApplicantProfileId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PreFlightTrainingPeople_PreFlightTrainings_PreFlightTrainingId",
                        column: x => x.PreFlightTrainingId,
                        principalSchema: "NatnaAgency",
                        principalTable: "PreFlightTrainings",
                        principalColumn: "PreFlightTrainingId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FingerPrintInvestigationPeople_ApplicantProfileId",
                schema: "NatnaAgency",
                table: "FingerPrintInvestigationPeople",
                column: "ApplicantProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_FingerPrintInvestigationPeople_FingerPrintInvestigationId",
                schema: "NatnaAgency",
                table: "FingerPrintInvestigationPeople",
                column: "FingerPrintInvestigationId");

            migrationBuilder.CreateIndex(
                name: "IX_PreFlightTrainingPeople_ApplicantProfileId",
                schema: "NatnaAgency",
                table: "PreFlightTrainingPeople",
                column: "ApplicantProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_PreFlightTrainingPeople_PreFlightTrainingId",
                schema: "NatnaAgency",
                table: "PreFlightTrainingPeople",
                column: "PreFlightTrainingId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CoCs",
                schema: "NatnaAgency");

            migrationBuilder.DropTable(
                name: "FingerPrintInvestigationPeople",
                schema: "NatnaAgency");

            migrationBuilder.DropTable(
                name: "PreFlightTrainingPeople",
                schema: "NatnaAgency");

            migrationBuilder.DropTable(
                name: "FingerPrintInvestigations",
                schema: "NatnaAgency");

            migrationBuilder.DropTable(
                name: "PreFlightTrainings",
                schema: "NatnaAgency");
        }
    }
}
