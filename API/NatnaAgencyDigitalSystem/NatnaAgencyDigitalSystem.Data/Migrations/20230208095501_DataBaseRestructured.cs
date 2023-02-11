using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NatnaAgencyDigitalSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class DataBaseRestructured : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                schema: "NatnaAgency",
                table: "ApplicantPlacements");

            migrationBuilder.DropColumn(
                name: "Status",
                schema: "NatnaAgency",
                table: "ApplicantLabourOffices");

            migrationBuilder.DropColumn(
                name: "Status",
                schema: "NatnaAgency",
                table: "ApplicantInsurances");

            migrationBuilder.DropColumn(
                name: "Status",
                schema: "NatnaAgency",
                table: "ApplicantFlightTickets");

            migrationBuilder.DropColumn(
                name: "Status",
                schema: "NatnaAgency",
                table: "ApplicantContractAgreements");

            migrationBuilder.AddColumn<string>(
                name: "LabourOfficeDocumentFilePath",
                schema: "NatnaAgency",
                table: "ApplicantLabourOffices",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LetterFilePath",
                schema: "NatnaAgency",
                table: "ApplicantLabourOffices",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ApplicantStatus",
                columns: table => new
                {
                    ApplicantStatusId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicantProfileId = table.Column<int>(type: "int", nullable: false),
                    OfficeLevel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicantStatus", x => x.ApplicantStatusId);
                    table.ForeignKey(
                        name: "FK_ApplicantStatus_ApplicantProfiles_ApplicantProfileId",
                        column: x => x.ApplicantProfileId,
                        principalSchema: "NatnaAgency",
                        principalTable: "ApplicantProfiles",
                        principalColumn: "ApplicantProfileId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicantStatus_ApplicantProfileId",
                table: "ApplicantStatus",
                column: "ApplicantProfileId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicantStatus");

            migrationBuilder.DropColumn(
                name: "LabourOfficeDocumentFilePath",
                schema: "NatnaAgency",
                table: "ApplicantLabourOffices");

            migrationBuilder.DropColumn(
                name: "LetterFilePath",
                schema: "NatnaAgency",
                table: "ApplicantLabourOffices");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                schema: "NatnaAgency",
                table: "ApplicantPlacements",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                schema: "NatnaAgency",
                table: "ApplicantLabourOffices",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                schema: "NatnaAgency",
                table: "ApplicantInsurances",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                schema: "NatnaAgency",
                table: "ApplicantFlightTickets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                schema: "NatnaAgency",
                table: "ApplicantContractAgreements",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
