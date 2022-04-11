using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FDLsys.Migrations
{
    public partial class tablesmig : Migration
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

            migrationBuilder.CreateTable(
                name: "Flight",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    cie = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    datevol = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    escalDEP = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    escalARR = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SequencesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flight", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Flight_Sequences_SequencesId",
                        column: x => x.SequencesId,
                        principalTable: "Sequences",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    FlightId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Equipes_Flight_FlightId",
                        column: x => x.FlightId,
                        principalTable: "Flight",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Equipes_FlightId",
                table: "Equipes",
                column: "FlightId");

            migrationBuilder.CreateIndex(
                name: "IX_Flight_SequencesId",
                table: "Flight",
                column: "SequencesId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Equipes");

            migrationBuilder.DropTable(
                name: "Flight");

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
