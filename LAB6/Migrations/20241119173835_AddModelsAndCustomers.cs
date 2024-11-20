using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace LAB6.Migrations
{
    /// <inheritdoc />
    public partial class AddModelsAndCustomers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Models_ModelCode1",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_MechanicsOnServices_Mechanics_MechanicId1",
                table: "MechanicsOnServices");

            migrationBuilder.DropForeignKey(
                name: "FK_Models_Manufacturers_ManufacturerCode1",
                table: "Models");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceBookings_Cars_CarLicenceNumber",
                table: "ServiceBookings");

            migrationBuilder.DropIndex(
                name: "IX_ServiceBookings_CarLicenceNumber",
                table: "ServiceBookings");

            migrationBuilder.DropColumn(
                name: "CarLicenceNumber",
                table: "ServiceBookings");

            migrationBuilder.AlterColumn<int>(
                name: "ManufacturerCode1",
                table: "Models",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "MechanicId1",
                table: "MechanicsOnServices",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "MechanicId",
                table: "MechanicsOnServices",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<int>(
                name: "ModelCode1",
                table: "Cars",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceBookings_LicenceNumber",
                table: "ServiceBookings",
                column: "LicenceNumber");

            migrationBuilder.CreateIndex(
                name: "IX_Models_ManufacturerCode",
                table: "Models",
                column: "ManufacturerCode");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_EmailAddress",
                table: "Customers",
                column: "EmailAddress",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cars_ModelCode",
                table: "Cars",
                column: "ModelCode");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Models_ModelCode",
                table: "Cars",
                column: "ModelCode",
                principalTable: "Models",
                principalColumn: "ModelCode",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Models_ModelCode1",
                table: "Cars",
                column: "ModelCode1",
                principalTable: "Models",
                principalColumn: "ModelCode");

            migrationBuilder.AddForeignKey(
                name: "FK_MechanicsOnServices_Mechanics_MechanicId",
                table: "MechanicsOnServices",
                column: "MechanicId",
                principalTable: "Mechanics",
                principalColumn: "MechanicId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MechanicsOnServices_Mechanics_MechanicId1",
                table: "MechanicsOnServices",
                column: "MechanicId1",
                principalTable: "Mechanics",
                principalColumn: "MechanicId");

            migrationBuilder.AddForeignKey(
                name: "FK_Models_Manufacturers_ManufacturerCode",
                table: "Models",
                column: "ManufacturerCode",
                principalTable: "Manufacturers",
                principalColumn: "ManufacturerCode",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Models_Manufacturers_ManufacturerCode1",
                table: "Models",
                column: "ManufacturerCode1",
                principalTable: "Manufacturers",
                principalColumn: "ManufacturerCode");

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceBookings_Cars_LicenceNumber",
                table: "ServiceBookings",
                column: "LicenceNumber",
                principalTable: "Cars",
                principalColumn: "LicenceNumber",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Models_ModelCode",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Models_ModelCode1",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_MechanicsOnServices_Mechanics_MechanicId",
                table: "MechanicsOnServices");

            migrationBuilder.DropForeignKey(
                name: "FK_MechanicsOnServices_Mechanics_MechanicId1",
                table: "MechanicsOnServices");

            migrationBuilder.DropForeignKey(
                name: "FK_Models_Manufacturers_ManufacturerCode",
                table: "Models");

            migrationBuilder.DropForeignKey(
                name: "FK_Models_Manufacturers_ManufacturerCode1",
                table: "Models");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceBookings_Cars_LicenceNumber",
                table: "ServiceBookings");

            migrationBuilder.DropIndex(
                name: "IX_ServiceBookings_LicenceNumber",
                table: "ServiceBookings");

            migrationBuilder.DropIndex(
                name: "IX_Models_ManufacturerCode",
                table: "Models");

            migrationBuilder.DropIndex(
                name: "IX_Customers_EmailAddress",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Cars_ModelCode",
                table: "Cars");

            migrationBuilder.AddColumn<string>(
                name: "CarLicenceNumber",
                table: "ServiceBookings",
                type: "text",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ManufacturerCode1",
                table: "Models",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MechanicId1",
                table: "MechanicsOnServices",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MechanicId",
                table: "MechanicsOnServices",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<int>(
                name: "ModelCode1",
                table: "Cars",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ServiceBookings_CarLicenceNumber",
                table: "ServiceBookings",
                column: "CarLicenceNumber");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Models_ModelCode1",
                table: "Cars",
                column: "ModelCode1",
                principalTable: "Models",
                principalColumn: "ModelCode",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MechanicsOnServices_Mechanics_MechanicId1",
                table: "MechanicsOnServices",
                column: "MechanicId1",
                principalTable: "Mechanics",
                principalColumn: "MechanicId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Models_Manufacturers_ManufacturerCode1",
                table: "Models",
                column: "ManufacturerCode1",
                principalTable: "Manufacturers",
                principalColumn: "ManufacturerCode",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceBookings_Cars_CarLicenceNumber",
                table: "ServiceBookings",
                column: "CarLicenceNumber",
                principalTable: "Cars",
                principalColumn: "LicenceNumber");
        }
    }
}
