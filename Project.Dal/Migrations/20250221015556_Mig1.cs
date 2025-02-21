using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Project.Dal.Migrations
{
    /// <inheritdoc />
    public partial class Mig1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ActivationCode = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Salary = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    HireDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Shift = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ExtraServices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "money", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExtraServices", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Packages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PriceMultiplier = table.Column<decimal>(type: "money", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Packages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RoomTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AppUserProfiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nationality = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdentityNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AppUserId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserProfiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppUserProfiles_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Floor = table.Column<int>(type: "int", nullable: false),
                    PricePerNight = table.Column<decimal>(type: "money", nullable: false),
                    RoomStatus = table.Column<int>(type: "int", nullable: false),
                    RoomTypeId = table.Column<int>(type: "int", nullable: false),
                    HasBalcony = table.Column<bool>(type: "bit", nullable: false),
                    HasMinibar = table.Column<bool>(type: "bit", nullable: false),
                    HasAirConditioner = table.Column<bool>(type: "bit", nullable: false),
                    HasTV = table.Column<bool>(type: "bit", nullable: false),
                    HasHairDryer = table.Column<bool>(type: "bit", nullable: false),
                    HasWifi = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rooms_RoomTypes_RoomTypeId",
                        column: x => x.RoomTypeId,
                        principalTable: "RoomTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "money", nullable: false),
                    AppUserId = table.Column<int>(type: "int", nullable: true),
                    RoomId = table.Column<int>(type: "int", nullable: false),
                    PackageId = table.Column<int>(type: "int", nullable: true),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    ReservationStatus = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reservations_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Reservations_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservations_Packages_PackageId",
                        column: x => x.PackageId,
                        principalTable: "Packages",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Reservations_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PaymentAmount = table.Column<decimal>(type: "money", nullable: false),
                    PaymentMethod = table.Column<int>(type: "int", nullable: false),
                    ReservationId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Payments_Reservations_ReservationId",
                        column: x => x.ReservationId,
                        principalTable: "Reservations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReservationExtraServices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReservationId = table.Column<int>(type: "int", nullable: false),
                    ExtraServiceId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReservationExtraServices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReservationExtraServices_ExtraServices_ExtraServiceId",
                        column: x => x.ExtraServiceId,
                        principalTable: "ExtraServices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReservationExtraServices_Reservations_ReservationId",
                        column: x => x.ReservationId,
                        principalTable: "Reservations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { 1, "e866e3c6-c9de-4e0c-a5d4-0e36ab251bcd", "Admin", "ADMIN" },
                    { 2, "efcd4aa6-c2c5-4a1e-8143-b712a21ca20d", "Member", "MEMBER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ActivationCode", "ConcurrencyStamp", "CreatedDate", "DeletedDate", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "ModifiedDate", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Status", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { 1, 0, new Guid("00000000-0000-0000-0000-000000000000"), "d7b096d4-a002-4e41-91c8-e6b9211a98a7", new DateTime(2025, 2, 21, 4, 55, 55, 903, DateTimeKind.Local).AddTicks(3489), null, "bilgehotel@email.com", true, false, null, null, "BILGEHOTEL@EMAIL.COM", "BILGEHOTEL", "AQAAAAIAAYagAAAAELh0/TlxTvj0z8/x5Qh+cLw02v3VgNyLRiwgfActC3FzcS+zxl3pRfGTJrUHfPP4Fg==", null, false, "68779767-fe0b-4604-a326-8ac3793e7b47", 1, false, "bilgehotel" },
                    { 2, 0, new Guid("00000000-0000-0000-0000-000000000000"), "47c04f04-ed41-4616-a37a-5363096e78ac", new DateTime(2025, 2, 21, 4, 55, 55, 953, DateTimeKind.Local).AddTicks(2860), null, "testmember@email.com", true, false, null, null, "TESTMEMBER@EMAIL.COM", "TESTMEMBER", "AQAAAAIAAYagAAAAEDFPxQlOcG2vFS5VdLyR+Ouvd0vh9b1rt49ID2szh4MLmc9qT7FORqSaeRXnmnVaxQ==", null, false, "b2e0b876-2bec-43ce-bf27-d8f3c4c396a2", 1, false, "testmember" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Address", "BirthDate", "CreatedDate", "DeletedDate", "FirstName", "HireDate", "LastName", "ModifiedDate", "PhoneNumber", "Salary", "Shift", "Status" },
                values: new object[,]
                {
                    { 1, "İbn-i Sina Sokak 79a, Bingöl, Makau (Makao)", new DateTime(1970, 4, 23, 14, 54, 57, 92, DateTimeKind.Local).AddTicks(8832), new DateTime(2025, 2, 21, 4, 55, 55, 852, DateTimeKind.Local).AddTicks(3346), null, "Buyat", new DateTime(2014, 3, 27, 6, 22, 11, 890, DateTimeKind.Local).AddTicks(1618), "Balcı", null, "+90-679-160-21-48", 140.90m, 2, 1 },
                    { 2, "30 Ağustos Caddesi 9, Denizli, Polonya", new DateTime(1978, 5, 3, 21, 3, 19, 27, DateTimeKind.Local).AddTicks(705), new DateTime(2025, 2, 21, 4, 55, 55, 852, DateTimeKind.Local).AddTicks(3490), null, "Kızdurmuş", new DateTime(2023, 6, 22, 6, 50, 18, 821, DateTimeKind.Local).AddTicks(4949), "Abadan", null, "+90-291-360-6-708", 126.69m, 3, 1 },
                    { 3, "Barış Sokak 64c, Kilis, Saint Helena, İngiltere", new DateTime(1990, 1, 15, 9, 23, 17, 726, DateTimeKind.Local).AddTicks(9866), new DateTime(2025, 2, 21, 4, 55, 55, 852, DateTimeKind.Local).AddTicks(3567), null, "Aladoğan", new DateTime(2018, 3, 28, 4, 1, 37, 935, DateTimeKind.Local).AddTicks(860), "Çetiner", null, "+90-539-211-2-860", 123.39m, 2, 1 },
                    { 4, "Sevgi Sokak 69a, Tekirdağ, Slovakya", new DateTime(1970, 4, 23, 22, 14, 44, 502, DateTimeKind.Local).AddTicks(3610), new DateTime(2025, 2, 21, 4, 55, 55, 852, DateTimeKind.Local).AddTicks(3671), null, "Altınoba", new DateTime(2015, 1, 24, 1, 31, 24, 309, DateTimeKind.Local).AddTicks(213), "Akşit", null, "+90-131-668-85-57", 123.63m, 1, 1 },
                    { 5, "Harman Altı Sokak 253, Çankırı, İspanya", new DateTime(1970, 7, 26, 9, 38, 12, 409, DateTimeKind.Local).AddTicks(2482), new DateTime(2025, 2, 21, 4, 55, 55, 852, DateTimeKind.Local).AddTicks(3781), null, "Açığ", new DateTime(2018, 7, 1, 12, 47, 9, 969, DateTimeKind.Local).AddTicks(936), "Kıraç ", null, "+90-528-607-6-906", 151.24m, 2, 1 },
                    { 6, "İsmet Attila Caddesi 70b, Artvin, Malezya", new DateTime(1979, 11, 3, 15, 6, 38, 620, DateTimeKind.Local).AddTicks(3537), new DateTime(2025, 2, 21, 4, 55, 55, 852, DateTimeKind.Local).AddTicks(3925), null, "Eyiz", new DateTime(2019, 6, 5, 4, 28, 46, 572, DateTimeKind.Local).AddTicks(7138), "Paksüt", null, "+90-260-912-0-892", 122.02m, 1, 1 },
                    { 7, "Afyon Kaya Sokak 7, K.maraş, Fas", new DateTime(1969, 10, 11, 4, 10, 37, 691, DateTimeKind.Local).AddTicks(4919), new DateTime(2025, 2, 21, 4, 55, 55, 852, DateTimeKind.Local).AddTicks(3998), null, "Arslanargun", new DateTime(2017, 6, 24, 8, 44, 24, 66, DateTimeKind.Local).AddTicks(9015), "Özbir", null, "+90-346-168-0-101", 150.42m, 1, 1 },
                    { 8, "Sağlık Sokak 6, Konya, Şili", new DateTime(1972, 3, 15, 6, 41, 53, 739, DateTimeKind.Local).AddTicks(982), new DateTime(2025, 2, 21, 4, 55, 55, 852, DateTimeKind.Local).AddTicks(4093), null, "Bayınçur", new DateTime(2017, 5, 16, 15, 12, 54, 468, DateTimeKind.Local).AddTicks(1474), "Çağıran", null, "+90-151-782-98-04", 121.54m, 1, 1 },
                    { 9, "Oğuzhan Sokak 48b, Şanlıurfa, Uruguay", new DateTime(2004, 7, 31, 1, 58, 39, 832, DateTimeKind.Local).AddTicks(2019), new DateTime(2025, 2, 21, 4, 55, 55, 852, DateTimeKind.Local).AddTicks(4226), null, "Inanç", new DateTime(2022, 7, 9, 14, 1, 6, 524, DateTimeKind.Local).AddTicks(9012), "Beşerler", null, "+90-203-641-85-97", 138.58m, 1, 1 },
                    { 10, "Saygılı Sokak 48, Ordu, Hırvatistan", new DateTime(2002, 1, 2, 10, 24, 0, 471, DateTimeKind.Local).AddTicks(8630), new DateTime(2025, 2, 21, 4, 55, 55, 852, DateTimeKind.Local).AddTicks(4350), null, "Aygırak", new DateTime(2023, 11, 19, 12, 42, 7, 907, DateTimeKind.Local).AddTicks(6158), "Ertepınar", null, "+90-058-947-3-101", 116.99m, 2, 1 },
                    { 11, "Ali Çetinkaya Caddesi 3, Kırşehir, Kolombiya", new DateTime(1996, 9, 19, 12, 59, 58, 165, DateTimeKind.Local).AddTicks(2898), new DateTime(2025, 2, 21, 4, 55, 55, 852, DateTimeKind.Local).AddTicks(4424), null, "Gökçen", new DateTime(2018, 5, 20, 19, 50, 17, 325, DateTimeKind.Local).AddTicks(6380), "Kunt", null, "+90-535-332-5-256", 116.20m, 1, 1 },
                    { 12, "Bahçe Sokak 99b, Antalya, Kosta Rika", new DateTime(1981, 2, 20, 4, 18, 5, 933, DateTimeKind.Local).AddTicks(5437), new DateTime(2025, 2, 21, 4, 55, 55, 852, DateTimeKind.Local).AddTicks(4520), null, "Ayızdağ", new DateTime(2015, 8, 29, 20, 26, 4, 125, DateTimeKind.Local).AddTicks(8109), "Kutlay", null, "+90-564-329-4-525", 134.07m, 2, 1 },
                    { 13, "Lütfi Karadirek Caddesi 31, Hakkari, İran", new DateTime(2000, 5, 6, 17, 57, 14, 66, DateTimeKind.Local).AddTicks(8365), new DateTime(2025, 2, 21, 4, 55, 55, 852, DateTimeKind.Local).AddTicks(4631), null, "Başçı", new DateTime(2015, 5, 18, 8, 58, 13, 870, DateTimeKind.Local).AddTicks(2942), "Evliyaoğlu", null, "+90-095-307-11-27", 129.42m, 2, 1 },
                    { 14, "Harman Altı Sokak 429, Tunceli, Yeni Zelanda", new DateTime(1969, 10, 11, 1, 25, 34, 534, DateTimeKind.Local).AddTicks(342), new DateTime(2025, 2, 21, 4, 55, 55, 852, DateTimeKind.Local).AddTicks(4695), null, "Başkırt", new DateTime(2018, 1, 18, 17, 38, 7, 703, DateTimeKind.Local).AddTicks(2511), "Erkekli", null, "+90-929-253-08-87", 127.65m, 1, 1 },
                    { 15, "Bahçe Sokak 50b, Konya, Jamaika", new DateTime(1996, 11, 25, 17, 58, 17, 657, DateTimeKind.Local).AddTicks(1906), new DateTime(2025, 2, 21, 4, 55, 55, 852, DateTimeKind.Local).AddTicks(4797), null, "Bayurku", new DateTime(2016, 9, 13, 13, 33, 57, 898, DateTimeKind.Local).AddTicks(557), "Erkekli", null, "+90-248-823-21-42", 119.74m, 1, 1 },
                    { 16, "Sarıkaya Caddesi 9, Kocaeli, Zimbabve", new DateTime(1971, 9, 16, 18, 38, 37, 782, DateTimeKind.Local).AddTicks(2141), new DateTime(2025, 2, 21, 4, 55, 55, 852, DateTimeKind.Local).AddTicks(4892), null, "Basat", new DateTime(2018, 11, 18, 21, 53, 40, 990, DateTimeKind.Local).AddTicks(6147), "Kutlay", null, "+90-767-396-63-59", 121.77m, 1, 1 },
                    { 17, "Menekşe Sokak 470, Diyarbakır, Moğolistan", new DateTime(1975, 9, 10, 12, 49, 56, 189, DateTimeKind.Local).AddTicks(7065), new DateTime(2025, 2, 21, 4, 55, 55, 852, DateTimeKind.Local).AddTicks(4996), null, "Bulaçapan", new DateTime(2022, 12, 17, 15, 5, 4, 959, DateTimeKind.Local).AddTicks(233), "Menemencioğlu", null, "+90-860-181-7-394", 129.14m, 1, 1 },
                    { 18, "Kekeçoğlu Sokak 5, Aksaray, Burkina Faso", new DateTime(2001, 12, 8, 10, 23, 54, 333, DateTimeKind.Local).AddTicks(2086), new DateTime(2025, 2, 21, 4, 55, 55, 852, DateTimeKind.Local).AddTicks(5064), null, "Gün", new DateTime(2015, 2, 3, 10, 33, 52, 894, DateTimeKind.Local).AddTicks(5283), "Doğan ", null, "+90-496-761-47-04", 119.03m, 2, 1 },
                    { 19, "Köypınar Sokak 34b, Iğdır, Kuveyt", new DateTime(1995, 5, 12, 10, 30, 21, 692, DateTimeKind.Local).AddTicks(2977), new DateTime(2025, 2, 21, 4, 55, 55, 852, DateTimeKind.Local).AddTicks(5148), null, "Bıçkıcı", new DateTime(2014, 8, 13, 15, 9, 46, 549, DateTimeKind.Local).AddTicks(9931), "Çevik", null, "+90-887-223-52-19", 141.72m, 1, 1 },
                    { 20, "Bandak Sokak 622, Ordu, Amerikan Samoa", new DateTime(1976, 4, 23, 23, 22, 18, 808, DateTimeKind.Local).AddTicks(656), new DateTime(2025, 2, 21, 4, 55, 55, 852, DateTimeKind.Local).AddTicks(5241), null, "Aksungur", new DateTime(2024, 1, 13, 15, 59, 56, 872, DateTimeKind.Local).AddTicks(8129), "Tanrıkulu", null, "+90-131-178-22-09", 134.27m, 1, 1 },
                    { 21, "Afyon Kaya Sokak 56, Kütahya, Yemen", new DateTime(1989, 9, 12, 6, 0, 31, 955, DateTimeKind.Local).AddTicks(1688), new DateTime(2025, 2, 21, 4, 55, 55, 852, DateTimeKind.Local).AddTicks(5354), null, "Bangu", new DateTime(2016, 10, 30, 22, 26, 15, 198, DateTimeKind.Local).AddTicks(7536), "Uluhan", null, "+90-959-126-9-784", 134.69m, 2, 1 },
                    { 22, "Bandak Sokak 25b, Tokat, Bahama Adaları", new DateTime(1985, 6, 5, 3, 43, 16, 580, DateTimeKind.Local).AddTicks(4794), new DateTime(2025, 2, 21, 4, 55, 55, 852, DateTimeKind.Local).AddTicks(5416), null, "Bozbörü", new DateTime(2020, 2, 27, 4, 10, 26, 267, DateTimeKind.Local).AddTicks(4224), "Durmaz", null, "+90-928-480-3-126", 155.59m, 2, 1 },
                    { 23, "Sarıkaya Caddesi 48a, Niğde, Fransız Guyanası", new DateTime(1973, 5, 15, 17, 25, 40, 757, DateTimeKind.Local).AddTicks(5829), new DateTime(2025, 2, 21, 4, 55, 55, 852, DateTimeKind.Local).AddTicks(5506), null, "Kançı", new DateTime(2017, 6, 17, 20, 46, 43, 238, DateTimeKind.Local).AddTicks(195), "Samancı", null, "+90-564-395-29-11", 159.73m, 1, 1 },
                    { 24, "Dar Sokak 7, Adıyaman, Moğolistan", new DateTime(1992, 2, 10, 11, 15, 39, 123, DateTimeKind.Local).AddTicks(2943), new DateTime(2025, 2, 21, 4, 55, 55, 852, DateTimeKind.Local).AddTicks(5596), null, "Aşantuğrul", new DateTime(2023, 9, 8, 7, 5, 56, 93, DateTimeKind.Local).AddTicks(1466), "Barbarosoğlu", null, "+90-371-292-9-764", 166.68m, 2, 1 },
                    { 25, "Afyon Kaya Sokak 8, Erzincan, Cebelitarık, İngiltere", new DateTime(2004, 4, 8, 6, 54, 44, 984, DateTimeKind.Local).AddTicks(3701), new DateTime(2025, 2, 21, 4, 55, 55, 852, DateTimeKind.Local).AddTicks(5687), null, "Ayma", new DateTime(2016, 7, 11, 18, 11, 12, 219, DateTimeKind.Local).AddTicks(618), "Köylüoğlu", null, "+90-722-792-4-608", 150.39m, 2, 1 },
                    { 26, "Barış Sokak 82c, Şırnak, Libya", new DateTime(1981, 9, 1, 0, 24, 55, 752, DateTimeKind.Local).AddTicks(4809), new DateTime(2025, 2, 21, 4, 55, 55, 852, DateTimeKind.Local).AddTicks(5748), null, "Amul", new DateTime(2021, 7, 13, 23, 38, 35, 719, DateTimeKind.Local).AddTicks(3651), "Ekici", null, "+90-860-126-84-28", 167.15m, 1, 1 },
                    { 27, "Ülkü Sokak 31, Afyon, Malta", new DateTime(1993, 11, 16, 4, 47, 54, 730, DateTimeKind.Local).AddTicks(3917), new DateTime(2025, 2, 21, 4, 55, 55, 852, DateTimeKind.Local).AddTicks(5844), null, "Alpkutlu", new DateTime(2014, 7, 31, 12, 27, 32, 627, DateTimeKind.Local).AddTicks(6230), "Erbay", null, "+90-921-629-6-125", 162.97m, 1, 1 },
                    { 28, "Köypınar Sokak 1, Sakarya, Madagaskar", new DateTime(1991, 10, 20, 13, 2, 28, 75, DateTimeKind.Local).AddTicks(777), new DateTime(2025, 2, 21, 4, 55, 55, 852, DateTimeKind.Local).AddTicks(5939), null, "Batuk", new DateTime(2018, 1, 29, 23, 5, 33, 612, DateTimeKind.Local).AddTicks(4213), "Gürmen", null, "+90-430-963-10-40", 167.50m, 1, 1 },
                    { 29, "Fatih Sokak  54c, Çorum, Belize", new DateTime(1990, 8, 21, 21, 42, 3, 719, DateTimeKind.Local).AddTicks(5157), new DateTime(2025, 2, 21, 4, 55, 55, 852, DateTimeKind.Local).AddTicks(5999), null, "Buluş", new DateTime(2021, 3, 27, 12, 27, 22, 55, DateTimeKind.Local).AddTicks(6250), "Erginsoy", null, "+90-501-979-88-51", 148.87m, 2, 1 },
                    { 30, "Dar Sokak 61b, Aydın, Anguilla, İngiltere", new DateTime(2001, 7, 19, 21, 54, 6, 84, DateTimeKind.Local).AddTicks(2386), new DateTime(2025, 2, 21, 4, 55, 55, 852, DateTimeKind.Local).AddTicks(6080), null, "Çağru", new DateTime(2018, 11, 14, 11, 46, 41, 539, DateTimeKind.Local).AddTicks(1423), "Babacan", null, "+90-416-264-56-45", 114.37m, 1, 1 },
                    { 31, "Lütfi Karadirek Caddesi 341, Kars, Wake Adaları, Amerika", new DateTime(1972, 6, 13, 6, 41, 25, 540, DateTimeKind.Local).AddTicks(1268), new DateTime(2025, 2, 21, 4, 55, 55, 852, DateTimeKind.Local).AddTicks(6182), null, "Avluç", new DateTime(2015, 12, 29, 2, 54, 57, 918, DateTimeKind.Local).AddTicks(3965), "Tekand", null, "+90-299-763-00-07", 100.91m, 1, 1 },
                    { 32, "Dar Sokak 8, Aydın, Birleşik Arap Emirlikleri", new DateTime(1978, 4, 8, 22, 10, 57, 208, DateTimeKind.Local).AddTicks(5553), new DateTime(2025, 2, 21, 4, 55, 55, 852, DateTimeKind.Local).AddTicks(6306), null, "Altay", new DateTime(2020, 4, 23, 12, 58, 38, 106, DateTimeKind.Local).AddTicks(4160), "Günday", null, "+90-767-102-6-474", 105.70m, 1, 1 },
                    { 33, "Bandak Sokak 1, Uşak, San Marino", new DateTime(1968, 5, 30, 14, 30, 39, 167, DateTimeKind.Local).AddTicks(3177), new DateTime(2025, 2, 21, 4, 55, 55, 852, DateTimeKind.Local).AddTicks(6368), null, "Boran", new DateTime(2020, 8, 26, 22, 43, 9, 939, DateTimeKind.Local).AddTicks(5208), "Koç", null, "+90-255-375-45-50", 110.85m, 1, 1 },
                    { 34, "Mevlana Sokak 790, Sivas, Gine", new DateTime(1978, 4, 15, 2, 13, 59, 7, DateTimeKind.Local).AddTicks(190), new DateTime(2025, 2, 21, 4, 55, 55, 852, DateTimeKind.Local).AddTicks(6465), null, "Buluç", new DateTime(2018, 10, 10, 22, 42, 1, 381, DateTimeKind.Local).AddTicks(6487), "Gürmen", null, "+90-144-585-61-53", 119.03m, 1, 1 },
                    { 35, "Okul Sokak 11, Mardin, Amerikan Samoa", new DateTime(1978, 10, 7, 13, 44, 58, 716, DateTimeKind.Local).AddTicks(8639), new DateTime(2025, 2, 21, 4, 55, 55, 852, DateTimeKind.Local).AddTicks(6555), null, "Açığ", new DateTime(2020, 1, 29, 18, 18, 10, 122, DateTimeKind.Local).AddTicks(9613), "Bolatlı", null, "+90-688-689-6-339", 128.17m, 1, 1 },
                    { 36, "Sarıkaya Caddesi 12c, Giresun, Liechtenstein", new DateTime(1972, 9, 14, 14, 3, 57, 308, DateTimeKind.Local).AddTicks(2671), new DateTime(2025, 2, 21, 4, 55, 55, 852, DateTimeKind.Local).AddTicks(6652), null, "Akbörü", new DateTime(2021, 5, 13, 18, 41, 57, 880, DateTimeKind.Local).AddTicks(6122), "Ertepınar", null, "+90-062-967-4-859", 116.11m, 2, 1 },
                    { 37, "30 Ağustos Caddesi 58b, Bitlis, Türkmenistan", new DateTime(1971, 10, 26, 4, 34, 58, 743, DateTimeKind.Local).AddTicks(5063), new DateTime(2025, 2, 21, 4, 55, 55, 852, DateTimeKind.Local).AddTicks(6716), null, "Ağalak", new DateTime(2015, 10, 16, 23, 41, 49, 893, DateTimeKind.Local).AddTicks(4117), "Hamzaoğlu", null, "+90-262-545-7-629", 101.31m, 1, 1 },
                    { 38, "Atatürk Bulvarı 91, Eskişehir, Orta Afrika Cumhuriyeti", new DateTime(1968, 6, 22, 1, 3, 6, 521, DateTimeKind.Local).AddTicks(2619), new DateTime(2025, 2, 21, 4, 55, 55, 852, DateTimeKind.Local).AddTicks(6812), null, "Araboğa", new DateTime(2023, 4, 25, 22, 27, 10, 214, DateTimeKind.Local).AddTicks(3495), "Sadıklar", null, "+90-646-924-21-02", 114.19m, 1, 1 },
                    { 39, "Atatürk Bulvarı 0, Bartın, Guyana", new DateTime(2001, 10, 26, 6, 22, 5, 659, DateTimeKind.Local).AddTicks(7704), new DateTime(2025, 2, 21, 4, 55, 55, 852, DateTimeKind.Local).AddTicks(6899), null, "Kırlangıç", new DateTime(2021, 1, 12, 2, 33, 6, 749, DateTimeKind.Local).AddTicks(2689), "Polat", null, "+90-130-862-7-569", 123.14m, 2, 1 },
                    { 40, "Okul Sokak 85c, Kütahya, Saint Pierre ve Miquelon, Fransa", new DateTime(1982, 5, 20, 3, 7, 9, 216, DateTimeKind.Local).AddTicks(5316), new DateTime(2025, 2, 21, 4, 55, 55, 852, DateTimeKind.Local).AddTicks(6961), null, "Basanyalavaç", new DateTime(2018, 4, 8, 15, 38, 34, 690, DateTimeKind.Local).AddTicks(826), "Çağıran", null, "+90-120-954-21-17", 136.89m, 1, 1 },
                    { 41, "Fatih Sokak  66b, Muş, Güney Kore", new DateTime(1998, 4, 6, 3, 31, 38, 234, DateTimeKind.Local).AddTicks(483), new DateTime(2025, 2, 21, 4, 55, 55, 852, DateTimeKind.Local).AddTicks(7040), null, "Esen", new DateTime(2018, 5, 29, 8, 56, 16, 875, DateTimeKind.Local).AddTicks(6962), "Biçer", null, "+90-196-709-2-419", 121.15m, 1, 1 },
                    { 42, "Mevlana Sokak 31a, Hakkari, Polonya", new DateTime(1978, 8, 16, 9, 4, 6, 335, DateTimeKind.Local).AddTicks(7315), new DateTime(2025, 2, 21, 4, 55, 55, 852, DateTimeKind.Local).AddTicks(7134), null, "Erdeniözük", new DateTime(2017, 5, 10, 17, 57, 18, 487, DateTimeKind.Local).AddTicks(2050), "Mayhoş", null, "+90-242-144-6-127", 121.83m, 2, 1 },
                    { 43, "Bandak Sokak 97c, Isparta, Kamboçya", new DateTime(1973, 4, 27, 11, 9, 35, 916, DateTimeKind.Local).AddTicks(5454), new DateTime(2025, 2, 21, 4, 55, 55, 852, DateTimeKind.Local).AddTicks(7249), null, "Balta", new DateTime(2020, 5, 2, 20, 36, 21, 244, DateTimeKind.Local).AddTicks(4019), "Adıvar", null, "+90-514-703-93-11", 143.57m, 3, 1 },
                    { 44, "İsmet Attila Caddesi 305, Düzce, Danimarka", new DateTime(1990, 9, 13, 17, 17, 23, 679, DateTimeKind.Local).AddTicks(7638), new DateTime(2025, 2, 21, 4, 55, 55, 852, DateTimeKind.Local).AddTicks(7316), null, "Bükebuyruç", new DateTime(2021, 1, 31, 20, 18, 43, 52, DateTimeKind.Local).AddTicks(7339), "Başoğlu", null, "+90-603-474-02-48", 156.56m, 3, 1 }
                });

            migrationBuilder.InsertData(
                table: "ExtraServices",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Description", "ModifiedDate", "Name", "Price", "Status" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 2, 21, 4, 55, 55, 953, DateTimeKind.Local).AddTicks(4384), null, "Günlük sınırsız spa kullanımı.", null, "Spa Kullanımı", 50m, 1 },
                    { 2, new DateTime(2025, 2, 21, 4, 55, 55, 953, DateTimeKind.Local).AddTicks(4388), null, "24 saat oda servisi. Tüm yemek siparişleri dahildir.", null, "Oda Servisi", 30m, 1 },
                    { 3, new DateTime(2025, 2, 21, 4, 55, 55, 953, DateTimeKind.Local).AddTicks(4395), null, "Minibardaki içecekler ve atıştırmalıklar dahil.", null, "Minibar Kullanımı", 20m, 1 },
                    { 4, new DateTime(2025, 2, 21, 4, 55, 55, 953, DateTimeKind.Local).AddTicks(4401), null, "Gidiş-dönüş özel araç transferi.", null, "Havalimanı Transferi", 100m, 1 },
                    { 5, new DateTime(2025, 2, 21, 4, 55, 55, 953, DateTimeKind.Local).AddTicks(4405), null, "Konaklama süresince ücretsiz çamaşır ve kuru temizleme hizmeti.", null, "Çamaşırhane Hizmeti", 40m, 1 },
                    { 6, new DateTime(2025, 2, 21, 4, 55, 55, 953, DateTimeKind.Local).AddTicks(4428), null, "Ekstra günlük temizlik ve hijyen paketi.", null, "Günlük Oda Temizliği", 25m, 1 },
                    { 7, new DateTime(2025, 2, 21, 4, 55, 55, 953, DateTimeKind.Local).AddTicks(4432), null, "Özel şezlong ve plaj hizmetleri.", null, "Özel Plaj Alanı", 35m, 1 }
                });

            migrationBuilder.InsertData(
                table: "Packages",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Description", "ModifiedDate", "Name", "PriceMultiplier", "Status" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 2, 21, 4, 55, 55, 953, DateTimeKind.Local).AddTicks(4166), null, "Kahvaltı, öğle ve akşam yemeği dahil.", null, "Tam Pansiyon", 1.2m, 1 },
                    { 2, new DateTime(2025, 2, 21, 4, 55, 55, 953, DateTimeKind.Local).AddTicks(4181), null, "Tüm yemekler, alkollü-alkolsüz içecekler ve otelin sunduğu belirli hizmetler dahil.", null, "Her Şey Dahil", 1.5m, 1 }
                });

            migrationBuilder.InsertData(
                table: "RoomTypes",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Description", "ModifiedDate", "Name", "Status" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 2, 21, 4, 55, 55, 848, DateTimeKind.Local).AddTicks(5041), null, "1 adet tek kişilik yatak. Balkon ve minibar bulunmaz. Klima, TV, saç kurutma makinesi ve WiFi mevcuttur.", null, "Tek Kişilik", 1 },
                    { 2, new DateTime(2025, 2, 21, 4, 55, 55, 848, DateTimeKind.Local).AddTicks(5061), null, "1 adet büyük (duble) yatak. Minibar bulunur. Klima, TV, saç kurutma makinesi ve WiFi mevcuttur.", null, "Çift Kişilik (Duble)", 1 },
                    { 3, new DateTime(2025, 2, 21, 4, 55, 55, 848, DateTimeKind.Local).AddTicks(5063), null, "3 adet tek kişilik yatak. Balkon ve minibar bulunmaz. Klima, TV, saç kurutma makinesi ve WiFi mevcuttur.", null, "Üç Kişilik", 1 },
                    { 4, new DateTime(2025, 2, 21, 4, 55, 55, 848, DateTimeKind.Local).AddTicks(5065), null, "1 adet büyük (duble) yatak + 2 adet tek kişilik yatak. Balkon ve minibar bulunur. Klima, TV, saç kurutma makinesi ve WiFi mevcuttur.", null, "Dört Kişilik", 1 },
                    { 5, new DateTime(2025, 2, 21, 4, 55, 55, 848, DateTimeKind.Local).AddTicks(5066), null, "Geniş ve lüks oda. Özel oturma alanı, büyük yatak, balkon, minibar, özel banyo ve lüks hizmetler. Klima, TV, saç kurutma makinesi, WiFi ve özel hizmetler mevcuttur.", null, "Kral Dairesi", 1 }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 }
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Floor", "HasAirConditioner", "HasBalcony", "HasHairDryer", "HasMinibar", "HasTV", "HasWifi", "ModifiedDate", "PricePerNight", "RoomNumber", "RoomStatus", "RoomTypeId", "Status" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 2, 21, 4, 55, 55, 850, DateTimeKind.Local).AddTicks(7852), null, 1, true, false, true, false, true, true, null, 105.54m, "126", 1, 3, 1 },
                    { 2, new DateTime(2025, 2, 21, 4, 55, 55, 850, DateTimeKind.Local).AddTicks(7874), null, 1, true, false, true, false, true, true, null, 60.48m, "143", 2, 3, 1 },
                    { 3, new DateTime(2025, 2, 21, 4, 55, 55, 850, DateTimeKind.Local).AddTicks(7880), null, 1, true, false, true, false, true, true, null, 102.88m, "187", 3, 1, 1 },
                    { 4, new DateTime(2025, 2, 21, 4, 55, 55, 850, DateTimeKind.Local).AddTicks(7886), null, 1, true, false, true, false, true, true, null, 83.38m, "184", 1, 1, 1 },
                    { 5, new DateTime(2025, 2, 21, 4, 55, 55, 850, DateTimeKind.Local).AddTicks(7890), null, 1, true, false, true, false, true, true, null, 130.30m, "149", 3, 3, 1 },
                    { 6, new DateTime(2025, 2, 21, 4, 55, 55, 850, DateTimeKind.Local).AddTicks(7896), null, 1, true, false, true, false, true, true, null, 110.70m, "161", 1, 1, 1 },
                    { 7, new DateTime(2025, 2, 21, 4, 55, 55, 850, DateTimeKind.Local).AddTicks(7900), null, 1, true, false, true, false, true, true, null, 106.35m, "171", 3, 1, 1 },
                    { 8, new DateTime(2025, 2, 21, 4, 55, 55, 850, DateTimeKind.Local).AddTicks(7905), null, 1, true, false, true, false, true, true, null, 127.12m, "103", 1, 3, 1 },
                    { 9, new DateTime(2025, 2, 21, 4, 55, 55, 850, DateTimeKind.Local).AddTicks(7909), null, 1, true, false, true, false, true, true, null, 110.87m, "184", 2, 1, 1 },
                    { 10, new DateTime(2025, 2, 21, 4, 55, 55, 850, DateTimeKind.Local).AddTicks(7913), null, 1, true, false, true, false, true, true, null, 131.15m, "157", 1, 3, 1 },
                    { 11, new DateTime(2025, 2, 21, 4, 55, 55, 850, DateTimeKind.Local).AddTicks(7921), null, 2, true, false, true, true, true, true, null, 180.53m, "268", 1, 2, 1 },
                    { 12, new DateTime(2025, 2, 21, 4, 55, 55, 850, DateTimeKind.Local).AddTicks(7927), null, 2, true, false, true, false, true, true, null, 161.50m, "280", 1, 1, 1 },
                    { 13, new DateTime(2025, 2, 21, 4, 55, 55, 850, DateTimeKind.Local).AddTicks(7931), null, 2, true, false, true, true, true, true, null, 185.29m, "267", 1, 2, 1 },
                    { 14, new DateTime(2025, 2, 21, 4, 55, 55, 850, DateTimeKind.Local).AddTicks(7981), null, 2, true, false, true, false, true, true, null, 181.42m, "288", 1, 1, 1 },
                    { 15, new DateTime(2025, 2, 21, 4, 55, 55, 850, DateTimeKind.Local).AddTicks(7987), null, 2, true, false, true, true, true, true, null, 118.54m, "258", 3, 2, 1 },
                    { 16, new DateTime(2025, 2, 21, 4, 55, 55, 850, DateTimeKind.Local).AddTicks(7993), null, 2, true, false, true, true, true, true, null, 159.53m, "256", 2, 2, 1 },
                    { 17, new DateTime(2025, 2, 21, 4, 55, 55, 850, DateTimeKind.Local).AddTicks(8001), null, 2, true, false, true, false, true, true, null, 128.04m, "237", 2, 1, 1 },
                    { 18, new DateTime(2025, 2, 21, 4, 55, 55, 850, DateTimeKind.Local).AddTicks(8007), null, 2, true, false, true, true, true, true, null, 123.86m, "273", 1, 2, 1 },
                    { 19, new DateTime(2025, 2, 21, 4, 55, 55, 850, DateTimeKind.Local).AddTicks(8013), null, 2, true, false, true, false, true, true, null, 157.28m, "245", 3, 1, 1 },
                    { 20, new DateTime(2025, 2, 21, 4, 55, 55, 850, DateTimeKind.Local).AddTicks(8018), null, 2, true, false, true, false, true, true, null, 116.62m, "234", 3, 1, 1 },
                    { 21, new DateTime(2025, 2, 21, 4, 55, 55, 850, DateTimeKind.Local).AddTicks(8029), null, 3, true, true, true, true, true, true, null, 285.39m, "383", 3, 2, 1 },
                    { 22, new DateTime(2025, 2, 21, 4, 55, 55, 850, DateTimeKind.Local).AddTicks(8035), null, 3, true, true, true, true, true, true, null, 187.15m, "386", 3, 3, 1 },
                    { 23, new DateTime(2025, 2, 21, 4, 55, 55, 850, DateTimeKind.Local).AddTicks(8040), null, 3, true, true, true, true, true, true, null, 161.55m, "326", 3, 2, 1 },
                    { 24, new DateTime(2025, 2, 21, 4, 55, 55, 850, DateTimeKind.Local).AddTicks(8044), null, 3, true, true, true, true, true, true, null, 223.41m, "314", 1, 2, 1 },
                    { 25, new DateTime(2025, 2, 21, 4, 55, 55, 850, DateTimeKind.Local).AddTicks(8047), null, 3, true, true, true, true, true, true, null, 278.08m, "300", 3, 2, 1 },
                    { 26, new DateTime(2025, 2, 21, 4, 55, 55, 850, DateTimeKind.Local).AddTicks(8051), null, 3, true, true, true, true, true, true, null, 194.37m, "390", 3, 2, 1 },
                    { 27, new DateTime(2025, 2, 21, 4, 55, 55, 850, DateTimeKind.Local).AddTicks(8055), null, 3, true, true, true, true, true, true, null, 202.63m, "302", 3, 2, 1 },
                    { 28, new DateTime(2025, 2, 21, 4, 55, 55, 850, DateTimeKind.Local).AddTicks(8059), null, 3, true, true, true, true, true, true, null, 286.90m, "356", 1, 3, 1 },
                    { 29, new DateTime(2025, 2, 21, 4, 55, 55, 850, DateTimeKind.Local).AddTicks(8062), null, 3, true, true, true, true, true, true, null, 286.90m, "341", 3, 2, 1 },
                    { 30, new DateTime(2025, 2, 21, 4, 55, 55, 850, DateTimeKind.Local).AddTicks(8066), null, 3, true, true, true, true, true, true, null, 155.03m, "396", 1, 3, 1 },
                    { 31, new DateTime(2025, 2, 21, 4, 55, 55, 850, DateTimeKind.Local).AddTicks(8077), null, 4, true, true, true, true, true, true, null, 418.52m, "480", 1, 4, 1 },
                    { 32, new DateTime(2025, 2, 21, 4, 55, 55, 850, DateTimeKind.Local).AddTicks(8082), null, 4, true, true, true, true, true, true, null, 487.97m, "405", 3, 4, 1 },
                    { 33, new DateTime(2025, 2, 21, 4, 55, 55, 850, DateTimeKind.Local).AddTicks(8086), null, 4, true, true, true, true, true, true, null, 444.58m, "406", 2, 4, 1 },
                    { 34, new DateTime(2025, 2, 21, 4, 55, 55, 850, DateTimeKind.Local).AddTicks(8091), null, 4, true, true, true, true, true, true, null, 442.88m, "479", 1, 4, 1 },
                    { 35, new DateTime(2025, 2, 21, 4, 55, 55, 850, DateTimeKind.Local).AddTicks(8095), null, 4, true, true, true, true, true, true, null, 352.89m, "404", 3, 2, 1 },
                    { 36, new DateTime(2025, 2, 21, 4, 55, 55, 850, DateTimeKind.Local).AddTicks(8099), null, 4, true, true, true, true, true, true, null, 331.73m, "429", 1, 2, 1 },
                    { 37, new DateTime(2025, 2, 21, 4, 55, 55, 850, DateTimeKind.Local).AddTicks(8102), null, 4, true, true, true, true, true, true, null, 214.85m, "494", 2, 2, 1 },
                    { 38, new DateTime(2025, 2, 21, 4, 55, 55, 850, DateTimeKind.Local).AddTicks(8106), null, 4, true, true, true, true, true, true, null, 220.54m, "493", 2, 4, 1 },
                    { 39, new DateTime(2025, 2, 21, 4, 55, 55, 850, DateTimeKind.Local).AddTicks(8109), null, 4, true, true, true, true, true, true, null, 441.45m, "441", 2, 4, 1 },
                    { 40, new DateTime(2025, 2, 21, 4, 55, 55, 850, DateTimeKind.Local).AddTicks(8113), null, 4, true, true, true, true, true, true, null, 362.78m, "468", 2, 2, 1 },
                    { 41, new DateTime(2025, 2, 21, 4, 55, 55, 850, DateTimeKind.Local).AddTicks(8117), null, 4, true, true, true, true, true, true, null, 1000m, "500", 1, 5, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppUserProfiles_AppUserId",
                table: "AppUserProfiles",
                column: "AppUserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_ReservationId",
                table: "Payments",
                column: "ReservationId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ReservationExtraServices_ExtraServiceId",
                table: "ReservationExtraServices",
                column: "ExtraServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_ReservationExtraServices_ReservationId",
                table: "ReservationExtraServices",
                column: "ReservationId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_AppUserId",
                table: "Reservations",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_EmployeeId",
                table: "Reservations",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_PackageId",
                table: "Reservations",
                column: "PackageId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_RoomId",
                table: "Reservations",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_RoomTypeId",
                table: "Rooms",
                column: "RoomTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppUserProfiles");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "ReservationExtraServices");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "ExtraServices");

            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Packages");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropTable(
                name: "RoomTypes");
        }
    }
}
