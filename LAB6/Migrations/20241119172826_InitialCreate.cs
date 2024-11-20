using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace LAB6.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Gender = table.Column<string>(type: "text", nullable: false),
                    EmailAddress = table.Column<string>(type: "text", nullable: false),
                    PhoneNumber = table.Column<string>(type: "text", nullable: false),
                    AddressLine1 = table.Column<string>(type: "text", nullable: false),
                    AddressLine2 = table.Column<string>(type: "text", nullable: false),
                    AddressLine3 = table.Column<string>(type: "text", nullable: false),
                    City = table.Column<string>(type: "text", nullable: false),
                    State = table.Column<string>(type: "text", nullable: false),
                    OtherCustomerDetails = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "Manufacturers",
                columns: table => new
                {
                    ManufacturerCode = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ManufacturerName = table.Column<string>(type: "text", nullable: false),
                    OtherManufacturerDetails = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manufacturers", x => x.ManufacturerCode);
                });

            migrationBuilder.CreateTable(
                name: "Mechanics",
                columns: table => new
                {
                    MechanicId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MechanicName = table.Column<string>(type: "text", nullable: false),
                    OtherMechanicDetails = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mechanics", x => x.MechanicId);
                });

            migrationBuilder.CreateTable(
                name: "Models",
                columns: table => new
                {
                    ModelCode = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ManufacturerCode = table.Column<int>(type: "integer", nullable: false),
                    ModelName = table.Column<string>(type: "text", nullable: false),
                    OtherModelDetails = table.Column<string>(type: "text", nullable: false),
                    ManufacturerCode1 = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Models", x => x.ModelCode);
                    table.ForeignKey(
                        name: "FK_Models_Manufacturers_ManufacturerCode1",
                        column: x => x.ManufacturerCode1,
                        principalTable: "Manufacturers",
                        principalColumn: "ManufacturerCode",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    LicenceNumber = table.Column<string>(type: "text", nullable: false),
                    ModelCode = table.Column<int>(type: "integer", nullable: false),
                    CustomerId = table.Column<int>(type: "integer", nullable: false),
                    CurrentMileage = table.Column<int>(type: "integer", nullable: false),
                    EngineSize = table.Column<double>(type: "double precision", nullable: false),
                    OtherCarDetails = table.Column<string>(type: "text", nullable: false),
                    ModelCode1 = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.LicenceNumber);
                    table.ForeignKey(
                        name: "FK_Cars_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cars_Models_ModelCode1",
                        column: x => x.ModelCode1,
                        principalTable: "Models",
                        principalColumn: "ModelCode",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ServiceBookings",
                columns: table => new
                {
                    SvcBookingId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CustomerId = table.Column<int>(type: "integer", nullable: false),
                    LicenceNumber = table.Column<string>(type: "text", nullable: false),
                    PaymentReceivedYN = table.Column<bool>(type: "boolean", nullable: false),
                    DateTimeOfService = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    OtherSvcBookingDetails = table.Column<string>(type: "text", nullable: false),
                    CarLicenceNumber = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceBookings", x => x.SvcBookingId);
                    table.ForeignKey(
                        name: "FK_ServiceBookings_Cars_CarLicenceNumber",
                        column: x => x.CarLicenceNumber,
                        principalTable: "Cars",
                        principalColumn: "LicenceNumber");
                    table.ForeignKey(
                        name: "FK_ServiceBookings_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MechanicsOnServices",
                columns: table => new
                {
                    MechanicId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SvcBookingId = table.Column<int>(type: "integer", nullable: false),
                    MechanicId1 = table.Column<int>(type: "integer", nullable: false),
                    ServiceBookingSvcBookingId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MechanicsOnServices", x => x.MechanicId);
                    table.ForeignKey(
                        name: "FK_MechanicsOnServices_Mechanics_MechanicId1",
                        column: x => x.MechanicId1,
                        principalTable: "Mechanics",
                        principalColumn: "MechanicId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MechanicsOnServices_ServiceBookings_ServiceBookingSvcBookin~",
                        column: x => x.ServiceBookingSvcBookingId,
                        principalTable: "ServiceBookings",
                        principalColumn: "SvcBookingId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cars_CustomerId",
                table: "Cars",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_ModelCode1",
                table: "Cars",
                column: "ModelCode1");

            migrationBuilder.CreateIndex(
                name: "IX_MechanicsOnServices_MechanicId1",
                table: "MechanicsOnServices",
                column: "MechanicId1");

            migrationBuilder.CreateIndex(
                name: "IX_MechanicsOnServices_ServiceBookingSvcBookingId",
                table: "MechanicsOnServices",
                column: "ServiceBookingSvcBookingId");

            migrationBuilder.CreateIndex(
                name: "IX_Models_ManufacturerCode1",
                table: "Models",
                column: "ManufacturerCode1");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceBookings_CarLicenceNumber",
                table: "ServiceBookings",
                column: "CarLicenceNumber");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceBookings_CustomerId",
                table: "ServiceBookings",
                column: "CustomerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MechanicsOnServices");

            migrationBuilder.DropTable(
                name: "Mechanics");

            migrationBuilder.DropTable(
                name: "ServiceBookings");

            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Models");

            migrationBuilder.DropTable(
                name: "Manufacturers");
        }
    }
}
