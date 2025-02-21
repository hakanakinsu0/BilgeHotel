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
                    Salary = table.Column<decimal>(type: "money", nullable: false),
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
                    { 1, "b4f09409-22c2-4d8c-9299-b5519816481d", "Admin", "ADMIN" },
                    { 2, "4a1b0d50-3612-42e5-8b62-28e61f189da8", "Member", "MEMBER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ActivationCode", "ConcurrencyStamp", "CreatedDate", "DeletedDate", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "ModifiedDate", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Status", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { 1, 0, new Guid("00000000-0000-0000-0000-000000000000"), "8e063270-335b-4f8b-ade3-204a1ecafeed", new DateTime(2025, 2, 21, 6, 35, 44, 229, DateTimeKind.Local).AddTicks(6534), null, "bilgehotel@email.com", true, false, null, null, "BILGEHOTEL@EMAIL.COM", "BILGEHOTEL", "AQAAAAIAAYagAAAAEPjeFelXifPg3RMX9uiKTlePu5O79zzqPH6I8QmB4QJKKzaD260r8wnqleV1lBSWOA==", null, false, "36e645b6-6736-4370-806c-7270b30c6904", 1, false, "bilgehotel" },
                    { 2, 0, new Guid("00000000-0000-0000-0000-000000000000"), "748f7cb3-972b-478c-bb12-6152a7de2a7a", new DateTime(2025, 2, 21, 6, 35, 44, 267, DateTimeKind.Local).AddTicks(1867), null, "testmember@email.com", true, false, null, null, "TESTMEMBER@EMAIL.COM", "TESTMEMBER", "AQAAAAIAAYagAAAAEJ0CcPYKa/9BePjfghYxE9MqwXAMGoVrsJjWIhCft3DRI2H3aPVyciHpzaqsdoqYcg==", null, false, "0f7729cc-37a6-456b-9bd7-7916606e25bb", 1, false, "testmember" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Address", "BirthDate", "CreatedDate", "DeletedDate", "FirstName", "HireDate", "LastName", "ModifiedDate", "PhoneNumber", "Salary", "Shift", "Status" },
                values: new object[,]
                {
                    { 1, "İsmet Paşa Caddesi 5, Elazığ, Amerika Birleşik Devletleri", new DateTime(2004, 3, 25, 21, 24, 47, 83, DateTimeKind.Local).AddTicks(3267), new DateTime(2025, 2, 21, 6, 35, 44, 190, DateTimeKind.Local).AddTicks(6044), null, "Edil", new DateTime(2023, 12, 9, 15, 11, 34, 709, DateTimeKind.Local).AddTicks(7044), "Akar ", null, "+90-209-026-6-923", 131.55m, 3, 1 },
                    { 2, "Okul Sokak 90c, Burdur, Zambiya", new DateTime(1990, 4, 16, 20, 30, 33, 656, DateTimeKind.Local).AddTicks(8369), new DateTime(2025, 2, 21, 6, 35, 44, 190, DateTimeKind.Local).AddTicks(6144), null, "Atılgan", new DateTime(2019, 2, 26, 22, 33, 42, 877, DateTimeKind.Local).AddTicks(3897), "Akay", null, "+90-911-748-11-35", 145.71m, 1, 1 },
                    { 3, "İsmet Attila Caddesi 93c, Bitlis, Yeni Zelanda", new DateTime(1986, 11, 15, 17, 21, 19, 563, DateTimeKind.Local).AddTicks(6089), new DateTime(2025, 2, 21, 6, 35, 44, 190, DateTimeKind.Local).AddTicks(6203), null, "Erentüz", new DateTime(2018, 11, 1, 0, 48, 0, 202, DateTimeKind.Local).AddTicks(8067), "Tuğluk", null, "+90-972-869-0-452", 133.71m, 1, 1 },
                    { 4, "Bahçe Sokak 39c, Kocaeli, Monako", new DateTime(1996, 1, 13, 11, 3, 24, 553, DateTimeKind.Local).AddTicks(4436), new DateTime(2025, 2, 21, 6, 35, 44, 190, DateTimeKind.Local).AddTicks(6289), null, "Berkiş", new DateTime(2022, 7, 27, 4, 38, 51, 521, DateTimeKind.Local).AddTicks(4260), "Gönültaş", null, "+90-408-868-3-380", 158.10m, 1, 1 },
                    { 5, "Kekeçoğlu Sokak 75b, Bartın, Grönland", new DateTime(2007, 1, 22, 17, 14, 31, 524, DateTimeKind.Local).AddTicks(4639), new DateTime(2025, 2, 21, 6, 35, 44, 190, DateTimeKind.Local).AddTicks(6369), null, "Alka", new DateTime(2014, 11, 14, 14, 13, 55, 434, DateTimeKind.Local).AddTicks(4204), "Sarıoğlu", null, "+90-524-898-6-568", 126.45m, 1, 1 },
                    { 6, "Ali Çetinkaya Caddesi 48, Uşak, Haiti", new DateTime(1987, 4, 1, 5, 42, 6, 567, DateTimeKind.Local).AddTicks(3080), new DateTime(2025, 2, 21, 6, 35, 44, 190, DateTimeKind.Local).AddTicks(6459), null, "Aşan", new DateTime(2018, 8, 2, 12, 42, 14, 271, DateTimeKind.Local).AddTicks(7194), "Yazıcı", null, "+90-169-329-09-48", 146.20m, 3, 1 },
                    { 7, "Ali Çetinkaya Caddesi 21b, İstanbul, Bahreyn", new DateTime(1995, 9, 10, 2, 28, 41, 467, DateTimeKind.Local).AddTicks(1716), new DateTime(2025, 2, 21, 6, 35, 44, 190, DateTimeKind.Local).AddTicks(6518), null, "Kayaçık", new DateTime(2014, 4, 7, 11, 16, 4, 649, DateTimeKind.Local).AddTicks(5320), "Gümüşpala", null, "+90-480-087-66-83", 127.56m, 2, 1 },
                    { 8, "Okul Sokak 299, Yozgat, Amerikan Samoa", new DateTime(1985, 12, 7, 23, 50, 21, 221, DateTimeKind.Local).AddTicks(5270), new DateTime(2025, 2, 21, 6, 35, 44, 190, DateTimeKind.Local).AddTicks(6608), null, "Kançı", new DateTime(2017, 2, 3, 1, 26, 2, 116, DateTimeKind.Local).AddTicks(1584), "Uluhan", null, "+90-037-783-18-76", 111.01m, 2, 1 },
                    { 9, "Dağınık Evler Sokak 35a, Muş, Küba", new DateTime(1989, 1, 2, 13, 13, 47, 308, DateTimeKind.Local).AddTicks(4932), new DateTime(2025, 2, 21, 6, 35, 44, 190, DateTimeKind.Local).AddTicks(6692), null, "Basan", new DateTime(2020, 8, 13, 0, 19, 37, 962, DateTimeKind.Local).AddTicks(5403), "Durmaz", null, "+90-319-743-15-07", 132.46m, 2, 1 },
                    { 10, "Kaldırım Sokak 47, Şanlıurfa, Afganistan", new DateTime(1981, 4, 23, 0, 54, 29, 41, DateTimeKind.Local).AddTicks(9785), new DateTime(2025, 2, 21, 6, 35, 44, 190, DateTimeKind.Local).AddTicks(6767), null, "Binbeği", new DateTime(2022, 9, 26, 8, 24, 34, 441, DateTimeKind.Local).AddTicks(664), "Özbir", null, "+90-061-916-85-82", 135.80m, 2, 1 },
                    { 11, "Kerimoğlu Sokak 93, Bursa, Filipinler", new DateTime(1992, 5, 2, 19, 59, 23, 236, DateTimeKind.Local).AddTicks(3996), new DateTime(2025, 2, 21, 6, 35, 44, 190, DateTimeKind.Local).AddTicks(6818), null, "Gökçiçek", new DateTime(2014, 4, 22, 9, 32, 59, 577, DateTimeKind.Local).AddTicks(504), "Adal", null, "+90-197-162-35-64", 128.59m, 2, 1 },
                    { 12, "Namık Kemal Caddesi 11c, İzmir, Grönland", new DateTime(2001, 10, 22, 1, 58, 5, 60, DateTimeKind.Local).AddTicks(8316), new DateTime(2025, 2, 21, 6, 35, 44, 190, DateTimeKind.Local).AddTicks(6899), null, "Ardıç", new DateTime(2017, 10, 22, 16, 9, 22, 428, DateTimeKind.Local).AddTicks(9140), "Kaya ", null, "+90-477-756-1-639", 126.85m, 2, 1 },
                    { 13, "Bayır Sokak 27, Nevşehir, Wake Adaları, Amerika", new DateTime(1993, 8, 26, 10, 10, 19, 83, DateTimeKind.Local).AddTicks(5473), new DateTime(2025, 2, 21, 6, 35, 44, 190, DateTimeKind.Local).AddTicks(6977), null, "Alkaşı", new DateTime(2020, 6, 12, 19, 9, 16, 979, DateTimeKind.Local).AddTicks(8783), "Tokgöz", null, "+90-247-253-83-86", 128.03m, 1, 1 },
                    { 14, "Bayır Sokak 780, Burdur, Midway Adaları, Amerika", new DateTime(2005, 11, 17, 4, 4, 38, 965, DateTimeKind.Local).AddTicks(3024), new DateTime(2025, 2, 21, 6, 35, 44, 190, DateTimeKind.Local).AddTicks(7060), null, "Kaynak", new DateTime(2023, 1, 13, 2, 8, 53, 998, DateTimeKind.Local).AddTicks(6327), "Okur", null, "+90-228-854-82-60", 127.23m, 1, 1 },
                    { 15, "Kocatepe Caddesi 57c, Kars, Nijerya", new DateTime(1983, 6, 24, 22, 22, 52, 884, DateTimeKind.Local).AddTicks(859), new DateTime(2025, 2, 21, 6, 35, 44, 190, DateTimeKind.Local).AddTicks(7110), null, "Bürküt", new DateTime(2022, 4, 17, 12, 18, 39, 814, DateTimeKind.Local).AddTicks(4865), "Kutlay", null, "+90-977-677-0-374", 129.06m, 2, 1 },
                    { 16, "Sevgi Sokak 70b, Kocaeli, Mikronezya", new DateTime(1980, 7, 14, 0, 15, 35, 317, DateTimeKind.Local).AddTicks(415), new DateTime(2025, 2, 21, 6, 35, 44, 190, DateTimeKind.Local).AddTicks(7172), null, "Aladağ", new DateTime(2020, 5, 30, 7, 25, 13, 709, DateTimeKind.Local).AddTicks(1496), "Koçyiğit", null, "+90-138-424-67-74", 129.92m, 2, 1 },
                    { 17, "Bayır Sokak 29b, Adana, Mauritius", new DateTime(1996, 8, 9, 4, 25, 51, 972, DateTimeKind.Local).AddTicks(7122), new DateTime(2025, 2, 21, 6, 35, 44, 190, DateTimeKind.Local).AddTicks(7249), null, "Başak", new DateTime(2014, 10, 21, 21, 17, 50, 722, DateTimeKind.Local).AddTicks(8801), "Gönültaş", null, "+90-019-318-26-57", 122.13m, 1, 1 },
                    { 18, "Harman Yolu Sokak  65c, Sivas, Christmas Adası , Avusturalya", new DateTime(2003, 12, 22, 20, 52, 53, 205, DateTimeKind.Local).AddTicks(4507), new DateTime(2025, 2, 21, 6, 35, 44, 190, DateTimeKind.Local).AddTicks(7302), null, "Ayaz", new DateTime(2017, 2, 27, 10, 36, 34, 161, DateTimeKind.Local).AddTicks(3013), "Egeli", null, "+90-856-777-99-35", 121.18m, 1, 1 },
                    { 19, "Bahçe Sokak 80, Amasya, Mali", new DateTime(1980, 6, 1, 9, 18, 3, 592, DateTimeKind.Local).AddTicks(145), new DateTime(2025, 2, 21, 6, 35, 44, 190, DateTimeKind.Local).AddTicks(7384), null, "Buyançuk", new DateTime(2018, 11, 30, 18, 12, 50, 71, DateTimeKind.Local).AddTicks(5975), "Demirel", null, "+90-263-503-6-992", 152.58m, 1, 1 },
                    { 20, "Kerimoğlu Sokak 017, Afyon, Zimbabve", new DateTime(1983, 11, 12, 6, 43, 17, 671, DateTimeKind.Local).AddTicks(7864), new DateTime(2025, 2, 21, 6, 35, 44, 190, DateTimeKind.Local).AddTicks(7458), null, "Belek", new DateTime(2022, 6, 23, 14, 31, 53, 239, DateTimeKind.Local).AddTicks(2289), "Erçetin", null, "+90-923-397-51-26", 163.20m, 1, 1 },
                    { 21, "Oğuzhan Sokak 6, Giresun, Barbados", new DateTime(1969, 9, 18, 13, 56, 57, 163, DateTimeKind.Local).AddTicks(5721), new DateTime(2025, 2, 21, 6, 35, 44, 190, DateTimeKind.Local).AddTicks(7538), null, "Bögü", new DateTime(2020, 10, 30, 6, 23, 1, 204, DateTimeKind.Local).AddTicks(9224), "Tekand", null, "+90-069-798-8-856", 151.74m, 1, 1 },
                    { 22, "Güven Yaka Sokak 48b, Antalya, Burundi", new DateTime(2005, 5, 3, 9, 19, 24, 337, DateTimeKind.Local).AddTicks(8014), new DateTime(2025, 2, 21, 6, 35, 44, 190, DateTimeKind.Local).AddTicks(7588), null, "Aydoğmuş", new DateTime(2019, 7, 9, 0, 35, 54, 238, DateTimeKind.Local).AddTicks(3495), "Kuzucu", null, "+90-682-069-7-301", 168.88m, 2, 1 },
                    { 23, "Yunus Emre Sokak 83c, Tekirdağ, Martinik, Fransa", new DateTime(2005, 9, 25, 18, 42, 57, 210, DateTimeKind.Local).AddTicks(4877), new DateTime(2025, 2, 21, 6, 35, 44, 190, DateTimeKind.Local).AddTicks(7666), null, "Bayık", new DateTime(2024, 1, 25, 23, 51, 20, 18, DateTimeKind.Local).AddTicks(1043), "Alyanak", null, "+90-364-638-9-399", 152.23m, 1, 1 },
                    { 24, "Köypınar Sokak 42c, Karaman, Ekvator Ginesi", new DateTime(1989, 11, 1, 16, 43, 56, 465, DateTimeKind.Local).AddTicks(3891), new DateTime(2025, 2, 21, 6, 35, 44, 190, DateTimeKind.Local).AddTicks(7740), null, "Batu", new DateTime(2022, 11, 21, 9, 21, 56, 398, DateTimeKind.Local).AddTicks(9847), "Aydan", null, "+90-011-731-93-37", 131.63m, 1, 1 },
                    { 25, "Menekşe Sokak 53, İzmir, Sierra Leone", new DateTime(1999, 1, 19, 13, 1, 37, 219, DateTimeKind.Local).AddTicks(8182), new DateTime(2025, 2, 21, 6, 35, 44, 190, DateTimeKind.Local).AddTicks(7813), null, "Çankız", new DateTime(2021, 9, 14, 5, 52, 17, 645, DateTimeKind.Local).AddTicks(5414), "Kılıççı", null, "+90-152-174-74-21", 137.14m, 2, 1 },
                    { 26, "Okul Sokak 19c, Kilis, Liechtenstein", new DateTime(1969, 4, 21, 18, 12, 30, 691, DateTimeKind.Local).AddTicks(3997), new DateTime(2025, 2, 21, 6, 35, 44, 190, DateTimeKind.Local).AddTicks(7860), null, "Alabörü", new DateTime(2016, 9, 14, 23, 17, 28, 283, DateTimeKind.Local).AddTicks(1246), "Kahveci", null, "+90-809-070-67-10", 152.28m, 1, 1 },
                    { 27, "Nalbant Sokak 94a, Karabük, Gambiya", new DateTime(1997, 2, 4, 19, 52, 20, 438, DateTimeKind.Local).AddTicks(9340), new DateTime(2025, 2, 21, 6, 35, 44, 190, DateTimeKind.Local).AddTicks(7925), null, "Asrı", new DateTime(2015, 5, 8, 4, 40, 7, 107, DateTimeKind.Local).AddTicks(1545), "Özberk", null, "+90-083-189-84-39", 161.60m, 2, 1 },
                    { 28, "Oğuzhan Sokak 19c, Çankırı, Nijerya", new DateTime(2003, 8, 19, 16, 0, 34, 952, DateTimeKind.Local).AddTicks(8395), new DateTime(2025, 2, 21, 6, 35, 44, 190, DateTimeKind.Local).AddTicks(8004), null, "Çağlayan", new DateTime(2020, 4, 25, 7, 30, 39, 566, DateTimeKind.Local).AddTicks(8962), "Kutlay", null, "+90-612-812-6-244", 134.36m, 2, 1 },
                    { 29, "Sevgi Sokak 09a, Konya, Saint Helena, İngiltere", new DateTime(2000, 6, 11, 12, 5, 16, 666, DateTimeKind.Local).AddTicks(503), new DateTime(2025, 2, 21, 6, 35, 44, 190, DateTimeKind.Local).AddTicks(8089), null, "Bilgeçikşin", new DateTime(2021, 1, 20, 17, 28, 17, 717, DateTimeKind.Local).AddTicks(6134), "Gümüşpala", null, "+90-383-266-60-60", 157.60m, 1, 1 },
                    { 30, "Namık Kemal Caddesi 4, Zonguldak, Kenya", new DateTime(1999, 5, 14, 8, 52, 55, 785, DateTimeKind.Local).AddTicks(7380), new DateTime(2025, 2, 21, 6, 35, 44, 190, DateTimeKind.Local).AddTicks(8141), null, "Akı", new DateTime(2021, 9, 6, 19, 31, 8, 833, DateTimeKind.Local).AddTicks(2849), "Tuğluk", null, "+90-801-970-5-565", 124.64m, 1, 1 },
                    { 31, "Mevlana Sokak 30c, Karabük, Kongo Demokratik Cumhuriyeti", new DateTime(1979, 10, 31, 21, 47, 2, 346, DateTimeKind.Local).AddTicks(5318), new DateTime(2025, 2, 21, 6, 35, 44, 190, DateTimeKind.Local).AddTicks(8213), null, "Bumın", new DateTime(2018, 10, 10, 14, 31, 25, 741, DateTimeKind.Local).AddTicks(7805), "Biçer", null, "+90-310-362-5-026", 110.75m, 1, 1 },
                    { 32, "Namık Kemal Caddesi 9, Edirne, Gambiya", new DateTime(1967, 9, 3, 10, 41, 42, 726, DateTimeKind.Local).AddTicks(1143), new DateTime(2025, 2, 21, 6, 35, 44, 190, DateTimeKind.Local).AddTicks(8286), null, "Iyıktağ", new DateTime(2014, 8, 9, 6, 23, 9, 774, DateTimeKind.Local).AddTicks(5693), "Çetin", null, "+90-528-041-3-811", 105.25m, 1, 1 },
                    { 33, "Ali Çetinkaya Caddesi 7, Bartın, Zimbabve", new DateTime(1999, 6, 19, 3, 47, 1, 537, DateTimeKind.Local).AddTicks(4581), new DateTime(2025, 2, 21, 6, 35, 44, 190, DateTimeKind.Local).AddTicks(8331), null, "Apak", new DateTime(2021, 6, 7, 3, 32, 59, 304, DateTimeKind.Local).AddTicks(5196), "Kuzucu", null, "+90-326-478-5-537", 139.57m, 2, 1 },
                    { 34, "Oğuzhan Sokak 81, Ağrı, Eritre", new DateTime(1982, 9, 11, 2, 39, 41, 888, DateTimeKind.Local).AddTicks(8620), new DateTime(2025, 2, 21, 6, 35, 44, 190, DateTimeKind.Local).AddTicks(8408), null, "Arkın", new DateTime(2020, 4, 21, 17, 0, 32, 769, DateTimeKind.Local).AddTicks(5846), "Özberk", null, "+90-763-719-1-079", 116.21m, 1, 1 },
                    { 35, "Oğuzhan Sokak 88a, Hatay, Arjantin", new DateTime(2004, 12, 15, 11, 27, 32, 180, DateTimeKind.Local).AddTicks(1706), new DateTime(2025, 2, 21, 6, 35, 44, 190, DateTimeKind.Local).AddTicks(8484), null, "Baçara", new DateTime(2015, 1, 23, 7, 25, 4, 389, DateTimeKind.Local).AddTicks(4064), "Numanoğlu", null, "+90-785-654-7-504", 120.36m, 1, 1 },
                    { 36, "İsmet Paşa Caddesi 1, Muğla, Liechtenstein", new DateTime(1971, 10, 30, 15, 18, 39, 803, DateTimeKind.Local).AddTicks(5683), new DateTime(2025, 2, 21, 6, 35, 44, 190, DateTimeKind.Local).AddTicks(8558), null, "Arı", new DateTime(2017, 6, 11, 17, 40, 55, 20, DateTimeKind.Local).AddTicks(4104), "Karaer", null, "+90-346-255-4-417", 123.62m, 2, 1 },
                    { 37, "Barış Sokak 043, Kayseri, Umman", new DateTime(1967, 3, 28, 13, 33, 53, 126, DateTimeKind.Local).AddTicks(7230), new DateTime(2025, 2, 21, 6, 35, 44, 190, DateTimeKind.Local).AddTicks(8609), null, "Adsız", new DateTime(2017, 8, 12, 23, 52, 36, 735, DateTimeKind.Local).AddTicks(7748), "Dalkıran", null, "+90-612-749-6-284", 104.03m, 2, 1 },
                    { 38, "Sevgi Sokak 16, Tekirdağ, Cape Verde", new DateTime(2005, 1, 30, 22, 48, 17, 778, DateTimeKind.Local).AddTicks(3051), new DateTime(2025, 2, 21, 6, 35, 44, 190, DateTimeKind.Local).AddTicks(8674), null, "Akbaş", new DateTime(2015, 5, 3, 6, 37, 40, 42, DateTimeKind.Local).AddTicks(2130), "Taşlı", null, "+90-764-507-36-60", 123.12m, 2, 1 },
                    { 39, "Dağınık Evler Sokak 24c, Edirne, Birleşik Arap Emirlikleri", new DateTime(2004, 9, 17, 1, 44, 12, 500, DateTimeKind.Local).AddTicks(8985), new DateTime(2025, 2, 21, 6, 35, 44, 190, DateTimeKind.Local).AddTicks(8749), null, "Akkun", new DateTime(2016, 9, 22, 12, 11, 0, 690, DateTimeKind.Local).AddTicks(8623), "Kahveci", null, "+90-975-950-7-195", 115.34m, 2, 1 },
                    { 40, "Sevgi Sokak 629, Tunceli, Litvanya", new DateTime(1998, 3, 27, 9, 59, 36, 533, DateTimeKind.Local).AddTicks(3479), new DateTime(2025, 2, 21, 6, 35, 44, 190, DateTimeKind.Local).AddTicks(8836), null, "Alayunt", new DateTime(2023, 5, 25, 22, 54, 58, 737, DateTimeKind.Local).AddTicks(7555), "Kutlay", null, "+90-406-775-9-124", 115.45m, 1, 1 },
                    { 41, "Kaldırım Sokak 60b, Nevşehir, Bahreyn", new DateTime(1979, 1, 22, 20, 36, 49, 385, DateTimeKind.Local).AddTicks(2757), new DateTime(2025, 2, 21, 6, 35, 44, 190, DateTimeKind.Local).AddTicks(8882), null, "Atımer", new DateTime(2014, 11, 9, 11, 25, 45, 834, DateTimeKind.Local).AddTicks(8518), "Çörekçi", null, "+90-009-997-25-65", 134.50m, 2, 1 },
                    { 42, "Ergenekon Sokak   541, Bartın, Saint Martin, Fransa", new DateTime(1975, 7, 2, 20, 47, 56, 588, DateTimeKind.Local).AddTicks(5565), new DateTime(2025, 2, 21, 6, 35, 44, 190, DateTimeKind.Local).AddTicks(8958), null, "Akbulak", new DateTime(2018, 12, 26, 10, 41, 50, 384, DateTimeKind.Local).AddTicks(1239), "Duygulu", null, "+90-892-117-6-207", 124.18m, 2, 1 },
                    { 43, "Kocatepe Caddesi 91c, Şanlıurfa, Sırbistan", new DateTime(2006, 6, 24, 1, 46, 11, 126, DateTimeKind.Local).AddTicks(3053), new DateTime(2025, 2, 21, 6, 35, 44, 190, DateTimeKind.Local).AddTicks(9035), null, "Çokramayul", new DateTime(2017, 8, 17, 14, 34, 43, 450, DateTimeKind.Local).AddTicks(9717), "Kaplangı", null, "+90-697-250-87-94", 167.12m, 3, 1 },
                    { 44, "Menekşe Sokak 6, Gümüşhane, Saint Pierre ve Miquelon, Fransa", new DateTime(1984, 10, 22, 14, 1, 11, 167, DateTimeKind.Local).AddTicks(6705), new DateTime(2025, 2, 21, 6, 35, 44, 190, DateTimeKind.Local).AddTicks(9111), null, "Barlıbay", new DateTime(2017, 6, 16, 3, 56, 28, 493, DateTimeKind.Local).AddTicks(2563), "Sinanoğlu", null, "+90-724-018-8-826", 166.41m, 1, 1 }
                });

            migrationBuilder.InsertData(
                table: "ExtraServices",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Description", "ModifiedDate", "Name", "Price", "Status" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 2, 21, 6, 35, 44, 267, DateTimeKind.Local).AddTicks(2226), null, "Günlük sınırsız spa kullanımı.", null, "Spa Kullanımı", 50m, 1 },
                    { 2, new DateTime(2025, 2, 21, 6, 35, 44, 267, DateTimeKind.Local).AddTicks(2228), null, "24 saat oda servisi. Tüm yemek siparişleri dahildir.", null, "Oda Servisi", 30m, 1 },
                    { 3, new DateTime(2025, 2, 21, 6, 35, 44, 267, DateTimeKind.Local).AddTicks(2229), null, "Minibardaki içecekler ve atıştırmalıklar dahil.", null, "Minibar Kullanımı", 20m, 1 },
                    { 4, new DateTime(2025, 2, 21, 6, 35, 44, 267, DateTimeKind.Local).AddTicks(2231), null, "Gidiş-dönüş özel araç transferi.", null, "Havalimanı Transferi", 100m, 1 },
                    { 5, new DateTime(2025, 2, 21, 6, 35, 44, 267, DateTimeKind.Local).AddTicks(2232), null, "Konaklama süresince ücretsiz çamaşır ve kuru temizleme hizmeti.", null, "Çamaşırhane Hizmeti", 40m, 1 },
                    { 6, new DateTime(2025, 2, 21, 6, 35, 44, 267, DateTimeKind.Local).AddTicks(2241), null, "Ekstra günlük temizlik ve hijyen paketi.", null, "Günlük Oda Temizliği", 25m, 1 },
                    { 7, new DateTime(2025, 2, 21, 6, 35, 44, 267, DateTimeKind.Local).AddTicks(2243), null, "Özel şezlong ve plaj hizmetleri.", null, "Özel Plaj Alanı", 35m, 1 }
                });

            migrationBuilder.InsertData(
                table: "Packages",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Description", "ModifiedDate", "Name", "PriceMultiplier", "Status" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 2, 21, 6, 35, 44, 267, DateTimeKind.Local).AddTicks(2181), null, "Kahvaltı, öğle ve akşam yemeği dahil.", null, "Tam Pansiyon", 1.2m, 1 },
                    { 2, new DateTime(2025, 2, 21, 6, 35, 44, 267, DateTimeKind.Local).AddTicks(2184), null, "Tüm yemekler, alkollü-alkolsüz içecekler ve otelin sunduğu belirli hizmetler dahil.", null, "Her Şey Dahil", 1.5m, 1 }
                });

            migrationBuilder.InsertData(
                table: "RoomTypes",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Description", "ModifiedDate", "Name", "Status" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 2, 21, 6, 35, 44, 187, DateTimeKind.Local).AddTicks(3354), null, "1 adet tek kişilik yatak. Balkon ve minibar bulunmaz. Klima, TV, saç kurutma makinesi ve WiFi mevcuttur.", null, "Tek Kişilik", 1 },
                    { 2, new DateTime(2025, 2, 21, 6, 35, 44, 187, DateTimeKind.Local).AddTicks(3363), null, "1 adet büyük (duble) yatak. Minibar bulunur. Klima, TV, saç kurutma makinesi ve WiFi mevcuttur.", null, "Çift Kişilik (Duble)", 1 },
                    { 3, new DateTime(2025, 2, 21, 6, 35, 44, 187, DateTimeKind.Local).AddTicks(3366), null, "3 adet tek kişilik yatak. Balkon ve minibar bulunmaz. Klima, TV, saç kurutma makinesi ve WiFi mevcuttur.", null, "Üç Kişilik", 1 },
                    { 4, new DateTime(2025, 2, 21, 6, 35, 44, 187, DateTimeKind.Local).AddTicks(3368), null, "1 adet büyük (duble) yatak + 2 adet tek kişilik yatak. Balkon ve minibar bulunur. Klima, TV, saç kurutma makinesi ve WiFi mevcuttur.", null, "Dört Kişilik", 1 },
                    { 5, new DateTime(2025, 2, 21, 6, 35, 44, 187, DateTimeKind.Local).AddTicks(3369), null, "Geniş ve lüks oda. Özel oturma alanı, büyük yatak, balkon, minibar, özel banyo ve lüks hizmetler. Klima, TV, saç kurutma makinesi, WiFi ve özel hizmetler mevcuttur.", null, "Kral Dairesi", 1 }
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
                    { 1, new DateTime(2025, 2, 21, 6, 35, 44, 189, DateTimeKind.Local).AddTicks(511), null, 1, true, false, true, false, true, true, null, 76.71m, "144", 2, 3, 1 },
                    { 2, new DateTime(2025, 2, 21, 6, 35, 44, 189, DateTimeKind.Local).AddTicks(523), null, 1, true, false, true, false, true, true, null, 69.15m, "132", 2, 3, 1 },
                    { 3, new DateTime(2025, 2, 21, 6, 35, 44, 189, DateTimeKind.Local).AddTicks(528), null, 1, true, false, true, false, true, true, null, 106.85m, "103", 1, 1, 1 },
                    { 4, new DateTime(2025, 2, 21, 6, 35, 44, 189, DateTimeKind.Local).AddTicks(532), null, 1, true, false, true, false, true, true, null, 139.36m, "171", 1, 3, 1 },
                    { 5, new DateTime(2025, 2, 21, 6, 35, 44, 189, DateTimeKind.Local).AddTicks(535), null, 1, true, false, true, false, true, true, null, 104.91m, "178", 3, 3, 1 },
                    { 6, new DateTime(2025, 2, 21, 6, 35, 44, 189, DateTimeKind.Local).AddTicks(539), null, 1, true, false, true, false, true, true, null, 109.72m, "162", 1, 3, 1 },
                    { 7, new DateTime(2025, 2, 21, 6, 35, 44, 189, DateTimeKind.Local).AddTicks(543), null, 1, true, false, true, false, true, true, null, 77.89m, "145", 2, 3, 1 },
                    { 8, new DateTime(2025, 2, 21, 6, 35, 44, 189, DateTimeKind.Local).AddTicks(546), null, 1, true, false, true, false, true, true, null, 106.06m, "155", 2, 3, 1 },
                    { 9, new DateTime(2025, 2, 21, 6, 35, 44, 189, DateTimeKind.Local).AddTicks(549), null, 1, true, false, true, false, true, true, null, 77.57m, "103", 1, 1, 1 },
                    { 10, new DateTime(2025, 2, 21, 6, 35, 44, 189, DateTimeKind.Local).AddTicks(553), null, 1, true, false, true, false, true, true, null, 129.11m, "196", 1, 1, 1 },
                    { 11, new DateTime(2025, 2, 21, 6, 35, 44, 189, DateTimeKind.Local).AddTicks(558), null, 2, true, false, true, false, true, true, null, 174.08m, "236", 2, 1, 1 },
                    { 12, new DateTime(2025, 2, 21, 6, 35, 44, 189, DateTimeKind.Local).AddTicks(561), null, 2, true, false, true, true, true, true, null, 128.91m, "257", 1, 2, 1 },
                    { 13, new DateTime(2025, 2, 21, 6, 35, 44, 189, DateTimeKind.Local).AddTicks(600), null, 2, true, false, true, false, true, true, null, 189.27m, "214", 1, 1, 1 },
                    { 14, new DateTime(2025, 2, 21, 6, 35, 44, 189, DateTimeKind.Local).AddTicks(604), null, 2, true, false, true, false, true, true, null, 128.28m, "281", 3, 1, 1 },
                    { 15, new DateTime(2025, 2, 21, 6, 35, 44, 189, DateTimeKind.Local).AddTicks(608), null, 2, true, false, true, false, true, true, null, 185.43m, "222", 1, 1, 1 },
                    { 16, new DateTime(2025, 2, 21, 6, 35, 44, 189, DateTimeKind.Local).AddTicks(610), null, 2, true, false, true, true, true, true, null, 199.12m, "218", 1, 2, 1 },
                    { 17, new DateTime(2025, 2, 21, 6, 35, 44, 189, DateTimeKind.Local).AddTicks(613), null, 2, true, false, true, true, true, true, null, 123.50m, "211", 1, 2, 1 },
                    { 18, new DateTime(2025, 2, 21, 6, 35, 44, 189, DateTimeKind.Local).AddTicks(617), null, 2, true, false, true, true, true, true, null, 115.16m, "210", 1, 2, 1 },
                    { 19, new DateTime(2025, 2, 21, 6, 35, 44, 189, DateTimeKind.Local).AddTicks(620), null, 2, true, false, true, false, true, true, null, 189.44m, "247", 2, 1, 1 },
                    { 20, new DateTime(2025, 2, 21, 6, 35, 44, 189, DateTimeKind.Local).AddTicks(622), null, 2, true, false, true, false, true, true, null, 162.30m, "259", 3, 1, 1 },
                    { 21, new DateTime(2025, 2, 21, 6, 35, 44, 189, DateTimeKind.Local).AddTicks(628), null, 3, true, true, true, true, true, true, null, 178.81m, "309", 1, 3, 1 },
                    { 22, new DateTime(2025, 2, 21, 6, 35, 44, 189, DateTimeKind.Local).AddTicks(632), null, 3, true, true, true, true, true, true, null, 153.10m, "338", 1, 2, 1 },
                    { 23, new DateTime(2025, 2, 21, 6, 35, 44, 189, DateTimeKind.Local).AddTicks(635), null, 3, true, true, true, true, true, true, null, 183.89m, "324", 3, 2, 1 },
                    { 24, new DateTime(2025, 2, 21, 6, 35, 44, 189, DateTimeKind.Local).AddTicks(638), null, 3, true, true, true, true, true, true, null, 204.69m, "381", 3, 2, 1 },
                    { 25, new DateTime(2025, 2, 21, 6, 35, 44, 189, DateTimeKind.Local).AddTicks(641), null, 3, true, true, true, true, true, true, null, 214.54m, "345", 1, 2, 1 },
                    { 26, new DateTime(2025, 2, 21, 6, 35, 44, 189, DateTimeKind.Local).AddTicks(644), null, 3, true, true, true, true, true, true, null, 251.37m, "323", 2, 2, 1 },
                    { 27, new DateTime(2025, 2, 21, 6, 35, 44, 189, DateTimeKind.Local).AddTicks(646), null, 3, true, true, true, true, true, true, null, 256.15m, "314", 1, 2, 1 },
                    { 28, new DateTime(2025, 2, 21, 6, 35, 44, 189, DateTimeKind.Local).AddTicks(650), null, 3, true, true, true, true, true, true, null, 188.16m, "365", 2, 3, 1 },
                    { 29, new DateTime(2025, 2, 21, 6, 35, 44, 189, DateTimeKind.Local).AddTicks(653), null, 3, true, true, true, true, true, true, null, 151.38m, "393", 3, 3, 1 },
                    { 30, new DateTime(2025, 2, 21, 6, 35, 44, 189, DateTimeKind.Local).AddTicks(655), null, 3, true, true, true, true, true, true, null, 263.47m, "331", 3, 2, 1 },
                    { 31, new DateTime(2025, 2, 21, 6, 35, 44, 189, DateTimeKind.Local).AddTicks(660), null, 4, true, true, true, true, true, true, null, 292.16m, "483", 3, 2, 1 },
                    { 32, new DateTime(2025, 2, 21, 6, 35, 44, 189, DateTimeKind.Local).AddTicks(663), null, 4, true, true, true, true, true, true, null, 264.04m, "465", 3, 2, 1 },
                    { 33, new DateTime(2025, 2, 21, 6, 35, 44, 189, DateTimeKind.Local).AddTicks(666), null, 4, true, true, true, true, true, true, null, 435.69m, "434", 2, 4, 1 },
                    { 34, new DateTime(2025, 2, 21, 6, 35, 44, 189, DateTimeKind.Local).AddTicks(670), null, 4, true, true, true, true, true, true, null, 230.64m, "421", 2, 2, 1 },
                    { 35, new DateTime(2025, 2, 21, 6, 35, 44, 189, DateTimeKind.Local).AddTicks(673), null, 4, true, true, true, true, true, true, null, 485.34m, "466", 2, 2, 1 },
                    { 36, new DateTime(2025, 2, 21, 6, 35, 44, 189, DateTimeKind.Local).AddTicks(676), null, 4, true, true, true, true, true, true, null, 429.55m, "431", 3, 4, 1 },
                    { 37, new DateTime(2025, 2, 21, 6, 35, 44, 189, DateTimeKind.Local).AddTicks(678), null, 4, true, true, true, true, true, true, null, 436.96m, "494", 2, 2, 1 },
                    { 38, new DateTime(2025, 2, 21, 6, 35, 44, 189, DateTimeKind.Local).AddTicks(681), null, 4, true, true, true, true, true, true, null, 360.66m, "426", 3, 4, 1 },
                    { 39, new DateTime(2025, 2, 21, 6, 35, 44, 189, DateTimeKind.Local).AddTicks(684), null, 4, true, true, true, true, true, true, null, 206.53m, "484", 1, 4, 1 },
                    { 40, new DateTime(2025, 2, 21, 6, 35, 44, 189, DateTimeKind.Local).AddTicks(686), null, 4, true, true, true, true, true, true, null, 354.51m, "468", 1, 4, 1 },
                    { 41, new DateTime(2025, 2, 21, 6, 35, 44, 189, DateTimeKind.Local).AddTicks(688), null, 4, true, true, true, true, true, true, null, 1000m, "500", 1, 5, 1 }
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
