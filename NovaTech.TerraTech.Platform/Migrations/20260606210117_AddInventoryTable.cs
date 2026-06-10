using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace NovaTech.TerraTech.Platform.Migrations
{
    /// <inheritdoc />
    public partial class AddInventoryTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_notifications",
                table: "notifications");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "notifications",
                newName: "title");

            migrationBuilder.RenameColumn(
                name: "Message",
                table: "notifications",
                newName: "message");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "notifications",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "notifications",
                newName: "updated_at");

            migrationBuilder.RenameColumn(
                name: "ProfileId",
                table: "notifications",
                newName: "profile_id");

            migrationBuilder.RenameColumn(
                name: "IsRead",
                table: "notifications",
                newName: "is_read");

            migrationBuilder.RenameColumn(
                name: "IsAlert",
                table: "notifications",
                newName: "is_alert");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "notifications",
                newName: "created_at");

            migrationBuilder.AddPrimaryKey(
                name: "p_k_notifications",
                table: "notifications",
                column: "id");

            migrationBuilder.CreateTable(
                name: "inventories",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    product_id = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    stock_quantity = table.Column<int>(type: "int", nullable: false),
                    warehouse_location = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    created_at = table.Column<DateTimeOffset>(type: "datetime", nullable: true),
                    updated_at = table.Column<DateTimeOffset>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("p_k_inventories", x => x.id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "inventories");

            migrationBuilder.DropPrimaryKey(
                name: "p_k_notifications",
                table: "notifications");

            migrationBuilder.RenameColumn(
                name: "title",
                table: "notifications",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "message",
                table: "notifications",
                newName: "Message");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "notifications",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "updated_at",
                table: "notifications",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "profile_id",
                table: "notifications",
                newName: "ProfileId");

            migrationBuilder.RenameColumn(
                name: "is_read",
                table: "notifications",
                newName: "IsRead");

            migrationBuilder.RenameColumn(
                name: "is_alert",
                table: "notifications",
                newName: "IsAlert");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "notifications",
                newName: "CreatedAt");

            migrationBuilder.AddPrimaryKey(
                name: "PK_notifications",
                table: "notifications",
                column: "Id");
        }
    }
}
