using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eIMIC223925.DATA.Migrations
{
    public partial class KhoiTao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("139b9d0b-967b-454a-b471-b2bb5f6c7522"),
                column: "ConcurrencyStamp",
                value: "a78dafab-f845-4617-8681-4bb274705783");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "e9a0e9fb-3d16-4b1e-b17c-cbf9f8a25018", "AQAAAAEAACcQAAAAEPb8GCzAXpwpqmFvrW6Bl3x109YpK+2oOcNjIRzCR7pRiGm+QpLQRFhUfM6gFR15XQ==" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2022, 11, 22, 21, 16, 16, 525, DateTimeKind.Local).AddTicks(3947));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("139b9d0b-967b-454a-b471-b2bb5f6c7522"),
                column: "ConcurrencyStamp",
                value: "e60f90b7-71fb-4cda-81ae-c592b87c564a");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "f3404b8c-90df-4bc9-bf0d-69610a3ca5e1", "AQAAAAEAACcQAAAAEJMelXv9CXaz0j2RVrs07uwvWZ+ulo/IrzPf/n/JLJGqVePQ6c46o81USCzeZOFF1Q==" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2022, 11, 1, 18, 23, 49, 979, DateTimeKind.Local).AddTicks(4624));
        }
    }
}
