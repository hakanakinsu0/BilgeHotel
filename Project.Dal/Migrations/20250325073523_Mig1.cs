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
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    Nationality = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdentityNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    HasBalcony = table.Column<bool>(type: "bit", nullable: false),
                    HasMinibar = table.Column<bool>(type: "bit", nullable: false),
                    HasAirConditioner = table.Column<bool>(type: "bit", nullable: false),
                    HasTV = table.Column<bool>(type: "bit", nullable: false),
                    HasHairDryer = table.Column<bool>(type: "bit", nullable: false),
                    HasWifi = table.Column<bool>(type: "bit", nullable: false),
                    RoomTypeId = table.Column<int>(type: "int", nullable: false),
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
                    ReservationStatus = table.Column<int>(type: "int", nullable: false),
                    AppUserId = table.Column<int>(type: "int", nullable: true),
                    RoomId = table.Column<int>(type: "int", nullable: false),
                    PackageId = table.Column<int>(type: "int", nullable: true),
                    EmployeeId = table.Column<int>(type: "int", nullable: true),
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
                        principalColumn: "Id");
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
                    { 1, "966db002-e8d8-4cc2-b075-4db193ad2337", "Admin", "ADMIN" },
                    { 2, "f954f68d-e6bd-443f-b745-88b327e43581", "Member", "MEMBER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ActivationCode", "ConcurrencyStamp", "CreatedDate", "DeletedDate", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "ModifiedDate", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Status", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { 1, 0, new Guid("00000000-0000-0000-0000-000000000000"), "5eb81a70-90bf-48a6-b7f5-2bb0cafbcc82", new DateTime(2025, 3, 25, 10, 35, 23, 23, DateTimeKind.Local).AddTicks(5420), null, "bilgehotel@email.com", true, false, null, null, "BILGEHOTEL@EMAIL.COM", "BILGEHOTEL", "AQAAAAIAAYagAAAAEENdf0sXW39qKHiy6squWLn+sy8ZS6l2541+89yctR87UhDa7Rm1lJQEQLqTTbv0SQ==", null, false, "5facb190-a22c-48c8-898d-ffdeb70057f0", 1, false, "bilgehotel" },
                    { 2, 0, new Guid("00000000-0000-0000-0000-000000000000"), "da0eca25-eefe-4212-9c9a-02191401441e", new DateTime(2025, 3, 25, 10, 35, 23, 62, DateTimeKind.Local).AddTicks(6770), null, "testmember@email.com", true, false, null, null, "TESTMEMBER@EMAIL.COM", "TESTMEMBER", "AQAAAAIAAYagAAAAEEWZBuexLLAU39skvOTRxVhDzL/o70asa99gXk0qEphK8CPWNHNs/lPfxLDNNmisJg==", null, false, "c23a4208-0091-4ef8-a5ee-6bdfa4bce789", 1, false, "testmember" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Address", "BirthDate", "CreatedDate", "DeletedDate", "FirstName", "HireDate", "LastName", "ModifiedDate", "PhoneNumber", "Position", "Salary", "Shift", "Status" },
                values: new object[,]
                {
                    { 1, "Gül Sokak 29, Konya, Lesotho", new DateTime(2007, 2, 12, 16, 49, 7, 707, DateTimeKind.Local).AddTicks(9313), new DateTime(2025, 3, 25, 10, 35, 22, 984, DateTimeKind.Local).AddTicks(2650), null, "Damla", new DateTime(2020, 12, 11, 3, 1, 12, 707, DateTimeKind.Local).AddTicks(8452), "Dağdaş", null, "+90-963-788-87-05", "Resepsiyonist", 51229.08m, 3, 1 },
                    { 2, "Köypınar Sokak 87c, Muş, Kazakistan", new DateTime(1980, 12, 10, 13, 59, 38, 715, DateTimeKind.Local).AddTicks(8604), new DateTime(2025, 3, 25, 10, 35, 22, 984, DateTimeKind.Local).AddTicks(2723), null, "Bekeçarslan", new DateTime(2016, 12, 15, 7, 27, 16, 372, DateTimeKind.Local).AddTicks(889), "Sepetçi", null, "+90-142-646-8-648", "Resepsiyonist", 48380.48m, 1, 1 },
                    { 3, "Saygılı Sokak 63b, Çorum, Kiribati", new DateTime(1993, 1, 12, 8, 44, 2, 628, DateTimeKind.Local).AddTicks(6243), new DateTime(2025, 3, 25, 10, 35, 22, 984, DateTimeKind.Local).AddTicks(2811), null, "Bilgetonyukuk", new DateTime(2018, 5, 23, 5, 46, 16, 240, DateTimeKind.Local).AddTicks(9487), "Öymen", null, "+90-963-822-6-487", "Resepsiyonist", 42064.87m, 2, 1 },
                    { 4, "Nalbant Sokak 15b, Bartın, Trinidad ve Tobago", new DateTime(1977, 7, 31, 1, 19, 36, 750, DateTimeKind.Local).AddTicks(3689), new DateTime(2025, 3, 25, 10, 35, 22, 984, DateTimeKind.Local).AddTicks(2894), null, "Barmaklı", new DateTime(2024, 1, 20, 10, 57, 25, 889, DateTimeKind.Local).AddTicks(7055), "Kıraç ", null, "+90-133-567-6-195", "Resepsiyonist", 46913.84m, 2, 1 },
                    { 5, "Barış Sokak 97c, Gümüşhane, Ukrayna", new DateTime(1968, 7, 17, 21, 54, 37, 492, DateTimeKind.Local).AddTicks(1327), new DateTime(2025, 3, 25, 10, 35, 22, 984, DateTimeKind.Local).AddTicks(2968), null, "Baskın", new DateTime(2018, 3, 18, 6, 40, 15, 269, DateTimeKind.Local).AddTicks(1928), "Ertürk", null, "+90-265-967-9-250", "Resepsiyonist", 45560.83m, 3, 1 },
                    { 6, "Afyon Kaya Sokak 87c, Kütahya, Arnavutluk", new DateTime(1967, 3, 26, 2, 45, 17, 135, DateTimeKind.Local).AddTicks(9839), new DateTime(2025, 3, 25, 10, 35, 22, 984, DateTimeKind.Local).AddTicks(3026), null, "Buyruk", new DateTime(2019, 8, 10, 3, 15, 16, 133, DateTimeKind.Local).AddTicks(7156), "Karaduman", null, "+90-017-944-72-81", "Resepsiyonist", 47552.96m, 3, 1 },
                    { 7, "Bahçe Sokak 24, Bitlis, Saint Helena, İngiltere", new DateTime(1988, 3, 9, 3, 15, 1, 220, DateTimeKind.Local).AddTicks(6408), new DateTime(2025, 3, 25, 10, 35, 22, 984, DateTimeKind.Local).AddTicks(3108), null, "Bağtaş", new DateTime(2016, 2, 17, 18, 10, 19, 931, DateTimeKind.Local).AddTicks(696), "Tuğlu", null, "+90-673-876-8-626", "Resepsiyonist", 53460.41m, 3, 1 },
                    { 8, "Kekeçoğlu Sokak 29b, Gümüşhane, Kırgızistan", new DateTime(1975, 8, 21, 17, 10, 48, 75, DateTimeKind.Local).AddTicks(7338), new DateTime(2025, 3, 25, 10, 35, 22, 984, DateTimeKind.Local).AddTicks(3197), null, "Dururbunsuz", new DateTime(2014, 9, 10, 6, 6, 59, 577, DateTimeKind.Local).AddTicks(8263), "Öztonga", null, "+90-899-271-8-912", "Temizlik Görevlisi", 31487.36m, 1, 1 },
                    { 9, "Saygılı Sokak 27, Hatay, Estonya", new DateTime(2003, 2, 18, 23, 56, 4, 484, DateTimeKind.Local).AddTicks(664), new DateTime(2025, 3, 25, 10, 35, 22, 984, DateTimeKind.Local).AddTicks(3289), null, "Arıboğa", new DateTime(2018, 10, 30, 10, 48, 3, 473, DateTimeKind.Local).AddTicks(3779), "Demirel", null, "+90-268-633-24-62", "Temizlik Görevlisi", 32873.18m, 2, 1 },
                    { 10, "30 Ağustos Caddesi 68b, Nevşehir, Romanya", new DateTime(2005, 3, 24, 13, 11, 28, 759, DateTimeKind.Local).AddTicks(5366), new DateTime(2025, 3, 25, 10, 35, 22, 984, DateTimeKind.Local).AddTicks(3347), null, "Al", new DateTime(2018, 11, 3, 1, 39, 21, 514, DateTimeKind.Local).AddTicks(6624), "Biçer", null, "+90-935-706-29-02", "Temizlik Görevlisi", 31760.82m, 1, 1 },
                    { 11, "Dar Sokak 66, Van, Çin", new DateTime(1981, 10, 26, 22, 32, 1, 674, DateTimeKind.Local).AddTicks(1049), new DateTime(2025, 3, 25, 10, 35, 22, 984, DateTimeKind.Local).AddTicks(3421), null, "Damla", new DateTime(2021, 2, 28, 20, 58, 4, 892, DateTimeKind.Local).AddTicks(6383), "Bolatlı", null, "+90-368-703-1-633", "Temizlik Görevlisi", 28607.95m, 2, 1 },
                    { 12, "Mevlana Sokak 86c, Aydın, Botswana", new DateTime(1986, 8, 27, 18, 3, 42, 603, DateTimeKind.Local).AddTicks(8057), new DateTime(2025, 3, 25, 10, 35, 22, 984, DateTimeKind.Local).AddTicks(3496), null, "Çemen", new DateTime(2016, 9, 27, 23, 13, 4, 879, DateTimeKind.Local).AddTicks(4715), "Topaloğlu", null, "+90-376-267-9-530", "Temizlik Görevlisi", 29160.43m, 2, 1 },
                    { 13, "Yunus Emre Sokak 85a, Trabzon, Singapur", new DateTime(1998, 10, 13, 14, 14, 10, 633, DateTimeKind.Local).AddTicks(9748), new DateTime(2025, 3, 25, 10, 35, 22, 984, DateTimeKind.Local).AddTicks(3550), null, "Barkın", new DateTime(2016, 8, 7, 17, 40, 2, 405, DateTimeKind.Local).AddTicks(5141), "Doğan ", null, "+90-475-666-92-23", "Temizlik Görevlisi", 33335.21m, 1, 1 },
                    { 14, "Fatih Sokak  82a, Samsun, Arjantin", new DateTime(2004, 1, 17, 21, 13, 36, 500, DateTimeKind.Local).AddTicks(4720), new DateTime(2025, 3, 25, 10, 35, 22, 984, DateTimeKind.Local).AddTicks(3621), null, "Alperen", new DateTime(2014, 9, 21, 12, 6, 26, 173, DateTimeKind.Local).AddTicks(7244), "Çapanoğlu", null, "+90-974-641-35-02", "Temizlik Görevlisi", 26481.22m, 2, 1 },
                    { 15, "Yunus Emre Sokak 178, Bolu, Meksika", new DateTime(1978, 8, 23, 4, 20, 23, 774, DateTimeKind.Local).AddTicks(2565), new DateTime(2025, 3, 25, 10, 35, 22, 984, DateTimeKind.Local).AddTicks(3709), null, "Büre", new DateTime(2017, 5, 12, 13, 54, 38, 96, DateTimeKind.Local).AddTicks(2206), "Aclan", null, "+90-822-612-63-13", "Temizlik Görevlisi", 28378.23m, 1, 1 },
                    { 16, "Harman Altı Sokak 44a, Amasya, Palmyra Atoll, Amerika", new DateTime(2005, 8, 8, 8, 6, 30, 407, DateTimeKind.Local).AddTicks(1225), new DateTime(2025, 3, 25, 10, 35, 22, 984, DateTimeKind.Local).AddTicks(3783), null, "Aşanboğa", new DateTime(2018, 11, 30, 13, 51, 12, 602, DateTimeKind.Local).AddTicks(9309), "Kulaksızoğlu", null, "+90-443-137-45-93", "Temizlik Görevlisi", 29914.46m, 1, 1 },
                    { 17, "Dağınık Evler Sokak 81b, Rize, Malezya", new DateTime(1970, 11, 24, 11, 57, 12, 61, DateTimeKind.Local).AddTicks(3477), new DateTime(2025, 3, 25, 10, 35, 22, 984, DateTimeKind.Local).AddTicks(3832), null, "Ardıç", new DateTime(2021, 1, 11, 9, 21, 55, 40, DateTimeKind.Local).AddTicks(2313), "Karaböcek", null, "+90-876-650-83-25", "Temizlik Görevlisi", 30630.40m, 1, 1 },
                    { 18, "İsmet Paşa Caddesi 435, Adana, Kosova", new DateTime(1996, 11, 26, 15, 20, 15, 509, DateTimeKind.Local).AddTicks(1326), new DateTime(2025, 3, 25, 10, 35, 22, 984, DateTimeKind.Local).AddTicks(3910), null, "Aykan", new DateTime(2021, 12, 8, 17, 17, 30, 697, DateTimeKind.Local).AddTicks(771), "Ekici", null, "+90-971-664-86-40", "Temizlik Görevlisi", 27118.21m, 1, 1 },
                    { 19, "Kerimoğlu Sokak 64b, İçel (Mersin), Saint Pierre ve Miquelon, Fransa", new DateTime(2000, 12, 14, 21, 43, 0, 316, DateTimeKind.Local).AddTicks(2418), new DateTime(2025, 3, 25, 10, 35, 22, 984, DateTimeKind.Local).AddTicks(3998), null, "Baykara", new DateTime(2022, 4, 15, 23, 18, 51, 28, DateTimeKind.Local).AddTicks(9108), "Çamdalı", null, "+90-459-961-81-18", "Aşçı", 103187.01m, 1, 1 },
                    { 20, "Mevlana Sokak 74c, Bilecik, Haiti", new DateTime(1996, 7, 8, 1, 29, 0, 273, DateTimeKind.Local).AddTicks(2826), new DateTime(2025, 3, 25, 10, 35, 22, 984, DateTimeKind.Local).AddTicks(4071), null, "Bolmuş", new DateTime(2017, 2, 16, 22, 28, 31, 984, DateTimeKind.Local).AddTicks(297), "Babacan", null, "+90-056-199-4-547", "Aşçı", 109207.31m, 2, 1 },
                    { 21, "İsmet Attila Caddesi 26, Bilecik, İsrail", new DateTime(1989, 12, 7, 15, 40, 39, 665, DateTimeKind.Local).AddTicks(5833), new DateTime(2025, 3, 25, 10, 35, 22, 984, DateTimeKind.Local).AddTicks(4120), null, "Boğaçuk", new DateTime(2024, 1, 15, 23, 16, 27, 187, DateTimeKind.Local).AddTicks(8474), "Süleymanoğlu", null, "+90-097-907-93-88", "Aşçı", 102456.07m, 1, 1 },
                    { 22, "Fatih Sokak  30c, Batman, Slovakya", new DateTime(1972, 3, 25, 17, 10, 31, 772, DateTimeKind.Local).AddTicks(6429), new DateTime(2025, 3, 25, 10, 35, 22, 984, DateTimeKind.Local).AddTicks(4194), null, "Erentüz", new DateTime(2015, 6, 9, 18, 32, 33, 885, DateTimeKind.Local).AddTicks(3840), "Bakırcıoğlu", null, "+90-377-075-07-31", "Aşçı", 102379.36m, 2, 1 },
                    { 23, "Ülkü Sokak 13a, Isparta, Zimbabve", new DateTime(2004, 8, 11, 0, 25, 47, 247, DateTimeKind.Local).AddTicks(5257), new DateTime(2025, 3, 25, 10, 35, 22, 984, DateTimeKind.Local).AddTicks(4266), null, "Çağatay", new DateTime(2022, 6, 28, 15, 3, 18, 269, DateTimeKind.Local).AddTicks(4940), "Karaer", null, "+90-979-397-74-66", "Aşçı", 101732.25m, 1, 1 },
                    { 24, "Sıran Söğüt Sokak 1, Manisa, Bermuda, İngiltere", new DateTime(2001, 8, 8, 20, 35, 25, 32, DateTimeKind.Local).AddTicks(4470), new DateTime(2025, 3, 25, 10, 35, 22, 984, DateTimeKind.Local).AddTicks(4343), null, "Barçan", new DateTime(2015, 7, 6, 0, 8, 24, 384, DateTimeKind.Local).AddTicks(2826), "Kuday", null, "+90-594-043-63-02", "Aşçı", 105435.90m, 1, 1 },
                    { 25, "Kaldırım Sokak 178, Şırnak, Guatemala", new DateTime(1984, 8, 24, 8, 34, 17, 44, DateTimeKind.Local).AddTicks(6854), new DateTime(2025, 3, 25, 10, 35, 22, 984, DateTimeKind.Local).AddTicks(4394), null, "Buluç", new DateTime(2020, 5, 23, 23, 12, 53, 550, DateTimeKind.Local).AddTicks(5399), "Kocabıyık", null, "+90-060-869-9-995", "Aşçı", 100319.13m, 2, 1 },
                    { 26, "Ergenekon Sokak   55b, Ankara, Brunei", new DateTime(1972, 11, 30, 17, 5, 2, 281, DateTimeKind.Local).AddTicks(3170), new DateTime(2025, 3, 25, 10, 35, 22, 984, DateTimeKind.Local).AddTicks(4473), null, "Bengi", new DateTime(2018, 8, 18, 3, 40, 8, 798, DateTimeKind.Local).AddTicks(4281), "Saygıner", null, "+90-643-065-9-504", "Aşçı", 101634.76m, 2, 1 },
                    { 27, "Ülkü Sokak 67c, Çanakkale, Svaziland", new DateTime(2001, 11, 23, 6, 3, 22, 173, DateTimeKind.Local).AddTicks(6382), new DateTime(2025, 3, 25, 10, 35, 22, 984, DateTimeKind.Local).AddTicks(4541), null, "Keklik", new DateTime(2015, 5, 27, 17, 49, 40, 146, DateTimeKind.Local).AddTicks(2369), "Akar ", null, "+90-139-701-9-554", "Aşçı", 109534.50m, 2, 1 },
                    { 28, "Barış Sokak 39, Manisa, Surinam", new DateTime(1985, 1, 25, 19, 15, 15, 134, DateTimeKind.Local).AddTicks(1213), new DateTime(2025, 3, 25, 10, 35, 22, 984, DateTimeKind.Local).AddTicks(4616), null, "Bilig", new DateTime(2018, 11, 13, 17, 31, 35, 739, DateTimeKind.Local).AddTicks(1472), "Akgül", null, "+90-840-148-14-37", "Aşçı", 103361.70m, 2, 1 },
                    { 29, "Yunus Emre Sokak 62, Van, Aruba, Hollanda", new DateTime(1991, 5, 26, 5, 27, 11, 907, DateTimeKind.Local).AddTicks(3494), new DateTime(2025, 3, 25, 10, 35, 22, 984, DateTimeKind.Local).AddTicks(4665), null, "Alpaya", new DateTime(2014, 6, 28, 1, 10, 27, 12, DateTimeKind.Local).AddTicks(7927), "Yalçın", null, "+90-016-487-4-684", "Aşçı", 105345.93m, 1, 1 },
                    { 30, "Saygılı Sokak 61a, İzmir, Filipinler", new DateTime(1967, 4, 29, 15, 29, 57, 824, DateTimeKind.Local).AddTicks(3527), new DateTime(2025, 3, 25, 10, 35, 22, 984, DateTimeKind.Local).AddTicks(4752), null, "Çağrıtegin", new DateTime(2018, 8, 24, 2, 22, 22, 485, DateTimeKind.Local).AddTicks(4418), "Karaböcek", null, "+90-920-914-8-649", "Garson", 82309.85m, 1, 1 },
                    { 31, "Nalbant Sokak 06b, Zonguldak, İrlanda", new DateTime(1982, 6, 7, 22, 47, 41, 683, DateTimeKind.Local).AddTicks(9614), new DateTime(2025, 3, 25, 10, 35, 22, 984, DateTimeKind.Local).AddTicks(4823), null, "Borlukçu", new DateTime(2016, 12, 21, 2, 47, 13, 688, DateTimeKind.Local).AddTicks(3484), "Çatalbaş", null, "+90-052-122-0-191", "Garson", 72094.50m, 2, 1 },
                    { 32, "Lütfi Karadirek Caddesi 97, Trabzon, Cibuti", new DateTime(1973, 3, 13, 2, 49, 18, 522, DateTimeKind.Local).AddTicks(1535), new DateTime(2025, 3, 25, 10, 35, 22, 984, DateTimeKind.Local).AddTicks(4872), null, "Aşanboğa", new DateTime(2019, 2, 17, 3, 43, 2, 397, DateTimeKind.Local).AddTicks(1785), "Sezek", null, "+90-271-324-24-10", "Garson", 99072.81m, 1, 1 },
                    { 33, "Bandak Sokak 24b, Rize, Saint Pierre ve Miquelon, Fransa", new DateTime(1977, 12, 8, 1, 42, 47, 786, DateTimeKind.Local).AddTicks(3363), new DateTime(2025, 3, 25, 10, 35, 22, 984, DateTimeKind.Local).AddTicks(4944), null, "Kezlik", new DateTime(2015, 4, 20, 5, 13, 47, 351, DateTimeKind.Local).AddTicks(986), "Kunter", null, "+90-910-788-86-08", "Garson", 72991.48m, 2, 1 },
                    { 34, "Alparslan Türkeş Bulvarı 23b, Aksaray, Romanya", new DateTime(2003, 3, 10, 4, 27, 48, 203, DateTimeKind.Local).AddTicks(3062), new DateTime(2025, 3, 25, 10, 35, 22, 984, DateTimeKind.Local).AddTicks(5020), null, "Bayna", new DateTime(2016, 3, 29, 21, 30, 59, 199, DateTimeKind.Local).AddTicks(1712), "Yetkiner", null, "+90-565-603-2-672", "Garson", 96075.13m, 2, 1 },
                    { 35, "30 Ağustos Caddesi 183, Kilis, Burkina Faso", new DateTime(1980, 3, 22, 4, 36, 51, 520, DateTimeKind.Local).AddTicks(792), new DateTime(2025, 3, 25, 10, 35, 22, 984, DateTimeKind.Local).AddTicks(5110), null, "Akbudak", new DateTime(2015, 12, 6, 3, 8, 49, 891, DateTimeKind.Local).AddTicks(22), "Karaböcek", null, "+90-500-065-83-08", "Garson", 97047.98m, 2, 1 },
                    { 36, "Alparslan Türkeş Bulvarı 34b, Hakkari, Marşal Adaları", new DateTime(1967, 5, 18, 23, 45, 53, 610, DateTimeKind.Local).AddTicks(7787), new DateTime(2025, 3, 25, 10, 35, 22, 984, DateTimeKind.Local).AddTicks(5159), null, "Bozbörü", new DateTime(2023, 10, 27, 14, 42, 52, 833, DateTimeKind.Local).AddTicks(6520), "Denkel", null, "+90-265-396-81-47", "Garson", 91618.59m, 1, 1 },
                    { 37, "Ali Çetinkaya Caddesi 32c, Kütahya, Azerbaycan", new DateTime(2007, 1, 5, 20, 14, 52, 974, DateTimeKind.Local).AddTicks(8013), new DateTime(2025, 3, 25, 10, 35, 22, 984, DateTimeKind.Local).AddTicks(5256), null, "Gönül", new DateTime(2020, 4, 23, 17, 34, 50, 555, DateTimeKind.Local).AddTicks(1147), "Menemencioğlu", null, "+90-762-556-2-210", "Garson", 93932.99m, 2, 1 },
                    { 38, "Kaldırım Sokak 977, Zonguldak, Umman", new DateTime(2006, 9, 26, 21, 16, 43, 597, DateTimeKind.Local).AddTicks(9945), new DateTime(2025, 3, 25, 10, 35, 22, 984, DateTimeKind.Local).AddTicks(5335), null, "Akçora", new DateTime(2016, 6, 10, 1, 40, 55, 748, DateTimeKind.Local).AddTicks(5303), "Özberk", null, "+90-440-151-89-94", "Garson", 93812.05m, 2, 1 },
                    { 39, "Tevfik Fikret Caddesi 3, Artvin, Tonga", new DateTime(1988, 3, 31, 9, 29, 54, 57, DateTimeKind.Local).AddTicks(2847), new DateTime(2025, 3, 25, 10, 35, 22, 984, DateTimeKind.Local).AddTicks(5412), null, "Bakır", new DateTime(2014, 12, 18, 14, 20, 34, 347, DateTimeKind.Local).AddTicks(3942), "Körmükçü", null, "+90-160-150-6-875", "Garson", 75967.15m, 1, 1 },
                    { 40, "Kerimoğlu Sokak 94c, Ankara, Hollanda Antilleri", new DateTime(1986, 11, 19, 3, 32, 42, 980, DateTimeKind.Local).AddTicks(8170), new DateTime(2025, 3, 25, 10, 35, 22, 984, DateTimeKind.Local).AddTicks(5461), null, "Besentegin", new DateTime(2019, 4, 19, 1, 46, 42, 835, DateTimeKind.Local).AddTicks(8214), "Başoğlu", null, "+90-943-116-48-23", "Garson", 96043.45m, 2, 1 },
                    { 41, "Ali Çetinkaya Caddesi 786, Isparta, Makedonya", new DateTime(1994, 5, 11, 16, 10, 46, 472, DateTimeKind.Local).AddTicks(5215), new DateTime(2025, 3, 25, 10, 35, 22, 984, DateTimeKind.Local).AddTicks(5541), null, "Aral", new DateTime(2023, 3, 4, 6, 5, 18, 234, DateTimeKind.Local).AddTicks(6058), "Bakırcıoğlu", null, "+90-273-869-1-131", "Garson", 90540.76m, 1, 1 },
                    { 42, "Okul Sokak 66c, Manisa, Lüksemburg", new DateTime(2003, 8, 4, 7, 51, 8, 756, DateTimeKind.Local).AddTicks(4170), new DateTime(2025, 3, 25, 10, 35, 22, 984, DateTimeKind.Local).AddTicks(5615), null, "Börübars", new DateTime(2022, 1, 25, 12, 20, 3, 115, DateTimeKind.Local).AddTicks(4061), "Velioğlu", null, "+90-283-723-03-99", "Garson", 79713.16m, 1, 1 },
                    { 43, "Dağınık Evler Sokak 6, Aydın, Samoa", new DateTime(1990, 12, 17, 7, 46, 13, 477, DateTimeKind.Local).AddTicks(6400), new DateTime(2025, 3, 25, 10, 35, 22, 984, DateTimeKind.Local).AddTicks(5691), null, "Basu", new DateTime(2022, 4, 4, 13, 35, 14, 306, DateTimeKind.Local).AddTicks(4846), "Abacı", null, "+90-435-575-9-008", "Elektrikçi", 152305.86m, 2, 1 },
                    { 44, "Fatih Sokak  43c, Giresun, Kongo", new DateTime(1980, 1, 9, 6, 42, 27, 220, DateTimeKind.Local).AddTicks(5839), new DateTime(2025, 3, 25, 10, 35, 22, 984, DateTimeKind.Local).AddTicks(5744), null, "Ağlamış", new DateTime(2020, 3, 15, 16, 34, 35, 680, DateTimeKind.Local).AddTicks(7001), "Sezek", null, "+90-172-916-7-546", "IT Sorumlusu", 174513.14m, 1, 1 }
                });

            migrationBuilder.InsertData(
                table: "ExtraServices",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Description", "ModifiedDate", "Name", "Price", "Status" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 3, 25, 10, 35, 23, 62, DateTimeKind.Local).AddTicks(7067), null, "Günlük sınırsız spa kullanımı.", null, "Spa Kullanımı", 3000m, 1 },
                    { 2, new DateTime(2025, 3, 25, 10, 35, 23, 62, DateTimeKind.Local).AddTicks(7069), null, "24 saat oda servisi. Tüm yemek siparişleri dahildir.", null, "Oda Servisi", 1500m, 1 },
                    { 3, new DateTime(2025, 3, 25, 10, 35, 23, 62, DateTimeKind.Local).AddTicks(7070), null, "Minibardaki içecekler ve atıştırmalıklar dahil.", null, "Minibar Kullanımı", 1000m, 1 },
                    { 4, new DateTime(2025, 3, 25, 10, 35, 23, 62, DateTimeKind.Local).AddTicks(7072), null, "Gidiş-dönüş özel araç transferi.", null, "Havalimanı Transferi", 5000m, 1 },
                    { 5, new DateTime(2025, 3, 25, 10, 35, 23, 62, DateTimeKind.Local).AddTicks(7073), null, "Konaklama süresince ücretsiz çamaşır ve kuru temizleme hizmeti.", null, "Çamaşırhane Hizmeti", 500m, 1 },
                    { 6, new DateTime(2025, 3, 25, 10, 35, 23, 62, DateTimeKind.Local).AddTicks(7079), null, "Ekstra günlük temizlik ve hijyen paketi.", null, "Günlük Oda Temizliği", 500m, 1 },
                    { 7, new DateTime(2025, 3, 25, 10, 35, 23, 62, DateTimeKind.Local).AddTicks(7081), null, "Özel şezlong ve plaj hizmetleri.", null, "Özel Plaj Alanı", 7500m, 1 }
                });

            migrationBuilder.InsertData(
                table: "Packages",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Description", "ModifiedDate", "Name", "PriceMultiplier", "Status" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 3, 25, 10, 35, 23, 62, DateTimeKind.Local).AddTicks(7022), null, "Kahvaltı, öğle ve akşam yemeği dahil.", null, "Tam Pansiyon", 1.2m, 1 },
                    { 2, new DateTime(2025, 3, 25, 10, 35, 23, 62, DateTimeKind.Local).AddTicks(7029), null, "Tüm yemekler, alkollü-alkolsüz içecekler ve otelin sunduğu belirli hizmetler dahil.", null, "Her Şey Dahil", 1.5m, 1 }
                });

            migrationBuilder.InsertData(
                table: "RoomTypes",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Description", "ModifiedDate", "Name", "Status" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 3, 25, 10, 35, 22, 982, DateTimeKind.Local).AddTicks(5911), null, "1 adet tek kişilik yatak. Balkon ve minibar bulunmaz. Klima, TV, saç kurutma makinesi ve WiFi mevcuttur.", null, "Tek Kişilik", 1 },
                    { 2, new DateTime(2025, 3, 25, 10, 35, 22, 982, DateTimeKind.Local).AddTicks(5921), null, "1 adet büyük (duble) yatak. Klima, TV, saç kurutma makinesi ve WiFi mevcuttur.", null, "Çift Kişilik (Duble)", 1 },
                    { 3, new DateTime(2025, 3, 25, 10, 35, 22, 982, DateTimeKind.Local).AddTicks(5923), null, "2 adet tek kişilik yatak. Klima, TV, saç kurutma makinesi ve WiFi mevcuttur.", null, "Çift Kişilik (Tek Kişilik 2 Yataklı)", 1 },
                    { 4, new DateTime(2025, 3, 25, 10, 35, 22, 982, DateTimeKind.Local).AddTicks(5924), null, "3 adet tek kişilik yatak.  Klima, TV, saç kurutma makinesi ve WiFi mevcuttur.", null, "Üç Kişilik (Tek Kişilik 3 Yataklı)", 1 },
                    { 5, new DateTime(2025, 3, 25, 10, 35, 22, 982, DateTimeKind.Local).AddTicks(5925), null, "Bir tek bir duble yatak.  Klima, TV, saç kurutma makinesi ve WiFi mevcuttur.", null, "Üç Kişilik (1 Tek, 1 Duble Yataklı)", 1 },
                    { 6, new DateTime(2025, 3, 25, 10, 35, 22, 982, DateTimeKind.Local).AddTicks(5927), null, "1 adet büyük (duble) yatak + 2 adet tek kişilik yatak. Klima, TV, saç kurutma makinesi ve WiFi mevcuttur.", null, "Dört Kişilik", 1 },
                    { 7, new DateTime(2025, 3, 25, 10, 35, 22, 982, DateTimeKind.Local).AddTicks(5928), null, "Geniş ve lüks oda. Özel oturma alanı, büyük yatak, balkon, minibar, özel banyo ve lüks hizmetler. Klima, TV, saç kurutma makinesi, WiFi ve özel hizmetler mevcuttur.", null, "Kral Dairesi", 1 }
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
                    { 1, new DateTime(2025, 3, 25, 10, 35, 22, 982, DateTimeKind.Local).AddTicks(5984), null, 1, true, false, true, false, true, true, null, 1000m, "100", 1, 1, 1 },
                    { 2, new DateTime(2025, 3, 25, 10, 35, 22, 982, DateTimeKind.Local).AddTicks(5986), null, 1, true, false, true, false, true, true, null, 1000m, "101", 1, 1, 1 },
                    { 3, new DateTime(2025, 3, 25, 10, 35, 22, 982, DateTimeKind.Local).AddTicks(5987), null, 1, true, false, true, false, true, true, null, 1000m, "102", 1, 1, 1 },
                    { 4, new DateTime(2025, 3, 25, 10, 35, 22, 982, DateTimeKind.Local).AddTicks(5988), null, 1, true, false, true, false, true, true, null, 1000m, "103", 1, 1, 1 },
                    { 5, new DateTime(2025, 3, 25, 10, 35, 22, 982, DateTimeKind.Local).AddTicks(5989), null, 1, true, false, true, false, true, true, null, 1000m, "104", 1, 1, 1 },
                    { 6, new DateTime(2025, 3, 25, 10, 35, 22, 982, DateTimeKind.Local).AddTicks(5990), null, 1, true, false, true, false, true, true, null, 1000m, "105", 1, 1, 1 },
                    { 7, new DateTime(2025, 3, 25, 10, 35, 22, 982, DateTimeKind.Local).AddTicks(5991), null, 1, true, false, true, false, true, true, null, 1000m, "106", 1, 1, 1 },
                    { 8, new DateTime(2025, 3, 25, 10, 35, 22, 982, DateTimeKind.Local).AddTicks(5992), null, 1, true, false, true, false, true, true, null, 1000m, "107", 1, 1, 1 },
                    { 9, new DateTime(2025, 3, 25, 10, 35, 22, 982, DateTimeKind.Local).AddTicks(5993), null, 1, true, false, true, false, true, true, null, 1000m, "108", 1, 1, 1 },
                    { 10, new DateTime(2025, 3, 25, 10, 35, 22, 982, DateTimeKind.Local).AddTicks(5994), null, 1, true, false, true, false, true, true, null, 1000m, "109", 1, 1, 1 },
                    { 11, new DateTime(2025, 3, 25, 10, 35, 22, 982, DateTimeKind.Local).AddTicks(5996), null, 1, true, false, true, false, true, true, null, 1500m, "110", 1, 4, 1 },
                    { 12, new DateTime(2025, 3, 25, 10, 35, 22, 982, DateTimeKind.Local).AddTicks(5997), null, 1, true, false, true, false, true, true, null, 1500m, "111", 1, 4, 1 },
                    { 13, new DateTime(2025, 3, 25, 10, 35, 22, 982, DateTimeKind.Local).AddTicks(5998), null, 1, true, false, true, false, true, true, null, 1500m, "112", 1, 4, 1 },
                    { 14, new DateTime(2025, 3, 25, 10, 35, 22, 982, DateTimeKind.Local).AddTicks(6042), null, 1, true, false, true, false, true, true, null, 1500m, "113", 1, 4, 1 },
                    { 15, new DateTime(2025, 3, 25, 10, 35, 22, 982, DateTimeKind.Local).AddTicks(6043), null, 1, true, false, true, false, true, true, null, 1500m, "114", 1, 4, 1 },
                    { 16, new DateTime(2025, 3, 25, 10, 35, 22, 982, DateTimeKind.Local).AddTicks(6044), null, 1, true, false, true, false, true, true, null, 1500m, "115", 1, 4, 1 },
                    { 17, new DateTime(2025, 3, 25, 10, 35, 22, 982, DateTimeKind.Local).AddTicks(6044), null, 1, true, false, true, false, true, true, null, 1500m, "116", 1, 4, 1 },
                    { 18, new DateTime(2025, 3, 25, 10, 35, 22, 982, DateTimeKind.Local).AddTicks(6046), null, 1, true, false, true, false, true, true, null, 1500m, "117", 1, 4, 1 },
                    { 19, new DateTime(2025, 3, 25, 10, 35, 22, 982, DateTimeKind.Local).AddTicks(6047), null, 1, true, false, true, false, true, true, null, 1500m, "118", 1, 4, 1 },
                    { 20, new DateTime(2025, 3, 25, 10, 35, 22, 982, DateTimeKind.Local).AddTicks(6048), null, 1, true, false, true, false, true, true, null, 1500m, "119", 1, 4, 1 },
                    { 21, new DateTime(2025, 3, 25, 10, 35, 22, 982, DateTimeKind.Local).AddTicks(6050), null, 2, true, false, true, false, true, true, null, 1200m, "200", 1, 1, 1 },
                    { 22, new DateTime(2025, 3, 25, 10, 35, 22, 982, DateTimeKind.Local).AddTicks(6051), null, 2, true, false, true, false, true, true, null, 1200m, "201", 1, 1, 1 },
                    { 23, new DateTime(2025, 3, 25, 10, 35, 22, 982, DateTimeKind.Local).AddTicks(6052), null, 2, true, false, true, false, true, true, null, 1200m, "202", 1, 1, 1 },
                    { 24, new DateTime(2025, 3, 25, 10, 35, 22, 982, DateTimeKind.Local).AddTicks(6052), null, 2, true, false, true, false, true, true, null, 1200m, "203", 1, 1, 1 },
                    { 25, new DateTime(2025, 3, 25, 10, 35, 22, 982, DateTimeKind.Local).AddTicks(6053), null, 2, true, false, true, false, true, true, null, 1200m, "204", 1, 1, 1 },
                    { 26, new DateTime(2025, 3, 25, 10, 35, 22, 982, DateTimeKind.Local).AddTicks(6053), null, 2, true, false, true, false, true, true, null, 1200m, "205", 1, 1, 1 },
                    { 27, new DateTime(2025, 3, 25, 10, 35, 22, 982, DateTimeKind.Local).AddTicks(6054), null, 2, true, false, true, false, true, true, null, 1200m, "206", 1, 1, 1 },
                    { 28, new DateTime(2025, 3, 25, 10, 35, 22, 982, DateTimeKind.Local).AddTicks(6054), null, 2, true, false, true, false, true, true, null, 1200m, "207", 1, 1, 1 },
                    { 29, new DateTime(2025, 3, 25, 10, 35, 22, 982, DateTimeKind.Local).AddTicks(6055), null, 2, true, false, true, false, true, true, null, 1200m, "208", 1, 1, 1 },
                    { 30, new DateTime(2025, 3, 25, 10, 35, 22, 982, DateTimeKind.Local).AddTicks(6055), null, 2, true, false, true, false, true, true, null, 1200m, "209", 1, 1, 1 },
                    { 31, new DateTime(2025, 3, 25, 10, 35, 22, 982, DateTimeKind.Local).AddTicks(6057), null, 2, true, false, true, true, true, true, null, 1800m, "210", 1, 3, 1 },
                    { 32, new DateTime(2025, 3, 25, 10, 35, 22, 982, DateTimeKind.Local).AddTicks(6058), null, 2, true, false, true, true, true, true, null, 1800m, "211", 1, 3, 1 },
                    { 33, new DateTime(2025, 3, 25, 10, 35, 22, 982, DateTimeKind.Local).AddTicks(6059), null, 2, true, false, true, true, true, true, null, 1800m, "212", 1, 3, 1 },
                    { 34, new DateTime(2025, 3, 25, 10, 35, 22, 982, DateTimeKind.Local).AddTicks(6060), null, 2, true, false, true, true, true, true, null, 1800m, "213", 1, 3, 1 },
                    { 35, new DateTime(2025, 3, 25, 10, 35, 22, 982, DateTimeKind.Local).AddTicks(6061), null, 2, true, false, true, true, true, true, null, 1800m, "214", 1, 3, 1 },
                    { 36, new DateTime(2025, 3, 25, 10, 35, 22, 982, DateTimeKind.Local).AddTicks(6061), null, 2, true, false, true, true, true, true, null, 1800m, "215", 1, 3, 1 },
                    { 37, new DateTime(2025, 3, 25, 10, 35, 22, 982, DateTimeKind.Local).AddTicks(6062), null, 2, true, false, true, true, true, true, null, 1800m, "216", 1, 3, 1 },
                    { 38, new DateTime(2025, 3, 25, 10, 35, 22, 982, DateTimeKind.Local).AddTicks(6062), null, 2, true, false, true, true, true, true, null, 1800m, "217", 1, 3, 1 },
                    { 39, new DateTime(2025, 3, 25, 10, 35, 22, 982, DateTimeKind.Local).AddTicks(6063), null, 2, true, false, true, true, true, true, null, 1800m, "218", 1, 3, 1 },
                    { 40, new DateTime(2025, 3, 25, 10, 35, 22, 982, DateTimeKind.Local).AddTicks(6063), null, 2, true, false, true, true, true, true, null, 1800m, "219", 1, 3, 1 },
                    { 41, new DateTime(2025, 3, 25, 10, 35, 22, 982, DateTimeKind.Local).AddTicks(6066), null, 3, true, true, true, true, true, true, null, 2200m, "300", 1, 2, 1 },
                    { 42, new DateTime(2025, 3, 25, 10, 35, 22, 982, DateTimeKind.Local).AddTicks(6068), null, 3, true, true, true, true, true, true, null, 2200m, "301", 1, 2, 1 },
                    { 43, new DateTime(2025, 3, 25, 10, 35, 22, 982, DateTimeKind.Local).AddTicks(6068), null, 3, true, true, true, true, true, true, null, 2200m, "302", 1, 2, 1 },
                    { 44, new DateTime(2025, 3, 25, 10, 35, 22, 982, DateTimeKind.Local).AddTicks(6069), null, 3, true, true, true, true, true, true, null, 2200m, "303", 1, 2, 1 },
                    { 45, new DateTime(2025, 3, 25, 10, 35, 22, 982, DateTimeKind.Local).AddTicks(6069), null, 3, true, true, true, true, true, true, null, 2200m, "304", 1, 2, 1 },
                    { 46, new DateTime(2025, 3, 25, 10, 35, 22, 982, DateTimeKind.Local).AddTicks(6070), null, 3, true, true, true, true, true, true, null, 2200m, "305", 1, 2, 1 },
                    { 47, new DateTime(2025, 3, 25, 10, 35, 22, 982, DateTimeKind.Local).AddTicks(6070), null, 3, true, true, true, true, true, true, null, 2200m, "306", 1, 2, 1 },
                    { 48, new DateTime(2025, 3, 25, 10, 35, 22, 982, DateTimeKind.Local).AddTicks(6071), null, 3, true, true, true, true, true, true, null, 2200m, "307", 1, 2, 1 },
                    { 49, new DateTime(2025, 3, 25, 10, 35, 22, 982, DateTimeKind.Local).AddTicks(6071), null, 3, true, true, true, true, true, true, null, 2200m, "308", 1, 2, 1 },
                    { 50, new DateTime(2025, 3, 25, 10, 35, 22, 982, DateTimeKind.Local).AddTicks(6072), null, 3, true, true, true, true, true, true, null, 2200m, "309", 1, 2, 1 },
                    { 51, new DateTime(2025, 3, 25, 10, 35, 22, 982, DateTimeKind.Local).AddTicks(6074), null, 3, true, true, true, true, true, true, null, 2500m, "310", 1, 5, 1 },
                    { 52, new DateTime(2025, 3, 25, 10, 35, 22, 982, DateTimeKind.Local).AddTicks(6075), null, 3, true, true, true, true, true, true, null, 2500m, "311", 1, 5, 1 },
                    { 53, new DateTime(2025, 3, 25, 10, 35, 22, 982, DateTimeKind.Local).AddTicks(6075), null, 3, true, true, true, true, true, true, null, 2500m, "312", 1, 5, 1 },
                    { 54, new DateTime(2025, 3, 25, 10, 35, 22, 982, DateTimeKind.Local).AddTicks(6076), null, 3, true, true, true, true, true, true, null, 2500m, "313", 1, 5, 1 },
                    { 55, new DateTime(2025, 3, 25, 10, 35, 22, 982, DateTimeKind.Local).AddTicks(6076), null, 3, true, true, true, true, true, true, null, 2500m, "314", 1, 5, 1 },
                    { 56, new DateTime(2025, 3, 25, 10, 35, 22, 982, DateTimeKind.Local).AddTicks(6077), null, 3, true, true, true, true, true, true, null, 2500m, "315", 1, 5, 1 },
                    { 57, new DateTime(2025, 3, 25, 10, 35, 22, 982, DateTimeKind.Local).AddTicks(6077), null, 3, true, true, true, true, true, true, null, 2500m, "316", 1, 5, 1 },
                    { 58, new DateTime(2025, 3, 25, 10, 35, 22, 982, DateTimeKind.Local).AddTicks(6078), null, 3, true, true, true, true, true, true, null, 2500m, "317", 1, 5, 1 },
                    { 59, new DateTime(2025, 3, 25, 10, 35, 22, 982, DateTimeKind.Local).AddTicks(6078), null, 3, true, true, true, true, true, true, null, 2500m, "318", 1, 5, 1 },
                    { 60, new DateTime(2025, 3, 25, 10, 35, 22, 982, DateTimeKind.Local).AddTicks(6079), null, 3, true, true, true, true, true, true, null, 2500m, "319", 1, 5, 1 },
                    { 61, new DateTime(2025, 3, 25, 10, 35, 22, 982, DateTimeKind.Local).AddTicks(6081), null, 4, true, true, true, true, true, true, null, 2800m, "400", 1, 2, 1 },
                    { 62, new DateTime(2025, 3, 25, 10, 35, 22, 982, DateTimeKind.Local).AddTicks(6082), null, 4, true, true, true, true, true, true, null, 2800m, "401", 1, 2, 1 },
                    { 63, new DateTime(2025, 3, 25, 10, 35, 22, 982, DateTimeKind.Local).AddTicks(6082), null, 4, true, true, true, true, true, true, null, 2800m, "402", 1, 2, 1 },
                    { 64, new DateTime(2025, 3, 25, 10, 35, 22, 982, DateTimeKind.Local).AddTicks(6083), null, 4, true, true, true, true, true, true, null, 2800m, "403", 1, 2, 1 },
                    { 65, new DateTime(2025, 3, 25, 10, 35, 22, 982, DateTimeKind.Local).AddTicks(6101), null, 4, true, true, true, true, true, true, null, 2800m, "404", 1, 2, 1 },
                    { 66, new DateTime(2025, 3, 25, 10, 35, 22, 982, DateTimeKind.Local).AddTicks(6102), null, 4, true, true, true, true, true, true, null, 2800m, "405", 1, 2, 1 },
                    { 67, new DateTime(2025, 3, 25, 10, 35, 22, 982, DateTimeKind.Local).AddTicks(6103), null, 4, true, true, true, true, true, true, null, 2800m, "406", 1, 2, 1 },
                    { 68, new DateTime(2025, 3, 25, 10, 35, 22, 982, DateTimeKind.Local).AddTicks(6104), null, 4, true, true, true, true, true, true, null, 2800m, "407", 1, 2, 1 },
                    { 69, new DateTime(2025, 3, 25, 10, 35, 22, 982, DateTimeKind.Local).AddTicks(6104), null, 4, true, true, true, true, true, true, null, 2800m, "408", 1, 2, 1 },
                    { 70, new DateTime(2025, 3, 25, 10, 35, 22, 982, DateTimeKind.Local).AddTicks(6105), null, 4, true, true, true, true, true, true, null, 2800m, "409", 1, 2, 1 },
                    { 71, new DateTime(2025, 3, 25, 10, 35, 22, 982, DateTimeKind.Local).AddTicks(6107), null, 4, true, true, true, true, true, true, null, 3500m, "410", 1, 6, 1 },
                    { 72, new DateTime(2025, 3, 25, 10, 35, 22, 982, DateTimeKind.Local).AddTicks(6108), null, 4, true, true, true, true, true, true, null, 3500m, "411", 1, 6, 1 },
                    { 73, new DateTime(2025, 3, 25, 10, 35, 22, 982, DateTimeKind.Local).AddTicks(6109), null, 4, true, true, true, true, true, true, null, 3500m, "412", 1, 6, 1 },
                    { 74, new DateTime(2025, 3, 25, 10, 35, 22, 982, DateTimeKind.Local).AddTicks(6109), null, 4, true, true, true, true, true, true, null, 3500m, "413", 1, 6, 1 },
                    { 75, new DateTime(2025, 3, 25, 10, 35, 22, 982, DateTimeKind.Local).AddTicks(6110), null, 4, true, true, true, true, true, true, null, 3500m, "414", 1, 6, 1 },
                    { 76, new DateTime(2025, 3, 25, 10, 35, 22, 982, DateTimeKind.Local).AddTicks(6110), null, 4, true, true, true, true, true, true, null, 3500m, "415", 1, 6, 1 },
                    { 77, new DateTime(2025, 3, 25, 10, 35, 22, 982, DateTimeKind.Local).AddTicks(6112), null, 4, true, true, true, true, true, true, null, 10000m, "417", 1, 7, 1 }
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
