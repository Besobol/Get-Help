using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Get_Help.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedTicketModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "AgentId",
                table: "Ticket",
                type: "int",
                nullable: true,
                comment: "Agent Identifier",
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "Agent Identifier");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "AgentId",
                table: "Ticket",
                type: "int",
                nullable: false,
                defaultValue: 0,
                comment: "Agent Identifier",
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true,
                oldComment: "Agent Identifier");
        }
    }
}
