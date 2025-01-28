using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Alertify.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class templateId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "TemplateId",
                table: "SmsTemplates",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TemplateId",
                table: "SmsTemplates");
        }
    }
}
