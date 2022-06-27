using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TripLog.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Trips",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Destination = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Accomidations = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EndDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccomidationPhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AccomidationEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThingsToDo1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThingsToDo2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThingsToDo3 = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trips", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Trips",
                columns: new[] { "Id", "AccomidationEmail", "AccomidationPhone", "Accomidations", "Destination", "EndDate", "StartDate", "ThingsToDo1", "ThingsToDo2", "ThingsToDo3" },
                values: new object[] { 1, "resortworld@resort.com", "475-890-1234", "Resort World", "Puerto Rico", "05/27/2021", "05/20/2021", "visit beach", "have a margarita", "tan" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Trips");
        }
    }
}
