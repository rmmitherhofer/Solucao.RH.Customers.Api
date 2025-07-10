using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Solucao.RH.Customers.Data.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence<int>(
                name: "SQ_Customer");

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<long>(type: "bigint", nullable: false, defaultValueSql: "NEXT VALUE FOR SQ_Customer"),
                    Cnpj = table.Column<string>(type: "varchar(14)", nullable: false),
                    Name = table.Column<string>(type: "varchar(150)", nullable: false),
                    Telephone = table.Column<string>(type: "varchar(15)", nullable: true),
                    Cellphone = table.Column<string>(type: "varchar(15)", nullable: true),
                    Email = table.Column<string>(type: "varchar(254)", nullable: true),
                    Site = table.Column<string>(type: "varchar(150)", nullable: true),
                    FoundationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    StateRegistration = table.Column<string>(type: "varchar(150)", nullable: true),
                    MunicipalRegistration = table.Column<string>(type: "varchar(150)", nullable: true),
                    Segment = table.Column<string>(type: "varchar(150)", nullable: true),
                    CompanySize = table.Column<string>(type: "varchar(150)", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    BusinessArea = table.Column<string>(type: "varchar(150)", nullable: true),
                    Classification = table.Column<string>(type: "varchar(150)", nullable: true),
                    Type = table.Column<string>(type: "varchar(150)", nullable: true),
                    Origin = table.Column<string>(type: "varchar(150)", nullable: true),
                    RegistrationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateChanged = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Street = table.Column<string>(type: "varchar(150)", nullable: false),
                    Number = table.Column<string>(type: "varchar(10)", nullable: true),
                    Complement = table.Column<string>(type: "varchar(60)", nullable: true),
                    District = table.Column<string>(type: "varchar(120)", nullable: true),
                    ZipCode = table.Column<string>(type: "varchar(10)", nullable: false),
                    City = table.Column<string>(type: "varchar(120)", nullable: false),
                    State = table.Column<string>(type: "varchar(120)", nullable: false),
                    Country = table.Column<string>(type: "varchar(120)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RegistrationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateChanged = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Addresses_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "varchar(150)", nullable: false),
                    Telephone = table.Column<string>(type: "varchar(15)", nullable: true),
                    CellPhone = table.Column<string>(type: "varchar(15)", nullable: true),
                    WhatsApp = table.Column<string>(type: "varchar(15)", nullable: true),
                    Email = table.Column<string>(type: "varchar(254)", nullable: true),
                    Department = table.Column<string>(type: "varchar(150)", nullable: true),
                    Position = table.Column<string>(type: "varchar(150)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RegistrationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateChanged = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contacts_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_CustomerId",
                table: "Addresses",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_CustomerId",
                table: "Contacts",
                column: "CustomerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropSequence(
                name: "SQ_Customer");
        }
    }
}
