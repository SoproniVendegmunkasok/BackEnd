using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GuestHibajelentesEvvegi.Migrations
{
    /// <inheritdoc />
    public partial class asd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NormalizedName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ConcurrencyStamp = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UserName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NormalizedUserName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NormalizedEmail = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EmailConfirmed = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    PasswordHash = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SecurityStamp = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ConcurrencyStamp = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PhoneNumber = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PhoneNumberConfirmed = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Machines",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    status = table.Column<int>(type: "int", nullable: false),
                    hall = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    created_at = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Machines", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ClaimType = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ClaimValue = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ClaimType = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ClaimValue = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProviderKey = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProviderDisplayName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UserId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RoleId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LoginProvider = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Value = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Errors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    status = table.Column<int>(type: "int", nullable: false),
                    description = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    submitted_by = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    machine_id = table.Column<int>(type: "int", nullable: false),
                    assigned_to = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    created_at = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    resolved_at = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Errors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Errors_AspNetUsers_assigned_to",
                        column: x => x.assigned_to,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Errors_AspNetUsers_submitted_by",
                        column: x => x.submitted_by,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Errors_Machines_machine_id",
                        column: x => x.machine_id,
                        principalTable: "Machines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Error_logs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    description = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    created_at = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    error_id = table.Column<int>(type: "int", nullable: false),
                    user_id = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Error_logs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Error_logs_AspNetUsers_user_id",
                        column: x => x.user_id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Error_logs_Errors_error_id",
                        column: x => x.error_id,
                        principalTable: "Errors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    description = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    assigned_to = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    error_id = table.Column<int>(type: "int", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    resolved_at = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tasks_AspNetUsers_assigned_to",
                        column: x => x.assigned_to,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tasks_Errors_error_id",
                        column: x => x.error_id,
                        principalTable: "Errors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "1", 0, "XYZ123", "user1@example.com", true, false, null, "USER1@EXAMPLE.COM", "USER1", "AQAAAAIAAYagAAAAELzE0Wrf9HOHKgcIumGnnzT3l4CQa9PAc9pN77mgArUJptgJL/fgkfEu/weeyhTwBQ==", null, false, "ABC123", false, "user1" },
                    { "2", 0, "UVW456", "user2@example.com", true, false, null, "USER2@EXAMPLE.COM", "USER2", "AQAAAAIAAYagAAAAEO/F8wkxerv9DZ2NP1go80NewzhfdYoVr55sVBNKtU95YHZ85dZzQMs9zoKmbAaeQQ==", null, false, "DEF456", false, "user2" },
                    { "3", 0, "RST789", "user3@example.com", true, false, null, "USER3@EXAMPLE.COM", "USER3", "AQAAAAIAAYagAAAAEJ0vvjT1SYrRYme8Bcf0RVy0XWOjlsFOBeISu2Pi/APVtP1BfC6xKE1b2ExoHBV7YA==", null, false, "GHI789", false, "user3" },
                    { "4", 0, "OPQ012", "user4@example.com", true, false, null, "USER4@EXAMPLE.COM", "USER4", "AQAAAAIAAYagAAAAEC6X/9bLzl4+cfGiFYU95e7PgdjD4qnB4GhPs/XDKcUdei6AFOu65SniU00/Y/gLTQ==", null, false, "JKL012", false, "user4" }
                });

            migrationBuilder.InsertData(
                table: "Machines",
                columns: new[] { "Id", "created_at", "hall", "name", "status" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 3, 30, 21, 0, 38, 114, DateTimeKind.Local).AddTicks(8380), "H1", "Machine1", 0 },
                    { 2, new DateTime(2025, 3, 30, 21, 0, 38, 114, DateTimeKind.Local).AddTicks(8430), "H2", "Machine2", 1 },
                    { 3, new DateTime(2025, 3, 30, 21, 0, 38, 114, DateTimeKind.Local).AddTicks(8433), "H3", "Machine3", 0 },
                    { 4, new DateTime(2025, 3, 30, 21, 0, 38, 114, DateTimeKind.Local).AddTicks(8435), "H4", "Machine4", 1 }
                });

            migrationBuilder.InsertData(
                table: "Errors",
                columns: new[] { "Id", "assigned_to", "created_at", "description", "machine_id", "resolved_at", "status", "submitted_by" },
                values: new object[,]
                {
                    { 1, "2", new DateTime(2025, 3, 30, 21, 0, 38, 114, DateTimeKind.Local).AddTicks(8466), "Error description 1", 1, new DateTime(2025, 3, 31, 21, 0, 38, 114, DateTimeKind.Local).AddTicks(8477), 0, "1" },
                    { 2, "3", new DateTime(2025, 3, 30, 21, 0, 38, 114, DateTimeKind.Local).AddTicks(8487), "Error description 2", 2, new DateTime(2025, 4, 1, 21, 0, 38, 114, DateTimeKind.Local).AddTicks(8489), 1, "2" },
                    { 3, "4", new DateTime(2025, 3, 30, 21, 0, 38, 114, DateTimeKind.Local).AddTicks(8491), "Error description 3", 3, new DateTime(2025, 4, 2, 21, 0, 38, 114, DateTimeKind.Local).AddTicks(8492), 2, "3" },
                    { 4, "1", new DateTime(2025, 3, 30, 21, 0, 38, 114, DateTimeKind.Local).AddTicks(8497), "Error description 4", 4, new DateTime(2025, 4, 3, 21, 0, 38, 114, DateTimeKind.Local).AddTicks(8498), 0, "4" }
                });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "assigned_to", "created_at", "description", "error_id", "resolved_at" },
                values: new object[,]
                {
                    { 1, "2", new DateTime(2025, 3, 30, 21, 0, 38, 114, DateTimeKind.Local).AddTicks(8536), "Task 1 for Error 1", 1, new DateTime(2025, 3, 30, 22, 0, 38, 114, DateTimeKind.Local).AddTicks(8542) },
                    { 2, "2", new DateTime(2025, 3, 30, 21, 0, 38, 114, DateTimeKind.Local).AddTicks(8545), "Task 2 for Error 1", 1, new DateTime(2025, 3, 30, 23, 0, 38, 114, DateTimeKind.Local).AddTicks(8562) },
                    { 3, "2", new DateTime(2025, 3, 30, 21, 0, 38, 114, DateTimeKind.Local).AddTicks(8564), "Task 3 for Error 1", 1, new DateTime(2025, 3, 31, 0, 0, 38, 114, DateTimeKind.Local).AddTicks(8566) },
                    { 4, "3", new DateTime(2025, 3, 30, 21, 0, 38, 114, DateTimeKind.Local).AddTicks(8571), "Task 1 for Error 2", 2, new DateTime(2025, 3, 30, 22, 0, 38, 114, DateTimeKind.Local).AddTicks(8572) },
                    { 5, "3", new DateTime(2025, 3, 30, 21, 0, 38, 114, DateTimeKind.Local).AddTicks(8574), "Task 2 for Error 2", 2, new DateTime(2025, 3, 30, 23, 0, 38, 114, DateTimeKind.Local).AddTicks(8576) },
                    { 6, "3", new DateTime(2025, 3, 30, 21, 0, 38, 114, DateTimeKind.Local).AddTicks(8578), "Task 3 for Error 2", 2, new DateTime(2025, 3, 31, 0, 0, 38, 114, DateTimeKind.Local).AddTicks(8579) },
                    { 7, "4", new DateTime(2025, 3, 30, 21, 0, 38, 114, DateTimeKind.Local).AddTicks(8581), "Task 1 for Error 3", 3, new DateTime(2025, 3, 30, 22, 0, 38, 114, DateTimeKind.Local).AddTicks(8583) },
                    { 8, "4", new DateTime(2025, 3, 30, 21, 0, 38, 114, DateTimeKind.Local).AddTicks(8585), "Task 2 for Error 3", 3, new DateTime(2025, 3, 30, 23, 0, 38, 114, DateTimeKind.Local).AddTicks(8586) },
                    { 9, "4", new DateTime(2025, 3, 30, 21, 0, 38, 114, DateTimeKind.Local).AddTicks(8588), "Task 3 for Error 3", 3, new DateTime(2025, 3, 31, 0, 0, 38, 114, DateTimeKind.Local).AddTicks(8592) },
                    { 10, "1", new DateTime(2025, 3, 30, 21, 0, 38, 114, DateTimeKind.Local).AddTicks(8617), "Task 1 for Error 4", 4, new DateTime(2025, 3, 30, 22, 0, 38, 114, DateTimeKind.Local).AddTicks(8619) },
                    { 11, "1", new DateTime(2025, 3, 30, 21, 0, 38, 114, DateTimeKind.Local).AddTicks(8621), "Task 2 for Error 4", 4, new DateTime(2025, 3, 30, 23, 0, 38, 114, DateTimeKind.Local).AddTicks(8622) },
                    { 12, "1", new DateTime(2025, 3, 30, 21, 0, 38, 114, DateTimeKind.Local).AddTicks(8624), "Task 3 for Error 4", 4, new DateTime(2025, 3, 31, 0, 0, 38, 114, DateTimeKind.Local).AddTicks(8625) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Error_logs_error_id",
                table: "Error_logs",
                column: "error_id");

            migrationBuilder.CreateIndex(
                name: "IX_Error_logs_user_id",
                table: "Error_logs",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_Errors_assigned_to",
                table: "Errors",
                column: "assigned_to");

            migrationBuilder.CreateIndex(
                name: "IX_Errors_machine_id",
                table: "Errors",
                column: "machine_id");

            migrationBuilder.CreateIndex(
                name: "IX_Errors_submitted_by",
                table: "Errors",
                column: "submitted_by");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_assigned_to",
                table: "Tasks",
                column: "assigned_to");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_error_id",
                table: "Tasks",
                column: "error_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Error_logs");

            migrationBuilder.DropTable(
                name: "Tasks");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Errors");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Machines");
        }
    }
}
