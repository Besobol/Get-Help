using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Get_Help.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Discriminator", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { 1, null, "AgentRole", "Agent", "AGENT" },
                    { 2, null, "ClientRole", "Client", "CLIENT" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { 2, 0, "090bd9a0-b898-4020-936a-ee23c6bb6a09", "Agent", "Smith@agent.com", false, false, null, "Agent Smith", "SMITH@AGENT.COM", "SMITH@AGENT.COM", "AQAAAAIAAYagAAAAEKFVSsEJa9vA6nWTHbdGfTE1YlfvBh7WhByGcY31C6lC/YAUmorO4PAjSt+imytx2Q==", null, false, "f8a039b4-97d4-48c6-8c3b-14fad8a3f142", false, "Smith@agent.com" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { 3, 0, "03e98d4c-e097-4934-8438-1f4270ac8a12", "Client", "JDoe@user.com", false, false, null, "JDOE@USER.COM", "JDOE", "AQAAAAIAAYagAAAAEGu0sSs6hC/LRn7+iUMRN8Gj8QCNL/oqJVqiL13dsoeR5v4EFLFAlO0DR+qBAgEKXQ==", null, false, "99187c04-e717-4f2e-b890-6bf5ffc59057", false, "JDoe" });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "Id", "ImgUrl", "Name" },
                values: new object[,]
                {
                    { 1, "https://nepirockcastle.com/wp-content/uploads/2019/03/Technopolis-bg-logo.png", "Technopolis" },
                    { 2, "https://th.bing.com/th/id/OIP.kxBLq5pbWza-QlJHrOyz6QHaDt?rs=1&pid=ImgDetMain", "Technomarket" },
                    { 3, "Images/ServiceImages/Amazon.jpg", "Amazon" },
                    { 4, "Images/ServiceImages/eBay.png", "eBay" }
                });

            migrationBuilder.InsertData(
                table: "Topics",
                columns: new[] { "Id", "Name", "ServiceId" },
                values: new object[,]
                {
                    { 1, "How to cancel my purchase?", 1 },
                    { 2, "Account problems", 1 },
                    { 3, "Payment plans", 1 },
                    { 4, "Technical advice", 1 }
                });

            migrationBuilder.InsertData(
                table: "Tickets",
                columns: new[] { "Id", "AgentId", "ClientId", "TimeClosed", "TimeOpened", "Title", "TopicId" },
                values: new object[,]
                {
                    { 1, null, 3, null, new DateTime(2024, 4, 20, 18, 33, 58, 110, DateTimeKind.Local).AddTicks(4192), "What are good PC parts at the moment", 4 },
                    { 2, null, 3, null, new DateTime(2024, 1, 16, 18, 33, 58, 110, DateTimeKind.Local).AddTicks(4200), "How to find a good fridge", 4 },
                    { 3, null, 3, null, new DateTime(2024, 4, 5, 18, 33, 58, 110, DateTimeKind.Local).AddTicks(4201), "Can i use this microwave as an oven", 4 },
                    { 4, null, 3, null, new DateTime(2024, 4, 10, 18, 33, 58, 110, DateTimeKind.Local).AddTicks(4203), "What are good deals at the moment", 4 },
                    { 5, null, 3, null, new DateTime(2024, 4, 10, 18, 33, 58, 110, DateTimeKind.Local).AddTicks(4205), "What are good deals at the moment", 4 },
                    { 6, null, 3, null, new DateTime(2024, 4, 10, 18, 33, 58, 110, DateTimeKind.Local).AddTicks(4206), "What are good deals at the moment", 4 },
                    { 7, null, 3, null, new DateTime(2024, 4, 10, 18, 33, 58, 110, DateTimeKind.Local).AddTicks(4208), "What are good deals at the moment", 4 },
                    { 8, null, 3, null, new DateTime(2024, 4, 10, 18, 33, 58, 110, DateTimeKind.Local).AddTicks(4209), "What are good deals at the moment", 4 },
                    { 9, null, 3, null, new DateTime(2024, 4, 10, 18, 33, 58, 110, DateTimeKind.Local).AddTicks(4211), "What are good deals at the moment", 4 },
                    { 10, null, 3, null, new DateTime(2024, 4, 10, 18, 33, 58, 110, DateTimeKind.Local).AddTicks(4213), "What are good deals at the moment", 4 },
                    { 11, null, 3, null, new DateTime(2024, 4, 10, 18, 33, 58, 110, DateTimeKind.Local).AddTicks(4215), "What are good deals at the moment", 4 },
                    { 12, null, 3, null, new DateTime(2024, 4, 10, 18, 33, 58, 110, DateTimeKind.Local).AddTicks(4216), "What are good deals at the moment", 4 },
                    { 13, null, 3, null, new DateTime(2024, 4, 10, 18, 33, 58, 110, DateTimeKind.Local).AddTicks(4218), "What are good deals at the moment", 4 },
                    { 14, null, 3, null, new DateTime(2024, 4, 10, 18, 33, 58, 110, DateTimeKind.Local).AddTicks(4219), "What are good deals at the moment", 4 },
                    { 15, null, 3, null, new DateTime(2024, 4, 10, 18, 33, 58, 110, DateTimeKind.Local).AddTicks(4221), "What are good deals at the moment", 4 },
                    { 16, null, 3, null, new DateTime(2024, 4, 10, 18, 33, 58, 110, DateTimeKind.Local).AddTicks(4222), "What are good deals at the moment", 4 },
                    { 17, null, 3, null, new DateTime(2024, 4, 10, 18, 33, 58, 110, DateTimeKind.Local).AddTicks(4224), "What are good deals at the moment", 4 },
                    { 18, null, 3, null, new DateTime(2024, 4, 10, 18, 33, 58, 110, DateTimeKind.Local).AddTicks(4225), "What are good deals at the moment", 4 },
                    { 19, null, 3, null, new DateTime(2024, 4, 10, 18, 33, 58, 110, DateTimeKind.Local).AddTicks(4227), "What are good deals at the moment", 4 },
                    { 20, null, 3, null, new DateTime(2024, 4, 10, 18, 33, 58, 110, DateTimeKind.Local).AddTicks(4228), "What are good deals at the moment", 4 },
                    { 21, null, 3, null, new DateTime(2024, 4, 10, 18, 33, 58, 110, DateTimeKind.Local).AddTicks(4230), "What are good deals at the moment", 4 },
                    { 22, null, 3, null, new DateTime(2024, 4, 10, 18, 33, 58, 110, DateTimeKind.Local).AddTicks(4231), "What are good deals at the moment", 4 },
                    { 23, null, 3, null, new DateTime(2024, 4, 10, 18, 33, 58, 110, DateTimeKind.Local).AddTicks(4233), "What are good deals at the moment", 4 },
                    { 24, null, 3, null, new DateTime(2024, 4, 10, 18, 33, 58, 110, DateTimeKind.Local).AddTicks(4234), "What are good deals at the moment", 4 },
                    { 25, null, 3, null, new DateTime(2024, 4, 10, 18, 33, 58, 110, DateTimeKind.Local).AddTicks(4236), "What are good deals at the moment", 4 },
                    { 26, null, 3, null, new DateTime(2024, 4, 10, 18, 33, 58, 110, DateTimeKind.Local).AddTicks(4292), "What are good deals at the moment", 4 },
                    { 27, null, 3, null, new DateTime(2024, 4, 10, 18, 33, 58, 110, DateTimeKind.Local).AddTicks(4294), "What are good deals at the moment", 4 },
                    { 28, null, 3, null, new DateTime(2024, 4, 10, 18, 33, 58, 110, DateTimeKind.Local).AddTicks(4296), "What are good deals at the moment", 4 },
                    { 29, null, 3, null, new DateTime(2024, 4, 10, 18, 33, 58, 110, DateTimeKind.Local).AddTicks(4298), "What are good deals at the moment", 4 },
                    { 30, null, 3, null, new DateTime(2024, 4, 10, 18, 33, 58, 110, DateTimeKind.Local).AddTicks(4300), "What are good deals at the moment", 4 },
                    { 31, null, 3, null, new DateTime(2024, 4, 10, 18, 33, 58, 110, DateTimeKind.Local).AddTicks(4301), "What are good deals at the moment", 4 }
                });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "AgentId", "ClientId", "Content", "SentTime", "TicketId" },
                values: new object[,]
                {
                    { 1, null, 3, "I need advice about my question", new DateTime(2024, 4, 25, 18, 33, 58, 227, DateTimeKind.Local).AddTicks(6729), 1 },
                    { 2, 2, null, "Answer", new DateTime(2024, 4, 25, 18, 33, 58, 227, DateTimeKind.Local).AddTicks(6730), 1 },
                    { 3, null, 3, "Question", new DateTime(2024, 4, 25, 18, 33, 58, 227, DateTimeKind.Local).AddTicks(6732), 1 },
                    { 4, 2, null, "Confusion?", new DateTime(2024, 4, 25, 18, 33, 58, 227, DateTimeKind.Local).AddTicks(6734), 1 },
                    { 5, null, 3, "Paragraph of explanation: The morning sun gently kissed the dewy grass as birds chirped melodies of a new day. Amidst the tranquility, whispers of adventure beckoned, enticing souls to explore the unknown. With each step, the world unfolded, revealing secrets waiting to be discovered.\r\nThe world hummed with the rhythm of life, where each heartbeat echoed a tale untold. Beneath the azure sky, dreams danced like leaves in the wind, weaving stories of hope and resilience. In the symphony of existence, every moment held the promise of infinite possibilities, waiting to be embraced.", new DateTime(2024, 4, 25, 18, 33, 58, 227, DateTimeKind.Local).AddTicks(6735), 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
