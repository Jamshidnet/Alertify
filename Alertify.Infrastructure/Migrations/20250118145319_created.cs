using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Alertify.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class created : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LastModified",
                table: "UnsentMessages",
                newName: "LastModifiedAt");

            migrationBuilder.RenameColumn(
                name: "Created",
                table: "UnsentMessages",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "LastModified",
                table: "Statuses",
                newName: "LastModifiedAt");

            migrationBuilder.RenameColumn(
                name: "Created",
                table: "Statuses",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "LastModified",
                table: "SmsTemplates",
                newName: "LastModifiedAt");

            migrationBuilder.RenameColumn(
                name: "Created",
                table: "SmsTemplates",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "LastModified",
                table: "SmsManagers",
                newName: "LastModifiedAt");

            migrationBuilder.RenameColumn(
                name: "Created",
                table: "SmsManagers",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "LastModified",
                table: "Regions",
                newName: "LastModifiedAt");

            migrationBuilder.RenameColumn(
                name: "Created",
                table: "Regions",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "LastModified",
                table: "Organizations",
                newName: "LastModifiedAt");

            migrationBuilder.RenameColumn(
                name: "Created",
                table: "Organizations",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "LastModified",
                table: "OrganizationClassifications",
                newName: "LastModifiedAt");

            migrationBuilder.RenameColumn(
                name: "Created",
                table: "OrganizationClassifications",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "LastModified",
                table: "MessageLogs",
                newName: "LastModifiedAt");

            migrationBuilder.RenameColumn(
                name: "Created",
                table: "MessageLogs",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "LastModified",
                table: "Districts",
                newName: "LastModifiedAt");

            migrationBuilder.RenameColumn(
                name: "Created",
                table: "Districts",
                newName: "CreatedAt");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LastModifiedAt",
                table: "UnsentMessages",
                newName: "LastModified");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "UnsentMessages",
                newName: "Created");

            migrationBuilder.RenameColumn(
                name: "LastModifiedAt",
                table: "Statuses",
                newName: "LastModified");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "Statuses",
                newName: "Created");

            migrationBuilder.RenameColumn(
                name: "LastModifiedAt",
                table: "SmsTemplates",
                newName: "LastModified");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "SmsTemplates",
                newName: "Created");

            migrationBuilder.RenameColumn(
                name: "LastModifiedAt",
                table: "SmsManagers",
                newName: "LastModified");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "SmsManagers",
                newName: "Created");

            migrationBuilder.RenameColumn(
                name: "LastModifiedAt",
                table: "Regions",
                newName: "LastModified");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "Regions",
                newName: "Created");

            migrationBuilder.RenameColumn(
                name: "LastModifiedAt",
                table: "Organizations",
                newName: "LastModified");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "Organizations",
                newName: "Created");

            migrationBuilder.RenameColumn(
                name: "LastModifiedAt",
                table: "OrganizationClassifications",
                newName: "LastModified");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "OrganizationClassifications",
                newName: "Created");

            migrationBuilder.RenameColumn(
                name: "LastModifiedAt",
                table: "MessageLogs",
                newName: "LastModified");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "MessageLogs",
                newName: "Created");

            migrationBuilder.RenameColumn(
                name: "LastModifiedAt",
                table: "Districts",
                newName: "LastModified");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "Districts",
                newName: "Created");
        }
    }
}
