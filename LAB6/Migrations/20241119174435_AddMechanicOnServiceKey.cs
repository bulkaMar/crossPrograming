using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LAB6.Migrations
{
    /// <inheritdoc />
    public partial class AddMechanicOnServiceKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "FK_MechanicsOnServices_ServiceBookings_ServiceBookingSvcBookin~",
                table: "MechanicsOnServices");

            migrationBuilder.DropForeignKey(
                name: "FK_Models_Manufacturers_ManufacturerCode",
                table: "Models");

            migrationBuilder.DropForeignKey(
                name: "FK_Models_Manufacturers_ManufacturerCode1",
                table: "Models");

            migrationBuilder.DropIndex(
                name: "IX_Models_ManufacturerCode1",
                table: "Models");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MechanicsOnServices",
                table: "MechanicsOnServices");

            migrationBuilder.DropIndex(
                name: "IX_MechanicsOnServices_MechanicId1",
                table: "MechanicsOnServices");

            migrationBuilder.DropIndex(
                name: "IX_MechanicsOnServices_ServiceBookingSvcBookingId",
                table: "MechanicsOnServices");

            migrationBuilder.DropIndex(
                name: "IX_Cars_ModelCode1",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "ManufacturerCode1",
                table: "Models");

            migrationBuilder.DropColumn(
                name: "MechanicId1",
                table: "MechanicsOnServices");

            migrationBuilder.DropColumn(
                name: "ServiceBookingSvcBookingId",
                table: "MechanicsOnServices");

            migrationBuilder.DropColumn(
                name: "ModelCode1",
                table: "Cars");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MechanicsOnServices",
                table: "MechanicsOnServices",
                columns: new[] { "MechanicId", "SvcBookingId" });

            migrationBuilder.CreateIndex(
                name: "IX_MechanicsOnServices_SvcBookingId",
                table: "MechanicsOnServices",
                column: "SvcBookingId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Models_ModelCode",
                table: "Cars",
                column: "ModelCode",
                principalTable: "Models",
                principalColumn: "ModelCode",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MechanicsOnServices_Mechanics_MechanicId",
                table: "MechanicsOnServices",
                column: "MechanicId",
                principalTable: "Mechanics",
                principalColumn: "MechanicId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MechanicsOnServices_ServiceBookings_SvcBookingId",
                table: "MechanicsOnServices",
                column: "SvcBookingId",
                principalTable: "ServiceBookings",
                principalColumn: "SvcBookingId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Models_Manufacturers_ManufacturerCode",
                table: "Models",
                column: "ManufacturerCode",
                principalTable: "Manufacturers",
                principalColumn: "ManufacturerCode",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Models_ModelCode",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_MechanicsOnServices_Mechanics_MechanicId",
                table: "MechanicsOnServices");

            migrationBuilder.DropForeignKey(
                name: "FK_MechanicsOnServices_ServiceBookings_SvcBookingId",
                table: "MechanicsOnServices");

            migrationBuilder.DropForeignKey(
                name: "FK_Models_Manufacturers_ManufacturerCode",
                table: "Models");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MechanicsOnServices",
                table: "MechanicsOnServices");

            migrationBuilder.DropIndex(
                name: "IX_MechanicsOnServices_SvcBookingId",
                table: "MechanicsOnServices");

            migrationBuilder.AddColumn<int>(
                name: "ManufacturerCode1",
                table: "Models",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MechanicId1",
                table: "MechanicsOnServices",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ServiceBookingSvcBookingId",
                table: "MechanicsOnServices",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ModelCode1",
                table: "Cars",
                type: "integer",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_MechanicsOnServices",
                table: "MechanicsOnServices",
                column: "MechanicId");

            migrationBuilder.CreateIndex(
                name: "IX_Models_ManufacturerCode1",
                table: "Models",
                column: "ManufacturerCode1");

            migrationBuilder.CreateIndex(
                name: "IX_MechanicsOnServices_MechanicId1",
                table: "MechanicsOnServices",
                column: "MechanicId1");

            migrationBuilder.CreateIndex(
                name: "IX_MechanicsOnServices_ServiceBookingSvcBookingId",
                table: "MechanicsOnServices",
                column: "ServiceBookingSvcBookingId");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_ModelCode1",
                table: "Cars",
                column: "ModelCode1");

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
                name: "FK_MechanicsOnServices_ServiceBookings_ServiceBookingSvcBookin~",
                table: "MechanicsOnServices",
                column: "ServiceBookingSvcBookingId",
                principalTable: "ServiceBookings",
                principalColumn: "SvcBookingId",
                onDelete: ReferentialAction.Cascade);

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
        }
    }
}
