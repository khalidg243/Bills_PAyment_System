using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bills_Payment_API.Migrations
{
    /// <inheritdoc />
    public partial class newInitialMig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    CP_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CP_Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    CP_Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CP_Password = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CP_Phone = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.CP_Id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    C_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    C_Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    C_Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    C_Password = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    C_Phone = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    C_Passport_No = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.C_Id);
                });

            migrationBuilder.CreateTable(
                name: "Bills",
                columns: table => new
                {
                    B_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Customer_Id = table.Column<int>(type: "int", nullable: false),
                    Company_Id = table.Column<int>(type: "int", nullable: false),
                    B_Amount = table.Column<float>(type: "real", nullable: false),
                    B_CreationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    B_DueDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    B_Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bills", x => x.B_Id);
                    table.ForeignKey(
                        name: "FK_Bills_Companies_Company_Id",
                        column: x => x.Company_Id,
                        principalTable: "Companies",
                        principalColumn: "CP_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bills_Customers_Customer_Id",
                        column: x => x.Customer_Id,
                        principalTable: "Customers",
                        principalColumn: "C_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bills_Company_Id",
                table: "Bills",
                column: "Company_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Bills_Customer_Id",
                table: "Bills",
                column: "Customer_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Companies_CP_Email_CP_Phone",
                table: "Companies",
                columns: new[] { "CP_Email", "CP_Phone" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Customers_C_Passport_No_C_Email_C_Phone",
                table: "Customers",
                columns: new[] { "C_Passport_No", "C_Email", "C_Phone" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bills");

            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
