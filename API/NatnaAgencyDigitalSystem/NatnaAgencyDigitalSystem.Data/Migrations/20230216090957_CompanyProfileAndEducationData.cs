using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NatnaAgencyDigitalSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class CompanyProfileAndEducationData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CompanyProfiles",
                schema: "NatnaAgency",
                columns: table => new
                {
                    CompanyProfileId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AgencyId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NameAm = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddressRegion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Zone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Wereda = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Kebelle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LicenseNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GeneralManager = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telephone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fax = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    POBox = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LogoName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyProfiles", x => x.CompanyProfileId);
                });

            migrationBuilder.CreateTable(
                name: "EducationHistorys",
                schema: "NatnaAgency",
                columns: table => new
                {
                    EducationHistoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicantProfileId = table.Column<int>(type: "int", nullable: false),
                    QualificationType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LevelOfQualification = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    YearCompleted = table.Column<int>(type: "int", nullable: false),
                    Award = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProfessionalSkill = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EducationHistorys", x => x.EducationHistoryId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompanyProfiles",
                schema: "NatnaAgency");

            migrationBuilder.DropTable(
                name: "EducationHistorys",
                schema: "NatnaAgency");
        }
    }
}
