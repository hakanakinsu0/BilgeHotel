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
                    { 1, "bc50c2e4-ebee-4c35-af3a-ed6136de758b", "Admin", "ADMIN" },
                    { 2, "338056de-b5b1-43ad-842f-f12eba7e8940", "Member", "MEMBER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ActivationCode", "ConcurrencyStamp", "CreatedDate", "DeletedDate", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "ModifiedDate", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Status", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { 1, 0, new Guid("00000000-0000-0000-0000-000000000000"), "ae0d7052-c1e2-4892-b4c7-981aa4aa24d4", new DateTime(2025, 3, 11, 1, 57, 41, 754, DateTimeKind.Local).AddTicks(2455), null, "bilgehotel@email.com", true, false, null, null, "BILGEHOTEL@EMAIL.COM", "BILGEHOTEL", "AQAAAAIAAYagAAAAEL/I76zdsIno+hPInV7HtehFIvrVE1gG2KyTT6rbi0Be0E640Zy4HJ9Ay6wlDMnecg==", null, false, "67b211bf-72a1-4c8d-8b8b-81cfa80a3b93", 1, false, "bilgehotel" },
                    { 2, 0, new Guid("00000000-0000-0000-0000-000000000000"), "007bddd3-fab6-4a7c-bd63-23341ab9b7d8", new DateTime(2025, 3, 11, 1, 57, 41, 792, DateTimeKind.Local).AddTicks(5558), null, "testmember@email.com", true, false, null, null, "TESTMEMBER@EMAIL.COM", "TESTMEMBER", "AQAAAAIAAYagAAAAEMOb0lOJXVACMZWwD5rlIoj1RALtPWnOe+t/uINv1/yFoXSVkrtV92SmsGTl2nLTxA==", null, false, "674e051b-be18-416c-aee0-9a37dca468c4", 1, false, "testmember" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Address", "BirthDate", "CreatedDate", "DeletedDate", "FirstName", "HireDate", "LastName", "ModifiedDate", "PhoneNumber", "Salary", "Shift", "Status" },
                values: new object[,]
                {
                    { 1, "Bandak Sokak 74a, Yozgat, Tayland", new DateTime(1990, 11, 5, 16, 14, 24, 922, DateTimeKind.Local).AddTicks(2557), new DateTime(2025, 3, 11, 1, 57, 41, 714, DateTimeKind.Local).AddTicks(4218), null, "Bilgebayunçur", new DateTime(2022, 3, 9, 9, 4, 54, 922, DateTimeKind.Local).AddTicks(7269), "Ekşioğlu", null, "+90-658-120-78-59", 142.69m, 2, 1 },
                    { 2, "Bahçe Sokak 06b, Osmaniye, Kazakistan", new DateTime(1987, 1, 22, 1, 11, 55, 916, DateTimeKind.Local).AddTicks(6479), new DateTime(2025, 3, 11, 1, 57, 41, 714, DateTimeKind.Local).AddTicks(4290), null, "Akbudak", new DateTime(2020, 7, 21, 15, 20, 26, 901, DateTimeKind.Local).AddTicks(3528), "Egeli", null, "+90-190-573-70-08", 129.86m, 3, 1 },
                    { 3, "Güven Yaka Sokak 0, Muş, Guadalup, Fransa", new DateTime(2000, 10, 26, 15, 52, 41, 643, DateTimeKind.Local).AddTicks(415), new DateTime(2025, 3, 11, 1, 57, 41, 714, DateTimeKind.Local).AddTicks(4382), null, "Akı", new DateTime(2022, 6, 7, 14, 12, 43, 899, DateTimeKind.Local).AddTicks(4269), "Solmaz", null, "+90-788-515-04-78", 155.02m, 3, 1 },
                    { 4, "Barış Sokak 76a, Erzincan, Nijerya", new DateTime(1976, 4, 19, 23, 15, 32, 928, DateTimeKind.Local).AddTicks(30), new DateTime(2025, 3, 11, 1, 57, 41, 714, DateTimeKind.Local).AddTicks(4479), null, "Duygu", new DateTime(2015, 3, 28, 8, 0, 12, 470, DateTimeKind.Local).AddTicks(4667), "Karaduman", null, "+90-557-490-76-35", 140.98m, 2, 1 },
                    { 5, "Menekşe Sokak 697, K.maraş, Suriye", new DateTime(1992, 1, 3, 6, 55, 50, 208, DateTimeKind.Local).AddTicks(1796), new DateTime(2025, 3, 11, 1, 57, 41, 714, DateTimeKind.Local).AddTicks(4558), null, "Akça", new DateTime(2019, 10, 10, 13, 33, 38, 948, DateTimeKind.Local).AddTicks(2856), "Evliyaoğlu", null, "+90-673-293-58-31", 138.39m, 1, 1 },
                    { 6, "Gül Sokak 72, İçel (Mersin), Güney Georgia ve Güney Sandviç Adaları, İngiltere", new DateTime(1998, 8, 4, 6, 33, 24, 471, DateTimeKind.Local).AddTicks(4626), new DateTime(2025, 3, 11, 1, 57, 41, 714, DateTimeKind.Local).AddTicks(4615), null, "Bağaışbara", new DateTime(2021, 1, 17, 14, 3, 53, 681, DateTimeKind.Local).AddTicks(7366), "Akan", null, "+90-927-584-52-81", 132.09m, 2, 1 },
                    { 7, "İsmet Attila Caddesi 675, Burdur, Gambiya", new DateTime(1986, 7, 21, 9, 38, 18, 886, DateTimeKind.Local).AddTicks(3161), new DateTime(2025, 3, 11, 1, 57, 41, 714, DateTimeKind.Local).AddTicks(4706), null, "Çağrıtegin", new DateTime(2023, 9, 19, 16, 40, 15, 932, DateTimeKind.Local).AddTicks(3770), "Paksüt", null, "+90-300-927-7-174", 139.13m, 1, 1 },
                    { 8, "Namık Kemal Caddesi 03a, Kırklareli, İtalya", new DateTime(1973, 11, 22, 18, 13, 28, 856, DateTimeKind.Local).AddTicks(4787), new DateTime(2025, 3, 11, 1, 57, 41, 714, DateTimeKind.Local).AddTicks(4796), null, "Berginsenge", new DateTime(2021, 4, 11, 5, 30, 11, 13, DateTimeKind.Local).AddTicks(5567), "Tütüncü", null, "+90-000-396-23-92", 118.88m, 2, 1 },
                    { 9, "Bayır Sokak 05b, Adana, Solomon Adaları", new DateTime(1977, 8, 17, 3, 3, 41, 707, DateTimeKind.Local).AddTicks(7125), new DateTime(2025, 3, 11, 1, 57, 41, 714, DateTimeKind.Local).AddTicks(4846), null, "Burulgu", new DateTime(2018, 11, 25, 2, 15, 59, 986, DateTimeKind.Local).AddTicks(3094), "Uluhan", null, "+90-584-654-54-73", 114.59m, 2, 1 },
                    { 10, "İsmet Paşa Caddesi 6, Giresun, Tayland", new DateTime(1969, 3, 19, 14, 17, 3, 505, DateTimeKind.Local).AddTicks(7741), new DateTime(2025, 3, 11, 1, 57, 41, 714, DateTimeKind.Local).AddTicks(4938), null, "Bügü", new DateTime(2017, 4, 14, 19, 15, 35, 268, DateTimeKind.Local).AddTicks(4926), "Tahincioğlu", null, "+90-298-265-7-858", 122.79m, 1, 1 },
                    { 11, "Dar Sokak 96a, Aydın, Ekvator", new DateTime(2001, 4, 5, 23, 44, 41, 967, DateTimeKind.Local).AddTicks(635), new DateTime(2025, 3, 11, 1, 57, 41, 714, DateTimeKind.Local).AddTicks(5014), null, "Ekin", new DateTime(2023, 3, 2, 16, 15, 20, 145, DateTimeKind.Local).AddTicks(6553), "Dizdar ", null, "+90-737-865-16-69", 120.94m, 1, 1 },
                    { 12, "Menekşe Sokak 56b, Amasya, Tunus", new DateTime(1978, 12, 27, 18, 43, 23, 103, DateTimeKind.Local).AddTicks(8545), new DateTime(2025, 3, 11, 1, 57, 41, 714, DateTimeKind.Local).AddTicks(5081), null, "Burulday", new DateTime(2020, 8, 10, 18, 44, 15, 319, DateTimeKind.Local).AddTicks(6559), "Tokatlıoğlu", null, "+90-770-050-0-493", 113.61m, 1, 1 },
                    { 13, "Barış Sokak 147, Yozgat, Aruba, Hollanda", new DateTime(1977, 9, 26, 14, 46, 44, 581, DateTimeKind.Local).AddTicks(9891), new DateTime(2025, 3, 11, 1, 57, 41, 714, DateTimeKind.Local).AddTicks(5128), null, "Ayyıldız", new DateTime(2019, 9, 8, 16, 5, 56, 167, DateTimeKind.Local).AddTicks(3175), "Karadaş", null, "+90-562-387-63-11", 110.94m, 2, 1 },
                    { 14, "Afyon Kaya Sokak 597, Denizli, Hindistan", new DateTime(1983, 3, 8, 12, 5, 30, 664, DateTimeKind.Local).AddTicks(8181), new DateTime(2025, 3, 11, 1, 57, 41, 714, DateTimeKind.Local).AddTicks(5209), null, "Benlidemir", new DateTime(2021, 6, 7, 7, 53, 5, 768, DateTimeKind.Local).AddTicks(5816), "Dağlaroğlu", null, "+90-772-384-52-82", 116.93m, 2, 1 },
                    { 15, "İbn-i Sina Sokak 99b, Amasya, Çin", new DateTime(1973, 1, 14, 2, 34, 33, 826, DateTimeKind.Local).AddTicks(2415), new DateTime(2025, 3, 11, 1, 57, 41, 714, DateTimeKind.Local).AddTicks(5294), null, "Akbulak", new DateTime(2018, 12, 11, 13, 21, 31, 14, DateTimeKind.Local).AddTicks(9119), "Durmaz", null, "+90-210-323-38-89", 124.98m, 1, 1 },
                    { 16, "30 Ağustos Caddesi 35b, Şırnak, Maldiv Adaları", new DateTime(1985, 8, 13, 22, 50, 29, 306, DateTimeKind.Local).AddTicks(9891), new DateTime(2025, 3, 11, 1, 57, 41, 714, DateTimeKind.Local).AddTicks(5372), null, "Asuğ", new DateTime(2023, 10, 22, 4, 52, 41, 701, DateTimeKind.Local).AddTicks(3388), "Tazegül", null, "+90-404-428-85-32", 120.65m, 2, 1 },
                    { 17, "İsmet Paşa Caddesi 67, Van, Sierra Leone", new DateTime(2002, 9, 13, 13, 21, 41, 658, DateTimeKind.Local).AddTicks(1604), new DateTime(2025, 3, 11, 1, 57, 41, 714, DateTimeKind.Local).AddTicks(5421), null, "Beçeapa", new DateTime(2020, 1, 3, 13, 8, 47, 468, DateTimeKind.Local).AddTicks(1138), "Topaloğlu", null, "+90-644-825-50-53", 118.63m, 1, 1 },
                    { 18, "Harman Altı Sokak 11b, Iğdır, Svalbard, Norveç", new DateTime(1995, 2, 22, 22, 21, 41, 699, DateTimeKind.Local).AddTicks(248), new DateTime(2025, 3, 11, 1, 57, 41, 714, DateTimeKind.Local).AddTicks(5500), null, "Batrak", new DateTime(2023, 4, 25, 0, 47, 55, 499, DateTimeKind.Local).AddTicks(2543), "Dağlaroğlu", null, "+90-517-309-24-35", 121.93m, 2, 1 },
                    { 19, "Oğuzhan Sokak 1, Artvin, Vanuatu", new DateTime(1985, 4, 19, 9, 55, 31, 221, DateTimeKind.Local).AddTicks(1957), new DateTime(2025, 3, 11, 1, 57, 41, 714, DateTimeKind.Local).AddTicks(5579), null, "Akbay", new DateTime(2014, 5, 5, 12, 9, 1, 753, DateTimeKind.Local).AddTicks(9928), "Ağaoğlu", null, "+90-063-118-3-100", 168.86m, 1, 1 },
                    { 20, "Saygılı Sokak 05, Antalya, Palau Adaları", new DateTime(1969, 1, 3, 7, 42, 4, 75, DateTimeKind.Local).AddTicks(4028), new DateTime(2025, 3, 11, 1, 57, 41, 714, DateTimeKind.Local).AddTicks(5659), null, "Kargılaç", new DateTime(2020, 10, 21, 8, 12, 23, 303, DateTimeKind.Local).AddTicks(5899), "Kutlay", null, "+90-237-983-4-453", 162.14m, 1, 1 },
                    { 21, "Okul Sokak 19b, Tunceli, Bermuda, İngiltere", new DateTime(1972, 8, 2, 22, 52, 42, 612, DateTimeKind.Local).AddTicks(1120), new DateTime(2025, 3, 11, 1, 57, 41, 714, DateTimeKind.Local).AddTicks(5709), null, "Kekik", new DateTime(2018, 11, 3, 17, 52, 33, 652, DateTimeKind.Local).AddTicks(829), "Okur", null, "+90-238-679-0-651", 132.29m, 2, 1 },
                    { 22, "Oğuzhan Sokak 63, Kocaeli, Fransız Guyanası", new DateTime(1969, 8, 31, 10, 19, 24, 377, DateTimeKind.Local).AddTicks(6697), new DateTime(2025, 3, 11, 1, 57, 41, 714, DateTimeKind.Local).AddTicks(5781), null, "Aruk", new DateTime(2021, 4, 9, 23, 40, 58, 485, DateTimeKind.Local).AddTicks(9658), "Taşçı", null, "+90-716-521-12-26", 142.29m, 2, 1 },
                    { 23, "Bahçe Sokak 146, İzmir, Nijer", new DateTime(2005, 12, 22, 0, 49, 29, 288, DateTimeKind.Local).AddTicks(5836), new DateTime(2025, 3, 11, 1, 57, 41, 714, DateTimeKind.Local).AddTicks(5846), null, "Balkık", new DateTime(2018, 6, 27, 4, 13, 23, 780, DateTimeKind.Local).AddTicks(8890), "Kuday", null, "+90-908-009-2-923", 143.68m, 1, 1 },
                    { 24, "Güven Yaka Sokak 09a, Balıkesir, Yunanistan", new DateTime(1972, 4, 24, 6, 15, 9, 635, DateTimeKind.Local).AddTicks(9277), new DateTime(2025, 3, 11, 1, 57, 41, 714, DateTimeKind.Local).AddTicks(5892), null, "Atakağan", new DateTime(2016, 4, 17, 17, 45, 6, 163, DateTimeKind.Local).AddTicks(4682), "Öztonga", null, "+90-379-484-19-72", 163.85m, 2, 1 },
                    { 25, "Kaldırım Sokak 04a, Elazığ, Marşal Adaları", new DateTime(1979, 6, 26, 13, 23, 58, 200, DateTimeKind.Local).AddTicks(7234), new DateTime(2025, 3, 11, 1, 57, 41, 714, DateTimeKind.Local).AddTicks(5973), null, "Boyankulu", new DateTime(2018, 4, 15, 3, 0, 0, 550, DateTimeKind.Local).AddTicks(5405), "Ekşioğlu", null, "+90-254-228-35-20", 146.62m, 1, 1 },
                    { 26, "Yunus Emre Sokak 37b, Isparta, İrlanda", new DateTime(1983, 5, 22, 15, 48, 22, 773, DateTimeKind.Local).AddTicks(4985), new DateTime(2025, 3, 11, 1, 57, 41, 714, DateTimeKind.Local).AddTicks(6063), null, "Adsız", new DateTime(2014, 11, 26, 18, 22, 3, 902, DateTimeKind.Local).AddTicks(3617), "Keçeci", null, "+90-501-162-2-017", 149.50m, 1, 1 },
                    { 27, "Sarıkaya Caddesi 34a, Afyon, El Salvador", new DateTime(1984, 5, 23, 5, 39, 17, 340, DateTimeKind.Local).AddTicks(4), new DateTime(2025, 3, 11, 1, 57, 41, 714, DateTimeKind.Local).AddTicks(6147), null, "Akbaş", new DateTime(2024, 1, 3, 19, 43, 45, 572, DateTimeKind.Local).AddTicks(6460), "Tütüncü", null, "+90-543-840-21-93", 153.63m, 1, 1 },
                    { 28, "Köypınar Sokak 94a, İzmir, Cebelitarık, İngiltere", new DateTime(1977, 7, 6, 17, 45, 22, 701, DateTimeKind.Local).AddTicks(3390), new DateTime(2025, 3, 11, 1, 57, 41, 714, DateTimeKind.Local).AddTicks(6195), null, "Altankan", new DateTime(2018, 12, 30, 11, 41, 50, 973, DateTimeKind.Local).AddTicks(7659), "Önür", null, "+90-987-744-2-917", 153.13m, 2, 1 },
                    { 29, "30 Ağustos Caddesi 09, Artvin, Danimarka", new DateTime(1993, 8, 27, 10, 56, 1, 184, DateTimeKind.Local).AddTicks(4568), new DateTime(2025, 3, 11, 1, 57, 41, 714, DateTimeKind.Local).AddTicks(6271), null, "Eyiz", new DateTime(2014, 4, 6, 8, 45, 28, 487, DateTimeKind.Local).AddTicks(4709), "Erginsoy", null, "+90-131-787-30-68", 132.94m, 1, 1 },
                    { 30, "Dar Sokak 80a, Mardin, İran", new DateTime(1983, 6, 27, 17, 39, 1, 146, DateTimeKind.Local).AddTicks(4448), new DateTime(2025, 3, 11, 1, 57, 41, 714, DateTimeKind.Local).AddTicks(6343), null, "Arı", new DateTime(2022, 6, 12, 5, 27, 42, 285, DateTimeKind.Local).AddTicks(3078), "Ilıcalı", null, "+90-331-591-73-71", 111.98m, 2, 1 },
                    { 31, "Bahçe Sokak 57b, Niğde, Belçika", new DateTime(1997, 9, 14, 5, 31, 41, 281, DateTimeKind.Local).AddTicks(886), new DateTime(2025, 3, 11, 1, 57, 41, 714, DateTimeKind.Local).AddTicks(6417), null, "Açık", new DateTime(2017, 12, 3, 21, 15, 40, 528, DateTimeKind.Local).AddTicks(6443), "Aybar", null, "+90-902-066-9-841", 125.04m, 1, 1 },
                    { 32, "İsmet Paşa Caddesi 11c, Iğdır, Bhutan", new DateTime(2000, 9, 24, 12, 14, 28, 507, DateTimeKind.Local).AddTicks(820), new DateTime(2025, 3, 11, 1, 57, 41, 714, DateTimeKind.Local).AddTicks(6464), null, "Bilgebayunçur", new DateTime(2014, 4, 7, 17, 25, 16, 882, DateTimeKind.Local).AddTicks(9656), "Özkara", null, "+90-186-041-77-71", 134.59m, 1, 1 },
                    { 33, "Barış Sokak 79c, Çanakkale, Arnavutluk", new DateTime(2006, 5, 26, 15, 48, 48, 662, DateTimeKind.Local).AddTicks(2649), new DateTime(2025, 3, 11, 1, 57, 41, 714, DateTimeKind.Local).AddTicks(6536), null, "Kazkatun", new DateTime(2014, 9, 6, 9, 6, 1, 559, DateTimeKind.Local).AddTicks(1864), "Tunçeri", null, "+90-688-517-86-89", 126.12m, 2, 1 },
                    { 34, "Alparslan Türkeş Bulvarı 15, Denizli, Kırgızistan", new DateTime(1984, 8, 13, 3, 30, 3, 23, DateTimeKind.Local).AddTicks(3878), new DateTime(2025, 3, 11, 1, 57, 41, 714, DateTimeKind.Local).AddTicks(6602), null, "Açık", new DateTime(2016, 7, 21, 23, 57, 45, 758, DateTimeKind.Local).AddTicks(8196), "Sepetçi", null, "+90-453-701-4-435", 135.44m, 1, 1 },
                    { 35, "Nalbant Sokak 96, Bartın, Grönland", new DateTime(1970, 12, 25, 23, 30, 36, 75, DateTimeKind.Local).AddTicks(2414), new DateTime(2025, 3, 11, 1, 57, 41, 714, DateTimeKind.Local).AddTicks(6685), null, "Bügdüz", new DateTime(2018, 6, 28, 13, 27, 3, 850, DateTimeKind.Local).AddTicks(4931), "Abadan", null, "+90-149-336-8-103", 126.53m, 2, 1 },
                    { 36, "İsmet Paşa Caddesi 455, Kastamonu, Ekvator Ginesi", new DateTime(1996, 7, 16, 4, 3, 20, 423, DateTimeKind.Local).AddTicks(7043), new DateTime(2025, 3, 11, 1, 57, 41, 714, DateTimeKind.Local).AddTicks(6732), null, "Alpagut", new DateTime(2020, 8, 30, 18, 53, 45, 953, DateTimeKind.Local).AddTicks(7717), "Durak ", null, "+90-643-096-63-28", 129.44m, 2, 1 },
                    { 37, "Namık Kemal Caddesi 1, Samsun, Amerikan Samoa", new DateTime(1992, 10, 20, 13, 22, 34, 609, DateTimeKind.Local).AddTicks(1909), new DateTime(2025, 3, 11, 1, 57, 41, 714, DateTimeKind.Local).AddTicks(6826), null, "Al", new DateTime(2023, 1, 26, 15, 32, 13, 332, DateTimeKind.Local).AddTicks(341), "Menemencioğlu", null, "+90-912-353-8-312", 121.06m, 1, 1 },
                    { 38, "Afyon Kaya Sokak 52c, Gümüşhane, Avusturya", new DateTime(1969, 1, 24, 18, 48, 8, 769, DateTimeKind.Local).AddTicks(1535), new DateTime(2025, 3, 11, 1, 57, 41, 714, DateTimeKind.Local).AddTicks(6909), null, "Barboğa", new DateTime(2019, 5, 7, 4, 45, 34, 801, DateTimeKind.Local).AddTicks(5339), "Avan", null, "+90-364-772-19-87", 127.25m, 2, 1 },
                    { 39, "Ülkü Sokak 40a, Konya, Yeni Zelanda", new DateTime(1977, 7, 20, 19, 47, 44, 518, DateTimeKind.Local).AddTicks(3621), new DateTime(2025, 3, 11, 1, 57, 41, 714, DateTimeKind.Local).AddTicks(6996), null, "Ekim", new DateTime(2023, 5, 5, 13, 45, 38, 55, DateTimeKind.Local).AddTicks(5048), "Yetkiner", null, "+90-205-108-92-59", 122.21m, 1, 1 },
                    { 40, "Namık Kemal Caddesi 12a, Düzce, Kazakistan", new DateTime(1971, 9, 28, 23, 50, 24, 87, DateTimeKind.Local).AddTicks(6040), new DateTime(2025, 3, 11, 1, 57, 41, 714, DateTimeKind.Local).AddTicks(7045), null, "Apa", new DateTime(2023, 8, 26, 13, 0, 51, 665, DateTimeKind.Local).AddTicks(7184), "Akışık", null, "+90-883-238-6-095", 102.90m, 1, 1 },
                    { 41, "Fatih Sokak  6, Balıkesir, Lesotho", new DateTime(2002, 8, 19, 20, 5, 12, 13, DateTimeKind.Local).AddTicks(2806), new DateTime(2025, 3, 11, 1, 57, 41, 714, DateTimeKind.Local).AddTicks(7123), null, "Beğbars", new DateTime(2016, 12, 11, 10, 18, 21, 189, DateTimeKind.Local).AddTicks(7413), "Nalbantoğlu", null, "+90-622-232-74-85", 109.75m, 1, 1 },
                    { 42, "Dağınık Evler Sokak 59a, İstanbul, Kanada", new DateTime(1970, 6, 11, 0, 5, 30, 808, DateTimeKind.Local).AddTicks(3083), new DateTime(2025, 3, 11, 1, 57, 41, 714, DateTimeKind.Local).AddTicks(7206), null, "Cılasun", new DateTime(2019, 5, 1, 11, 39, 8, 988, DateTimeKind.Local).AddTicks(3496), "Tunaboylu", null, "+90-030-171-3-028", 136.53m, 1, 1 },
                    { 43, "Alparslan Türkeş Bulvarı 10c, Yalova, Hırvatistan", new DateTime(1989, 9, 21, 1, 8, 31, 270, DateTimeKind.Local).AddTicks(4291), new DateTime(2025, 3, 11, 1, 57, 41, 714, DateTimeKind.Local).AddTicks(7289), null, "Alparslan", new DateTime(2014, 11, 15, 23, 12, 21, 200, DateTimeKind.Local).AddTicks(507), "Erbulak", null, "+90-294-773-40-92", 143.44m, 3, 1 },
                    { 44, "Oğuzhan Sokak 87, Kilis, Lübnan", new DateTime(1984, 9, 11, 7, 34, 59, 188, DateTimeKind.Local).AddTicks(7605), new DateTime(2025, 3, 11, 1, 57, 41, 714, DateTimeKind.Local).AddTicks(7348), null, "Alpaya", new DateTime(2017, 4, 23, 3, 11, 52, 850, DateTimeKind.Local).AddTicks(3158), "Poçan", null, "+90-431-197-3-026", 158.10m, 2, 1 }
                });

            migrationBuilder.InsertData(
                table: "ExtraServices",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Description", "ModifiedDate", "Name", "Price", "Status" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 3, 11, 1, 57, 41, 792, DateTimeKind.Local).AddTicks(5909), null, "Günlük sınırsız spa kullanımı.", null, "Spa Kullanımı", 50m, 1 },
                    { 2, new DateTime(2025, 3, 11, 1, 57, 41, 792, DateTimeKind.Local).AddTicks(5911), null, "24 saat oda servisi. Tüm yemek siparişleri dahildir.", null, "Oda Servisi", 30m, 1 },
                    { 3, new DateTime(2025, 3, 11, 1, 57, 41, 792, DateTimeKind.Local).AddTicks(5913), null, "Minibardaki içecekler ve atıştırmalıklar dahil.", null, "Minibar Kullanımı", 20m, 1 },
                    { 4, new DateTime(2025, 3, 11, 1, 57, 41, 792, DateTimeKind.Local).AddTicks(5914), null, "Gidiş-dönüş özel araç transferi.", null, "Havalimanı Transferi", 100m, 1 },
                    { 5, new DateTime(2025, 3, 11, 1, 57, 41, 792, DateTimeKind.Local).AddTicks(5916), null, "Konaklama süresince ücretsiz çamaşır ve kuru temizleme hizmeti.", null, "Çamaşırhane Hizmeti", 40m, 1 },
                    { 6, new DateTime(2025, 3, 11, 1, 57, 41, 792, DateTimeKind.Local).AddTicks(5924), null, "Ekstra günlük temizlik ve hijyen paketi.", null, "Günlük Oda Temizliği", 25m, 1 },
                    { 7, new DateTime(2025, 3, 11, 1, 57, 41, 792, DateTimeKind.Local).AddTicks(5925), null, "Özel şezlong ve plaj hizmetleri.", null, "Özel Plaj Alanı", 35m, 1 }
                });

            migrationBuilder.InsertData(
                table: "Packages",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Description", "ModifiedDate", "Name", "PriceMultiplier", "Status" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 3, 11, 1, 57, 41, 792, DateTimeKind.Local).AddTicks(5866), null, "Kahvaltı, öğle ve akşam yemeği dahil.", null, "Tam Pansiyon", 1.2m, 1 },
                    { 2, new DateTime(2025, 3, 11, 1, 57, 41, 792, DateTimeKind.Local).AddTicks(5868), null, "Tüm yemekler, alkollü-alkolsüz içecekler ve otelin sunduğu belirli hizmetler dahil.", null, "Her Şey Dahil", 1.5m, 1 }
                });

            migrationBuilder.InsertData(
                table: "RoomTypes",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Description", "ModifiedDate", "Name", "Status" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 3, 11, 1, 57, 41, 712, DateTimeKind.Local).AddTicks(7060), null, "1 adet tek kişilik yatak. Balkon ve minibar bulunmaz. Klima, TV, saç kurutma makinesi ve WiFi mevcuttur.", null, "Tek Kişilik", 1 },
                    { 2, new DateTime(2025, 3, 11, 1, 57, 41, 712, DateTimeKind.Local).AddTicks(7071), null, "1 adet büyük (duble) yatak. Minibar bulunur. Klima, TV, saç kurutma makinesi ve WiFi mevcuttur.", null, "Çift Kişilik (Duble)", 1 },
                    { 3, new DateTime(2025, 3, 11, 1, 57, 41, 712, DateTimeKind.Local).AddTicks(7072), null, "3 adet tek kişilik yatak. Balkon ve minibar bulunmaz. Klima, TV, saç kurutma makinesi ve WiFi mevcuttur.", null, "Üç Kişilik", 1 },
                    { 4, new DateTime(2025, 3, 11, 1, 57, 41, 712, DateTimeKind.Local).AddTicks(7074), null, "1 adet büyük (duble) yatak + 2 adet tek kişilik yatak. Balkon ve minibar bulunur. Klima, TV, saç kurutma makinesi ve WiFi mevcuttur.", null, "Dört Kişilik", 1 },
                    { 5, new DateTime(2025, 3, 11, 1, 57, 41, 712, DateTimeKind.Local).AddTicks(7075), null, "Geniş ve lüks oda. Özel oturma alanı, büyük yatak, balkon, minibar, özel banyo ve lüks hizmetler. Klima, TV, saç kurutma makinesi, WiFi ve özel hizmetler mevcuttur.", null, "Kral Dairesi", 1 }
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
                    { 1, new DateTime(2025, 3, 11, 1, 57, 41, 712, DateTimeKind.Local).AddTicks(7136), null, 1, true, false, true, false, true, true, null, 1000m, "100", 1, 1, 1 },
                    { 2, new DateTime(2025, 3, 11, 1, 57, 41, 712, DateTimeKind.Local).AddTicks(7138), null, 1, true, false, true, false, true, true, null, 1000m, "101", 1, 1, 1 },
                    { 3, new DateTime(2025, 3, 11, 1, 57, 41, 712, DateTimeKind.Local).AddTicks(7139), null, 1, true, false, true, false, true, true, null, 1000m, "102", 1, 1, 1 },
                    { 4, new DateTime(2025, 3, 11, 1, 57, 41, 712, DateTimeKind.Local).AddTicks(7139), null, 1, true, false, true, false, true, true, null, 1000m, "103", 1, 1, 1 },
                    { 5, new DateTime(2025, 3, 11, 1, 57, 41, 712, DateTimeKind.Local).AddTicks(7140), null, 1, true, false, true, false, true, true, null, 1000m, "104", 1, 1, 1 },
                    { 6, new DateTime(2025, 3, 11, 1, 57, 41, 712, DateTimeKind.Local).AddTicks(7142), null, 1, true, false, true, false, true, true, null, 1000m, "105", 1, 1, 1 },
                    { 7, new DateTime(2025, 3, 11, 1, 57, 41, 712, DateTimeKind.Local).AddTicks(7143), null, 1, true, false, true, false, true, true, null, 1000m, "106", 1, 1, 1 },
                    { 8, new DateTime(2025, 3, 11, 1, 57, 41, 712, DateTimeKind.Local).AddTicks(7143), null, 1, true, false, true, false, true, true, null, 1000m, "107", 1, 1, 1 },
                    { 9, new DateTime(2025, 3, 11, 1, 57, 41, 712, DateTimeKind.Local).AddTicks(7144), null, 1, true, false, true, false, true, true, null, 1000m, "108", 1, 1, 1 },
                    { 10, new DateTime(2025, 3, 11, 1, 57, 41, 712, DateTimeKind.Local).AddTicks(7145), null, 1, true, false, true, false, true, true, null, 1000m, "109", 1, 1, 1 },
                    { 11, new DateTime(2025, 3, 11, 1, 57, 41, 712, DateTimeKind.Local).AddTicks(7148), null, 1, true, false, true, false, true, true, null, 1500m, "110", 1, 3, 1 },
                    { 12, new DateTime(2025, 3, 11, 1, 57, 41, 712, DateTimeKind.Local).AddTicks(7149), null, 1, true, false, true, false, true, true, null, 1500m, "111", 1, 3, 1 },
                    { 13, new DateTime(2025, 3, 11, 1, 57, 41, 712, DateTimeKind.Local).AddTicks(7150), null, 1, true, false, true, false, true, true, null, 1500m, "112", 1, 3, 1 },
                    { 14, new DateTime(2025, 3, 11, 1, 57, 41, 712, DateTimeKind.Local).AddTicks(7150), null, 1, true, false, true, false, true, true, null, 1500m, "113", 1, 3, 1 },
                    { 15, new DateTime(2025, 3, 11, 1, 57, 41, 712, DateTimeKind.Local).AddTicks(7151), null, 1, true, false, true, false, true, true, null, 1500m, "114", 1, 3, 1 },
                    { 16, new DateTime(2025, 3, 11, 1, 57, 41, 712, DateTimeKind.Local).AddTicks(7151), null, 1, true, false, true, false, true, true, null, 1500m, "115", 1, 3, 1 },
                    { 17, new DateTime(2025, 3, 11, 1, 57, 41, 712, DateTimeKind.Local).AddTicks(7152), null, 1, true, false, true, false, true, true, null, 1500m, "116", 1, 3, 1 },
                    { 18, new DateTime(2025, 3, 11, 1, 57, 41, 712, DateTimeKind.Local).AddTicks(7153), null, 1, true, false, true, false, true, true, null, 1500m, "117", 1, 3, 1 },
                    { 19, new DateTime(2025, 3, 11, 1, 57, 41, 712, DateTimeKind.Local).AddTicks(7154), null, 1, true, false, true, false, true, true, null, 1500m, "118", 1, 3, 1 },
                    { 20, new DateTime(2025, 3, 11, 1, 57, 41, 712, DateTimeKind.Local).AddTicks(7154), null, 1, true, false, true, false, true, true, null, 1500m, "119", 1, 3, 1 },
                    { 21, new DateTime(2025, 3, 11, 1, 57, 41, 712, DateTimeKind.Local).AddTicks(7156), null, 2, true, false, true, false, true, true, null, 1200m, "200", 1, 1, 1 },
                    { 22, new DateTime(2025, 3, 11, 1, 57, 41, 712, DateTimeKind.Local).AddTicks(7157), null, 2, true, false, true, false, true, true, null, 1200m, "201", 1, 1, 1 },
                    { 23, new DateTime(2025, 3, 11, 1, 57, 41, 712, DateTimeKind.Local).AddTicks(7158), null, 2, true, false, true, false, true, true, null, 1200m, "202", 1, 1, 1 },
                    { 24, new DateTime(2025, 3, 11, 1, 57, 41, 712, DateTimeKind.Local).AddTicks(7158), null, 2, true, false, true, false, true, true, null, 1200m, "203", 1, 1, 1 },
                    { 25, new DateTime(2025, 3, 11, 1, 57, 41, 712, DateTimeKind.Local).AddTicks(7159), null, 2, true, false, true, false, true, true, null, 1200m, "204", 1, 1, 1 },
                    { 26, new DateTime(2025, 3, 11, 1, 57, 41, 712, DateTimeKind.Local).AddTicks(7159), null, 2, true, false, true, false, true, true, null, 1200m, "205", 1, 1, 1 },
                    { 27, new DateTime(2025, 3, 11, 1, 57, 41, 712, DateTimeKind.Local).AddTicks(7160), null, 2, true, false, true, false, true, true, null, 1200m, "206", 1, 1, 1 },
                    { 28, new DateTime(2025, 3, 11, 1, 57, 41, 712, DateTimeKind.Local).AddTicks(7160), null, 2, true, false, true, false, true, true, null, 1200m, "207", 1, 1, 1 },
                    { 29, new DateTime(2025, 3, 11, 1, 57, 41, 712, DateTimeKind.Local).AddTicks(7161), null, 2, true, false, true, false, true, true, null, 1200m, "208", 1, 1, 1 },
                    { 30, new DateTime(2025, 3, 11, 1, 57, 41, 712, DateTimeKind.Local).AddTicks(7161), null, 2, true, false, true, false, true, true, null, 1200m, "209", 1, 1, 1 },
                    { 31, new DateTime(2025, 3, 11, 1, 57, 41, 712, DateTimeKind.Local).AddTicks(7163), null, 2, true, false, true, true, true, true, null, 1800m, "210", 1, 2, 1 },
                    { 32, new DateTime(2025, 3, 11, 1, 57, 41, 712, DateTimeKind.Local).AddTicks(7164), null, 2, true, false, true, true, true, true, null, 1800m, "211", 1, 2, 1 },
                    { 33, new DateTime(2025, 3, 11, 1, 57, 41, 712, DateTimeKind.Local).AddTicks(7165), null, 2, true, false, true, true, true, true, null, 1800m, "212", 1, 2, 1 },
                    { 34, new DateTime(2025, 3, 11, 1, 57, 41, 712, DateTimeKind.Local).AddTicks(7166), null, 2, true, false, true, true, true, true, null, 1800m, "213", 1, 2, 1 },
                    { 35, new DateTime(2025, 3, 11, 1, 57, 41, 712, DateTimeKind.Local).AddTicks(7167), null, 2, true, false, true, true, true, true, null, 1800m, "214", 1, 2, 1 },
                    { 36, new DateTime(2025, 3, 11, 1, 57, 41, 712, DateTimeKind.Local).AddTicks(7167), null, 2, true, false, true, true, true, true, null, 1800m, "215", 1, 2, 1 },
                    { 37, new DateTime(2025, 3, 11, 1, 57, 41, 712, DateTimeKind.Local).AddTicks(7168), null, 2, true, false, true, true, true, true, null, 1800m, "216", 1, 2, 1 },
                    { 38, new DateTime(2025, 3, 11, 1, 57, 41, 712, DateTimeKind.Local).AddTicks(7169), null, 2, true, false, true, true, true, true, null, 1800m, "217", 1, 2, 1 },
                    { 39, new DateTime(2025, 3, 11, 1, 57, 41, 712, DateTimeKind.Local).AddTicks(7197), null, 2, true, false, true, true, true, true, null, 1800m, "218", 1, 2, 1 },
                    { 40, new DateTime(2025, 3, 11, 1, 57, 41, 712, DateTimeKind.Local).AddTicks(7198), null, 2, true, false, true, true, true, true, null, 1800m, "219", 1, 2, 1 },
                    { 41, new DateTime(2025, 3, 11, 1, 57, 41, 712, DateTimeKind.Local).AddTicks(7201), null, 3, true, true, true, true, true, true, null, 2200m, "300", 1, 2, 1 },
                    { 42, new DateTime(2025, 3, 11, 1, 57, 41, 712, DateTimeKind.Local).AddTicks(7202), null, 3, true, true, true, true, true, true, null, 2200m, "301", 1, 2, 1 },
                    { 43, new DateTime(2025, 3, 11, 1, 57, 41, 712, DateTimeKind.Local).AddTicks(7203), null, 3, true, true, true, true, true, true, null, 2200m, "302", 1, 2, 1 },
                    { 44, new DateTime(2025, 3, 11, 1, 57, 41, 712, DateTimeKind.Local).AddTicks(7204), null, 3, true, true, true, true, true, true, null, 2200m, "303", 1, 2, 1 },
                    { 45, new DateTime(2025, 3, 11, 1, 57, 41, 712, DateTimeKind.Local).AddTicks(7205), null, 3, true, true, true, true, true, true, null, 2200m, "304", 1, 2, 1 },
                    { 46, new DateTime(2025, 3, 11, 1, 57, 41, 712, DateTimeKind.Local).AddTicks(7205), null, 3, true, true, true, true, true, true, null, 2200m, "305", 1, 2, 1 },
                    { 47, new DateTime(2025, 3, 11, 1, 57, 41, 712, DateTimeKind.Local).AddTicks(7206), null, 3, true, true, true, true, true, true, null, 2200m, "306", 1, 2, 1 },
                    { 48, new DateTime(2025, 3, 11, 1, 57, 41, 712, DateTimeKind.Local).AddTicks(7207), null, 3, true, true, true, true, true, true, null, 2200m, "307", 1, 2, 1 },
                    { 49, new DateTime(2025, 3, 11, 1, 57, 41, 712, DateTimeKind.Local).AddTicks(7207), null, 3, true, true, true, true, true, true, null, 2200m, "308", 1, 2, 1 },
                    { 50, new DateTime(2025, 3, 11, 1, 57, 41, 712, DateTimeKind.Local).AddTicks(7208), null, 3, true, true, true, true, true, true, null, 2200m, "309", 1, 2, 1 },
                    { 51, new DateTime(2025, 3, 11, 1, 57, 41, 712, DateTimeKind.Local).AddTicks(7210), null, 3, true, true, true, true, true, true, null, 2500m, "310", 1, 3, 1 },
                    { 52, new DateTime(2025, 3, 11, 1, 57, 41, 712, DateTimeKind.Local).AddTicks(7211), null, 3, true, true, true, true, true, true, null, 2500m, "311", 1, 3, 1 },
                    { 53, new DateTime(2025, 3, 11, 1, 57, 41, 712, DateTimeKind.Local).AddTicks(7211), null, 3, true, true, true, true, true, true, null, 2500m, "312", 1, 3, 1 },
                    { 54, new DateTime(2025, 3, 11, 1, 57, 41, 712, DateTimeKind.Local).AddTicks(7212), null, 3, true, true, true, true, true, true, null, 2500m, "313", 1, 3, 1 },
                    { 55, new DateTime(2025, 3, 11, 1, 57, 41, 712, DateTimeKind.Local).AddTicks(7213), null, 3, true, true, true, true, true, true, null, 2500m, "314", 1, 3, 1 },
                    { 56, new DateTime(2025, 3, 11, 1, 57, 41, 712, DateTimeKind.Local).AddTicks(7213), null, 3, true, true, true, true, true, true, null, 2500m, "315", 1, 3, 1 },
                    { 57, new DateTime(2025, 3, 11, 1, 57, 41, 712, DateTimeKind.Local).AddTicks(7214), null, 3, true, true, true, true, true, true, null, 2500m, "316", 1, 3, 1 },
                    { 58, new DateTime(2025, 3, 11, 1, 57, 41, 712, DateTimeKind.Local).AddTicks(7214), null, 3, true, true, true, true, true, true, null, 2500m, "317", 1, 3, 1 },
                    { 59, new DateTime(2025, 3, 11, 1, 57, 41, 712, DateTimeKind.Local).AddTicks(7215), null, 3, true, true, true, true, true, true, null, 2500m, "318", 1, 3, 1 },
                    { 60, new DateTime(2025, 3, 11, 1, 57, 41, 712, DateTimeKind.Local).AddTicks(7216), null, 3, true, true, true, true, true, true, null, 2500m, "319", 1, 3, 1 },
                    { 61, new DateTime(2025, 3, 11, 1, 57, 41, 712, DateTimeKind.Local).AddTicks(7217), null, 4, true, true, true, true, true, true, null, 2800m, "400", 1, 2, 1 },
                    { 62, new DateTime(2025, 3, 11, 1, 57, 41, 712, DateTimeKind.Local).AddTicks(7218), null, 4, true, true, true, true, true, true, null, 2800m, "401", 1, 2, 1 },
                    { 63, new DateTime(2025, 3, 11, 1, 57, 41, 712, DateTimeKind.Local).AddTicks(7219), null, 4, true, true, true, true, true, true, null, 2800m, "402", 1, 2, 1 },
                    { 64, new DateTime(2025, 3, 11, 1, 57, 41, 712, DateTimeKind.Local).AddTicks(7219), null, 4, true, true, true, true, true, true, null, 2800m, "403", 1, 2, 1 },
                    { 65, new DateTime(2025, 3, 11, 1, 57, 41, 712, DateTimeKind.Local).AddTicks(7220), null, 4, true, true, true, true, true, true, null, 2800m, "404", 1, 2, 1 },
                    { 66, new DateTime(2025, 3, 11, 1, 57, 41, 712, DateTimeKind.Local).AddTicks(7221), null, 4, true, true, true, true, true, true, null, 2800m, "405", 1, 2, 1 },
                    { 67, new DateTime(2025, 3, 11, 1, 57, 41, 712, DateTimeKind.Local).AddTicks(7222), null, 4, true, true, true, true, true, true, null, 2800m, "406", 1, 2, 1 },
                    { 68, new DateTime(2025, 3, 11, 1, 57, 41, 712, DateTimeKind.Local).AddTicks(7223), null, 4, true, true, true, true, true, true, null, 2800m, "407", 1, 2, 1 },
                    { 69, new DateTime(2025, 3, 11, 1, 57, 41, 712, DateTimeKind.Local).AddTicks(7223), null, 4, true, true, true, true, true, true, null, 2800m, "408", 1, 2, 1 },
                    { 70, new DateTime(2025, 3, 11, 1, 57, 41, 712, DateTimeKind.Local).AddTicks(7224), null, 4, true, true, true, true, true, true, null, 2800m, "409", 1, 2, 1 },
                    { 71, new DateTime(2025, 3, 11, 1, 57, 41, 712, DateTimeKind.Local).AddTicks(7225), null, 4, true, true, true, true, true, true, null, 3500m, "410", 1, 4, 1 },
                    { 72, new DateTime(2025, 3, 11, 1, 57, 41, 712, DateTimeKind.Local).AddTicks(7226), null, 4, true, true, true, true, true, true, null, 3500m, "411", 1, 4, 1 },
                    { 73, new DateTime(2025, 3, 11, 1, 57, 41, 712, DateTimeKind.Local).AddTicks(7227), null, 4, true, true, true, true, true, true, null, 3500m, "412", 1, 4, 1 },
                    { 74, new DateTime(2025, 3, 11, 1, 57, 41, 712, DateTimeKind.Local).AddTicks(7228), null, 4, true, true, true, true, true, true, null, 3500m, "413", 1, 4, 1 },
                    { 75, new DateTime(2025, 3, 11, 1, 57, 41, 712, DateTimeKind.Local).AddTicks(7228), null, 4, true, true, true, true, true, true, null, 3500m, "414", 1, 4, 1 },
                    { 76, new DateTime(2025, 3, 11, 1, 57, 41, 712, DateTimeKind.Local).AddTicks(7229), null, 4, true, true, true, true, true, true, null, 3500m, "415", 1, 4, 1 },
                    { 77, new DateTime(2025, 3, 11, 1, 57, 41, 712, DateTimeKind.Local).AddTicks(7230), null, 4, true, true, true, true, true, true, null, 10000m, "417", 1, 5, 1 }
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
