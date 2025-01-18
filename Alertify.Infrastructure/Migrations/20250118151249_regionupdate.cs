using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Alertify.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class regionupdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
           table: "Regions",
           columns: new[] { "Id", "ShortName", "FullName", "CreatedAt" },
           values: new object[,]
           {
                 { 1, "1", "Тошкент шаҳри", DateTime.UtcNow },
                    { 2, "2", "Тошкент вилояти", DateTime.UtcNow },
                    { 3, "3", "Андижон", DateTime.UtcNow },
                    { 4, "4", "Бухоро", DateTime.UtcNow },
                    { 5, "5", "Жиззах", DateTime.UtcNow },
                    { 6, "6", "Қорақалпоғистон Республикаси", DateTime.UtcNow },
                    { 7, "7", "Қашқадарё", DateTime.UtcNow },
                    { 8, "8", "Навоий", DateTime.UtcNow },
                    { 9, "9", "Наманган", DateTime.UtcNow },
                    { 10, "10", "Самарқанд", DateTime.UtcNow },
                    { 11, "11", "Сурхондарё", DateTime.UtcNow },
                    { 12, "12", "Сирдарё", DateTime.UtcNow },
                    { 13, "13", "Фарғона", DateTime.UtcNow },
                    { 14, "14", "Хоразм", DateTime.UtcNow }
           });



            migrationBuilder.InsertData(
                table: "Districts",
                columns: new[] { "Id", "RegionId", "FullName", "ShortName", "CreatedAt" },
                values: new object[,]
                {
                     { 202, 14, "Урганч тумани", "Urganj", DateTime.UtcNow },
                    { 135, 10, "Каттақўрғон тумани", "Kattaqorgon", DateTime.UtcNow },
                    { 1, 1, "Бектемир", "Bektemir", DateTime.UtcNow },
                    { 2, 1, "Мирзо Улуғбек", "Mirzo Ulugbek", DateTime.UtcNow },
                    { 3, 1, "Миробод", "Mirobod", DateTime.UtcNow },
                    { 4, 1, "Олмазор", "Olmazor", DateTime.UtcNow },
                    { 5, 1, "Сергели", "Sergeli", DateTime.UtcNow },
                    { 6, 1, "Учтепа", "Uchtepa", DateTime.UtcNow },
                    { 7, 1, "Яшнобод", "Yashnobod", DateTime.UtcNow },
                    { 8, 1, "Чилонзор", "Chilonzor", DateTime.UtcNow },
                    { 9, 1, "Шайхонтоҳур", "Shaykhontohur", DateTime.UtcNow },
                    { 10, 1, "Юнусобод", "Yunusobod", DateTime.UtcNow },
                    { 11, 1, "Яккасарой", "Yakkasaroy", DateTime.UtcNow },
                    { 12, 2, "Бўстонлиқ", "Bustonliq", DateTime.UtcNow },
                    { 13, 2, "Оққўрғон", "Oqqorgon", DateTime.UtcNow },
                    { 14, 2, "Охангарон", "Ohangaron", DateTime.UtcNow },
                    { 15, 2, "Бекобод", "Bekobod", DateTime.UtcNow },
                    { 16, 2, "Бука", "Buka", DateTime.UtcNow },
                    { 17, 2, "Зангиота", "Zangiota", DateTime.UtcNow },
                    { 18, 2, "Қибрай", "Qibray", DateTime.UtcNow },
                    { 19, 2, "Қуйичирчиқ", "Quyichirchiq", DateTime.UtcNow },
                    { 20, 2, "Паркент", "Parkent", DateTime.UtcNow },
                    { 21, 2, "Пскент", "Piskent", DateTime.UtcNow },
                    { 22, 2, "Тошкент", "Toshkent", DateTime.UtcNow },
                    { 23, 2, "Ўртачирчиқ", "O'rtachirchiq", DateTime.UtcNow },
                    { 24, 2, "Чиноз", "Chinoz", DateTime.UtcNow },
                    { 25, 2, "Юқоричирчиқ", "Yuqorichirchiq", DateTime.UtcNow },
                    { 26, 2, "Янгийўл", "Yangiyol", DateTime.UtcNow },
                    { 27, 2, "Олмалиқ шаҳри", "Olmaliq", DateTime.UtcNow },
                    { 28, 2, "Aнгрен шаҳри", "Angren", DateTime.UtcNow },
                    { 29, 2, "Охангарон шаҳри", "Ohangaron City", DateTime.UtcNow },
                    { 30, 2, "Бекобод шаҳри", "Bekobod City", DateTime.UtcNow },
                    { 31, 2, "Чирчиқ шаҳри", "Chirchiq", DateTime.UtcNow },
                    { 32, 2, "Янгийўл шаҳри", "Yangiyol City", DateTime.UtcNow },
                    { 33, 3, "Aндижон шаҳри", "Andijon", DateTime.UtcNow },
                    { 34, 3, "Aсака шаҳри", "Asaka", DateTime.UtcNow }
        });


            migrationBuilder.InsertData(
                table: "OrganizationClassifications",
                columns: new[] { "Id", "ShortName", "FullName", "CreatedAt" },
                values: new object[,]
                {
                    { 1, "O'quv markaz", "O'quv markaz", DateTime.UtcNow },
                    { 2, "Ishlab chiqarish","Ishlab chiqarish",  DateTime.UtcNow },
                    { 3, "Savdo", "Savdo", DateTime.UtcNow },
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            for (int id = 1; id <= 14; id++)
            {
                migrationBuilder.DeleteData(
                    table: "Regions",
                    keyColumn: "Id",
                    keyValue: id);
            }

            // Delete the inserted rows
            for (int id = 1; id <= 202; id++)
            {
                migrationBuilder.DeleteData(
                    table: "Districts",
                    keyColumn: "Id",
                    keyValue: id);
            }

            // Delete the inserted rows
            for (int id = 1; id <= 202; id++)
            {
                migrationBuilder.DeleteData(
                    table: "OrganizationClassifications",
                    keyColumn: "Id",
                    keyValue: id);
            }
        }
    }
}
