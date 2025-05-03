using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GuestHibajelentesEvvegi.Migrations
{
    /// <inheritdoc />
    public partial class asd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "machine_id",
                table: "Error_logs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEBKvl6OLc8rk8ZuA/a6dQw8fEqJ5X4FmLjHJboMpgYMUeokCIpRyKD5A9EVRJcXKOw==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAENeaUbWC913fAtwq3ORs5RXB7vuhhjV5fJSSSLM956wrUhKxsQ/lzMYkNiHzn0JNrQ==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEHOswhwd7WaAfnpPBfgs4H16gXdEZOpF94PaN0szp7K8t1ZbYffgpUAaTzcfoD+elw==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEOrrAGGW4x08NqHagE3Vq5WWddsev5Ll+qhByzNyRu1SPax2Jah+sEW6frDPuZbY2w==");

            migrationBuilder.UpdateData(
                table: "Errors",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "created_at", "resolved_at" },
                values: new object[] { new DateTime(2025, 4, 28, 2, 19, 1, 406, DateTimeKind.Local).AddTicks(2143), new DateTime(2025, 4, 29, 2, 19, 1, 406, DateTimeKind.Local).AddTicks(2145) });

            migrationBuilder.UpdateData(
                table: "Errors",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "created_at", "resolved_at" },
                values: new object[] { new DateTime(2025, 4, 28, 2, 19, 1, 406, DateTimeKind.Local).AddTicks(2148), new DateTime(2025, 4, 30, 2, 19, 1, 406, DateTimeKind.Local).AddTicks(2149) });

            migrationBuilder.UpdateData(
                table: "Errors",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "created_at", "resolved_at" },
                values: new object[] { new DateTime(2025, 4, 28, 2, 19, 1, 406, DateTimeKind.Local).AddTicks(2151), new DateTime(2025, 5, 1, 2, 19, 1, 406, DateTimeKind.Local).AddTicks(2152) });

            migrationBuilder.UpdateData(
                table: "Errors",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "created_at", "resolved_at" },
                values: new object[] { new DateTime(2025, 4, 28, 2, 19, 1, 406, DateTimeKind.Local).AddTicks(2154), new DateTime(2025, 5, 2, 2, 19, 1, 406, DateTimeKind.Local).AddTicks(2155) });

            migrationBuilder.UpdateData(
                table: "Machines",
                keyColumn: "Id",
                keyValue: 1,
                column: "created_at",
                value: new DateTime(2025, 4, 28, 2, 19, 1, 406, DateTimeKind.Local).AddTicks(2073));

            migrationBuilder.UpdateData(
                table: "Machines",
                keyColumn: "Id",
                keyValue: 2,
                column: "created_at",
                value: new DateTime(2025, 4, 28, 2, 19, 1, 406, DateTimeKind.Local).AddTicks(2116));

            migrationBuilder.UpdateData(
                table: "Machines",
                keyColumn: "Id",
                keyValue: 3,
                column: "created_at",
                value: new DateTime(2025, 4, 28, 2, 19, 1, 406, DateTimeKind.Local).AddTicks(2118));

            migrationBuilder.UpdateData(
                table: "Machines",
                keyColumn: "Id",
                keyValue: 4,
                column: "created_at",
                value: new DateTime(2025, 4, 28, 2, 19, 1, 406, DateTimeKind.Local).AddTicks(2120));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "created_at", "resolved_at" },
                values: new object[] { new DateTime(2025, 4, 28, 2, 19, 1, 406, DateTimeKind.Local).AddTicks(2176), new DateTime(2025, 4, 28, 3, 19, 1, 406, DateTimeKind.Local).AddTicks(2177) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "created_at", "resolved_at" },
                values: new object[] { new DateTime(2025, 4, 28, 2, 19, 1, 406, DateTimeKind.Local).AddTicks(2180), new DateTime(2025, 4, 28, 4, 19, 1, 406, DateTimeKind.Local).AddTicks(2181) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "created_at", "resolved_at" },
                values: new object[] { new DateTime(2025, 4, 28, 2, 19, 1, 406, DateTimeKind.Local).AddTicks(2183), new DateTime(2025, 4, 28, 5, 19, 1, 406, DateTimeKind.Local).AddTicks(2184) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "created_at", "resolved_at" },
                values: new object[] { new DateTime(2025, 4, 28, 2, 19, 1, 406, DateTimeKind.Local).AddTicks(2185), new DateTime(2025, 4, 28, 3, 19, 1, 406, DateTimeKind.Local).AddTicks(2186) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "created_at", "resolved_at" },
                values: new object[] { new DateTime(2025, 4, 28, 2, 19, 1, 406, DateTimeKind.Local).AddTicks(2188), new DateTime(2025, 4, 28, 4, 19, 1, 406, DateTimeKind.Local).AddTicks(2189) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "created_at", "resolved_at" },
                values: new object[] { new DateTime(2025, 4, 28, 2, 19, 1, 406, DateTimeKind.Local).AddTicks(2191), new DateTime(2025, 4, 28, 5, 19, 1, 406, DateTimeKind.Local).AddTicks(2192) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "created_at", "resolved_at" },
                values: new object[] { new DateTime(2025, 4, 28, 2, 19, 1, 406, DateTimeKind.Local).AddTicks(2193), new DateTime(2025, 4, 28, 3, 19, 1, 406, DateTimeKind.Local).AddTicks(2194) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "created_at", "resolved_at" },
                values: new object[] { new DateTime(2025, 4, 28, 2, 19, 1, 406, DateTimeKind.Local).AddTicks(2196), new DateTime(2025, 4, 28, 4, 19, 1, 406, DateTimeKind.Local).AddTicks(2197) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "created_at", "resolved_at" },
                values: new object[] { new DateTime(2025, 4, 28, 2, 19, 1, 406, DateTimeKind.Local).AddTicks(2199), new DateTime(2025, 4, 28, 5, 19, 1, 406, DateTimeKind.Local).AddTicks(2200) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "created_at", "resolved_at" },
                values: new object[] { new DateTime(2025, 4, 28, 2, 19, 1, 406, DateTimeKind.Local).AddTicks(2201), new DateTime(2025, 4, 28, 3, 19, 1, 406, DateTimeKind.Local).AddTicks(2202) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "created_at", "resolved_at" },
                values: new object[] { new DateTime(2025, 4, 28, 2, 19, 1, 406, DateTimeKind.Local).AddTicks(2204), new DateTime(2025, 4, 28, 4, 19, 1, 406, DateTimeKind.Local).AddTicks(2205) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "created_at", "resolved_at" },
                values: new object[] { new DateTime(2025, 4, 28, 2, 19, 1, 406, DateTimeKind.Local).AddTicks(2207), new DateTime(2025, 4, 28, 5, 19, 1, 406, DateTimeKind.Local).AddTicks(2208) });

            migrationBuilder.CreateIndex(
                name: "IX_Error_logs_machine_id",
                table: "Error_logs",
                column: "machine_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Error_logs_Machines_machine_id",
                table: "Error_logs",
                column: "machine_id",
                principalTable: "Machines",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Error_logs_Machines_machine_id",
                table: "Error_logs");

            migrationBuilder.DropIndex(
                name: "IX_Error_logs_machine_id",
                table: "Error_logs");

            migrationBuilder.DropColumn(
                name: "machine_id",
                table: "Error_logs");

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
                columns: new[] { "created_at", "resolved_at" },
                values: new object[] { new DateTime(2025, 4, 23, 1, 50, 7, 460, DateTimeKind.Local).AddTicks(6440), new DateTime(2025, 4, 23, 2, 50, 7, 460, DateTimeKind.Local).AddTicks(6457) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "created_at", "resolved_at" },
                values: new object[] { new DateTime(2025, 4, 23, 1, 50, 7, 460, DateTimeKind.Local).AddTicks(6460), new DateTime(2025, 4, 23, 3, 50, 7, 460, DateTimeKind.Local).AddTicks(6483) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "created_at", "resolved_at" },
                values: new object[] { new DateTime(2025, 4, 23, 1, 50, 7, 460, DateTimeKind.Local).AddTicks(6485), new DateTime(2025, 4, 23, 4, 50, 7, 460, DateTimeKind.Local).AddTicks(6487) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "created_at", "resolved_at" },
                values: new object[] { new DateTime(2025, 4, 23, 1, 50, 7, 460, DateTimeKind.Local).AddTicks(6489), new DateTime(2025, 4, 23, 2, 50, 7, 460, DateTimeKind.Local).AddTicks(6490) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "created_at", "resolved_at" },
                values: new object[] { new DateTime(2025, 4, 23, 1, 50, 7, 460, DateTimeKind.Local).AddTicks(6492), new DateTime(2025, 4, 23, 3, 50, 7, 460, DateTimeKind.Local).AddTicks(6493) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "created_at", "resolved_at" },
                values: new object[] { new DateTime(2025, 4, 23, 1, 50, 7, 460, DateTimeKind.Local).AddTicks(6495), new DateTime(2025, 4, 23, 4, 50, 7, 460, DateTimeKind.Local).AddTicks(6497) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "created_at", "resolved_at" },
                values: new object[] { new DateTime(2025, 4, 23, 1, 50, 7, 460, DateTimeKind.Local).AddTicks(6498), new DateTime(2025, 4, 23, 2, 50, 7, 460, DateTimeKind.Local).AddTicks(6500) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "created_at", "resolved_at" },
                values: new object[] { new DateTime(2025, 4, 23, 1, 50, 7, 460, DateTimeKind.Local).AddTicks(6502), new DateTime(2025, 4, 23, 3, 50, 7, 460, DateTimeKind.Local).AddTicks(6503) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "created_at", "resolved_at" },
                values: new object[] { new DateTime(2025, 4, 23, 1, 50, 7, 460, DateTimeKind.Local).AddTicks(6505), new DateTime(2025, 4, 23, 4, 50, 7, 460, DateTimeKind.Local).AddTicks(6518) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "created_at", "resolved_at" },
                values: new object[] { new DateTime(2025, 4, 23, 1, 50, 7, 460, DateTimeKind.Local).AddTicks(6557), new DateTime(2025, 4, 23, 2, 50, 7, 460, DateTimeKind.Local).AddTicks(6559) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "created_at", "resolved_at" },
                values: new object[] { new DateTime(2025, 4, 23, 1, 50, 7, 460, DateTimeKind.Local).AddTicks(6561), new DateTime(2025, 4, 23, 3, 50, 7, 460, DateTimeKind.Local).AddTicks(6563) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "created_at", "resolved_at" },
                values: new object[] { new DateTime(2025, 4, 23, 1, 50, 7, 460, DateTimeKind.Local).AddTicks(6565), new DateTime(2025, 4, 23, 4, 50, 7, 460, DateTimeKind.Local).AddTicks(6566) });
        }
    }
}
