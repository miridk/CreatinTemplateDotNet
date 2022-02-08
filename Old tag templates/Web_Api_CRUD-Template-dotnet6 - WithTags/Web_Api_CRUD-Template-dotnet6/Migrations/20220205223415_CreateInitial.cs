using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TAG_{'modelName'}.Migrations
{
    public partial class CreateInitial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TAG_{'modelName'}s",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TAG_{'propertiesEf'}
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TAG_{'modelName'}s", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TAG_{'modelName'}s");
        }
    }
}
