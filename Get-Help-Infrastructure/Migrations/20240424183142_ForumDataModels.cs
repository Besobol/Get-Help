using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Get_Help.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ForumDataModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ForumUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Forum User identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientId = table.Column<int>(type: "int", nullable: false, comment: "Client user Id owner of forum user")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ForumUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ForumUsers_AspNetUsers_ClientId",
                        column: x => x.ClientId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Forum User extension");

            migrationBuilder.CreateTable(
                name: "ForumTopics",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Forum Topic identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false, comment: "Forum Topic Title"),
                    TopicCreatorId = table.Column<int>(type: "int", nullable: true, comment: "Forum User Id that created the topic")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ForumTopics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ForumTopics_ForumUsers_TopicCreatorId",
                        column: x => x.TopicCreatorId,
                        principalTable: "ForumUsers",
                        principalColumn: "Id");
                },
                comment: "Forum Topic");

            migrationBuilder.CreateTable(
                name: "ForumPosts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Forum Post identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PostContent = table.Column<string>(type: "text", maxLength: 2000, nullable: false),
                    ForumUserId = table.Column<int>(type: "int", nullable: true, comment: "Forum post creator"),
                    Rating = table.Column<int>(type: "int", nullable: false, comment: "Post rating"),
                    ReplyToPostId = table.Column<int>(type: "int", nullable: true, comment: "Post is a reply to post with Id"),
                    PostReplyId = table.Column<int>(type: "int", nullable: true),
                    ForumTopicId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ForumPosts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ForumPosts_ForumPosts_PostReplyId",
                        column: x => x.PostReplyId,
                        principalTable: "ForumPosts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ForumPosts_ForumTopics_ForumTopicId",
                        column: x => x.ForumTopicId,
                        principalTable: "ForumTopics",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ForumPosts_ForumUsers_ForumUserId",
                        column: x => x.ForumUserId,
                        principalTable: "ForumUsers",
                        principalColumn: "Id");
                },
                comment: "Forum Post");

            migrationBuilder.CreateTable(
                name: "ForumPostReplies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Forum Post Reply identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(type: "text", maxLength: 2000, nullable: false),
                    ForumPostId = table.Column<int>(type: "int", nullable: false, comment: "Reply to post with Id")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ForumPostReplies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ForumPostReplies_ForumPosts_ForumPostId",
                        column: x => x.ForumPostId,
                        principalTable: "ForumPosts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ForumPostRatings",
                columns: table => new
                {
                    ForumPostReplyId = table.Column<int>(type: "int", nullable: false),
                    ForumUserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ForumPostRatings", x => new { x.ForumPostReplyId, x.ForumUserId });
                    table.ForeignKey(
                        name: "FK_ForumPostRatings_ForumPostReplies_ForumPostReplyId",
                        column: x => x.ForumPostReplyId,
                        principalTable: "ForumPostReplies",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ForumPostRatings_ForumUsers_ForumUserId",
                        column: x => x.ForumUserId,
                        principalTable: "ForumUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ForumPostRatings_ForumUserId",
                table: "ForumPostRatings",
                column: "ForumUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ForumPostReplies_ForumPostId",
                table: "ForumPostReplies",
                column: "ForumPostId");

            migrationBuilder.CreateIndex(
                name: "IX_ForumPosts_ForumTopicId",
                table: "ForumPosts",
                column: "ForumTopicId");

            migrationBuilder.CreateIndex(
                name: "IX_ForumPosts_ForumUserId",
                table: "ForumPosts",
                column: "ForumUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ForumPosts_PostReplyId",
                table: "ForumPosts",
                column: "PostReplyId");

            migrationBuilder.CreateIndex(
                name: "IX_ForumTopics_TopicCreatorId",
                table: "ForumTopics",
                column: "TopicCreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_ForumUsers_ClientId",
                table: "ForumUsers",
                column: "ClientId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ForumPostRatings");

            migrationBuilder.DropTable(
                name: "ForumPostReplies");

            migrationBuilder.DropTable(
                name: "ForumPosts");

            migrationBuilder.DropTable(
                name: "ForumTopics");

            migrationBuilder.DropTable(
                name: "ForumUsers");
        }
    }
}
