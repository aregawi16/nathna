using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NatnaAgencyDigitalSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class SauMigUpdates : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExperiencedJobs",
                schema: "NatnaAgency");

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartDate",
                schema: "NatnaAgency",
                table: "WorkExperiences",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndDate",
                schema: "NatnaAgency",
                table: "WorkExperiences",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<int>(
                name: "Duration",
                schema: "NatnaAgency",
                table: "WorkExperiences",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "YearCompleted",
                schema: "NatnaAgency",
                table: "EducationHistorys",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                schema: "NatnaAgency",
                table: "ContactPersons",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "ApplicantVideoPath",
                schema: "NatnaAgency",
                table: "ApplicantDocuments",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "ApplicantSmallPhotoPath",
                schema: "NatnaAgency",
                table: "ApplicantDocuments",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "ApplicantIdFilePath",
                schema: "NatnaAgency",
                table: "ApplicantDocuments",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "ApplicantFullPhotoPath",
                schema: "NatnaAgency",
                table: "ApplicantDocuments",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Duration",
                schema: "NatnaAgency",
                table: "WorkExperiences");

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartDate",
                schema: "NatnaAgency",
                table: "WorkExperiences",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndDate",
                schema: "NatnaAgency",
                table: "WorkExperiences",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "YearCompleted",
                schema: "NatnaAgency",
                table: "EducationHistorys",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                schema: "NatnaAgency",
                table: "ContactPersons",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ApplicantVideoPath",
                schema: "NatnaAgency",
                table: "ApplicantDocuments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ApplicantSmallPhotoPath",
                schema: "NatnaAgency",
                table: "ApplicantDocuments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ApplicantIdFilePath",
                schema: "NatnaAgency",
                table: "ApplicantDocuments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ApplicantFullPhotoPath",
                schema: "NatnaAgency",
                table: "ApplicantDocuments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "ExperiencedJobs",
                schema: "NatnaAgency",
                columns: table => new
                {
                    ExperiencedJobId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CommonJobId = table.Column<int>(type: "int", nullable: false),
                    ApplicantProfileId = table.Column<int>(type: "int", nullable: false),
                    HaveExperience = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExperiencedJobs", x => x.ExperiencedJobId);
                    table.ForeignKey(
                        name: "FK_ExperiencedJobs_ApplicantProfiles_ApplicantProfileId",
                        column: x => x.ApplicantProfileId,
                        principalSchema: "NatnaAgency",
                        principalTable: "ApplicantProfiles",
                        principalColumn: "ApplicantProfileId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExperiencedJobs_CommonJobs_CommonJobId",
                        column: x => x.CommonJobId,
                        principalSchema: "NatnaAgency",
                        principalTable: "CommonJobs",
                        principalColumn: "CommonJobId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExperiencedJobs_ApplicantProfileId",
                schema: "NatnaAgency",
                table: "ExperiencedJobs",
                column: "ApplicantProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_ExperiencedJobs_CommonJobId",
                schema: "NatnaAgency",
                table: "ExperiencedJobs",
                column: "CommonJobId");
        }
    }
}
