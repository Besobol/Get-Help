using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Get_Help.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RemovedDeleteTypeAndAddedTickletTitle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_DeleteTypes_DeleteTypeId",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Ticket_TicketId",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_Services_DeleteTypes_DeleteTypeId",
                table: "Services");

            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_AspNetUsers_AgentId",
                table: "Ticket");

            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_AspNetUsers_ClientId",
                table: "Ticket");

            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_DeleteTypes_DeleteTypeId",
                table: "Ticket");

            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_Topics_TopicId",
                table: "Ticket");

            migrationBuilder.DropForeignKey(
                name: "FK_Topics_DeleteTypes_DeleteTypeId",
                table: "Topics");

            migrationBuilder.DropTable(
                name: "DeleteTypes");

            migrationBuilder.DropIndex(
                name: "IX_Topics_DeleteTypeId",
                table: "Topics");

            migrationBuilder.DropIndex(
                name: "IX_Services_DeleteTypeId",
                table: "Services");

            migrationBuilder.DropIndex(
                name: "IX_Messages_DeleteTypeId",
                table: "Messages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ticket",
                table: "Ticket");

            migrationBuilder.DropIndex(
                name: "IX_Ticket_DeleteTypeId",
                table: "Ticket");

            migrationBuilder.DropColumn(
                name: "DeleteTypeId",
                table: "Topics");

            migrationBuilder.DropColumn(
                name: "DeleteTypeId",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "DeleteTypeId",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "DeleteTypeId",
                table: "Ticket");

            migrationBuilder.RenameTable(
                name: "Ticket",
                newName: "Tickets");

            migrationBuilder.RenameIndex(
                name: "IX_Ticket_TopicId",
                table: "Tickets",
                newName: "IX_Tickets_TopicId");

            migrationBuilder.RenameIndex(
                name: "IX_Ticket_ClientId",
                table: "Tickets",
                newName: "IX_Tickets_ClientId");

            migrationBuilder.RenameIndex(
                name: "IX_Ticket_AgentId",
                table: "Tickets",
                newName: "IX_Tickets_AgentId");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Tickets",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tickets",
                table: "Tickets",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Tickets_TicketId",
                table: "Messages",
                column: "TicketId",
                principalTable: "Tickets",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_AspNetUsers_AgentId",
                table: "Tickets",
                column: "AgentId",
                principalTable: "AspNetUsers",
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Tickets_TicketId",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_AspNetUsers_AgentId",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_AspNetUsers_ClientId",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Topics_TopicId",
                table: "Tickets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tickets",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Tickets");

            migrationBuilder.RenameTable(
                name: "Tickets",
                newName: "Ticket");

            migrationBuilder.RenameIndex(
                name: "IX_Tickets_TopicId",
                table: "Ticket",
                newName: "IX_Ticket_TopicId");

            migrationBuilder.RenameIndex(
                name: "IX_Tickets_ClientId",
                table: "Ticket",
                newName: "IX_Ticket_ClientId");

            migrationBuilder.RenameIndex(
                name: "IX_Tickets_AgentId",
                table: "Ticket",
                newName: "IX_Ticket_AgentId");

            migrationBuilder.AddColumn<int>(
                name: "DeleteTypeId",
                table: "Topics",
                type: "int",
                nullable: true,
                comment: "Delete Type Identifier");

            migrationBuilder.AddColumn<int>(
                name: "DeleteTypeId",
                table: "Services",
                type: "int",
                nullable: true,
                comment: "Delete Type Identifier");

            migrationBuilder.AddColumn<int>(
                name: "DeleteTypeId",
                table: "Messages",
                type: "int",
                nullable: true,
                comment: "Delete Type Identifier");

            migrationBuilder.AddColumn<int>(
                name: "DeleteTypeId",
                table: "Ticket",
                type: "int",
                nullable: true,
                comment: "Delete Type Identifier");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ticket",
                table: "Ticket",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "DeleteTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Delete Type Identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false, comment: "Delete Type Name")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeleteTypes", x => x.Id);
                },
                comment: "Delete Type");

            migrationBuilder.CreateIndex(
                name: "IX_Topics_DeleteTypeId",
                table: "Topics",
                column: "DeleteTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Services_DeleteTypeId",
                table: "Services",
                column: "DeleteTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_DeleteTypeId",
                table: "Messages",
                column: "DeleteTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_DeleteTypeId",
                table: "Ticket",
                column: "DeleteTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_DeleteTypes_DeleteTypeId",
                table: "Messages",
                column: "DeleteTypeId",
                principalTable: "DeleteTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Ticket_TicketId",
                table: "Messages",
                column: "TicketId",
                principalTable: "Ticket",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Services_DeleteTypes_DeleteTypeId",
                table: "Services",
                column: "DeleteTypeId",
                principalTable: "DeleteTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_AspNetUsers_AgentId",
                table: "Ticket",
                column: "AgentId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_AspNetUsers_ClientId",
                table: "Ticket",
                column: "ClientId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_DeleteTypes_DeleteTypeId",
                table: "Ticket",
                column: "DeleteTypeId",
                principalTable: "DeleteTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_Topics_TopicId",
                table: "Ticket",
                column: "TopicId",
                principalTable: "Topics",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Topics_DeleteTypes_DeleteTypeId",
                table: "Topics",
                column: "DeleteTypeId",
                principalTable: "DeleteTypes",
                principalColumn: "Id");
        }
    }
}
