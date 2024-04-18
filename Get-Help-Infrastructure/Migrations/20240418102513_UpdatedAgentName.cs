using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Get_Help_Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedAgentName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Agents");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Agents");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Agents",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                comment: "Agent Name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Agents");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Agents",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                comment: "Agent First Name");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Agents",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                comment: "Agent Last Name");
        }
    }
}
