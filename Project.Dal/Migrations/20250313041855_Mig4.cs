using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project.Dal.Migrations
{
    /// <inheritdoc />
    public partial class Mig4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Employees_EmployeeId",
                table: "Reservations");

            migrationBuilder.AlterColumn<int>(
                name: "EmployeeId",
                table: "Reservations",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "8716e9b0-b06e-4438-81db-433e5b65c331");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "94c18e03-f2ce-4e90-a2e6-81da4f69659f");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "PasswordHash", "SecurityStamp" },
                values: new object[] { "79d6c051-84f5-460e-a0a8-dd4f27e0b3b2", new DateTime(2025, 3, 13, 7, 18, 55, 426, DateTimeKind.Local).AddTicks(8308), "AQAAAAIAAYagAAAAEIfqxsFqC1BH0IdIzs8royiC3CLoP3caBqJPpTAgLz8u/ZOmtQz60NCIYFYSwtRE/A==", "6e0d8083-d9a1-43a8-b37b-cac2bcb03bff" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9f18bf0c-e4a4-4307-b100-3554c9f992b4", new DateTime(2025, 3, 13, 7, 18, 55, 464, DateTimeKind.Local).AddTicks(9263), "AQAAAAIAAYagAAAAEGEEzFJGH8L87o/i8QmUtqS36vMJhQ6pyVbppQbeqhLGSGVxokV0JO9rXBjd78ouhA==", "bed24bbb-91ae-428b-bb15-b3c7770b1bf9" });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Address", "BirthDate", "CreatedDate", "FirstName", "HireDate", "LastName", "PhoneNumber", "Salary" },
                values: new object[] { "Bandak Sokak 99a, Kırıkkale, Hindistan", new DateTime(1973, 12, 7, 7, 28, 46, 943, DateTimeKind.Local).AddTicks(2009), new DateTime(2025, 3, 13, 7, 18, 55, 388, DateTimeKind.Local).AddTicks(8750), "Aykurt", new DateTime(2020, 8, 26, 17, 24, 15, 31, DateTimeKind.Local).AddTicks(5716), "Yılmazer", "+90-018-849-0-782", 153.32m });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Address", "BirthDate", "CreatedDate", "FirstName", "HireDate", "LastName", "PhoneNumber", "Salary" },
                values: new object[] { "Sevgi Sokak 63c, Aydın, Almanya", new DateTime(2006, 1, 11, 7, 6, 1, 955, DateTimeKind.Local).AddTicks(6571), new DateTime(2025, 3, 13, 7, 18, 55, 388, DateTimeKind.Local).AddTicks(8825), "Bangu", new DateTime(2015, 9, 26, 12, 36, 58, 136, DateTimeKind.Local).AddTicks(7912), "Tunaboylu", "+90-205-553-68-01", 124.10m });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Address", "BirthDate", "CreatedDate", "FirstName", "HireDate", "LastName", "PhoneNumber", "Salary", "Shift" },
                values: new object[] { "Nalbant Sokak 50b, Balıkesir, Sao Tome ve Principe", new DateTime(1972, 6, 24, 11, 57, 49, 157, DateTimeKind.Local).AddTicks(292), new DateTime(2025, 3, 13, 7, 18, 55, 388, DateTimeKind.Local).AddTicks(8917), "Amrak", new DateTime(2021, 8, 5, 0, 33, 18, 377, DateTimeKind.Local).AddTicks(652), "Uluhan", "+90-157-844-8-302", 142.19m, 1 });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Address", "BirthDate", "CreatedDate", "FirstName", "HireDate", "LastName", "PhoneNumber", "Salary" },
                values: new object[] { "Okul Sokak 224, Uşak, Vallis ve Futuna, Fransa", new DateTime(2006, 5, 26, 7, 28, 8, 771, DateTimeKind.Local).AddTicks(5820), new DateTime(2025, 3, 13, 7, 18, 55, 388, DateTimeKind.Local).AddTicks(8999), "Açığ", new DateTime(2015, 12, 13, 8, 58, 11, 553, DateTimeKind.Local).AddTicks(3060), "Durak ", "+90-285-262-5-468", 146.48m });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Address", "BirthDate", "CreatedDate", "FirstName", "HireDate", "LastName", "PhoneNumber", "Salary" },
                values: new object[] { "Kaldırım Sokak 69c, Iğdır, Finlandiya", new DateTime(1983, 9, 5, 21, 48, 20, 432, DateTimeKind.Local).AddTicks(141), new DateTime(2025, 3, 13, 7, 18, 55, 388, DateTimeKind.Local).AddTicks(9056), "Kımızalma", new DateTime(2021, 6, 5, 3, 14, 40, 196, DateTimeKind.Local).AddTicks(7970), "Arıcan", "+90-967-630-91-45", 157.96m });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Address", "BirthDate", "CreatedDate", "FirstName", "HireDate", "LastName", "PhoneNumber", "Salary" },
                values: new object[] { "Harman Yolu Sokak  0, Nevşehir, Fransız Guyanası", new DateTime(1982, 3, 12, 2, 52, 56, 34, DateTimeKind.Local).AddTicks(2857), new DateTime(2025, 3, 13, 7, 18, 55, 388, DateTimeKind.Local).AddTicks(9139), "Ay", new DateTime(2018, 11, 18, 15, 56, 43, 922, DateTimeKind.Local).AddTicks(441), "Akyürek", "+90-680-764-6-333", 158.14m });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Address", "BirthDate", "CreatedDate", "FirstName", "HireDate", "LastName", "PhoneNumber", "Salary", "Shift" },
                values: new object[] { "Kerimoğlu Sokak 7, Eskişehir, Yunanistan", new DateTime(1981, 12, 3, 9, 49, 7, 610, DateTimeKind.Local).AddTicks(1353), new DateTime(2025, 3, 13, 7, 18, 55, 388, DateTimeKind.Local).AddTicks(9213), "Atlıbeğ", new DateTime(2015, 10, 17, 15, 15, 35, 286, DateTimeKind.Local).AddTicks(3737), "Dizdar ", "+90-973-261-1-995", 127.50m, 3 });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Address", "BirthDate", "CreatedDate", "FirstName", "HireDate", "LastName", "PhoneNumber", "Salary", "Shift" },
                values: new object[] { "Bayır Sokak 67c, Karaman, Belçika", new DateTime(1972, 7, 25, 12, 20, 7, 301, DateTimeKind.Local).AddTicks(856), new DateTime(2025, 3, 13, 7, 18, 55, 388, DateTimeKind.Local).AddTicks(9299), "Açuk", new DateTime(2018, 12, 7, 2, 55, 56, 902, DateTimeKind.Local).AddTicks(3998), "Erkekli", "+90-784-661-74-78", 125.40m, 1 });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Address", "BirthDate", "CreatedDate", "FirstName", "HireDate", "PhoneNumber", "Salary", "Shift" },
                values: new object[] { "Tevfik Fikret Caddesi 28c, Konya, İngiltere", new DateTime(1974, 5, 14, 13, 11, 14, 539, DateTimeKind.Local).AddTicks(3315), new DateTime(2025, 3, 13, 7, 18, 55, 388, DateTimeKind.Local).AddTicks(9352), "Bartu", new DateTime(2016, 12, 22, 18, 48, 35, 542, DateTimeKind.Local).AddTicks(1874), "+90-141-161-2-123", 138.99m, 2 });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Address", "BirthDate", "CreatedDate", "FirstName", "HireDate", "LastName", "PhoneNumber", "Salary" },
                values: new object[] { "Bayır Sokak 11a, Sinop, Guyana", new DateTime(1985, 6, 8, 14, 40, 26, 608, DateTimeKind.Local).AddTicks(6571), new DateTime(2025, 3, 13, 7, 18, 55, 388, DateTimeKind.Local).AddTicks(9438), "Anıl", new DateTime(2016, 2, 6, 1, 10, 0, 82, DateTimeKind.Local).AddTicks(6042), "Paksüt", "+90-229-768-4-065", 134.18m });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "Address", "BirthDate", "CreatedDate", "FirstName", "HireDate", "LastName", "PhoneNumber", "Salary", "Shift" },
                values: new object[] { "Sıran Söğüt Sokak 09, Aksaray, İsrail", new DateTime(1990, 9, 19, 15, 35, 46, 118, DateTimeKind.Local).AddTicks(5842), new DateTime(2025, 3, 13, 7, 18, 55, 388, DateTimeKind.Local).AddTicks(9507), "Büre", new DateTime(2021, 12, 30, 10, 31, 46, 726, DateTimeKind.Local).AddTicks(9842), "Uluhan", "+90-636-255-0-348", 138.26m, 2 });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "Address", "BirthDate", "CreatedDate", "FirstName", "HireDate", "LastName", "PhoneNumber", "Salary" },
                values: new object[] { "Sevgi Sokak 0, Kayseri, Danimarka", new DateTime(1997, 3, 28, 1, 23, 22, 101, DateTimeKind.Local).AddTicks(7318), new DateTime(2025, 3, 13, 7, 18, 55, 388, DateTimeKind.Local).AddTicks(9585), "Bayrak", new DateTime(2017, 2, 14, 11, 41, 34, 168, DateTimeKind.Local).AddTicks(8220), "Sarıoğlu", "+90-240-970-6-010", 129.19m });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "Address", "BirthDate", "CreatedDate", "FirstName", "HireDate", "LastName", "PhoneNumber", "Salary", "Shift" },
                values: new object[] { "Okul Sokak 763, Şırnak, Liberya", new DateTime(1995, 8, 26, 19, 18, 58, 368, DateTimeKind.Local).AddTicks(771), new DateTime(2025, 3, 13, 7, 18, 55, 388, DateTimeKind.Local).AddTicks(9634), "Ala", new DateTime(2018, 5, 3, 3, 43, 38, 780, DateTimeKind.Local).AddTicks(7480), "Polat", "+90-258-474-82-57", 127.29m, 2 });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "Address", "BirthDate", "CreatedDate", "FirstName", "HireDate", "LastName", "PhoneNumber", "Salary", "Shift" },
                values: new object[] { "Mevlana Sokak 30, Edirne, Sudan", new DateTime(1986, 4, 15, 6, 56, 24, 592, DateTimeKind.Local).AddTicks(9544), new DateTime(2025, 3, 13, 7, 18, 55, 388, DateTimeKind.Local).AddTicks(9720), "Etil", new DateTime(2023, 9, 27, 12, 32, 4, 818, DateTimeKind.Local).AddTicks(2852), "Topçuoğlu", "+90-480-171-4-576", 111.68m, 2 });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "Address", "BirthDate", "CreatedDate", "FirstName", "HireDate", "LastName", "PhoneNumber", "Salary", "Shift" },
                values: new object[] { "Barış Sokak 77, Iğdır, Uganda", new DateTime(1991, 2, 24, 2, 57, 42, 306, DateTimeKind.Local).AddTicks(1290), new DateTime(2025, 3, 13, 7, 18, 55, 388, DateTimeKind.Local).AddTicks(9789), "Açık", new DateTime(2017, 7, 17, 3, 15, 45, 934, DateTimeKind.Local).AddTicks(481), "Çevik", "+90-371-628-02-38", 114.69m, 2 });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "Address", "BirthDate", "CreatedDate", "FirstName", "HireDate", "LastName", "PhoneNumber", "Salary", "Shift" },
                values: new object[] { "Bahçe Sokak 51b, Şırnak, Saint Pierre ve Miquelon, Fransa", new DateTime(1991, 7, 1, 20, 21, 6, 974, DateTimeKind.Local).AddTicks(1013), new DateTime(2025, 3, 13, 7, 18, 55, 388, DateTimeKind.Local).AddTicks(9840), "Bozan", new DateTime(2020, 8, 3, 13, 38, 36, 536, DateTimeKind.Local).AddTicks(5637), "Taşlı", "+90-251-783-04-40", 131.66m, 1 });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "Address", "BirthDate", "CreatedDate", "FirstName", "HireDate", "LastName", "PhoneNumber", "Salary" },
                values: new object[] { "Alparslan Türkeş Bulvarı 772, Mardin, Somali", new DateTime(1982, 11, 2, 18, 19, 54, 594, DateTimeKind.Local).AddTicks(130), new DateTime(2025, 3, 13, 7, 18, 55, 388, DateTimeKind.Local).AddTicks(9914), "Atlıkağan", new DateTime(2014, 12, 18, 2, 16, 29, 310, DateTimeKind.Local).AddTicks(8047), "Erginsoy", "+90-329-730-5-496", 122.09m });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "Address", "BirthDate", "CreatedDate", "FirstName", "HireDate", "LastName", "PhoneNumber", "Salary", "Shift" },
                values: new object[] { "Tevfik Fikret Caddesi 78c, Ardahan, Ürdün", new DateTime(1972, 2, 28, 6, 24, 27, 902, DateTimeKind.Local).AddTicks(8353), new DateTime(2025, 3, 13, 7, 18, 55, 388, DateTimeKind.Local).AddTicks(9986), "Budak", new DateTime(2021, 7, 15, 3, 34, 17, 998, DateTimeKind.Local).AddTicks(7479), "Topçuoğlu", "+90-630-643-26-72", 112.24m, 2 });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "Address", "BirthDate", "CreatedDate", "FirstName", "HireDate", "LastName", "PhoneNumber", "Salary", "Shift" },
                values: new object[] { "Dağınık Evler Sokak 397, Bartın, Cayman Adaları, İngiltere", new DateTime(2006, 10, 30, 5, 6, 26, 825, DateTimeKind.Local).AddTicks(8325), new DateTime(2025, 3, 13, 7, 18, 55, 389, DateTimeKind.Local).AddTicks(71), "Günçiçek", new DateTime(2016, 9, 29, 23, 40, 24, 257, DateTimeKind.Local).AddTicks(4200), "Sözeri", "+90-280-725-3-103", 165.29m, 1 });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "Address", "BirthDate", "CreatedDate", "FirstName", "HireDate", "LastName", "PhoneNumber", "Salary" },
                values: new object[] { "İbn-i Sina Sokak 51b, Kütahya, Belçika", new DateTime(1985, 3, 6, 17, 52, 50, 165, DateTimeKind.Local).AddTicks(9069), new DateTime(2025, 3, 13, 7, 18, 55, 389, DateTimeKind.Local).AddTicks(121), "Beğkulu", new DateTime(2019, 5, 16, 2, 31, 26, 292, DateTimeKind.Local).AddTicks(5621), "Abacı", "+90-511-488-70-44", 136.34m });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "Address", "BirthDate", "CreatedDate", "FirstName", "HireDate", "LastName", "PhoneNumber", "Salary" },
                values: new object[] { "Güven Yaka Sokak 11c, Kütahya, Nijer", new DateTime(1977, 9, 5, 22, 39, 41, 434, DateTimeKind.Local).AddTicks(8323), new DateTime(2025, 3, 13, 7, 18, 55, 389, DateTimeKind.Local).AddTicks(218), "Karlıgaç", new DateTime(2023, 11, 16, 3, 41, 17, 375, DateTimeKind.Local).AddTicks(4688), "Yetkiner", "+90-611-087-53-96", 142.21m });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "Address", "BirthDate", "CreatedDate", "FirstName", "HireDate", "LastName", "PhoneNumber", "Salary", "Shift" },
                values: new object[] { "Bandak Sokak 69, Isparta, Çin", new DateTime(1993, 3, 6, 8, 30, 11, 530, DateTimeKind.Local).AddTicks(3603), new DateTime(2025, 3, 13, 7, 18, 55, 389, DateTimeKind.Local).AddTicks(280), "Bıçkı", new DateTime(2024, 1, 26, 14, 41, 39, 426, DateTimeKind.Local).AddTicks(1613), "Demirbaş", "+90-448-845-6-806", 135.03m, 2 });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "Address", "BirthDate", "CreatedDate", "FirstName", "HireDate", "LastName", "PhoneNumber", "Salary" },
                values: new object[] { "Okul Sokak 7, Iğdır, Porto Riko, Amerika", new DateTime(1971, 8, 7, 21, 14, 57, 841, DateTimeKind.Local).AddTicks(970), new DateTime(2025, 3, 13, 7, 18, 55, 389, DateTimeKind.Local).AddTicks(357), "Bilgekağan", new DateTime(2023, 12, 16, 1, 42, 48, 159, DateTimeKind.Local).AddTicks(25), "Kunt", "+90-347-171-90-71", 136.66m });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "Address", "BirthDate", "CreatedDate", "FirstName", "HireDate", "LastName", "PhoneNumber", "Salary", "Shift" },
                values: new object[] { "Fatih Sokak  66, Tunceli, Madagaskar", new DateTime(1984, 9, 23, 20, 54, 57, 773, DateTimeKind.Local).AddTicks(3519), new DateTime(2025, 3, 13, 7, 18, 55, 389, DateTimeKind.Local).AddTicks(404), "Eser", new DateTime(2021, 1, 17, 7, 5, 22, 960, DateTimeKind.Local).AddTicks(8661), "Tazegül", "+90-266-064-4-533", 153.45m, 2 });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "Address", "BirthDate", "CreatedDate", "FirstName", "HireDate", "LastName", "PhoneNumber", "Salary", "Shift" },
                values: new object[] { "Güven Yaka Sokak 89c, Niğde, Virgin Adaları, İngiltere", new DateTime(1979, 1, 19, 19, 20, 43, 434, DateTimeKind.Local).AddTicks(7396), new DateTime(2025, 3, 13, 7, 18, 55, 389, DateTimeKind.Local).AddTicks(483), "Azban", new DateTime(2020, 4, 2, 12, 35, 37, 926, DateTimeKind.Local).AddTicks(4003), "Körmükçü", "+90-737-579-09-99", 152.73m, 2 });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "Address", "BirthDate", "CreatedDate", "FirstName", "HireDate", "LastName", "PhoneNumber", "Salary", "Shift" },
                values: new object[] { "Nalbant Sokak 75b, Amasya, Eritre", new DateTime(1998, 3, 20, 12, 55, 40, 479, DateTimeKind.Local).AddTicks(1325), new DateTime(2025, 3, 13, 7, 18, 55, 389, DateTimeKind.Local).AddTicks(552), "Adaldı", new DateTime(2014, 3, 22, 14, 40, 57, 591, DateTimeKind.Local).AddTicks(1042), "Topçuoğlu", "+90-867-476-6-678", 154.32m, 2 });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "Address", "BirthDate", "CreatedDate", "FirstName", "HireDate", "LastName", "PhoneNumber", "Salary" },
                values: new object[] { "Dağınık Evler Sokak 0, Muğla, Aruba, Hollanda", new DateTime(1981, 4, 5, 16, 26, 28, 604, DateTimeKind.Local).AddTicks(372), new DateTime(2025, 3, 13, 7, 18, 55, 389, DateTimeKind.Local).AddTicks(622), "Altınkağan", new DateTime(2016, 5, 12, 8, 3, 13, 796, DateTimeKind.Local).AddTicks(2106), "Uluhan", "+90-957-584-5-898", 163.94m });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "Address", "BirthDate", "CreatedDate", "FirstName", "HireDate", "LastName", "PhoneNumber", "Salary" },
                values: new object[] { "Oğuzhan Sokak 197, Kırıkkale, Cape Verde", new DateTime(1967, 11, 1, 3, 59, 24, 205, DateTimeKind.Local).AddTicks(2633), new DateTime(2025, 3, 13, 7, 18, 55, 389, DateTimeKind.Local).AddTicks(676), "Berk", new DateTime(2024, 2, 7, 12, 29, 6, 594, DateTimeKind.Local).AddTicks(9573), "Öztuna", "+90-254-964-3-003", 168.78m });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "Address", "BirthDate", "CreatedDate", "FirstName", "HireDate", "LastName", "PhoneNumber", "Salary", "Shift" },
                values: new object[] { "Barış Sokak 71, Rize, Ruanda", new DateTime(1971, 12, 10, 8, 8, 5, 581, DateTimeKind.Local).AddTicks(2893), new DateTime(2025, 3, 13, 7, 18, 55, 389, DateTimeKind.Local).AddTicks(746), "Işık", new DateTime(2014, 8, 13, 22, 8, 18, 229, DateTimeKind.Local).AddTicks(6920), "Oraloğlu", "+90-848-717-6-253", 165.31m, 1 });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "Address", "BirthDate", "CreatedDate", "FirstName", "HireDate", "LastName", "PhoneNumber", "Salary", "Shift" },
                values: new object[] { "Afyon Kaya Sokak 20b, Sivas, Guyana", new DateTime(1969, 7, 23, 23, 54, 47, 740, DateTimeKind.Local).AddTicks(561), new DateTime(2025, 3, 13, 7, 18, 55, 389, DateTimeKind.Local).AddTicks(820), "Baysungur", new DateTime(2021, 4, 18, 19, 39, 54, 553, DateTimeKind.Local).AddTicks(6443), "Kulaksızoğlu", "+90-624-465-6-250", 107.66m, 1 });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "Address", "BirthDate", "CreatedDate", "FirstName", "HireDate", "LastName", "PhoneNumber", "Salary" },
                values: new object[] { "Dağınık Evler Sokak 0, Şanlıurfa, Kırgızistan", new DateTime(1997, 4, 11, 14, 34, 44, 290, DateTimeKind.Local).AddTicks(4595), new DateTime(2025, 3, 13, 7, 18, 55, 389, DateTimeKind.Local).AddTicks(896), "Görün", new DateTime(2021, 7, 2, 11, 22, 40, 127, DateTimeKind.Local).AddTicks(8843), "Koçoğlu", "+90-628-286-93-89", 133.78m });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "Address", "BirthDate", "CreatedDate", "FirstName", "HireDate", "LastName", "PhoneNumber", "Salary", "Shift" },
                values: new object[] { "Mevlana Sokak 9, Edirne, Danimarka", new DateTime(1967, 4, 20, 2, 22, 41, 355, DateTimeKind.Local).AddTicks(1385), new DateTime(2025, 3, 13, 7, 18, 55, 389, DateTimeKind.Local).AddTicks(940), "Atıkutlutaş", new DateTime(2014, 8, 8, 7, 19, 19, 527, DateTimeKind.Local).AddTicks(5960), "Kuday", "+90-735-238-3-351", 133.24m, 1 });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "Address", "BirthDate", "CreatedDate", "FirstName", "HireDate", "LastName", "PhoneNumber", "Salary", "Shift" },
                values: new object[] { "İsmet Paşa Caddesi 808, Trabzon, Venezuela", new DateTime(1975, 4, 11, 16, 32, 37, 891, DateTimeKind.Local).AddTicks(9318), new DateTime(2025, 3, 13, 7, 18, 55, 389, DateTimeKind.Local).AddTicks(1005), "Akbaş", new DateTime(2020, 1, 28, 0, 19, 18, 511, DateTimeKind.Local).AddTicks(206), "Ozansoy", "+90-043-225-7-040", 110.17m, 2 });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 34,
                columns: new[] { "Address", "BirthDate", "CreatedDate", "FirstName", "HireDate", "LastName", "PhoneNumber", "Salary", "Shift" },
                values: new object[] { "Ergenekon Sokak   27b, Bilecik, Sırbistan", new DateTime(1972, 2, 4, 4, 1, 45, 393, DateTimeKind.Local).AddTicks(9525), new DateTime(2025, 3, 13, 7, 18, 55, 389, DateTimeKind.Local).AddTicks(1086), "Ayızdağ", new DateTime(2015, 7, 20, 8, 12, 1, 670, DateTimeKind.Local).AddTicks(5830), "Adal", "+90-616-039-70-37", 100.41m, 2 });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 35,
                columns: new[] { "Address", "BirthDate", "CreatedDate", "FirstName", "HireDate", "LastName", "PhoneNumber", "Salary" },
                values: new object[] { "Namık Kemal Caddesi 710, Kütahya, Zambiya", new DateTime(1983, 6, 28, 15, 19, 51, 552, DateTimeKind.Local).AddTicks(9011), new DateTime(2025, 3, 13, 7, 18, 55, 389, DateTimeKind.Local).AddTicks(1163), "Barkdurmuş", new DateTime(2015, 6, 24, 12, 54, 47, 37, DateTimeKind.Local).AddTicks(2035), "Sandalcı", "+90-155-990-3-528", 129.34m });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 36,
                columns: new[] { "Address", "BirthDate", "CreatedDate", "FirstName", "HireDate", "LastName", "PhoneNumber", "Salary" },
                values: new object[] { "Alparslan Türkeş Bulvarı 81c, Karabük, Dominik Cumhuriyeti", new DateTime(1993, 11, 3, 9, 47, 40, 746, DateTimeKind.Local).AddTicks(8649), new DateTime(2025, 3, 13, 7, 18, 55, 389, DateTimeKind.Local).AddTicks(1212), "Bazır", new DateTime(2015, 11, 14, 21, 38, 15, 963, DateTimeKind.Local).AddTicks(8470), "Kavaklıoğlu", "+90-126-981-5-795", 121.12m });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 37,
                columns: new[] { "Address", "BirthDate", "CreatedDate", "FirstName", "HireDate", "LastName", "PhoneNumber", "Salary", "Shift" },
                values: new object[] { "Güven Yaka Sokak 55, Bayburt, Gine-Bissau", new DateTime(1969, 5, 17, 11, 13, 20, 925, DateTimeKind.Local).AddTicks(9606), new DateTime(2025, 3, 13, 7, 18, 55, 389, DateTimeKind.Local).AddTicks(1285), "Babur", new DateTime(2014, 11, 25, 1, 39, 38, 70, DateTimeKind.Local).AddTicks(9038), "Akman", "+90-395-869-3-030", 122.21m, 1 });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 38,
                columns: new[] { "Address", "BirthDate", "CreatedDate", "FirstName", "HireDate", "LastName", "PhoneNumber", "Salary", "Shift" },
                values: new object[] { "Okul Sokak 48, Bursa, Filipinler", new DateTime(1979, 10, 7, 21, 46, 12, 363, DateTimeKind.Local).AddTicks(5066), new DateTime(2025, 3, 13, 7, 18, 55, 389, DateTimeKind.Local).AddTicks(1359), "Arslanargun", new DateTime(2023, 11, 21, 7, 46, 56, 426, DateTimeKind.Local).AddTicks(3248), "Akar ", "+90-116-247-43-63", 110.97m, 2 });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 39,
                columns: new[] { "Address", "BirthDate", "CreatedDate", "FirstName", "HireDate", "LastName", "PhoneNumber", "Salary" },
                values: new object[] { "Ali Çetinkaya Caddesi 83a, Bitlis, Seyşeller", new DateTime(1969, 11, 13, 14, 15, 28, 637, DateTimeKind.Local).AddTicks(2910), new DateTime(2025, 3, 13, 7, 18, 55, 389, DateTimeKind.Local).AddTicks(1407), "Buluş", new DateTime(2021, 7, 25, 20, 4, 3, 337, DateTimeKind.Local).AddTicks(8051), "Öztuna", "+90-079-227-0-556", 106.06m });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 40,
                columns: new[] { "Address", "BirthDate", "CreatedDate", "FirstName", "HireDate", "LastName", "PhoneNumber", "Salary" },
                values: new object[] { "Alparslan Türkeş Bulvarı 60c, Adıyaman, Jamaika", new DateTime(1989, 2, 14, 6, 7, 26, 307, DateTimeKind.Local).AddTicks(4741), new DateTime(2025, 3, 13, 7, 18, 55, 389, DateTimeKind.Local).AddTicks(1478), "Biçek", new DateTime(2018, 4, 27, 2, 50, 13, 469, DateTimeKind.Local).AddTicks(8586), "Barbarosoğlu", "+90-852-909-8-171", 119.03m });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 41,
                columns: new[] { "Address", "BirthDate", "CreatedDate", "FirstName", "HireDate", "LastName", "PhoneNumber", "Salary", "Shift" },
                values: new object[] { "Saygılı Sokak 46, Kırşehir, Kosova", new DateTime(1981, 1, 10, 9, 29, 52, 187, DateTimeKind.Local).AddTicks(6797), new DateTime(2025, 3, 13, 7, 18, 55, 389, DateTimeKind.Local).AddTicks(1554), "Barsbeğ", new DateTime(2014, 4, 22, 8, 8, 32, 259, DateTimeKind.Local).AddTicks(72), "Oraloğlu", "+90-706-576-12-05", 139.74m, 1 });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 42,
                columns: new[] { "Address", "BirthDate", "CreatedDate", "FirstName", "HireDate", "LastName", "PhoneNumber", "Salary" },
                values: new object[] { "Kekeçoğlu Sokak 99a, Sivas, Yemen", new DateTime(2003, 12, 20, 23, 25, 22, 444, DateTimeKind.Local).AddTicks(709), new DateTime(2025, 3, 13, 7, 18, 55, 389, DateTimeKind.Local).AddTicks(1626), "Aladoğan", new DateTime(2018, 10, 8, 11, 2, 35, 907, DateTimeKind.Local).AddTicks(5022), "Karabulut", "+90-633-445-2-806", 131.38m });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 43,
                columns: new[] { "Address", "BirthDate", "CreatedDate", "FirstName", "HireDate", "LastName", "PhoneNumber", "Salary", "Shift" },
                values: new object[] { "Ülkü Sokak 82a, Van, Lübnan", new DateTime(2003, 12, 9, 14, 29, 45, 927, DateTimeKind.Local).AddTicks(6022), new DateTime(2025, 3, 13, 7, 18, 55, 389, DateTimeKind.Local).AddTicks(1676), "Beğtüzün", new DateTime(2021, 6, 2, 5, 54, 13, 733, DateTimeKind.Local).AddTicks(8174), "Özkara", "+90-234-573-56-18", 148.28m, 3 });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 44,
                columns: new[] { "Address", "BirthDate", "CreatedDate", "FirstName", "HireDate", "LastName", "PhoneNumber", "Salary" },
                values: new object[] { "Sevgi Sokak 31b, Kırıkkale, Senegal", new DateTime(1982, 12, 7, 7, 31, 7, 253, DateTimeKind.Local).AddTicks(4304), new DateTime(2025, 3, 13, 7, 18, 55, 389, DateTimeKind.Local).AddTicks(1748), "Altankağan", new DateTime(2021, 11, 13, 13, 0, 26, 117, DateTimeKind.Local).AddTicks(9005), "Poyrazoğlu", "+90-442-863-5-092", 164.72m });

            migrationBuilder.UpdateData(
                table: "ExtraServices",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 13, 7, 18, 55, 464, DateTimeKind.Local).AddTicks(9503));

            migrationBuilder.UpdateData(
                table: "ExtraServices",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 13, 7, 18, 55, 464, DateTimeKind.Local).AddTicks(9505));

            migrationBuilder.UpdateData(
                table: "ExtraServices",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 13, 7, 18, 55, 464, DateTimeKind.Local).AddTicks(9507));

            migrationBuilder.UpdateData(
                table: "ExtraServices",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 13, 7, 18, 55, 464, DateTimeKind.Local).AddTicks(9508));

            migrationBuilder.UpdateData(
                table: "ExtraServices",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 13, 7, 18, 55, 464, DateTimeKind.Local).AddTicks(9509));

            migrationBuilder.UpdateData(
                table: "ExtraServices",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 13, 7, 18, 55, 464, DateTimeKind.Local).AddTicks(9514));

            migrationBuilder.UpdateData(
                table: "ExtraServices",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 13, 7, 18, 55, 464, DateTimeKind.Local).AddTicks(9515));

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 13, 7, 18, 55, 464, DateTimeKind.Local).AddTicks(9466));

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 13, 7, 18, 55, 464, DateTimeKind.Local).AddTicks(9469));

            migrationBuilder.UpdateData(
                table: "RoomTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 13, 7, 18, 55, 386, DateTimeKind.Local).AddTicks(9325));

            migrationBuilder.UpdateData(
                table: "RoomTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 13, 7, 18, 55, 386, DateTimeKind.Local).AddTicks(9337));

            migrationBuilder.UpdateData(
                table: "RoomTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 13, 7, 18, 55, 386, DateTimeKind.Local).AddTicks(9339));

            migrationBuilder.UpdateData(
                table: "RoomTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 13, 7, 18, 55, 386, DateTimeKind.Local).AddTicks(9340));

            migrationBuilder.UpdateData(
                table: "RoomTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 13, 7, 18, 55, 386, DateTimeKind.Local).AddTicks(9341));

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 13, 7, 18, 55, 386, DateTimeKind.Local).AddTicks(9399));

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 13, 7, 18, 55, 386, DateTimeKind.Local).AddTicks(9402));

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 13, 7, 18, 55, 386, DateTimeKind.Local).AddTicks(9403));

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 13, 7, 18, 55, 386, DateTimeKind.Local).AddTicks(9404));

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 13, 7, 18, 55, 386, DateTimeKind.Local).AddTicks(9405));

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 13, 7, 18, 55, 386, DateTimeKind.Local).AddTicks(9406));

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 13, 7, 18, 55, 386, DateTimeKind.Local).AddTicks(9407));

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 13, 7, 18, 55, 386, DateTimeKind.Local).AddTicks(9408));

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 13, 7, 18, 55, 386, DateTimeKind.Local).AddTicks(9409));

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 13, 7, 18, 55, 386, DateTimeKind.Local).AddTicks(9410));

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 13, 7, 18, 55, 386, DateTimeKind.Local).AddTicks(9412));

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 13, 7, 18, 55, 386, DateTimeKind.Local).AddTicks(9413));

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 13, 7, 18, 55, 386, DateTimeKind.Local).AddTicks(9414));

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 13, 7, 18, 55, 386, DateTimeKind.Local).AddTicks(9415));

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 13, 7, 18, 55, 386, DateTimeKind.Local).AddTicks(9415));

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 13, 7, 18, 55, 386, DateTimeKind.Local).AddTicks(9416));

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 13, 7, 18, 55, 386, DateTimeKind.Local).AddTicks(9416));

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 13, 7, 18, 55, 386, DateTimeKind.Local).AddTicks(9418));

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 13, 7, 18, 55, 386, DateTimeKind.Local).AddTicks(9418));

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 13, 7, 18, 55, 386, DateTimeKind.Local).AddTicks(9419));

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 13, 7, 18, 55, 386, DateTimeKind.Local).AddTicks(9421));

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 13, 7, 18, 55, 386, DateTimeKind.Local).AddTicks(9422));

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 13, 7, 18, 55, 386, DateTimeKind.Local).AddTicks(9422));

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 13, 7, 18, 55, 386, DateTimeKind.Local).AddTicks(9423));

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 13, 7, 18, 55, 386, DateTimeKind.Local).AddTicks(9423));

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 13, 7, 18, 55, 386, DateTimeKind.Local).AddTicks(9424));

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 13, 7, 18, 55, 386, DateTimeKind.Local).AddTicks(9424));

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 13, 7, 18, 55, 386, DateTimeKind.Local).AddTicks(9425));

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 13, 7, 18, 55, 386, DateTimeKind.Local).AddTicks(9425));

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 13, 7, 18, 55, 386, DateTimeKind.Local).AddTicks(9454));

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 13, 7, 18, 55, 386, DateTimeKind.Local).AddTicks(9457));

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 13, 7, 18, 55, 386, DateTimeKind.Local).AddTicks(9458));

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 13, 7, 18, 55, 386, DateTimeKind.Local).AddTicks(9459));

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 34,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 13, 7, 18, 55, 386, DateTimeKind.Local).AddTicks(9460));

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 35,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 13, 7, 18, 55, 386, DateTimeKind.Local).AddTicks(9461));

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 36,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 13, 7, 18, 55, 386, DateTimeKind.Local).AddTicks(9462));

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 37,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 13, 7, 18, 55, 386, DateTimeKind.Local).AddTicks(9463));

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 38,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 13, 7, 18, 55, 386, DateTimeKind.Local).AddTicks(9463));

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 39,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 13, 7, 18, 55, 386, DateTimeKind.Local).AddTicks(9464));

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 40,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 13, 7, 18, 55, 386, DateTimeKind.Local).AddTicks(9464));

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 41,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 13, 7, 18, 55, 386, DateTimeKind.Local).AddTicks(9467));

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 42,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 13, 7, 18, 55, 386, DateTimeKind.Local).AddTicks(9468));

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 43,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 13, 7, 18, 55, 386, DateTimeKind.Local).AddTicks(9469));

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 44,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 13, 7, 18, 55, 386, DateTimeKind.Local).AddTicks(9470));

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 45,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 13, 7, 18, 55, 386, DateTimeKind.Local).AddTicks(9470));

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 46,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 13, 7, 18, 55, 386, DateTimeKind.Local).AddTicks(9471));

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 47,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 13, 7, 18, 55, 386, DateTimeKind.Local).AddTicks(9471));

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 48,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 13, 7, 18, 55, 386, DateTimeKind.Local).AddTicks(9472));

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 49,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 13, 7, 18, 55, 386, DateTimeKind.Local).AddTicks(9472));

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 50,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 13, 7, 18, 55, 386, DateTimeKind.Local).AddTicks(9473));

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 51,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 13, 7, 18, 55, 386, DateTimeKind.Local).AddTicks(9475));

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 52,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 13, 7, 18, 55, 386, DateTimeKind.Local).AddTicks(9476));

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 53,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 13, 7, 18, 55, 386, DateTimeKind.Local).AddTicks(9477));

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 54,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 13, 7, 18, 55, 386, DateTimeKind.Local).AddTicks(9477));

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 55,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 13, 7, 18, 55, 386, DateTimeKind.Local).AddTicks(9478));

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 56,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 13, 7, 18, 55, 386, DateTimeKind.Local).AddTicks(9478));

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 57,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 13, 7, 18, 55, 386, DateTimeKind.Local).AddTicks(9479));

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 58,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 13, 7, 18, 55, 386, DateTimeKind.Local).AddTicks(9479));

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 59,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 13, 7, 18, 55, 386, DateTimeKind.Local).AddTicks(9480));

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 60,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 13, 7, 18, 55, 386, DateTimeKind.Local).AddTicks(9480));

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 61,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 13, 7, 18, 55, 386, DateTimeKind.Local).AddTicks(9482));

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 62,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 13, 7, 18, 55, 386, DateTimeKind.Local).AddTicks(9483));

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 63,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 13, 7, 18, 55, 386, DateTimeKind.Local).AddTicks(9484));

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 64,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 13, 7, 18, 55, 386, DateTimeKind.Local).AddTicks(9484));

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 65,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 13, 7, 18, 55, 386, DateTimeKind.Local).AddTicks(9485));

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 66,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 13, 7, 18, 55, 386, DateTimeKind.Local).AddTicks(9486));

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 67,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 13, 7, 18, 55, 386, DateTimeKind.Local).AddTicks(9487));

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 68,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 13, 7, 18, 55, 386, DateTimeKind.Local).AddTicks(9487));

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 69,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 13, 7, 18, 55, 386, DateTimeKind.Local).AddTicks(9488));

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 70,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 13, 7, 18, 55, 386, DateTimeKind.Local).AddTicks(9488));

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 71,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 13, 7, 18, 55, 386, DateTimeKind.Local).AddTicks(9490));

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 72,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 13, 7, 18, 55, 386, DateTimeKind.Local).AddTicks(9491));

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 73,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 13, 7, 18, 55, 386, DateTimeKind.Local).AddTicks(9518));

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 74,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 13, 7, 18, 55, 386, DateTimeKind.Local).AddTicks(9519));

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 75,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 13, 7, 18, 55, 386, DateTimeKind.Local).AddTicks(9520));

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 76,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 13, 7, 18, 55, 386, DateTimeKind.Local).AddTicks(9521));

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 77,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 13, 7, 18, 55, 386, DateTimeKind.Local).AddTicks(9523));

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Employees_EmployeeId",
                table: "Reservations",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Employees_EmployeeId",
                table: "Reservations");

            migrationBuilder.AlterColumn<int>(
                name: "EmployeeId",
                table: "Reservations",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "fefab537-2b6c-4eca-8065-edd761636727");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "e51829d9-ab06-460f-aa27-3157c4bef1b0");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d3ff1b93-06ce-45ff-9c39-6d07b5430bee", new DateTime(2025, 3, 13, 7, 11, 37, 150, DateTimeKind.Local).AddTicks(5420), "AQAAAAIAAYagAAAAEEQWmkv9KgEhgpNU7nY+SWDoHqLtXfNo7oKqOPQPFBAlsFNu4XPHK5FSkdroEY+iaA==", "4c8b2612-1781-4393-9cc6-68242aaff120" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "PasswordHash", "SecurityStamp" },
                values: new object[] { "04406d37-5f57-40d3-a736-c2189d85278b", new DateTime(2025, 3, 13, 7, 11, 37, 192, DateTimeKind.Local).AddTicks(6070), "AQAAAAIAAYagAAAAEKDCkMqjXMojOEKaFlrHb+joIzZ0KPpifybBQ/J0boebdC38tCtnADrTEuk2YZ+6pg==", "77421970-f091-45eb-a908-47d24aaef717" });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Address", "BirthDate", "CreatedDate", "FirstName", "HireDate", "LastName", "PhoneNumber", "Salary" },
                values: new object[] { "İbn-i Sina Sokak 8, Diyarbakır, Kanarya Adaları", new DateTime(1974, 9, 16, 22, 48, 48, 255, DateTimeKind.Local).AddTicks(4474), new DateTime(2025, 3, 13, 7, 11, 37, 108, DateTimeKind.Local).AddTicks(1152), "Başkırt", new DateTime(2020, 12, 29, 11, 42, 0, 82, DateTimeKind.Local).AddTicks(2913), "Özbey", "+90-058-687-9-821", 132.77m });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Address", "BirthDate", "CreatedDate", "FirstName", "HireDate", "LastName", "PhoneNumber", "Salary" },
                values: new object[] { "Bahçe Sokak 109, Gümüşhane, Slovakya", new DateTime(1989, 8, 16, 21, 51, 44, 992, DateTimeKind.Local).AddTicks(5979), new DateTime(2025, 3, 13, 7, 11, 37, 108, DateTimeKind.Local).AddTicks(1289), "Altankan", new DateTime(2015, 7, 8, 12, 32, 44, 755, DateTimeKind.Local).AddTicks(9556), "Bademci", "+90-138-845-2-254", 148.10m });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Address", "BirthDate", "CreatedDate", "FirstName", "HireDate", "LastName", "PhoneNumber", "Salary", "Shift" },
                values: new object[] { "Harman Yolu Sokak  35a, Denizli, Angola", new DateTime(2006, 11, 11, 15, 18, 16, 63, DateTimeKind.Local).AddTicks(4624), new DateTime(2025, 3, 13, 7, 11, 37, 108, DateTimeKind.Local).AddTicks(1391), "Kıvanç", new DateTime(2014, 10, 16, 1, 21, 37, 92, DateTimeKind.Local).AddTicks(9919), "Akman", "+90-234-502-40-78", 127.75m, 2 });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Address", "BirthDate", "CreatedDate", "FirstName", "HireDate", "LastName", "PhoneNumber", "Salary" },
                values: new object[] { "Ülkü Sokak 072, Kastamonu, İsviçre", new DateTime(1986, 12, 26, 14, 34, 46, 886, DateTimeKind.Local).AddTicks(2183), new DateTime(2025, 3, 13, 7, 11, 37, 108, DateTimeKind.Local).AddTicks(1497), "Bilgin", new DateTime(2019, 7, 11, 9, 28, 6, 396, DateTimeKind.Local).AddTicks(7726), "Gürmen", "+90-037-331-2-389", 125.00m });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Address", "BirthDate", "CreatedDate", "FirstName", "HireDate", "LastName", "PhoneNumber", "Salary" },
                values: new object[] { "Köypınar Sokak 87b, Çorum, Estonya", new DateTime(1973, 3, 12, 13, 10, 39, 543, DateTimeKind.Local).AddTicks(3906), new DateTime(2025, 3, 13, 7, 11, 37, 108, DateTimeKind.Local).AddTicks(1561), "Büktegin", new DateTime(2019, 12, 29, 1, 45, 19, 8, DateTimeKind.Local).AddTicks(2210), "Pektemek", "+90-665-797-6-216", 141.64m });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Address", "BirthDate", "CreatedDate", "FirstName", "HireDate", "LastName", "PhoneNumber", "Salary" },
                values: new object[] { "Köypınar Sokak 89c, Giresun, Aruba, Hollanda", new DateTime(1974, 8, 8, 12, 37, 55, 152, DateTimeKind.Local).AddTicks(4370), new DateTime(2025, 3, 13, 7, 11, 37, 108, DateTimeKind.Local).AddTicks(1657), "Bağtaş", new DateTime(2023, 12, 2, 22, 59, 7, 983, DateTimeKind.Local).AddTicks(3288), "Özbir", "+90-479-945-0-498", 124.65m });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Address", "BirthDate", "CreatedDate", "FirstName", "HireDate", "LastName", "PhoneNumber", "Salary", "Shift" },
                values: new object[] { "Sağlık Sokak 80, Niğde, Marşal Adaları", new DateTime(2005, 9, 11, 22, 48, 29, 809, DateTimeKind.Local).AddTicks(876), new DateTime(2025, 3, 13, 7, 11, 37, 108, DateTimeKind.Local).AddTicks(1751), "Artuk", new DateTime(2016, 11, 12, 1, 49, 16, 985, DateTimeKind.Local).AddTicks(3087), "Tokatlıoğlu", "+90-434-053-4-270", 159.40m, 2 });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Address", "BirthDate", "CreatedDate", "FirstName", "HireDate", "LastName", "PhoneNumber", "Salary", "Shift" },
                values: new object[] { "Köypınar Sokak 3, Van, Togo", new DateTime(1973, 9, 9, 15, 23, 51, 689, DateTimeKind.Local).AddTicks(7834), new DateTime(2025, 3, 13, 7, 11, 37, 108, DateTimeKind.Local).AddTicks(1848), "Ebkızı", new DateTime(2023, 12, 18, 5, 25, 46, 947, DateTimeKind.Local).AddTicks(6783), "Kasapoğlu", "+90-382-120-75-61", 133.45m, 2 });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Address", "BirthDate", "CreatedDate", "FirstName", "HireDate", "PhoneNumber", "Salary", "Shift" },
                values: new object[] { "Menekşe Sokak 64a, Balıkesir, Avustralya", new DateTime(1975, 1, 23, 0, 28, 5, 232, DateTimeKind.Local).AddTicks(8154), new DateTime(2025, 3, 13, 7, 11, 37, 108, DateTimeKind.Local).AddTicks(1911), "Aykağan", new DateTime(2023, 2, 3, 21, 1, 24, 757, DateTimeKind.Local).AddTicks(8834), "+90-079-639-5-041", 113.95m, 1 });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Address", "BirthDate", "CreatedDate", "FirstName", "HireDate", "LastName", "PhoneNumber", "Salary" },
                values: new object[] { "Ülkü Sokak 49c, Kayseri, Mauritius", new DateTime(1986, 1, 23, 9, 14, 25, 143, DateTimeKind.Local).AddTicks(951), new DateTime(2025, 3, 13, 7, 11, 37, 108, DateTimeKind.Local).AddTicks(1991), "Kımızın", new DateTime(2018, 9, 27, 7, 18, 13, 515, DateTimeKind.Local).AddTicks(4203), "Erberk", "+90-190-677-4-240", 117.13m });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "Address", "BirthDate", "CreatedDate", "FirstName", "HireDate", "LastName", "PhoneNumber", "Salary", "Shift" },
                values: new object[] { "Lütfi Karadirek Caddesi 05a, Tunceli, Danimarka", new DateTime(1987, 4, 10, 5, 59, 12, 473, DateTimeKind.Local).AddTicks(674), new DateTime(2025, 3, 13, 7, 11, 37, 108, DateTimeKind.Local).AddTicks(2088), "Bağaşatulu", new DateTime(2023, 2, 13, 21, 34, 56, 580, DateTimeKind.Local).AddTicks(5546), "Beşerler", "+90-723-826-42-18", 131.12m, 1 });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "Address", "BirthDate", "CreatedDate", "FirstName", "HireDate", "LastName", "PhoneNumber", "Salary" },
                values: new object[] { "Kocatepe Caddesi 76b, Hatay, İzlanda", new DateTime(1977, 10, 25, 11, 5, 0, 756, DateTimeKind.Local).AddTicks(1249), new DateTime(2025, 3, 13, 7, 11, 37, 108, DateTimeKind.Local).AddTicks(2188), "Arınç", new DateTime(2017, 11, 12, 15, 33, 22, 55, DateTimeKind.Local).AddTicks(1167), "Yeşilkaya", "+90-253-618-8-878", 122.25m });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "Address", "BirthDate", "CreatedDate", "FirstName", "HireDate", "LastName", "PhoneNumber", "Salary", "Shift" },
                values: new object[] { "Kaldırım Sokak 63, Ankara, Reunion, Fransa", new DateTime(1985, 9, 27, 23, 51, 23, 916, DateTimeKind.Local).AddTicks(995), new DateTime(2025, 3, 13, 7, 11, 37, 108, DateTimeKind.Local).AddTicks(2252), "Ağabay", new DateTime(2022, 1, 21, 22, 4, 54, 833, DateTimeKind.Local).AddTicks(5247), "Pekkan", "+90-895-654-95-76", 116.77m, 1 });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "Address", "BirthDate", "CreatedDate", "FirstName", "HireDate", "LastName", "PhoneNumber", "Salary", "Shift" },
                values: new object[] { "Sevgi Sokak 71b, Nevşehir, Montserrat", new DateTime(1969, 5, 16, 19, 58, 1, 794, DateTimeKind.Local).AddTicks(1788), new DateTime(2025, 3, 13, 7, 11, 37, 108, DateTimeKind.Local).AddTicks(2341), "Bağa", new DateTime(2020, 8, 12, 1, 26, 51, 164, DateTimeKind.Local).AddTicks(9340), "Dalkıran", "+90-784-135-57-12", 127.37m, 1 });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "Address", "BirthDate", "CreatedDate", "FirstName", "HireDate", "LastName", "PhoneNumber", "Salary", "Shift" },
                values: new object[] { "Ülkü Sokak 3, Denizli, Hindistan", new DateTime(1973, 11, 18, 16, 5, 45, 909, DateTimeKind.Local).AddTicks(7030), new DateTime(2025, 3, 13, 7, 11, 37, 108, DateTimeKind.Local).AddTicks(2425), "Baysungur", new DateTime(2017, 7, 4, 15, 46, 47, 86, DateTimeKind.Local).AddTicks(4701), "Beşerler", "+90-733-470-10-28", 115.15m, 1 });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "Address", "BirthDate", "CreatedDate", "FirstName", "HireDate", "LastName", "PhoneNumber", "Salary", "Shift" },
                values: new object[] { "Kocatepe Caddesi 3, İzmir, Saint Helena, İngiltere", new DateTime(1998, 6, 24, 10, 28, 37, 104, DateTimeKind.Local).AddTicks(8962), new DateTime(2025, 3, 13, 7, 11, 37, 108, DateTimeKind.Local).AddTicks(2483), "Burulgu", new DateTime(2019, 5, 16, 12, 26, 29, 577, DateTimeKind.Local).AddTicks(2997), "Arslanoğlu", "+90-020-614-1-909", 129.04m, 2 });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "Address", "BirthDate", "CreatedDate", "FirstName", "HireDate", "LastName", "PhoneNumber", "Salary" },
                values: new object[] { "Barış Sokak 29c, Karabük, Venezuela", new DateTime(1971, 6, 7, 19, 17, 35, 947, DateTimeKind.Local).AddTicks(3463), new DateTime(2025, 3, 13, 7, 11, 37, 108, DateTimeKind.Local).AddTicks(2568), "Gözde", new DateTime(2014, 4, 11, 15, 0, 24, 331, DateTimeKind.Local).AddTicks(9459), "Sandalcı", "+90-994-572-8-190", 119.12m });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "Address", "BirthDate", "CreatedDate", "FirstName", "HireDate", "LastName", "PhoneNumber", "Salary", "Shift" },
                values: new object[] { "Alparslan Türkeş Bulvarı 81c, Malatya, Solomon Adaları", new DateTime(2000, 7, 4, 15, 17, 40, 291, DateTimeKind.Local).AddTicks(746), new DateTime(2025, 3, 13, 7, 11, 37, 108, DateTimeKind.Local).AddTicks(2654), "Ağabay", new DateTime(2019, 7, 10, 0, 58, 18, 830, DateTimeKind.Local).AddTicks(8271), "Karaduman", "+90-438-938-44-12", 132.94m, 1 });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "Address", "BirthDate", "CreatedDate", "FirstName", "HireDate", "LastName", "PhoneNumber", "Salary", "Shift" },
                values: new object[] { "Sıran Söğüt Sokak 04c, Siirt, Umman", new DateTime(1990, 1, 9, 20, 7, 34, 43, DateTimeKind.Local).AddTicks(315), new DateTime(2025, 3, 13, 7, 11, 37, 108, DateTimeKind.Local).AddTicks(2741), "Bulmaz", new DateTime(2014, 9, 26, 2, 8, 29, 171, DateTimeKind.Local).AddTicks(9320), "Solmaz", "+90-458-077-3-664", 130.22m, 2 });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "Address", "BirthDate", "CreatedDate", "FirstName", "HireDate", "LastName", "PhoneNumber", "Salary" },
                values: new object[] { "İsmet Paşa Caddesi 308, Amasya, Haiti", new DateTime(1992, 7, 4, 14, 32, 57, 608, DateTimeKind.Local).AddTicks(6603), new DateTime(2025, 3, 13, 7, 11, 37, 108, DateTimeKind.Local).AddTicks(2798), "Bıdın", new DateTime(2022, 2, 17, 23, 18, 4, 405, DateTimeKind.Local).AddTicks(5432), "Alyanak", "+90-986-242-61-77", 169.84m });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "Address", "BirthDate", "CreatedDate", "FirstName", "HireDate", "LastName", "PhoneNumber", "Salary" },
                values: new object[] { "Atatürk Bulvarı 42, Şanlıurfa, Yeni Kaledonya, Fransa", new DateTime(1998, 4, 4, 19, 12, 31, 894, DateTimeKind.Local).AddTicks(8087), new DateTime(2025, 3, 13, 7, 11, 37, 108, DateTimeKind.Local).AddTicks(2873), "Azıl", new DateTime(2021, 1, 4, 18, 22, 30, 503, DateTimeKind.Local).AddTicks(7825), "Ozansoy", "+90-728-048-1-179", 131.31m });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "Address", "BirthDate", "CreatedDate", "FirstName", "HireDate", "LastName", "PhoneNumber", "Salary", "Shift" },
                values: new object[] { "Sevgi Sokak 7, Çanakkale, Azerbaycan", new DateTime(1997, 5, 16, 11, 38, 55, 711, DateTimeKind.Local).AddTicks(9634), new DateTime(2025, 3, 13, 7, 11, 37, 108, DateTimeKind.Local).AddTicks(2965), "Buluç", new DateTime(2019, 2, 15, 4, 50, 33, 302, DateTimeKind.Local).AddTicks(1857), "Velioğlu", "+90-549-018-7-875", 158.63m, 1 });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "Address", "BirthDate", "CreatedDate", "FirstName", "HireDate", "LastName", "PhoneNumber", "Salary" },
                values: new object[] { "Oğuzhan Sokak 56, Samsun, Irak", new DateTime(1989, 11, 11, 2, 53, 21, 427, DateTimeKind.Local).AddTicks(2306), new DateTime(2025, 3, 13, 7, 11, 37, 108, DateTimeKind.Local).AddTicks(3059), "Erinç", new DateTime(2015, 12, 21, 14, 0, 37, 41, DateTimeKind.Local).AddTicks(1088), "Uluhan", "+90-558-055-07-90", 141.39m });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "Address", "BirthDate", "CreatedDate", "FirstName", "HireDate", "LastName", "PhoneNumber", "Salary", "Shift" },
                values: new object[] { "Sağlık Sokak 96a, Antalya, Yeni Zelanda", new DateTime(1996, 5, 21, 9, 42, 34, 939, DateTimeKind.Local).AddTicks(7186), new DateTime(2025, 3, 13, 7, 11, 37, 108, DateTimeKind.Local).AddTicks(3113), "Argıl", new DateTime(2022, 4, 17, 8, 2, 32, 512, DateTimeKind.Local).AddTicks(2224), "Barbarosoğlu", "+90-908-022-83-99", 130.71m, 1 });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "Address", "BirthDate", "CreatedDate", "FirstName", "HireDate", "LastName", "PhoneNumber", "Salary", "Shift" },
                values: new object[] { "Okul Sokak 95b, Karabük, Tunus", new DateTime(1969, 2, 28, 3, 40, 45, 424, DateTimeKind.Local).AddTicks(1748), new DateTime(2025, 3, 13, 7, 11, 37, 108, DateTimeKind.Local).AddTicks(3197), "Kırlangıç", new DateTime(2018, 7, 26, 19, 21, 42, 163, DateTimeKind.Local).AddTicks(2937), "Çörekçi", "+90-083-477-50-04", 136.14m, 1 });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "Address", "BirthDate", "CreatedDate", "FirstName", "HireDate", "LastName", "PhoneNumber", "Salary", "Shift" },
                values: new object[] { "Sevgi Sokak 17b, Antalya, Katar", new DateTime(1977, 6, 21, 2, 51, 32, 782, DateTimeKind.Local).AddTicks(3402), new DateTime(2025, 3, 13, 7, 11, 37, 108, DateTimeKind.Local).AddTicks(3277), "Barkdoğdu", new DateTime(2020, 1, 25, 10, 31, 27, 160, DateTimeKind.Local).AddTicks(9841), "Kahveci", "+90-692-984-5-958", 162.97m, 1 });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "Address", "BirthDate", "CreatedDate", "FirstName", "HireDate", "LastName", "PhoneNumber", "Salary" },
                values: new object[] { "Gül Sokak 97, İstanbul, Guyana", new DateTime(2002, 3, 16, 2, 39, 29, 703, DateTimeKind.Local).AddTicks(363), new DateTime(2025, 3, 13, 7, 11, 37, 108, DateTimeKind.Local).AddTicks(3334), "Bergü", new DateTime(2023, 11, 19, 3, 36, 24, 600, DateTimeKind.Local).AddTicks(3367), "Tütüncü", "+90-578-326-7-067", 135.01m });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "Address", "BirthDate", "CreatedDate", "FirstName", "HireDate", "LastName", "PhoneNumber", "Salary" },
                values: new object[] { "Alparslan Türkeş Bulvarı 95b, Mardin, Çin", new DateTime(1997, 2, 24, 10, 27, 46, 435, DateTimeKind.Local).AddTicks(8868), new DateTime(2025, 3, 13, 7, 11, 37, 108, DateTimeKind.Local).AddTicks(3440), "Basut", new DateTime(2015, 4, 4, 10, 13, 58, 779, DateTimeKind.Local).AddTicks(1788), "Eronat", "+90-776-817-2-480", 162.50m });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "Address", "BirthDate", "CreatedDate", "FirstName", "HireDate", "LastName", "PhoneNumber", "Salary", "Shift" },
                values: new object[] { "Köypınar Sokak 08, Erzincan, Malavi", new DateTime(1999, 1, 3, 11, 45, 29, 889, DateTimeKind.Local).AddTicks(3514), new DateTime(2025, 3, 13, 7, 11, 37, 108, DateTimeKind.Local).AddTicks(3513), "Barak", new DateTime(2018, 12, 2, 21, 17, 26, 799, DateTimeKind.Local).AddTicks(4544), "Evliyaoğlu", "+90-712-170-31-02", 169.88m, 2 });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "Address", "BirthDate", "CreatedDate", "FirstName", "HireDate", "LastName", "PhoneNumber", "Salary", "Shift" },
                values: new object[] { "Barış Sokak 506, Sinop, Panama", new DateTime(1976, 9, 13, 18, 55, 11, 899, DateTimeKind.Local).AddTicks(4955), new DateTime(2025, 3, 13, 7, 11, 37, 108, DateTimeKind.Local).AddTicks(3602), "Çağatay", new DateTime(2015, 11, 17, 10, 15, 7, 190, DateTimeKind.Local).AddTicks(1841), "Topçuoğlu", "+90-485-248-91-46", 118.43m, 2 });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "Address", "BirthDate", "CreatedDate", "FirstName", "HireDate", "LastName", "PhoneNumber", "Salary" },
                values: new object[] { "Oğuzhan Sokak 20, Zonguldak, Fiji", new DateTime(1982, 9, 11, 11, 31, 22, 445, DateTimeKind.Local).AddTicks(4451), new DateTime(2025, 3, 13, 7, 11, 37, 108, DateTimeKind.Local).AddTicks(3654), "Altankağan", new DateTime(2015, 10, 16, 1, 40, 24, 122, DateTimeKind.Local).AddTicks(5913), "Erkekli", "+90-999-682-0-380", 103.53m });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "Address", "BirthDate", "CreatedDate", "FirstName", "HireDate", "LastName", "PhoneNumber", "Salary", "Shift" },
                values: new object[] { "Ülkü Sokak 812, Adıyaman, Azerbaycan", new DateTime(1985, 7, 5, 0, 39, 44, 300, DateTimeKind.Local).AddTicks(8005), new DateTime(2025, 3, 13, 7, 11, 37, 108, DateTimeKind.Local).AddTicks(3755), "Bora", new DateTime(2022, 7, 3, 4, 32, 52, 983, DateTimeKind.Local).AddTicks(7406), "Durak ", "+90-668-288-23-02", 123.18m, 2 });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "Address", "BirthDate", "CreatedDate", "FirstName", "HireDate", "LastName", "PhoneNumber", "Salary", "Shift" },
                values: new object[] { "Saygılı Sokak 36a, Trabzon, Angola", new DateTime(1971, 5, 29, 3, 25, 46, 70, DateTimeKind.Local).AddTicks(2862), new DateTime(2025, 3, 13, 7, 11, 37, 108, DateTimeKind.Local).AddTicks(3837), "Aşuk", new DateTime(2015, 5, 16, 13, 24, 36, 977, DateTimeKind.Local).AddTicks(8399), "Akay", "+90-548-511-2-984", 105.14m, 1 });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 34,
                columns: new[] { "Address", "BirthDate", "CreatedDate", "FirstName", "HireDate", "LastName", "PhoneNumber", "Salary", "Shift" },
                values: new object[] { "Atatürk Bulvarı 11b, Hatay, Tunus", new DateTime(1972, 3, 2, 21, 28, 20, 722, DateTimeKind.Local).AddTicks(6071), new DateTime(2025, 3, 13, 7, 11, 37, 108, DateTimeKind.Local).AddTicks(3922), "İrinçköl", new DateTime(2023, 4, 23, 3, 0, 3, 134, DateTimeKind.Local).AddTicks(1920), "Alpuğan", "+90-647-694-5-048", 121.41m, 1 });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 35,
                columns: new[] { "Address", "BirthDate", "CreatedDate", "FirstName", "HireDate", "LastName", "PhoneNumber", "Salary" },
                values: new object[] { "Kaldırım Sokak 39b, Malatya, Makau (Makao)", new DateTime(1970, 11, 23, 18, 55, 19, 279, DateTimeKind.Local).AddTicks(6213), new DateTime(2025, 3, 13, 7, 11, 37, 108, DateTimeKind.Local).AddTicks(3976), "Ant", new DateTime(2021, 7, 28, 7, 30, 21, 806, DateTimeKind.Local).AddTicks(8404), "Özgörkey", "+90-327-422-24-30", 107.18m });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 36,
                columns: new[] { "Address", "BirthDate", "CreatedDate", "FirstName", "HireDate", "LastName", "PhoneNumber", "Salary" },
                values: new object[] { "Kocatepe Caddesi 4, Yalova, Libya", new DateTime(1992, 9, 2, 7, 43, 47, 52, DateTimeKind.Local).AddTicks(3519), new DateTime(2025, 3, 13, 7, 11, 37, 108, DateTimeKind.Local).AddTicks(4066), "Bükdüz", new DateTime(2023, 6, 23, 16, 56, 47, 880, DateTimeKind.Local).AddTicks(2899), "Akgül", "+90-189-542-5-615", 105.47m });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 37,
                columns: new[] { "Address", "BirthDate", "CreatedDate", "FirstName", "HireDate", "LastName", "PhoneNumber", "Salary", "Shift" },
                values: new object[] { "Köypınar Sokak 3, Kütahya, Zambiya", new DateTime(1994, 9, 28, 12, 55, 25, 203, DateTimeKind.Local).AddTicks(1901), new DateTime(2025, 3, 13, 7, 11, 37, 108, DateTimeKind.Local).AddTicks(4154), "Çabdar", new DateTime(2015, 6, 24, 11, 52, 48, 450, DateTimeKind.Local).AddTicks(4354), "Çevik", "+90-883-696-35-22", 120.96m, 2 });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 38,
                columns: new[] { "Address", "BirthDate", "CreatedDate", "FirstName", "HireDate", "LastName", "PhoneNumber", "Salary", "Shift" },
                values: new object[] { "Namık Kemal Caddesi 11c, Yalova, Venezuela", new DateTime(2000, 3, 18, 8, 42, 36, 189, DateTimeKind.Local).AddTicks(3282), new DateTime(2025, 3, 13, 7, 11, 37, 108, DateTimeKind.Local).AddTicks(4241), "Beğdemir", new DateTime(2017, 8, 29, 17, 15, 3, 637, DateTimeKind.Local).AddTicks(2207), "Ayverdi", "+90-536-705-0-532", 100.18m, 1 });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 39,
                columns: new[] { "Address", "BirthDate", "CreatedDate", "FirstName", "HireDate", "LastName", "PhoneNumber", "Salary" },
                values: new object[] { "Saygılı Sokak 0, Kütahya, Grönland", new DateTime(1986, 10, 20, 5, 32, 40, 572, DateTimeKind.Local).AddTicks(99), new DateTime(2025, 3, 13, 7, 11, 37, 108, DateTimeKind.Local).AddTicks(4294), "Budunlu", new DateTime(2022, 5, 2, 12, 33, 48, 150, DateTimeKind.Local).AddTicks(3799), "Uca", "+90-086-348-94-85", 132.09m });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 40,
                columns: new[] { "Address", "BirthDate", "CreatedDate", "FirstName", "HireDate", "LastName", "PhoneNumber", "Salary" },
                values: new object[] { "Yunus Emre Sokak 09, Afyon, Bulgaristan", new DateTime(1994, 9, 29, 12, 43, 10, 571, DateTimeKind.Local).AddTicks(4932), new DateTime(2025, 3, 13, 7, 11, 37, 108, DateTimeKind.Local).AddTicks(4370), "Bıçkıcı", new DateTime(2018, 2, 7, 19, 29, 6, 471, DateTimeKind.Local).AddTicks(1940), "Ağaoğlu", "+90-495-270-03-67", 118.05m });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 41,
                columns: new[] { "Address", "BirthDate", "CreatedDate", "FirstName", "HireDate", "LastName", "PhoneNumber", "Salary", "Shift" },
                values: new object[] { "Ali Çetinkaya Caddesi 14b, İstanbul, Surinam", new DateTime(1990, 12, 21, 9, 7, 37, 713, DateTimeKind.Local).AddTicks(9177), new DateTime(2025, 3, 13, 7, 11, 37, 108, DateTimeKind.Local).AddTicks(4460), "Kımızalmıla", new DateTime(2022, 8, 29, 5, 33, 59, 674, DateTimeKind.Local).AddTicks(385), "Poyrazoğlu", "+90-246-130-53-56", 122.84m, 2 });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 42,
                columns: new[] { "Address", "BirthDate", "CreatedDate", "FirstName", "HireDate", "LastName", "PhoneNumber", "Salary" },
                values: new object[] { "Nalbant Sokak 85a, İçel (Mersin), Fransız Polinezyası", new DateTime(1995, 3, 4, 15, 41, 11, 905, DateTimeKind.Local).AddTicks(9728), new DateTime(2025, 3, 13, 7, 11, 37, 108, DateTimeKind.Local).AddTicks(4557), "Başbuğ", new DateTime(2019, 4, 16, 14, 45, 19, 304, DateTimeKind.Local).AddTicks(957), "Sadıklar", "+90-484-941-88-06", 139.70m });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 43,
                columns: new[] { "Address", "BirthDate", "CreatedDate", "FirstName", "HireDate", "LastName", "PhoneNumber", "Salary", "Shift" },
                values: new object[] { "Bayır Sokak 68, Muğla, Fas", new DateTime(1996, 9, 23, 11, 57, 1, 949, DateTimeKind.Local).AddTicks(1588), new DateTime(2025, 3, 13, 7, 11, 37, 108, DateTimeKind.Local).AddTicks(4615), "İrtiş", new DateTime(2020, 4, 7, 16, 42, 18, 610, DateTimeKind.Local).AddTicks(6547), "Aykaç", "+90-227-550-0-063", 175.54m, 1 });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 44,
                columns: new[] { "Address", "BirthDate", "CreatedDate", "FirstName", "HireDate", "LastName", "PhoneNumber", "Salary" },
                values: new object[] { "Dağınık Evler Sokak 263, Burdur, Kırgızistan", new DateTime(1975, 8, 4, 0, 5, 52, 171, DateTimeKind.Local).AddTicks(7969), new DateTime(2025, 3, 13, 7, 11, 37, 108, DateTimeKind.Local).AddTicks(4704), "Avar", new DateTime(2018, 7, 5, 5, 18, 24, 221, DateTimeKind.Local).AddTicks(1240), "Gümüşpala", "+90-027-832-44-06", 157.63m });

            migrationBuilder.UpdateData(
                table: "ExtraServices",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 13, 7, 11, 37, 192, DateTimeKind.Local).AddTicks(6602));

            migrationBuilder.UpdateData(
                table: "ExtraServices",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 13, 7, 11, 37, 192, DateTimeKind.Local).AddTicks(6605));

            migrationBuilder.UpdateData(
                table: "ExtraServices",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 13, 7, 11, 37, 192, DateTimeKind.Local).AddTicks(6606));

            migrationBuilder.UpdateData(
                table: "ExtraServices",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 13, 7, 11, 37, 192, DateTimeKind.Local).AddTicks(6608));

            migrationBuilder.UpdateData(
                table: "ExtraServices",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 13, 7, 11, 37, 192, DateTimeKind.Local).AddTicks(6609));

            migrationBuilder.UpdateData(
                table: "ExtraServices",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 13, 7, 11, 37, 192, DateTimeKind.Local).AddTicks(6622));

            migrationBuilder.UpdateData(
                table: "ExtraServices",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 13, 7, 11, 37, 192, DateTimeKind.Local).AddTicks(6623));

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 13, 7, 11, 37, 192, DateTimeKind.Local).AddTicks(6550));

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 13, 7, 11, 37, 192, DateTimeKind.Local).AddTicks(6554));

            migrationBuilder.UpdateData(
                table: "RoomTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 13, 7, 11, 37, 106, DateTimeKind.Local).AddTicks(2969));

            migrationBuilder.UpdateData(
                table: "RoomTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 13, 7, 11, 37, 106, DateTimeKind.Local).AddTicks(2981));

            migrationBuilder.UpdateData(
                table: "RoomTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 13, 7, 11, 37, 106, DateTimeKind.Local).AddTicks(2983));

            migrationBuilder.UpdateData(
                table: "RoomTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 13, 7, 11, 37, 106, DateTimeKind.Local).AddTicks(2984));

            migrationBuilder.UpdateData(
                table: "RoomTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 13, 7, 11, 37, 106, DateTimeKind.Local).AddTicks(2986));

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 13, 7, 11, 37, 106, DateTimeKind.Local).AddTicks(3050));

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 13, 7, 11, 37, 106, DateTimeKind.Local).AddTicks(3053));

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 13, 7, 11, 37, 106, DateTimeKind.Local).AddTicks(3054));

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 13, 7, 11, 37, 106, DateTimeKind.Local).AddTicks(3055));

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 13, 7, 11, 37, 106, DateTimeKind.Local).AddTicks(3056));

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 13, 7, 11, 37, 106, DateTimeKind.Local).AddTicks(3057));

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 13, 7, 11, 37, 106, DateTimeKind.Local).AddTicks(3059));

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 13, 7, 11, 37, 106, DateTimeKind.Local).AddTicks(3060));

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 13, 7, 11, 37, 106, DateTimeKind.Local).AddTicks(3060));

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 13, 7, 11, 37, 106, DateTimeKind.Local).AddTicks(3062));

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 13, 7, 11, 37, 106, DateTimeKind.Local).AddTicks(3065));

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 13, 7, 11, 37, 106, DateTimeKind.Local).AddTicks(3066));

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 13, 7, 11, 37, 106, DateTimeKind.Local).AddTicks(3066));

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 13, 7, 11, 37, 106, DateTimeKind.Local).AddTicks(3067));

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 13, 7, 11, 37, 106, DateTimeKind.Local).AddTicks(3068));

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 13, 7, 11, 37, 106, DateTimeKind.Local).AddTicks(3068));

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 13, 7, 11, 37, 106, DateTimeKind.Local).AddTicks(3069));

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 13, 7, 11, 37, 106, DateTimeKind.Local).AddTicks(3071));

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 13, 7, 11, 37, 106, DateTimeKind.Local).AddTicks(3071));

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 13, 7, 11, 37, 106, DateTimeKind.Local).AddTicks(3072));

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 13, 7, 11, 37, 106, DateTimeKind.Local).AddTicks(3074));

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 13, 7, 11, 37, 106, DateTimeKind.Local).AddTicks(3075));

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 13, 7, 11, 37, 106, DateTimeKind.Local).AddTicks(3076));

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 13, 7, 11, 37, 106, DateTimeKind.Local).AddTicks(3076));

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 13, 7, 11, 37, 106, DateTimeKind.Local).AddTicks(3077));

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 13, 7, 11, 37, 106, DateTimeKind.Local).AddTicks(3077));

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 13, 7, 11, 37, 106, DateTimeKind.Local).AddTicks(3078));

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 13, 7, 11, 37, 106, DateTimeKind.Local).AddTicks(3079));

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 13, 7, 11, 37, 106, DateTimeKind.Local).AddTicks(3079));

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 13, 7, 11, 37, 106, DateTimeKind.Local).AddTicks(3080));

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 13, 7, 11, 37, 106, DateTimeKind.Local).AddTicks(3082));

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 13, 7, 11, 37, 106, DateTimeKind.Local).AddTicks(3083));

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 13, 7, 11, 37, 106, DateTimeKind.Local).AddTicks(3084));

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 34,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 13, 7, 11, 37, 106, DateTimeKind.Local).AddTicks(3120));

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 35,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 13, 7, 11, 37, 106, DateTimeKind.Local).AddTicks(3121));

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 36,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 13, 7, 11, 37, 106, DateTimeKind.Local).AddTicks(3122));

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 37,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 13, 7, 11, 37, 106, DateTimeKind.Local).AddTicks(3123));

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 38,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 13, 7, 11, 37, 106, DateTimeKind.Local).AddTicks(3124));

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 39,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 13, 7, 11, 37, 106, DateTimeKind.Local).AddTicks(3124));

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 40,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 13, 7, 11, 37, 106, DateTimeKind.Local).AddTicks(3125));

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 41,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 13, 7, 11, 37, 106, DateTimeKind.Local).AddTicks(3129));

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 42,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 13, 7, 11, 37, 106, DateTimeKind.Local).AddTicks(3130));

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 43,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 13, 7, 11, 37, 106, DateTimeKind.Local).AddTicks(3131));

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 44,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 13, 7, 11, 37, 106, DateTimeKind.Local).AddTicks(3131));

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 45,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 13, 7, 11, 37, 106, DateTimeKind.Local).AddTicks(3132));

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 46,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 13, 7, 11, 37, 106, DateTimeKind.Local).AddTicks(3133));

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 47,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 13, 7, 11, 37, 106, DateTimeKind.Local).AddTicks(3133));

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 48,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 13, 7, 11, 37, 106, DateTimeKind.Local).AddTicks(3134));

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 49,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 13, 7, 11, 37, 106, DateTimeKind.Local).AddTicks(3134));

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 50,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 13, 7, 11, 37, 106, DateTimeKind.Local).AddTicks(3135));

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 51,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 13, 7, 11, 37, 106, DateTimeKind.Local).AddTicks(3137));

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 52,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 13, 7, 11, 37, 106, DateTimeKind.Local).AddTicks(3138));

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 53,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 13, 7, 11, 37, 106, DateTimeKind.Local).AddTicks(3139));

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 54,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 13, 7, 11, 37, 106, DateTimeKind.Local).AddTicks(3140));

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 55,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 13, 7, 11, 37, 106, DateTimeKind.Local).AddTicks(3140));

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 56,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 13, 7, 11, 37, 106, DateTimeKind.Local).AddTicks(3141));

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 57,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 13, 7, 11, 37, 106, DateTimeKind.Local).AddTicks(3142));

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 58,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 13, 7, 11, 37, 106, DateTimeKind.Local).AddTicks(3142));

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 59,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 13, 7, 11, 37, 106, DateTimeKind.Local).AddTicks(3143));

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 60,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 13, 7, 11, 37, 106, DateTimeKind.Local).AddTicks(3143));

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 61,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 13, 7, 11, 37, 106, DateTimeKind.Local).AddTicks(3145));

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 62,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 13, 7, 11, 37, 106, DateTimeKind.Local).AddTicks(3146));

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 63,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 13, 7, 11, 37, 106, DateTimeKind.Local).AddTicks(3147));

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 64,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 13, 7, 11, 37, 106, DateTimeKind.Local).AddTicks(3148));

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 65,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 13, 7, 11, 37, 106, DateTimeKind.Local).AddTicks(3148));

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 66,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 13, 7, 11, 37, 106, DateTimeKind.Local).AddTicks(3150));

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 67,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 13, 7, 11, 37, 106, DateTimeKind.Local).AddTicks(3151));

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 68,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 13, 7, 11, 37, 106, DateTimeKind.Local).AddTicks(3151));

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 69,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 13, 7, 11, 37, 106, DateTimeKind.Local).AddTicks(3152));

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 70,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 13, 7, 11, 37, 106, DateTimeKind.Local).AddTicks(3152));

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 71,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 13, 7, 11, 37, 106, DateTimeKind.Local).AddTicks(3155));

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 72,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 13, 7, 11, 37, 106, DateTimeKind.Local).AddTicks(3156));

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 73,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 13, 7, 11, 37, 106, DateTimeKind.Local).AddTicks(3156));

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 74,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 13, 7, 11, 37, 106, DateTimeKind.Local).AddTicks(3157));

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 75,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 13, 7, 11, 37, 106, DateTimeKind.Local).AddTicks(3158));

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 76,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 13, 7, 11, 37, 106, DateTimeKind.Local).AddTicks(3158));

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 77,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 13, 7, 11, 37, 106, DateTimeKind.Local).AddTicks(3160));

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Employees_EmployeeId",
                table: "Reservations",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
