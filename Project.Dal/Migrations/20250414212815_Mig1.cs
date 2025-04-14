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
                name: "DatabaseBackupLogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FilePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AppUserId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DatabaseBackupLogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DatabaseBackupLogs_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InventoryItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SerialNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InventoryItems_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
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
                    { 1, "0afacafa-afb3-4834-9b79-1b1c671cd130", "Admin", "ADMIN" },
                    { 2, "474dff22-be64-4c7a-970a-7bb0c3002093", "Member", "MEMBER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ActivationCode", "ConcurrencyStamp", "CreatedDate", "DeletedDate", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "ModifiedDate", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Status", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { 1, 0, new Guid("00000000-0000-0000-0000-000000000000"), "1b646898-059c-417f-8c98-249c5c143135", new DateTime(2025, 4, 15, 0, 28, 15, 463, DateTimeKind.Local).AddTicks(6425), null, "bilgehotel@email.com", true, false, null, null, "BILGEHOTEL@EMAIL.COM", "BILGEHOTEL", "AQAAAAIAAYagAAAAEMyWVgJSVJD3FIo7LKTblussGWFrxOJU2sqEPOpUy6gndwvOZsvJ6sh7wCFFnk7btQ==", null, false, "d5da1df4-e012-4438-a0f0-dd800110df6f", 1, false, "bilgehotel" },
                    { 2, 0, new Guid("00000000-0000-0000-0000-000000000000"), "f67f4d83-90fd-4578-b504-07aa5c585d76", new DateTime(2025, 4, 15, 0, 28, 15, 501, DateTimeKind.Local).AddTicks(6635), null, "testmember@email.com", true, false, null, null, "TESTMEMBER@EMAIL.COM", "TESTMEMBER", "AQAAAAIAAYagAAAAEORNWKNEz85QtcKDATSW3FlJ3UgVUQleTgLU+nivpuJUJN5ATnQ8gPZkOgQay9VyAQ==", null, false, "dad4f2cd-6d9e-41c2-b85c-a67cb443e9a9", 1, false, "testmember" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Address", "BirthDate", "CreatedDate", "DeletedDate", "FirstName", "HireDate", "LastName", "ModifiedDate", "PhoneNumber", "Position", "Salary", "Shift", "Status" },
                values: new object[,]
                {
                    { 1, "Sıran Söğüt Sokak 48, Kırklareli, Kongo", new DateTime(2002, 10, 7, 19, 56, 55, 768, DateTimeKind.Local).AddTicks(2508), new DateTime(2025, 4, 15, 0, 28, 15, 424, DateTimeKind.Local).AddTicks(9403), null, "Arnaç", new DateTime(2015, 2, 5, 9, 23, 52, 300, DateTimeKind.Local).AddTicks(2269), "Erginsoy", null, "+905749619739", "Resepsiyonist", 58148.85m, 1, 1 },
                    { 2, "Kekeçoğlu Sokak 80c, Mardin, Palau Adaları", new DateTime(1981, 11, 17, 15, 34, 28, 726, DateTimeKind.Local).AddTicks(7240), new DateTime(2025, 4, 15, 0, 28, 15, 424, DateTimeKind.Local).AddTicks(9496), null, "İrtiş", new DateTime(2020, 10, 18, 6, 33, 14, 359, DateTimeKind.Local).AddTicks(4560), "Orbay", null, "+905559182229", "Resepsiyonist", 41583.96m, 2, 1 },
                    { 3, "Sıran Söğüt Sokak 509, Tekirdağ, Kuveyt", new DateTime(1999, 5, 14, 10, 52, 35, 256, DateTimeKind.Local).AddTicks(3108), new DateTime(2025, 4, 15, 0, 28, 15, 424, DateTimeKind.Local).AddTicks(9552), null, "Kezlik", new DateTime(2021, 10, 22, 23, 32, 26, 983, DateTimeKind.Local).AddTicks(1503), "Poçan", null, "+905126509279", "Resepsiyonist", 58277.86m, 2, 1 },
                    { 4, "Ali Çetinkaya Caddesi 6, Kütahya, Çad", new DateTime(1992, 9, 10, 23, 42, 56, 193, DateTimeKind.Local).AddTicks(6091), new DateTime(2025, 4, 15, 0, 28, 15, 424, DateTimeKind.Local).AddTicks(9631), null, "Arsıl", new DateTime(2021, 7, 28, 21, 4, 52, 968, DateTimeKind.Local).AddTicks(7611), "Taşçı", null, "+905678154976", "Resepsiyonist", 52338.47m, 1, 1 },
                    { 5, "Nalbant Sokak 39, Nevşehir, Endonezya", new DateTime(1968, 6, 27, 13, 14, 11, 81, DateTimeKind.Local).AddTicks(7182), new DateTime(2025, 4, 15, 0, 28, 15, 424, DateTimeKind.Local).AddTicks(9707), null, "Atmaca", new DateTime(2020, 12, 26, 12, 11, 46, 619, DateTimeKind.Local).AddTicks(1505), "Arslanoğlu", null, "+905774427687", "Resepsiyonist", 53128.67m, 3, 1 },
                    { 6, "Nalbant Sokak 96a, Gümüşhane, Bahreyn", new DateTime(1992, 10, 26, 1, 3, 35, 606, DateTimeKind.Local).AddTicks(1323), new DateTime(2025, 4, 15, 0, 28, 15, 424, DateTimeKind.Local).AddTicks(9756), null, "Asığ", new DateTime(2022, 11, 25, 18, 29, 33, 252, DateTimeKind.Local).AddTicks(206), "Tahincioğlu", null, "+905050231749", "Resepsiyonist", 52850.14m, 1, 1 },
                    { 7, "Alparslan Türkeş Bulvarı 16, Isparta, Letonya", new DateTime(1998, 3, 23, 5, 29, 12, 995, DateTimeKind.Local).AddTicks(1366), new DateTime(2025, 4, 15, 0, 28, 15, 424, DateTimeKind.Local).AddTicks(9821), null, "Alptunga", new DateTime(2017, 2, 27, 12, 14, 29, 717, DateTimeKind.Local).AddTicks(6096), "Eronat", null, "+905533851809", "Resepsiyonist", 52492.24m, 2, 1 },
                    { 8, "Mevlana Sokak 9, Şırnak, Karadağ", new DateTime(2003, 5, 22, 21, 16, 16, 370, DateTimeKind.Local).AddTicks(4947), new DateTime(2025, 4, 15, 0, 28, 15, 424, DateTimeKind.Local).AddTicks(9910), null, "Barbulsun", new DateTime(2017, 8, 26, 18, 12, 46, 925, DateTimeKind.Local).AddTicks(7326), "Okur", null, "+905341855403", "Temizlik Görevlisi", 32624.63m, 2, 1 },
                    { 9, "Sevgi Sokak 13a, Çanakkale, Avusturya", new DateTime(2001, 7, 9, 22, 13, 20, 20, DateTimeKind.Local).AddTicks(422), new DateTime(2025, 4, 15, 0, 28, 15, 424, DateTimeKind.Local).AddTicks(9965), null, "Eğrim", new DateTime(2015, 9, 18, 18, 29, 1, 504, DateTimeKind.Local).AddTicks(9913), "Evliyaoğlu", null, "+905325992954", "Temizlik Görevlisi", 34873.84m, 2, 1 },
                    { 10, "Harman Yolu Sokak  04b, Tekirdağ, Solomon Adaları", new DateTime(1997, 3, 14, 19, 36, 56, 534, DateTimeKind.Local).AddTicks(2431), new DateTime(2025, 4, 15, 0, 28, 15, 425, DateTimeKind.Local).AddTicks(50), null, "Ayaçı", new DateTime(2017, 11, 30, 5, 24, 18, 210, DateTimeKind.Local).AddTicks(3729), "Erginsoy", null, "+905984540202", "Temizlik Görevlisi", 29926.08m, 1, 1 },
                    { 11, "Kekeçoğlu Sokak 4, Kars, Yeni Zelanda", new DateTime(1976, 2, 29, 20, 41, 2, 224, DateTimeKind.Local).AddTicks(339), new DateTime(2025, 4, 15, 0, 28, 15, 425, DateTimeKind.Local).AddTicks(94), null, "Ebren", new DateTime(2020, 9, 17, 5, 19, 1, 250, DateTimeKind.Local).AddTicks(4356), "Akyüz", null, "+905716857765", "Temizlik Görevlisi", 25743.59m, 1, 1 },
                    { 12, "Dağınık Evler Sokak 77a, Artvin, Dominika", new DateTime(1992, 3, 23, 22, 18, 53, 789, DateTimeKind.Local).AddTicks(1463), new DateTime(2025, 4, 15, 0, 28, 15, 425, DateTimeKind.Local).AddTicks(166), null, "Barın", new DateTime(2018, 6, 7, 3, 37, 19, 16, DateTimeKind.Local).AddTicks(5980), "Bolatlı", null, "+905845708957", "Temizlik Görevlisi", 30440.49m, 2, 1 },
                    { 13, "Saygılı Sokak 36, Kilis, Lesotho", new DateTime(1982, 10, 18, 23, 5, 8, 140, DateTimeKind.Local).AddTicks(3711), new DateTime(2025, 4, 15, 0, 28, 15, 425, DateTimeKind.Local).AddTicks(234), null, "Arslanargun", new DateTime(2017, 8, 7, 2, 50, 26, 499, DateTimeKind.Local).AddTicks(9053), "Dağlaroğlu", null, "+905933200461", "Temizlik Görevlisi", 25181.82m, 1, 1 },
                    { 14, "Lütfi Karadirek Caddesi 65b, Kilis, Suriye", new DateTime(1985, 10, 12, 3, 46, 52, 22, DateTimeKind.Local).AddTicks(8259), new DateTime(2025, 4, 15, 0, 28, 15, 425, DateTimeKind.Local).AddTicks(279), null, "Aydoğmuş", new DateTime(2017, 9, 25, 17, 8, 40, 982, DateTimeKind.Local).AddTicks(9013), "Adıvar", null, "+905320943121", "Temizlik Görevlisi", 31428.29m, 1, 1 },
                    { 15, "Oğuzhan Sokak 71c, Mardin, Moğolistan", new DateTime(1973, 8, 28, 13, 49, 32, 445, DateTimeKind.Local).AddTicks(2318), new DateTime(2025, 4, 15, 0, 28, 15, 425, DateTimeKind.Local).AddTicks(351), null, "Barsgan", new DateTime(2017, 7, 7, 9, 15, 23, 237, DateTimeKind.Local).AddTicks(6595), "Yılmazer", null, "+905682252741", "Temizlik Görevlisi", 31272.15m, 2, 1 },
                    { 16, "Okul Sokak 42c, Aydın, Saint Helena, İngiltere", new DateTime(1973, 2, 10, 8, 15, 44, 811, DateTimeKind.Local).AddTicks(1212), new DateTime(2025, 4, 15, 0, 28, 15, 425, DateTimeKind.Local).AddTicks(417), null, "Basanyalavaç", new DateTime(2022, 8, 1, 14, 17, 49, 526, DateTimeKind.Local).AddTicks(8513), "Dizdar ", null, "+905512379764", "Temizlik Görevlisi", 26507.24m, 2, 1 },
                    { 17, "Gül Sokak 74a, Sakarya, İsrail", new DateTime(1987, 10, 22, 8, 58, 23, 890, DateTimeKind.Local).AddTicks(368), new DateTime(2025, 4, 15, 0, 28, 15, 425, DateTimeKind.Local).AddTicks(468), null, "Beyizçi", new DateTime(2021, 4, 25, 18, 14, 45, 568, DateTimeKind.Local).AddTicks(3990), "Körmükçü", null, "+905378435544", "Temizlik Görevlisi", 27751.74m, 2, 1 },
                    { 18, "Fatih Sokak  80b, Niğde, Bermuda, İngiltere", new DateTime(1990, 8, 6, 10, 32, 28, 818, DateTimeKind.Local).AddTicks(9031), new DateTime(2025, 4, 15, 0, 28, 15, 425, DateTimeKind.Local).AddTicks(535), null, "Çeykün", new DateTime(2021, 1, 19, 9, 18, 4, 67, DateTimeKind.Local).AddTicks(5479), "Aykaç", null, "+905546788559", "Temizlik Görevlisi", 34034.52m, 2, 1 },
                    { 19, "Sarıkaya Caddesi 19, Kastamonu, Afganistan", new DateTime(1975, 11, 7, 15, 36, 26, 341, DateTimeKind.Local).AddTicks(5929), new DateTime(2025, 4, 15, 0, 28, 15, 425, DateTimeKind.Local).AddTicks(596), null, "Arademir", new DateTime(2019, 4, 7, 13, 31, 53, 801, DateTimeKind.Local).AddTicks(6679), "Topçuoğlu", null, "+905027963839", "Aşçı", 119277.62m, 2, 1 },
                    { 20, "Menekşe Sokak 13, Mardin, Slovakya", new DateTime(1970, 1, 19, 19, 57, 26, 190, DateTimeKind.Local).AddTicks(1842), new DateTime(2025, 4, 15, 0, 28, 15, 425, DateTimeKind.Local).AddTicks(1077), null, "Amrak", new DateTime(2015, 10, 20, 11, 41, 32, 189, DateTimeKind.Local).AddTicks(3772), "Doğan ", null, "+905367563886", "Aşçı", 106494.21m, 2, 1 },
                    { 21, "Sevgi Sokak 10a, İstanbul, Mauritius", new DateTime(2002, 7, 10, 5, 46, 38, 80, DateTimeKind.Local).AddTicks(3246), new DateTime(2025, 4, 15, 0, 28, 15, 425, DateTimeKind.Local).AddTicks(1231), null, "Buyruç", new DateTime(2017, 1, 8, 23, 7, 1, 492, DateTimeKind.Local).AddTicks(1059), "Özkara", null, "+905901372055", "Aşçı", 102339.94m, 2, 1 },
                    { 22, "Oğuzhan Sokak 06a, Konya, Folkland Adaları, İngiltere", new DateTime(2004, 5, 10, 1, 43, 54, 445, DateTimeKind.Local).AddTicks(4505), new DateTime(2025, 4, 15, 0, 28, 15, 425, DateTimeKind.Local).AddTicks(1315), null, "Burulgu", new DateTime(2021, 1, 15, 15, 56, 41, 167, DateTimeKind.Local).AddTicks(5288), "Topçuoğlu", null, "+905615057418", "Aşçı", 118797.41m, 1, 1 },
                    { 23, "Atatürk Bulvarı 17a, Burdur, Sri Lanka", new DateTime(2004, 5, 29, 18, 26, 37, 149, DateTimeKind.Local).AddTicks(5076), new DateTime(2025, 4, 15, 0, 28, 15, 425, DateTimeKind.Local).AddTicks(1365), null, "Begine", new DateTime(2018, 12, 2, 8, 15, 8, 86, DateTimeKind.Local).AddTicks(4627), "Baykam", null, "+905649250840", "Aşçı", 118519.32m, 2, 1 },
                    { 24, "Okul Sokak 6, Aydın, Gambiya", new DateTime(1968, 6, 7, 3, 12, 48, 318, DateTimeKind.Local).AddTicks(2523), new DateTime(2025, 4, 15, 0, 28, 15, 425, DateTimeKind.Local).AddTicks(1434), null, "Elkin", new DateTime(2024, 1, 10, 13, 51, 21, 471, DateTimeKind.Local).AddTicks(1066), "Akar ", null, "+905523837749", "Aşçı", 104477.84m, 2, 1 },
                    { 25, "Bandak Sokak 96, Ordu, Bolivya", new DateTime(1984, 11, 13, 13, 4, 1, 297, DateTimeKind.Local).AddTicks(516), new DateTime(2025, 4, 15, 0, 28, 15, 425, DateTimeKind.Local).AddTicks(1478), null, "Kımızalma", new DateTime(2018, 5, 3, 2, 33, 17, 803, DateTimeKind.Local).AddTicks(9302), "Başoğlu", null, "+905244408389", "Aşçı", 101998.08m, 1, 1 },
                    { 26, "Kekeçoğlu Sokak 72a, Kırklareli, Litvanya", new DateTime(1992, 7, 26, 1, 59, 21, 774, DateTimeKind.Local).AddTicks(8810), new DateTime(2025, 4, 15, 0, 28, 15, 425, DateTimeKind.Local).AddTicks(1578), null, "Berdibeğ", new DateTime(2020, 5, 30, 17, 39, 59, 393, DateTimeKind.Local).AddTicks(2936), "Sezek", null, "+905713102622", "Aşçı", 110232.66m, 2, 1 },
                    { 27, "Atatürk Bulvarı 63, Çankırı, Cibuti", new DateTime(2001, 8, 12, 18, 3, 22, 49, DateTimeKind.Local).AddTicks(8364), new DateTime(2025, 4, 15, 0, 28, 15, 425, DateTimeKind.Local).AddTicks(1669), null, "Arçuk", new DateTime(2021, 1, 22, 14, 11, 14, 969, DateTimeKind.Local).AddTicks(6223), "Poyrazoğlu", null, "+905311093249", "Aşçı", 116377.00m, 1, 1 },
                    { 28, "Sevgi Sokak 35a, Konya, Tacikistan", new DateTime(1994, 2, 21, 10, 59, 18, 81, DateTimeKind.Local).AddTicks(9698), new DateTime(2025, 4, 15, 0, 28, 15, 425, DateTimeKind.Local).AddTicks(1711), null, "Alperen", new DateTime(2021, 4, 4, 8, 8, 19, 170, DateTimeKind.Local).AddTicks(6634), "Tekand", null, "+905803970974", "Aşçı", 101826.71m, 2, 1 },
                    { 29, "Sıran Söğüt Sokak 44b, Ankara, Somali", new DateTime(1989, 10, 27, 2, 45, 45, 120, DateTimeKind.Local).AddTicks(4712), new DateTime(2025, 4, 15, 0, 28, 15, 425, DateTimeKind.Local).AddTicks(1801), null, "Çemgen", new DateTime(2017, 2, 3, 19, 43, 29, 659, DateTimeKind.Local).AddTicks(2629), "Erez", null, "+905407551371", "Aşçı", 117492.48m, 1, 1 },
                    { 30, "Atatürk Bulvarı 11, İzmir, Moğolistan", new DateTime(1972, 12, 9, 0, 7, 15, 40, DateTimeKind.Local).AddTicks(1109), new DateTime(2025, 4, 15, 0, 28, 15, 425, DateTimeKind.Local).AddTicks(1870), null, "Altınkan", new DateTime(2021, 12, 21, 10, 40, 47, 328, DateTimeKind.Local).AddTicks(8042), "Kaplangı", null, "+905796976529", "Garson", 99074.01m, 2, 1 },
                    { 31, "Saygılı Sokak 91b, Karaman, Saint Helena, İngiltere", new DateTime(1975, 7, 12, 2, 22, 31, 418, DateTimeKind.Local).AddTicks(1641), new DateTime(2025, 4, 15, 0, 28, 15, 425, DateTimeKind.Local).AddTicks(1915), null, "Aybalta", new DateTime(2020, 3, 15, 15, 41, 52, 351, DateTimeKind.Local).AddTicks(6802), "Tokgöz", null, "+905138185694", "Garson", 81867.74m, 1, 1 },
                    { 32, "Oğuzhan Sokak 80a, Gümüşhane, Virgin Adaları, İngiltere", new DateTime(1992, 10, 26, 8, 16, 12, 978, DateTimeKind.Local).AddTicks(7823), new DateTime(2025, 4, 15, 0, 28, 15, 425, DateTimeKind.Local).AddTicks(1975), null, "Bumın", new DateTime(2022, 9, 27, 17, 48, 52, 743, DateTimeKind.Local).AddTicks(7707), "Poçan", null, "+905454021443", "Garson", 91164.20m, 2, 1 },
                    { 33, "İsmet Paşa Caddesi 70a, Mardin, Orta Afrika Cumhuriyeti", new DateTime(1999, 2, 20, 3, 31, 24, 852, DateTimeKind.Local).AddTicks(1308), new DateTime(2025, 4, 15, 0, 28, 15, 425, DateTimeKind.Local).AddTicks(2067), null, "Baraktöre", new DateTime(2020, 12, 14, 13, 6, 44, 462, DateTimeKind.Local).AddTicks(6435), "Tunçeri", null, "+905231251523", "Garson", 83583.27m, 2, 1 },
                    { 34, "Tevfik Fikret Caddesi 875, Muş, Bangladeş", new DateTime(1993, 4, 10, 10, 12, 39, 304, DateTimeKind.Local).AddTicks(7401), new DateTime(2025, 4, 15, 0, 28, 15, 425, DateTimeKind.Local).AddTicks(2117), null, "Bıtaybıkı", new DateTime(2020, 9, 1, 0, 13, 39, 902, DateTimeKind.Local).AddTicks(7408), "Demirbaş", null, "+905872960943", "Garson", 94315.74m, 2, 1 },
                    { 35, "Nalbant Sokak 514, Bursa, Nijer", new DateTime(1996, 7, 2, 11, 45, 9, 48, DateTimeKind.Local).AddTicks(7104), new DateTime(2025, 4, 15, 0, 28, 15, 425, DateTimeKind.Local).AddTicks(2199), null, "Başgan", new DateTime(2017, 1, 17, 13, 27, 44, 922, DateTimeKind.Local).AddTicks(3151), "Dağdaş", null, "+905951996149", "Garson", 76461.26m, 2, 1 },
                    { 36, "Okul Sokak 32a, İstanbul, Nijerya", new DateTime(1982, 3, 11, 20, 54, 23, 739, DateTimeKind.Local).AddTicks(756), new DateTime(2025, 4, 15, 0, 28, 15, 425, DateTimeKind.Local).AddTicks(2266), null, "Batu", new DateTime(2015, 11, 2, 9, 51, 55, 179, DateTimeKind.Local).AddTicks(1194), "Barbarosoğlu", null, "+905707668126", "Garson", 70702.91m, 1, 1 },
                    { 37, "Köypınar Sokak 51b, Sakarya, İran", new DateTime(2001, 5, 24, 12, 9, 1, 435, DateTimeKind.Local).AddTicks(768), new DateTime(2025, 4, 15, 0, 28, 15, 425, DateTimeKind.Local).AddTicks(2310), null, "Ebkızı", new DateTime(2016, 6, 11, 12, 56, 56, 547, DateTimeKind.Local).AddTicks(4816), "Koçyiğit", null, "+905050562503", "Garson", 71822.44m, 2, 1 },
                    { 38, "Kekeçoğlu Sokak 3, Kütahya, Svaziland", new DateTime(1972, 7, 24, 12, 30, 14, 161, DateTimeKind.Local).AddTicks(9467), new DateTime(2025, 4, 15, 0, 28, 15, 425, DateTimeKind.Local).AddTicks(2376), null, "Barçan", new DateTime(2020, 11, 27, 9, 15, 21, 576, DateTimeKind.Local).AddTicks(8300), "Avan", null, "+905949656733", "Garson", 81510.88m, 2, 1 },
                    { 39, "Dağınık Evler Sokak 5, Bingöl, Marşal Adaları", new DateTime(1986, 10, 15, 0, 30, 52, 246, DateTimeKind.Local).AddTicks(5350), new DateTime(2025, 4, 15, 0, 28, 15, 425, DateTimeKind.Local).AddTicks(2469), null, "Ekeç", new DateTime(2016, 9, 19, 23, 5, 4, 984, DateTimeKind.Local).AddTicks(7966), "Polat", null, "+905812585472", "Garson", 97198.54m, 2, 1 },
                    { 40, "Ülkü Sokak 44a, Bitlis, Moğolistan", new DateTime(1998, 10, 23, 23, 21, 41, 80, DateTimeKind.Local).AddTicks(7147), new DateTime(2025, 4, 15, 0, 28, 15, 425, DateTimeKind.Local).AddTicks(2515), null, "Iyıktağ", new DateTime(2014, 11, 6, 5, 38, 14, 430, DateTimeKind.Local).AddTicks(1497), "Koç", null, "+905198593148", "Garson", 97783.97m, 1, 1 },
                    { 41, "İbn-i Sina Sokak 5, Bursa, Virgin Adaları, Amerika", new DateTime(1972, 12, 12, 13, 57, 20, 665, DateTimeKind.Local).AddTicks(1055), new DateTime(2025, 4, 15, 0, 28, 15, 425, DateTimeKind.Local).AddTicks(2603), null, "Bargan", new DateTime(2015, 3, 25, 15, 40, 17, 195, DateTimeKind.Local).AddTicks(4748), "Beşerler", null, "+905588772988", "Garson", 89700.21m, 2, 1 },
                    { 42, "Bayır Sokak 30a, Hatay, Gine", new DateTime(2000, 3, 27, 20, 8, 56, 972, DateTimeKind.Local).AddTicks(3345), new DateTime(2025, 4, 15, 0, 28, 15, 425, DateTimeKind.Local).AddTicks(2645), null, "Barkdurmuş", new DateTime(2021, 3, 9, 9, 47, 41, 43, DateTimeKind.Local).AddTicks(5959), "Öymen", null, "+905094714287", "Garson", 74879.91m, 1, 1 },
                    { 43, "Sarıkaya Caddesi 8, Elazığ, Kongo", new DateTime(1990, 9, 17, 15, 43, 52, 665, DateTimeKind.Local).AddTicks(1524), new DateTime(2025, 4, 15, 0, 28, 15, 425, DateTimeKind.Local).AddTicks(2730), null, "Buzaçtutuk", new DateTime(2021, 5, 21, 0, 29, 35, 395, DateTimeKind.Local).AddTicks(4881), "Öztuna", null, "+905179928195", "Elektrikçi", 117052.50m, 1, 1 },
                    { 44, "Ergenekon Sokak   73, Van, Ruanda", new DateTime(1977, 12, 26, 10, 36, 56, 925, DateTimeKind.Local).AddTicks(3925), new DateTime(2025, 4, 15, 0, 28, 15, 425, DateTimeKind.Local).AddTicks(2796), null, "Barçadoğdu", new DateTime(2018, 9, 17, 15, 53, 16, 590, DateTimeKind.Local).AddTicks(507), "Uca", null, "+905426642773", "IT Sorumlusu", 167958.34m, 1, 1 }
                });

            migrationBuilder.InsertData(
                table: "ExtraServices",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Description", "ModifiedDate", "Name", "Price", "Status" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 4, 15, 0, 28, 15, 501, DateTimeKind.Local).AddTicks(7079), null, "Günlük sınırsız spa kullanımı.", null, "Spa Kullanımı", 3000m, 1 },
                    { 2, new DateTime(2025, 4, 15, 0, 28, 15, 501, DateTimeKind.Local).AddTicks(7081), null, "24 saat oda servisi. Tüm yemek siparişleri dahildir.", null, "Oda Servisi", 1500m, 1 },
                    { 3, new DateTime(2025, 4, 15, 0, 28, 15, 501, DateTimeKind.Local).AddTicks(7082), null, "Minibardaki içecekler ve atıştırmalıklar dahil.", null, "Minibar Kullanımı", 1000m, 1 },
                    { 4, new DateTime(2025, 4, 15, 0, 28, 15, 501, DateTimeKind.Local).AddTicks(7084), null, "Gidiş-dönüş özel araç transferi.", null, "Havalimanı Transferi", 5000m, 1 },
                    { 5, new DateTime(2025, 4, 15, 0, 28, 15, 501, DateTimeKind.Local).AddTicks(7085), null, "Konaklama süresince ücretsiz çamaşır ve kuru temizleme hizmeti.", null, "Çamaşırhane Hizmeti", 500m, 1 },
                    { 6, new DateTime(2025, 4, 15, 0, 28, 15, 501, DateTimeKind.Local).AddTicks(7094), null, "Ekstra günlük temizlik ve hijyen paketi.", null, "Günlük Oda Temizliği", 500m, 1 },
                    { 7, new DateTime(2025, 4, 15, 0, 28, 15, 501, DateTimeKind.Local).AddTicks(7095), null, "Özel şezlong ve plaj hizmetleri.", null, "Özel Plaj Alanı", 7500m, 1 }
                });

            migrationBuilder.InsertData(
                table: "Packages",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Description", "ModifiedDate", "Name", "PriceMultiplier", "Status" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 4, 15, 0, 28, 15, 501, DateTimeKind.Local).AddTicks(7027), null, "Kahvaltı, öğle ve akşam yemeği dahil.", null, "Tam Pansiyon", 1.2m, 1 },
                    { 2, new DateTime(2025, 4, 15, 0, 28, 15, 501, DateTimeKind.Local).AddTicks(7030), null, "Tüm yemekler, alkollü-alkolsüz içecekler ve otelin sunduğu belirli hizmetler dahil.", null, "Her Şey Dahil", 1.5m, 1 }
                });

            migrationBuilder.InsertData(
                table: "RoomTypes",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Description", "ModifiedDate", "Name", "Status" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 4, 15, 0, 28, 15, 423, DateTimeKind.Local).AddTicks(2346), null, "1 adet tek kişilik yatak. Balkon ve minibar bulunmaz. Klima, TV, saç kurutma makinesi ve WiFi mevcuttur.", null, "Tek Kişilik", 1 },
                    { 2, new DateTime(2025, 4, 15, 0, 28, 15, 423, DateTimeKind.Local).AddTicks(2356), null, "1 adet büyük (duble) yatak. Klima, TV, saç kurutma makinesi ve WiFi mevcuttur.", null, "Çift Kişilik (Duble)", 1 },
                    { 3, new DateTime(2025, 4, 15, 0, 28, 15, 423, DateTimeKind.Local).AddTicks(2357), null, "2 adet tek kişilik yatak. Klima, TV, saç kurutma makinesi ve WiFi mevcuttur.", null, "Çift Kişilik (Tek Kişilik 2 Yataklı)", 1 },
                    { 4, new DateTime(2025, 4, 15, 0, 28, 15, 423, DateTimeKind.Local).AddTicks(2358), null, "3 adet tek kişilik yatak.  Klima, TV, saç kurutma makinesi ve WiFi mevcuttur.", null, "Üç Kişilik (Tek Kişilik 3 Yataklı)", 1 },
                    { 5, new DateTime(2025, 4, 15, 0, 28, 15, 423, DateTimeKind.Local).AddTicks(2359), null, "Bir tek bir duble yatak.  Klima, TV, saç kurutma makinesi ve WiFi mevcuttur.", null, "Üç Kişilik (1 Tek, 1 Duble Yataklı)", 1 },
                    { 6, new DateTime(2025, 4, 15, 0, 28, 15, 423, DateTimeKind.Local).AddTicks(2388), null, "1 adet büyük (duble) yatak + 2 adet tek kişilik yatak. Klima, TV, saç kurutma makinesi ve WiFi mevcuttur.", null, "Dört Kişilik", 1 },
                    { 7, new DateTime(2025, 4, 15, 0, 28, 15, 423, DateTimeKind.Local).AddTicks(2389), null, "Geniş ve lüks oda. Özel oturma alanı, büyük yatak, balkon, minibar, özel banyo ve lüks hizmetler. Klima, TV, saç kurutma makinesi, WiFi ve özel hizmetler mevcuttur.", null, "Kral Dairesi", 1 }
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
                table: "InventoryItems",
                columns: new[] { "Id", "Category", "CreatedDate", "DeletedDate", "Description", "EmployeeId", "Location", "ModifiedDate", "Name", "SerialNumber", "Status" },
                values: new object[,]
                {
                    { 1, "Bilgisayar", new DateTime(2025, 4, 15, 0, 28, 15, 501, DateTimeKind.Local).AddTicks(7258), null, "Intel i5 - 8GB RAM", 44, "Resepsiyon", null, "Masaüstü PC", "PC-RSP-001", 1 },
                    { 2, "Bilgisayar", new DateTime(2025, 4, 15, 0, 28, 15, 501, DateTimeKind.Local).AddTicks(7258), null, "Intel i5 - 8GB RAM", 44, "Resepsiyon", null, "Masaüstü PC", "PC-RSP-002", 1 },
                    { 3, "Bilgisayar", new DateTime(2025, 4, 15, 0, 28, 15, 501, DateTimeKind.Local).AddTicks(7258), null, "Intel i3 - 4GB RAM", 44, "Resepsiyon", null, "Masaüstü PC", "PC-RSP-003", 1 },
                    { 4, "Bilgisayar", new DateTime(2025, 4, 15, 0, 28, 15, 501, DateTimeKind.Local).AddTicks(7258), null, "Intel i7 - 16GB RAM", 44, "Resepsiyon", null, "Masaüstü PC", "PC-RSP-004", 1 },
                    { 5, "Bilgisayar", new DateTime(2025, 4, 15, 0, 28, 15, 501, DateTimeKind.Local).AddTicks(7258), null, "All-in-One Dokunmatik", 44, "Bar", null, "Bar Terminali", "PC-BAR-001", 1 },
                    { 6, "Bilgisayar", new DateTime(2025, 4, 15, 0, 28, 15, 501, DateTimeKind.Local).AddTicks(7258), null, "Mini PC - Fanless", 44, "Havuzbaşı snackbar", null, "Havuzbaşı PC", "PC-HAVUZ-001", 1 },
                    { 7, "Bilgisayar", new DateTime(2025, 4, 15, 0, 28, 15, 501, DateTimeKind.Local).AddTicks(7258), null, "Dell Latitude", 44, "Yönetim Ofisi", null, "Yönetici Laptop", "PC-OFC-001", 1 },
                    { 8, "Bilgisayar", new DateTime(2025, 4, 15, 0, 28, 15, 501, DateTimeKind.Local).AddTicks(7258), null, "Lenovo ThinkPad", 44, "Yönetim Ofisi", null, "Yönetici Laptop", "PC-OFC-002", 1 },
                    { 9, "Bilgisayar", new DateTime(2025, 4, 15, 0, 28, 15, 501, DateTimeKind.Local).AddTicks(7258), null, "HP EliteBook", 44, "Yönetim Ofisi", null, "Yönetici Laptop", "PC-OFC-003", 1 },
                    { 10, "Bilgisayar", new DateTime(2025, 4, 15, 0, 28, 15, 501, DateTimeKind.Local).AddTicks(7258), null, "Core i5 - 8GB", 44, "Yönetim Ofisi", null, "Yönetici Masaüstü", "PC-OFC-004", 1 },
                    { 11, "Bilgisayar", new DateTime(2025, 4, 15, 0, 28, 15, 501, DateTimeKind.Local).AddTicks(7258), null, "Core i7 - 16GB", 44, "Yönetim Ofisi", null, "Yönetici Masaüstü", "PC-OFC-005", 1 },
                    { 12, "Bilgisayar", new DateTime(2025, 4, 15, 0, 28, 15, 501, DateTimeKind.Local).AddTicks(7258), null, "Core i3 - 4GB", 44, "Yönetim Ofisi", null, "Yönetici Masaüstü", "PC-OFC-006", 1 },
                    { 13, "Server", new DateTime(2025, 4, 15, 0, 28, 15, 501, DateTimeKind.Local).AddTicks(7258), null, "Windows Server 2003", 44, "Teknik Sunucu Odası", null, "Mail Server", "SRV-001", 1 },
                    { 14, "Server", new DateTime(2025, 4, 15, 0, 28, 15, 501, DateTimeKind.Local).AddTicks(7258), null, "XP Professional - Domain dışı", 44, "Teknik Sunucu Odası", null, "Wireless Router Server", "SRV-002", 1 }
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Floor", "HasAirConditioner", "HasBalcony", "HasHairDryer", "HasMinibar", "HasTV", "HasWifi", "ModifiedDate", "PricePerNight", "RoomNumber", "RoomStatus", "RoomTypeId", "Status" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 4, 15, 0, 28, 15, 423, DateTimeKind.Local).AddTicks(2444), null, 1, true, false, true, false, true, true, null, 1000m, "100", 1, 1, 1 },
                    { 2, new DateTime(2025, 4, 15, 0, 28, 15, 423, DateTimeKind.Local).AddTicks(2447), null, 1, true, false, true, false, true, true, null, 1000m, "101", 1, 1, 1 },
                    { 3, new DateTime(2025, 4, 15, 0, 28, 15, 423, DateTimeKind.Local).AddTicks(2448), null, 1, true, false, true, false, true, true, null, 1000m, "102", 1, 1, 1 },
                    { 4, new DateTime(2025, 4, 15, 0, 28, 15, 423, DateTimeKind.Local).AddTicks(2448), null, 1, true, false, true, false, true, true, null, 1000m, "103", 1, 1, 1 },
                    { 5, new DateTime(2025, 4, 15, 0, 28, 15, 423, DateTimeKind.Local).AddTicks(2449), null, 1, true, false, true, false, true, true, null, 1000m, "104", 1, 1, 1 },
                    { 6, new DateTime(2025, 4, 15, 0, 28, 15, 423, DateTimeKind.Local).AddTicks(2451), null, 1, true, false, true, false, true, true, null, 1000m, "105", 1, 1, 1 },
                    { 7, new DateTime(2025, 4, 15, 0, 28, 15, 423, DateTimeKind.Local).AddTicks(2452), null, 1, true, false, true, false, true, true, null, 1000m, "106", 1, 1, 1 },
                    { 8, new DateTime(2025, 4, 15, 0, 28, 15, 423, DateTimeKind.Local).AddTicks(2452), null, 1, true, false, true, false, true, true, null, 1000m, "107", 1, 1, 1 },
                    { 9, new DateTime(2025, 4, 15, 0, 28, 15, 423, DateTimeKind.Local).AddTicks(2453), null, 1, true, false, true, false, true, true, null, 1000m, "108", 1, 1, 1 },
                    { 10, new DateTime(2025, 4, 15, 0, 28, 15, 423, DateTimeKind.Local).AddTicks(2454), null, 1, true, false, true, false, true, true, null, 1000m, "109", 1, 1, 1 },
                    { 11, new DateTime(2025, 4, 15, 0, 28, 15, 423, DateTimeKind.Local).AddTicks(2457), null, 1, true, false, true, false, true, true, null, 1500m, "110", 1, 4, 1 },
                    { 12, new DateTime(2025, 4, 15, 0, 28, 15, 423, DateTimeKind.Local).AddTicks(2458), null, 1, true, false, true, false, true, true, null, 1500m, "111", 1, 4, 1 },
                    { 13, new DateTime(2025, 4, 15, 0, 28, 15, 423, DateTimeKind.Local).AddTicks(2458), null, 1, true, false, true, false, true, true, null, 1500m, "112", 1, 4, 1 },
                    { 14, new DateTime(2025, 4, 15, 0, 28, 15, 423, DateTimeKind.Local).AddTicks(2459), null, 1, true, false, true, false, true, true, null, 1500m, "113", 1, 4, 1 },
                    { 15, new DateTime(2025, 4, 15, 0, 28, 15, 423, DateTimeKind.Local).AddTicks(2459), null, 1, true, false, true, false, true, true, null, 1500m, "114", 1, 4, 1 },
                    { 16, new DateTime(2025, 4, 15, 0, 28, 15, 423, DateTimeKind.Local).AddTicks(2460), null, 1, true, false, true, false, true, true, null, 1500m, "115", 1, 4, 1 },
                    { 17, new DateTime(2025, 4, 15, 0, 28, 15, 423, DateTimeKind.Local).AddTicks(2460), null, 1, true, false, true, false, true, true, null, 1500m, "116", 1, 4, 1 },
                    { 18, new DateTime(2025, 4, 15, 0, 28, 15, 423, DateTimeKind.Local).AddTicks(2462), null, 1, true, false, true, false, true, true, null, 1500m, "117", 1, 4, 1 },
                    { 19, new DateTime(2025, 4, 15, 0, 28, 15, 423, DateTimeKind.Local).AddTicks(2462), null, 1, true, false, true, false, true, true, null, 1500m, "118", 1, 4, 1 },
                    { 20, new DateTime(2025, 4, 15, 0, 28, 15, 423, DateTimeKind.Local).AddTicks(2463), null, 1, true, false, true, false, true, true, null, 1500m, "119", 1, 4, 1 },
                    { 21, new DateTime(2025, 4, 15, 0, 28, 15, 423, DateTimeKind.Local).AddTicks(2465), null, 2, true, false, true, false, true, true, null, 1200m, "200", 1, 1, 1 },
                    { 22, new DateTime(2025, 4, 15, 0, 28, 15, 423, DateTimeKind.Local).AddTicks(2466), null, 2, true, false, true, false, true, true, null, 1200m, "201", 1, 1, 1 },
                    { 23, new DateTime(2025, 4, 15, 0, 28, 15, 423, DateTimeKind.Local).AddTicks(2466), null, 2, true, false, true, false, true, true, null, 1200m, "202", 1, 1, 1 },
                    { 24, new DateTime(2025, 4, 15, 0, 28, 15, 423, DateTimeKind.Local).AddTicks(2467), null, 2, true, false, true, false, true, true, null, 1200m, "203", 1, 1, 1 },
                    { 25, new DateTime(2025, 4, 15, 0, 28, 15, 423, DateTimeKind.Local).AddTicks(2468), null, 2, true, false, true, false, true, true, null, 1200m, "204", 1, 1, 1 },
                    { 26, new DateTime(2025, 4, 15, 0, 28, 15, 423, DateTimeKind.Local).AddTicks(2468), null, 2, true, false, true, false, true, true, null, 1200m, "205", 1, 1, 1 },
                    { 27, new DateTime(2025, 4, 15, 0, 28, 15, 423, DateTimeKind.Local).AddTicks(2469), null, 2, true, false, true, false, true, true, null, 1200m, "206", 1, 1, 1 },
                    { 28, new DateTime(2025, 4, 15, 0, 28, 15, 423, DateTimeKind.Local).AddTicks(2469), null, 2, true, false, true, false, true, true, null, 1200m, "207", 1, 1, 1 },
                    { 29, new DateTime(2025, 4, 15, 0, 28, 15, 423, DateTimeKind.Local).AddTicks(2471), null, 2, true, false, true, false, true, true, null, 1200m, "208", 1, 1, 1 },
                    { 30, new DateTime(2025, 4, 15, 0, 28, 15, 423, DateTimeKind.Local).AddTicks(2471), null, 2, true, false, true, false, true, true, null, 1200m, "209", 1, 1, 1 },
                    { 31, new DateTime(2025, 4, 15, 0, 28, 15, 423, DateTimeKind.Local).AddTicks(2473), null, 2, true, false, true, true, true, true, null, 1800m, "210", 1, 3, 1 },
                    { 32, new DateTime(2025, 4, 15, 0, 28, 15, 423, DateTimeKind.Local).AddTicks(2474), null, 2, true, false, true, true, true, true, null, 1800m, "211", 1, 3, 1 },
                    { 33, new DateTime(2025, 4, 15, 0, 28, 15, 423, DateTimeKind.Local).AddTicks(2474), null, 2, true, false, true, true, true, true, null, 1800m, "212", 1, 3, 1 },
                    { 34, new DateTime(2025, 4, 15, 0, 28, 15, 423, DateTimeKind.Local).AddTicks(2476), null, 2, true, false, true, true, true, true, null, 1800m, "213", 1, 3, 1 },
                    { 35, new DateTime(2025, 4, 15, 0, 28, 15, 423, DateTimeKind.Local).AddTicks(2477), null, 2, true, false, true, true, true, true, null, 1800m, "214", 1, 3, 1 },
                    { 36, new DateTime(2025, 4, 15, 0, 28, 15, 423, DateTimeKind.Local).AddTicks(2477), null, 2, true, false, true, true, true, true, null, 1800m, "215", 1, 3, 1 },
                    { 37, new DateTime(2025, 4, 15, 0, 28, 15, 423, DateTimeKind.Local).AddTicks(2478), null, 2, true, false, true, true, true, true, null, 1800m, "216", 1, 3, 1 },
                    { 38, new DateTime(2025, 4, 15, 0, 28, 15, 423, DateTimeKind.Local).AddTicks(2478), null, 2, true, false, true, true, true, true, null, 1800m, "217", 1, 3, 1 },
                    { 39, new DateTime(2025, 4, 15, 0, 28, 15, 423, DateTimeKind.Local).AddTicks(2479), null, 2, true, false, true, true, true, true, null, 1800m, "218", 1, 3, 1 },
                    { 40, new DateTime(2025, 4, 15, 0, 28, 15, 423, DateTimeKind.Local).AddTicks(2480), null, 2, true, false, true, true, true, true, null, 1800m, "219", 1, 3, 1 },
                    { 41, new DateTime(2025, 4, 15, 0, 28, 15, 423, DateTimeKind.Local).AddTicks(2484), null, 3, true, true, true, true, true, true, null, 2200m, "300", 1, 2, 1 },
                    { 42, new DateTime(2025, 4, 15, 0, 28, 15, 423, DateTimeKind.Local).AddTicks(2485), null, 3, true, true, true, true, true, true, null, 2200m, "301", 1, 2, 1 },
                    { 43, new DateTime(2025, 4, 15, 0, 28, 15, 423, DateTimeKind.Local).AddTicks(2486), null, 3, true, true, true, true, true, true, null, 2200m, "302", 1, 2, 1 },
                    { 44, new DateTime(2025, 4, 15, 0, 28, 15, 423, DateTimeKind.Local).AddTicks(2486), null, 3, true, true, true, true, true, true, null, 2200m, "303", 1, 2, 1 },
                    { 45, new DateTime(2025, 4, 15, 0, 28, 15, 423, DateTimeKind.Local).AddTicks(2487), null, 3, true, true, true, true, true, true, null, 2200m, "304", 1, 2, 1 },
                    { 46, new DateTime(2025, 4, 15, 0, 28, 15, 423, DateTimeKind.Local).AddTicks(2487), null, 3, true, true, true, true, true, true, null, 2200m, "305", 1, 2, 1 },
                    { 47, new DateTime(2025, 4, 15, 0, 28, 15, 423, DateTimeKind.Local).AddTicks(2488), null, 3, true, true, true, true, true, true, null, 2200m, "306", 1, 2, 1 },
                    { 48, new DateTime(2025, 4, 15, 0, 28, 15, 423, DateTimeKind.Local).AddTicks(2488), null, 3, true, true, true, true, true, true, null, 2200m, "307", 1, 2, 1 },
                    { 49, new DateTime(2025, 4, 15, 0, 28, 15, 423, DateTimeKind.Local).AddTicks(2512), null, 3, true, true, true, true, true, true, null, 2200m, "308", 1, 2, 1 },
                    { 50, new DateTime(2025, 4, 15, 0, 28, 15, 423, DateTimeKind.Local).AddTicks(2513), null, 3, true, true, true, true, true, true, null, 2200m, "309", 1, 2, 1 },
                    { 51, new DateTime(2025, 4, 15, 0, 28, 15, 423, DateTimeKind.Local).AddTicks(2515), null, 3, true, true, true, true, true, true, null, 2500m, "310", 1, 5, 1 },
                    { 52, new DateTime(2025, 4, 15, 0, 28, 15, 423, DateTimeKind.Local).AddTicks(2516), null, 3, true, true, true, true, true, true, null, 2500m, "311", 1, 5, 1 },
                    { 53, new DateTime(2025, 4, 15, 0, 28, 15, 423, DateTimeKind.Local).AddTicks(2517), null, 3, true, true, true, true, true, true, null, 2500m, "312", 1, 5, 1 },
                    { 54, new DateTime(2025, 4, 15, 0, 28, 15, 423, DateTimeKind.Local).AddTicks(2517), null, 3, true, true, true, true, true, true, null, 2500m, "313", 1, 5, 1 },
                    { 55, new DateTime(2025, 4, 15, 0, 28, 15, 423, DateTimeKind.Local).AddTicks(2518), null, 3, true, true, true, true, true, true, null, 2500m, "314", 1, 5, 1 },
                    { 56, new DateTime(2025, 4, 15, 0, 28, 15, 423, DateTimeKind.Local).AddTicks(2519), null, 3, true, true, true, true, true, true, null, 2500m, "315", 1, 5, 1 },
                    { 57, new DateTime(2025, 4, 15, 0, 28, 15, 423, DateTimeKind.Local).AddTicks(2519), null, 3, true, true, true, true, true, true, null, 2500m, "316", 1, 5, 1 },
                    { 58, new DateTime(2025, 4, 15, 0, 28, 15, 423, DateTimeKind.Local).AddTicks(2520), null, 3, true, true, true, true, true, true, null, 2500m, "317", 1, 5, 1 },
                    { 59, new DateTime(2025, 4, 15, 0, 28, 15, 423, DateTimeKind.Local).AddTicks(2521), null, 3, true, true, true, true, true, true, null, 2500m, "318", 1, 5, 1 },
                    { 60, new DateTime(2025, 4, 15, 0, 28, 15, 423, DateTimeKind.Local).AddTicks(2521), null, 3, true, true, true, true, true, true, null, 2500m, "319", 1, 5, 1 },
                    { 61, new DateTime(2025, 4, 15, 0, 28, 15, 423, DateTimeKind.Local).AddTicks(2523), null, 4, true, true, true, true, true, true, null, 2800m, "400", 1, 2, 1 },
                    { 62, new DateTime(2025, 4, 15, 0, 28, 15, 423, DateTimeKind.Local).AddTicks(2524), null, 4, true, true, true, true, true, true, null, 2800m, "401", 1, 2, 1 },
                    { 63, new DateTime(2025, 4, 15, 0, 28, 15, 423, DateTimeKind.Local).AddTicks(2524), null, 4, true, true, true, true, true, true, null, 2800m, "402", 1, 2, 1 },
                    { 64, new DateTime(2025, 4, 15, 0, 28, 15, 423, DateTimeKind.Local).AddTicks(2525), null, 4, true, true, true, true, true, true, null, 2800m, "403", 1, 2, 1 },
                    { 65, new DateTime(2025, 4, 15, 0, 28, 15, 423, DateTimeKind.Local).AddTicks(2526), null, 4, true, true, true, true, true, true, null, 2800m, "404", 1, 2, 1 },
                    { 66, new DateTime(2025, 4, 15, 0, 28, 15, 423, DateTimeKind.Local).AddTicks(2527), null, 4, true, true, true, true, true, true, null, 2800m, "405", 1, 2, 1 },
                    { 67, new DateTime(2025, 4, 15, 0, 28, 15, 423, DateTimeKind.Local).AddTicks(2528), null, 4, true, true, true, true, true, true, null, 2800m, "406", 1, 2, 1 },
                    { 68, new DateTime(2025, 4, 15, 0, 28, 15, 423, DateTimeKind.Local).AddTicks(2528), null, 4, true, true, true, true, true, true, null, 2800m, "407", 1, 2, 1 },
                    { 69, new DateTime(2025, 4, 15, 0, 28, 15, 423, DateTimeKind.Local).AddTicks(2529), null, 4, true, true, true, true, true, true, null, 2800m, "408", 1, 2, 1 },
                    { 70, new DateTime(2025, 4, 15, 0, 28, 15, 423, DateTimeKind.Local).AddTicks(2529), null, 4, true, true, true, true, true, true, null, 2800m, "409", 1, 2, 1 },
                    { 71, new DateTime(2025, 4, 15, 0, 28, 15, 423, DateTimeKind.Local).AddTicks(2531), null, 4, true, true, true, true, true, true, null, 3500m, "410", 1, 6, 1 },
                    { 72, new DateTime(2025, 4, 15, 0, 28, 15, 423, DateTimeKind.Local).AddTicks(2532), null, 4, true, true, true, true, true, true, null, 3500m, "411", 1, 6, 1 },
                    { 73, new DateTime(2025, 4, 15, 0, 28, 15, 423, DateTimeKind.Local).AddTicks(2533), null, 4, true, true, true, true, true, true, null, 3500m, "412", 1, 6, 1 },
                    { 74, new DateTime(2025, 4, 15, 0, 28, 15, 423, DateTimeKind.Local).AddTicks(2533), null, 4, true, true, true, true, true, true, null, 3500m, "413", 1, 6, 1 },
                    { 75, new DateTime(2025, 4, 15, 0, 28, 15, 423, DateTimeKind.Local).AddTicks(2534), null, 4, true, true, true, true, true, true, null, 3500m, "414", 1, 6, 1 },
                    { 76, new DateTime(2025, 4, 15, 0, 28, 15, 423, DateTimeKind.Local).AddTicks(2534), null, 4, true, true, true, true, true, true, null, 3500m, "415", 1, 6, 1 },
                    { 77, new DateTime(2025, 4, 15, 0, 28, 15, 423, DateTimeKind.Local).AddTicks(2536), null, 4, true, true, true, true, true, true, null, 10000m, "417", 1, 7, 1 }
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
                name: "IX_DatabaseBackupLogs_AppUserId",
                table: "DatabaseBackupLogs",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryItems_EmployeeId",
                table: "InventoryItems",
                column: "EmployeeId");

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
                name: "DatabaseBackupLogs");

            migrationBuilder.DropTable(
                name: "InventoryItems");

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
