using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class InitalMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "Householders",
                schema: "dbo",
                columns: table => new
                {
                    HouseholderNumber = table.Column<int>(type: "int", nullable: false),
                    HouseholderTc = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    HaveCar = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Householders", x => x.HouseholderNumber);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Role = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    PasswordRetryCount = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HouseDetails",
                schema: "dbo",
                columns: table => new
                {
                    HouseId = table.Column<int>(type: "int", nullable: false),
                    HouseholderNumber = table.Column<int>(type: "int", nullable: false),
                    Floor = table.Column<int>(type: "int", maxLength: 2, nullable: false),
                    IsEmpty = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    IsSmall = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HouseDetails", x => x.HouseId);
                    table.ForeignKey(
                        name: "FK_HouseDetails_Householders_HouseholderNumber",
                        column: x => x.HouseholderNumber,
                        principalSchema: "dbo",
                        principalTable: "Householders",
                        principalColumn: "HouseholderNumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bills",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HouseId = table.Column<int>(type: "int", nullable: false),
                    Dues = table.Column<int>(type: "int", maxLength: 5, nullable: false),
                    ElectricBill = table.Column<decimal>(type: "decimal(15,2)", precision: 15, scale: 2, nullable: false, defaultValue: 0m),
                    WaterBill = table.Column<decimal>(type: "decimal(15,2)", precision: 15, scale: 2, nullable: false, defaultValue: 0m),
                    GasBill = table.Column<decimal>(type: "decimal(15,2)", precision: 15, scale: 2, nullable: false, defaultValue: 0m),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bills_HouseDetails_HouseId",
                        column: x => x.HouseId,
                        principalSchema: "dbo",
                        principalTable: "HouseDetails",
                        principalColumn: "HouseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bills_HouseId",
                schema: "dbo",
                table: "Bills",
                column: "HouseId");

            migrationBuilder.CreateIndex(
                name: "IX_HouseDetails_HouseholderNumber",
                schema: "dbo",
                table: "HouseDetails",
                column: "HouseholderNumber");

            migrationBuilder.CreateIndex(
                name: "IX_HouseDetails_HouseId",
                schema: "dbo",
                table: "HouseDetails",
                column: "HouseId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Householders_HouseholderNumber",
                schema: "dbo",
                table: "Householders",
                column: "HouseholderNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserName",
                schema: "dbo",
                table: "Users",
                column: "UserName",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bills",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Users",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "HouseDetails",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Householders",
                schema: "dbo");
        }
    }
}
