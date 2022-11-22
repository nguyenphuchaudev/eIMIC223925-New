using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eIMIC223925.DATA.Migrations
{
    public partial class updatetableProductImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "OrderDate",
                table: "Orders",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 10, 27, 19, 22, 57, 961, DateTimeKind.Local).AddTicks(3157));

            migrationBuilder.CreateTable(
                name: "ProductImages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(nullable: false),
                    ImagePath = table.Column<string>(maxLength: 200, nullable: false),
                    Caption = table.Column<string>(maxLength: 200, nullable: true),
                    IsDefault = table.Column<bool>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    SortOrder = table.Column<int>(nullable: false),
                    FileSize = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductImages_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_ProductImages_ProductId",
                table: "ProductImages",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductImages");

            migrationBuilder.AlterColumn<DateTime>(
                name: "OrderDate",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 27, 19, 22, 57, 961, DateTimeKind.Local).AddTicks(3157),
                oldClrType: typeof(DateTime));

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("139b9d0b-967b-454a-b471-b2bb5f6c7522"),
                column: "ConcurrencyStamp",
                value: "aa5ba64d-49ec-4b35-9c75-defe4140d538");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "4d8668ec-3659-4946-9f1d-58611f5500ce", "AQAAAAEAACcQAAAAENYH9WUA7gxrYUUSlYu+ftnn157+YJ0gnP9hQzfGN3qqlBe5KFGaa9VVrGOu8lYSqw==" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2022, 10, 27, 19, 22, 57, 991, DateTimeKind.Local).AddTicks(433));
        }
    }
}
