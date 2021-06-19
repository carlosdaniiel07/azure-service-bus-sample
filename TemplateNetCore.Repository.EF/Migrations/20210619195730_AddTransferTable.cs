using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TemplateNetCore.Repository.EF.Migrations
{
    public partial class AddTransferTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "transfer",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    value = table.Column<decimal>(type: "decimal(11,2)", nullable: false),
                    from_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    to_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    status = table.Column<byte>(type: "tinyint", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    deleted_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_transfer", x => x.id);
                    table.ForeignKey(
                        name: "FK_transfer_from_id_user",
                        column: x => x.from_id,
                        principalTable: "user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_transfer_to_id_user",
                        column: x => x.to_id,
                        principalTable: "user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_transfer_from_id",
                table: "transfer",
                column: "from_id");

            migrationBuilder.CreateIndex(
                name: "IX_transfer_to_id",
                table: "transfer",
                column: "to_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "transfer");
        }
    }
}
