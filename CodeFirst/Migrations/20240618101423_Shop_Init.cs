using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CodeFirst.Migrations
{
    /// <inheritdoc />
    public partial class Shop_Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mail = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: true),
                    Type = table.Column<int>(type: "int", nullable: false),
                    ClientId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "Address", "Age", "City", "Mail", "Name" },
                values: new object[,]
                {
                    { 1, "115 rue Fontgiève", 36, "Clermont-Ferrand", "scheveny@gmail.com", "Sylvain Cheveny" },
                    { 2, "12 avenue des Champs-Élysées", 28, "Paris", "marie.dubois@gmail.com", "Marie Dubois" },
                    { 3, "8 rue de la Paix", 45, "Lyon", "paul.martin@gmail.com", "Paul Martin" },
                    { 4, "20 rue Victor Hugo", 32, "Marseille", "sophie.bernard@gmail.com", "Sophie Bernard" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "ClientId", "Description", "Name", "Price", "Type" },
                values: new object[,]
                {
                    { 1, 1, "Pêché en Atlantique Nord-Est", "Dos de cabillaud", 44.899999999999999, 1 },
                    { 2, 2, "Origine France", "Filet de bœuf", 34.5, 0 },
                    { 3, 3, "Origine France", "Pomme Granny Smith", 2.2999999999999998, 2 },
                    { 4, 4, "Cultivées sans pesticides", "Carottes bio", 3.1000000000000001, 3 },
                    { 5, 1, "Fromage au lait cru", "Camembert de Normandie", 5.5, 4 },
                    { 6, 2, "Cuit au four à bois", "Pain de campagne", 4.2000000000000002, 5 },
                    { 7, 3, "Pâtisserie artisanale", "Croissant", 1.5, 6 },
                    { 8, 4, "Préparée maison", "Ratatouille en conserve", 6.7999999999999998, 7 },
                    { 9, 1, "Surgelés rapidement après récolte", "Mélange de légumes surgelés", 4.0, 8 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clients_Mail",
                table: "Clients",
                column: "Mail",
                unique: true,
                filter: "[Mail] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ClientId",
                table: "Products",
                column: "ClientId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Clients");
        }
    }
}
