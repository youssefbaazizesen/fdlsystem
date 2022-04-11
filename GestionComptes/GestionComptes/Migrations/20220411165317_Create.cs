using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FDLsys.Migrations
{
    public partial class Create : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "matricule_CDB",
                table: "listesfdl",
                newName: "MatriculeId");

            migrationBuilder.AlterColumn<string>(
                name: "expected_dep_time",
                table: "Sequences",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "FlightId",
                table: "Sequences",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Flight",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cie = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    datevol = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    escalDEP = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    escalARR = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flight", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Equipes",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    cle = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    fonction = table.Column<int>(type: "int", nullable: false),
                    first_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    last_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FlightId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FlightId1 = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Equipes_Flight_FlightId1",
                        column: x => x.FlightId1,
                        principalTable: "Flight",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sequences_FlightId",
                table: "Sequences",
                column: "FlightId");

            migrationBuilder.CreateIndex(
                name: "IX_Equipes_FlightId1",
                table: "Equipes",
                column: "FlightId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Sequences_Flight_FlightId",
                table: "Sequences",
                column: "FlightId",
                principalTable: "Flight",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sequences_Flight_FlightId",
                table: "Sequences");

            migrationBuilder.DropTable(
                name: "Equipes");

            migrationBuilder.DropTable(
                name: "Flight");

            migrationBuilder.DropIndex(
                name: "IX_Sequences_FlightId",
                table: "Sequences");

            migrationBuilder.DropColumn(
                name: "FlightId",
                table: "Sequences");

            migrationBuilder.RenameColumn(
                name: "MatriculeId",
                table: "listesfdl",
                newName: "matricule_CDB");

            migrationBuilder.AlterColumn<int>(
                name: "expected_dep_time",
                table: "Sequences",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
