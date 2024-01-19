using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace E_KTPWeb.Migrations
{
    /// <inheritdoc />
    public partial class SeederDataToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "DataKTP",
                columns: new[] { "Id", "NIK", "Name" },
                values: new object[,]
                {
                    { 1, 1234567891111113L, "Ahmad Subardjo" },
                    { 2, 1232123456787654L, "Ahmad Hadsii" },
                    { 3, 1234543212345678L, "Surdi Nurdo" },
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DataKTP",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "DataKTP",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "DataKTP",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
