using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DfaCRUDApplication.Migrations
{
    /// <inheritdoc />
    public partial class First : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Sid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Sname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SGender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SDob = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Sid);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Students");
        }
    }
}
