using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Get_Help.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class DataModelsConfiguration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Tickets_TicketId",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_AspNetUsers_ClientId",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Topics_TopicId",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_Topics_Services_ServiceId",
                table: "Topics");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Tickets_TicketId",
                table: "Messages",
                column: "TicketId",
                principalTable: "Tickets",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_AspNetUsers_ClientId",
                table: "Tickets",
                column: "ClientId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Topics_TopicId",
                table: "Tickets",
                column: "TopicId",
                principalTable: "Topics",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Topics_Services_ServiceId",
                table: "Topics",
                column: "ServiceId",
                principalTable: "Services",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Tickets_TicketId",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_AspNetUsers_ClientId",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Topics_TopicId",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_Topics_Services_ServiceId",
                table: "Topics");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Discriminator", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { 1, null, "AgentRole", "Agent", "AGENT" },
                    { 2, null, "ClientRole", "Client", "CLIENT" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Tickets_TicketId",
                table: "Messages",
                column: "TicketId",
                principalTable: "Tickets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_AspNetUsers_ClientId",
                table: "Tickets",
                column: "ClientId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Topics_TopicId",
                table: "Tickets",
                column: "TopicId",
                principalTable: "Topics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Topics_Services_ServiceId",
                table: "Topics",
                column: "ServiceId",
                principalTable: "Services",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
