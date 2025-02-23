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
                    { 1, "ca02fc25-2c51-4605-a0c6-9a2dbb0b7894", "Admin", "ADMIN" },
                    { 2, "21398d80-e1c0-4589-8010-c1a1674cac9a", "Member", "MEMBER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ActivationCode", "ConcurrencyStamp", "CreatedDate", "DeletedDate", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "ModifiedDate", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Status", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { 1, 0, new Guid("00000000-0000-0000-0000-000000000000"), "52e50b97-169e-421e-8442-c8fcfa59b852", new DateTime(2025, 2, 23, 15, 23, 44, 202, DateTimeKind.Local).AddTicks(9949), null, "bilgehotel@email.com", true, false, null, null, "BILGEHOTEL@EMAIL.COM", "BILGEHOTEL", "AQAAAAIAAYagAAAAEBYO5aGkX2P3211q6nzuNAQlxMxAcfvmNd/hq+du/3ceOHUR2IwLWmKJfBUopj5XHw==", null, false, "b95ef230-c9dd-4de3-a032-b68c66677764", 1, false, "bilgehotel" },
                    { 2, 0, new Guid("00000000-0000-0000-0000-000000000000"), "2fa1372d-11aa-4b21-a9d8-776325b74ae7", new DateTime(2025, 2, 23, 15, 23, 44, 246, DateTimeKind.Local).AddTicks(4468), null, "testmember@email.com", true, false, null, null, "TESTMEMBER@EMAIL.COM", "TESTMEMBER", "AQAAAAIAAYagAAAAEGhPrCvmfNl8lZQo8KfaFwBL3U9bseVwUhTsioL4n5qDBLQxZa+YuQtMOL4EVjJdog==", null, false, "35698620-3ad6-41e5-97f2-1b3c4f54c833", 1, false, "testmember" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Address", "BirthDate", "CreatedDate", "DeletedDate", "FirstName", "HireDate", "LastName", "ModifiedDate", "PhoneNumber", "Salary", "Shift", "Status" },
                values: new object[,]
                {
                    { 1, "Bahçe Sokak 0, Bilecik, Gambiya", new DateTime(1972, 12, 26, 21, 22, 47, 519, DateTimeKind.Local).AddTicks(2467), new DateTime(2025, 2, 23, 15, 23, 44, 163, DateTimeKind.Local).AddTicks(2080), null, "Katunkız", new DateTime(2019, 7, 2, 8, 5, 48, 381, DateTimeKind.Local).AddTicks(8401), "Pekkan", null, "+90-706-965-8-201", 123.23m, 1, 1 },
                    { 2, "Tevfik Fikret Caddesi 225, Mardin, Grönland", new DateTime(1986, 4, 29, 13, 12, 4, 466, DateTimeKind.Local).AddTicks(4776), new DateTime(2025, 2, 23, 15, 23, 44, 163, DateTimeKind.Local).AddTicks(2186), null, "Badabul", new DateTime(2015, 7, 13, 8, 7, 6, 27, DateTimeKind.Local).AddTicks(1626), "Tokatlıoğlu", null, "+90-259-255-18-12", 152.61m, 1, 1 },
                    { 3, "Namık Kemal Caddesi 7, Hakkari, İtalya", new DateTime(1985, 1, 8, 2, 19, 19, 725, DateTimeKind.Local).AddTicks(3002), new DateTime(2025, 2, 23, 15, 23, 44, 163, DateTimeKind.Local).AddTicks(2246), null, "Begine", new DateTime(2017, 1, 24, 9, 56, 58, 272, DateTimeKind.Local).AddTicks(8922), "Dağdaş", null, "+90-161-885-6-376", 120.57m, 3, 1 },
                    { 4, "Güven Yaka Sokak 14a, Çankırı, Gürcistan H", new DateTime(2004, 3, 9, 1, 38, 3, 728, DateTimeKind.Local).AddTicks(3984), new DateTime(2025, 2, 23, 15, 23, 44, 163, DateTimeKind.Local).AddTicks(2333), null, "Buyan", new DateTime(2015, 12, 15, 8, 31, 52, 539, DateTimeKind.Local).AddTicks(1044), "Abadan", null, "+90-301-851-4-372", 148.87m, 3, 1 },
                    { 5, "Ülkü Sokak 25a, Karaman, Kuzey Kore", new DateTime(1990, 4, 4, 11, 56, 5, 762, DateTimeKind.Local).AddTicks(8671), new DateTime(2025, 2, 23, 15, 23, 44, 163, DateTimeKind.Local).AddTicks(2414), null, "Adlıbeğ", new DateTime(2018, 4, 11, 9, 59, 24, 624, DateTimeKind.Local).AddTicks(4021), "Pekkan", null, "+90-864-424-11-73", 127.43m, 1, 1 },
                    { 6, "Fatih Sokak  96, İçel (Mersin), Hollanda Antilleri", new DateTime(1997, 11, 25, 20, 8, 26, 187, DateTimeKind.Local).AddTicks(723), new DateTime(2025, 2, 23, 15, 23, 44, 163, DateTimeKind.Local).AddTicks(2499), null, "Altuga", new DateTime(2014, 8, 21, 6, 14, 0, 332, DateTimeKind.Local).AddTicks(9501), "Demirbaş", null, "+90-364-429-6-928", 157.86m, 2, 1 },
                    { 7, "İsmet Paşa Caddesi 04b, Bolu, Namibia", new DateTime(1999, 9, 9, 14, 59, 51, 113, DateTimeKind.Local).AddTicks(103), new DateTime(2025, 2, 23, 15, 23, 44, 163, DateTimeKind.Local).AddTicks(2560), null, "Barkdoğdu", new DateTime(2020, 9, 29, 13, 45, 45, 237, DateTimeKind.Local).AddTicks(1376), "Ağaoğlu", null, "+90-000-697-13-09", 135.28m, 2, 1 },
                    { 8, "Fatih Sokak  73, Çankırı, İran", new DateTime(1992, 12, 31, 10, 50, 39, 965, DateTimeKind.Local).AddTicks(4471), new DateTime(2025, 2, 23, 15, 23, 44, 163, DateTimeKind.Local).AddTicks(2648), null, "Atakağan", new DateTime(2017, 5, 12, 8, 6, 0, 75, DateTimeKind.Local).AddTicks(9492), "Nebioğlu", null, "+90-945-337-61-66", 112.54m, 2, 1 },
                    { 9, "Sarıkaya Caddesi 0, Bingöl, Azerbaycan", new DateTime(1976, 4, 4, 6, 21, 41, 531, DateTimeKind.Local).AddTicks(6791), new DateTime(2025, 2, 23, 15, 23, 44, 163, DateTimeKind.Local).AddTicks(2722), null, "Böge", new DateTime(2017, 3, 21, 8, 3, 5, 793, DateTimeKind.Local).AddTicks(4596), "Menemencioğlu", null, "+90-006-059-3-143", 114.14m, 1, 1 },
                    { 10, "Harman Altı Sokak 76, Rize, Somali", new DateTime(1978, 10, 15, 13, 7, 6, 848, DateTimeKind.Local).AddTicks(968), new DateTime(2025, 2, 23, 15, 23, 44, 163, DateTimeKind.Local).AddTicks(2778), null, "Kırçiçek", new DateTime(2016, 3, 8, 22, 41, 52, 709, DateTimeKind.Local).AddTicks(8350), "Baturalp", null, "+90-259-177-30-60", 117.58m, 2, 1 },
                    { 11, "Dağınık Evler Sokak 51b, Karabük, Özbekistan", new DateTime(1967, 7, 8, 20, 3, 38, 355, DateTimeKind.Local).AddTicks(2004), new DateTime(2025, 2, 23, 15, 23, 44, 163, DateTimeKind.Local).AddTicks(2863), null, "Gülegen", new DateTime(2020, 3, 1, 12, 33, 18, 458, DateTimeKind.Local).AddTicks(7187), "Erkekli", null, "+90-699-760-1-031", 128.12m, 2, 1 },
                    { 12, "Okul Sokak 69, Erzurum, Tayvan", new DateTime(1973, 1, 7, 3, 57, 48, 605, DateTimeKind.Local).AddTicks(6086), new DateTime(2025, 2, 23, 15, 23, 44, 163, DateTimeKind.Local).AddTicks(2965), null, "Bayraç", new DateTime(2021, 4, 21, 19, 29, 19, 782, DateTimeKind.Local).AddTicks(8006), "Orbay", null, "+90-352-069-7-165", 138.66m, 2, 1 },
                    { 13, "Kekeçoğlu Sokak 54a, Edirne, İspanya", new DateTime(1987, 1, 30, 20, 1, 0, 720, DateTimeKind.Local).AddTicks(7556), new DateTime(2025, 2, 23, 15, 23, 44, 163, DateTimeKind.Local).AddTicks(3045), null, "Arbay", new DateTime(2015, 3, 15, 20, 18, 58, 467, DateTimeKind.Local).AddTicks(1405), "Nalbantoğlu", null, "+90-454-391-4-163", 132.51m, 1, 1 },
                    { 14, "Sarıkaya Caddesi 36a, Bilecik, Ekvator", new DateTime(2001, 9, 15, 13, 34, 43, 4, DateTimeKind.Local).AddTicks(2935), new DateTime(2025, 2, 23, 15, 23, 44, 163, DateTimeKind.Local).AddTicks(3090), null, "Bergü", new DateTime(2023, 11, 5, 23, 54, 57, 629, DateTimeKind.Local).AddTicks(605), "Tokatlıoğlu", null, "+90-257-470-67-40", 137.19m, 1, 1 },
                    { 15, "Harman Altı Sokak 730, Van, Ruanda", new DateTime(2003, 3, 27, 9, 1, 37, 187, DateTimeKind.Local).AddTicks(1194), new DateTime(2025, 2, 23, 15, 23, 44, 163, DateTimeKind.Local).AddTicks(3162), null, "Işık", new DateTime(2017, 1, 7, 22, 2, 41, 480, DateTimeKind.Local).AddTicks(9700), "Gürmen", null, "+90-074-151-0-223", 110.70m, 2, 1 },
                    { 16, "Mevlana Sokak 100, Tekirdağ, Tonga", new DateTime(2003, 1, 22, 11, 30, 7, 938, DateTimeKind.Local).AddTicks(8713), new DateTime(2025, 2, 23, 15, 23, 44, 163, DateTimeKind.Local).AddTicks(3233), null, "Baydur", new DateTime(2014, 5, 18, 9, 23, 19, 890, DateTimeKind.Local).AddTicks(7121), "Tahincioğlu", null, "+90-589-019-58-00", 129.57m, 1, 1 },
                    { 17, "Dağınık Evler Sokak 7, Kütahya, Monako", new DateTime(1971, 4, 2, 2, 26, 14, 485, DateTimeKind.Local).AddTicks(6983), new DateTime(2025, 2, 23, 15, 23, 44, 163, DateTimeKind.Local).AddTicks(3308), null, "Adlıbeğ", new DateTime(2022, 10, 14, 7, 3, 2, 279, DateTimeKind.Local).AddTicks(4147), "Tuğluk", null, "+90-779-366-4-999", 124.27m, 1, 1 },
                    { 18, "Barış Sokak 923, Antalya, İsviçre", new DateTime(2005, 8, 12, 3, 5, 38, 780, DateTimeKind.Local).AddTicks(7189), new DateTime(2025, 2, 23, 15, 23, 44, 163, DateTimeKind.Local).AddTicks(3361), null, "Günay", new DateTime(2018, 6, 11, 15, 27, 38, 354, DateTimeKind.Local).AddTicks(1425), "Sepetçi", null, "+90-215-709-7-069", 116.96m, 1, 1 },
                    { 19, "Barış Sokak 28c, Hatay, Fransız Guyanası", new DateTime(2002, 1, 17, 22, 16, 3, 226, DateTimeKind.Local).AddTicks(2964), new DateTime(2025, 2, 23, 15, 23, 44, 163, DateTimeKind.Local).AddTicks(3438), null, "Ebkızı", new DateTime(2017, 4, 22, 16, 35, 24, 155, DateTimeKind.Local).AddTicks(5735), "Paksüt", null, "+90-751-521-61-23", 141.46m, 2, 1 },
                    { 20, "Harman Yolu Sokak  578, Çanakkale, Panama", new DateTime(1985, 1, 10, 15, 34, 31, 453, DateTimeKind.Local).AddTicks(9137), new DateTime(2025, 2, 23, 15, 23, 44, 163, DateTimeKind.Local).AddTicks(3506), null, "Gökbörü", new DateTime(2024, 1, 16, 6, 17, 50, 771, DateTimeKind.Local).AddTicks(512), "Toraman", null, "+90-900-455-6-928", 149.15m, 2, 1 },
                    { 21, "Namık Kemal Caddesi 930, Zonguldak, Guyana", new DateTime(1993, 1, 4, 20, 12, 39, 437, DateTimeKind.Local).AddTicks(3820), new DateTime(2025, 2, 23, 15, 23, 44, 163, DateTimeKind.Local).AddTicks(3581), null, "Baltar", new DateTime(2021, 12, 27, 3, 29, 40, 91, DateTimeKind.Local).AddTicks(1454), "Akışık", null, "+90-452-072-7-511", 165.08m, 2, 1 },
                    { 22, "Nalbant Sokak 86a, Nevşehir, El Salvador", new DateTime(1969, 10, 25, 4, 24, 35, 205, DateTimeKind.Local).AddTicks(5710), new DateTime(2025, 2, 23, 15, 23, 44, 163, DateTimeKind.Local).AddTicks(3629), null, "İldike", new DateTime(2014, 7, 27, 16, 1, 51, 102, DateTimeKind.Local).AddTicks(5779), "Akyüz", null, "+90-908-934-4-482", 168.64m, 1, 1 },
                    { 23, "Dar Sokak 88c, Erzurum, Birmanya (Myanmar)", new DateTime(2001, 9, 29, 16, 25, 8, 357, DateTimeKind.Local).AddTicks(4746), new DateTime(2025, 2, 23, 15, 23, 44, 163, DateTimeKind.Local).AddTicks(3711), null, "Alpilig", new DateTime(2021, 9, 2, 16, 56, 45, 689, DateTimeKind.Local).AddTicks(7111), "Gürmen", null, "+90-629-118-40-95", 163.65m, 1, 1 },
                    { 24, "Ali Çetinkaya Caddesi 84b, Şanlıurfa, Brunei", new DateTime(1985, 4, 16, 0, 3, 7, 990, DateTimeKind.Local).AddTicks(5975), new DateTime(2025, 2, 23, 15, 23, 44, 163, DateTimeKind.Local).AddTicks(3786), null, "Kımızın", new DateTime(2020, 6, 5, 14, 25, 58, 504, DateTimeKind.Local).AddTicks(746), "Velioğlu", null, "+90-089-577-0-100", 167.18m, 1, 1 },
                    { 25, "Barış Sokak 266, Isparta, Mikronezya", new DateTime(1977, 9, 16, 4, 31, 3, 63, DateTimeKind.Local).AddTicks(8081), new DateTime(2025, 2, 23, 15, 23, 44, 163, DateTimeKind.Local).AddTicks(3836), null, "Atıgay", new DateTime(2017, 11, 22, 0, 28, 15, 330, DateTimeKind.Local).AddTicks(1092), "Arıcan", null, "+90-777-339-07-15", 144.14m, 2, 1 },
                    { 26, "Okul Sokak 8, Diyarbakır, Gambiya", new DateTime(2002, 11, 28, 9, 4, 25, 421, DateTimeKind.Local).AddTicks(5197), new DateTime(2025, 2, 23, 15, 23, 44, 163, DateTimeKind.Local).AddTicks(3906), null, "Alpata", new DateTime(2014, 10, 14, 3, 59, 35, 355, DateTimeKind.Local).AddTicks(1677), "Saygıner", null, "+90-209-379-0-447", 130.31m, 1, 1 },
                    { 27, "Menekşe Sokak 51, Samsun, Burkina Faso", new DateTime(1987, 11, 19, 12, 27, 39, 72, DateTimeKind.Local).AddTicks(1474), new DateTime(2025, 2, 23, 15, 23, 44, 163, DateTimeKind.Local).AddTicks(3978), null, "Börüsengün", new DateTime(2017, 7, 23, 17, 4, 34, 499, DateTimeKind.Local).AddTicks(9919), "Erez", null, "+90-382-178-47-85", 169.00m, 1, 1 },
                    { 28, "Atatürk Bulvarı 8, Bingöl, Kazakistan", new DateTime(1987, 11, 21, 13, 44, 35, 390, DateTimeKind.Local).AddTicks(7152), new DateTime(2025, 2, 23, 15, 23, 44, 163, DateTimeKind.Local).AddTicks(4048), null, "Bukak", new DateTime(2017, 8, 27, 18, 11, 36, 461, DateTimeKind.Local).AddTicks(6145), "Abadan", null, "+90-998-876-79-06", 156.24m, 2, 1 },
                    { 29, "Kekeçoğlu Sokak 33c, İçel (Mersin), Kazakistan", new DateTime(1975, 5, 24, 5, 18, 38, 203, DateTimeKind.Local).AddTicks(4862), new DateTime(2025, 2, 23, 15, 23, 44, 163, DateTimeKind.Local).AddTicks(4097), null, "Alptegin", new DateTime(2019, 12, 14, 1, 5, 45, 172, DateTimeKind.Local).AddTicks(1193), "Atakol", null, "+90-726-371-9-338", 142.00m, 2, 1 },
                    { 30, "Bahçe Sokak 49a, İçel (Mersin), Galler", new DateTime(1971, 12, 9, 18, 34, 5, 307, DateTimeKind.Local).AddTicks(5763), new DateTime(2025, 2, 23, 15, 23, 44, 163, DateTimeKind.Local).AddTicks(4174), null, "Batrak", new DateTime(2020, 4, 7, 13, 8, 16, 151, DateTimeKind.Local).AddTicks(7416), "Özgörkey", null, "+90-893-134-3-576", 107.66m, 2, 1 },
                    { 31, "Namık Kemal Caddesi 03, Van, Porto Riko, Amerika", new DateTime(1982, 7, 29, 16, 5, 59, 287, DateTimeKind.Local).AddTicks(267), new DateTime(2025, 2, 23, 15, 23, 44, 163, DateTimeKind.Local).AddTicks(4243), null, "Alpaykağan", new DateTime(2016, 1, 19, 18, 54, 13, 476, DateTimeKind.Local).AddTicks(9235), "Erbay", null, "+90-125-635-4-909", 113.78m, 2, 1 },
                    { 32, "Okul Sokak 28c, Kırşehir, Gine", new DateTime(1989, 2, 4, 15, 14, 3, 233, DateTimeKind.Local).AddTicks(2820), new DateTime(2025, 2, 23, 15, 23, 44, 163, DateTimeKind.Local).AddTicks(4321), null, "Artuk", new DateTime(2022, 1, 8, 17, 42, 51, 698, DateTimeKind.Local).AddTicks(6152), "Abadan", null, "+90-748-745-16-26", 100.95m, 1, 1 },
                    { 33, "Sevgi Sokak 19b, Bolu, Bahama Adaları", new DateTime(1969, 2, 5, 14, 28, 20, 328, DateTimeKind.Local).AddTicks(7430), new DateTime(2025, 2, 23, 15, 23, 44, 163, DateTimeKind.Local).AddTicks(4369), null, "Güler", new DateTime(2015, 7, 25, 16, 51, 8, 845, DateTimeKind.Local).AddTicks(7445), "Yorulmaz", null, "+90-073-150-91-16", 121.08m, 1, 1 },
                    { 34, "Dar Sokak 69, Kars, Tayland", new DateTime(1969, 5, 19, 10, 23, 32, 563, DateTimeKind.Local).AddTicks(4809), new DateTime(2025, 2, 23, 15, 23, 44, 163, DateTimeKind.Local).AddTicks(4448), null, "Begil", new DateTime(2021, 9, 29, 18, 28, 29, 121, DateTimeKind.Local).AddTicks(7792), "Paksüt", null, "+90-973-496-61-34", 107.09m, 2, 1 },
                    { 35, "Sıran Söğüt Sokak 29b, Antalya, Ekvator Ginesi", new DateTime(1994, 9, 29, 13, 44, 20, 269, DateTimeKind.Local).AddTicks(242), new DateTime(2025, 2, 23, 15, 23, 44, 163, DateTimeKind.Local).AddTicks(4519), null, "Ekin", new DateTime(2014, 5, 21, 15, 47, 9, 744, DateTimeKind.Local).AddTicks(6648), "Aykaç", null, "+90-280-903-24-31", 112.67m, 2, 1 },
                    { 36, "Ergenekon Sokak   70a, İzmir, Togo", new DateTime(1993, 6, 17, 8, 34, 46, 549, DateTimeKind.Local).AddTicks(5065), new DateTime(2025, 2, 23, 15, 23, 44, 163, DateTimeKind.Local).AddTicks(4596), null, "Çölü", new DateTime(2014, 10, 11, 10, 43, 35, 836, DateTimeKind.Local).AddTicks(9766), "Kaplangı", null, "+90-265-690-51-56", 128.93m, 2, 1 },
                    { 37, "Atatürk Bulvarı 22b, Kastamonu, Tacikistan", new DateTime(1984, 7, 12, 17, 37, 44, 862, DateTimeKind.Local).AddTicks(2166), new DateTime(2025, 2, 23, 15, 23, 44, 163, DateTimeKind.Local).AddTicks(4644), null, "Bilgekülüçur", new DateTime(2022, 3, 2, 12, 48, 10, 176, DateTimeKind.Local).AddTicks(2395), "Kasapoğlu", null, "+90-746-548-4-196", 105.81m, 2, 1 },
                    { 38, "Köypınar Sokak 785, Kırşehir, Belçika", new DateTime(1977, 8, 29, 11, 8, 54, 793, DateTimeKind.Local).AddTicks(5190), new DateTime(2025, 2, 23, 15, 23, 44, 163, DateTimeKind.Local).AddTicks(4717), null, "Apa", new DateTime(2019, 2, 9, 6, 19, 16, 666, DateTimeKind.Local).AddTicks(2188), "Mayhoş", null, "+90-385-234-0-780", 113.58m, 2, 1 },
                    { 39, "Harman Yolu Sokak  347, Adana, Gabon", new DateTime(1997, 2, 9, 16, 4, 58, 949, DateTimeKind.Local).AddTicks(8924), new DateTime(2025, 2, 23, 15, 23, 44, 163, DateTimeKind.Local).AddTicks(4803), null, "Barça", new DateTime(2023, 5, 21, 8, 37, 44, 356, DateTimeKind.Local).AddTicks(4745), "Ertürk", null, "+90-373-358-6-416", 111.79m, 1, 1 },
                    { 40, "Tevfik Fikret Caddesi 817, Konya, Vallis ve Futuna, Fransa", new DateTime(1991, 5, 18, 0, 45, 8, 924, DateTimeKind.Local).AddTicks(3519), new DateTime(2025, 2, 23, 15, 23, 44, 163, DateTimeKind.Local).AddTicks(4850), null, "Esen", new DateTime(2022, 1, 24, 10, 4, 53, 53, DateTimeKind.Local).AddTicks(582), "Biçer", null, "+90-287-627-8-931", 109.01m, 2, 1 },
                    { 41, "Sıran Söğüt Sokak 0, Çorum, Niue, Yeni Zelanda", new DateTime(1982, 7, 31, 23, 40, 57, 623, DateTimeKind.Local).AddTicks(5777), new DateTime(2025, 2, 23, 15, 23, 44, 163, DateTimeKind.Local).AddTicks(4929), null, "Bağaalp", new DateTime(2022, 10, 24, 16, 11, 22, 482, DateTimeKind.Local).AddTicks(3006), "Küçükler", null, "+90-173-253-0-175", 109.26m, 2, 1 },
                    { 42, "Sarıkaya Caddesi 43, Aksaray, Slovakya", new DateTime(1972, 9, 29, 12, 50, 25, 520, DateTimeKind.Local).AddTicks(6627), new DateTime(2025, 2, 23, 15, 23, 44, 163, DateTimeKind.Local).AddTicks(5002), null, "İlbilge", new DateTime(2016, 9, 15, 22, 27, 2, 439, DateTimeKind.Local).AddTicks(2046), "Tekelioğlu", null, "+90-058-786-1-347", 119.60m, 1, 1 },
                    { 43, "Okul Sokak 23c, Diyarbakır, Kenya", new DateTime(1969, 1, 9, 9, 36, 57, 26, DateTimeKind.Local).AddTicks(8354), new DateTime(2025, 2, 23, 15, 23, 44, 163, DateTimeKind.Local).AddTicks(5077), null, "Anıl", new DateTime(2020, 2, 27, 9, 37, 51, 776, DateTimeKind.Local).AddTicks(5337), "Aclan", null, "+90-011-612-11-74", 155.56m, 3, 1 },
                    { 44, "İsmet Paşa Caddesi 69c, Denizli, Virgin Adaları, İngiltere", new DateTime(1974, 2, 8, 10, 40, 18, 242, DateTimeKind.Local).AddTicks(474), new DateTime(2025, 2, 23, 15, 23, 44, 163, DateTimeKind.Local).AddTicks(5133), null, "Gözde", new DateTime(2022, 9, 19, 11, 28, 45, 335, DateTimeKind.Local).AddTicks(4283), "Ayverdi", null, "+90-344-958-20-52", 166.29m, 2, 1 }
                });

            migrationBuilder.InsertData(
                table: "ExtraServices",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Description", "ModifiedDate", "Name", "Price", "Status" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 2, 23, 15, 23, 44, 246, DateTimeKind.Local).AddTicks(4858), null, "Günlük sınırsız spa kullanımı.", null, "Spa Kullanımı", 50m, 1 },
                    { 2, new DateTime(2025, 2, 23, 15, 23, 44, 246, DateTimeKind.Local).AddTicks(4860), null, "24 saat oda servisi. Tüm yemek siparişleri dahildir.", null, "Oda Servisi", 30m, 1 },
                    { 3, new DateTime(2025, 2, 23, 15, 23, 44, 246, DateTimeKind.Local).AddTicks(4862), null, "Minibardaki içecekler ve atıştırmalıklar dahil.", null, "Minibar Kullanımı", 20m, 1 },
                    { 4, new DateTime(2025, 2, 23, 15, 23, 44, 246, DateTimeKind.Local).AddTicks(4863), null, "Gidiş-dönüş özel araç transferi.", null, "Havalimanı Transferi", 100m, 1 },
                    { 5, new DateTime(2025, 2, 23, 15, 23, 44, 246, DateTimeKind.Local).AddTicks(4865), null, "Konaklama süresince ücretsiz çamaşır ve kuru temizleme hizmeti.", null, "Çamaşırhane Hizmeti", 40m, 1 },
                    { 6, new DateTime(2025, 2, 23, 15, 23, 44, 246, DateTimeKind.Local).AddTicks(4874), null, "Ekstra günlük temizlik ve hijyen paketi.", null, "Günlük Oda Temizliği", 25m, 1 },
                    { 7, new DateTime(2025, 2, 23, 15, 23, 44, 246, DateTimeKind.Local).AddTicks(4875), null, "Özel şezlong ve plaj hizmetleri.", null, "Özel Plaj Alanı", 35m, 1 }
                });

            migrationBuilder.InsertData(
                table: "Packages",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Description", "ModifiedDate", "Name", "PriceMultiplier", "Status" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 2, 23, 15, 23, 44, 246, DateTimeKind.Local).AddTicks(4803), null, "Kahvaltı, öğle ve akşam yemeği dahil.", null, "Tam Pansiyon", 1.2m, 1 },
                    { 2, new DateTime(2025, 2, 23, 15, 23, 44, 246, DateTimeKind.Local).AddTicks(4806), null, "Tüm yemekler, alkollü-alkolsüz içecekler ve otelin sunduğu belirli hizmetler dahil.", null, "Her Şey Dahil", 1.5m, 1 }
                });

            migrationBuilder.InsertData(
                table: "RoomTypes",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Description", "ModifiedDate", "Name", "Status" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 2, 23, 15, 23, 44, 160, DateTimeKind.Local).AddTicks(3937), null, "1 adet tek kişilik yatak. Balkon ve minibar bulunmaz. Klima, TV, saç kurutma makinesi ve WiFi mevcuttur.", null, "Tek Kişilik", 1 },
                    { 2, new DateTime(2025, 2, 23, 15, 23, 44, 160, DateTimeKind.Local).AddTicks(3947), null, "1 adet büyük (duble) yatak. Minibar bulunur. Klima, TV, saç kurutma makinesi ve WiFi mevcuttur.", null, "Çift Kişilik (Duble)", 1 },
                    { 3, new DateTime(2025, 2, 23, 15, 23, 44, 160, DateTimeKind.Local).AddTicks(3949), null, "3 adet tek kişilik yatak. Balkon ve minibar bulunmaz. Klima, TV, saç kurutma makinesi ve WiFi mevcuttur.", null, "Üç Kişilik", 1 },
                    { 4, new DateTime(2025, 2, 23, 15, 23, 44, 160, DateTimeKind.Local).AddTicks(3951), null, "1 adet büyük (duble) yatak + 2 adet tek kişilik yatak. Balkon ve minibar bulunur. Klima, TV, saç kurutma makinesi ve WiFi mevcuttur.", null, "Dört Kişilik", 1 },
                    { 5, new DateTime(2025, 2, 23, 15, 23, 44, 160, DateTimeKind.Local).AddTicks(3952), null, "Geniş ve lüks oda. Özel oturma alanı, büyük yatak, balkon, minibar, özel banyo ve lüks hizmetler. Klima, TV, saç kurutma makinesi, WiFi ve özel hizmetler mevcuttur.", null, "Kral Dairesi", 1 }
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
                    { 1, new DateTime(2025, 2, 23, 15, 23, 44, 162, DateTimeKind.Local).AddTicks(636), null, 1, true, false, true, false, true, true, null, 95.54m, "164", 1, 3, 1 },
                    { 2, new DateTime(2025, 2, 23, 15, 23, 44, 162, DateTimeKind.Local).AddTicks(651), null, 1, true, false, true, false, true, true, null, 145.50m, "175", 2, 1, 1 },
                    { 3, new DateTime(2025, 2, 23, 15, 23, 44, 162, DateTimeKind.Local).AddTicks(656), null, 1, true, false, true, false, true, true, null, 103.81m, "102", 2, 1, 1 },
                    { 4, new DateTime(2025, 2, 23, 15, 23, 44, 162, DateTimeKind.Local).AddTicks(659), null, 1, true, false, true, false, true, true, null, 70.63m, "158", 2, 1, 1 },
                    { 5, new DateTime(2025, 2, 23, 15, 23, 44, 162, DateTimeKind.Local).AddTicks(662), null, 1, true, false, true, false, true, true, null, 71.11m, "145", 2, 1, 1 },
                    { 6, new DateTime(2025, 2, 23, 15, 23, 44, 162, DateTimeKind.Local).AddTicks(667), null, 1, true, false, true, false, true, true, null, 143.89m, "104", 1, 3, 1 },
                    { 7, new DateTime(2025, 2, 23, 15, 23, 44, 162, DateTimeKind.Local).AddTicks(670), null, 1, true, false, true, false, true, true, null, 141.49m, "114", 1, 1, 1 },
                    { 8, new DateTime(2025, 2, 23, 15, 23, 44, 162, DateTimeKind.Local).AddTicks(673), null, 1, true, false, true, false, true, true, null, 112.64m, "185", 2, 1, 1 },
                    { 9, new DateTime(2025, 2, 23, 15, 23, 44, 162, DateTimeKind.Local).AddTicks(676), null, 1, true, false, true, false, true, true, null, 78.70m, "127", 2, 3, 1 },
                    { 10, new DateTime(2025, 2, 23, 15, 23, 44, 162, DateTimeKind.Local).AddTicks(680), null, 1, true, false, true, false, true, true, null, 132.64m, "154", 3, 3, 1 },
                    { 11, new DateTime(2025, 2, 23, 15, 23, 44, 162, DateTimeKind.Local).AddTicks(686), null, 2, true, false, true, false, true, true, null, 163.04m, "285", 1, 1, 1 },
                    { 12, new DateTime(2025, 2, 23, 15, 23, 44, 162, DateTimeKind.Local).AddTicks(690), null, 2, true, false, true, true, true, true, null, 192.78m, "238", 3, 2, 1 },
                    { 13, new DateTime(2025, 2, 23, 15, 23, 44, 162, DateTimeKind.Local).AddTicks(693), null, 2, true, false, true, true, true, true, null, 121.63m, "268", 1, 2, 1 },
                    { 14, new DateTime(2025, 2, 23, 15, 23, 44, 162, DateTimeKind.Local).AddTicks(696), null, 2, true, false, true, true, true, true, null, 191.77m, "295", 1, 2, 1 },
                    { 15, new DateTime(2025, 2, 23, 15, 23, 44, 162, DateTimeKind.Local).AddTicks(698), null, 2, true, false, true, false, true, true, null, 121.82m, "277", 1, 1, 1 },
                    { 16, new DateTime(2025, 2, 23, 15, 23, 44, 162, DateTimeKind.Local).AddTicks(701), null, 2, true, false, true, false, true, true, null, 190.39m, "265", 2, 1, 1 },
                    { 17, new DateTime(2025, 2, 23, 15, 23, 44, 162, DateTimeKind.Local).AddTicks(703), null, 2, true, false, true, false, true, true, null, 169.33m, "247", 3, 1, 1 },
                    { 18, new DateTime(2025, 2, 23, 15, 23, 44, 162, DateTimeKind.Local).AddTicks(708), null, 2, true, false, true, false, true, true, null, 140.64m, "231", 1, 1, 1 },
                    { 19, new DateTime(2025, 2, 23, 15, 23, 44, 162, DateTimeKind.Local).AddTicks(711), null, 2, true, false, true, true, true, true, null, 198.31m, "207", 1, 2, 1 },
                    { 20, new DateTime(2025, 2, 23, 15, 23, 44, 162, DateTimeKind.Local).AddTicks(713), null, 2, true, false, true, true, true, true, null, 150.78m, "248", 3, 2, 1 },
                    { 21, new DateTime(2025, 2, 23, 15, 23, 44, 162, DateTimeKind.Local).AddTicks(719), null, 3, true, true, true, true, true, true, null, 220.40m, "350", 3, 2, 1 },
                    { 22, new DateTime(2025, 2, 23, 15, 23, 44, 162, DateTimeKind.Local).AddTicks(723), null, 3, true, true, true, true, true, true, null, 190.22m, "356", 3, 3, 1 },
                    { 23, new DateTime(2025, 2, 23, 15, 23, 44, 162, DateTimeKind.Local).AddTicks(726), null, 3, true, true, true, true, true, true, null, 224.42m, "363", 3, 2, 1 },
                    { 24, new DateTime(2025, 2, 23, 15, 23, 44, 162, DateTimeKind.Local).AddTicks(729), null, 3, true, true, true, true, true, true, null, 298.38m, "304", 3, 3, 1 },
                    { 25, new DateTime(2025, 2, 23, 15, 23, 44, 162, DateTimeKind.Local).AddTicks(731), null, 3, true, true, true, true, true, true, null, 202.31m, "360", 1, 2, 1 },
                    { 26, new DateTime(2025, 2, 23, 15, 23, 44, 162, DateTimeKind.Local).AddTicks(734), null, 3, true, true, true, true, true, true, null, 189.16m, "350", 3, 2, 1 },
                    { 27, new DateTime(2025, 2, 23, 15, 23, 44, 162, DateTimeKind.Local).AddTicks(737), null, 3, true, true, true, true, true, true, null, 216.17m, "382", 1, 3, 1 },
                    { 28, new DateTime(2025, 2, 23, 15, 23, 44, 162, DateTimeKind.Local).AddTicks(739), null, 3, true, true, true, true, true, true, null, 221.24m, "340", 3, 3, 1 },
                    { 29, new DateTime(2025, 2, 23, 15, 23, 44, 162, DateTimeKind.Local).AddTicks(773), null, 3, true, true, true, true, true, true, null, 170.94m, "320", 3, 2, 1 },
                    { 30, new DateTime(2025, 2, 23, 15, 23, 44, 162, DateTimeKind.Local).AddTicks(777), null, 3, true, true, true, true, true, true, null, 182.66m, "379", 2, 3, 1 },
                    { 31, new DateTime(2025, 2, 23, 15, 23, 44, 162, DateTimeKind.Local).AddTicks(783), null, 4, true, true, true, true, true, true, null, 223.98m, "465", 2, 2, 1 },
                    { 32, new DateTime(2025, 2, 23, 15, 23, 44, 162, DateTimeKind.Local).AddTicks(786), null, 4, true, true, true, true, true, true, null, 430.82m, "444", 1, 2, 1 },
                    { 33, new DateTime(2025, 2, 23, 15, 23, 44, 162, DateTimeKind.Local).AddTicks(789), null, 4, true, true, true, true, true, true, null, 340.72m, "410", 1, 2, 1 },
                    { 34, new DateTime(2025, 2, 23, 15, 23, 44, 162, DateTimeKind.Local).AddTicks(793), null, 4, true, true, true, true, true, true, null, 300.93m, "430", 2, 4, 1 },
                    { 35, new DateTime(2025, 2, 23, 15, 23, 44, 162, DateTimeKind.Local).AddTicks(796), null, 4, true, true, true, true, true, true, null, 274.63m, "401", 3, 2, 1 },
                    { 36, new DateTime(2025, 2, 23, 15, 23, 44, 162, DateTimeKind.Local).AddTicks(798), null, 4, true, true, true, true, true, true, null, 359.20m, "469", 2, 4, 1 },
                    { 37, new DateTime(2025, 2, 23, 15, 23, 44, 162, DateTimeKind.Local).AddTicks(801), null, 4, true, true, true, true, true, true, null, 266.18m, "482", 3, 4, 1 },
                    { 38, new DateTime(2025, 2, 23, 15, 23, 44, 162, DateTimeKind.Local).AddTicks(804), null, 4, true, true, true, true, true, true, null, 281.41m, "429", 2, 2, 1 },
                    { 39, new DateTime(2025, 2, 23, 15, 23, 44, 162, DateTimeKind.Local).AddTicks(806), null, 4, true, true, true, true, true, true, null, 312.16m, "457", 2, 4, 1 },
                    { 40, new DateTime(2025, 2, 23, 15, 23, 44, 162, DateTimeKind.Local).AddTicks(808), null, 4, true, true, true, true, true, true, null, 294.46m, "488", 1, 2, 1 },
                    { 41, new DateTime(2025, 2, 23, 15, 23, 44, 162, DateTimeKind.Local).AddTicks(810), null, 4, true, true, true, true, true, true, null, 1000m, "500", 1, 5, 1 }
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
