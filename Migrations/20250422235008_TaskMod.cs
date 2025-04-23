using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GuestHibajelentesEvvegi.Migrations
{
    /// <inheritdoc />
    public partial class TaskMod : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "status",
                table: "Tasks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEEbbxPbPhjlBi6cYVX/Dx/6p8rY4STCfN2Rm7VrbiEgmQ6XSg1YAO9/QXwMzu/GRoQ==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEHtyphFUCH6F0L9BAflqz8oKKYImRfWctk6b87GsEhWmjXm1kqRcB6jtOHL8GQZ5qQ==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEBZhXQgVCINQLKTiiK784Bk448co87BVbk22GHs0mJQJCdPCjMaouHwlbiRqcr31Mw==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEM5uotZdRJiXG04d8HhIzAhThZ02TWyTXJIGKSr7/mIb6ODMvo7C0FoYmicRNcImkw==");

            migrationBuilder.UpdateData(
                table: "Errors",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "created_at", "resolved_at" },
                values: new object[] { new DateTime(2025, 4, 23, 1, 50, 7, 460, DateTimeKind.Local).AddTicks(5955), new DateTime(2025, 4, 24, 1, 50, 7, 460, DateTimeKind.Local).AddTicks(5969) });

            migrationBuilder.UpdateData(
                table: "Errors",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "created_at", "resolved_at" },
                values: new object[] { new DateTime(2025, 4, 23, 1, 50, 7, 460, DateTimeKind.Local).AddTicks(5987), new DateTime(2025, 4, 25, 1, 50, 7, 460, DateTimeKind.Local).AddTicks(5988) });

            migrationBuilder.UpdateData(
                table: "Errors",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "created_at", "resolved_at" },
                values: new object[] { new DateTime(2025, 4, 23, 1, 50, 7, 460, DateTimeKind.Local).AddTicks(5992), new DateTime(2025, 4, 26, 1, 50, 7, 460, DateTimeKind.Local).AddTicks(5994) });

            migrationBuilder.UpdateData(
                table: "Errors",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "created_at", "resolved_at" },
                values: new object[] { new DateTime(2025, 4, 23, 1, 50, 7, 460, DateTimeKind.Local).AddTicks(6006), new DateTime(2025, 4, 27, 1, 50, 7, 460, DateTimeKind.Local).AddTicks(6007) });

            migrationBuilder.UpdateData(
                table: "Machines",
                keyColumn: "Id",
                keyValue: 1,
                column: "created_at",
                value: new DateTime(2025, 4, 23, 1, 50, 7, 460, DateTimeKind.Local).AddTicks(5672));

            migrationBuilder.UpdateData(
                table: "Machines",
                keyColumn: "Id",
                keyValue: 2,
                column: "created_at",
                value: new DateTime(2025, 4, 23, 1, 50, 7, 460, DateTimeKind.Local).AddTicks(5759));

            migrationBuilder.UpdateData(
                table: "Machines",
                keyColumn: "Id",
                keyValue: 3,
                column: "created_at",
                value: new DateTime(2025, 4, 23, 1, 50, 7, 460, DateTimeKind.Local).AddTicks(5762));

            migrationBuilder.UpdateData(
                table: "Machines",
                keyColumn: "Id",
                keyValue: 4,
                column: "created_at",
                value: new DateTime(2025, 4, 23, 1, 50, 7, 460, DateTimeKind.Local).AddTicks(5765));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "created_at", "resolved_at", "status" },
                values: new object[] { new DateTime(2025, 4, 23, 1, 50, 7, 460, DateTimeKind.Local).AddTicks(6440), new DateTime(2025, 4, 23, 2, 50, 7, 460, DateTimeKind.Local).AddTicks(6457), 0 });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "created_at", "resolved_at", "status" },
                values: new object[] { new DateTime(2025, 4, 23, 1, 50, 7, 460, DateTimeKind.Local).AddTicks(6460), new DateTime(2025, 4, 23, 3, 50, 7, 460, DateTimeKind.Local).AddTicks(6483), 0 });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "created_at", "resolved_at", "status" },
                values: new object[] { new DateTime(2025, 4, 23, 1, 50, 7, 460, DateTimeKind.Local).AddTicks(6485), new DateTime(2025, 4, 23, 4, 50, 7, 460, DateTimeKind.Local).AddTicks(6487), 0 });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "created_at", "resolved_at", "status" },
                values: new object[] { new DateTime(2025, 4, 23, 1, 50, 7, 460, DateTimeKind.Local).AddTicks(6489), new DateTime(2025, 4, 23, 2, 50, 7, 460, DateTimeKind.Local).AddTicks(6490), 0 });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "created_at", "resolved_at", "status" },
                values: new object[] { new DateTime(2025, 4, 23, 1, 50, 7, 460, DateTimeKind.Local).AddTicks(6492), new DateTime(2025, 4, 23, 3, 50, 7, 460, DateTimeKind.Local).AddTicks(6493), 0 });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "created_at", "resolved_at", "status" },
                values: new object[] { new DateTime(2025, 4, 23, 1, 50, 7, 460, DateTimeKind.Local).AddTicks(6495), new DateTime(2025, 4, 23, 4, 50, 7, 460, DateTimeKind.Local).AddTicks(6497), 0 });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "created_at", "resolved_at", "status" },
                values: new object[] { new DateTime(2025, 4, 23, 1, 50, 7, 460, DateTimeKind.Local).AddTicks(6498), new DateTime(2025, 4, 23, 2, 50, 7, 460, DateTimeKind.Local).AddTicks(6500), 0 });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "created_at", "resolved_at", "status" },
                values: new object[] { new DateTime(2025, 4, 23, 1, 50, 7, 460, DateTimeKind.Local).AddTicks(6502), new DateTime(2025, 4, 23, 3, 50, 7, 460, DateTimeKind.Local).AddTicks(6503), 0 });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "created_at", "resolved_at", "status" },
                values: new object[] { new DateTime(2025, 4, 23, 1, 50, 7, 460, DateTimeKind.Local).AddTicks(6505), new DateTime(2025, 4, 23, 4, 50, 7, 460, DateTimeKind.Local).AddTicks(6518), 0 });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "created_at", "resolved_at", "status" },
                values: new object[] { new DateTime(2025, 4, 23, 1, 50, 7, 460, DateTimeKind.Local).AddTicks(6557), new DateTime(2025, 4, 23, 2, 50, 7, 460, DateTimeKind.Local).AddTicks(6559), 0 });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "created_at", "resolved_at", "status" },
                values: new object[] { new DateTime(2025, 4, 23, 1, 50, 7, 460, DateTimeKind.Local).AddTicks(6561), new DateTime(2025, 4, 23, 3, 50, 7, 460, DateTimeKind.Local).AddTicks(6563), 0 });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "created_at", "resolved_at", "status" },
                values: new object[] { new DateTime(2025, 4, 23, 1, 50, 7, 460, DateTimeKind.Local).AddTicks(6565), new DateTime(2025, 4, 23, 4, 50, 7, 460, DateTimeKind.Local).AddTicks(6566), 0 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "status",
                table: "Tasks");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEJ0e59BOccJPV0cMaFjZTe4ukIBnk1q874drP2IonPGO336uAGXC6lZbQg6H3uTaLA==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEDVcF43nzOg5TGEUtVIPx1QyjA9pysIZJqodQPSeeIIXFHqepm98KkaOPYYlmAyv9Q==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAECc2D35+TK+4keFInCfSwHv5kPPQ2yngKWWtpp7Ahxkza7hO7pt4+6+2WZIzBUqK3w==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEAnhjBlWOrkl5PltMVJWxDrJrELoxuiCOdm9rjmfdWg8PBe43tc7cfJn37AClHna9A==");

            migrationBuilder.UpdateData(
                table: "Errors",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "created_at", "resolved_at" },
                values: new object[] { new DateTime(2025, 3, 31, 0, 49, 35, 969, DateTimeKind.Local).AddTicks(8774), new DateTime(2025, 4, 1, 0, 49, 35, 969, DateTimeKind.Local).AddTicks(8783) });

            migrationBuilder.UpdateData(
                table: "Errors",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "created_at", "resolved_at" },
                values: new object[] { new DateTime(2025, 3, 31, 0, 49, 35, 969, DateTimeKind.Local).AddTicks(8806), new DateTime(2025, 4, 2, 0, 49, 35, 969, DateTimeKind.Local).AddTicks(8810) });

            migrationBuilder.UpdateData(
                table: "Errors",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "created_at", "resolved_at" },
                values: new object[] { new DateTime(2025, 3, 31, 0, 49, 35, 969, DateTimeKind.Local).AddTicks(8814), new DateTime(2025, 4, 3, 0, 49, 35, 969, DateTimeKind.Local).AddTicks(8816) });

            migrationBuilder.UpdateData(
                table: "Errors",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "created_at", "resolved_at" },
                values: new object[] { new DateTime(2025, 3, 31, 0, 49, 35, 969, DateTimeKind.Local).AddTicks(8823), new DateTime(2025, 4, 4, 0, 49, 35, 969, DateTimeKind.Local).AddTicks(8826) });

            migrationBuilder.UpdateData(
                table: "Machines",
                keyColumn: "Id",
                keyValue: 1,
                column: "created_at",
                value: new DateTime(2025, 3, 31, 0, 49, 35, 969, DateTimeKind.Local).AddTicks(8562));

            migrationBuilder.UpdateData(
                table: "Machines",
                keyColumn: "Id",
                keyValue: 2,
                column: "created_at",
                value: new DateTime(2025, 3, 31, 0, 49, 35, 969, DateTimeKind.Local).AddTicks(8676));

            migrationBuilder.UpdateData(
                table: "Machines",
                keyColumn: "Id",
                keyValue: 3,
                column: "created_at",
                value: new DateTime(2025, 3, 31, 0, 49, 35, 969, DateTimeKind.Local).AddTicks(8680));

            migrationBuilder.UpdateData(
                table: "Machines",
                keyColumn: "Id",
                keyValue: 4,
                column: "created_at",
                value: new DateTime(2025, 3, 31, 0, 49, 35, 969, DateTimeKind.Local).AddTicks(8683));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "created_at", "resolved_at" },
                values: new object[] { new DateTime(2025, 3, 31, 0, 49, 35, 969, DateTimeKind.Local).AddTicks(8893), new DateTime(2025, 3, 31, 1, 49, 35, 969, DateTimeKind.Local).AddTicks(8902) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "created_at", "resolved_at" },
                values: new object[] { new DateTime(2025, 3, 31, 0, 49, 35, 969, DateTimeKind.Local).AddTicks(8906), new DateTime(2025, 3, 31, 2, 49, 35, 969, DateTimeKind.Local).AddTicks(8928) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "created_at", "resolved_at" },
                values: new object[] { new DateTime(2025, 3, 31, 0, 49, 35, 969, DateTimeKind.Local).AddTicks(8932), new DateTime(2025, 3, 31, 3, 49, 35, 969, DateTimeKind.Local).AddTicks(8935) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "created_at", "resolved_at" },
                values: new object[] { new DateTime(2025, 3, 31, 0, 49, 35, 969, DateTimeKind.Local).AddTicks(8939), new DateTime(2025, 3, 31, 1, 49, 35, 969, DateTimeKind.Local).AddTicks(8941) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "created_at", "resolved_at" },
                values: new object[] { new DateTime(2025, 3, 31, 0, 49, 35, 969, DateTimeKind.Local).AddTicks(8945), new DateTime(2025, 3, 31, 2, 49, 35, 969, DateTimeKind.Local).AddTicks(8947) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "created_at", "resolved_at" },
                values: new object[] { new DateTime(2025, 3, 31, 0, 49, 35, 969, DateTimeKind.Local).AddTicks(8951), new DateTime(2025, 3, 31, 3, 49, 35, 969, DateTimeKind.Local).AddTicks(8953) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "created_at", "resolved_at" },
                values: new object[] { new DateTime(2025, 3, 31, 0, 49, 35, 969, DateTimeKind.Local).AddTicks(8957), new DateTime(2025, 3, 31, 1, 49, 35, 969, DateTimeKind.Local).AddTicks(8959) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "created_at", "resolved_at" },
                values: new object[] { new DateTime(2025, 3, 31, 0, 49, 35, 969, DateTimeKind.Local).AddTicks(8962), new DateTime(2025, 3, 31, 2, 49, 35, 969, DateTimeKind.Local).AddTicks(8965) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "created_at", "resolved_at" },
                values: new object[] { new DateTime(2025, 3, 31, 0, 49, 35, 969, DateTimeKind.Local).AddTicks(8968), new DateTime(2025, 3, 31, 3, 49, 35, 969, DateTimeKind.Local).AddTicks(8978) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "created_at", "resolved_at" },
                values: new object[] { new DateTime(2025, 3, 31, 0, 49, 35, 969, DateTimeKind.Local).AddTicks(9029), new DateTime(2025, 3, 31, 1, 49, 35, 969, DateTimeKind.Local).AddTicks(9032) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "created_at", "resolved_at" },
                values: new object[] { new DateTime(2025, 3, 31, 0, 49, 35, 969, DateTimeKind.Local).AddTicks(9036), new DateTime(2025, 3, 31, 2, 49, 35, 969, DateTimeKind.Local).AddTicks(9038) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "created_at", "resolved_at" },
                values: new object[] { new DateTime(2025, 3, 31, 0, 49, 35, 969, DateTimeKind.Local).AddTicks(9041), new DateTime(2025, 3, 31, 3, 49, 35, 969, DateTimeKind.Local).AddTicks(9043) });
        }
    }
}
