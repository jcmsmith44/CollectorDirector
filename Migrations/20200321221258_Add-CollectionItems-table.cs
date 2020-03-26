using Microsoft.EntityFrameworkCore.Migrations;

namespace CollectorDirector.Migrations
{
    public partial class AddCollectionItemstable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "CollectionItems",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Condition",
                table: "CollectionItems",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Value",
                table: "CollectionItems",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "CollectionItems");

            migrationBuilder.DropColumn(
                name: "Condition",
                table: "CollectionItems");

            migrationBuilder.DropColumn(
                name: "Value",
                table: "CollectionItems");
        }
    }
}
