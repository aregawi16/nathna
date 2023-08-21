using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NatnaAgencyDigitalSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class NotificationAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AgencyId",
                schema: "NatnaAgency",
                table: "CompanyProfiles");

            migrationBuilder.RenameColumn(
                name: "AddressRegion",
                schema: "NatnaAgency",
                table: "CompanyProfiles",
                newName: "Address");

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.RenameColumn(
                name: "Address",
                schema: "NatnaAgency",
                table: "CompanyProfiles",
                newName: "AddressRegion");

            migrationBuilder.AddColumn<int>(
                name: "AgencyId",
                schema: "NatnaAgency",
                table: "CompanyProfiles",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
