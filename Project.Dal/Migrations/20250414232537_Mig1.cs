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
                    { 1, "a66c0d55-3ec6-4786-83e3-1949cdba315b", "Admin", "ADMIN" },
                    { 2, "10ab751f-c377-4dc1-8d01-88872d84b36b", "Member", "MEMBER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ActivationCode", "ConcurrencyStamp", "CreatedDate", "DeletedDate", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "ModifiedDate", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Status", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { 1, 0, new Guid("00000000-0000-0000-0000-000000000000"), "a04eea05-c719-4595-be1d-d9ef3c610f7b", new DateTime(2025, 4, 15, 2, 25, 36, 989, DateTimeKind.Local).AddTicks(4951), null, "bilgehotel@email.com", true, false, null, null, "BILGEHOTEL@EMAIL.COM", "BILGEHOTEL", "AQAAAAIAAYagAAAAEGWmybs5ZKh8hm7Z/wv3wWiPaSZnCr4D4Us0UwRJVPXzvxp5wcK5Vy9/HZ7tcwCtOA==", null, false, "78b6d0b5-4555-4316-b920-94a1dda39bb3", 1, false, "bilgehotel" },
                    { 2, 0, new Guid("00000000-0000-0000-0000-000000000000"), "fb18a74a-00c6-4017-b8dc-e5fc64085289", new DateTime(2025, 4, 15, 2, 25, 37, 27, DateTimeKind.Local).AddTicks(947), null, "testmember@email.com", true, false, null, null, "TESTMEMBER@EMAIL.COM", "TESTMEMBER", "AQAAAAIAAYagAAAAENS4bVvyvvzEabI+xi/QvbSHUu46hr5uf/QMbTiqWQ4N/tgtfYWbfQeOG5Gpmktdmg==", null, false, "79561e5b-5a5f-4f17-9e89-631dc833d0cd", 1, false, "testmember" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Address", "BirthDate", "CreatedDate", "DeletedDate", "FirstName", "HireDate", "LastName", "ModifiedDate", "PhoneNumber", "Position", "Salary", "Shift", "Status" },
                values: new object[,]
                {
                    { 1, "Köypınar Sokak 80c, Bolu, Doğu Timor", new DateTime(2001, 5, 4, 3, 13, 25, 922, DateTimeKind.Local).AddTicks(5493), new DateTime(2025, 4, 15, 2, 25, 36, 951, DateTimeKind.Local).AddTicks(3967), null, "Arıkdoruk", new DateTime(2014, 11, 22, 18, 19, 12, 178, DateTimeKind.Local).AddTicks(6652), "Tokatlıoğlu", null, "+905132308080", "Resepsiyonist", 53814.39m, 3, 1 },
                    { 2, "Namık Kemal Caddesi 99c, İzmir, Hindistan", new DateTime(1977, 1, 24, 9, 38, 56, 219, DateTimeKind.Local).AddTicks(8030), new DateTime(2025, 4, 15, 2, 25, 36, 951, DateTimeKind.Local).AddTicks(4031), null, "Bilgeçikşin", new DateTime(2017, 1, 11, 2, 22, 2, 45, DateTimeKind.Local).AddTicks(9973), "Topçuoğlu", null, "+905409034514", "Resepsiyonist", 57593.55m, 2, 1 },
                    { 3, "Dağınık Evler Sokak 17a, Şanlıurfa, Kuzey Maryana Adaları", new DateTime(1971, 11, 16, 17, 44, 29, 86, DateTimeKind.Local).AddTicks(9268), new DateTime(2025, 4, 15, 2, 25, 36, 951, DateTimeKind.Local).AddTicks(4101), null, "Beyrek", new DateTime(2016, 11, 29, 12, 21, 47, 414, DateTimeKind.Local).AddTicks(4411), "Çevik", null, "+905269782172", "Resepsiyonist", 53809.92m, 1, 1 },
                    { 4, "Ülkü Sokak 96, Erzincan, Ukrayna", new DateTime(1980, 11, 11, 7, 42, 40, 730, DateTimeKind.Local).AddTicks(2922), new DateTime(2025, 4, 15, 2, 25, 36, 951, DateTimeKind.Local).AddTicks(4186), null, "Çiçem", new DateTime(2018, 10, 14, 0, 29, 17, 169, DateTimeKind.Local).AddTicks(8883), "Sepetçi", null, "+905608888687", "Resepsiyonist", 46102.52m, 3, 1 },
                    { 5, "Bahçe Sokak 02, Uşak, Tacikistan", new DateTime(1993, 3, 2, 4, 21, 22, 422, DateTimeKind.Local).AddTicks(5716), new DateTime(2025, 4, 15, 2, 25, 36, 951, DateTimeKind.Local).AddTicks(4235), null, "Engin", new DateTime(2016, 1, 22, 4, 55, 20, 374, DateTimeKind.Local).AddTicks(4371), "Tokgöz", null, "+905806876801", "Resepsiyonist", 53905.28m, 1, 1 },
                    { 6, "Okul Sokak 42b, Kırşehir, Burkina Faso", new DateTime(1973, 2, 13, 15, 30, 11, 455, DateTimeKind.Local).AddTicks(2130), new DateTime(2025, 4, 15, 2, 25, 36, 951, DateTimeKind.Local).AddTicks(4320), null, "Arslanargun", new DateTime(2016, 6, 26, 16, 5, 59, 192, DateTimeKind.Local).AddTicks(2504), "Yazıcı", null, "+905318262947", "Resepsiyonist", 52241.57m, 3, 1 },
                    { 7, "Oğuzhan Sokak 6, Şırnak, Porto Riko, Amerika", new DateTime(1969, 5, 28, 13, 53, 18, 725, DateTimeKind.Local).AddTicks(7221), new DateTime(2025, 4, 15, 2, 25, 36, 951, DateTimeKind.Local).AddTicks(4400), null, "Belgi", new DateTime(2021, 12, 28, 1, 47, 36, 892, DateTimeKind.Local).AddTicks(3436), "Balcı", null, "+905258035740", "Resepsiyonist", 41864.51m, 1, 1 },
                    { 8, "Harman Altı Sokak 90a, Yozgat, Svaziland", new DateTime(1969, 6, 25, 17, 40, 59, 209, DateTimeKind.Local).AddTicks(6220), new DateTime(2025, 4, 15, 2, 25, 36, 951, DateTimeKind.Local).AddTicks(4453), null, "Bayram", new DateTime(2019, 6, 12, 0, 17, 22, 190, DateTimeKind.Local).AddTicks(5929), "Çapanoğlu", null, "+905234388006", "Temizlik Görevlisi", 27832.49m, 2, 1 },
                    { 9, "Dağınık Evler Sokak 531, Elazığ, Slovakya", new DateTime(1981, 10, 13, 0, 0, 15, 88, DateTimeKind.Local).AddTicks(7646), new DateTime(2025, 4, 15, 2, 25, 36, 951, DateTimeKind.Local).AddTicks(4546), null, "Gelin", new DateTime(2019, 8, 24, 11, 53, 28, 677, DateTimeKind.Local).AddTicks(8246), "Çetin", null, "+905175025062", "Temizlik Görevlisi", 30972.42m, 2, 1 },
                    { 10, "Afyon Kaya Sokak 41b, Zonguldak, Lüksemburg", new DateTime(1968, 12, 24, 16, 6, 16, 914, DateTimeKind.Local).AddTicks(5435), new DateTime(2025, 4, 15, 2, 25, 36, 951, DateTimeKind.Local).AddTicks(4730), null, "Erdeni", new DateTime(2022, 9, 15, 4, 32, 52, 659, DateTimeKind.Local).AddTicks(6356), "Duygulu", null, "+905438683974", "Temizlik Görevlisi", 31759.90m, 2, 1 },
                    { 11, "Ali Çetinkaya Caddesi 03b, Gaziantep, Orta Afrika Cumhuriyeti", new DateTime(1981, 8, 15, 1, 41, 54, 517, DateTimeKind.Local).AddTicks(4416), new DateTime(2025, 4, 15, 2, 25, 36, 951, DateTimeKind.Local).AddTicks(4795), null, "Kayaçık", new DateTime(2023, 5, 3, 9, 38, 49, 751, DateTimeKind.Local).AddTicks(5405), "Korol", null, "+905750943729", "Temizlik Görevlisi", 32883.19m, 1, 1 },
                    { 12, "Gül Sokak 34b, Aydın, Ermenistan", new DateTime(1990, 4, 15, 14, 30, 1, 290, DateTimeKind.Local).AddTicks(8302), new DateTime(2025, 4, 15, 2, 25, 36, 951, DateTimeKind.Local).AddTicks(4865), null, "Altay", new DateTime(2020, 5, 16, 10, 28, 29, 770, DateTimeKind.Local).AddTicks(475), "Kocabıyık", null, "+905244712782", "Temizlik Görevlisi", 25552.07m, 1, 1 },
                    { 13, "Mevlana Sokak 0, Karaman, Kuveyt", new DateTime(1974, 10, 14, 3, 6, 39, 398, DateTimeKind.Local).AddTicks(3312), new DateTime(2025, 4, 15, 2, 25, 36, 951, DateTimeKind.Local).AddTicks(4909), null, "Bağan", new DateTime(2018, 10, 5, 0, 55, 12, 683, DateTimeKind.Local).AddTicks(4826), "Yetkiner", null, "+905387288794", "Temizlik Görevlisi", 29279.13m, 1, 1 },
                    { 14, "Köypınar Sokak 40, Adana, Nijer", new DateTime(1997, 8, 15, 6, 59, 57, 250, DateTimeKind.Local).AddTicks(3642), new DateTime(2025, 4, 15, 2, 25, 36, 951, DateTimeKind.Local).AddTicks(4974), null, "Ergenekatun", new DateTime(2023, 10, 13, 1, 41, 30, 539, DateTimeKind.Local).AddTicks(7925), "Akal", null, "+905320380693", "Temizlik Görevlisi", 32270.52m, 2, 1 },
                    { 15, "Alparslan Türkeş Bulvarı 85, Niğde, Guam, Amerika", new DateTime(1975, 6, 16, 8, 19, 13, 572, DateTimeKind.Local).AddTicks(3886), new DateTime(2025, 4, 15, 2, 25, 36, 951, DateTimeKind.Local).AddTicks(5041), null, "Kızılalma", new DateTime(2023, 12, 15, 17, 17, 3, 431, DateTimeKind.Local).AddTicks(8755), "Çağıran", null, "+905610932476", "Temizlik Görevlisi", 31344.28m, 1, 1 },
                    { 16, "Oğuzhan Sokak 8, Tunceli, Hırvatistan", new DateTime(1967, 12, 18, 12, 48, 47, 170, DateTimeKind.Local).AddTicks(7298), new DateTime(2025, 4, 15, 2, 25, 36, 951, DateTimeKind.Local).AddTicks(5085), null, "Baydar", new DateTime(2021, 5, 19, 14, 26, 43, 380, DateTimeKind.Local).AddTicks(6825), "Evliyaoğlu", null, "+905754107206", "Temizlik Görevlisi", 26750.82m, 1, 1 },
                    { 17, "Harman Altı Sokak 03b, Kocaeli, Angola", new DateTime(1984, 9, 25, 21, 4, 27, 546, DateTimeKind.Local).AddTicks(592), new DateTime(2025, 4, 15, 2, 25, 36, 951, DateTimeKind.Local).AddTicks(5160), null, "Bükdüz", new DateTime(2019, 6, 25, 15, 46, 1, 954, DateTimeKind.Local).AddTicks(3387), "Erginsoy", null, "+905857917343", "Temizlik Görevlisi", 34568.40m, 2, 1 },
                    { 18, "Mevlana Sokak 202, Ankara, Galler", new DateTime(1985, 4, 17, 10, 45, 43, 405, DateTimeKind.Local).AddTicks(1881), new DateTime(2025, 4, 15, 2, 25, 36, 951, DateTimeKind.Local).AddTicks(5238), null, "Arınç", new DateTime(2022, 5, 18, 8, 5, 20, 421, DateTimeKind.Local).AddTicks(6168), "Akışık", null, "+905126854135", "Temizlik Görevlisi", 33175.80m, 1, 1 },
                    { 19, "Nalbant Sokak 888, Kocaeli, Brunei", new DateTime(1999, 9, 19, 16, 35, 31, 4, DateTimeKind.Local).AddTicks(2146), new DateTime(2025, 4, 15, 2, 25, 36, 951, DateTimeKind.Local).AddTicks(5285), null, "Çağrıbeğ", new DateTime(2023, 8, 7, 11, 32, 53, 687, DateTimeKind.Local).AddTicks(540), "Kutlay", null, "+905247195471", "Aşçı", 108110.55m, 2, 1 },
                    { 20, "Oğuzhan Sokak 56a, Adıyaman, Gine-Bissau", new DateTime(1996, 4, 3, 6, 4, 42, 525, DateTimeKind.Local).AddTicks(1662), new DateTime(2025, 4, 15, 2, 25, 36, 951, DateTimeKind.Local).AddTicks(5353), null, "İtil", new DateTime(2022, 1, 15, 1, 24, 21, 87, DateTimeKind.Local).AddTicks(7959), "Okumuş", null, "+905099134692", "Aşçı", 104733.64m, 1, 1 },
                    { 21, "Okul Sokak 92c, Çorum, Monako", new DateTime(1996, 6, 12, 22, 56, 3, 239, DateTimeKind.Local).AddTicks(5769), new DateTime(2025, 4, 15, 2, 25, 36, 951, DateTimeKind.Local).AddTicks(5422), null, "Aykağan", new DateTime(2016, 8, 9, 0, 24, 49, 496, DateTimeKind.Local).AddTicks(5120), "Kocabıyık", null, "+905706532275", "Aşçı", 112985.03m, 1, 1 },
                    { 22, "Ali Çetinkaya Caddesi 36, Tunceli, Bangladeş", new DateTime(1994, 10, 6, 22, 44, 44, 156, DateTimeKind.Local).AddTicks(9095), new DateTime(2025, 4, 15, 2, 25, 36, 951, DateTimeKind.Local).AddTicks(5464), null, "Ayluç", new DateTime(2016, 5, 3, 13, 32, 49, 735, DateTimeKind.Local).AddTicks(4414), "Biçer", null, "+905072762056", "Aşçı", 102477.45m, 2, 1 },
                    { 23, "Bayır Sokak 98b, Iğdır, Vanuatu", new DateTime(1978, 12, 21, 22, 38, 15, 654, DateTimeKind.Local).AddTicks(1206), new DateTime(2025, 4, 15, 2, 25, 36, 951, DateTimeKind.Local).AddTicks(5556), null, "Çölü", new DateTime(2014, 7, 11, 13, 51, 36, 324, DateTimeKind.Local).AddTicks(8744), "Köybaşı", null, "+905691431088", "Aşçı", 105027.75m, 1, 1 },
                    { 24, "Menekşe Sokak 81, Konya, Azerbaycan", new DateTime(1980, 8, 5, 15, 48, 41, 653, DateTimeKind.Local).AddTicks(1444), new DateTime(2025, 4, 15, 2, 25, 36, 951, DateTimeKind.Local).AddTicks(5663), null, "Beyrek", new DateTime(2016, 11, 16, 7, 53, 59, 307, DateTimeKind.Local).AddTicks(6368), "Mertoğlu", null, "+905020884441", "Aşçı", 116822.72m, 2, 1 },
                    { 25, "Afyon Kaya Sokak 866, Uşak, Hollanda Antilleri", new DateTime(1987, 4, 13, 4, 45, 14, 752, DateTimeKind.Local).AddTicks(8908), new DateTime(2025, 4, 15, 2, 25, 36, 951, DateTimeKind.Local).AddTicks(5707), null, "Aydoğmuş", new DateTime(2017, 3, 25, 1, 9, 39, 96, DateTimeKind.Local).AddTicks(7040), "Çevik", null, "+905491448714", "Aşçı", 103454.47m, 2, 1 },
                    { 26, "Kaldırım Sokak 93b, Amasya, Senegal", new DateTime(2001, 5, 2, 7, 20, 8, 615, DateTimeKind.Local).AddTicks(2450), new DateTime(2025, 4, 15, 2, 25, 36, 951, DateTimeKind.Local).AddTicks(5773), null, "Başçı", new DateTime(2020, 6, 1, 20, 34, 6, 649, DateTimeKind.Local).AddTicks(2703), "Baykam", null, "+905251162923", "Aşçı", 118629.51m, 2, 1 },
                    { 27, "Fatih Sokak  62a, Aksaray, Senegal", new DateTime(1974, 2, 25, 12, 28, 51, 751, DateTimeKind.Local).AddTicks(3818), new DateTime(2025, 4, 15, 2, 25, 36, 951, DateTimeKind.Local).AddTicks(5845), null, "Güvercin", new DateTime(2014, 10, 20, 6, 45, 38, 270, DateTimeKind.Local).AddTicks(1837), "Tekelioğlu", null, "+905469774099", "Aşçı", 109248.77m, 2, 1 },
                    { 28, "İsmet Attila Caddesi 66b, Şırnak, Tonga", new DateTime(1984, 4, 16, 20, 43, 6, 696, DateTimeKind.Local).AddTicks(1978), new DateTime(2025, 4, 15, 2, 25, 36, 951, DateTimeKind.Local).AddTicks(5887), null, "Gelin", new DateTime(2018, 9, 20, 19, 13, 13, 712, DateTimeKind.Local).AddTicks(7314), "Berberoğlu", null, "+905977139182", "Aşçı", 114206.97m, 1, 1 },
                    { 29, "Sarıkaya Caddesi 05a, Kırıkkale, Johnston Atoll, Amerika", new DateTime(1993, 5, 30, 3, 37, 35, 593, DateTimeKind.Local).AddTicks(18), new DateTime(2025, 4, 15, 2, 25, 36, 951, DateTimeKind.Local).AddTicks(5987), null, "Arslantegin", new DateTime(2015, 9, 30, 7, 17, 17, 40, DateTimeKind.Local).AddTicks(9335), "Tekand", null, "+905705269734", "Aşçı", 119297.78m, 2, 1 },
                    { 30, "Bahçe Sokak 1, Antalya, Sudan", new DateTime(1991, 4, 9, 19, 37, 7, 857, DateTimeKind.Local).AddTicks(9030), new DateTime(2025, 4, 15, 2, 25, 36, 951, DateTimeKind.Local).AddTicks(6030), null, "Adalmış", new DateTime(2022, 1, 1, 12, 55, 33, 291, DateTimeKind.Local).AddTicks(235), "Koçoğlu", null, "+905502944810", "Garson", 93970.24m, 2, 1 },
                    { 31, "Menekşe Sokak 3, Denizli, Kamerun", new DateTime(1990, 10, 27, 11, 23, 24, 414, DateTimeKind.Local).AddTicks(6565), new DateTime(2025, 4, 15, 2, 25, 36, 951, DateTimeKind.Local).AddTicks(6114), null, "Kepez", new DateTime(2016, 6, 18, 11, 59, 53, 809, DateTimeKind.Local).AddTicks(4041), "Özbey", null, "+905781908085", "Garson", 84192.18m, 2, 1 },
                    { 32, "Atatürk Bulvarı 58c, Ankara, Gine-Bissau", new DateTime(2007, 2, 6, 13, 5, 4, 27, DateTimeKind.Local).AddTicks(9236), new DateTime(2025, 4, 15, 2, 25, 36, 951, DateTimeKind.Local).AddTicks(6180), null, "Inanç", new DateTime(2016, 1, 31, 19, 35, 33, 800, DateTimeKind.Local).AddTicks(9364), "Baturalp", null, "+905010872588", "Garson", 91699.91m, 1, 1 },
                    { 33, "Gül Sokak 32b, Konya, Guatemala", new DateTime(1968, 2, 10, 7, 28, 10, 858, DateTimeKind.Local).AddTicks(4185), new DateTime(2025, 4, 15, 2, 25, 36, 951, DateTimeKind.Local).AddTicks(6220), null, "Aşan", new DateTime(2022, 3, 18, 14, 43, 31, 734, DateTimeKind.Local).AddTicks(7996), "Yazıcı", null, "+905633138074", "Garson", 86999.86m, 2, 1 },
                    { 34, "Dağınık Evler Sokak 35a, Sakarya, Romanya", new DateTime(1975, 1, 1, 1, 14, 49, 158, DateTimeKind.Local).AddTicks(1079), new DateTime(2025, 4, 15, 2, 25, 36, 951, DateTimeKind.Local).AddTicks(6290), null, "Begine", new DateTime(2022, 5, 20, 21, 56, 27, 146, DateTimeKind.Local).AddTicks(2135), "Köybaşı", null, "+905061839266", "Garson", 99743.98m, 2, 1 },
                    { 35, "Lütfi Karadirek Caddesi 8, Denizli, Guadalup, Fransa", new DateTime(1994, 9, 21, 21, 13, 41, 742, DateTimeKind.Local).AddTicks(2498), new DateTime(2025, 4, 15, 2, 25, 36, 951, DateTimeKind.Local).AddTicks(6357), null, "Kımızalma", new DateTime(2021, 11, 17, 9, 57, 0, 115, DateTimeKind.Local).AddTicks(3500), "Akar ", null, "+905191913126", "Garson", 85129.76m, 1, 1 },
                    { 36, "Harman Yolu Sokak  81b, Amasya, Afganistan", new DateTime(1993, 10, 21, 19, 20, 53, 370, DateTimeKind.Local).AddTicks(3252), new DateTime(2025, 4, 15, 2, 25, 36, 951, DateTimeKind.Local).AddTicks(6399), null, "Atasagun", new DateTime(2021, 1, 6, 1, 44, 49, 384, DateTimeKind.Local).AddTicks(7642), "Mertoğlu", null, "+905615211198", "Garson", 97768.68m, 1, 1 },
                    { 37, "Menekşe Sokak 75a, Bolu, Bulgaristan", new DateTime(1972, 6, 10, 21, 20, 46, 259, DateTimeKind.Local).AddTicks(4601), new DateTime(2025, 4, 15, 2, 25, 36, 951, DateTimeKind.Local).AddTicks(6463), null, "Bağaalp", new DateTime(2020, 1, 13, 14, 55, 58, 880, DateTimeKind.Local).AddTicks(6348), "Ilıcalı", null, "+905539766986", "Garson", 71052.45m, 1, 1 },
                    { 38, "Menekşe Sokak 70b, İzmir, Cibuti", new DateTime(1969, 4, 25, 0, 13, 54, 643, DateTimeKind.Local).AddTicks(8772), new DateTime(2025, 4, 15, 2, 25, 36, 951, DateTimeKind.Local).AddTicks(6521), null, "Balkık", new DateTime(2014, 9, 10, 18, 7, 57, 911, DateTimeKind.Local).AddTicks(2847), "Dağdaş", null, "+905465423383", "Garson", 76308.79m, 2, 1 },
                    { 39, "Köypınar Sokak 660, Diyarbakır, Kenya", new DateTime(2004, 8, 13, 22, 54, 45, 344, DateTimeKind.Local).AddTicks(3779), new DateTime(2025, 4, 15, 2, 25, 36, 951, DateTimeKind.Local).AddTicks(6563), null, "Günyaruk", new DateTime(2017, 9, 14, 10, 51, 41, 583, DateTimeKind.Local).AddTicks(8940), "Öztonga", null, "+905757059021", "Garson", 81543.14m, 1, 1 },
                    { 40, "Barış Sokak 65a, Adıyaman, Belçika", new DateTime(1994, 2, 10, 15, 29, 35, 567, DateTimeKind.Local).AddTicks(8118), new DateTime(2025, 4, 15, 2, 25, 36, 951, DateTimeKind.Local).AddTicks(6652), null, "Alpaya", new DateTime(2016, 4, 24, 22, 38, 9, 492, DateTimeKind.Local).AddTicks(7797), "Yalçın", null, "+905676770813", "Garson", 84669.65m, 2, 1 },
                    { 41, "Güven Yaka Sokak 8, Eskişehir, Laos", new DateTime(1973, 11, 26, 8, 7, 9, 618, DateTimeKind.Local).AddTicks(2805), new DateTime(2025, 4, 15, 2, 25, 36, 951, DateTimeKind.Local).AddTicks(6750), null, "Baysungur", new DateTime(2022, 1, 14, 19, 39, 33, 270, DateTimeKind.Local).AddTicks(4671), "Yıldızoğlu", null, "+905093178191", "Garson", 94293.18m, 2, 1 },
                    { 42, "Kaldırım Sokak 16b, Aydın, Hollanda Antilleri", new DateTime(1991, 10, 23, 5, 27, 28, 308, DateTimeKind.Local).AddTicks(4138), new DateTime(2025, 4, 15, 2, 25, 36, 951, DateTimeKind.Local).AddTicks(6792), null, "Çocukbörü", new DateTime(2015, 3, 22, 19, 32, 4, 746, DateTimeKind.Local).AddTicks(4856), "Kunt", null, "+905527747923", "Garson", 93995.60m, 1, 1 },
                    { 43, "Afyon Kaya Sokak 91c, Aydın, Fas", new DateTime(1990, 9, 4, 3, 51, 36, 902, DateTimeKind.Local).AddTicks(4748), new DateTime(2025, 4, 15, 2, 25, 36, 951, DateTimeKind.Local).AddTicks(6868), null, "Balaka", new DateTime(2022, 12, 15, 6, 56, 43, 807, DateTimeKind.Local).AddTicks(4285), "Yalçın", null, "+905184668818", "Elektrikçi", 137036.92m, 3, 1 },
                    { 44, "Sağlık Sokak 9, Adıyaman, Suudi Arabistan", new DateTime(1978, 10, 21, 9, 33, 10, 75, DateTimeKind.Local).AddTicks(4079), new DateTime(2025, 4, 15, 2, 25, 36, 951, DateTimeKind.Local).AddTicks(6940), null, "Arçuk", new DateTime(2016, 7, 13, 13, 19, 31, 975, DateTimeKind.Local).AddTicks(7096), "Ağaoğlu", null, "+905575520801", "IT Sorumlusu", 151881.50m, 3, 1 }
                });

            migrationBuilder.InsertData(
                table: "ExtraServices",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Description", "ModifiedDate", "Name", "Price", "Status" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 4, 15, 2, 25, 37, 27, DateTimeKind.Local).AddTicks(1131), null, "Günlük sınırsız spa kullanımı.", null, "Spa Kullanımı", 3000m, 1 },
                    { 2, new DateTime(2025, 4, 15, 2, 25, 37, 27, DateTimeKind.Local).AddTicks(1133), null, "24 saat oda servisi. Tüm yemek siparişleri dahildir.", null, "Oda Servisi", 1500m, 1 },
                    { 3, new DateTime(2025, 4, 15, 2, 25, 37, 27, DateTimeKind.Local).AddTicks(1134), null, "Minibardaki içecekler ve atıştırmalıklar dahil.", null, "Minibar Kullanımı", 1000m, 1 },
                    { 4, new DateTime(2025, 4, 15, 2, 25, 37, 27, DateTimeKind.Local).AddTicks(1135), null, "Gidiş-dönüş özel araç transferi.", null, "Havalimanı Transferi", 5000m, 1 },
                    { 5, new DateTime(2025, 4, 15, 2, 25, 37, 27, DateTimeKind.Local).AddTicks(1137), null, "Konaklama süresince ücretsiz çamaşır ve kuru temizleme hizmeti.", null, "Çamaşırhane Hizmeti", 500m, 1 },
                    { 6, new DateTime(2025, 4, 15, 2, 25, 37, 27, DateTimeKind.Local).AddTicks(1140), null, "Ekstra günlük temizlik ve hijyen paketi.", null, "Günlük Oda Temizliği", 500m, 1 },
                    { 7, new DateTime(2025, 4, 15, 2, 25, 37, 27, DateTimeKind.Local).AddTicks(1142), null, "Özel şezlong ve plaj hizmetleri.", null, "Özel Plaj Alanı", 7500m, 1 }
                });

            migrationBuilder.InsertData(
                table: "Packages",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Description", "ModifiedDate", "Name", "PriceMultiplier", "Status" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 4, 15, 2, 25, 37, 27, DateTimeKind.Local).AddTicks(1098), null, "Kahvaltı, öğle ve akşam yemeği dahil.", null, "Tam Pansiyon", 1.2m, 1 },
                    { 2, new DateTime(2025, 4, 15, 2, 25, 37, 27, DateTimeKind.Local).AddTicks(1101), null, "Tüm yemekler, alkollü-alkolsüz içecekler ve otelin sunduğu belirli hizmetler dahil.", null, "Her Şey Dahil", 1.5m, 1 }
                });

            migrationBuilder.InsertData(
                table: "RoomTypes",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Description", "ModifiedDate", "Name", "Status" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 4, 15, 2, 25, 36, 949, DateTimeKind.Local).AddTicks(7037), null, "1 adet tek kişilik yatak. Balkon ve minibar bulunmaz. Klima, TV, saç kurutma makinesi ve WiFi mevcuttur.", null, "Tek Kişilik", 1 },
                    { 2, new DateTime(2025, 4, 15, 2, 25, 36, 949, DateTimeKind.Local).AddTicks(7047), null, "1 adet büyük (duble) yatak. Klima, TV, saç kurutma makinesi ve WiFi mevcuttur.", null, "Çift Kişilik (Duble)", 1 },
                    { 3, new DateTime(2025, 4, 15, 2, 25, 36, 949, DateTimeKind.Local).AddTicks(7048), null, "2 adet tek kişilik yatak. Klima, TV, saç kurutma makinesi ve WiFi mevcuttur.", null, "Çift Kişilik (Tek Kişilik 2 Yataklı)", 1 },
                    { 4, new DateTime(2025, 4, 15, 2, 25, 36, 949, DateTimeKind.Local).AddTicks(7050), null, "3 adet tek kişilik yatak.  Klima, TV, saç kurutma makinesi ve WiFi mevcuttur.", null, "Üç Kişilik (Tek Kişilik 3 Yataklı)", 1 },
                    { 5, new DateTime(2025, 4, 15, 2, 25, 36, 949, DateTimeKind.Local).AddTicks(7051), null, "Bir tek bir duble yatak.  Klima, TV, saç kurutma makinesi ve WiFi mevcuttur.", null, "Üç Kişilik (1 Tek, 1 Duble Yataklı)", 1 },
                    { 6, new DateTime(2025, 4, 15, 2, 25, 36, 949, DateTimeKind.Local).AddTicks(7053), null, "1 adet büyük (duble) yatak + 2 adet tek kişilik yatak. Klima, TV, saç kurutma makinesi ve WiFi mevcuttur.", null, "Dört Kişilik", 1 },
                    { 7, new DateTime(2025, 4, 15, 2, 25, 36, 949, DateTimeKind.Local).AddTicks(7054), null, "Geniş ve lüks oda. Özel oturma alanı, büyük yatak, balkon, minibar, özel banyo ve lüks hizmetler. Klima, TV, saç kurutma makinesi, WiFi ve özel hizmetler mevcuttur.", null, "Kral Dairesi", 1 }
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
                    { 1, "Bilgisayar", new DateTime(2025, 4, 15, 2, 25, 37, 27, DateTimeKind.Local).AddTicks(1163), null, "Intel i5 - 8GB RAM", 44, "Resepsiyon", null, "Masaüstü PC", "PC-RSP-001", 1 },
                    { 2, "Bilgisayar", new DateTime(2025, 4, 15, 2, 25, 37, 27, DateTimeKind.Local).AddTicks(1163), null, "Intel i5 - 8GB RAM", 44, "Resepsiyon", null, "Masaüstü PC", "PC-RSP-002", 1 },
                    { 3, "Bilgisayar", new DateTime(2025, 4, 15, 2, 25, 37, 27, DateTimeKind.Local).AddTicks(1163), null, "Intel i3 - 4GB RAM", 44, "Resepsiyon", null, "Masaüstü PC", "PC-RSP-003", 1 },
                    { 4, "Bilgisayar", new DateTime(2025, 4, 15, 2, 25, 37, 27, DateTimeKind.Local).AddTicks(1163), null, "Intel i7 - 16GB RAM", 44, "Resepsiyon", null, "Masaüstü PC", "PC-RSP-004", 1 },
                    { 5, "Bilgisayar", new DateTime(2025, 4, 15, 2, 25, 37, 27, DateTimeKind.Local).AddTicks(1163), null, "All-in-One Dokunmatik", 44, "Bar", null, "Bar Terminali", "PC-BAR-001", 1 },
                    { 6, "Bilgisayar", new DateTime(2025, 4, 15, 2, 25, 37, 27, DateTimeKind.Local).AddTicks(1163), null, "Mini PC - Fanless", 44, "Havuzbaşı snackbar", null, "Havuzbaşı PC", "PC-HAVUZ-001", 1 },
                    { 7, "Bilgisayar", new DateTime(2025, 4, 15, 2, 25, 37, 27, DateTimeKind.Local).AddTicks(1163), null, "Dell Latitude", 44, "Yönetim Ofisi", null, "Yönetici Laptop", "PC-OFC-001", 1 },
                    { 8, "Bilgisayar", new DateTime(2025, 4, 15, 2, 25, 37, 27, DateTimeKind.Local).AddTicks(1163), null, "Lenovo ThinkPad", 44, "Yönetim Ofisi", null, "Yönetici Laptop", "PC-OFC-002", 1 },
                    { 9, "Bilgisayar", new DateTime(2025, 4, 15, 2, 25, 37, 27, DateTimeKind.Local).AddTicks(1163), null, "HP EliteBook", 44, "Yönetim Ofisi", null, "Yönetici Laptop", "PC-OFC-003", 1 },
                    { 10, "Bilgisayar", new DateTime(2025, 4, 15, 2, 25, 37, 27, DateTimeKind.Local).AddTicks(1163), null, "Core i5 - 8GB", 44, "Yönetim Ofisi", null, "Yönetici Masaüstü", "PC-OFC-004", 1 },
                    { 11, "Bilgisayar", new DateTime(2025, 4, 15, 2, 25, 37, 27, DateTimeKind.Local).AddTicks(1163), null, "Core i7 - 16GB", 44, "Yönetim Ofisi", null, "Yönetici Masaüstü", "PC-OFC-005", 1 },
                    { 12, "Bilgisayar", new DateTime(2025, 4, 15, 2, 25, 37, 27, DateTimeKind.Local).AddTicks(1163), null, "Core i3 - 4GB", 44, "Yönetim Ofisi", null, "Yönetici Masaüstü", "PC-OFC-006", 1 },
                    { 13, "Server", new DateTime(2025, 4, 15, 2, 25, 37, 27, DateTimeKind.Local).AddTicks(1163), null, "Windows Server 2003", 44, "Teknik Sunucu Odası", null, "Mail Server", "SRV-001", 1 },
                    { 14, "Server", new DateTime(2025, 4, 15, 2, 25, 37, 27, DateTimeKind.Local).AddTicks(1163), null, "XP Professional - Domain dışı", 44, "Teknik Sunucu Odası", null, "Wireless Router Server", "SRV-002", 1 }
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Floor", "HasAirConditioner", "HasBalcony", "HasHairDryer", "HasMinibar", "HasTV", "HasWifi", "ModifiedDate", "PricePerNight", "RoomNumber", "RoomStatus", "RoomTypeId", "Status" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 4, 15, 2, 25, 36, 949, DateTimeKind.Local).AddTicks(7115), null, 1, true, false, true, false, true, true, null, 1000m, "100", 1, 1, 1 },
                    { 2, new DateTime(2025, 4, 15, 2, 25, 36, 949, DateTimeKind.Local).AddTicks(7117), null, 1, true, false, true, false, true, true, null, 1000m, "101", 1, 1, 1 },
                    { 3, new DateTime(2025, 4, 15, 2, 25, 36, 949, DateTimeKind.Local).AddTicks(7118), null, 1, true, false, true, false, true, true, null, 1000m, "102", 1, 1, 1 },
                    { 4, new DateTime(2025, 4, 15, 2, 25, 36, 949, DateTimeKind.Local).AddTicks(7119), null, 1, true, false, true, false, true, true, null, 1000m, "103", 1, 1, 1 },
                    { 5, new DateTime(2025, 4, 15, 2, 25, 36, 949, DateTimeKind.Local).AddTicks(7120), null, 1, true, false, true, false, true, true, null, 1000m, "104", 1, 1, 1 },
                    { 6, new DateTime(2025, 4, 15, 2, 25, 36, 949, DateTimeKind.Local).AddTicks(7122), null, 1, true, false, true, false, true, true, null, 1000m, "105", 1, 1, 1 },
                    { 7, new DateTime(2025, 4, 15, 2, 25, 36, 949, DateTimeKind.Local).AddTicks(7123), null, 1, true, false, true, false, true, true, null, 1000m, "106", 1, 1, 1 },
                    { 8, new DateTime(2025, 4, 15, 2, 25, 36, 949, DateTimeKind.Local).AddTicks(7123), null, 1, true, false, true, false, true, true, null, 1000m, "107", 1, 1, 1 },
                    { 9, new DateTime(2025, 4, 15, 2, 25, 36, 949, DateTimeKind.Local).AddTicks(7124), null, 1, true, false, true, false, true, true, null, 1000m, "108", 1, 1, 1 },
                    { 10, new DateTime(2025, 4, 15, 2, 25, 36, 949, DateTimeKind.Local).AddTicks(7125), null, 1, true, false, true, false, true, true, null, 1000m, "109", 1, 1, 1 },
                    { 11, new DateTime(2025, 4, 15, 2, 25, 36, 949, DateTimeKind.Local).AddTicks(7128), null, 1, true, false, true, false, true, true, null, 1500m, "110", 1, 4, 1 },
                    { 12, new DateTime(2025, 4, 15, 2, 25, 36, 949, DateTimeKind.Local).AddTicks(7162), null, 1, true, false, true, false, true, true, null, 1500m, "111", 1, 4, 1 },
                    { 13, new DateTime(2025, 4, 15, 2, 25, 36, 949, DateTimeKind.Local).AddTicks(7163), null, 1, true, false, true, false, true, true, null, 1500m, "112", 1, 4, 1 },
                    { 14, new DateTime(2025, 4, 15, 2, 25, 36, 949, DateTimeKind.Local).AddTicks(7164), null, 1, true, false, true, false, true, true, null, 1500m, "113", 1, 4, 1 },
                    { 15, new DateTime(2025, 4, 15, 2, 25, 36, 949, DateTimeKind.Local).AddTicks(7164), null, 1, true, false, true, false, true, true, null, 1500m, "114", 1, 4, 1 },
                    { 16, new DateTime(2025, 4, 15, 2, 25, 36, 949, DateTimeKind.Local).AddTicks(7165), null, 1, true, false, true, false, true, true, null, 1500m, "115", 1, 4, 1 },
                    { 17, new DateTime(2025, 4, 15, 2, 25, 36, 949, DateTimeKind.Local).AddTicks(7166), null, 1, true, false, true, false, true, true, null, 1500m, "116", 1, 4, 1 },
                    { 18, new DateTime(2025, 4, 15, 2, 25, 36, 949, DateTimeKind.Local).AddTicks(7167), null, 1, true, false, true, false, true, true, null, 1500m, "117", 1, 4, 1 },
                    { 19, new DateTime(2025, 4, 15, 2, 25, 36, 949, DateTimeKind.Local).AddTicks(7168), null, 1, true, false, true, false, true, true, null, 1500m, "118", 1, 4, 1 },
                    { 20, new DateTime(2025, 4, 15, 2, 25, 36, 949, DateTimeKind.Local).AddTicks(7169), null, 1, true, false, true, false, true, true, null, 1500m, "119", 1, 4, 1 },
                    { 21, new DateTime(2025, 4, 15, 2, 25, 36, 949, DateTimeKind.Local).AddTicks(7176), null, 2, true, false, true, false, true, true, null, 1200m, "200", 1, 1, 1 },
                    { 22, new DateTime(2025, 4, 15, 2, 25, 36, 949, DateTimeKind.Local).AddTicks(7176), null, 2, true, false, true, false, true, true, null, 1200m, "201", 1, 1, 1 },
                    { 23, new DateTime(2025, 4, 15, 2, 25, 36, 949, DateTimeKind.Local).AddTicks(7177), null, 2, true, false, true, false, true, true, null, 1200m, "202", 1, 1, 1 },
                    { 24, new DateTime(2025, 4, 15, 2, 25, 36, 949, DateTimeKind.Local).AddTicks(7177), null, 2, true, false, true, false, true, true, null, 1200m, "203", 1, 1, 1 },
                    { 25, new DateTime(2025, 4, 15, 2, 25, 36, 949, DateTimeKind.Local).AddTicks(7178), null, 2, true, false, true, false, true, true, null, 1200m, "204", 1, 1, 1 },
                    { 26, new DateTime(2025, 4, 15, 2, 25, 36, 949, DateTimeKind.Local).AddTicks(7178), null, 2, true, false, true, false, true, true, null, 1200m, "205", 1, 1, 1 },
                    { 27, new DateTime(2025, 4, 15, 2, 25, 36, 949, DateTimeKind.Local).AddTicks(7179), null, 2, true, false, true, false, true, true, null, 1200m, "206", 1, 1, 1 },
                    { 28, new DateTime(2025, 4, 15, 2, 25, 36, 949, DateTimeKind.Local).AddTicks(7179), null, 2, true, false, true, false, true, true, null, 1200m, "207", 1, 1, 1 },
                    { 29, new DateTime(2025, 4, 15, 2, 25, 36, 949, DateTimeKind.Local).AddTicks(7181), null, 2, true, false, true, false, true, true, null, 1200m, "208", 1, 1, 1 },
                    { 30, new DateTime(2025, 4, 15, 2, 25, 36, 949, DateTimeKind.Local).AddTicks(7181), null, 2, true, false, true, false, true, true, null, 1200m, "209", 1, 1, 1 },
                    { 31, new DateTime(2025, 4, 15, 2, 25, 36, 949, DateTimeKind.Local).AddTicks(7183), null, 2, true, false, true, true, true, true, null, 1800m, "210", 1, 3, 1 },
                    { 32, new DateTime(2025, 4, 15, 2, 25, 36, 949, DateTimeKind.Local).AddTicks(7184), null, 2, true, false, true, true, true, true, null, 1800m, "211", 1, 3, 1 },
                    { 33, new DateTime(2025, 4, 15, 2, 25, 36, 949, DateTimeKind.Local).AddTicks(7185), null, 2, true, false, true, true, true, true, null, 1800m, "212", 1, 3, 1 },
                    { 34, new DateTime(2025, 4, 15, 2, 25, 36, 949, DateTimeKind.Local).AddTicks(7186), null, 2, true, false, true, true, true, true, null, 1800m, "213", 1, 3, 1 },
                    { 35, new DateTime(2025, 4, 15, 2, 25, 36, 949, DateTimeKind.Local).AddTicks(7186), null, 2, true, false, true, true, true, true, null, 1800m, "214", 1, 3, 1 },
                    { 36, new DateTime(2025, 4, 15, 2, 25, 36, 949, DateTimeKind.Local).AddTicks(7187), null, 2, true, false, true, true, true, true, null, 1800m, "215", 1, 3, 1 },
                    { 37, new DateTime(2025, 4, 15, 2, 25, 36, 949, DateTimeKind.Local).AddTicks(7187), null, 2, true, false, true, true, true, true, null, 1800m, "216", 1, 3, 1 },
                    { 38, new DateTime(2025, 4, 15, 2, 25, 36, 949, DateTimeKind.Local).AddTicks(7188), null, 2, true, false, true, true, true, true, null, 1800m, "217", 1, 3, 1 },
                    { 39, new DateTime(2025, 4, 15, 2, 25, 36, 949, DateTimeKind.Local).AddTicks(7188), null, 2, true, false, true, true, true, true, null, 1800m, "218", 1, 3, 1 },
                    { 40, new DateTime(2025, 4, 15, 2, 25, 36, 949, DateTimeKind.Local).AddTicks(7189), null, 2, true, false, true, true, true, true, null, 1800m, "219", 1, 3, 1 },
                    { 41, new DateTime(2025, 4, 15, 2, 25, 36, 949, DateTimeKind.Local).AddTicks(7192), null, 3, true, true, true, true, true, true, null, 2200m, "300", 1, 2, 1 },
                    { 42, new DateTime(2025, 4, 15, 2, 25, 36, 949, DateTimeKind.Local).AddTicks(7193), null, 3, true, true, true, true, true, true, null, 2200m, "301", 1, 2, 1 },
                    { 43, new DateTime(2025, 4, 15, 2, 25, 36, 949, DateTimeKind.Local).AddTicks(7193), null, 3, true, true, true, true, true, true, null, 2200m, "302", 1, 2, 1 },
                    { 44, new DateTime(2025, 4, 15, 2, 25, 36, 949, DateTimeKind.Local).AddTicks(7194), null, 3, true, true, true, true, true, true, null, 2200m, "303", 1, 2, 1 },
                    { 45, new DateTime(2025, 4, 15, 2, 25, 36, 949, DateTimeKind.Local).AddTicks(7195), null, 3, true, true, true, true, true, true, null, 2200m, "304", 1, 2, 1 },
                    { 46, new DateTime(2025, 4, 15, 2, 25, 36, 949, DateTimeKind.Local).AddTicks(7195), null, 3, true, true, true, true, true, true, null, 2200m, "305", 1, 2, 1 },
                    { 47, new DateTime(2025, 4, 15, 2, 25, 36, 949, DateTimeKind.Local).AddTicks(7196), null, 3, true, true, true, true, true, true, null, 2200m, "306", 1, 2, 1 },
                    { 48, new DateTime(2025, 4, 15, 2, 25, 36, 949, DateTimeKind.Local).AddTicks(7196), null, 3, true, true, true, true, true, true, null, 2200m, "307", 1, 2, 1 },
                    { 49, new DateTime(2025, 4, 15, 2, 25, 36, 949, DateTimeKind.Local).AddTicks(7197), null, 3, true, true, true, true, true, true, null, 2200m, "308", 1, 2, 1 },
                    { 50, new DateTime(2025, 4, 15, 2, 25, 36, 949, DateTimeKind.Local).AddTicks(7197), null, 3, true, true, true, true, true, true, null, 2200m, "309", 1, 2, 1 },
                    { 51, new DateTime(2025, 4, 15, 2, 25, 36, 949, DateTimeKind.Local).AddTicks(7199), null, 3, true, true, true, true, true, true, null, 2500m, "310", 1, 5, 1 },
                    { 52, new DateTime(2025, 4, 15, 2, 25, 36, 949, DateTimeKind.Local).AddTicks(7200), null, 3, true, true, true, true, true, true, null, 2500m, "311", 1, 5, 1 },
                    { 53, new DateTime(2025, 4, 15, 2, 25, 36, 949, DateTimeKind.Local).AddTicks(7201), null, 3, true, true, true, true, true, true, null, 2500m, "312", 1, 5, 1 },
                    { 54, new DateTime(2025, 4, 15, 2, 25, 36, 949, DateTimeKind.Local).AddTicks(7201), null, 3, true, true, true, true, true, true, null, 2500m, "313", 1, 5, 1 },
                    { 55, new DateTime(2025, 4, 15, 2, 25, 36, 949, DateTimeKind.Local).AddTicks(7202), null, 3, true, true, true, true, true, true, null, 2500m, "314", 1, 5, 1 },
                    { 56, new DateTime(2025, 4, 15, 2, 25, 36, 949, DateTimeKind.Local).AddTicks(7202), null, 3, true, true, true, true, true, true, null, 2500m, "315", 1, 5, 1 },
                    { 57, new DateTime(2025, 4, 15, 2, 25, 36, 949, DateTimeKind.Local).AddTicks(7203), null, 3, true, true, true, true, true, true, null, 2500m, "316", 1, 5, 1 },
                    { 58, new DateTime(2025, 4, 15, 2, 25, 36, 949, DateTimeKind.Local).AddTicks(7203), null, 3, true, true, true, true, true, true, null, 2500m, "317", 1, 5, 1 },
                    { 59, new DateTime(2025, 4, 15, 2, 25, 36, 949, DateTimeKind.Local).AddTicks(7204), null, 3, true, true, true, true, true, true, null, 2500m, "318", 1, 5, 1 },
                    { 60, new DateTime(2025, 4, 15, 2, 25, 36, 949, DateTimeKind.Local).AddTicks(7204), null, 3, true, true, true, true, true, true, null, 2500m, "319", 1, 5, 1 },
                    { 61, new DateTime(2025, 4, 15, 2, 25, 36, 949, DateTimeKind.Local).AddTicks(7206), null, 4, true, true, true, true, true, true, null, 2800m, "400", 1, 2, 1 },
                    { 62, new DateTime(2025, 4, 15, 2, 25, 36, 949, DateTimeKind.Local).AddTicks(7207), null, 4, true, true, true, true, true, true, null, 2800m, "401", 1, 2, 1 },
                    { 63, new DateTime(2025, 4, 15, 2, 25, 36, 949, DateTimeKind.Local).AddTicks(7208), null, 4, true, true, true, true, true, true, null, 2800m, "402", 1, 2, 1 },
                    { 64, new DateTime(2025, 4, 15, 2, 25, 36, 949, DateTimeKind.Local).AddTicks(7259), null, 4, true, true, true, true, true, true, null, 2800m, "403", 1, 2, 1 },
                    { 65, new DateTime(2025, 4, 15, 2, 25, 36, 949, DateTimeKind.Local).AddTicks(7260), null, 4, true, true, true, true, true, true, null, 2800m, "404", 1, 2, 1 },
                    { 66, new DateTime(2025, 4, 15, 2, 25, 36, 949, DateTimeKind.Local).AddTicks(7261), null, 4, true, true, true, true, true, true, null, 2800m, "405", 1, 2, 1 },
                    { 67, new DateTime(2025, 4, 15, 2, 25, 36, 949, DateTimeKind.Local).AddTicks(7262), null, 4, true, true, true, true, true, true, null, 2800m, "406", 1, 2, 1 },
                    { 68, new DateTime(2025, 4, 15, 2, 25, 36, 949, DateTimeKind.Local).AddTicks(7263), null, 4, true, true, true, true, true, true, null, 2800m, "407", 1, 2, 1 },
                    { 69, new DateTime(2025, 4, 15, 2, 25, 36, 949, DateTimeKind.Local).AddTicks(7263), null, 4, true, true, true, true, true, true, null, 2800m, "408", 1, 2, 1 },
                    { 70, new DateTime(2025, 4, 15, 2, 25, 36, 949, DateTimeKind.Local).AddTicks(7264), null, 4, true, true, true, true, true, true, null, 2800m, "409", 1, 2, 1 },
                    { 71, new DateTime(2025, 4, 15, 2, 25, 36, 949, DateTimeKind.Local).AddTicks(7266), null, 4, true, true, true, true, true, true, null, 3500m, "410", 1, 6, 1 },
                    { 72, new DateTime(2025, 4, 15, 2, 25, 36, 949, DateTimeKind.Local).AddTicks(7267), null, 4, true, true, true, true, true, true, null, 3500m, "411", 1, 6, 1 },
                    { 73, new DateTime(2025, 4, 15, 2, 25, 36, 949, DateTimeKind.Local).AddTicks(7267), null, 4, true, true, true, true, true, true, null, 3500m, "412", 1, 6, 1 },
                    { 74, new DateTime(2025, 4, 15, 2, 25, 36, 949, DateTimeKind.Local).AddTicks(7268), null, 4, true, true, true, true, true, true, null, 3500m, "413", 1, 6, 1 },
                    { 75, new DateTime(2025, 4, 15, 2, 25, 36, 949, DateTimeKind.Local).AddTicks(7269), null, 4, true, true, true, true, true, true, null, 3500m, "414", 1, 6, 1 },
                    { 76, new DateTime(2025, 4, 15, 2, 25, 36, 949, DateTimeKind.Local).AddTicks(7269), null, 4, true, true, true, true, true, true, null, 3500m, "415", 1, 6, 1 },
                    { 77, new DateTime(2025, 4, 15, 2, 25, 36, 949, DateTimeKind.Local).AddTicks(7271), null, 4, true, true, true, true, true, true, null, 10000m, "417", 1, 7, 1 }
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
