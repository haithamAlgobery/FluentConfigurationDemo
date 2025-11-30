using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FluentConfiguration.Migrations
{
    /// <inheritdoc />
    public partial class CreateNewDataBase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Units",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UnitSize = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UnitType = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    ApartmentAmenities_FloorNumber = table.Column<int>(type: "int", nullable: true),
                    ApartmentAmenities_HasBalcony = table.Column<bool>(type: "bit", nullable: true),
                    HouseAmenities_NumberOfBedrooms = table.Column<int>(type: "int", nullable: true),
                    HouseAmenities_HasGarge = table.Column<int>(type: "int", nullable: true),
                    OfficeAmenities_NumberOfWorkspaces = table.Column<int>(type: "int", nullable: true),
                    OfficeAmenities_HasConferenceRoom = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Units", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Units");
        }
    }
}
