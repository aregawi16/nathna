using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NatnaAgencyDigitalSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class RmBaseModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                schema: "NatnaAgency",
                table: "WorkExperiences");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                schema: "NatnaAgency",
                table: "WorkExperiences");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                schema: "NatnaAgency",
                table: "WorkExperiences");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                schema: "NatnaAgency",
                table: "WorkExperiences");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                schema: "NatnaAgency",
                table: "ExperiencedJobs");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                schema: "NatnaAgency",
                table: "ExperiencedJobs");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                schema: "NatnaAgency",
                table: "ExperiencedJobs");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                schema: "NatnaAgency",
                table: "ExperiencedJobs");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                schema: "NatnaAgency",
                table: "ContactPersons");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                schema: "NatnaAgency",
                table: "ContactPersons");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                schema: "NatnaAgency",
                table: "ContactPersons");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                schema: "NatnaAgency",
                table: "ContactPersons");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                schema: "NatnaAgency",
                table: "ApplicantDocuments");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                schema: "NatnaAgency",
                table: "ApplicantDocuments");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                schema: "NatnaAgency",
                table: "ApplicantDocuments");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                schema: "NatnaAgency",
                table: "ApplicantDocuments");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                schema: "NatnaAgency",
                table: "WorkExperiences",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                schema: "NatnaAgency",
                table: "WorkExperiences",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                schema: "NatnaAgency",
                table: "WorkExperiences",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                schema: "NatnaAgency",
                table: "WorkExperiences",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                schema: "NatnaAgency",
                table: "ExperiencedJobs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                schema: "NatnaAgency",
                table: "ExperiencedJobs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                schema: "NatnaAgency",
                table: "ExperiencedJobs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                schema: "NatnaAgency",
                table: "ExperiencedJobs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                schema: "NatnaAgency",
                table: "ContactPersons",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                schema: "NatnaAgency",
                table: "ContactPersons",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                schema: "NatnaAgency",
                table: "ContactPersons",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                schema: "NatnaAgency",
                table: "ContactPersons",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                schema: "NatnaAgency",
                table: "ApplicantDocuments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                schema: "NatnaAgency",
                table: "ApplicantDocuments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                schema: "NatnaAgency",
                table: "ApplicantDocuments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                schema: "NatnaAgency",
                table: "ApplicantDocuments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
