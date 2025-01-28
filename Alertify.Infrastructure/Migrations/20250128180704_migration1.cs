using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Alertify.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class migration1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Message",
                table: "SmsTemplates",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Organizations",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Organizations",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SecretKey",
                table: "Organizations",
                type: "text",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UnsentMessages_SmsManagerId",
                table: "UnsentMessages",
                column: "SmsManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_SmsTemplates_OrganizationId",
                table: "SmsTemplates",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_SmsManagers_TemplateId",
                table: "SmsManagers",
                column: "TemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_MessageLogs_OrganizationId",
                table: "MessageLogs",
                column: "OrganizationId");

            migrationBuilder.AddForeignKey(
                name: "FK_MessageLogs_Organizations_OrganizationId",
                table: "MessageLogs",
                column: "OrganizationId",
                principalTable: "Organizations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SmsManagers_SmsTemplates_TemplateId",
                table: "SmsManagers",
                column: "TemplateId",
                principalTable: "SmsTemplates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SmsTemplates_Organizations_OrganizationId",
                table: "SmsTemplates",
                column: "OrganizationId",
                principalTable: "Organizations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UnsentMessages_SmsManagers_SmsManagerId",
                table: "UnsentMessages",
                column: "SmsManagerId",
                principalTable: "SmsManagers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MessageLogs_Organizations_OrganizationId",
                table: "MessageLogs");

            migrationBuilder.DropForeignKey(
                name: "FK_SmsManagers_SmsTemplates_TemplateId",
                table: "SmsManagers");

            migrationBuilder.DropForeignKey(
                name: "FK_SmsTemplates_Organizations_OrganizationId",
                table: "SmsTemplates");

            migrationBuilder.DropForeignKey(
                name: "FK_UnsentMessages_SmsManagers_SmsManagerId",
                table: "UnsentMessages");

            migrationBuilder.DropIndex(
                name: "IX_UnsentMessages_SmsManagerId",
                table: "UnsentMessages");

            migrationBuilder.DropIndex(
                name: "IX_SmsTemplates_OrganizationId",
                table: "SmsTemplates");

            migrationBuilder.DropIndex(
                name: "IX_SmsManagers_TemplateId",
                table: "SmsManagers");

            migrationBuilder.DropIndex(
                name: "IX_MessageLogs_OrganizationId",
                table: "MessageLogs");

            migrationBuilder.DropColumn(
                name: "Message",
                table: "SmsTemplates");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Organizations");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Organizations");

            migrationBuilder.DropColumn(
                name: "SecretKey",
                table: "Organizations");
        }
    }
}
