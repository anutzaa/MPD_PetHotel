using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetHotel.Migrations
{
    /// <inheritdoc />
    public partial class changes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Comments",
                table: "Pet");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Pet");

            migrationBuilder.DropColumn(
                name: "Race",
                table: "Pet");

            migrationBuilder.RenameColumn(
                name: "Sex",
                table: "Pet",
                newName: "PetName");

            migrationBuilder.AlterColumn<bool>(
                name: "Availability",
                table: "Rooms",
                type: "bit",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Rooms",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Rooms",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "hasSpecialNeeds",
                table: "Pet",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Booking",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "hasSpecialNeeds",
                table: "Pet");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Booking");

            migrationBuilder.RenameColumn(
                name: "PetName",
                table: "Pet",
                newName: "Sex");

            migrationBuilder.AlterColumn<int>(
                name: "Availability",
                table: "Rooms",
                type: "int",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AddColumn<string>(
                name: "Comments",
                table: "Pet",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Pet",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Race",
                table: "Pet",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
