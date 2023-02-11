using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NatnaAgencyDigitalSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class ExpJobUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_ExperiencedJobs_CommonJobId",
                schema: "NatnaAgency",
                table: "ExperiencedJobs",
                column: "CommonJobId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExperiencedJobs_CommonJobs_CommonJobId",
                schema: "NatnaAgency",
                table: "ExperiencedJobs",
                column: "CommonJobId",
                principalSchema: "NatnaAgency",
                principalTable: "CommonJobs",
                principalColumn: "CommonJobId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExperiencedJobs_CommonJobs_CommonJobId",
                schema: "NatnaAgency",
                table: "ExperiencedJobs");

            migrationBuilder.DropIndex(
                name: "IX_ExperiencedJobs_CommonJobId",
                schema: "NatnaAgency",
                table: "ExperiencedJobs");
        }
    }
}
