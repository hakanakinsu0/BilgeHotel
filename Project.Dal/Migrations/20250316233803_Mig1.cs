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
                    { 1, "8cd3874b-f46e-4863-9b92-1fd5ec4571fe", "Admin", "ADMIN" },
                    { 2, "64cc9d8f-f0ff-4483-9001-f31bb92d97c4", "Member", "MEMBER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ActivationCode", "ConcurrencyStamp", "CreatedDate", "DeletedDate", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "ModifiedDate", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Status", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { 1, 0, new Guid("00000000-0000-0000-0000-000000000000"), "9834e77f-0330-47d1-9ea0-32cd9150c326", new DateTime(2025, 3, 17, 2, 38, 2, 983, DateTimeKind.Local).AddTicks(9081), null, "bilgehotel@email.com", true, false, null, null, "BILGEHOTEL@EMAIL.COM", "BILGEHOTEL", "AQAAAAIAAYagAAAAEMwCZy1lPYf888jZLjCDExYTZzOIzQpONZWNAiCL6Lmgjrg/XaY3PyIQ3i/kGKvNpw==", null, false, "87d6cbc0-5170-4901-9753-df9929426904", 1, false, "bilgehotel" },
                    { 2, 0, new Guid("00000000-0000-0000-0000-000000000000"), "8f8ae079-a3fb-43b9-8404-edc4455f4590", new DateTime(2025, 3, 17, 2, 38, 3, 22, DateTimeKind.Local).AddTicks(4403), null, "testmember@email.com", true, false, null, null, "TESTMEMBER@EMAIL.COM", "TESTMEMBER", "AQAAAAIAAYagAAAAEKvDgKFwhoP5XA90mvewZKjxgyz0izF3Dcs1FEvjMcSQ7EMwq/xzzExjlfrcOZiDvw==", null, false, "8d926003-bd97-4e11-b8c0-819e5f51cba7", 1, false, "testmember" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Address", "BirthDate", "CreatedDate", "DeletedDate", "FirstName", "HireDate", "LastName", "ModifiedDate", "PhoneNumber", "Position", "Salary", "Shift", "Status" },
                values: new object[,]
                {
                    { 1, "Sıran Söğüt Sokak 21b, Trabzon, Meksika", new DateTime(1998, 3, 24, 21, 48, 38, 534, DateTimeKind.Local).AddTicks(834), new DateTime(2025, 3, 17, 2, 38, 2, 942, DateTimeKind.Local).AddTicks(3300), null, "Akın", new DateTime(2018, 11, 14, 4, 35, 51, 793, DateTimeKind.Local).AddTicks(6820), "Balaban", null, "+90-032-853-9-498", "Resepsiyonist", 55044.94m, 2, 1 },
                    { 2, "Dağınık Evler Sokak 2, Sinop, Güney Afrika", new DateTime(1988, 8, 5, 12, 50, 39, 921, DateTimeKind.Local).AddTicks(1397), new DateTime(2025, 3, 17, 2, 38, 2, 942, DateTimeKind.Local).AddTicks(3414), null, "Çölü", new DateTime(2022, 11, 13, 6, 50, 50, 89, DateTimeKind.Local).AddTicks(837), "Yıldırım ", null, "+90-464-805-4-190", "Resepsiyonist", 40931.84m, 3, 1 },
                    { 3, "Yunus Emre Sokak 40c, Afyon, Solomon Adaları", new DateTime(2006, 10, 15, 14, 7, 51, 68, DateTimeKind.Local).AddTicks(486), new DateTime(2025, 3, 17, 2, 38, 2, 942, DateTimeKind.Local).AddTicks(3473), null, "Amrak", new DateTime(2015, 7, 20, 11, 34, 42, 238, DateTimeKind.Local).AddTicks(6316), "Polat", null, "+90-315-047-0-670", "Resepsiyonist", 43432.70m, 3, 1 },
                    { 4, "Alparslan Türkeş Bulvarı 1, Tekirdağ, Yemen", new DateTime(1976, 3, 28, 0, 59, 47, 220, DateTimeKind.Local).AddTicks(7847), new DateTime(2025, 3, 17, 2, 38, 2, 942, DateTimeKind.Local).AddTicks(3558), null, "Altıntamgan", new DateTime(2019, 7, 4, 3, 15, 14, 621, DateTimeKind.Local).AddTicks(855), "Samancı", null, "+90-668-847-4-990", "Resepsiyonist", 44507.10m, 3, 1 },
                    { 5, "Bandak Sokak 310, İstanbul, Brunei", new DateTime(1977, 3, 10, 10, 31, 13, 0, DateTimeKind.Local).AddTicks(9583), new DateTime(2025, 3, 17, 2, 38, 2, 942, DateTimeKind.Local).AddTicks(3640), null, "Bürkek", new DateTime(2017, 2, 25, 9, 33, 27, 575, DateTimeKind.Local).AddTicks(2034), "Velioğlu", null, "+90-851-541-00-84", "Resepsiyonist", 43594.78m, 2, 1 },
                    { 6, "Afyon Kaya Sokak 804, Gaziantep, Tanzanya", new DateTime(1971, 4, 4, 23, 11, 15, 830, DateTimeKind.Local).AddTicks(8432), new DateTime(2025, 3, 17, 2, 38, 2, 942, DateTimeKind.Local).AddTicks(3695), null, "Armağan", new DateTime(2020, 9, 25, 11, 35, 10, 788, DateTimeKind.Local).AddTicks(8698), "Kavaklıoğlu", null, "+90-718-835-88-78", "Resepsiyonist", 49992.50m, 2, 1 },
                    { 7, "Harman Yolu Sokak  2, Siirt, Palau Adaları", new DateTime(1978, 11, 6, 8, 42, 6, 321, DateTimeKind.Local).AddTicks(1630), new DateTime(2025, 3, 17, 2, 38, 2, 942, DateTimeKind.Local).AddTicks(3772), null, "Ceyhun", new DateTime(2022, 8, 30, 23, 12, 13, 365, DateTimeKind.Local).AddTicks(4692), "Topçuoğlu", null, "+90-140-786-3-211", "Resepsiyonist", 42049.87m, 1, 1 },
                    { 8, "Ergenekon Sokak   78, Yalova, Bermuda, İngiltere", new DateTime(1996, 11, 14, 6, 54, 10, 560, DateTimeKind.Local).AddTicks(3695), new DateTime(2025, 3, 17, 2, 38, 2, 942, DateTimeKind.Local).AddTicks(3857), null, "Alpata", new DateTime(2023, 3, 12, 14, 6, 36, 835, DateTimeKind.Local).AddTicks(2131), "Erdoğan", null, "+90-415-245-4-374", "Temizlik Görevlisi", 33914.91m, 2, 1 },
                    { 9, "İsmet Attila Caddesi 84c, Ordu, Guadalup, Fransa", new DateTime(1986, 5, 3, 20, 42, 12, 250, DateTimeKind.Local).AddTicks(8218), new DateTime(2025, 3, 17, 2, 38, 2, 942, DateTimeKind.Local).AddTicks(3935), null, "Erdem", new DateTime(2021, 10, 24, 16, 55, 57, 925, DateTimeKind.Local).AddTicks(8919), "Erbay", null, "+90-649-804-6-637", "Temizlik Görevlisi", 32320.08m, 2, 1 },
                    { 10, "Gül Sokak 699, Mardin, Bulgaristan", new DateTime(1980, 1, 26, 19, 44, 6, 445, DateTimeKind.Local).AddTicks(1062), new DateTime(2025, 3, 17, 2, 38, 2, 942, DateTimeKind.Local).AddTicks(3988), null, "Akpıra", new DateTime(2022, 10, 23, 9, 34, 23, 867, DateTimeKind.Local).AddTicks(6420), "Taşçı", null, "+90-699-502-62-76", "Temizlik Görevlisi", 32512.28m, 2, 1 },
                    { 11, "Ali Çetinkaya Caddesi 01b, Gaziantep, Belize", new DateTime(2000, 2, 24, 0, 54, 39, 322, DateTimeKind.Local).AddTicks(5458), new DateTime(2025, 3, 17, 2, 38, 2, 942, DateTimeKind.Local).AddTicks(4051), null, "Gökçe", new DateTime(2024, 1, 30, 7, 30, 48, 344, DateTimeKind.Local).AddTicks(4253), "Adan", null, "+90-289-054-3-464", "Temizlik Görevlisi", 30538.92m, 2, 1 },
                    { 12, "İsmet Attila Caddesi 65c, Balıkesir, Özbekistan", new DateTime(1992, 1, 5, 6, 39, 43, 876, DateTimeKind.Local).AddTicks(9502), new DateTime(2025, 3, 17, 2, 38, 2, 942, DateTimeKind.Local).AddTicks(4126), null, "Aksungur", new DateTime(2019, 5, 19, 15, 37, 13, 582, DateTimeKind.Local).AddTicks(6539), "Örge", null, "+90-495-134-1-442", "Temizlik Görevlisi", 34523.37m, 2, 1 },
                    { 13, "Tevfik Fikret Caddesi 17, Antalya, Guatemala", new DateTime(1974, 9, 17, 2, 2, 16, 603, DateTimeKind.Local).AddTicks(2242), new DateTime(2025, 3, 17, 2, 38, 2, 942, DateTimeKind.Local).AddTicks(4207), null, "Begi", new DateTime(2018, 4, 20, 2, 33, 46, 403, DateTimeKind.Local).AddTicks(7592), "Sezek", null, "+90-432-997-5-158", "Temizlik Görevlisi", 30300.79m, 2, 1 },
                    { 14, "Kerimoğlu Sokak 74b, Amasya, Kazakistan", new DateTime(2002, 9, 17, 17, 28, 31, 423, DateTimeKind.Local).AddTicks(3620), new DateTime(2025, 3, 17, 2, 38, 2, 942, DateTimeKind.Local).AddTicks(4255), null, "Bayançar", new DateTime(2018, 4, 3, 21, 37, 17, 26, DateTimeKind.Local).AddTicks(6053), "Akgül", null, "+90-638-175-80-85", "Temizlik Görevlisi", 28779.25m, 1, 1 },
                    { 15, "Barış Sokak 691, Kocaeli, Folkland Adaları, İngiltere", new DateTime(1981, 4, 1, 17, 37, 37, 450, DateTimeKind.Local).AddTicks(1571), new DateTime(2025, 3, 17, 2, 38, 2, 942, DateTimeKind.Local).AddTicks(4332), null, "Buldur", new DateTime(2021, 5, 1, 2, 30, 50, 649, DateTimeKind.Local).AddTicks(2450), "Erçetin", null, "+90-375-511-5-874", "Temizlik Görevlisi", 31471.95m, 1, 1 },
                    { 16, "Gül Sokak 24a, Bursa, Rusya Federasyonu", new DateTime(1995, 8, 19, 14, 50, 57, 349, DateTimeKind.Local).AddTicks(3079), new DateTime(2025, 3, 17, 2, 38, 2, 942, DateTimeKind.Local).AddTicks(4404), null, "Büdüstudun", new DateTime(2015, 12, 26, 16, 43, 25, 381, DateTimeKind.Local).AddTicks(6882), "Abadan", null, "+90-936-357-1-717", "Temizlik Görevlisi", 25216.92m, 2, 1 },
                    { 17, "Tevfik Fikret Caddesi 88c, İçel (Mersin), Ekvator Ginesi", new DateTime(2003, 11, 29, 12, 20, 59, 404, DateTimeKind.Local).AddTicks(2192), new DateTime(2025, 3, 17, 2, 38, 2, 942, DateTimeKind.Local).AddTicks(4477), null, "Abşar", new DateTime(2022, 10, 29, 11, 40, 2, 270, DateTimeKind.Local).AddTicks(692), "Atan", null, "+90-842-291-85-10", "Temizlik Görevlisi", 30015.66m, 1, 1 },
                    { 18, "Bandak Sokak 501, Rize, Moldavya", new DateTime(2002, 12, 10, 1, 50, 38, 190, DateTimeKind.Local).AddTicks(375), new DateTime(2025, 3, 17, 2, 38, 2, 942, DateTimeKind.Local).AddTicks(4525), null, "Apak", new DateTime(2021, 2, 3, 1, 31, 9, 398, DateTimeKind.Local).AddTicks(4064), "Erdoğan", null, "+90-944-833-6-730", "Temizlik Görevlisi", 25316.83m, 1, 1 },
                    { 19, "Bahçe Sokak 14c, Balıkesir, Kosova", new DateTime(1987, 9, 15, 12, 8, 55, 868, DateTimeKind.Local).AddTicks(1445), new DateTime(2025, 3, 17, 2, 38, 2, 942, DateTimeKind.Local).AddTicks(4616), null, "Gelin", new DateTime(2019, 8, 7, 15, 6, 54, 937, DateTimeKind.Local).AddTicks(1526), "Yılmazer", null, "+90-014-877-22-19", "Aşçı", 100624.71m, 1, 1 },
                    { 20, "Kerimoğlu Sokak 568, Muş, Kırgızistan", new DateTime(1979, 4, 14, 23, 4, 13, 464, DateTimeKind.Local).AddTicks(328), new DateTime(2025, 3, 17, 2, 38, 2, 942, DateTimeKind.Local).AddTicks(4712), null, "Bayur", new DateTime(2017, 9, 25, 8, 20, 0, 245, DateTimeKind.Local).AddTicks(9066), "Denkel", null, "+90-349-207-99-43", "Aşçı", 111664.51m, 1, 1 },
                    { 21, "Sıran Söğüt Sokak 1, Ordu, Cibuti", new DateTime(1987, 3, 21, 20, 46, 49, 489, DateTimeKind.Local).AddTicks(6899), new DateTime(2025, 3, 17, 2, 38, 2, 942, DateTimeKind.Local).AddTicks(4773), null, "Buldur", new DateTime(2020, 1, 3, 4, 39, 5, 713, DateTimeKind.Local).AddTicks(1362), "Arıcan", null, "+90-747-897-62-88", "Aşçı", 118099.32m, 1, 1 },
                    { 22, "Kaldırım Sokak 0, Ardahan, Benin", new DateTime(1973, 10, 11, 21, 40, 52, 159, DateTimeKind.Local).AddTicks(2934), new DateTime(2025, 3, 17, 2, 38, 2, 942, DateTimeKind.Local).AddTicks(4822), null, "Bıçkı", new DateTime(2016, 7, 12, 11, 16, 9, 801, DateTimeKind.Local).AddTicks(8593), "Öztonga", null, "+90-724-026-48-41", "Aşçı", 119150.49m, 2, 1 },
                    { 23, "Sağlık Sokak 69, İçel (Mersin), Ürdün", new DateTime(1988, 11, 20, 9, 39, 12, 703, DateTimeKind.Local).AddTicks(2664), new DateTime(2025, 3, 17, 2, 38, 2, 942, DateTimeKind.Local).AddTicks(4895), null, "Bükebuyraç", new DateTime(2018, 7, 18, 12, 4, 57, 104, DateTimeKind.Local).AddTicks(4968), "Taşçı", null, "+90-842-981-96-95", "Aşçı", 103366.23m, 2, 1 },
                    { 24, "Dar Sokak 29, Rize, Maldiv Adaları", new DateTime(1977, 2, 20, 9, 29, 39, 512, DateTimeKind.Local).AddTicks(3940), new DateTime(2025, 3, 17, 2, 38, 2, 942, DateTimeKind.Local).AddTicks(4973), null, "Dizik", new DateTime(2019, 8, 20, 22, 1, 18, 165, DateTimeKind.Local).AddTicks(1278), "Numanoğlu", null, "+90-390-250-08-24", "Aşçı", 101609.78m, 1, 1 },
                    { 25, "Barış Sokak 43, Rize, Madagaskar", new DateTime(1978, 10, 8, 15, 50, 42, 240, DateTimeKind.Local).AddTicks(9813), new DateTime(2025, 3, 17, 2, 38, 2, 942, DateTimeKind.Local).AddTicks(5018), null, "Ayban", new DateTime(2020, 10, 12, 12, 48, 47, 664, DateTimeKind.Local).AddTicks(1792), "Bakırcıoğlu", null, "+90-929-533-0-958", "Aşçı", 113065.34m, 2, 1 },
                    { 26, "Ergenekon Sokak   51c, Tunceli, Fransız Guyanası", new DateTime(1977, 1, 10, 22, 42, 36, 395, DateTimeKind.Local).AddTicks(3683), new DateTime(2025, 3, 17, 2, 38, 2, 942, DateTimeKind.Local).AddTicks(5091), null, "Boyan", new DateTime(2015, 12, 18, 2, 8, 45, 385, DateTimeKind.Local).AddTicks(327), "Yetkiner", null, "+90-972-753-94-44", "Aşçı", 114645.17m, 1, 1 },
                    { 27, "Tevfik Fikret Caddesi 16c, Giresun, Mayotte, Fransa", new DateTime(1983, 2, 23, 23, 17, 7, 519, DateTimeKind.Local).AddTicks(3972), new DateTime(2025, 3, 17, 2, 38, 2, 942, DateTimeKind.Local).AddTicks(5161), null, "Bünül", new DateTime(2021, 2, 24, 12, 22, 11, 856, DateTimeKind.Local).AddTicks(6374), "Beşerler", null, "+90-929-387-72-48", "Aşçı", 114621.99m, 1, 1 },
                    { 28, "Köypınar Sokak 14a, Düzce, İsviçre", new DateTime(1990, 4, 1, 1, 50, 8, 212, DateTimeKind.Local).AddTicks(2453), new DateTime(2025, 3, 17, 2, 38, 2, 942, DateTimeKind.Local).AddTicks(5240), null, "Akbuğra", new DateTime(2017, 8, 19, 16, 54, 35, 360, DateTimeKind.Local).AddTicks(9862), "Baturalp", null, "+90-472-419-1-357", "Aşçı", 115213.02m, 1, 1 },
                    { 29, "Bandak Sokak 18, Zonguldak, Endonezya", new DateTime(1984, 4, 22, 2, 44, 29, 226, DateTimeKind.Local).AddTicks(662), new DateTime(2025, 3, 17, 2, 38, 2, 942, DateTimeKind.Local).AddTicks(5289), null, "Çolman", new DateTime(2018, 8, 10, 17, 19, 47, 501, DateTimeKind.Local).AddTicks(8015), "Karabulut", null, "+90-757-963-02-44", "Aşçı", 100810.09m, 2, 1 },
                    { 30, "Dağınık Evler Sokak 91, Elazığ, Gürcistan H", new DateTime(1976, 1, 21, 19, 7, 30, 492, DateTimeKind.Local).AddTicks(8451), new DateTime(2025, 3, 17, 2, 38, 2, 942, DateTimeKind.Local).AddTicks(5360), null, "Başgan", new DateTime(2014, 8, 28, 13, 44, 55, 391, DateTimeKind.Local).AddTicks(2994), "Avan", null, "+90-802-543-3-230", "Garson", 85121.58m, 1, 1 },
                    { 31, "Köypınar Sokak 2, Tekirdağ, Özbekistan", new DateTime(1996, 4, 22, 12, 34, 44, 816, DateTimeKind.Local).AddTicks(35), new DateTime(2025, 3, 17, 2, 38, 2, 942, DateTimeKind.Local).AddTicks(5427), null, "Azak", new DateTime(2024, 3, 4, 11, 19, 48, 311, DateTimeKind.Local).AddTicks(2456), "Arıcan", null, "+90-488-718-62-30", "Garson", 95343.03m, 2, 1 },
                    { 32, "Okul Sokak 29b, Ardahan, Somali", new DateTime(2006, 6, 14, 15, 51, 26, 323, DateTimeKind.Local).AddTicks(1575), new DateTime(2025, 3, 17, 2, 38, 2, 942, DateTimeKind.Local).AddTicks(5487), null, "Gün", new DateTime(2015, 6, 9, 11, 6, 48, 657, DateTimeKind.Local).AddTicks(987), "Çetiner", null, "+90-977-556-3-753", "Garson", 94847.53m, 1, 1 },
                    { 33, "Harman Altı Sokak 16b, Kırşehir, Arnavutluk", new DateTime(1989, 7, 8, 7, 24, 34, 873, DateTimeKind.Local).AddTicks(4502), new DateTime(2025, 3, 17, 2, 38, 2, 942, DateTimeKind.Local).AddTicks(5538), null, "Buluk", new DateTime(2021, 7, 8, 23, 19, 33, 363, DateTimeKind.Local).AddTicks(4351), "Düşenkalkar", null, "+90-321-013-3-793", "Garson", 82748.83m, 2, 1 },
                    { 34, "Ülkü Sokak 21, Samsun, Solomon Adaları", new DateTime(1968, 5, 2, 13, 8, 14, 390, DateTimeKind.Local).AddTicks(8078), new DateTime(2025, 3, 17, 2, 38, 2, 942, DateTimeKind.Local).AddTicks(5619), null, "Altınoba", new DateTime(2022, 3, 7, 17, 44, 32, 64, DateTimeKind.Local).AddTicks(7148), "Düşenkalkar", null, "+90-055-441-6-792", "Garson", 78763.89m, 1, 1 },
                    { 35, "Yunus Emre Sokak 927, Şanlıurfa, Botswana", new DateTime(2002, 8, 5, 2, 1, 27, 185, DateTimeKind.Local).AddTicks(7179), new DateTime(2025, 3, 17, 2, 38, 2, 942, DateTimeKind.Local).AddTicks(5695), null, "Bayançar", new DateTime(2022, 7, 2, 5, 0, 51, 795, DateTimeKind.Local).AddTicks(5853), "Ayverdi", null, "+90-892-547-54-19", "Garson", 70087.73m, 2, 1 },
                    { 36, "30 Ağustos Caddesi 90, Eskişehir, Beyaz Rusya", new DateTime(2005, 9, 12, 6, 11, 13, 938, DateTimeKind.Local).AddTicks(9273), new DateTime(2025, 3, 17, 2, 38, 2, 942, DateTimeKind.Local).AddTicks(5765), null, "Büke", new DateTime(2016, 3, 26, 21, 22, 25, 453, DateTimeKind.Local).AddTicks(9367), "Eliçin", null, "+90-014-766-12-36", "Garson", 95859.04m, 1, 1 },
                    { 37, "Yunus Emre Sokak 93b, Zonguldak, Ruanda", new DateTime(1971, 5, 7, 11, 22, 34, 471, DateTimeKind.Local).AddTicks(3307), new DateTime(2025, 3, 17, 2, 38, 2, 942, DateTimeKind.Local).AddTicks(5811), null, "Kekik", new DateTime(2022, 5, 16, 17, 48, 56, 179, DateTimeKind.Local).AddTicks(6791), "Ertürk", null, "+90-955-560-45-78", "Garson", 86321.56m, 1, 1 },
                    { 38, "İbn-i Sina Sokak 645, Karabük, Nauru", new DateTime(2003, 8, 21, 18, 53, 11, 260, DateTimeKind.Local).AddTicks(4585), new DateTime(2025, 3, 17, 2, 38, 2, 942, DateTimeKind.Local).AddTicks(5886), null, "Çobulmak", new DateTime(2014, 11, 24, 7, 7, 57, 943, DateTimeKind.Local).AddTicks(5228), "Topaloğlu", null, "+90-393-299-9-601", "Garson", 97495.32m, 2, 1 },
                    { 39, "Gül Sokak 1, Adana, Liechtenstein", new DateTime(1981, 9, 17, 13, 44, 49, 315, DateTimeKind.Local).AddTicks(8104), new DateTime(2025, 3, 17, 2, 38, 2, 942, DateTimeKind.Local).AddTicks(5962), null, "Algu", new DateTime(2021, 3, 26, 3, 0, 57, 655, DateTimeKind.Local).AddTicks(2461), "Türkyılmaz", null, "+90-541-925-22-36", "Garson", 80703.36m, 1, 1 },
                    { 40, "Kocatepe Caddesi 12c, Mardin, Ekvator Ginesi", new DateTime(1986, 4, 12, 1, 10, 31, 301, DateTimeKind.Local).AddTicks(2977), new DateTime(2025, 3, 17, 2, 38, 2, 942, DateTimeKind.Local).AddTicks(6031), null, "Al", new DateTime(2020, 5, 25, 8, 53, 56, 336, DateTimeKind.Local).AddTicks(5453), "Dağdaş", null, "+90-437-943-9-830", "Garson", 73413.62m, 2, 1 },
                    { 41, "Dağınık Evler Sokak 94a, Manisa, Somali", new DateTime(1970, 9, 12, 8, 59, 37, 592, DateTimeKind.Local).AddTicks(5675), new DateTime(2025, 3, 17, 2, 38, 2, 942, DateTimeKind.Local).AddTicks(6076), null, "Ceyhun", new DateTime(2017, 10, 6, 11, 55, 47, 828, DateTimeKind.Local).AddTicks(2722), "Demirel", null, "+90-656-478-67-79", "Garson", 76871.44m, 2, 1 },
                    { 42, "Sıran Söğüt Sokak 86, İzmir, Bahreyn", new DateTime(1975, 5, 17, 1, 26, 24, 397, DateTimeKind.Local).AddTicks(6492), new DateTime(2025, 3, 17, 2, 38, 2, 942, DateTimeKind.Local).AddTicks(6151), null, "Bağaturçigşi", new DateTime(2016, 1, 2, 21, 53, 8, 835, DateTimeKind.Local).AddTicks(1155), "Gürmen", null, "+90-258-096-0-958", "Garson", 86803.64m, 2, 1 },
                    { 43, "Atatürk Bulvarı 11, İstanbul, Türkmenistan", new DateTime(1975, 5, 29, 8, 56, 10, 46, DateTimeKind.Local).AddTicks(1470), new DateTime(2025, 3, 17, 2, 38, 2, 942, DateTimeKind.Local).AddTicks(6215), null, "Akbulak", new DateTime(2022, 9, 24, 14, 11, 47, 593, DateTimeKind.Local).AddTicks(5511), "Özbir", null, "+90-645-153-82-65", "Elektrikçi", 166219.48m, 1, 1 },
                    { 44, "Nalbant Sokak 29b, K.maraş, Mali", new DateTime(1977, 5, 25, 11, 33, 9, 767, DateTimeKind.Local).AddTicks(1962), new DateTime(2025, 3, 17, 2, 38, 2, 942, DateTimeKind.Local).AddTicks(6266), null, "Bilgez", new DateTime(2021, 2, 28, 3, 25, 32, 952, DateTimeKind.Local).AddTicks(6532), "Tütüncü", null, "+90-516-125-1-008", "IT Sorumlusu", 150851.01m, 3, 1 }
                });

            migrationBuilder.InsertData(
                table: "ExtraServices",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Description", "ModifiedDate", "Name", "Price", "Status" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 3, 17, 2, 38, 3, 22, DateTimeKind.Local).AddTicks(4702), null, "Günlük sınırsız spa kullanımı.", null, "Spa Kullanımı", 3000m, 1 },
                    { 2, new DateTime(2025, 3, 17, 2, 38, 3, 22, DateTimeKind.Local).AddTicks(4705), null, "24 saat oda servisi. Tüm yemek siparişleri dahildir.", null, "Oda Servisi", 1500m, 1 },
                    { 3, new DateTime(2025, 3, 17, 2, 38, 3, 22, DateTimeKind.Local).AddTicks(4706), null, "Minibardaki içecekler ve atıştırmalıklar dahil.", null, "Minibar Kullanımı", 1000m, 1 },
                    { 4, new DateTime(2025, 3, 17, 2, 38, 3, 22, DateTimeKind.Local).AddTicks(4708), null, "Gidiş-dönüş özel araç transferi.", null, "Havalimanı Transferi", 5000m, 1 },
                    { 5, new DateTime(2025, 3, 17, 2, 38, 3, 22, DateTimeKind.Local).AddTicks(4709), null, "Konaklama süresince ücretsiz çamaşır ve kuru temizleme hizmeti.", null, "Çamaşırhane Hizmeti", 500m, 1 },
                    { 6, new DateTime(2025, 3, 17, 2, 38, 3, 22, DateTimeKind.Local).AddTicks(4716), null, "Ekstra günlük temizlik ve hijyen paketi.", null, "Günlük Oda Temizliği", 500m, 1 },
                    { 7, new DateTime(2025, 3, 17, 2, 38, 3, 22, DateTimeKind.Local).AddTicks(4717), null, "Özel şezlong ve plaj hizmetleri.", null, "Özel Plaj Alanı", 7500m, 1 }
                });

            migrationBuilder.InsertData(
                table: "Packages",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Description", "ModifiedDate", "Name", "PriceMultiplier", "Status" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 3, 17, 2, 38, 3, 22, DateTimeKind.Local).AddTicks(4651), null, "Kahvaltı, öğle ve akşam yemeği dahil.", null, "Tam Pansiyon", 1.2m, 1 },
                    { 2, new DateTime(2025, 3, 17, 2, 38, 3, 22, DateTimeKind.Local).AddTicks(4654), null, "Tüm yemekler, alkollü-alkolsüz içecekler ve otelin sunduğu belirli hizmetler dahil.", null, "Her Şey Dahil", 1.5m, 1 }
                });

            migrationBuilder.InsertData(
                table: "RoomTypes",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Description", "ModifiedDate", "Name", "Status" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 3, 17, 2, 38, 2, 940, DateTimeKind.Local).AddTicks(7628), null, "1 adet tek kişilik yatak. Balkon ve minibar bulunmaz. Klima, TV, saç kurutma makinesi ve WiFi mevcuttur.", null, "Tek Kişilik", 1 },
                    { 2, new DateTime(2025, 3, 17, 2, 38, 2, 940, DateTimeKind.Local).AddTicks(7641), null, "1 adet büyük (duble) yatak. Klima, TV, saç kurutma makinesi ve WiFi mevcuttur.", null, "Çift Kişilik (Duble)", 1 },
                    { 3, new DateTime(2025, 3, 17, 2, 38, 2, 940, DateTimeKind.Local).AddTicks(7643), null, "2 adet tek kişilik yatak. Klima, TV, saç kurutma makinesi ve WiFi mevcuttur.", null, "Çift Kişilik (Tek Kişilik 2 Yataklı)", 1 },
                    { 4, new DateTime(2025, 3, 17, 2, 38, 2, 940, DateTimeKind.Local).AddTicks(7644), null, "3 adet tek kişilik yatak.  Klima, TV, saç kurutma makinesi ve WiFi mevcuttur.", null, "Üç Kişilik (Tek Kişilik 3 Yataklı)", 1 },
                    { 5, new DateTime(2025, 3, 17, 2, 38, 2, 940, DateTimeKind.Local).AddTicks(7645), null, "Bir tek bir duble yatak.  Klima, TV, saç kurutma makinesi ve WiFi mevcuttur.", null, "Üç Kişilik (1 Tek, 1 Duble Yataklı)", 1 },
                    { 6, new DateTime(2025, 3, 17, 2, 38, 2, 940, DateTimeKind.Local).AddTicks(7647), null, "1 adet büyük (duble) yatak + 2 adet tek kişilik yatak. Klima, TV, saç kurutma makinesi ve WiFi mevcuttur.", null, "Dört Kişilik", 1 },
                    { 7, new DateTime(2025, 3, 17, 2, 38, 2, 940, DateTimeKind.Local).AddTicks(7649), null, "Geniş ve lüks oda. Özel oturma alanı, büyük yatak, balkon, minibar, özel banyo ve lüks hizmetler. Klima, TV, saç kurutma makinesi, WiFi ve özel hizmetler mevcuttur.", null, "Kral Dairesi", 1 }
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
                    { 1, new DateTime(2025, 3, 17, 2, 38, 2, 940, DateTimeKind.Local).AddTicks(7704), null, 1, true, false, true, false, true, true, null, 1000m, "100", 1, 1, 1 },
                    { 2, new DateTime(2025, 3, 17, 2, 38, 2, 940, DateTimeKind.Local).AddTicks(7711), null, 1, true, false, true, false, true, true, null, 1000m, "101", 1, 1, 1 },
                    { 3, new DateTime(2025, 3, 17, 2, 38, 2, 940, DateTimeKind.Local).AddTicks(7712), null, 1, true, false, true, false, true, true, null, 1000m, "102", 1, 1, 1 },
                    { 4, new DateTime(2025, 3, 17, 2, 38, 2, 940, DateTimeKind.Local).AddTicks(7713), null, 1, true, false, true, false, true, true, null, 1000m, "103", 1, 1, 1 },
                    { 5, new DateTime(2025, 3, 17, 2, 38, 2, 940, DateTimeKind.Local).AddTicks(7714), null, 1, true, false, true, false, true, true, null, 1000m, "104", 1, 1, 1 },
                    { 6, new DateTime(2025, 3, 17, 2, 38, 2, 940, DateTimeKind.Local).AddTicks(7715), null, 1, true, false, true, false, true, true, null, 1000m, "105", 1, 1, 1 },
                    { 7, new DateTime(2025, 3, 17, 2, 38, 2, 940, DateTimeKind.Local).AddTicks(7716), null, 1, true, false, true, false, true, true, null, 1000m, "106", 1, 1, 1 },
                    { 8, new DateTime(2025, 3, 17, 2, 38, 2, 940, DateTimeKind.Local).AddTicks(7717), null, 1, true, false, true, false, true, true, null, 1000m, "107", 1, 1, 1 },
                    { 9, new DateTime(2025, 3, 17, 2, 38, 2, 940, DateTimeKind.Local).AddTicks(7717), null, 1, true, false, true, false, true, true, null, 1000m, "108", 1, 1, 1 },
                    { 10, new DateTime(2025, 3, 17, 2, 38, 2, 940, DateTimeKind.Local).AddTicks(7719), null, 1, true, false, true, false, true, true, null, 1000m, "109", 1, 1, 1 },
                    { 11, new DateTime(2025, 3, 17, 2, 38, 2, 940, DateTimeKind.Local).AddTicks(7721), null, 1, true, false, true, false, true, true, null, 1500m, "110", 1, 4, 1 },
                    { 12, new DateTime(2025, 3, 17, 2, 38, 2, 940, DateTimeKind.Local).AddTicks(7723), null, 1, true, false, true, false, true, true, null, 1500m, "111", 1, 4, 1 },
                    { 13, new DateTime(2025, 3, 17, 2, 38, 2, 940, DateTimeKind.Local).AddTicks(7723), null, 1, true, false, true, false, true, true, null, 1500m, "112", 1, 4, 1 },
                    { 14, new DateTime(2025, 3, 17, 2, 38, 2, 940, DateTimeKind.Local).AddTicks(7724), null, 1, true, false, true, false, true, true, null, 1500m, "113", 1, 4, 1 },
                    { 15, new DateTime(2025, 3, 17, 2, 38, 2, 940, DateTimeKind.Local).AddTicks(7724), null, 1, true, false, true, false, true, true, null, 1500m, "114", 1, 4, 1 },
                    { 16, new DateTime(2025, 3, 17, 2, 38, 2, 940, DateTimeKind.Local).AddTicks(7748), null, 1, true, false, true, false, true, true, null, 1500m, "115", 1, 4, 1 },
                    { 17, new DateTime(2025, 3, 17, 2, 38, 2, 940, DateTimeKind.Local).AddTicks(7749), null, 1, true, false, true, false, true, true, null, 1500m, "116", 1, 4, 1 },
                    { 18, new DateTime(2025, 3, 17, 2, 38, 2, 940, DateTimeKind.Local).AddTicks(7751), null, 1, true, false, true, false, true, true, null, 1500m, "117", 1, 4, 1 },
                    { 19, new DateTime(2025, 3, 17, 2, 38, 2, 940, DateTimeKind.Local).AddTicks(7751), null, 1, true, false, true, false, true, true, null, 1500m, "118", 1, 4, 1 },
                    { 20, new DateTime(2025, 3, 17, 2, 38, 2, 940, DateTimeKind.Local).AddTicks(7752), null, 1, true, false, true, false, true, true, null, 1500m, "119", 1, 4, 1 },
                    { 21, new DateTime(2025, 3, 17, 2, 38, 2, 940, DateTimeKind.Local).AddTicks(7754), null, 2, true, false, true, false, true, true, null, 1200m, "200", 1, 1, 1 },
                    { 22, new DateTime(2025, 3, 17, 2, 38, 2, 940, DateTimeKind.Local).AddTicks(7755), null, 2, true, false, true, false, true, true, null, 1200m, "201", 1, 1, 1 },
                    { 23, new DateTime(2025, 3, 17, 2, 38, 2, 940, DateTimeKind.Local).AddTicks(7756), null, 2, true, false, true, false, true, true, null, 1200m, "202", 1, 1, 1 },
                    { 24, new DateTime(2025, 3, 17, 2, 38, 2, 940, DateTimeKind.Local).AddTicks(7756), null, 2, true, false, true, false, true, true, null, 1200m, "203", 1, 1, 1 },
                    { 25, new DateTime(2025, 3, 17, 2, 38, 2, 940, DateTimeKind.Local).AddTicks(7757), null, 2, true, false, true, false, true, true, null, 1200m, "204", 1, 1, 1 },
                    { 26, new DateTime(2025, 3, 17, 2, 38, 2, 940, DateTimeKind.Local).AddTicks(7757), null, 2, true, false, true, false, true, true, null, 1200m, "205", 1, 1, 1 },
                    { 27, new DateTime(2025, 3, 17, 2, 38, 2, 940, DateTimeKind.Local).AddTicks(7758), null, 2, true, false, true, false, true, true, null, 1200m, "206", 1, 1, 1 },
                    { 28, new DateTime(2025, 3, 17, 2, 38, 2, 940, DateTimeKind.Local).AddTicks(7758), null, 2, true, false, true, false, true, true, null, 1200m, "207", 1, 1, 1 },
                    { 29, new DateTime(2025, 3, 17, 2, 38, 2, 940, DateTimeKind.Local).AddTicks(7759), null, 2, true, false, true, false, true, true, null, 1200m, "208", 1, 1, 1 },
                    { 30, new DateTime(2025, 3, 17, 2, 38, 2, 940, DateTimeKind.Local).AddTicks(7759), null, 2, true, false, true, false, true, true, null, 1200m, "209", 1, 1, 1 },
                    { 31, new DateTime(2025, 3, 17, 2, 38, 2, 940, DateTimeKind.Local).AddTicks(7761), null, 2, true, false, true, true, true, true, null, 1800m, "210", 1, 3, 1 },
                    { 32, new DateTime(2025, 3, 17, 2, 38, 2, 940, DateTimeKind.Local).AddTicks(7762), null, 2, true, false, true, true, true, true, null, 1800m, "211", 1, 3, 1 },
                    { 33, new DateTime(2025, 3, 17, 2, 38, 2, 940, DateTimeKind.Local).AddTicks(7763), null, 2, true, false, true, true, true, true, null, 1800m, "212", 1, 3, 1 },
                    { 34, new DateTime(2025, 3, 17, 2, 38, 2, 940, DateTimeKind.Local).AddTicks(7764), null, 2, true, false, true, true, true, true, null, 1800m, "213", 1, 3, 1 },
                    { 35, new DateTime(2025, 3, 17, 2, 38, 2, 940, DateTimeKind.Local).AddTicks(7765), null, 2, true, false, true, true, true, true, null, 1800m, "214", 1, 3, 1 },
                    { 36, new DateTime(2025, 3, 17, 2, 38, 2, 940, DateTimeKind.Local).AddTicks(7765), null, 2, true, false, true, true, true, true, null, 1800m, "215", 1, 3, 1 },
                    { 37, new DateTime(2025, 3, 17, 2, 38, 2, 940, DateTimeKind.Local).AddTicks(7766), null, 2, true, false, true, true, true, true, null, 1800m, "216", 1, 3, 1 },
                    { 38, new DateTime(2025, 3, 17, 2, 38, 2, 940, DateTimeKind.Local).AddTicks(7766), null, 2, true, false, true, true, true, true, null, 1800m, "217", 1, 3, 1 },
                    { 39, new DateTime(2025, 3, 17, 2, 38, 2, 940, DateTimeKind.Local).AddTicks(7767), null, 2, true, false, true, true, true, true, null, 1800m, "218", 1, 3, 1 },
                    { 40, new DateTime(2025, 3, 17, 2, 38, 2, 940, DateTimeKind.Local).AddTicks(7767), null, 2, true, false, true, true, true, true, null, 1800m, "219", 1, 3, 1 },
                    { 41, new DateTime(2025, 3, 17, 2, 38, 2, 940, DateTimeKind.Local).AddTicks(7770), null, 3, true, true, true, true, true, true, null, 2200m, "300", 1, 2, 1 },
                    { 42, new DateTime(2025, 3, 17, 2, 38, 2, 940, DateTimeKind.Local).AddTicks(7772), null, 3, true, true, true, true, true, true, null, 2200m, "301", 1, 2, 1 },
                    { 43, new DateTime(2025, 3, 17, 2, 38, 2, 940, DateTimeKind.Local).AddTicks(7772), null, 3, true, true, true, true, true, true, null, 2200m, "302", 1, 2, 1 },
                    { 44, new DateTime(2025, 3, 17, 2, 38, 2, 940, DateTimeKind.Local).AddTicks(7773), null, 3, true, true, true, true, true, true, null, 2200m, "303", 1, 2, 1 },
                    { 45, new DateTime(2025, 3, 17, 2, 38, 2, 940, DateTimeKind.Local).AddTicks(7773), null, 3, true, true, true, true, true, true, null, 2200m, "304", 1, 2, 1 },
                    { 46, new DateTime(2025, 3, 17, 2, 38, 2, 940, DateTimeKind.Local).AddTicks(7774), null, 3, true, true, true, true, true, true, null, 2200m, "305", 1, 2, 1 },
                    { 47, new DateTime(2025, 3, 17, 2, 38, 2, 940, DateTimeKind.Local).AddTicks(7775), null, 3, true, true, true, true, true, true, null, 2200m, "306", 1, 2, 1 },
                    { 48, new DateTime(2025, 3, 17, 2, 38, 2, 940, DateTimeKind.Local).AddTicks(7775), null, 3, true, true, true, true, true, true, null, 2200m, "307", 1, 2, 1 },
                    { 49, new DateTime(2025, 3, 17, 2, 38, 2, 940, DateTimeKind.Local).AddTicks(7776), null, 3, true, true, true, true, true, true, null, 2200m, "308", 1, 2, 1 },
                    { 50, new DateTime(2025, 3, 17, 2, 38, 2, 940, DateTimeKind.Local).AddTicks(7776), null, 3, true, true, true, true, true, true, null, 2200m, "309", 1, 2, 1 },
                    { 51, new DateTime(2025, 3, 17, 2, 38, 2, 940, DateTimeKind.Local).AddTicks(7778), null, 3, true, true, true, true, true, true, null, 2500m, "310", 1, 5, 1 },
                    { 52, new DateTime(2025, 3, 17, 2, 38, 2, 940, DateTimeKind.Local).AddTicks(7779), null, 3, true, true, true, true, true, true, null, 2500m, "311", 1, 5, 1 },
                    { 53, new DateTime(2025, 3, 17, 2, 38, 2, 940, DateTimeKind.Local).AddTicks(7780), null, 3, true, true, true, true, true, true, null, 2500m, "312", 1, 5, 1 },
                    { 54, new DateTime(2025, 3, 17, 2, 38, 2, 940, DateTimeKind.Local).AddTicks(7781), null, 3, true, true, true, true, true, true, null, 2500m, "313", 1, 5, 1 },
                    { 55, new DateTime(2025, 3, 17, 2, 38, 2, 940, DateTimeKind.Local).AddTicks(7781), null, 3, true, true, true, true, true, true, null, 2500m, "314", 1, 5, 1 },
                    { 56, new DateTime(2025, 3, 17, 2, 38, 2, 940, DateTimeKind.Local).AddTicks(7782), null, 3, true, true, true, true, true, true, null, 2500m, "315", 1, 5, 1 },
                    { 57, new DateTime(2025, 3, 17, 2, 38, 2, 940, DateTimeKind.Local).AddTicks(7782), null, 3, true, true, true, true, true, true, null, 2500m, "316", 1, 5, 1 },
                    { 58, new DateTime(2025, 3, 17, 2, 38, 2, 940, DateTimeKind.Local).AddTicks(7783), null, 3, true, true, true, true, true, true, null, 2500m, "317", 1, 5, 1 },
                    { 59, new DateTime(2025, 3, 17, 2, 38, 2, 940, DateTimeKind.Local).AddTicks(7783), null, 3, true, true, true, true, true, true, null, 2500m, "318", 1, 5, 1 },
                    { 60, new DateTime(2025, 3, 17, 2, 38, 2, 940, DateTimeKind.Local).AddTicks(7784), null, 3, true, true, true, true, true, true, null, 2500m, "319", 1, 5, 1 },
                    { 61, new DateTime(2025, 3, 17, 2, 38, 2, 940, DateTimeKind.Local).AddTicks(7786), null, 4, true, true, true, true, true, true, null, 2800m, "400", 1, 2, 1 },
                    { 62, new DateTime(2025, 3, 17, 2, 38, 2, 940, DateTimeKind.Local).AddTicks(7787), null, 4, true, true, true, true, true, true, null, 2800m, "401", 1, 2, 1 },
                    { 63, new DateTime(2025, 3, 17, 2, 38, 2, 940, DateTimeKind.Local).AddTicks(7787), null, 4, true, true, true, true, true, true, null, 2800m, "402", 1, 2, 1 },
                    { 64, new DateTime(2025, 3, 17, 2, 38, 2, 940, DateTimeKind.Local).AddTicks(7788), null, 4, true, true, true, true, true, true, null, 2800m, "403", 1, 2, 1 },
                    { 65, new DateTime(2025, 3, 17, 2, 38, 2, 940, DateTimeKind.Local).AddTicks(7788), null, 4, true, true, true, true, true, true, null, 2800m, "404", 1, 2, 1 },
                    { 66, new DateTime(2025, 3, 17, 2, 38, 2, 940, DateTimeKind.Local).AddTicks(7811), null, 4, true, true, true, true, true, true, null, 2800m, "405", 1, 2, 1 },
                    { 67, new DateTime(2025, 3, 17, 2, 38, 2, 940, DateTimeKind.Local).AddTicks(7812), null, 4, true, true, true, true, true, true, null, 2800m, "406", 1, 2, 1 },
                    { 68, new DateTime(2025, 3, 17, 2, 38, 2, 940, DateTimeKind.Local).AddTicks(7812), null, 4, true, true, true, true, true, true, null, 2800m, "407", 1, 2, 1 },
                    { 69, new DateTime(2025, 3, 17, 2, 38, 2, 940, DateTimeKind.Local).AddTicks(7813), null, 4, true, true, true, true, true, true, null, 2800m, "408", 1, 2, 1 },
                    { 70, new DateTime(2025, 3, 17, 2, 38, 2, 940, DateTimeKind.Local).AddTicks(7814), null, 4, true, true, true, true, true, true, null, 2800m, "409", 1, 2, 1 },
                    { 71, new DateTime(2025, 3, 17, 2, 38, 2, 940, DateTimeKind.Local).AddTicks(7816), null, 4, true, true, true, true, true, true, null, 3500m, "410", 1, 6, 1 },
                    { 72, new DateTime(2025, 3, 17, 2, 38, 2, 940, DateTimeKind.Local).AddTicks(7817), null, 4, true, true, true, true, true, true, null, 3500m, "411", 1, 6, 1 },
                    { 73, new DateTime(2025, 3, 17, 2, 38, 2, 940, DateTimeKind.Local).AddTicks(7818), null, 4, true, true, true, true, true, true, null, 3500m, "412", 1, 6, 1 },
                    { 74, new DateTime(2025, 3, 17, 2, 38, 2, 940, DateTimeKind.Local).AddTicks(7818), null, 4, true, true, true, true, true, true, null, 3500m, "413", 1, 6, 1 },
                    { 75, new DateTime(2025, 3, 17, 2, 38, 2, 940, DateTimeKind.Local).AddTicks(7819), null, 4, true, true, true, true, true, true, null, 3500m, "414", 1, 6, 1 },
                    { 76, new DateTime(2025, 3, 17, 2, 38, 2, 940, DateTimeKind.Local).AddTicks(7820), null, 4, true, true, true, true, true, true, null, 3500m, "415", 1, 6, 1 },
                    { 77, new DateTime(2025, 3, 17, 2, 38, 2, 940, DateTimeKind.Local).AddTicks(7821), null, 4, true, true, true, true, true, true, null, 10000m, "417", 1, 7, 1 }
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
