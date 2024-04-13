using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Get_Help_Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialModelsAdd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Agents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Agent Identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Agent First Name"),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Agent Last Name"),
                    UserId = table.Column<int>(type: "int", nullable: false, comment: "Agent User Id")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Agents_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Application Agent");

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Client Identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false, comment: "Client User Identifier")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Clients_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Application Client");

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

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Service Identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Service Name"),
                    ImgUrl = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Service title Image Url"),
                    DeleteTypeId = table.Column<int>(type: "int", nullable: false, comment: "Delete Type Identifier")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Services_DeleteTypes_DeleteTypeId",
                        column: x => x.DeleteTypeId,
                        principalTable: "DeleteTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Service");

            migrationBuilder.CreateTable(
                name: "Topics",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Topic Identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false, comment: "Topic Title"),
                    ServiceId = table.Column<int>(type: "int", nullable: false, comment: "Service Identifier"),
                    DeleteTypeId = table.Column<int>(type: "int", nullable: false, comment: "Delete Type Identifier")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Topics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Topics_DeleteTypes_DeleteTypeId",
                        column: x => x.DeleteTypeId,
                        principalTable: "DeleteTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Topics_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "Id");
                },
                comment: "Service Topic");

            migrationBuilder.CreateTable(
                name: "Ticket",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Ticket Identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AgentId = table.Column<int>(type: "int", nullable: false, comment: "Agent Identifier"),
                    ClientId = table.Column<int>(type: "int", nullable: false, comment: "Client Identifier"),
                    TimeOpened = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Time of opening the Ticket"),
                    TimeClosed = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "Time of closing the Ticket"),
                    TopicId = table.Column<int>(type: "int", nullable: false, comment: "Topic Identifier"),
                    DeleteTypeId = table.Column<int>(type: "int", nullable: false, comment: "Delete Type Identifier")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ticket", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ticket_Agents_AgentId",
                        column: x => x.AgentId,
                        principalTable: "Agents",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Ticket_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Ticket_DeleteTypes_DeleteTypeId",
                        column: x => x.DeleteTypeId,
                        principalTable: "DeleteTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ticket_Topics_TopicId",
                        column: x => x.TopicId,
                        principalTable: "Topics",
                        principalColumn: "Id");
                },
                comment: "Ticket");

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Message Identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(type: "nvarchar(600)", maxLength: 600, nullable: false, comment: "Message Content"),
                    TicketId = table.Column<int>(type: "int", nullable: false, comment: "Ticket Identifier"),
                    AgentId = table.Column<int>(type: "int", nullable: false, comment: "Agent Identifier"),
                    ClientId = table.Column<int>(type: "int", nullable: false, comment: "Client Identifier"),
                    DeleteTypeId = table.Column<int>(type: "int", nullable: false, comment: "Delete Type Identifier")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Messages_Agents_AgentId",
                        column: x => x.AgentId,
                        principalTable: "Agents",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Messages_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Messages_DeleteTypes_DeleteTypeId",
                        column: x => x.DeleteTypeId,
                        principalTable: "DeleteTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Messages_Ticket_TicketId",
                        column: x => x.TicketId,
                        principalTable: "Ticket",
                        principalColumn: "Id");
                },
                comment: "Ticket Message");

            migrationBuilder.CreateIndex(
                name: "IX_Agents_UserId",
                table: "Agents",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_UserId",
                table: "Clients",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_AgentId",
                table: "Messages",
                column: "AgentId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_ClientId",
                table: "Messages",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_DeleteTypeId",
                table: "Messages",
                column: "DeleteTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_TicketId",
                table: "Messages",
                column: "TicketId");

            migrationBuilder.CreateIndex(
                name: "IX_Services_DeleteTypeId",
                table: "Services",
                column: "DeleteTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_AgentId",
                table: "Ticket",
                column: "AgentId");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_ClientId",
                table: "Ticket",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_DeleteTypeId",
                table: "Ticket",
                column: "DeleteTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_TopicId",
                table: "Ticket",
                column: "TopicId");

            migrationBuilder.CreateIndex(
                name: "IX_Topics_DeleteTypeId",
                table: "Topics",
                column: "DeleteTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Topics_ServiceId",
                table: "Topics",
                column: "ServiceId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "Ticket");

            migrationBuilder.DropTable(
                name: "Agents");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "Topics");

            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropTable(
                name: "DeleteTypes");
        }
    }
}
