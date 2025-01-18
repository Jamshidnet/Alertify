using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Alertify.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class regions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Organizations_DistrictId",
                table: "Organizations",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_Organizations_OrganizationClassificationId",
                table: "Organizations",
                column: "OrganizationClassificationId");

            migrationBuilder.CreateIndex(
                name: "IX_Organizations_RegionId",
                table: "Organizations",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_Districts_RegionId",
                table: "Districts",
                column: "RegionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Districts_Regions_RegionId",
                table: "Districts",
                column: "RegionId",
                principalTable: "Regions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Organizations_Districts_DistrictId",
                table: "Organizations",
                column: "DistrictId",
                principalTable: "Districts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Organizations_OrganizationClassifications_OrganizationClass~",
                table: "Organizations",
                column: "OrganizationClassificationId",
                principalTable: "OrganizationClassifications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Organizations_Regions_RegionId",
                table: "Organizations",
                column: "RegionId",
                principalTable: "Regions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Districts_Regions_RegionId",
                table: "Districts");

            migrationBuilder.DropForeignKey(
                name: "FK_Organizations_Districts_DistrictId",
                table: "Organizations");

            migrationBuilder.DropForeignKey(
                name: "FK_Organizations_OrganizationClassifications_OrganizationClass~",
                table: "Organizations");

            migrationBuilder.DropForeignKey(
                name: "FK_Organizations_Regions_RegionId",
                table: "Organizations");

            migrationBuilder.DropIndex(
                name: "IX_Organizations_DistrictId",
                table: "Organizations");

            migrationBuilder.DropIndex(
                name: "IX_Organizations_OrganizationClassificationId",
                table: "Organizations");

            migrationBuilder.DropIndex(
                name: "IX_Organizations_RegionId",
                table: "Organizations");

            migrationBuilder.DropIndex(
                name: "IX_Districts_RegionId",
                table: "Districts");
        }
    }
}
