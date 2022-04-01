using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FDLsys.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "listesfdl",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FDay_time = table.Column<int>(type: "int", nullable: false),
                    Fnight_time = table.Column<int>(type: "int", nullable: false),
                    FDay_desert_time = table.Column<int>(type: "int", nullable: false),
                    Fnight_desert_time = table.Column<int>(type: "int", nullable: false),
                    year = table.Column<int>(type: "int", nullable: false),
                    month = table.Column<int>(type: "int", nullable: false),
                    airplane_reg = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    captain_remarks = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    total_block = table.Column<int>(type: "int", nullable: false),
                    total_airborn = table.Column<int>(type: "int", nullable: false),
                    deadhead = table.Column<int>(type: "int", nullable: false),
                    matricule_CDB = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Edition_number = table.Column<int>(type: "int", nullable: false),
                    validation = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_listesfdl", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Matricule = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Passwordhash = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    PassworSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Matricule);
                });

            migrationBuilder.CreateTable(
                name: "Sequences",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    expected_dep_time = table.Column<int>(type: "int", nullable: false),
                    bt_in_minute = table.Column<int>(type: "int", nullable: false),
                    bt_in_hour = table.Column<int>(type: "int", nullable: false),
                    bt_out_minute = table.Column<int>(type: "int", nullable: false),
                    bt_out_hour = table.Column<int>(type: "int", nullable: false),
                    block_time = table.Column<int>(type: "int", nullable: false),
                    ab_on_hour = table.Column<int>(type: "int", nullable: false),
                    ab_off_hour = table.Column<int>(type: "int", nullable: false),
                    ab_off_minute = table.Column<int>(type: "int", nullable: false),
                    ab_on_minute = table.Column<int>(type: "int", nullable: false),
                    airborn_time = table.Column<int>(type: "int", nullable: false),
                    remaining_fuel_from_previous = table.Column<float>(type: "real", nullable: false),
                    added_fuel = table.Column<float>(type: "real", nullable: false),
                    remaining_fuel = table.Column<float>(type: "real", nullable: false),
                    fuel_at_departure = table.Column<float>(type: "real", nullable: false),
                    used_fuel = table.Column<float>(type: "real", nullable: false),
                    uplift = table.Column<float>(type: "real", nullable: false),
                    listesfdlID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sequences", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sequences_listesfdl_listesfdlID",
                        column: x => x.listesfdlID,
                        principalTable: "listesfdl",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sequences_listesfdlID",
                table: "Sequences",
                column: "listesfdlID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sequences");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "listesfdl");
        }
    }
}
