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
                    { 1, "0bc4a2f9-fb20-4393-a764-f533b682bbc3", "Admin", "ADMIN" },
                    { 2, "cbcbd084-6bd1-498b-a7e2-f02886b1c401", "Member", "MEMBER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ActivationCode", "ConcurrencyStamp", "CreatedDate", "DeletedDate", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "ModifiedDate", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Status", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { 1, 0, new Guid("00000000-0000-0000-0000-000000000000"), "b62637cd-8f51-4c0e-9a75-5a2ff1287ae2", new DateTime(2025, 4, 10, 17, 20, 50, 321, DateTimeKind.Local).AddTicks(5600), null, "bilgehotel@email.com", true, false, null, null, "BILGEHOTEL@EMAIL.COM", "BILGEHOTEL", "AQAAAAIAAYagAAAAEGuGCXlPNb11gIAoaNUf6HYGUvg3K2ZMVGei18xKjyzhW+ZtdJ/Ah7lVWqSxW/mElg==", null, false, "06b544a1-c0e3-40c2-8abb-52a1cc8b92af", 1, false, "bilgehotel" },
                    { 2, 0, new Guid("00000000-0000-0000-0000-000000000000"), "1a55a6be-3d16-403a-a831-2accd159e0b9", new DateTime(2025, 4, 10, 17, 20, 50, 359, DateTimeKind.Local).AddTicks(6274), null, "testmember@email.com", true, false, null, null, "TESTMEMBER@EMAIL.COM", "TESTMEMBER", "AQAAAAIAAYagAAAAEAUhwC3KYYmzauUoK1DDXANN6ejO6GySprmpJg0VKg0vxhLNYyc9kwc6BSYEhYbLug==", null, false, "362ffd2d-523f-4c77-9c70-9e2245cbd5ac", 1, false, "testmember" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Address", "BirthDate", "CreatedDate", "DeletedDate", "FirstName", "HireDate", "LastName", "ModifiedDate", "PhoneNumber", "Position", "Salary", "Shift", "Status" },
                values: new object[,]
                {
                    { 1, "İbn-i Sina Sokak 37, Şanlıurfa, Gana", new DateTime(1992, 9, 25, 8, 1, 8, 389, DateTimeKind.Local).AddTicks(8104), new DateTime(2025, 4, 10, 17, 20, 50, 282, DateTimeKind.Local).AddTicks(7130), null, "Buyruk", new DateTime(2024, 2, 2, 23, 21, 22, 461, DateTimeKind.Local).AddTicks(4478), "Önür", null, "+905607713907", "Resepsiyonist", 50645.03m, 3, 1 },
                    { 2, "Harman Yolu Sokak  22, Elazığ, Kosova", new DateTime(1987, 12, 20, 6, 35, 28, 146, DateTimeKind.Local).AddTicks(2001), new DateTime(2025, 4, 10, 17, 20, 50, 282, DateTimeKind.Local).AddTicks(7227), null, "Aral", new DateTime(2014, 9, 23, 22, 20, 38, 532, DateTimeKind.Local).AddTicks(5645), "Akaydın", null, "+905885081452", "Resepsiyonist", 52958.46m, 3, 1 },
                    { 3, "Kocatepe Caddesi 06a, Erzincan, Meksika", new DateTime(1974, 10, 30, 23, 17, 35, 452, DateTimeKind.Local).AddTicks(5351), new DateTime(2025, 4, 10, 17, 20, 50, 282, DateTimeKind.Local).AddTicks(7292), null, "Ebin", new DateTime(2022, 11, 3, 0, 38, 51, 20, DateTimeKind.Local).AddTicks(2532), "Aybar", null, "+905224644912", "Resepsiyonist", 49891.36m, 3, 1 },
                    { 4, "Saygılı Sokak 23b, Sinop, Marşal Adaları", new DateTime(1992, 11, 6, 11, 40, 50, 737, DateTimeKind.Local).AddTicks(6666), new DateTime(2025, 4, 10, 17, 20, 50, 282, DateTimeKind.Local).AddTicks(7366), null, "Aral", new DateTime(2023, 12, 21, 12, 59, 46, 763, DateTimeKind.Local).AddTicks(105), "Çapanoğlu", null, "+905184352083", "Resepsiyonist", 55164.61m, 2, 1 },
                    { 5, "Dağınık Evler Sokak 56b, Yalova, Yunanistan", new DateTime(1980, 8, 19, 5, 24, 14, 95, DateTimeKind.Local).AddTicks(7649), new DateTime(2025, 4, 10, 17, 20, 50, 282, DateTimeKind.Local).AddTicks(7476), null, "Belgi", new DateTime(2021, 4, 25, 5, 14, 30, 30, DateTimeKind.Local).AddTicks(4682), "Akar ", null, "+905382584883", "Resepsiyonist", 46179.85m, 2, 1 },
                    { 6, "Yunus Emre Sokak 43c, Antalya, Küba", new DateTime(1978, 7, 29, 5, 17, 46, 148, DateTimeKind.Local).AddTicks(9321), new DateTime(2025, 4, 10, 17, 20, 50, 282, DateTimeKind.Local).AddTicks(7528), null, "Bügdüzemen", new DateTime(2020, 10, 30, 7, 49, 0, 726, DateTimeKind.Local).AddTicks(9078), "Karabulut", null, "+905368136206", "Resepsiyonist", 56247.49m, 2, 1 },
                    { 7, "Mevlana Sokak 3, Ankara, Birleşik Arap Emirlikleri", new DateTime(1970, 4, 17, 10, 42, 11, 213, DateTimeKind.Local).AddTicks(5502), new DateTime(2025, 4, 10, 17, 20, 50, 282, DateTimeKind.Local).AddTicks(7619), null, "Ayluç", new DateTime(2019, 7, 28, 22, 4, 19, 209, DateTimeKind.Local).AddTicks(8639), "Doğan ", null, "+905699303689", "Resepsiyonist", 58806.74m, 1, 1 },
                    { 8, "Saygılı Sokak 201, Balıkesir, Midway Adaları, Amerika", new DateTime(2003, 10, 31, 9, 46, 22, 779, DateTimeKind.Local).AddTicks(931), new DateTime(2025, 4, 10, 17, 20, 50, 282, DateTimeKind.Local).AddTicks(7703), null, "Kekik", new DateTime(2021, 9, 15, 8, 9, 45, 724, DateTimeKind.Local).AddTicks(680), "Uluhan", null, "+905716125270", "Temizlik Görevlisi", 27490.11m, 1, 1 },
                    { 9, "Ülkü Sokak 80a, Kütahya, Küba", new DateTime(1982, 3, 23, 22, 46, 28, 3, DateTimeKind.Local).AddTicks(2393), new DateTime(2025, 4, 10, 17, 20, 50, 282, DateTimeKind.Local).AddTicks(7749), null, "Baran", new DateTime(2017, 4, 28, 12, 13, 10, 562, DateTimeKind.Local).AddTicks(1275), "Ozansoy", null, "+905535553710", "Temizlik Görevlisi", 32510.90m, 1, 1 },
                    { 10, "Okul Sokak 98a, Tunceli, Hindistan", new DateTime(1992, 11, 25, 7, 32, 6, 907, DateTimeKind.Local).AddTicks(5907), new DateTime(2025, 4, 10, 17, 20, 50, 282, DateTimeKind.Local).AddTicks(7818), null, "Keklik", new DateTime(2016, 1, 3, 9, 39, 37, 490, DateTimeKind.Local).AddTicks(1605), "Keçeci", null, "+905184160341", "Temizlik Görevlisi", 31853.63m, 2, 1 },
                    { 11, "Kocatepe Caddesi 71a, Elazığ, Kuzey Kore", new DateTime(1978, 5, 19, 7, 47, 57, 234, DateTimeKind.Local).AddTicks(805), new DateTime(2025, 4, 10, 17, 20, 50, 282, DateTimeKind.Local).AddTicks(7892), null, "Arçuk", new DateTime(2014, 12, 28, 4, 34, 45, 198, DateTimeKind.Local).AddTicks(9796), "Öztonga", null, "+905120523905", "Temizlik Görevlisi", 26451.37m, 2, 1 },
                    { 12, "Lütfi Karadirek Caddesi 81c, Bitlis, Dominika", new DateTime(2000, 3, 9, 15, 27, 57, 850, DateTimeKind.Local).AddTicks(1890), new DateTime(2025, 4, 10, 17, 20, 50, 282, DateTimeKind.Local).AddTicks(7939), null, "Boncuk", new DateTime(2018, 10, 31, 17, 58, 7, 521, DateTimeKind.Local).AddTicks(7181), "Kıraç ", null, "+905439443246", "Temizlik Görevlisi", 30966.87m, 2, 1 },
                    { 13, "Güven Yaka Sokak 82b, Elazığ, Jamaika", new DateTime(1977, 4, 17, 4, 41, 31, 891, DateTimeKind.Local).AddTicks(7626), new DateTime(2025, 4, 10, 17, 20, 50, 282, DateTimeKind.Local).AddTicks(8013), null, "Algu", new DateTime(2021, 9, 27, 21, 17, 2, 502, DateTimeKind.Local).AddTicks(6653), "Sözeri", null, "+905903024363", "Temizlik Görevlisi", 30842.05m, 2, 1 },
                    { 14, "Bayır Sokak 66a, Bilecik, Türkmenistan", new DateTime(1984, 6, 24, 23, 45, 48, 114, DateTimeKind.Local).AddTicks(9589), new DateTime(2025, 4, 10, 17, 20, 50, 282, DateTimeKind.Local).AddTicks(8064), null, "Kayacık", new DateTime(2017, 10, 26, 10, 16, 26, 573, DateTimeKind.Local).AddTicks(6903), "Akbulut", null, "+905976502728", "Temizlik Görevlisi", 33398.27m, 2, 1 },
                    { 15, "Ali Çetinkaya Caddesi 5, Van, Komorlar", new DateTime(1970, 7, 26, 22, 9, 34, 231, DateTimeKind.Local).AddTicks(7756), new DateTime(2025, 4, 10, 17, 20, 50, 282, DateTimeKind.Local).AddTicks(8135), null, "Gündoğdu", new DateTime(2018, 4, 28, 21, 33, 14, 232, DateTimeKind.Local).AddTicks(1428), "Akman", null, "+905991349357", "Temizlik Görevlisi", 25950.46m, 2, 1 },
                    { 16, "Kaldırım Sokak 07a, Gümüşhane, Kuzey İrlanda", new DateTime(1988, 6, 8, 22, 52, 49, 895, DateTimeKind.Local).AddTicks(7974), new DateTime(2025, 4, 10, 17, 20, 50, 282, DateTimeKind.Local).AddTicks(8207), null, "Güvercin", new DateTime(2019, 5, 15, 9, 25, 32, 127, DateTimeKind.Local).AddTicks(7184), "Berberoğlu", null, "+905386886993", "Temizlik Görevlisi", 28789.82m, 2, 1 },
                    { 17, "Bahçe Sokak 09c, Konya, Samoa", new DateTime(1992, 10, 5, 21, 30, 22, 431, DateTimeKind.Local).AddTicks(1589), new DateTime(2025, 4, 10, 17, 20, 50, 282, DateTimeKind.Local).AddTicks(8251), null, "Bora", new DateTime(2016, 5, 29, 23, 53, 34, 437, DateTimeKind.Local).AddTicks(6251), "Durak ", null, "+905798579198", "Temizlik Görevlisi", 29018.44m, 2, 1 },
                    { 18, "Afyon Kaya Sokak 5, Batman, Santa Lucia", new DateTime(1980, 5, 10, 11, 52, 42, 814, DateTimeKind.Local).AddTicks(556), new DateTime(2025, 4, 10, 17, 20, 50, 282, DateTimeKind.Local).AddTicks(8348), null, "Baksı", new DateTime(2023, 9, 20, 16, 2, 52, 231, DateTimeKind.Local).AddTicks(1422), "Köylüoğlu", null, "+905131101081", "Temizlik Görevlisi", 33562.31m, 1, 1 },
                    { 19, "İbn-i Sina Sokak 00a, Amasya, Nijer", new DateTime(1975, 9, 17, 5, 22, 56, 268, DateTimeKind.Local).AddTicks(615), new DateTime(2025, 4, 10, 17, 20, 50, 282, DateTimeKind.Local).AddTicks(8428), null, "Ekin", new DateTime(2019, 12, 6, 0, 49, 31, 714, DateTimeKind.Local).AddTicks(1491), "Koç", null, "+905066026999", "Aşçı", 100592.77m, 1, 1 },
                    { 20, "Yunus Emre Sokak 87b, Batman, Aruba, Hollanda", new DateTime(1996, 2, 17, 9, 26, 30, 12, DateTimeKind.Local).AddTicks(1474), new DateTime(2025, 4, 10, 17, 20, 50, 282, DateTimeKind.Local).AddTicks(8469), null, "Aştaloğul", new DateTime(2022, 9, 25, 23, 5, 25, 972, DateTimeKind.Local).AddTicks(8363), "Akgül", null, "+905317645959", "Aşçı", 118216.31m, 1, 1 },
                    { 21, "Ali Çetinkaya Caddesi 48c, Karaman, Güney Kore", new DateTime(1981, 9, 30, 8, 48, 34, 829, DateTimeKind.Local).AddTicks(3883), new DateTime(2025, 4, 10, 17, 20, 50, 282, DateTimeKind.Local).AddTicks(8545), null, "Bozbörü", new DateTime(2021, 5, 24, 22, 32, 51, 857, DateTimeKind.Local).AddTicks(2733), "Oraloğlu", null, "+905548091890", "Aşçı", 101771.98m, 2, 1 },
                    { 22, "Sıran Söğüt Sokak 68a, Artvin, Lesotho", new DateTime(1967, 12, 20, 1, 16, 23, 291, DateTimeKind.Local).AddTicks(1918), new DateTime(2025, 4, 10, 17, 20, 50, 282, DateTimeKind.Local).AddTicks(8613), null, "Bügdüzemen", new DateTime(2020, 8, 13, 21, 56, 7, 203, DateTimeKind.Local).AddTicks(8108), "Oraloğlu", null, "+905409189285", "Aşçı", 112429.42m, 1, 1 },
                    { 23, "Kerimoğlu Sokak 6, Çorum, Makedonya", new DateTime(1993, 3, 4, 14, 24, 27, 758, DateTimeKind.Local).AddTicks(6821), new DateTime(2025, 4, 10, 17, 20, 50, 282, DateTimeKind.Local).AddTicks(8658), null, "Altay", new DateTime(2022, 8, 30, 0, 27, 35, 29, DateTimeKind.Local).AddTicks(1224), "Özberk", null, "+905345873687", "Aşçı", 113368.59m, 2, 1 },
                    { 24, "Sevgi Sokak 84c, Adıyaman, Samoa", new DateTime(1995, 6, 18, 19, 58, 59, 871, DateTimeKind.Local).AddTicks(2684), new DateTime(2025, 4, 10, 17, 20, 50, 282, DateTimeKind.Local).AddTicks(8725), null, "Altınkağan", new DateTime(2023, 3, 19, 0, 25, 17, 756, DateTimeKind.Local).AddTicks(5457), "Adan", null, "+905611614413", "Aşçı", 115928.91m, 1, 1 },
                    { 25, "Mevlana Sokak 106, Osmaniye, Lübnan", new DateTime(1970, 11, 28, 19, 36, 15, 866, DateTimeKind.Local).AddTicks(1853), new DateTime(2025, 4, 10, 17, 20, 50, 282, DateTimeKind.Local).AddTicks(8796), null, "Adraman", new DateTime(2018, 9, 4, 18, 3, 53, 274, DateTimeKind.Local).AddTicks(1721), "Topaloğlu", null, "+905623680595", "Aşçı", 104814.92m, 1, 1 },
                    { 26, "Sevgi Sokak 40, Çankırı, Nauru", new DateTime(1998, 12, 2, 4, 38, 6, 72, DateTimeKind.Local).AddTicks(6401), new DateTime(2025, 4, 10, 17, 20, 50, 282, DateTimeKind.Local).AddTicks(8840), null, "Bürküt", new DateTime(2015, 2, 28, 13, 46, 11, 605, DateTimeKind.Local).AddTicks(2259), "Akan", null, "+905071921599", "Aşçı", 101965.80m, 1, 1 },
                    { 27, "Sağlık Sokak 29b, Çanakkale, Liberya", new DateTime(1985, 1, 28, 21, 50, 43, 927, DateTimeKind.Local).AddTicks(6457), new DateTime(2025, 4, 10, 17, 20, 50, 282, DateTimeKind.Local).AddTicks(8910), null, "Balaban", new DateTime(2014, 5, 12, 3, 18, 15, 170, DateTimeKind.Local).AddTicks(1097), "Öymen", null, "+905277235698", "Aşçı", 111189.22m, 2, 1 },
                    { 28, "Lütfi Karadirek Caddesi 82a, Kastamonu, Saint Pierre ve Miquelon, Fransa", new DateTime(1973, 6, 19, 20, 9, 54, 740, DateTimeKind.Local).AddTicks(1164), new DateTime(2025, 4, 10, 17, 20, 50, 282, DateTimeKind.Local).AddTicks(8955), null, "Barça", new DateTime(2019, 11, 14, 17, 36, 17, 612, DateTimeKind.Local).AddTicks(4101), "Türkdoğan", null, "+905600519229", "Aşçı", 102981.57m, 2, 1 },
                    { 29, "Sarıkaya Caddesi 00c, Çorum, Uruguay", new DateTime(2006, 3, 31, 5, 22, 45, 752, DateTimeKind.Local).AddTicks(9012), new DateTime(2025, 4, 10, 17, 20, 50, 282, DateTimeKind.Local).AddTicks(9015), null, "Artukaç", new DateTime(2015, 5, 10, 8, 5, 47, 865, DateTimeKind.Local).AddTicks(7865), "Türkyılmaz", null, "+905143212701", "Aşçı", 116338.64m, 1, 1 },
                    { 30, "İsmet Paşa Caddesi 60a, Sinop, Marşal Adaları", new DateTime(1998, 7, 19, 5, 26, 5, 311, DateTimeKind.Local).AddTicks(3452), new DateTime(2025, 4, 10, 17, 20, 50, 282, DateTimeKind.Local).AddTicks(9089), null, "Kımızın", new DateTime(2014, 5, 4, 22, 54, 57, 685, DateTimeKind.Local).AddTicks(1884), "Özkök ", null, "+905154414614", "Garson", 75547.56m, 1, 1 },
                    { 31, "Bayır Sokak 96c, Denizli, İspanya", new DateTime(1991, 5, 23, 19, 5, 22, 647, DateTimeKind.Local).AddTicks(4136), new DateTime(2025, 4, 10, 17, 20, 50, 282, DateTimeKind.Local).AddTicks(9133), null, "Balçar", new DateTime(2017, 11, 29, 15, 44, 51, 472, DateTimeKind.Local).AddTicks(3089), "Kaya ", null, "+905254858397", "Garson", 88813.30m, 1, 1 },
                    { 32, "Ergenekon Sokak   55b, Malatya, Estonya", new DateTime(1988, 8, 5, 23, 21, 23, 890, DateTimeKind.Local).AddTicks(8932), new DateTime(2025, 4, 10, 17, 20, 50, 282, DateTimeKind.Local).AddTicks(9218), null, "Basut", new DateTime(2014, 10, 15, 16, 9, 50, 359, DateTimeKind.Local).AddTicks(6090), "Evliyaoğlu", null, "+905919236898", "Garson", 73299.09m, 2, 1 },
                    { 33, "İbn-i Sina Sokak 687, Karabük, Çek Cumhuriyeti", new DateTime(1999, 1, 2, 8, 24, 39, 287, DateTimeKind.Local).AddTicks(8559), new DateTime(2025, 4, 10, 17, 20, 50, 282, DateTimeKind.Local).AddTicks(9286), null, "Bağatur", new DateTime(2017, 4, 23, 0, 55, 47, 728, DateTimeKind.Local).AddTicks(5349), "Tuğluk", null, "+905993280353", "Garson", 93688.15m, 2, 1 },
                    { 34, "Yunus Emre Sokak 54a, Ankara, Nijer", new DateTime(1999, 3, 8, 4, 37, 7, 318, DateTimeKind.Local).AddTicks(7908), new DateTime(2025, 4, 10, 17, 20, 50, 282, DateTimeKind.Local).AddTicks(9327), null, "Kaynak", new DateTime(2020, 5, 10, 14, 22, 31, 525, DateTimeKind.Local).AddTicks(1089), "Gümüşpala", null, "+905434786039", "Garson", 78297.55m, 1, 1 },
                    { 35, "Bahçe Sokak 32c, Hakkari, Tacikistan", new DateTime(1972, 3, 20, 17, 14, 27, 365, DateTimeKind.Local).AddTicks(2458), new DateTime(2025, 4, 10, 17, 20, 50, 282, DateTimeKind.Local).AddTicks(9393), null, "Işılay", new DateTime(2021, 3, 16, 23, 55, 43, 621, DateTimeKind.Local).AddTicks(9643), "Pektemek", null, "+905215359711", "Garson", 78098.91m, 1, 1 },
                    { 36, "Gül Sokak 0, Bitlis, Nikaragua", new DateTime(1996, 7, 11, 11, 15, 59, 403, DateTimeKind.Local).AddTicks(4486), new DateTime(2025, 4, 10, 17, 20, 50, 282, DateTimeKind.Local).AddTicks(9456), null, "Aral", new DateTime(2022, 3, 14, 12, 51, 27, 872, DateTimeKind.Local).AddTicks(6708), "Denkel", null, "+905210523511", "Garson", 83459.32m, 2, 1 },
                    { 37, "Mevlana Sokak 281, Gümüşhane, Almanya", new DateTime(1993, 12, 10, 17, 5, 55, 532, DateTimeKind.Local).AddTicks(6103), new DateTime(2025, 4, 10, 17, 20, 50, 282, DateTimeKind.Local).AddTicks(9504), null, "Alpış", new DateTime(2015, 4, 15, 0, 0, 4, 750, DateTimeKind.Local).AddTicks(8430), "Ekşioğlu", null, "+905224356303", "Garson", 78612.45m, 2, 1 },
                    { 38, "Harman Yolu Sokak  6, Antalya, Lesotho", new DateTime(1972, 11, 17, 18, 12, 4, 153, DateTimeKind.Local).AddTicks(6126), new DateTime(2025, 4, 10, 17, 20, 50, 282, DateTimeKind.Local).AddTicks(9567), null, "Gökçe", new DateTime(2021, 5, 11, 12, 7, 57, 778, DateTimeKind.Local).AddTicks(5667), "Ertepınar", null, "+905654409374", "Garson", 78777.00m, 2, 1 },
                    { 39, "Bahçe Sokak 53a, Tokat, Somali", new DateTime(1975, 8, 15, 19, 43, 21, 218, DateTimeKind.Local).AddTicks(5257), new DateTime(2025, 4, 10, 17, 20, 50, 282, DateTimeKind.Local).AddTicks(9634), null, "Artuk", new DateTime(2019, 3, 2, 12, 10, 25, 128, DateTimeKind.Local).AddTicks(834), "Yazıcı", null, "+905980047912", "Garson", 79848.07m, 1, 1 },
                    { 40, "Dar Sokak 0, Hatay, Malezya", new DateTime(1994, 10, 17, 11, 4, 25, 85, DateTimeKind.Local).AddTicks(9439), new DateTime(2025, 4, 10, 17, 20, 50, 282, DateTimeKind.Local).AddTicks(9677), null, "Abluç", new DateTime(2015, 6, 14, 16, 12, 32, 507, DateTimeKind.Local).AddTicks(2968), "Saygıner", null, "+905708388794", "Garson", 82671.52m, 2, 1 },
                    { 41, "Kocatepe Caddesi 02, İstanbul, Güney Kore", new DateTime(1978, 2, 6, 2, 15, 10, 569, DateTimeKind.Local).AddTicks(5834), new DateTime(2025, 4, 10, 17, 20, 50, 282, DateTimeKind.Local).AddTicks(9735), null, "Buzaçtutuk", new DateTime(2016, 4, 4, 7, 17, 10, 947, DateTimeKind.Local).AddTicks(3583), "Koyuncu", null, "+905489776192", "Garson", 97901.69m, 2, 1 },
                    { 42, "Saygılı Sokak 43b, Şanlıurfa, Yemen", new DateTime(1991, 10, 20, 21, 24, 42, 540, DateTimeKind.Local).AddTicks(4112), new DateTime(2025, 4, 10, 17, 20, 50, 282, DateTimeKind.Local).AddTicks(9808), null, "Arnaç", new DateTime(2016, 7, 20, 3, 18, 24, 929, DateTimeKind.Local).AddTicks(2056), "Akay", null, "+905786621589", "Garson", 88994.59m, 2, 1 },
                    { 43, "Gül Sokak 97c, Kırıkkale, Lesotho", new DateTime(1986, 2, 23, 4, 19, 15, 161, DateTimeKind.Local).AddTicks(802), new DateTime(2025, 4, 10, 17, 20, 50, 282, DateTimeKind.Local).AddTicks(9858), null, "Arıboğa", new DateTime(2020, 3, 21, 0, 9, 50, 705, DateTimeKind.Local).AddTicks(5279), "Elmastaşoğlu", null, "+905865355699", "Elektrikçi", 162643.87m, 2, 1 },
                    { 44, "Mevlana Sokak 01, Aydın, Niue, Yeni Zelanda", new DateTime(1990, 1, 3, 0, 12, 11, 689, DateTimeKind.Local).AddTicks(5428), new DateTime(2025, 4, 10, 17, 20, 50, 282, DateTimeKind.Local).AddTicks(9937), null, "Akbudak", new DateTime(2020, 12, 6, 23, 53, 34, 558, DateTimeKind.Local).AddTicks(2584), "Kurutluoğlu", null, "+905837851307", "IT Sorumlusu", 184476.00m, 2, 1 }
                });

            migrationBuilder.InsertData(
                table: "ExtraServices",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Description", "ModifiedDate", "Name", "Price", "Status" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 4, 10, 17, 20, 50, 359, DateTimeKind.Local).AddTicks(6585), null, "Günlük sınırsız spa kullanımı.", null, "Spa Kullanımı", 3000m, 1 },
                    { 2, new DateTime(2025, 4, 10, 17, 20, 50, 359, DateTimeKind.Local).AddTicks(6588), null, "24 saat oda servisi. Tüm yemek siparişleri dahildir.", null, "Oda Servisi", 1500m, 1 },
                    { 3, new DateTime(2025, 4, 10, 17, 20, 50, 359, DateTimeKind.Local).AddTicks(6589), null, "Minibardaki içecekler ve atıştırmalıklar dahil.", null, "Minibar Kullanımı", 1000m, 1 },
                    { 4, new DateTime(2025, 4, 10, 17, 20, 50, 359, DateTimeKind.Local).AddTicks(6590), null, "Gidiş-dönüş özel araç transferi.", null, "Havalimanı Transferi", 5000m, 1 },
                    { 5, new DateTime(2025, 4, 10, 17, 20, 50, 359, DateTimeKind.Local).AddTicks(6591), null, "Konaklama süresince ücretsiz çamaşır ve kuru temizleme hizmeti.", null, "Çamaşırhane Hizmeti", 500m, 1 },
                    { 6, new DateTime(2025, 4, 10, 17, 20, 50, 359, DateTimeKind.Local).AddTicks(6683), null, "Ekstra günlük temizlik ve hijyen paketi.", null, "Günlük Oda Temizliği", 500m, 1 },
                    { 7, new DateTime(2025, 4, 10, 17, 20, 50, 359, DateTimeKind.Local).AddTicks(6685), null, "Özel şezlong ve plaj hizmetleri.", null, "Özel Plaj Alanı", 7500m, 1 }
                });

            migrationBuilder.InsertData(
                table: "Packages",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Description", "ModifiedDate", "Name", "PriceMultiplier", "Status" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 4, 10, 17, 20, 50, 359, DateTimeKind.Local).AddTicks(6539), null, "Kahvaltı, öğle ve akşam yemeği dahil.", null, "Tam Pansiyon", 1.2m, 1 },
                    { 2, new DateTime(2025, 4, 10, 17, 20, 50, 359, DateTimeKind.Local).AddTicks(6543), null, "Tüm yemekler, alkollü-alkolsüz içecekler ve otelin sunduğu belirli hizmetler dahil.", null, "Her Şey Dahil", 1.5m, 1 }
                });

            migrationBuilder.InsertData(
                table: "RoomTypes",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Description", "ModifiedDate", "Name", "Status" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 4, 10, 17, 20, 50, 281, DateTimeKind.Local).AddTicks(10), null, "1 adet tek kişilik yatak. Balkon ve minibar bulunmaz. Klima, TV, saç kurutma makinesi ve WiFi mevcuttur.", null, "Tek Kişilik", 1 },
                    { 2, new DateTime(2025, 4, 10, 17, 20, 50, 281, DateTimeKind.Local).AddTicks(21), null, "1 adet büyük (duble) yatak. Klima, TV, saç kurutma makinesi ve WiFi mevcuttur.", null, "Çift Kişilik (Duble)", 1 },
                    { 3, new DateTime(2025, 4, 10, 17, 20, 50, 281, DateTimeKind.Local).AddTicks(22), null, "2 adet tek kişilik yatak. Klima, TV, saç kurutma makinesi ve WiFi mevcuttur.", null, "Çift Kişilik (Tek Kişilik 2 Yataklı)", 1 },
                    { 4, new DateTime(2025, 4, 10, 17, 20, 50, 281, DateTimeKind.Local).AddTicks(23), null, "3 adet tek kişilik yatak.  Klima, TV, saç kurutma makinesi ve WiFi mevcuttur.", null, "Üç Kişilik (Tek Kişilik 3 Yataklı)", 1 },
                    { 5, new DateTime(2025, 4, 10, 17, 20, 50, 281, DateTimeKind.Local).AddTicks(24), null, "Bir tek bir duble yatak.  Klima, TV, saç kurutma makinesi ve WiFi mevcuttur.", null, "Üç Kişilik (1 Tek, 1 Duble Yataklı)", 1 },
                    { 6, new DateTime(2025, 4, 10, 17, 20, 50, 281, DateTimeKind.Local).AddTicks(88), null, "1 adet büyük (duble) yatak + 2 adet tek kişilik yatak. Klima, TV, saç kurutma makinesi ve WiFi mevcuttur.", null, "Dört Kişilik", 1 },
                    { 7, new DateTime(2025, 4, 10, 17, 20, 50, 281, DateTimeKind.Local).AddTicks(89), null, "Geniş ve lüks oda. Özel oturma alanı, büyük yatak, balkon, minibar, özel banyo ve lüks hizmetler. Klima, TV, saç kurutma makinesi, WiFi ve özel hizmetler mevcuttur.", null, "Kral Dairesi", 1 }
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
                    { 1, new DateTime(2025, 4, 10, 17, 20, 50, 281, DateTimeKind.Local).AddTicks(162), null, 1, true, false, true, false, true, true, null, 1000m, "100", 1, 1, 1 },
                    { 2, new DateTime(2025, 4, 10, 17, 20, 50, 281, DateTimeKind.Local).AddTicks(170), null, 1, true, false, true, false, true, true, null, 1000m, "101", 1, 1, 1 },
                    { 3, new DateTime(2025, 4, 10, 17, 20, 50, 281, DateTimeKind.Local).AddTicks(171), null, 1, true, false, true, false, true, true, null, 1000m, "102", 1, 1, 1 },
                    { 4, new DateTime(2025, 4, 10, 17, 20, 50, 281, DateTimeKind.Local).AddTicks(172), null, 1, true, false, true, false, true, true, null, 1000m, "103", 1, 1, 1 },
                    { 5, new DateTime(2025, 4, 10, 17, 20, 50, 281, DateTimeKind.Local).AddTicks(173), null, 1, true, false, true, false, true, true, null, 1000m, "104", 1, 1, 1 },
                    { 6, new DateTime(2025, 4, 10, 17, 20, 50, 281, DateTimeKind.Local).AddTicks(175), null, 1, true, false, true, false, true, true, null, 1000m, "105", 1, 1, 1 },
                    { 7, new DateTime(2025, 4, 10, 17, 20, 50, 281, DateTimeKind.Local).AddTicks(176), null, 1, true, false, true, false, true, true, null, 1000m, "106", 1, 1, 1 },
                    { 8, new DateTime(2025, 4, 10, 17, 20, 50, 281, DateTimeKind.Local).AddTicks(176), null, 1, true, false, true, false, true, true, null, 1000m, "107", 1, 1, 1 },
                    { 9, new DateTime(2025, 4, 10, 17, 20, 50, 281, DateTimeKind.Local).AddTicks(177), null, 1, true, false, true, false, true, true, null, 1000m, "108", 1, 1, 1 },
                    { 10, new DateTime(2025, 4, 10, 17, 20, 50, 281, DateTimeKind.Local).AddTicks(178), null, 1, true, false, true, false, true, true, null, 1000m, "109", 1, 1, 1 },
                    { 11, new DateTime(2025, 4, 10, 17, 20, 50, 281, DateTimeKind.Local).AddTicks(181), null, 1, true, false, true, false, true, true, null, 1500m, "110", 1, 4, 1 },
                    { 12, new DateTime(2025, 4, 10, 17, 20, 50, 281, DateTimeKind.Local).AddTicks(182), null, 1, true, false, true, false, true, true, null, 1500m, "111", 1, 4, 1 },
                    { 13, new DateTime(2025, 4, 10, 17, 20, 50, 281, DateTimeKind.Local).AddTicks(183), null, 1, true, false, true, false, true, true, null, 1500m, "112", 1, 4, 1 },
                    { 14, new DateTime(2025, 4, 10, 17, 20, 50, 281, DateTimeKind.Local).AddTicks(183), null, 1, true, false, true, false, true, true, null, 1500m, "113", 1, 4, 1 },
                    { 15, new DateTime(2025, 4, 10, 17, 20, 50, 281, DateTimeKind.Local).AddTicks(184), null, 1, true, false, true, false, true, true, null, 1500m, "114", 1, 4, 1 },
                    { 16, new DateTime(2025, 4, 10, 17, 20, 50, 281, DateTimeKind.Local).AddTicks(184), null, 1, true, false, true, false, true, true, null, 1500m, "115", 1, 4, 1 },
                    { 17, new DateTime(2025, 4, 10, 17, 20, 50, 281, DateTimeKind.Local).AddTicks(185), null, 1, true, false, true, false, true, true, null, 1500m, "116", 1, 4, 1 },
                    { 18, new DateTime(2025, 4, 10, 17, 20, 50, 281, DateTimeKind.Local).AddTicks(186), null, 1, true, false, true, false, true, true, null, 1500m, "117", 1, 4, 1 },
                    { 19, new DateTime(2025, 4, 10, 17, 20, 50, 281, DateTimeKind.Local).AddTicks(186), null, 1, true, false, true, false, true, true, null, 1500m, "118", 1, 4, 1 },
                    { 20, new DateTime(2025, 4, 10, 17, 20, 50, 281, DateTimeKind.Local).AddTicks(187), null, 1, true, false, true, false, true, true, null, 1500m, "119", 1, 4, 1 },
                    { 21, new DateTime(2025, 4, 10, 17, 20, 50, 281, DateTimeKind.Local).AddTicks(189), null, 2, true, false, true, false, true, true, null, 1200m, "200", 1, 1, 1 },
                    { 22, new DateTime(2025, 4, 10, 17, 20, 50, 281, DateTimeKind.Local).AddTicks(190), null, 2, true, false, true, false, true, true, null, 1200m, "201", 1, 1, 1 },
                    { 23, new DateTime(2025, 4, 10, 17, 20, 50, 281, DateTimeKind.Local).AddTicks(190), null, 2, true, false, true, false, true, true, null, 1200m, "202", 1, 1, 1 },
                    { 24, new DateTime(2025, 4, 10, 17, 20, 50, 281, DateTimeKind.Local).AddTicks(191), null, 2, true, false, true, false, true, true, null, 1200m, "203", 1, 1, 1 },
                    { 25, new DateTime(2025, 4, 10, 17, 20, 50, 281, DateTimeKind.Local).AddTicks(191), null, 2, true, false, true, false, true, true, null, 1200m, "204", 1, 1, 1 },
                    { 26, new DateTime(2025, 4, 10, 17, 20, 50, 281, DateTimeKind.Local).AddTicks(192), null, 2, true, false, true, false, true, true, null, 1200m, "205", 1, 1, 1 },
                    { 27, new DateTime(2025, 4, 10, 17, 20, 50, 281, DateTimeKind.Local).AddTicks(192), null, 2, true, false, true, false, true, true, null, 1200m, "206", 1, 1, 1 },
                    { 28, new DateTime(2025, 4, 10, 17, 20, 50, 281, DateTimeKind.Local).AddTicks(193), null, 2, true, false, true, false, true, true, null, 1200m, "207", 1, 1, 1 },
                    { 29, new DateTime(2025, 4, 10, 17, 20, 50, 281, DateTimeKind.Local).AddTicks(193), null, 2, true, false, true, false, true, true, null, 1200m, "208", 1, 1, 1 },
                    { 30, new DateTime(2025, 4, 10, 17, 20, 50, 281, DateTimeKind.Local).AddTicks(194), null, 2, true, false, true, false, true, true, null, 1200m, "209", 1, 1, 1 },
                    { 31, new DateTime(2025, 4, 10, 17, 20, 50, 281, DateTimeKind.Local).AddTicks(196), null, 2, true, false, true, true, true, true, null, 1800m, "210", 1, 3, 1 },
                    { 32, new DateTime(2025, 4, 10, 17, 20, 50, 281, DateTimeKind.Local).AddTicks(197), null, 2, true, false, true, true, true, true, null, 1800m, "211", 1, 3, 1 },
                    { 33, new DateTime(2025, 4, 10, 17, 20, 50, 281, DateTimeKind.Local).AddTicks(197), null, 2, true, false, true, true, true, true, null, 1800m, "212", 1, 3, 1 },
                    { 34, new DateTime(2025, 4, 10, 17, 20, 50, 281, DateTimeKind.Local).AddTicks(198), null, 2, true, false, true, true, true, true, null, 1800m, "213", 1, 3, 1 },
                    { 35, new DateTime(2025, 4, 10, 17, 20, 50, 281, DateTimeKind.Local).AddTicks(199), null, 2, true, false, true, true, true, true, null, 1800m, "214", 1, 3, 1 },
                    { 36, new DateTime(2025, 4, 10, 17, 20, 50, 281, DateTimeKind.Local).AddTicks(200), null, 2, true, false, true, true, true, true, null, 1800m, "215", 1, 3, 1 },
                    { 37, new DateTime(2025, 4, 10, 17, 20, 50, 281, DateTimeKind.Local).AddTicks(200), null, 2, true, false, true, true, true, true, null, 1800m, "216", 1, 3, 1 },
                    { 38, new DateTime(2025, 4, 10, 17, 20, 50, 281, DateTimeKind.Local).AddTicks(201), null, 2, true, false, true, true, true, true, null, 1800m, "217", 1, 3, 1 },
                    { 39, new DateTime(2025, 4, 10, 17, 20, 50, 281, DateTimeKind.Local).AddTicks(201), null, 2, true, false, true, true, true, true, null, 1800m, "218", 1, 3, 1 },
                    { 40, new DateTime(2025, 4, 10, 17, 20, 50, 281, DateTimeKind.Local).AddTicks(202), null, 2, true, false, true, true, true, true, null, 1800m, "219", 1, 3, 1 },
                    { 41, new DateTime(2025, 4, 10, 17, 20, 50, 281, DateTimeKind.Local).AddTicks(205), null, 3, true, true, true, true, true, true, null, 2200m, "300", 1, 2, 1 },
                    { 42, new DateTime(2025, 4, 10, 17, 20, 50, 281, DateTimeKind.Local).AddTicks(206), null, 3, true, true, true, true, true, true, null, 2200m, "301", 1, 2, 1 },
                    { 43, new DateTime(2025, 4, 10, 17, 20, 50, 281, DateTimeKind.Local).AddTicks(206), null, 3, true, true, true, true, true, true, null, 2200m, "302", 1, 2, 1 },
                    { 44, new DateTime(2025, 4, 10, 17, 20, 50, 281, DateTimeKind.Local).AddTicks(207), null, 3, true, true, true, true, true, true, null, 2200m, "303", 1, 2, 1 },
                    { 45, new DateTime(2025, 4, 10, 17, 20, 50, 281, DateTimeKind.Local).AddTicks(208), null, 3, true, true, true, true, true, true, null, 2200m, "304", 1, 2, 1 },
                    { 46, new DateTime(2025, 4, 10, 17, 20, 50, 281, DateTimeKind.Local).AddTicks(208), null, 3, true, true, true, true, true, true, null, 2200m, "305", 1, 2, 1 },
                    { 47, new DateTime(2025, 4, 10, 17, 20, 50, 281, DateTimeKind.Local).AddTicks(209), null, 3, true, true, true, true, true, true, null, 2200m, "306", 1, 2, 1 },
                    { 48, new DateTime(2025, 4, 10, 17, 20, 50, 281, DateTimeKind.Local).AddTicks(210), null, 3, true, true, true, true, true, true, null, 2200m, "307", 1, 2, 1 },
                    { 49, new DateTime(2025, 4, 10, 17, 20, 50, 281, DateTimeKind.Local).AddTicks(254), null, 3, true, true, true, true, true, true, null, 2200m, "308", 1, 2, 1 },
                    { 50, new DateTime(2025, 4, 10, 17, 20, 50, 281, DateTimeKind.Local).AddTicks(255), null, 3, true, true, true, true, true, true, null, 2200m, "309", 1, 2, 1 },
                    { 51, new DateTime(2025, 4, 10, 17, 20, 50, 281, DateTimeKind.Local).AddTicks(257), null, 3, true, true, true, true, true, true, null, 2500m, "310", 1, 5, 1 },
                    { 52, new DateTime(2025, 4, 10, 17, 20, 50, 281, DateTimeKind.Local).AddTicks(258), null, 3, true, true, true, true, true, true, null, 2500m, "311", 1, 5, 1 },
                    { 53, new DateTime(2025, 4, 10, 17, 20, 50, 281, DateTimeKind.Local).AddTicks(258), null, 3, true, true, true, true, true, true, null, 2500m, "312", 1, 5, 1 },
                    { 54, new DateTime(2025, 4, 10, 17, 20, 50, 281, DateTimeKind.Local).AddTicks(259), null, 3, true, true, true, true, true, true, null, 2500m, "313", 1, 5, 1 },
                    { 55, new DateTime(2025, 4, 10, 17, 20, 50, 281, DateTimeKind.Local).AddTicks(260), null, 3, true, true, true, true, true, true, null, 2500m, "314", 1, 5, 1 },
                    { 56, new DateTime(2025, 4, 10, 17, 20, 50, 281, DateTimeKind.Local).AddTicks(260), null, 3, true, true, true, true, true, true, null, 2500m, "315", 1, 5, 1 },
                    { 57, new DateTime(2025, 4, 10, 17, 20, 50, 281, DateTimeKind.Local).AddTicks(261), null, 3, true, true, true, true, true, true, null, 2500m, "316", 1, 5, 1 },
                    { 58, new DateTime(2025, 4, 10, 17, 20, 50, 281, DateTimeKind.Local).AddTicks(262), null, 3, true, true, true, true, true, true, null, 2500m, "317", 1, 5, 1 },
                    { 59, new DateTime(2025, 4, 10, 17, 20, 50, 281, DateTimeKind.Local).AddTicks(262), null, 3, true, true, true, true, true, true, null, 2500m, "318", 1, 5, 1 },
                    { 60, new DateTime(2025, 4, 10, 17, 20, 50, 281, DateTimeKind.Local).AddTicks(263), null, 3, true, true, true, true, true, true, null, 2500m, "319", 1, 5, 1 },
                    { 61, new DateTime(2025, 4, 10, 17, 20, 50, 281, DateTimeKind.Local).AddTicks(265), null, 4, true, true, true, true, true, true, null, 2800m, "400", 1, 2, 1 },
                    { 62, new DateTime(2025, 4, 10, 17, 20, 50, 281, DateTimeKind.Local).AddTicks(266), null, 4, true, true, true, true, true, true, null, 2800m, "401", 1, 2, 1 },
                    { 63, new DateTime(2025, 4, 10, 17, 20, 50, 281, DateTimeKind.Local).AddTicks(266), null, 4, true, true, true, true, true, true, null, 2800m, "402", 1, 2, 1 },
                    { 64, new DateTime(2025, 4, 10, 17, 20, 50, 281, DateTimeKind.Local).AddTicks(267), null, 4, true, true, true, true, true, true, null, 2800m, "403", 1, 2, 1 },
                    { 65, new DateTime(2025, 4, 10, 17, 20, 50, 281, DateTimeKind.Local).AddTicks(267), null, 4, true, true, true, true, true, true, null, 2800m, "404", 1, 2, 1 },
                    { 66, new DateTime(2025, 4, 10, 17, 20, 50, 281, DateTimeKind.Local).AddTicks(268), null, 4, true, true, true, true, true, true, null, 2800m, "405", 1, 2, 1 },
                    { 67, new DateTime(2025, 4, 10, 17, 20, 50, 281, DateTimeKind.Local).AddTicks(269), null, 4, true, true, true, true, true, true, null, 2800m, "406", 1, 2, 1 },
                    { 68, new DateTime(2025, 4, 10, 17, 20, 50, 281, DateTimeKind.Local).AddTicks(269), null, 4, true, true, true, true, true, true, null, 2800m, "407", 1, 2, 1 },
                    { 69, new DateTime(2025, 4, 10, 17, 20, 50, 281, DateTimeKind.Local).AddTicks(270), null, 4, true, true, true, true, true, true, null, 2800m, "408", 1, 2, 1 },
                    { 70, new DateTime(2025, 4, 10, 17, 20, 50, 281, DateTimeKind.Local).AddTicks(271), null, 4, true, true, true, true, true, true, null, 2800m, "409", 1, 2, 1 },
                    { 71, new DateTime(2025, 4, 10, 17, 20, 50, 281, DateTimeKind.Local).AddTicks(273), null, 4, true, true, true, true, true, true, null, 3500m, "410", 1, 6, 1 },
                    { 72, new DateTime(2025, 4, 10, 17, 20, 50, 281, DateTimeKind.Local).AddTicks(273), null, 4, true, true, true, true, true, true, null, 3500m, "411", 1, 6, 1 },
                    { 73, new DateTime(2025, 4, 10, 17, 20, 50, 281, DateTimeKind.Local).AddTicks(274), null, 4, true, true, true, true, true, true, null, 3500m, "412", 1, 6, 1 },
                    { 74, new DateTime(2025, 4, 10, 17, 20, 50, 281, DateTimeKind.Local).AddTicks(274), null, 4, true, true, true, true, true, true, null, 3500m, "413", 1, 6, 1 },
                    { 75, new DateTime(2025, 4, 10, 17, 20, 50, 281, DateTimeKind.Local).AddTicks(275), null, 4, true, true, true, true, true, true, null, 3500m, "414", 1, 6, 1 },
                    { 76, new DateTime(2025, 4, 10, 17, 20, 50, 281, DateTimeKind.Local).AddTicks(275), null, 4, true, true, true, true, true, true, null, 3500m, "415", 1, 6, 1 },
                    { 77, new DateTime(2025, 4, 10, 17, 20, 50, 281, DateTimeKind.Local).AddTicks(277), null, 4, true, true, true, true, true, true, null, 10000m, "417", 1, 7, 1 }
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
