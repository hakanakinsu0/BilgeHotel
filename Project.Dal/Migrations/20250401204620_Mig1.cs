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
                    { 1, "14c31f26-e70b-4442-9efe-013750b0419e", "Admin", "ADMIN" },
                    { 2, "a02e2143-b67a-44f4-ac9e-a81f8ebaeb38", "Member", "MEMBER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ActivationCode", "ConcurrencyStamp", "CreatedDate", "DeletedDate", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "ModifiedDate", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Status", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { 1, 0, new Guid("00000000-0000-0000-0000-000000000000"), "dbf66d7a-3ceb-4f96-a687-9d000ecbb6bb", new DateTime(2025, 4, 1, 23, 46, 19, 704, DateTimeKind.Local).AddTicks(2697), null, "bilgehotel@email.com", true, false, null, null, "BILGEHOTEL@EMAIL.COM", "BILGEHOTEL", "AQAAAAIAAYagAAAAEAlrmlAd+EBV03EFSaY3sO/WRuhrOpp6PLdRbQKXOTjuF1EW0neGGMp61YeOSGR/bA==", null, false, "6173ca4e-1703-477e-8b9c-0a9dd8b3f30a", 1, false, "bilgehotel" },
                    { 2, 0, new Guid("00000000-0000-0000-0000-000000000000"), "3a28309d-acfb-491f-95c9-b9a17f8e1285", new DateTime(2025, 4, 1, 23, 46, 19, 743, DateTimeKind.Local).AddTicks(4474), null, "testmember@email.com", true, false, null, null, "TESTMEMBER@EMAIL.COM", "TESTMEMBER", "AQAAAAIAAYagAAAAEGEcVsxwdFJzmfYoG8UNyT0FjHRPmq7NZWJpfDSy/hmxnbSoJM7yYFpy7D397BRUFw==", null, false, "ba27e4a2-fc6d-4bff-9317-9bd7a272d691", 1, false, "testmember" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Address", "BirthDate", "CreatedDate", "DeletedDate", "FirstName", "HireDate", "LastName", "ModifiedDate", "PhoneNumber", "Position", "Salary", "Shift", "Status" },
                values: new object[,]
                {
                    { 1, "Ali Çetinkaya Caddesi 0, Ordu, K.K.T.C.", new DateTime(1989, 12, 9, 17, 16, 32, 67, DateTimeKind.Local).AddTicks(7819), new DateTime(2025, 4, 1, 23, 46, 19, 666, DateTimeKind.Local).AddTicks(3911), null, "İtil", new DateTime(2024, 3, 12, 23, 45, 38, 274, DateTimeKind.Local).AddTicks(4631), "Yetkiner", null, "+90-549-258-4-723", "Resepsiyonist", 58455.12m, 2, 1 },
                    { 2, "Güven Yaka Sokak 165, Isparta, Kiribati", new DateTime(1995, 10, 20, 13, 39, 16, 332, DateTimeKind.Local).AddTicks(4109), new DateTime(2025, 4, 1, 23, 46, 19, 666, DateTimeKind.Local).AddTicks(4039), null, "Akaş", new DateTime(2015, 12, 9, 1, 20, 46, 833, DateTimeKind.Local).AddTicks(6889), "Pektemek", null, "+90-449-087-02-28", "Resepsiyonist", 44332.07m, 1, 1 },
                    { 3, "Kocatepe Caddesi 90b, Samsun, Meksika", new DateTime(1972, 4, 15, 8, 25, 32, 935, DateTimeKind.Local).AddTicks(2706), new DateTime(2025, 4, 1, 23, 46, 19, 666, DateTimeKind.Local).AddTicks(4145), null, "Erinç", new DateTime(2018, 9, 15, 15, 5, 5, 669, DateTimeKind.Local).AddTicks(4981), "Barbarosoğlu", null, "+90-590-572-97-34", "Resepsiyonist", 51639.64m, 3, 1 },
                    { 4, "Dağınık Evler Sokak 49a, Adıyaman, Kuzey Kore", new DateTime(1994, 10, 15, 16, 10, 38, 808, DateTimeKind.Local).AddTicks(2228), new DateTime(2025, 4, 1, 23, 46, 19, 666, DateTimeKind.Local).AddTicks(4233), null, "Atıla", new DateTime(2021, 3, 1, 5, 14, 37, 851, DateTimeKind.Local).AddTicks(6509), "Özdenak", null, "+90-348-663-90-18", "Resepsiyonist", 42389.46m, 1, 1 },
                    { 5, "Sıran Söğüt Sokak 17, Iğdır, Sırbistan", new DateTime(1974, 10, 28, 8, 26, 4, 405, DateTimeKind.Local).AddTicks(7425), new DateTime(2025, 4, 1, 23, 46, 19, 666, DateTimeKind.Local).AddTicks(4290), null, "Börübars", new DateTime(2019, 10, 18, 5, 30, 52, 90, DateTimeKind.Local).AddTicks(7408), "Ozansoy", null, "+90-585-576-81-07", "Resepsiyonist", 40537.68m, 1, 1 },
                    { 6, "Gül Sokak 384, Hakkari, Aruba, Hollanda", new DateTime(1996, 3, 4, 0, 15, 3, 405, DateTimeKind.Local).AddTicks(6019), new DateTime(2025, 4, 1, 23, 46, 19, 666, DateTimeKind.Local).AddTicks(4377), null, "Arademir", new DateTime(2022, 10, 13, 18, 35, 57, 647, DateTimeKind.Local).AddTicks(2821), "Taşlı", null, "+90-952-790-47-15", "Resepsiyonist", 56641.68m, 3, 1 },
                    { 7, "Namık Kemal Caddesi 8, Sivas, Güney Kıbrıs Rum Yönetimi", new DateTime(2003, 8, 12, 13, 22, 1, 156, DateTimeKind.Local).AddTicks(7702), new DateTime(2025, 4, 1, 23, 46, 19, 666, DateTimeKind.Local).AddTicks(4465), null, "Baydur", new DateTime(2019, 11, 20, 9, 54, 16, 542, DateTimeKind.Local).AddTicks(2026), "Nalbantoğlu", null, "+90-193-208-25-06", "Resepsiyonist", 54703.14m, 1, 1 },
                    { 8, "Ülkü Sokak 39a, Muğla, Türkiye", new DateTime(1978, 8, 6, 11, 50, 4, 683, DateTimeKind.Local).AddTicks(3590), new DateTime(2025, 4, 1, 23, 46, 19, 666, DateTimeKind.Local).AddTicks(4566), null, "Bayram", new DateTime(2023, 5, 21, 11, 24, 19, 695, DateTimeKind.Local).AddTicks(4259), "Özdenak", null, "+90-440-128-1-432", "Temizlik Görevlisi", 28152.91m, 1, 1 },
                    { 9, "Ülkü Sokak 79, Kırklareli, Santa Lucia", new DateTime(1982, 8, 25, 4, 2, 38, 425, DateTimeKind.Local).AddTicks(3984), new DateTime(2025, 4, 1, 23, 46, 19, 666, DateTimeKind.Local).AddTicks(4615), null, "Kaynak", new DateTime(2023, 3, 6, 4, 9, 45, 807, DateTimeKind.Local).AddTicks(7481), "Ekici", null, "+90-846-635-6-494", "Temizlik Görevlisi", 26595.48m, 1, 1 },
                    { 10, "Menekşe Sokak 20, Yalova, Avustralya", new DateTime(1996, 4, 18, 1, 44, 31, 351, DateTimeKind.Local).AddTicks(1018), new DateTime(2025, 4, 1, 23, 46, 19, 666, DateTimeKind.Local).AddTicks(4707), null, "Bilgetardu", new DateTime(2023, 1, 30, 0, 39, 4, 322, DateTimeKind.Local).AddTicks(9582), "Biçer", null, "+90-541-366-4-733", "Temizlik Görevlisi", 33665.92m, 1, 1 },
                    { 11, "Barış Sokak 67b, İstanbul, Gabon", new DateTime(1992, 8, 6, 4, 36, 57, 101, DateTimeKind.Local).AddTicks(5234), new DateTime(2025, 4, 1, 23, 46, 19, 666, DateTimeKind.Local).AddTicks(4779), null, "Azban", new DateTime(2020, 2, 15, 4, 4, 19, 691, DateTimeKind.Local).AddTicks(2571), "Ertepınar", null, "+90-523-546-2-238", "Temizlik Görevlisi", 30837.03m, 2, 1 },
                    { 12, "Gül Sokak 778, Trabzon, Fiji", new DateTime(1985, 7, 1, 21, 3, 12, 430, DateTimeKind.Local).AddTicks(1291), new DateTime(2025, 4, 1, 23, 46, 19, 666, DateTimeKind.Local).AddTicks(4908), null, "Gökbörü", new DateTime(2018, 4, 19, 19, 31, 59, 324, DateTimeKind.Local).AddTicks(6150), "Düşenkalkar", null, "+90-569-771-3-344", "Temizlik Görevlisi", 27938.50m, 1, 1 },
                    { 13, "Saygılı Sokak 04, Diyarbakır, Gabon", new DateTime(1982, 9, 11, 8, 47, 52, 860, DateTimeKind.Local).AddTicks(8935), new DateTime(2025, 4, 1, 23, 46, 19, 666, DateTimeKind.Local).AddTicks(5040), null, "Bağan", new DateTime(2023, 1, 14, 13, 22, 27, 891, DateTimeKind.Local).AddTicks(8666), "Dağlaroğlu", null, "+90-051-628-5-195", "Temizlik Görevlisi", 26113.79m, 2, 1 },
                    { 14, "Alparslan Türkeş Bulvarı 510, Adana, Svaziland", new DateTime(1994, 11, 7, 7, 32, 50, 887, DateTimeKind.Local).AddTicks(2077), new DateTime(2025, 4, 1, 23, 46, 19, 666, DateTimeKind.Local).AddTicks(5130), null, "Abakay", new DateTime(2023, 7, 19, 23, 56, 45, 300, DateTimeKind.Local).AddTicks(7632), "Küçükler", null, "+90-407-618-89-77", "Temizlik Görevlisi", 28406.56m, 1, 1 },
                    { 15, "Afyon Kaya Sokak 63b, Bayburt, Çad", new DateTime(2002, 2, 6, 10, 31, 52, 375, DateTimeKind.Local).AddTicks(9321), new DateTime(2025, 4, 1, 23, 46, 19, 666, DateTimeKind.Local).AddTicks(5208), null, "Batu", new DateTime(2014, 9, 25, 5, 54, 21, 715, DateTimeKind.Local).AddTicks(5326), "Nebioğlu", null, "+90-194-092-53-27", "Temizlik Görevlisi", 32393.56m, 2, 1 },
                    { 16, "Menekşe Sokak 72a, Manisa, Ermenistan", new DateTime(1970, 1, 30, 18, 34, 3, 785, DateTimeKind.Local).AddTicks(2156), new DateTime(2025, 4, 1, 23, 46, 19, 666, DateTimeKind.Local).AddTicks(5259), null, "Kızılalma", new DateTime(2018, 10, 12, 9, 3, 44, 679, DateTimeKind.Local).AddTicks(203), "Yalçın", null, "+90-566-073-7-712", "Temizlik Görevlisi", 28285.73m, 2, 1 },
                    { 17, "Oğuzhan Sokak 95b, Kırşehir, Türkiye", new DateTime(1991, 12, 9, 21, 37, 8, 646, DateTimeKind.Local).AddTicks(3939), new DateTime(2025, 4, 1, 23, 46, 19, 666, DateTimeKind.Local).AddTicks(5335), null, "Katun", new DateTime(2019, 1, 19, 0, 38, 32, 939, DateTimeKind.Local).AddTicks(4955), "Kurutluoğlu", null, "+90-973-716-23-42", "Temizlik Görevlisi", 32842.27m, 1, 1 },
                    { 18, "Kerimoğlu Sokak 49c, Kırşehir, Japonya", new DateTime(1973, 1, 28, 11, 16, 23, 128, DateTimeKind.Local).AddTicks(873), new DateTime(2025, 4, 1, 23, 46, 19, 666, DateTimeKind.Local).AddTicks(5413), null, "Ağakağan", new DateTime(2019, 2, 19, 10, 1, 43, 488, DateTimeKind.Local).AddTicks(587), "Özkara", null, "+90-242-092-11-07", "Temizlik Görevlisi", 28676.98m, 1, 1 },
                    { 19, "Atatürk Bulvarı 58b, Kars, Kosta Rika", new DateTime(1999, 8, 26, 2, 59, 40, 833, DateTimeKind.Local).AddTicks(5278), new DateTime(2025, 4, 1, 23, 46, 19, 666, DateTimeKind.Local).AddTicks(5495), null, "Bangu", new DateTime(2019, 8, 13, 10, 57, 57, 407, DateTimeKind.Local).AddTicks(5423), "Aclan", null, "+90-494-252-6-681", "Aşçı", 116403.58m, 1, 1 },
                    { 20, "Ali Çetinkaya Caddesi 15c, Kastamonu, Ruanda", new DateTime(1998, 6, 6, 21, 19, 54, 212, DateTimeKind.Local).AddTicks(6527), new DateTime(2025, 4, 1, 23, 46, 19, 666, DateTimeKind.Local).AddTicks(5547), null, "Baldu", new DateTime(2023, 3, 23, 23, 17, 55, 128, DateTimeKind.Local).AddTicks(6800), "Denkel", null, "+90-974-271-1-070", "Aşçı", 107090.49m, 1, 1 },
                    { 21, "Kaldırım Sokak 93a, K.maraş, Grönland", new DateTime(1978, 1, 7, 1, 1, 46, 968, DateTimeKind.Local).AddTicks(9431), new DateTime(2025, 4, 1, 23, 46, 19, 666, DateTimeKind.Local).AddTicks(5621), null, "Adalan", new DateTime(2014, 6, 8, 10, 3, 59, 44, DateTimeKind.Local).AddTicks(1285), "Yıldızoğlu", null, "+90-732-396-8-927", "Aşçı", 114369.04m, 2, 1 },
                    { 22, "Güven Yaka Sokak 79, Elazığ, Kamboçya", new DateTime(1974, 6, 7, 1, 40, 56, 995, DateTimeKind.Local).AddTicks(4613), new DateTime(2025, 4, 1, 23, 46, 19, 666, DateTimeKind.Local).AddTicks(5687), null, "Alabörü", new DateTime(2022, 6, 18, 5, 44, 24, 774, DateTimeKind.Local).AddTicks(2693), "Eliçin", null, "+90-575-481-41-41", "Aşçı", 105106.51m, 1, 1 },
                    { 23, "Kocatepe Caddesi 8, Bilecik, Fransa", new DateTime(1984, 2, 21, 1, 21, 28, 139, DateTimeKind.Local).AddTicks(1907), new DateTime(2025, 4, 1, 23, 46, 19, 666, DateTimeKind.Local).AddTicks(5773), null, "Barmaklak", new DateTime(2019, 11, 28, 19, 49, 23, 328, DateTimeKind.Local).AddTicks(509), "Çamdalı", null, "+90-568-683-8-765", "Aşçı", 101522.35m, 1, 1 },
                    { 24, "Menekşe Sokak 96a, Afyon, Ürdün", new DateTime(1995, 11, 18, 4, 35, 37, 55, DateTimeKind.Local).AddTicks(5462), new DateTime(2025, 4, 1, 23, 46, 19, 666, DateTimeKind.Local).AddTicks(5823), null, "Ayluçtarkan", new DateTime(2017, 5, 17, 2, 11, 6, 527, DateTimeKind.Local).AddTicks(4826), "Küçükler", null, "+90-876-965-12-20", "Aşçı", 106189.29m, 2, 1 },
                    { 25, "Harman Yolu Sokak  410, Artvin, Şili", new DateTime(1978, 4, 28, 12, 36, 10, 595, DateTimeKind.Local).AddTicks(6156), new DateTime(2025, 4, 1, 23, 46, 19, 666, DateTimeKind.Local).AddTicks(5919), null, "Atberilgen", new DateTime(2017, 5, 29, 11, 42, 44, 495, DateTimeKind.Local).AddTicks(7019), "Çapanoğlu", null, "+90-961-179-98-33", "Aşçı", 115149.87m, 2, 1 },
                    { 26, "Dar Sokak 12a, Kastamonu, Samoa", new DateTime(1993, 12, 28, 7, 2, 3, 173, DateTimeKind.Local).AddTicks(242), new DateTime(2025, 4, 1, 23, 46, 19, 666, DateTimeKind.Local).AddTicks(5996), null, "Beğtegin", new DateTime(2021, 1, 7, 1, 37, 0, 785, DateTimeKind.Local).AddTicks(6151), "Baykam", null, "+90-016-383-0-306", "Aşçı", 119161.96m, 2, 1 },
                    { 27, "Mevlana Sokak 55a, Kars, Fransız Guyanası", new DateTime(2002, 6, 1, 19, 45, 23, 508, DateTimeKind.Local).AddTicks(7953), new DateTime(2025, 4, 1, 23, 46, 19, 666, DateTimeKind.Local).AddTicks(6047), null, "Bolsun", new DateTime(2020, 11, 1, 16, 33, 6, 317, DateTimeKind.Local).AddTicks(6201), "Mayhoş", null, "+90-464-472-1-472", "Aşçı", 105599.28m, 1, 1 },
                    { 28, "Bandak Sokak 58, Batman, Irak", new DateTime(1994, 4, 18, 18, 18, 51, 81, DateTimeKind.Local).AddTicks(1878), new DateTime(2025, 4, 1, 23, 46, 19, 666, DateTimeKind.Local).AddTicks(6124), null, "Arslan", new DateTime(2016, 9, 26, 8, 50, 15, 519, DateTimeKind.Local).AddTicks(9302), "Duygulu", null, "+90-969-800-03-96", "Aşçı", 106577.08m, 2, 1 },
                    { 29, "Ali Çetinkaya Caddesi 141, Muğla, Haiti", new DateTime(1984, 1, 13, 18, 12, 11, 85, DateTimeKind.Local).AddTicks(2055), new DateTime(2025, 4, 1, 23, 46, 19, 666, DateTimeKind.Local).AddTicks(6200), null, "Baysungur", new DateTime(2019, 2, 28, 3, 56, 0, 667, DateTimeKind.Local).AddTicks(3136), "Ayaydın", null, "+90-394-556-03-83", "Aşçı", 111488.86m, 1, 1 },
                    { 30, "İbn-i Sina Sokak 63c, Balıkesir, Sudan", new DateTime(1989, 6, 27, 12, 34, 48, 428, DateTimeKind.Local).AddTicks(7536), new DateTime(2025, 4, 1, 23, 46, 19, 666, DateTimeKind.Local).AddTicks(6280), null, "Atalmış", new DateTime(2023, 11, 3, 15, 16, 52, 546, DateTimeKind.Local).AddTicks(7646), "Çatalbaş", null, "+90-536-897-27-70", "Garson", 83010.69m, 2, 1 },
                    { 31, "Saygılı Sokak 44a, Aydın, Avusturya", new DateTime(2002, 3, 2, 2, 23, 44, 756, DateTimeKind.Local).AddTicks(3945), new DateTime(2025, 4, 1, 23, 46, 19, 666, DateTimeKind.Local).AddTicks(6325), null, "Bilgekağan", new DateTime(2017, 6, 23, 21, 13, 11, 982, DateTimeKind.Local).AddTicks(5519), "Baykam", null, "+90-987-429-1-132", "Garson", 73527.10m, 1, 1 },
                    { 32, "Okul Sokak 21, Kırıkkale, Galler", new DateTime(1995, 4, 6, 17, 26, 28, 806, DateTimeKind.Local).AddTicks(7196), new DateTime(2025, 4, 1, 23, 46, 19, 666, DateTimeKind.Local).AddTicks(6399), null, "Günay", new DateTime(2020, 2, 9, 9, 11, 13, 741, DateTimeKind.Local).AddTicks(2132), "Tuğlu", null, "+90-944-545-0-546", "Garson", 79454.10m, 1, 1 },
                    { 33, "Namık Kemal Caddesi 27a, Bartın, Şili", new DateTime(2007, 2, 12, 18, 13, 16, 341, DateTimeKind.Local).AddTicks(1499), new DateTime(2025, 4, 1, 23, 46, 19, 666, DateTimeKind.Local).AddTicks(6471), null, "Abak", new DateTime(2019, 1, 20, 7, 54, 56, 275, DateTimeKind.Local).AddTicks(4465), "Ilıcalı", null, "+90-769-327-8-423", "Garson", 98403.12m, 1, 1 },
                    { 34, "Mevlana Sokak 91b, Edirne, Vallis ve Futuna, Fransa", new DateTime(1980, 4, 12, 4, 32, 5, 387, DateTimeKind.Local).AddTicks(3403), new DateTime(2025, 4, 1, 23, 46, 19, 666, DateTimeKind.Local).AddTicks(6567), null, "Alper", new DateTime(2020, 11, 10, 17, 54, 12, 130, DateTimeKind.Local).AddTicks(3654), "Yetkiner", null, "+90-975-724-7-588", "Garson", 85514.18m, 1, 1 },
                    { 35, "Lütfi Karadirek Caddesi 78a, Kırklareli, Fransa", new DateTime(1998, 5, 12, 10, 26, 49, 561, DateTimeKind.Local).AddTicks(5462), new DateTime(2025, 4, 1, 23, 46, 19, 666, DateTimeKind.Local).AddTicks(6615), null, "Basat", new DateTime(2021, 3, 8, 0, 25, 27, 834, DateTimeKind.Local).AddTicks(7095), "Yorulmaz", null, "+90-546-117-6-378", "Garson", 98216.95m, 2, 1 },
                    { 36, "Ergenekon Sokak   88a, Çorum, Suudi Arabistan", new DateTime(1982, 7, 9, 0, 32, 34, 592, DateTimeKind.Local).AddTicks(9210), new DateTime(2025, 4, 1, 23, 46, 19, 666, DateTimeKind.Local).AddTicks(6721), null, "Çağlayan", new DateTime(2020, 10, 11, 11, 21, 34, 207, DateTimeKind.Local).AddTicks(8264), "Arslanoğlu", null, "+90-120-036-68-18", "Garson", 82112.87m, 1, 1 },
                    { 37, "Dağınık Evler Sokak 52, Elazığ, Gürcistan H", new DateTime(1978, 5, 30, 16, 57, 33, 549, DateTimeKind.Local).AddTicks(2872), new DateTime(2025, 4, 1, 23, 46, 19, 666, DateTimeKind.Local).AddTicks(6809), null, "Börü", new DateTime(2016, 12, 12, 0, 2, 29, 370, DateTimeKind.Local).AddTicks(3777), "Pekkan", null, "+90-119-982-8-827", "Garson", 98606.58m, 1, 1 },
                    { 38, "Harman Altı Sokak 7, Antalya, Mozambik", new DateTime(1972, 9, 20, 13, 34, 48, 840, DateTimeKind.Local).AddTicks(1643), new DateTime(2025, 4, 1, 23, 46, 19, 666, DateTimeKind.Local).AddTicks(6895), null, "Adlıbeğ", new DateTime(2019, 9, 1, 17, 6, 40, 265, DateTimeKind.Local).AddTicks(6629), "Sezek", null, "+90-224-924-49-06", "Garson", 73899.55m, 2, 1 },
                    { 39, "Sevgi Sokak 272, Muğla, Bolivya", new DateTime(1997, 12, 22, 23, 59, 7, 563, DateTimeKind.Local).AddTicks(1004), new DateTime(2025, 4, 1, 23, 46, 19, 666, DateTimeKind.Local).AddTicks(6941), null, "Batur", new DateTime(2017, 6, 25, 18, 22, 33, 246, DateTimeKind.Local).AddTicks(5719), "Ertürk", null, "+90-322-179-79-43", "Garson", 81056.61m, 2, 1 },
                    { 40, "Kocatepe Caddesi 47b, Kilis, Bulgaristan", new DateTime(2000, 12, 24, 9, 0, 17, 888, DateTimeKind.Local).AddTicks(2079), new DateTime(2025, 4, 1, 23, 46, 19, 666, DateTimeKind.Local).AddTicks(7026), null, "Altıntamgantarkan", new DateTime(2020, 8, 22, 16, 51, 18, 389, DateTimeKind.Local).AddTicks(5468), "Demirbaş", null, "+90-239-841-2-775", "Garson", 75175.20m, 2, 1 },
                    { 41, "Kekeçoğlu Sokak 73b, Tunceli, Nijerya", new DateTime(1973, 4, 20, 23, 43, 58, 991, DateTimeKind.Local).AddTicks(2394), new DateTime(2025, 4, 1, 23, 46, 19, 666, DateTimeKind.Local).AddTicks(7113), null, "Bayunçur", new DateTime(2014, 10, 12, 16, 1, 16, 3, DateTimeKind.Local).AddTicks(2722), "Topçuoğlu", null, "+90-722-894-1-398", "Garson", 96578.12m, 1, 1 },
                    { 42, "Tevfik Fikret Caddesi 35c, İzmir, Midway Adaları, Amerika", new DateTime(1996, 7, 9, 4, 48, 56, 149, DateTimeKind.Local).AddTicks(4878), new DateTime(2025, 4, 1, 23, 46, 19, 666, DateTimeKind.Local).AddTicks(7191), null, "Atımer", new DateTime(2020, 6, 23, 10, 4, 27, 810, DateTimeKind.Local).AddTicks(6331), "Okumuş", null, "+90-029-015-4-807", "Garson", 95030.22m, 2, 1 },
                    { 43, "Menekşe Sokak 81b, Bartın, Güney Kore", new DateTime(2004, 12, 20, 8, 49, 29, 352, DateTimeKind.Local).AddTicks(8336), new DateTime(2025, 4, 1, 23, 46, 19, 666, DateTimeKind.Local).AddTicks(7249), null, "Buyraç", new DateTime(2018, 7, 1, 4, 53, 51, 323, DateTimeKind.Local).AddTicks(7935), "Velioğlu", null, "+90-279-335-70-17", "Elektrikçi", 168976.48m, 3, 1 },
                    { 44, "Yunus Emre Sokak 68a, Malatya, Letonya", new DateTime(1974, 10, 14, 6, 31, 20, 985, DateTimeKind.Local).AddTicks(7583), new DateTime(2025, 4, 1, 23, 46, 19, 666, DateTimeKind.Local).AddTicks(7314), null, "Arkın", new DateTime(2020, 11, 14, 21, 41, 37, 411, DateTimeKind.Local).AddTicks(5856), "Nebioğlu", null, "+90-890-455-45-43", "IT Sorumlusu", 158857.09m, 1, 1 }
                });

            migrationBuilder.InsertData(
                table: "ExtraServices",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Description", "ModifiedDate", "Name", "Price", "Status" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 4, 1, 23, 46, 19, 743, DateTimeKind.Local).AddTicks(4712), null, "Günlük sınırsız spa kullanımı.", null, "Spa Kullanımı", 3000m, 1 },
                    { 2, new DateTime(2025, 4, 1, 23, 46, 19, 743, DateTimeKind.Local).AddTicks(4714), null, "24 saat oda servisi. Tüm yemek siparişleri dahildir.", null, "Oda Servisi", 1500m, 1 },
                    { 3, new DateTime(2025, 4, 1, 23, 46, 19, 743, DateTimeKind.Local).AddTicks(4715), null, "Minibardaki içecekler ve atıştırmalıklar dahil.", null, "Minibar Kullanımı", 1000m, 1 },
                    { 4, new DateTime(2025, 4, 1, 23, 46, 19, 743, DateTimeKind.Local).AddTicks(4717), null, "Gidiş-dönüş özel araç transferi.", null, "Havalimanı Transferi", 5000m, 1 },
                    { 5, new DateTime(2025, 4, 1, 23, 46, 19, 743, DateTimeKind.Local).AddTicks(4718), null, "Konaklama süresince ücretsiz çamaşır ve kuru temizleme hizmeti.", null, "Çamaşırhane Hizmeti", 500m, 1 },
                    { 6, new DateTime(2025, 4, 1, 23, 46, 19, 743, DateTimeKind.Local).AddTicks(4722), null, "Ekstra günlük temizlik ve hijyen paketi.", null, "Günlük Oda Temizliği", 500m, 1 },
                    { 7, new DateTime(2025, 4, 1, 23, 46, 19, 743, DateTimeKind.Local).AddTicks(4724), null, "Özel şezlong ve plaj hizmetleri.", null, "Özel Plaj Alanı", 7500m, 1 }
                });

            migrationBuilder.InsertData(
                table: "Packages",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Description", "ModifiedDate", "Name", "PriceMultiplier", "Status" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 4, 1, 23, 46, 19, 743, DateTimeKind.Local).AddTicks(4674), null, "Kahvaltı, öğle ve akşam yemeği dahil.", null, "Tam Pansiyon", 1.2m, 1 },
                    { 2, new DateTime(2025, 4, 1, 23, 46, 19, 743, DateTimeKind.Local).AddTicks(4677), null, "Tüm yemekler, alkollü-alkolsüz içecekler ve otelin sunduğu belirli hizmetler dahil.", null, "Her Şey Dahil", 1.5m, 1 }
                });

            migrationBuilder.InsertData(
                table: "RoomTypes",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Description", "ModifiedDate", "Name", "Status" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 4, 1, 23, 46, 19, 664, DateTimeKind.Local).AddTicks(5728), null, "1 adet tek kişilik yatak. Balkon ve minibar bulunmaz. Klima, TV, saç kurutma makinesi ve WiFi mevcuttur.", null, "Tek Kişilik", 1 },
                    { 2, new DateTime(2025, 4, 1, 23, 46, 19, 664, DateTimeKind.Local).AddTicks(5739), null, "1 adet büyük (duble) yatak. Klima, TV, saç kurutma makinesi ve WiFi mevcuttur.", null, "Çift Kişilik (Duble)", 1 },
                    { 3, new DateTime(2025, 4, 1, 23, 46, 19, 664, DateTimeKind.Local).AddTicks(5741), null, "2 adet tek kişilik yatak. Klima, TV, saç kurutma makinesi ve WiFi mevcuttur.", null, "Çift Kişilik (Tek Kişilik 2 Yataklı)", 1 },
                    { 4, new DateTime(2025, 4, 1, 23, 46, 19, 664, DateTimeKind.Local).AddTicks(5742), null, "3 adet tek kişilik yatak.  Klima, TV, saç kurutma makinesi ve WiFi mevcuttur.", null, "Üç Kişilik (Tek Kişilik 3 Yataklı)", 1 },
                    { 5, new DateTime(2025, 4, 1, 23, 46, 19, 664, DateTimeKind.Local).AddTicks(5743), null, "Bir tek bir duble yatak.  Klima, TV, saç kurutma makinesi ve WiFi mevcuttur.", null, "Üç Kişilik (1 Tek, 1 Duble Yataklı)", 1 },
                    { 6, new DateTime(2025, 4, 1, 23, 46, 19, 664, DateTimeKind.Local).AddTicks(5745), null, "1 adet büyük (duble) yatak + 2 adet tek kişilik yatak. Klima, TV, saç kurutma makinesi ve WiFi mevcuttur.", null, "Dört Kişilik", 1 },
                    { 7, new DateTime(2025, 4, 1, 23, 46, 19, 664, DateTimeKind.Local).AddTicks(5746), null, "Geniş ve lüks oda. Özel oturma alanı, büyük yatak, balkon, minibar, özel banyo ve lüks hizmetler. Klima, TV, saç kurutma makinesi, WiFi ve özel hizmetler mevcuttur.", null, "Kral Dairesi", 1 }
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
                    { 1, new DateTime(2025, 4, 1, 23, 46, 19, 664, DateTimeKind.Local).AddTicks(5816), null, 1, true, false, true, false, true, true, null, 1000m, "100", 1, 1, 1 },
                    { 2, new DateTime(2025, 4, 1, 23, 46, 19, 664, DateTimeKind.Local).AddTicks(5819), null, 1, true, false, true, false, true, true, null, 1000m, "101", 1, 1, 1 },
                    { 3, new DateTime(2025, 4, 1, 23, 46, 19, 664, DateTimeKind.Local).AddTicks(5820), null, 1, true, false, true, false, true, true, null, 1000m, "102", 1, 1, 1 },
                    { 4, new DateTime(2025, 4, 1, 23, 46, 19, 664, DateTimeKind.Local).AddTicks(5821), null, 1, true, false, true, false, true, true, null, 1000m, "103", 1, 1, 1 },
                    { 5, new DateTime(2025, 4, 1, 23, 46, 19, 664, DateTimeKind.Local).AddTicks(5822), null, 1, true, false, true, false, true, true, null, 1000m, "104", 1, 1, 1 },
                    { 6, new DateTime(2025, 4, 1, 23, 46, 19, 664, DateTimeKind.Local).AddTicks(5823), null, 1, true, false, true, false, true, true, null, 1000m, "105", 1, 1, 1 },
                    { 7, new DateTime(2025, 4, 1, 23, 46, 19, 664, DateTimeKind.Local).AddTicks(5824), null, 1, true, false, true, false, true, true, null, 1000m, "106", 1, 1, 1 },
                    { 8, new DateTime(2025, 4, 1, 23, 46, 19, 664, DateTimeKind.Local).AddTicks(5825), null, 1, true, false, true, false, true, true, null, 1000m, "107", 1, 1, 1 },
                    { 9, new DateTime(2025, 4, 1, 23, 46, 19, 664, DateTimeKind.Local).AddTicks(5826), null, 1, true, false, true, false, true, true, null, 1000m, "108", 1, 1, 1 },
                    { 10, new DateTime(2025, 4, 1, 23, 46, 19, 664, DateTimeKind.Local).AddTicks(5827), null, 1, true, false, true, false, true, true, null, 1000m, "109", 1, 1, 1 },
                    { 11, new DateTime(2025, 4, 1, 23, 46, 19, 664, DateTimeKind.Local).AddTicks(5829), null, 1, true, false, true, false, true, true, null, 1500m, "110", 1, 4, 1 },
                    { 12, new DateTime(2025, 4, 1, 23, 46, 19, 664, DateTimeKind.Local).AddTicks(5830), null, 1, true, false, true, false, true, true, null, 1500m, "111", 1, 4, 1 },
                    { 13, new DateTime(2025, 4, 1, 23, 46, 19, 664, DateTimeKind.Local).AddTicks(5831), null, 1, true, false, true, false, true, true, null, 1500m, "112", 1, 4, 1 },
                    { 14, new DateTime(2025, 4, 1, 23, 46, 19, 664, DateTimeKind.Local).AddTicks(5831), null, 1, true, false, true, false, true, true, null, 1500m, "113", 1, 4, 1 },
                    { 15, new DateTime(2025, 4, 1, 23, 46, 19, 664, DateTimeKind.Local).AddTicks(5832), null, 1, true, false, true, false, true, true, null, 1500m, "114", 1, 4, 1 },
                    { 16, new DateTime(2025, 4, 1, 23, 46, 19, 664, DateTimeKind.Local).AddTicks(5832), null, 1, true, false, true, false, true, true, null, 1500m, "115", 1, 4, 1 },
                    { 17, new DateTime(2025, 4, 1, 23, 46, 19, 664, DateTimeKind.Local).AddTicks(5833), null, 1, true, false, true, false, true, true, null, 1500m, "116", 1, 4, 1 },
                    { 18, new DateTime(2025, 4, 1, 23, 46, 19, 664, DateTimeKind.Local).AddTicks(5834), null, 1, true, false, true, false, true, true, null, 1500m, "117", 1, 4, 1 },
                    { 19, new DateTime(2025, 4, 1, 23, 46, 19, 664, DateTimeKind.Local).AddTicks(5835), null, 1, true, false, true, false, true, true, null, 1500m, "118", 1, 4, 1 },
                    { 20, new DateTime(2025, 4, 1, 23, 46, 19, 664, DateTimeKind.Local).AddTicks(5893), null, 1, true, false, true, false, true, true, null, 1500m, "119", 1, 4, 1 },
                    { 21, new DateTime(2025, 4, 1, 23, 46, 19, 664, DateTimeKind.Local).AddTicks(5895), null, 2, true, false, true, false, true, true, null, 1200m, "200", 1, 1, 1 },
                    { 22, new DateTime(2025, 4, 1, 23, 46, 19, 664, DateTimeKind.Local).AddTicks(5896), null, 2, true, false, true, false, true, true, null, 1200m, "201", 1, 1, 1 },
                    { 23, new DateTime(2025, 4, 1, 23, 46, 19, 664, DateTimeKind.Local).AddTicks(5897), null, 2, true, false, true, false, true, true, null, 1200m, "202", 1, 1, 1 },
                    { 24, new DateTime(2025, 4, 1, 23, 46, 19, 664, DateTimeKind.Local).AddTicks(5898), null, 2, true, false, true, false, true, true, null, 1200m, "203", 1, 1, 1 },
                    { 25, new DateTime(2025, 4, 1, 23, 46, 19, 664, DateTimeKind.Local).AddTicks(5898), null, 2, true, false, true, false, true, true, null, 1200m, "204", 1, 1, 1 },
                    { 26, new DateTime(2025, 4, 1, 23, 46, 19, 664, DateTimeKind.Local).AddTicks(5899), null, 2, true, false, true, false, true, true, null, 1200m, "205", 1, 1, 1 },
                    { 27, new DateTime(2025, 4, 1, 23, 46, 19, 664, DateTimeKind.Local).AddTicks(5899), null, 2, true, false, true, false, true, true, null, 1200m, "206", 1, 1, 1 },
                    { 28, new DateTime(2025, 4, 1, 23, 46, 19, 664, DateTimeKind.Local).AddTicks(5900), null, 2, true, false, true, false, true, true, null, 1200m, "207", 1, 1, 1 },
                    { 29, new DateTime(2025, 4, 1, 23, 46, 19, 664, DateTimeKind.Local).AddTicks(5901), null, 2, true, false, true, false, true, true, null, 1200m, "208", 1, 1, 1 },
                    { 30, new DateTime(2025, 4, 1, 23, 46, 19, 664, DateTimeKind.Local).AddTicks(5901), null, 2, true, false, true, false, true, true, null, 1200m, "209", 1, 1, 1 },
                    { 31, new DateTime(2025, 4, 1, 23, 46, 19, 664, DateTimeKind.Local).AddTicks(5903), null, 2, true, false, true, true, true, true, null, 1800m, "210", 1, 3, 1 },
                    { 32, new DateTime(2025, 4, 1, 23, 46, 19, 664, DateTimeKind.Local).AddTicks(5904), null, 2, true, false, true, true, true, true, null, 1800m, "211", 1, 3, 1 },
                    { 33, new DateTime(2025, 4, 1, 23, 46, 19, 664, DateTimeKind.Local).AddTicks(5904), null, 2, true, false, true, true, true, true, null, 1800m, "212", 1, 3, 1 },
                    { 34, new DateTime(2025, 4, 1, 23, 46, 19, 664, DateTimeKind.Local).AddTicks(5906), null, 2, true, false, true, true, true, true, null, 1800m, "213", 1, 3, 1 },
                    { 35, new DateTime(2025, 4, 1, 23, 46, 19, 664, DateTimeKind.Local).AddTicks(5907), null, 2, true, false, true, true, true, true, null, 1800m, "214", 1, 3, 1 },
                    { 36, new DateTime(2025, 4, 1, 23, 46, 19, 664, DateTimeKind.Local).AddTicks(5907), null, 2, true, false, true, true, true, true, null, 1800m, "215", 1, 3, 1 },
                    { 37, new DateTime(2025, 4, 1, 23, 46, 19, 664, DateTimeKind.Local).AddTicks(5908), null, 2, true, false, true, true, true, true, null, 1800m, "216", 1, 3, 1 },
                    { 38, new DateTime(2025, 4, 1, 23, 46, 19, 664, DateTimeKind.Local).AddTicks(5908), null, 2, true, false, true, true, true, true, null, 1800m, "217", 1, 3, 1 },
                    { 39, new DateTime(2025, 4, 1, 23, 46, 19, 664, DateTimeKind.Local).AddTicks(5909), null, 2, true, false, true, true, true, true, null, 1800m, "218", 1, 3, 1 },
                    { 40, new DateTime(2025, 4, 1, 23, 46, 19, 664, DateTimeKind.Local).AddTicks(5909), null, 2, true, false, true, true, true, true, null, 1800m, "219", 1, 3, 1 },
                    { 41, new DateTime(2025, 4, 1, 23, 46, 19, 664, DateTimeKind.Local).AddTicks(5913), null, 3, true, true, true, true, true, true, null, 2200m, "300", 1, 2, 1 },
                    { 42, new DateTime(2025, 4, 1, 23, 46, 19, 664, DateTimeKind.Local).AddTicks(5914), null, 3, true, true, true, true, true, true, null, 2200m, "301", 1, 2, 1 },
                    { 43, new DateTime(2025, 4, 1, 23, 46, 19, 664, DateTimeKind.Local).AddTicks(5915), null, 3, true, true, true, true, true, true, null, 2200m, "302", 1, 2, 1 },
                    { 44, new DateTime(2025, 4, 1, 23, 46, 19, 664, DateTimeKind.Local).AddTicks(5916), null, 3, true, true, true, true, true, true, null, 2200m, "303", 1, 2, 1 },
                    { 45, new DateTime(2025, 4, 1, 23, 46, 19, 664, DateTimeKind.Local).AddTicks(5916), null, 3, true, true, true, true, true, true, null, 2200m, "304", 1, 2, 1 },
                    { 46, new DateTime(2025, 4, 1, 23, 46, 19, 664, DateTimeKind.Local).AddTicks(5917), null, 3, true, true, true, true, true, true, null, 2200m, "305", 1, 2, 1 },
                    { 47, new DateTime(2025, 4, 1, 23, 46, 19, 664, DateTimeKind.Local).AddTicks(5917), null, 3, true, true, true, true, true, true, null, 2200m, "306", 1, 2, 1 },
                    { 48, new DateTime(2025, 4, 1, 23, 46, 19, 664, DateTimeKind.Local).AddTicks(5918), null, 3, true, true, true, true, true, true, null, 2200m, "307", 1, 2, 1 },
                    { 49, new DateTime(2025, 4, 1, 23, 46, 19, 664, DateTimeKind.Local).AddTicks(5919), null, 3, true, true, true, true, true, true, null, 2200m, "308", 1, 2, 1 },
                    { 50, new DateTime(2025, 4, 1, 23, 46, 19, 664, DateTimeKind.Local).AddTicks(5919), null, 3, true, true, true, true, true, true, null, 2200m, "309", 1, 2, 1 },
                    { 51, new DateTime(2025, 4, 1, 23, 46, 19, 664, DateTimeKind.Local).AddTicks(5921), null, 3, true, true, true, true, true, true, null, 2500m, "310", 1, 5, 1 },
                    { 52, new DateTime(2025, 4, 1, 23, 46, 19, 664, DateTimeKind.Local).AddTicks(5923), null, 3, true, true, true, true, true, true, null, 2500m, "311", 1, 5, 1 },
                    { 53, new DateTime(2025, 4, 1, 23, 46, 19, 664, DateTimeKind.Local).AddTicks(5923), null, 3, true, true, true, true, true, true, null, 2500m, "312", 1, 5, 1 },
                    { 54, new DateTime(2025, 4, 1, 23, 46, 19, 664, DateTimeKind.Local).AddTicks(5924), null, 3, true, true, true, true, true, true, null, 2500m, "313", 1, 5, 1 },
                    { 55, new DateTime(2025, 4, 1, 23, 46, 19, 664, DateTimeKind.Local).AddTicks(5924), null, 3, true, true, true, true, true, true, null, 2500m, "314", 1, 5, 1 },
                    { 56, new DateTime(2025, 4, 1, 23, 46, 19, 664, DateTimeKind.Local).AddTicks(5925), null, 3, true, true, true, true, true, true, null, 2500m, "315", 1, 5, 1 },
                    { 57, new DateTime(2025, 4, 1, 23, 46, 19, 664, DateTimeKind.Local).AddTicks(5925), null, 3, true, true, true, true, true, true, null, 2500m, "316", 1, 5, 1 },
                    { 58, new DateTime(2025, 4, 1, 23, 46, 19, 664, DateTimeKind.Local).AddTicks(5926), null, 3, true, true, true, true, true, true, null, 2500m, "317", 1, 5, 1 },
                    { 59, new DateTime(2025, 4, 1, 23, 46, 19, 664, DateTimeKind.Local).AddTicks(5926), null, 3, true, true, true, true, true, true, null, 2500m, "318", 1, 5, 1 },
                    { 60, new DateTime(2025, 4, 1, 23, 46, 19, 664, DateTimeKind.Local).AddTicks(5927), null, 3, true, true, true, true, true, true, null, 2500m, "319", 1, 5, 1 },
                    { 61, new DateTime(2025, 4, 1, 23, 46, 19, 664, DateTimeKind.Local).AddTicks(5929), null, 4, true, true, true, true, true, true, null, 2800m, "400", 1, 2, 1 },
                    { 62, new DateTime(2025, 4, 1, 23, 46, 19, 664, DateTimeKind.Local).AddTicks(5930), null, 4, true, true, true, true, true, true, null, 2800m, "401", 1, 2, 1 },
                    { 63, new DateTime(2025, 4, 1, 23, 46, 19, 664, DateTimeKind.Local).AddTicks(5931), null, 4, true, true, true, true, true, true, null, 2800m, "402", 1, 2, 1 },
                    { 64, new DateTime(2025, 4, 1, 23, 46, 19, 664, DateTimeKind.Local).AddTicks(5931), null, 4, true, true, true, true, true, true, null, 2800m, "403", 1, 2, 1 },
                    { 65, new DateTime(2025, 4, 1, 23, 46, 19, 664, DateTimeKind.Local).AddTicks(5932), null, 4, true, true, true, true, true, true, null, 2800m, "404", 1, 2, 1 },
                    { 66, new DateTime(2025, 4, 1, 23, 46, 19, 664, DateTimeKind.Local).AddTicks(5979), null, 4, true, true, true, true, true, true, null, 2800m, "405", 1, 2, 1 },
                    { 67, new DateTime(2025, 4, 1, 23, 46, 19, 664, DateTimeKind.Local).AddTicks(5979), null, 4, true, true, true, true, true, true, null, 2800m, "406", 1, 2, 1 },
                    { 68, new DateTime(2025, 4, 1, 23, 46, 19, 664, DateTimeKind.Local).AddTicks(5980), null, 4, true, true, true, true, true, true, null, 2800m, "407", 1, 2, 1 },
                    { 69, new DateTime(2025, 4, 1, 23, 46, 19, 664, DateTimeKind.Local).AddTicks(5981), null, 4, true, true, true, true, true, true, null, 2800m, "408", 1, 2, 1 },
                    { 70, new DateTime(2025, 4, 1, 23, 46, 19, 664, DateTimeKind.Local).AddTicks(5981), null, 4, true, true, true, true, true, true, null, 2800m, "409", 1, 2, 1 },
                    { 71, new DateTime(2025, 4, 1, 23, 46, 19, 664, DateTimeKind.Local).AddTicks(5984), null, 4, true, true, true, true, true, true, null, 3500m, "410", 1, 6, 1 },
                    { 72, new DateTime(2025, 4, 1, 23, 46, 19, 664, DateTimeKind.Local).AddTicks(5985), null, 4, true, true, true, true, true, true, null, 3500m, "411", 1, 6, 1 },
                    { 73, new DateTime(2025, 4, 1, 23, 46, 19, 664, DateTimeKind.Local).AddTicks(5985), null, 4, true, true, true, true, true, true, null, 3500m, "412", 1, 6, 1 },
                    { 74, new DateTime(2025, 4, 1, 23, 46, 19, 664, DateTimeKind.Local).AddTicks(5986), null, 4, true, true, true, true, true, true, null, 3500m, "413", 1, 6, 1 },
                    { 75, new DateTime(2025, 4, 1, 23, 46, 19, 664, DateTimeKind.Local).AddTicks(5987), null, 4, true, true, true, true, true, true, null, 3500m, "414", 1, 6, 1 },
                    { 76, new DateTime(2025, 4, 1, 23, 46, 19, 664, DateTimeKind.Local).AddTicks(5987), null, 4, true, true, true, true, true, true, null, 3500m, "415", 1, 6, 1 },
                    { 77, new DateTime(2025, 4, 1, 23, 46, 19, 664, DateTimeKind.Local).AddTicks(5989), null, 4, true, true, true, true, true, true, null, 10000m, "417", 1, 7, 1 }
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
