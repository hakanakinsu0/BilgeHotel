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
                    { 1, "bd25c59e-5258-4f0e-81db-e58a4bdbd29c", "Admin", "ADMIN" },
                    { 2, "7f1baf2a-bd65-4684-b042-a4f68e004891", "Member", "MEMBER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ActivationCode", "ConcurrencyStamp", "CreatedDate", "DeletedDate", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "ModifiedDate", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Status", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { 1, 0, new Guid("00000000-0000-0000-0000-000000000000"), "a7710893-654c-4999-bace-381e9e7929d1", new DateTime(2025, 4, 4, 1, 0, 10, 265, DateTimeKind.Local).AddTicks(5386), null, "bilgehotel@email.com", true, false, null, null, "BILGEHOTEL@EMAIL.COM", "BILGEHOTEL", "AQAAAAIAAYagAAAAEJGk1LzK1Hxzheve+dHTpBomgdjjir4Yc29OfGFY5EdwQH11YLaTTIdy0K3CZ98yVw==", null, false, "c0c90378-d150-4c8b-9a47-62d570a4b999", 1, false, "bilgehotel" },
                    { 2, 0, new Guid("00000000-0000-0000-0000-000000000000"), "beb92818-0ae4-4161-92a8-5f70983c3d59", new DateTime(2025, 4, 4, 1, 0, 10, 303, DateTimeKind.Local).AddTicks(464), null, "testmember@email.com", true, false, null, null, "TESTMEMBER@EMAIL.COM", "TESTMEMBER", "AQAAAAIAAYagAAAAELAwMYZK52/E53ehH+RXd6UEDsnmsVJl1F1PUSQOk9k4A2knLQJfGm+jqQvXEg4JYQ==", null, false, "5524fdfb-d7d8-434c-a920-8d79eee4b27a", 1, false, "testmember" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Address", "BirthDate", "CreatedDate", "DeletedDate", "FirstName", "HireDate", "LastName", "ModifiedDate", "PhoneNumber", "Position", "Salary", "Shift", "Status" },
                values: new object[,]
                {
                    { 1, "Kocatepe Caddesi 79c, Erzurum, Beyaz Rusya", new DateTime(2002, 6, 9, 14, 51, 40, 920, DateTimeKind.Local).AddTicks(9634), new DateTime(2025, 4, 4, 1, 0, 10, 227, DateTimeKind.Local).AddTicks(4496), null, "Bügdüz", new DateTime(2015, 5, 27, 14, 43, 5, 68, DateTimeKind.Local).AddTicks(7590), "Günday", null, "+905237848095", "Resepsiyonist", 53428.24m, 3, 1 },
                    { 2, "Yunus Emre Sokak 6, Erzincan, Namibia", new DateTime(1974, 5, 9, 8, 31, 51, 769, DateTimeKind.Local).AddTicks(9402), new DateTime(2025, 4, 4, 1, 0, 10, 227, DateTimeKind.Local).AddTicks(4567), null, "Kıvanç", new DateTime(2023, 2, 11, 16, 4, 46, 228, DateTimeKind.Local).AddTicks(158), "Tokatlıoğlu", null, "+905344249643", "Resepsiyonist", 49516.99m, 1, 1 },
                    { 3, "Kaldırım Sokak 22a, Karabük, Beyaz Rusya", new DateTime(1968, 11, 17, 14, 45, 43, 966, DateTimeKind.Local).AddTicks(3590), new DateTime(2025, 4, 4, 1, 0, 10, 227, DateTimeKind.Local).AddTicks(4651), null, "Bekeçtegin", new DateTime(2022, 7, 26, 16, 49, 35, 600, DateTimeKind.Local).AddTicks(6596), "Köybaşı", null, "+905104746773", "Resepsiyonist", 51812.10m, 3, 1 },
                    { 4, "Saygılı Sokak 71a, Tekirdağ, Nijer", new DateTime(2004, 1, 16, 6, 29, 1, 921, DateTimeKind.Local).AddTicks(1388), new DateTime(2025, 4, 4, 1, 0, 10, 227, DateTimeKind.Local).AddTicks(4703), null, "Altan", new DateTime(2023, 2, 1, 13, 17, 20, 637, DateTimeKind.Local).AddTicks(3478), "Başoğlu", null, "+905627254513", "Resepsiyonist", 46451.19m, 2, 1 },
                    { 5, "Gül Sokak 5, Adana, Solomon Adaları", new DateTime(2004, 4, 4, 9, 48, 3, 450, DateTimeKind.Local).AddTicks(9064), new DateTime(2025, 4, 4, 1, 0, 10, 227, DateTimeKind.Local).AddTicks(4775), null, "Arkın", new DateTime(2019, 5, 17, 12, 59, 7, 442, DateTimeKind.Local).AddTicks(9621), "Babaoğlu", null, "+905995024560", "Resepsiyonist", 54117.00m, 3, 1 },
                    { 6, "Yunus Emre Sokak 61c, Ağrı, İngiltere", new DateTime(1979, 4, 26, 4, 41, 47, 685, DateTimeKind.Local).AddTicks(3355), new DateTime(2025, 4, 4, 1, 0, 10, 227, DateTimeKind.Local).AddTicks(4849), null, "Artuk", new DateTime(2015, 11, 27, 23, 15, 59, 208, DateTimeKind.Local).AddTicks(755), "Tanrıkulu", null, "+905016326884", "Resepsiyonist", 46969.16m, 1, 1 },
                    { 7, "30 Ağustos Caddesi 44c, Ağrı, Şili", new DateTime(1979, 8, 7, 2, 12, 8, 147, DateTimeKind.Local).AddTicks(8102), new DateTime(2025, 4, 4, 1, 0, 10, 227, DateTimeKind.Local).AddTicks(4900), null, "Alpurungututuk", new DateTime(2021, 2, 19, 1, 16, 31, 704, DateTimeKind.Local).AddTicks(8127), "Süleymanoğlu", null, "+905622337598", "Resepsiyonist", 56966.09m, 1, 1 },
                    { 8, "İbn-i Sina Sokak 41c, Sinop, Avusturya", new DateTime(1977, 3, 13, 4, 6, 50, 442, DateTimeKind.Local).AddTicks(7143), new DateTime(2025, 4, 4, 1, 0, 10, 227, DateTimeKind.Local).AddTicks(4976), null, "Alptuğrul", new DateTime(2023, 2, 5, 1, 46, 35, 438, DateTimeKind.Local).AddTicks(906), "Okur", null, "+905068847191", "Temizlik Görevlisi", 32192.63m, 2, 1 },
                    { 9, "Sevgi Sokak 60c, İstanbul, Kazakistan", new DateTime(1976, 6, 21, 8, 40, 5, 112, DateTimeKind.Local).AddTicks(9323), new DateTime(2025, 4, 4, 1, 0, 10, 227, DateTimeKind.Local).AddTicks(5050), null, "Buluk", new DateTime(2017, 7, 28, 13, 8, 11, 403, DateTimeKind.Local).AddTicks(7943), "Erberk", null, "+905746341602", "Temizlik Görevlisi", 26788.37m, 1, 1 },
                    { 10, "Sağlık Sokak 6, Çankırı, Ürdün", new DateTime(1969, 9, 1, 14, 35, 39, 698, DateTimeKind.Local).AddTicks(9788), new DateTime(2025, 4, 4, 1, 0, 10, 227, DateTimeKind.Local).AddTicks(5099), null, "Kımızalmıla", new DateTime(2018, 7, 23, 16, 31, 20, 457, DateTimeKind.Local).AddTicks(6835), "Akışık", null, "+905031651994", "Temizlik Görevlisi", 29983.54m, 1, 1 },
                    { 11, "Namık Kemal Caddesi 70, Ankara, Togo", new DateTime(1974, 1, 16, 14, 5, 11, 484, DateTimeKind.Local).AddTicks(3584), new DateTime(2025, 4, 4, 1, 0, 10, 227, DateTimeKind.Local).AddTicks(5183), null, "Barçadurmuş", new DateTime(2015, 9, 3, 23, 0, 57, 158, DateTimeKind.Local).AddTicks(7555), "Çamdalı", null, "+905907632028", "Temizlik Görevlisi", 28247.88m, 2, 1 },
                    { 12, "Kekeçoğlu Sokak 32, Şanlıurfa, Birleşik Arap Emirlikleri", new DateTime(1992, 6, 28, 10, 38, 5, 742, DateTimeKind.Local).AddTicks(7405), new DateTime(2025, 4, 4, 1, 0, 10, 227, DateTimeKind.Local).AddTicks(5255), null, "Baynal", new DateTime(2018, 7, 6, 9, 16, 14, 688, DateTimeKind.Local).AddTicks(31), "Sezek", null, "+905608043139", "Temizlik Görevlisi", 25316.13m, 2, 1 },
                    { 13, "Barış Sokak 01, Muş, Somali", new DateTime(1971, 3, 10, 7, 26, 3, 397, DateTimeKind.Local).AddTicks(7624), new DateTime(2025, 4, 4, 1, 0, 10, 227, DateTimeKind.Local).AddTicks(5299), null, "Abak", new DateTime(2018, 9, 5, 13, 15, 32, 25, DateTimeKind.Local).AddTicks(7262), "Paksüt", null, "+905616832163", "Temizlik Görevlisi", 33404.98m, 2, 1 },
                    { 14, "Kaldırım Sokak 59a, Bitlis, Litvanya", new DateTime(1996, 2, 26, 1, 27, 20, 586, DateTimeKind.Local).AddTicks(5270), new DateTime(2025, 4, 4, 1, 0, 10, 227, DateTimeKind.Local).AddTicks(5369), null, "Boyan", new DateTime(2021, 11, 26, 15, 3, 5, 102, DateTimeKind.Local).AddTicks(3700), "Atakol", null, "+905219805171", "Temizlik Görevlisi", 26559.86m, 2, 1 },
                    { 15, "Yunus Emre Sokak 36a, Bolu, Anguilla, İngiltere", new DateTime(1975, 12, 3, 11, 49, 49, 657, DateTimeKind.Local).AddTicks(1546), new DateTime(2025, 4, 4, 1, 0, 10, 227, DateTimeKind.Local).AddTicks(5435), null, "Kesme", new DateTime(2016, 12, 6, 11, 4, 40, 791, DateTimeKind.Local).AddTicks(9239), "Ertepınar", null, "+905747280634", "Temizlik Görevlisi", 25926.25m, 1, 1 },
                    { 16, "Sağlık Sokak 90, Aydın, Kenya", new DateTime(1991, 8, 12, 15, 41, 35, 606, DateTimeKind.Local).AddTicks(8647), new DateTime(2025, 4, 4, 1, 0, 10, 227, DateTimeKind.Local).AddTicks(5479), null, "Aba", new DateTime(2018, 2, 24, 17, 18, 38, 519, DateTimeKind.Local).AddTicks(5361), "Tokgöz", null, "+905905884544", "Temizlik Görevlisi", 28389.09m, 1, 1 },
                    { 17, "Dar Sokak 83, Afyon, Madagaskar", new DateTime(1979, 2, 18, 14, 24, 46, 411, DateTimeKind.Local).AddTicks(4212), new DateTime(2025, 4, 4, 1, 0, 10, 227, DateTimeKind.Local).AddTicks(5545), null, "Basan", new DateTime(2022, 2, 9, 8, 35, 29, 39, DateTimeKind.Local).AddTicks(5124), "Yıldızoğlu", null, "+905433329349", "Temizlik Görevlisi", 31845.10m, 1, 1 },
                    { 18, "Güven Yaka Sokak 70, Afyon, Fransız Güney Eyaletleri (Kerguelen Adaları)", new DateTime(1974, 10, 15, 7, 58, 6, 166, DateTimeKind.Local).AddTicks(9559), new DateTime(2025, 4, 4, 1, 0, 10, 227, DateTimeKind.Local).AddTicks(5590), null, "Bilig", new DateTime(2023, 2, 15, 4, 24, 49, 469, DateTimeKind.Local).AddTicks(3284), "Tütüncü", null, "+905413734316", "Temizlik Görevlisi", 29997.78m, 2, 1 },
                    { 19, "Bandak Sokak 383, Düzce, Sudan", new DateTime(1975, 3, 3, 17, 31, 19, 56, DateTimeKind.Local).AddTicks(3132), new DateTime(2025, 4, 4, 1, 0, 10, 227, DateTimeKind.Local).AddTicks(5663), null, "Bilgeışbaratamgan", new DateTime(2019, 1, 5, 8, 30, 45, 957, DateTimeKind.Local).AddTicks(8389), "Akışık", null, "+905318190833", "Aşçı", 117119.58m, 2, 1 },
                    { 20, "İsmet Paşa Caddesi 669, Sakarya, Amerikan Samoa", new DateTime(2007, 1, 23, 15, 47, 38, 373, DateTimeKind.Local).AddTicks(8743), new DateTime(2025, 4, 4, 1, 0, 10, 227, DateTimeKind.Local).AddTicks(5733), null, "Kancı", new DateTime(2018, 3, 14, 3, 36, 26, 339, DateTimeKind.Local).AddTicks(9257), "Demirbaş", null, "+905958095165", "Aşçı", 106261.07m, 1, 1 },
                    { 21, "Namık Kemal Caddesi 27b, Düzce, Angola", new DateTime(1999, 7, 8, 10, 19, 49, 193, DateTimeKind.Local).AddTicks(9842), new DateTime(2025, 4, 4, 1, 0, 10, 227, DateTimeKind.Local).AddTicks(5776), null, "Atış", new DateTime(2016, 6, 12, 5, 7, 17, 296, DateTimeKind.Local).AddTicks(95), "Kocabıyık", null, "+905312967842", "Aşçı", 104416.34m, 2, 1 },
                    { 22, "30 Ağustos Caddesi 1, Tokat, Lübnan", new DateTime(2006, 4, 21, 7, 40, 47, 989, DateTimeKind.Local).AddTicks(3281), new DateTime(2025, 4, 4, 1, 0, 10, 227, DateTimeKind.Local).AddTicks(5849), null, "Aydarkağan", new DateTime(2016, 8, 15, 22, 2, 13, 702, DateTimeKind.Local).AddTicks(8343), "Demirel", null, "+905518998836", "Aşçı", 118362.30m, 1, 1 },
                    { 23, "Menekşe Sokak 14, Muğla, Belçika", new DateTime(1995, 4, 15, 8, 27, 12, 158, DateTimeKind.Local).AddTicks(9439), new DateTime(2025, 4, 4, 1, 0, 10, 227, DateTimeKind.Local).AddTicks(5930), null, "Bermek", new DateTime(2021, 10, 18, 5, 49, 35, 339, DateTimeKind.Local).AddTicks(8194), "Pekkan", null, "+905173180373", "Aşçı", 107584.55m, 1, 1 },
                    { 24, "Namık Kemal Caddesi 243, Bartın, Santa Lucia", new DateTime(1972, 9, 10, 2, 35, 43, 210, DateTimeKind.Local).AddTicks(8780), new DateTime(2025, 4, 4, 1, 0, 10, 227, DateTimeKind.Local).AddTicks(5979), null, "Duygu", new DateTime(2019, 7, 15, 21, 8, 37, 36, DateTimeKind.Local).AddTicks(9978), "Aşıkoğlu", null, "+905516569972", "Aşçı", 111765.82m, 2, 1 },
                    { 25, "Nalbant Sokak 95, Elazığ, Moğolistan", new DateTime(1996, 3, 22, 6, 18, 12, 331, DateTimeKind.Local).AddTicks(9274), new DateTime(2025, 4, 4, 1, 0, 10, 227, DateTimeKind.Local).AddTicks(6049), null, "Çilenti", new DateTime(2014, 5, 3, 19, 45, 10, 191, DateTimeKind.Local).AddTicks(6474), "Uluhan", null, "+905633145116", "Aşçı", 115384.01m, 2, 1 },
                    { 26, "Okul Sokak 39a, Kilis, Tonga", new DateTime(2004, 5, 15, 11, 59, 59, 579, DateTimeKind.Local).AddTicks(1877), new DateTime(2025, 4, 4, 1, 0, 10, 227, DateTimeKind.Local).AddTicks(6115), null, "Berendey", new DateTime(2018, 7, 20, 0, 15, 37, 8, DateTimeKind.Local).AddTicks(4367), "Evliyaoğlu", null, "+905190657833", "Aşçı", 101001.92m, 2, 1 },
                    { 27, "Bahçe Sokak 616, Diyarbakır, Suudi Arabistan", new DateTime(1969, 11, 15, 2, 17, 8, 944, DateTimeKind.Local).AddTicks(6461), new DateTime(2025, 4, 4, 1, 0, 10, 227, DateTimeKind.Local).AddTicks(6161), null, "Bıtaybıkı", new DateTime(2023, 4, 9, 20, 22, 0, 905, DateTimeKind.Local).AddTicks(1127), "Erbulak", null, "+905389169386", "Aşçı", 102027.15m, 2, 1 },
                    { 28, "Okul Sokak 67a, Isparta, Liberya", new DateTime(1981, 8, 18, 20, 20, 8, 403, DateTimeKind.Local).AddTicks(7182), new DateTime(2025, 4, 4, 1, 0, 10, 227, DateTimeKind.Local).AddTicks(6226), null, "Burulday", new DateTime(2022, 5, 24, 1, 19, 15, 898, DateTimeKind.Local).AddTicks(1693), "Akan", null, "+905471823405", "Aşçı", 114319.04m, 2, 1 },
                    { 29, "Sevgi Sokak 43c, Erzincan, Japonya", new DateTime(1983, 1, 4, 23, 46, 58, 751, DateTimeKind.Local).AddTicks(1526), new DateTime(2025, 4, 4, 1, 0, 10, 227, DateTimeKind.Local).AddTicks(6268), null, "Bağaturçigşi", new DateTime(2018, 1, 15, 21, 38, 36, 415, DateTimeKind.Local).AddTicks(3750), "Avan", null, "+905431940662", "Aşçı", 112574.69m, 2, 1 },
                    { 30, "İsmet Attila Caddesi 58c, Ağrı, Andorra", new DateTime(1981, 12, 29, 18, 35, 42, 723, DateTimeKind.Local).AddTicks(9213), new DateTime(2025, 4, 4, 1, 0, 10, 227, DateTimeKind.Local).AddTicks(6338), null, "Arslanbörü", new DateTime(2018, 1, 24, 22, 15, 20, 413, DateTimeKind.Local).AddTicks(7202), "Karaduman", null, "+905396396837", "Garson", 83078.75m, 1, 1 },
                    { 31, "Yunus Emre Sokak 568, Bartın, Reunion, Fransa", new DateTime(1988, 6, 10, 19, 0, 0, 225, DateTimeKind.Local).AddTicks(4760), new DateTime(2025, 4, 4, 1, 0, 10, 227, DateTimeKind.Local).AddTicks(6402), null, "Barımtay", new DateTime(2019, 2, 17, 8, 21, 55, 850, DateTimeKind.Local).AddTicks(2676), "Avan", null, "+905913475095", "Garson", 79131.75m, 2, 1 },
                    { 32, "Alparslan Türkeş Bulvarı 57b, Bitlis, Azerbaycan", new DateTime(1997, 6, 19, 19, 49, 43, 958, DateTimeKind.Local).AddTicks(9948), new DateTime(2025, 4, 4, 1, 0, 10, 227, DateTimeKind.Local).AddTicks(6447), null, "Ayluçtarkan", new DateTime(2017, 8, 14, 5, 28, 8, 553, DateTimeKind.Local).AddTicks(2093), "Okur", null, "+905003410489", "Garson", 99451.33m, 1, 1 },
                    { 33, "Harman Altı Sokak 5, Aydın, Malavi", new DateTime(1978, 3, 5, 9, 19, 56, 532, DateTimeKind.Local).AddTicks(666), new DateTime(2025, 4, 4, 1, 0, 10, 227, DateTimeKind.Local).AddTicks(6509), null, "Ayaz", new DateTime(2015, 6, 17, 13, 12, 23, 653, DateTimeKind.Local).AddTicks(2900), "Erbay", null, "+905003481085", "Garson", 85596.46m, 2, 1 },
                    { 34, "Ülkü Sokak 37c, Kütahya, Ermenistan", new DateTime(1977, 9, 20, 23, 53, 24, 181, DateTimeKind.Local).AddTicks(7577), new DateTime(2025, 4, 4, 1, 0, 10, 227, DateTimeKind.Local).AddTicks(6580), null, "Bayraç", new DateTime(2016, 10, 18, 15, 29, 4, 340, DateTimeKind.Local).AddTicks(9236), "Körmükçü", null, "+905259628824", "Garson", 71444.45m, 2, 1 },
                    { 35, "Yunus Emre Sokak 79a, Niğde, Burundi", new DateTime(2002, 9, 25, 2, 50, 10, 232, DateTimeKind.Local).AddTicks(3703), new DateTime(2025, 4, 4, 1, 0, 10, 227, DateTimeKind.Local).AddTicks(6622), null, "Bilgin", new DateTime(2024, 3, 19, 19, 38, 3, 117, DateTimeKind.Local).AddTicks(8634), "Akyürek", null, "+905656959064", "Garson", 84732.60m, 1, 1 },
                    { 36, "Tevfik Fikret Caddesi 97a, Van, Tunus", new DateTime(1970, 7, 17, 1, 9, 59, 953, DateTimeKind.Local).AddTicks(9256), new DateTime(2025, 4, 4, 1, 0, 10, 227, DateTimeKind.Local).AddTicks(6695), null, "Atıgay", new DateTime(2015, 10, 11, 5, 56, 7, 63, DateTimeKind.Local).AddTicks(7991), "Elçiboğa", null, "+905057086622", "Garson", 80951.10m, 2, 1 },
                    { 37, "Okul Sokak 36c, Rize, Birmanya (Myanmar)", new DateTime(1967, 8, 26, 3, 50, 4, 79, DateTimeKind.Local).AddTicks(8138), new DateTime(2025, 4, 4, 1, 0, 10, 227, DateTimeKind.Local).AddTicks(6763), null, "Ilaçın", new DateTime(2015, 12, 12, 18, 48, 23, 582, DateTimeKind.Local).AddTicks(5625), "Durak ", null, "+905159978102", "Garson", 94611.51m, 1, 1 },
                    { 38, "Kekeçoğlu Sokak 08b, Bilecik, Palmyra Atoll, Amerika", new DateTime(1969, 5, 29, 3, 40, 47, 720, DateTimeKind.Local).AddTicks(7641), new DateTime(2025, 4, 4, 1, 0, 10, 227, DateTimeKind.Local).AddTicks(6806), null, "Ayaş", new DateTime(2022, 11, 1, 11, 42, 26, 925, DateTimeKind.Local).AddTicks(6234), "Yıldızoğlu", null, "+905279584425", "Garson", 90228.50m, 2, 1 },
                    { 39, "Harman Yolu Sokak  13c, Bilecik, Kuzey İrlanda", new DateTime(1967, 7, 11, 4, 1, 0, 751, DateTimeKind.Local).AddTicks(6264), new DateTime(2025, 4, 4, 1, 0, 10, 227, DateTimeKind.Local).AddTicks(6889), null, "İlgegü", new DateTime(2017, 9, 10, 21, 36, 29, 85, DateTimeKind.Local).AddTicks(1771), "Erdoğan", null, "+905500942993", "Garson", 89685.01m, 2, 1 },
                    { 40, "Dağınık Evler Sokak 107, Antalya, Portekiz", new DateTime(1981, 3, 13, 9, 33, 16, 964, DateTimeKind.Local).AddTicks(7841), new DateTime(2025, 4, 4, 1, 0, 10, 227, DateTimeKind.Local).AddTicks(6953), null, "Çıngır", new DateTime(2021, 12, 31, 13, 32, 57, 687, DateTimeKind.Local).AddTicks(6782), "Polat", null, "+905263695147", "Garson", 76120.06m, 1, 1 },
                    { 41, "Ali Çetinkaya Caddesi 525, Malatya, Bolivya", new DateTime(1998, 1, 3, 8, 36, 40, 398, DateTimeKind.Local).AddTicks(9134), new DateTime(2025, 4, 4, 1, 0, 10, 227, DateTimeKind.Local).AddTicks(6996), null, "Burulgu", new DateTime(2014, 12, 17, 12, 10, 48, 662, DateTimeKind.Local).AddTicks(7494), "Ayverdi", null, "+905916960670", "Garson", 78761.16m, 2, 1 },
                    { 42, "Kekeçoğlu Sokak 733, Muş, Bangladeş", new DateTime(1967, 12, 30, 8, 1, 2, 384, DateTimeKind.Local).AddTicks(3538), new DateTime(2025, 4, 4, 1, 0, 10, 227, DateTimeKind.Local).AddTicks(7063), null, "Bangu", new DateTime(2017, 5, 31, 1, 31, 47, 925, DateTimeKind.Local).AddTicks(4491), "Kunter", null, "+905748008088", "Garson", 71086.57m, 1, 1 },
                    { 43, "İsmet Attila Caddesi 37b, Ağrı, Arjantin", new DateTime(1990, 4, 13, 20, 51, 4, 314, DateTimeKind.Local).AddTicks(8487), new DateTime(2025, 4, 4, 1, 0, 10, 227, DateTimeKind.Local).AddTicks(7133), null, "Artukaç", new DateTime(2014, 12, 21, 3, 7, 50, 390, DateTimeKind.Local).AddTicks(118), "Sarıoğlu", null, "+905742517667", "Elektrikçi", 124008.07m, 3, 1 },
                    { 44, "Lütfi Karadirek Caddesi 6, Tekirdağ, Amerika Birleşik Devletleri", new DateTime(1997, 10, 8, 2, 4, 55, 563, DateTimeKind.Local).AddTicks(1183), new DateTime(2025, 4, 4, 1, 0, 10, 227, DateTimeKind.Local).AddTicks(7184), null, "Buyruk", new DateTime(2021, 6, 19, 9, 45, 12, 499, DateTimeKind.Local).AddTicks(1240), "Okur", null, "+905998608383", "IT Sorumlusu", 162627.47m, 2, 1 }
                });

            migrationBuilder.InsertData(
                table: "ExtraServices",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Description", "ModifiedDate", "Name", "Price", "Status" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 4, 4, 1, 0, 10, 303, DateTimeKind.Local).AddTicks(649), null, "Günlük sınırsız spa kullanımı.", null, "Spa Kullanımı", 3000m, 1 },
                    { 2, new DateTime(2025, 4, 4, 1, 0, 10, 303, DateTimeKind.Local).AddTicks(657), null, "24 saat oda servisi. Tüm yemek siparişleri dahildir.", null, "Oda Servisi", 1500m, 1 },
                    { 3, new DateTime(2025, 4, 4, 1, 0, 10, 303, DateTimeKind.Local).AddTicks(659), null, "Minibardaki içecekler ve atıştırmalıklar dahil.", null, "Minibar Kullanımı", 1000m, 1 },
                    { 4, new DateTime(2025, 4, 4, 1, 0, 10, 303, DateTimeKind.Local).AddTicks(660), null, "Gidiş-dönüş özel araç transferi.", null, "Havalimanı Transferi", 5000m, 1 },
                    { 5, new DateTime(2025, 4, 4, 1, 0, 10, 303, DateTimeKind.Local).AddTicks(661), null, "Konaklama süresince ücretsiz çamaşır ve kuru temizleme hizmeti.", null, "Çamaşırhane Hizmeti", 500m, 1 },
                    { 6, new DateTime(2025, 4, 4, 1, 0, 10, 303, DateTimeKind.Local).AddTicks(665), null, "Ekstra günlük temizlik ve hijyen paketi.", null, "Günlük Oda Temizliği", 500m, 1 },
                    { 7, new DateTime(2025, 4, 4, 1, 0, 10, 303, DateTimeKind.Local).AddTicks(667), null, "Özel şezlong ve plaj hizmetleri.", null, "Özel Plaj Alanı", 7500m, 1 }
                });

            migrationBuilder.InsertData(
                table: "Packages",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Description", "ModifiedDate", "Name", "PriceMultiplier", "Status" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 4, 4, 1, 0, 10, 303, DateTimeKind.Local).AddTicks(617), null, "Kahvaltı, öğle ve akşam yemeği dahil.", null, "Tam Pansiyon", 1.2m, 1 },
                    { 2, new DateTime(2025, 4, 4, 1, 0, 10, 303, DateTimeKind.Local).AddTicks(620), null, "Tüm yemekler, alkollü-alkolsüz içecekler ve otelin sunduğu belirli hizmetler dahil.", null, "Her Şey Dahil", 1.5m, 1 }
                });

            migrationBuilder.InsertData(
                table: "RoomTypes",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Description", "ModifiedDate", "Name", "Status" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 4, 4, 1, 0, 10, 225, DateTimeKind.Local).AddTicks(8865), null, "1 adet tek kişilik yatak. Balkon ve minibar bulunmaz. Klima, TV, saç kurutma makinesi ve WiFi mevcuttur.", null, "Tek Kişilik", 1 },
                    { 2, new DateTime(2025, 4, 4, 1, 0, 10, 225, DateTimeKind.Local).AddTicks(8874), null, "1 adet büyük (duble) yatak. Klima, TV, saç kurutma makinesi ve WiFi mevcuttur.", null, "Çift Kişilik (Duble)", 1 },
                    { 3, new DateTime(2025, 4, 4, 1, 0, 10, 225, DateTimeKind.Local).AddTicks(8876), null, "2 adet tek kişilik yatak. Klima, TV, saç kurutma makinesi ve WiFi mevcuttur.", null, "Çift Kişilik (Tek Kişilik 2 Yataklı)", 1 },
                    { 4, new DateTime(2025, 4, 4, 1, 0, 10, 225, DateTimeKind.Local).AddTicks(8877), null, "3 adet tek kişilik yatak.  Klima, TV, saç kurutma makinesi ve WiFi mevcuttur.", null, "Üç Kişilik (Tek Kişilik 3 Yataklı)", 1 },
                    { 5, new DateTime(2025, 4, 4, 1, 0, 10, 225, DateTimeKind.Local).AddTicks(8878), null, "Bir tek bir duble yatak.  Klima, TV, saç kurutma makinesi ve WiFi mevcuttur.", null, "Üç Kişilik (1 Tek, 1 Duble Yataklı)", 1 },
                    { 6, new DateTime(2025, 4, 4, 1, 0, 10, 225, DateTimeKind.Local).AddTicks(8880), null, "1 adet büyük (duble) yatak + 2 adet tek kişilik yatak. Klima, TV, saç kurutma makinesi ve WiFi mevcuttur.", null, "Dört Kişilik", 1 },
                    { 7, new DateTime(2025, 4, 4, 1, 0, 10, 225, DateTimeKind.Local).AddTicks(8881), null, "Geniş ve lüks oda. Özel oturma alanı, büyük yatak, balkon, minibar, özel banyo ve lüks hizmetler. Klima, TV, saç kurutma makinesi, WiFi ve özel hizmetler mevcuttur.", null, "Kral Dairesi", 1 }
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
                    { 1, new DateTime(2025, 4, 4, 1, 0, 10, 225, DateTimeKind.Local).AddTicks(8933), null, 1, true, false, true, false, true, true, null, 1000m, "100", 1, 1, 1 },
                    { 2, new DateTime(2025, 4, 4, 1, 0, 10, 225, DateTimeKind.Local).AddTicks(8936), null, 1, true, false, true, false, true, true, null, 1000m, "101", 1, 1, 1 },
                    { 3, new DateTime(2025, 4, 4, 1, 0, 10, 225, DateTimeKind.Local).AddTicks(8937), null, 1, true, false, true, false, true, true, null, 1000m, "102", 1, 1, 1 },
                    { 4, new DateTime(2025, 4, 4, 1, 0, 10, 225, DateTimeKind.Local).AddTicks(8937), null, 1, true, false, true, false, true, true, null, 1000m, "103", 1, 1, 1 },
                    { 5, new DateTime(2025, 4, 4, 1, 0, 10, 225, DateTimeKind.Local).AddTicks(8938), null, 1, true, false, true, false, true, true, null, 1000m, "104", 1, 1, 1 },
                    { 6, new DateTime(2025, 4, 4, 1, 0, 10, 225, DateTimeKind.Local).AddTicks(8940), null, 1, true, false, true, false, true, true, null, 1000m, "105", 1, 1, 1 },
                    { 7, new DateTime(2025, 4, 4, 1, 0, 10, 225, DateTimeKind.Local).AddTicks(8941), null, 1, true, false, true, false, true, true, null, 1000m, "106", 1, 1, 1 },
                    { 8, new DateTime(2025, 4, 4, 1, 0, 10, 225, DateTimeKind.Local).AddTicks(8941), null, 1, true, false, true, false, true, true, null, 1000m, "107", 1, 1, 1 },
                    { 9, new DateTime(2025, 4, 4, 1, 0, 10, 225, DateTimeKind.Local).AddTicks(8942), null, 1, true, false, true, false, true, true, null, 1000m, "108", 1, 1, 1 },
                    { 10, new DateTime(2025, 4, 4, 1, 0, 10, 225, DateTimeKind.Local).AddTicks(8943), null, 1, true, false, true, false, true, true, null, 1000m, "109", 1, 1, 1 },
                    { 11, new DateTime(2025, 4, 4, 1, 0, 10, 225, DateTimeKind.Local).AddTicks(8946), null, 1, true, false, true, false, true, true, null, 1500m, "110", 1, 4, 1 },
                    { 12, new DateTime(2025, 4, 4, 1, 0, 10, 225, DateTimeKind.Local).AddTicks(8947), null, 1, true, false, true, false, true, true, null, 1500m, "111", 1, 4, 1 },
                    { 13, new DateTime(2025, 4, 4, 1, 0, 10, 225, DateTimeKind.Local).AddTicks(8948), null, 1, true, false, true, false, true, true, null, 1500m, "112", 1, 4, 1 },
                    { 14, new DateTime(2025, 4, 4, 1, 0, 10, 225, DateTimeKind.Local).AddTicks(8948), null, 1, true, false, true, false, true, true, null, 1500m, "113", 1, 4, 1 },
                    { 15, new DateTime(2025, 4, 4, 1, 0, 10, 225, DateTimeKind.Local).AddTicks(8949), null, 1, true, false, true, false, true, true, null, 1500m, "114", 1, 4, 1 },
                    { 16, new DateTime(2025, 4, 4, 1, 0, 10, 225, DateTimeKind.Local).AddTicks(8949), null, 1, true, false, true, false, true, true, null, 1500m, "115", 1, 4, 1 },
                    { 17, new DateTime(2025, 4, 4, 1, 0, 10, 225, DateTimeKind.Local).AddTicks(8950), null, 1, true, false, true, false, true, true, null, 1500m, "116", 1, 4, 1 },
                    { 18, new DateTime(2025, 4, 4, 1, 0, 10, 225, DateTimeKind.Local).AddTicks(8951), null, 1, true, false, true, false, true, true, null, 1500m, "117", 1, 4, 1 },
                    { 19, new DateTime(2025, 4, 4, 1, 0, 10, 225, DateTimeKind.Local).AddTicks(8952), null, 1, true, false, true, false, true, true, null, 1500m, "118", 1, 4, 1 },
                    { 20, new DateTime(2025, 4, 4, 1, 0, 10, 225, DateTimeKind.Local).AddTicks(8952), null, 1, true, false, true, false, true, true, null, 1500m, "119", 1, 4, 1 },
                    { 21, new DateTime(2025, 4, 4, 1, 0, 10, 225, DateTimeKind.Local).AddTicks(8954), null, 2, true, false, true, false, true, true, null, 1200m, "200", 1, 1, 1 },
                    { 22, new DateTime(2025, 4, 4, 1, 0, 10, 225, DateTimeKind.Local).AddTicks(8955), null, 2, true, false, true, false, true, true, null, 1200m, "201", 1, 1, 1 },
                    { 23, new DateTime(2025, 4, 4, 1, 0, 10, 225, DateTimeKind.Local).AddTicks(8956), null, 2, true, false, true, false, true, true, null, 1200m, "202", 1, 1, 1 },
                    { 24, new DateTime(2025, 4, 4, 1, 0, 10, 225, DateTimeKind.Local).AddTicks(8956), null, 2, true, false, true, false, true, true, null, 1200m, "203", 1, 1, 1 },
                    { 25, new DateTime(2025, 4, 4, 1, 0, 10, 225, DateTimeKind.Local).AddTicks(8957), null, 2, true, false, true, false, true, true, null, 1200m, "204", 1, 1, 1 },
                    { 26, new DateTime(2025, 4, 4, 1, 0, 10, 225, DateTimeKind.Local).AddTicks(8957), null, 2, true, false, true, false, true, true, null, 1200m, "205", 1, 1, 1 },
                    { 27, new DateTime(2025, 4, 4, 1, 0, 10, 225, DateTimeKind.Local).AddTicks(8958), null, 2, true, false, true, false, true, true, null, 1200m, "206", 1, 1, 1 },
                    { 28, new DateTime(2025, 4, 4, 1, 0, 10, 225, DateTimeKind.Local).AddTicks(8958), null, 2, true, false, true, false, true, true, null, 1200m, "207", 1, 1, 1 },
                    { 29, new DateTime(2025, 4, 4, 1, 0, 10, 225, DateTimeKind.Local).AddTicks(8959), null, 2, true, false, true, false, true, true, null, 1200m, "208", 1, 1, 1 },
                    { 30, new DateTime(2025, 4, 4, 1, 0, 10, 225, DateTimeKind.Local).AddTicks(8959), null, 2, true, false, true, false, true, true, null, 1200m, "209", 1, 1, 1 },
                    { 31, new DateTime(2025, 4, 4, 1, 0, 10, 225, DateTimeKind.Local).AddTicks(8961), null, 2, true, false, true, true, true, true, null, 1800m, "210", 1, 3, 1 },
                    { 32, new DateTime(2025, 4, 4, 1, 0, 10, 225, DateTimeKind.Local).AddTicks(8962), null, 2, true, false, true, true, true, true, null, 1800m, "211", 1, 3, 1 },
                    { 33, new DateTime(2025, 4, 4, 1, 0, 10, 225, DateTimeKind.Local).AddTicks(8963), null, 2, true, false, true, true, true, true, null, 1800m, "212", 1, 3, 1 },
                    { 34, new DateTime(2025, 4, 4, 1, 0, 10, 225, DateTimeKind.Local).AddTicks(8964), null, 2, true, false, true, true, true, true, null, 1800m, "213", 1, 3, 1 },
                    { 35, new DateTime(2025, 4, 4, 1, 0, 10, 225, DateTimeKind.Local).AddTicks(8965), null, 2, true, false, true, true, true, true, null, 1800m, "214", 1, 3, 1 },
                    { 36, new DateTime(2025, 4, 4, 1, 0, 10, 225, DateTimeKind.Local).AddTicks(8965), null, 2, true, false, true, true, true, true, null, 1800m, "215", 1, 3, 1 },
                    { 37, new DateTime(2025, 4, 4, 1, 0, 10, 225, DateTimeKind.Local).AddTicks(8966), null, 2, true, false, true, true, true, true, null, 1800m, "216", 1, 3, 1 },
                    { 38, new DateTime(2025, 4, 4, 1, 0, 10, 225, DateTimeKind.Local).AddTicks(8966), null, 2, true, false, true, true, true, true, null, 1800m, "217", 1, 3, 1 },
                    { 39, new DateTime(2025, 4, 4, 1, 0, 10, 225, DateTimeKind.Local).AddTicks(8967), null, 2, true, false, true, true, true, true, null, 1800m, "218", 1, 3, 1 },
                    { 40, new DateTime(2025, 4, 4, 1, 0, 10, 225, DateTimeKind.Local).AddTicks(8967), null, 2, true, false, true, true, true, true, null, 1800m, "219", 1, 3, 1 },
                    { 41, new DateTime(2025, 4, 4, 1, 0, 10, 225, DateTimeKind.Local).AddTicks(8972), null, 3, true, true, true, true, true, true, null, 2200m, "300", 1, 2, 1 },
                    { 42, new DateTime(2025, 4, 4, 1, 0, 10, 225, DateTimeKind.Local).AddTicks(8973), null, 3, true, true, true, true, true, true, null, 2200m, "301", 1, 2, 1 },
                    { 43, new DateTime(2025, 4, 4, 1, 0, 10, 225, DateTimeKind.Local).AddTicks(8974), null, 3, true, true, true, true, true, true, null, 2200m, "302", 1, 2, 1 },
                    { 44, new DateTime(2025, 4, 4, 1, 0, 10, 225, DateTimeKind.Local).AddTicks(9009), null, 3, true, true, true, true, true, true, null, 2200m, "303", 1, 2, 1 },
                    { 45, new DateTime(2025, 4, 4, 1, 0, 10, 225, DateTimeKind.Local).AddTicks(9010), null, 3, true, true, true, true, true, true, null, 2200m, "304", 1, 2, 1 },
                    { 46, new DateTime(2025, 4, 4, 1, 0, 10, 225, DateTimeKind.Local).AddTicks(9010), null, 3, true, true, true, true, true, true, null, 2200m, "305", 1, 2, 1 },
                    { 47, new DateTime(2025, 4, 4, 1, 0, 10, 225, DateTimeKind.Local).AddTicks(9011), null, 3, true, true, true, true, true, true, null, 2200m, "306", 1, 2, 1 },
                    { 48, new DateTime(2025, 4, 4, 1, 0, 10, 225, DateTimeKind.Local).AddTicks(9012), null, 3, true, true, true, true, true, true, null, 2200m, "307", 1, 2, 1 },
                    { 49, new DateTime(2025, 4, 4, 1, 0, 10, 225, DateTimeKind.Local).AddTicks(9013), null, 3, true, true, true, true, true, true, null, 2200m, "308", 1, 2, 1 },
                    { 50, new DateTime(2025, 4, 4, 1, 0, 10, 225, DateTimeKind.Local).AddTicks(9013), null, 3, true, true, true, true, true, true, null, 2200m, "309", 1, 2, 1 },
                    { 51, new DateTime(2025, 4, 4, 1, 0, 10, 225, DateTimeKind.Local).AddTicks(9015), null, 3, true, true, true, true, true, true, null, 2500m, "310", 1, 5, 1 },
                    { 52, new DateTime(2025, 4, 4, 1, 0, 10, 225, DateTimeKind.Local).AddTicks(9016), null, 3, true, true, true, true, true, true, null, 2500m, "311", 1, 5, 1 },
                    { 53, new DateTime(2025, 4, 4, 1, 0, 10, 225, DateTimeKind.Local).AddTicks(9017), null, 3, true, true, true, true, true, true, null, 2500m, "312", 1, 5, 1 },
                    { 54, new DateTime(2025, 4, 4, 1, 0, 10, 225, DateTimeKind.Local).AddTicks(9017), null, 3, true, true, true, true, true, true, null, 2500m, "313", 1, 5, 1 },
                    { 55, new DateTime(2025, 4, 4, 1, 0, 10, 225, DateTimeKind.Local).AddTicks(9018), null, 3, true, true, true, true, true, true, null, 2500m, "314", 1, 5, 1 },
                    { 56, new DateTime(2025, 4, 4, 1, 0, 10, 225, DateTimeKind.Local).AddTicks(9018), null, 3, true, true, true, true, true, true, null, 2500m, "315", 1, 5, 1 },
                    { 57, new DateTime(2025, 4, 4, 1, 0, 10, 225, DateTimeKind.Local).AddTicks(9019), null, 3, true, true, true, true, true, true, null, 2500m, "316", 1, 5, 1 },
                    { 58, new DateTime(2025, 4, 4, 1, 0, 10, 225, DateTimeKind.Local).AddTicks(9020), null, 3, true, true, true, true, true, true, null, 2500m, "317", 1, 5, 1 },
                    { 59, new DateTime(2025, 4, 4, 1, 0, 10, 225, DateTimeKind.Local).AddTicks(9020), null, 3, true, true, true, true, true, true, null, 2500m, "318", 1, 5, 1 },
                    { 60, new DateTime(2025, 4, 4, 1, 0, 10, 225, DateTimeKind.Local).AddTicks(9021), null, 3, true, true, true, true, true, true, null, 2500m, "319", 1, 5, 1 },
                    { 61, new DateTime(2025, 4, 4, 1, 0, 10, 225, DateTimeKind.Local).AddTicks(9023), null, 4, true, true, true, true, true, true, null, 2800m, "400", 1, 2, 1 },
                    { 62, new DateTime(2025, 4, 4, 1, 0, 10, 225, DateTimeKind.Local).AddTicks(9024), null, 4, true, true, true, true, true, true, null, 2800m, "401", 1, 2, 1 },
                    { 63, new DateTime(2025, 4, 4, 1, 0, 10, 225, DateTimeKind.Local).AddTicks(9024), null, 4, true, true, true, true, true, true, null, 2800m, "402", 1, 2, 1 },
                    { 64, new DateTime(2025, 4, 4, 1, 0, 10, 225, DateTimeKind.Local).AddTicks(9025), null, 4, true, true, true, true, true, true, null, 2800m, "403", 1, 2, 1 },
                    { 65, new DateTime(2025, 4, 4, 1, 0, 10, 225, DateTimeKind.Local).AddTicks(9025), null, 4, true, true, true, true, true, true, null, 2800m, "404", 1, 2, 1 },
                    { 66, new DateTime(2025, 4, 4, 1, 0, 10, 225, DateTimeKind.Local).AddTicks(9026), null, 4, true, true, true, true, true, true, null, 2800m, "405", 1, 2, 1 },
                    { 67, new DateTime(2025, 4, 4, 1, 0, 10, 225, DateTimeKind.Local).AddTicks(9027), null, 4, true, true, true, true, true, true, null, 2800m, "406", 1, 2, 1 },
                    { 68, new DateTime(2025, 4, 4, 1, 0, 10, 225, DateTimeKind.Local).AddTicks(9028), null, 4, true, true, true, true, true, true, null, 2800m, "407", 1, 2, 1 },
                    { 69, new DateTime(2025, 4, 4, 1, 0, 10, 225, DateTimeKind.Local).AddTicks(9028), null, 4, true, true, true, true, true, true, null, 2800m, "408", 1, 2, 1 },
                    { 70, new DateTime(2025, 4, 4, 1, 0, 10, 225, DateTimeKind.Local).AddTicks(9029), null, 4, true, true, true, true, true, true, null, 2800m, "409", 1, 2, 1 },
                    { 71, new DateTime(2025, 4, 4, 1, 0, 10, 225, DateTimeKind.Local).AddTicks(9030), null, 4, true, true, true, true, true, true, null, 3500m, "410", 1, 6, 1 },
                    { 72, new DateTime(2025, 4, 4, 1, 0, 10, 225, DateTimeKind.Local).AddTicks(9031), null, 4, true, true, true, true, true, true, null, 3500m, "411", 1, 6, 1 },
                    { 73, new DateTime(2025, 4, 4, 1, 0, 10, 225, DateTimeKind.Local).AddTicks(9032), null, 4, true, true, true, true, true, true, null, 3500m, "412", 1, 6, 1 },
                    { 74, new DateTime(2025, 4, 4, 1, 0, 10, 225, DateTimeKind.Local).AddTicks(9032), null, 4, true, true, true, true, true, true, null, 3500m, "413", 1, 6, 1 },
                    { 75, new DateTime(2025, 4, 4, 1, 0, 10, 225, DateTimeKind.Local).AddTicks(9033), null, 4, true, true, true, true, true, true, null, 3500m, "414", 1, 6, 1 },
                    { 76, new DateTime(2025, 4, 4, 1, 0, 10, 225, DateTimeKind.Local).AddTicks(9033), null, 4, true, true, true, true, true, true, null, 3500m, "415", 1, 6, 1 },
                    { 77, new DateTime(2025, 4, 4, 1, 0, 10, 225, DateTimeKind.Local).AddTicks(9035), null, 4, true, true, true, true, true, true, null, 10000m, "417", 1, 7, 1 }
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
