using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GuestHibajelentesEvvegi.Migrations
{
    /// <inheritdoc />
    public partial class xd : Migration
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
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1", null, "Admin", "ADMIN" },
                    { "2", null, "Linesman", "LINESMAN" },
                    { "3", null, "Repairman", "REPAIRMAN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "1", 0, "XYZ123", "user1@example.com", true, false, null, "USER1@EXAMPLE.COM", "USER1", "AQAAAAIAAYagAAAAEJ0e59BOccJPV0cMaFjZTe4ukIBnk1q874drP2IonPGO336uAGXC6lZbQg6H3uTaLA==", null, false, "ABC123", false, "user1" },
                    { "2", 0, "UVW456", "user2@example.com", true, false, null, "USER2@EXAMPLE.COM", "USER2", "AQAAAAIAAYagAAAAEDVcF43nzOg5TGEUtVIPx1QyjA9pysIZJqodQPSeeIIXFHqepm98KkaOPYYlmAyv9Q==", null, false, "DEF456", false, "user2" },
                    { "3", 0, "RST789", "user3@example.com", true, false, null, "USER3@EXAMPLE.COM", "USER3", "AQAAAAIAAYagAAAAECc2D35+TK+4keFInCfSwHv5kPPQ2yngKWWtpp7Ahxkza7hO7pt4+6+2WZIzBUqK3w==", null, false, "GHI789", false, "user3" },
                    { "4", 0, "OPQ012", "user4@example.com", true, false, null, "USER4@EXAMPLE.COM", "USER4", "AQAAAAIAAYagAAAAEAnhjBlWOrkl5PltMVJWxDrJrELoxuiCOdm9rjmfdWg8PBe43tc7cfJn37AClHna9A==", null, false, "JKL012", false, "user4" }
                });

            migrationBuilder.InsertData(
                table: "Machines",
                columns: new[] { "Id", "created_at", "hall", "name", "status" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 3, 31, 0, 49, 35, 969, DateTimeKind.Local).AddTicks(8562), "H1", "Machine1", 0 },
                    { 2, new DateTime(2025, 3, 31, 0, 49, 35, 969, DateTimeKind.Local).AddTicks(8676), "H2", "Machine2", 1 },
                    { 3, new DateTime(2025, 3, 31, 0, 49, 35, 969, DateTimeKind.Local).AddTicks(8680), "H3", "Machine3", 0 },
                    { 4, new DateTime(2025, 3, 31, 0, 49, 35, 969, DateTimeKind.Local).AddTicks(8683), "H4", "Machine4", 1 }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "1", "1" },
                    { "2", "2" },
                    { "3", "3" },
                    { "3", "4" }
                });

            migrationBuilder.InsertData(
                table: "Errors",
                columns: new[] { "Id", "assigned_to", "created_at", "description", "machine_id", "resolved_at", "status", "submitted_by" },
                values: new object[,]
                {
                    { 1, "2", new DateTime(2025, 3, 31, 0, 49, 35, 969, DateTimeKind.Local).AddTicks(8774), "Error description 1", 1, new DateTime(2025, 4, 1, 0, 49, 35, 969, DateTimeKind.Local).AddTicks(8783), 0, "1" },
                    { 2, "3", new DateTime(2025, 3, 31, 0, 49, 35, 969, DateTimeKind.Local).AddTicks(8806), "Error description 2", 2, new DateTime(2025, 4, 2, 0, 49, 35, 969, DateTimeKind.Local).AddTicks(8810), 1, "2" },
                    { 3, "4", new DateTime(2025, 3, 31, 0, 49, 35, 969, DateTimeKind.Local).AddTicks(8814), "Error description 3", 3, new DateTime(2025, 4, 3, 0, 49, 35, 969, DateTimeKind.Local).AddTicks(8816), 2, "3" },
                    { 4, "1", new DateTime(2025, 3, 31, 0, 49, 35, 969, DateTimeKind.Local).AddTicks(8823), "Error description 4", 4, new DateTime(2025, 4, 4, 0, 49, 35, 969, DateTimeKind.Local).AddTicks(8826), 0, "4" }
                });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "assigned_to", "created_at", "description", "error_id", "resolved_at" },
                values: new object[,]
                {
                    { 1, "2", new DateTime(2025, 3, 31, 0, 49, 35, 969, DateTimeKind.Local).AddTicks(8893), "Task 1 for Error 1", 1, new DateTime(2025, 3, 31, 1, 49, 35, 969, DateTimeKind.Local).AddTicks(8902) },
                    { 2, "2", new DateTime(2025, 3, 31, 0, 49, 35, 969, DateTimeKind.Local).AddTicks(8906), "Task 2 for Error 1", 1, new DateTime(2025, 3, 31, 2, 49, 35, 969, DateTimeKind.Local).AddTicks(8928) },
                    { 3, "2", new DateTime(2025, 3, 31, 0, 49, 35, 969, DateTimeKind.Local).AddTicks(8932), "Task 3 for Error 1", 1, new DateTime(2025, 3, 31, 3, 49, 35, 969, DateTimeKind.Local).AddTicks(8935) },
                    { 4, "3", new DateTime(2025, 3, 31, 0, 49, 35, 969, DateTimeKind.Local).AddTicks(8939), "Task 1 for Error 2", 2, new DateTime(2025, 3, 31, 1, 49, 35, 969, DateTimeKind.Local).AddTicks(8941) },
                    { 5, "3", new DateTime(2025, 3, 31, 0, 49, 35, 969, DateTimeKind.Local).AddTicks(8945), "Task 2 for Error 2", 2, new DateTime(2025, 3, 31, 2, 49, 35, 969, DateTimeKind.Local).AddTicks(8947) },
                    { 6, "3", new DateTime(2025, 3, 31, 0, 49, 35, 969, DateTimeKind.Local).AddTicks(8951), "Task 3 for Error 2", 2, new DateTime(2025, 3, 31, 3, 49, 35, 969, DateTimeKind.Local).AddTicks(8953) },
                    { 7, "4", new DateTime(2025, 3, 31, 0, 49, 35, 969, DateTimeKind.Local).AddTicks(8957), "Task 1 for Error 3", 3, new DateTime(2025, 3, 31, 1, 49, 35, 969, DateTimeKind.Local).AddTicks(8959) },
                    { 8, "4", new DateTime(2025, 3, 31, 0, 49, 35, 969, DateTimeKind.Local).AddTicks(8962), "Task 2 for Error 3", 3, new DateTime(2025, 3, 31, 2, 49, 35, 969, DateTimeKind.Local).AddTicks(8965) },
                    { 9, "4", new DateTime(2025, 3, 31, 0, 49, 35, 969, DateTimeKind.Local).AddTicks(8968), "Task 3 for Error 3", 3, new DateTime(2025, 3, 31, 3, 49, 35, 969, DateTimeKind.Local).AddTicks(8978) },
                    { 10, "1", new DateTime(2025, 3, 31, 0, 49, 35, 969, DateTimeKind.Local).AddTicks(9029), "Task 1 for Error 4", 4, new DateTime(2025, 3, 31, 1, 49, 35, 969, DateTimeKind.Local).AddTicks(9032) },
                    { 11, "1", new DateTime(2025, 3, 31, 0, 49, 35, 969, DateTimeKind.Local).AddTicks(9036), "Task 2 for Error 4", 4, new DateTime(2025, 3, 31, 2, 49, 35, 969, DateTimeKind.Local).AddTicks(9038) },
                    { 12, "1", new DateTime(2025, 3, 31, 0, 49, 35, 969, DateTimeKind.Local).AddTicks(9041), "Task 3 for Error 4", 4, new DateTime(2025, 3, 31, 3, 49, 35, 969, DateTimeKind.Local).AddTicks(9043) }
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
