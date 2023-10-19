using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Benchmark.Migrations
{
    /// <inheritdoc />
    public partial class NotificationTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    NotificationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Source = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SourceId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ResponseRequired = table.Column<bool>(type: "bit", nullable: false),
                    DisplayTimeSeconds = table.Column<int>(type: "int", nullable: true),
                    QrCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeliveredDateUtc = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ExpirationDateUtc = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    CreatedOnUtc = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModifiedOnUtc = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.NotificationId);
                });

            migrationBuilder.CreateTable(
                name: "NotificationBodies",
                columns: table => new
                {
                    NotificationBodyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NotificationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Locale = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOnUtc = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModifiedOnUtc = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotificationBodies", x => x.NotificationBodyId);
                    table.ForeignKey(
                        name: "FK_NotificationBodies_Notifications_NotificationId",
                        column: x => x.NotificationId,
                        principalTable: "Notifications",
                        principalColumn: "NotificationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NotificationResponses",
                columns: table => new
                {
                    NotificationResponseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NotificationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Locale = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOnUtc = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModifiedOnUtc = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotificationResponses", x => x.NotificationResponseId);
                    table.ForeignKey(
                        name: "FK_NotificationResponses_Notifications_NotificationId",
                        column: x => x.NotificationId,
                        principalTable: "Notifications",
                        principalColumn: "NotificationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NotificationTitles",
                columns: table => new
                {
                    NotificationTitleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NotificationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Locale = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOnUtc = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModifiedOnUtc = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotificationTitles", x => x.NotificationTitleId);
                    table.ForeignKey(
                        name: "FK_NotificationTitles_Notifications_NotificationId",
                        column: x => x.NotificationId,
                        principalTable: "Notifications",
                        principalColumn: "NotificationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UsersToNotifications",
                columns: table => new
                {
                    UsersToNotificationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsersId = table.Column<int>(type: "int", nullable: false),
                    NotificationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOnUtc = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModifiedOnUtc = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersToNotifications", x => x.UsersToNotificationId);
                    table.ForeignKey(
                        name: "FK_UsersToNotifications_Notifications_NotificationId",
                        column: x => x.NotificationId,
                        principalTable: "Notifications",
                        principalColumn: "NotificationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UsersToNotification_Acknowledgeds",
                columns: table => new
                {
                    UsersToNotification_AcknowledgedId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsersId = table.Column<int>(type: "int", nullable: false),
                    NotificationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NotificationResponseId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AcknowledgedOnUtc = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    Cash360_SentOnUtc = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    Koyus_SentOnUtc = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    CreatedOnUtc = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModifiedOnUtc = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersToNotification_Acknowledgeds", x => x.UsersToNotification_AcknowledgedId);
                    table.ForeignKey(
                        name: "FK_UsersToNotification_Acknowledgeds_NotificationResponses_NotificationResponseId",
                        column: x => x.NotificationResponseId,
                        principalTable: "NotificationResponses",
                        principalColumn: "NotificationResponseId");
                    table.ForeignKey(
                        name: "FK_UsersToNotification_Acknowledgeds_Notifications_NotificationId",
                        column: x => x.NotificationId,
                        principalTable: "Notifications",
                        principalColumn: "NotificationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NotificationBodies_NotificationId",
                table: "NotificationBodies",
                column: "NotificationId");

            migrationBuilder.CreateIndex(
                name: "IX_NotificationResponses_NotificationId",
                table: "NotificationResponses",
                column: "NotificationId");

            migrationBuilder.CreateIndex(
                name: "IX_NotificationTitles_NotificationId",
                table: "NotificationTitles",
                column: "NotificationId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersToNotification_Acknowledgeds_NotificationId",
                table: "UsersToNotification_Acknowledgeds",
                column: "NotificationId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersToNotification_Acknowledgeds_NotificationResponseId",
                table: "UsersToNotification_Acknowledgeds",
                column: "NotificationResponseId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersToNotifications_NotificationId",
                table: "UsersToNotifications",
                column: "NotificationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NotificationBodies");

            migrationBuilder.DropTable(
                name: "NotificationTitles");

            migrationBuilder.DropTable(
                name: "UsersToNotification_Acknowledgeds");

            migrationBuilder.DropTable(
                name: "UsersToNotifications");

            migrationBuilder.DropTable(
                name: "NotificationResponses");

            migrationBuilder.DropTable(
                name: "Notifications");
        }
    }
}
