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
                    { 1, "0a6daf66-9590-4920-83c7-5f05f7f1f629", "Admin", "ADMIN" },
                    { 2, "30f5ef65-56bf-440e-8be2-b17dea50544a", "Member", "MEMBER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ActivationCode", "ConcurrencyStamp", "CreatedDate", "DeletedDate", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "ModifiedDate", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Status", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { 1, 0, new Guid("00000000-0000-0000-0000-000000000000"), "85cd372f-b5cd-4792-b757-62384bc2f298", new DateTime(2025, 4, 14, 23, 37, 9, 959, DateTimeKind.Local).AddTicks(3509), null, "bilgehotel@email.com", true, false, null, null, "BILGEHOTEL@EMAIL.COM", "BILGEHOTEL", "AQAAAAIAAYagAAAAEByZeRMb5HOEYCkGnGtpPfUcqiuPRiJjsR1pUKE3aSUoNfhHeMwJQGpUjZSBoKx99Q==", null, false, "12e29abf-7f88-4a73-84a3-637eb0f3c2ff", 1, false, "bilgehotel" },
                    { 2, 0, new Guid("00000000-0000-0000-0000-000000000000"), "b90711d0-73b2-4a75-b141-b0703a85c9ae", new DateTime(2025, 4, 14, 23, 37, 9, 999, DateTimeKind.Local).AddTicks(1923), null, "testmember@email.com", true, false, null, null, "TESTMEMBER@EMAIL.COM", "TESTMEMBER", "AQAAAAIAAYagAAAAEN8Vy5+qD/+Sykdpnb8wifF3GCbQS+JTsNkbOzplO1H7c0zRjhU0ZW+7TEuzLd29Dw==", null, false, "d46957ae-eef9-4211-b2e3-f758c22872cd", 1, false, "testmember" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Address", "BirthDate", "CreatedDate", "DeletedDate", "FirstName", "HireDate", "LastName", "ModifiedDate", "PhoneNumber", "Position", "Salary", "Shift", "Status" },
                values: new object[,]
                {
                    { 1, "Bandak Sokak 06, Siirt, Kamboçya", new DateTime(1983, 11, 7, 0, 32, 57, 414, DateTimeKind.Local).AddTicks(2156), new DateTime(2025, 4, 14, 23, 37, 9, 921, DateTimeKind.Local).AddTicks(5089), null, "Aşıkbulmuş", new DateTime(2021, 1, 17, 10, 43, 41, 457, DateTimeKind.Local).AddTicks(7335), "Beşok", null, "+905993974566", "Resepsiyonist", 51515.96m, 1, 1 },
                    { 2, "Bayır Sokak 87b, Tokat, Libya", new DateTime(1987, 6, 28, 10, 4, 55, 443, DateTimeKind.Local).AddTicks(64), new DateTime(2025, 4, 14, 23, 37, 9, 921, DateTimeKind.Local).AddTicks(5156), null, "Adıkutlu", new DateTime(2014, 7, 18, 6, 11, 56, 68, DateTimeKind.Local).AddTicks(538), "Erdoğan", null, "+905118602208", "Resepsiyonist", 46168.78m, 2, 1 },
                    { 3, "Bandak Sokak 523, K.maraş, Laos", new DateTime(1989, 8, 10, 23, 14, 30, 711, DateTimeKind.Local).AddTicks(964), new DateTime(2025, 4, 14, 23, 37, 9, 921, DateTimeKind.Local).AddTicks(5237), null, "Çolpan", new DateTime(2017, 3, 10, 21, 44, 4, 382, DateTimeKind.Local).AddTicks(5335), "Uluhan", null, "+905014117950", "Resepsiyonist", 57348.26m, 2, 1 },
                    { 4, "Ergenekon Sokak   46, Bursa, Bulgaristan", new DateTime(1995, 2, 10, 11, 39, 31, 993, DateTimeKind.Local).AddTicks(1531), new DateTime(2025, 4, 14, 23, 37, 9, 921, DateTimeKind.Local).AddTicks(5308), null, "Arslanbörü", new DateTime(2016, 9, 19, 0, 11, 52, 210, DateTimeKind.Local).AddTicks(3247), "Kasapoğlu", null, "+905218014825", "Resepsiyonist", 44621.10m, 1, 1 },
                    { 5, "Dağınık Evler Sokak 041, Tunceli, Macaristan", new DateTime(1967, 7, 11, 19, 52, 36, 239, DateTimeKind.Local).AddTicks(9324), new DateTime(2025, 4, 14, 23, 37, 9, 921, DateTimeKind.Local).AddTicks(5357), null, "Akbudak", new DateTime(2014, 7, 13, 19, 22, 12, 585, DateTimeKind.Local).AddTicks(7791), "Durmaz", null, "+905127487619", "Resepsiyonist", 51546.79m, 3, 1 },
                    { 6, "Ali Çetinkaya Caddesi 05b, Hatay, Honduras", new DateTime(1985, 4, 1, 2, 16, 20, 725, DateTimeKind.Local).AddTicks(9659), new DateTime(2025, 4, 14, 23, 37, 9, 921, DateTimeKind.Local).AddTicks(5438), null, "Barçan", new DateTime(2016, 8, 25, 16, 24, 46, 106, DateTimeKind.Local).AddTicks(7028), "Günday", null, "+905016752219", "Resepsiyonist", 46990.85m, 3, 1 },
                    { 7, "Kaldırım Sokak 0, Isparta, Malta", new DateTime(1968, 3, 9, 6, 5, 7, 668, DateTimeKind.Local).AddTicks(6260), new DateTime(2025, 4, 14, 23, 37, 9, 921, DateTimeKind.Local).AddTicks(5519), null, "Gülemen", new DateTime(2021, 5, 7, 12, 35, 37, 238, DateTimeKind.Local).AddTicks(4017), "Demirbaş", null, "+905323156714", "Resepsiyonist", 59077.44m, 2, 1 },
                    { 8, "Sarıkaya Caddesi 6, Osmaniye, Kamboçya", new DateTime(2004, 9, 12, 14, 11, 15, 590, DateTimeKind.Local).AddTicks(514), new DateTime(2025, 4, 14, 23, 37, 9, 921, DateTimeKind.Local).AddTicks(5577), null, "Barçan", new DateTime(2016, 9, 15, 17, 42, 3, 670, DateTimeKind.Local).AddTicks(5818), "Ağaoğlu", null, "+905923926072", "Temizlik Görevlisi", 28013.60m, 2, 1 },
                    { 9, "İsmet Attila Caddesi 4, Kayseri, Tunus", new DateTime(1979, 3, 8, 17, 53, 15, 591, DateTimeKind.Local).AddTicks(4790), new DateTime(2025, 4, 14, 23, 37, 9, 921, DateTimeKind.Local).AddTicks(5649), null, "Aşantuğrul", new DateTime(2016, 4, 6, 20, 21, 39, 1, DateTimeKind.Local).AddTicks(9538), "Alyanak", null, "+905772882459", "Temizlik Görevlisi", 28270.29m, 2, 1 },
                    { 10, "Kekeçoğlu Sokak 68a, Balıkesir, Türkiye", new DateTime(1995, 12, 12, 3, 8, 16, 135, DateTimeKind.Local).AddTicks(4364), new DateTime(2025, 4, 14, 23, 37, 9, 921, DateTimeKind.Local).AddTicks(5720), null, "Alpturan", new DateTime(2019, 5, 26, 19, 6, 49, 691, DateTimeKind.Local).AddTicks(8952), "Sezek", null, "+905686917377", "Temizlik Görevlisi", 34066.61m, 2, 1 },
                    { 11, "Ergenekon Sokak   01a, Yozgat, Guadalup, Fransa", new DateTime(1994, 2, 9, 8, 31, 17, 612, DateTimeKind.Local).AddTicks(4979), new DateTime(2025, 4, 14, 23, 37, 9, 921, DateTimeKind.Local).AddTicks(5769), null, "Buyruç", new DateTime(2017, 11, 17, 6, 46, 52, 709, DateTimeKind.Local).AddTicks(3245), "Evliyaoğlu", null, "+905496982952", "Temizlik Görevlisi", 33096.93m, 1, 1 },
                    { 12, "Dar Sokak 82b, Bilecik, İsrail", new DateTime(2006, 6, 10, 18, 30, 46, 251, DateTimeKind.Local).AddTicks(5572), new DateTime(2025, 4, 14, 23, 37, 9, 921, DateTimeKind.Local).AddTicks(5839), null, "Bilgekutluk", new DateTime(2021, 5, 4, 11, 29, 41, 158, DateTimeKind.Local).AddTicks(6693), "Kunt", null, "+905357597715", "Temizlik Görevlisi", 33076.86m, 1, 1 },
                    { 13, "Atatürk Bulvarı 48, Nevşehir, Fiji", new DateTime(1991, 3, 15, 9, 8, 35, 868, DateTimeKind.Local).AddTicks(2983), new DateTime(2025, 4, 14, 23, 37, 9, 921, DateTimeKind.Local).AddTicks(5909), null, "Gökçe", new DateTime(2018, 10, 7, 3, 49, 3, 75, DateTimeKind.Local).AddTicks(3714), "Babacan", null, "+905402771933", "Temizlik Görevlisi", 34859.01m, 2, 1 },
                    { 14, "Kerimoğlu Sokak 86a, Çanakkale, Nikaragua", new DateTime(2001, 11, 3, 18, 48, 45, 865, DateTimeKind.Local).AddTicks(4422), new DateTime(2025, 4, 14, 23, 37, 9, 921, DateTimeKind.Local).AddTicks(5954), null, "Beğdilli", new DateTime(2021, 4, 5, 19, 38, 12, 235, DateTimeKind.Local).AddTicks(6717), "Karaböcek", null, "+905910410617", "Temizlik Görevlisi", 29875.21m, 2, 1 },
                    { 15, "Bahçe Sokak 99b, Ardahan, Dominik Cumhuriyeti", new DateTime(1969, 12, 6, 6, 6, 27, 284, DateTimeKind.Local).AddTicks(5039), new DateTime(2025, 4, 14, 23, 37, 9, 921, DateTimeKind.Local).AddTicks(6028), null, "Argu", new DateTime(2018, 10, 22, 4, 59, 12, 238, DateTimeKind.Local).AddTicks(8706), "Akaydın", null, "+905494421659", "Temizlik Görevlisi", 26065.48m, 2, 1 },
                    { 16, "Oğuzhan Sokak 16a, Manisa, El Salvador", new DateTime(1997, 9, 11, 12, 30, 40, 552, DateTimeKind.Local).AddTicks(4033), new DateTime(2025, 4, 14, 23, 37, 9, 921, DateTimeKind.Local).AddTicks(6073), null, "Kayça", new DateTime(2017, 1, 20, 0, 43, 39, 13, DateTimeKind.Local).AddTicks(3961), "Akar ", null, "+905427639455", "Temizlik Görevlisi", 33362.19m, 1, 1 },
                    { 17, "Okul Sokak 87a, Kilis, Bolivya", new DateTime(1992, 8, 1, 6, 44, 9, 974, DateTimeKind.Local).AddTicks(9998), new DateTime(2025, 4, 14, 23, 37, 9, 921, DateTimeKind.Local).AddTicks(6130), null, "Bayındır", new DateTime(2022, 4, 10, 4, 22, 43, 141, DateTimeKind.Local).AddTicks(3412), "Poçan", null, "+905763758507", "Temizlik Görevlisi", 25480.86m, 2, 1 },
                    { 18, "İsmet Paşa Caddesi 88c, Adıyaman, Bosna Hersek", new DateTime(1978, 3, 9, 12, 49, 33, 325, DateTimeKind.Local).AddTicks(306), new DateTime(2025, 4, 14, 23, 37, 9, 921, DateTimeKind.Local).AddTicks(6211), null, "Aydarkağan", new DateTime(2018, 12, 5, 21, 43, 6, 573, DateTimeKind.Local).AddTicks(3781), "Çatalbaş", null, "+905068089945", "Temizlik Görevlisi", 29079.37m, 2, 1 },
                    { 19, "Bayır Sokak 3, Van, Çad", new DateTime(1990, 1, 22, 3, 50, 55, 120, DateTimeKind.Local).AddTicks(3338), new DateTime(2025, 4, 14, 23, 37, 9, 921, DateTimeKind.Local).AddTicks(6253), null, "Bünül", new DateTime(2015, 5, 14, 8, 54, 26, 254, DateTimeKind.Local).AddTicks(8050), "Kahveci", null, "+905740196131", "Aşçı", 114733.68m, 1, 1 },
                    { 20, "Ülkü Sokak 57c, Bingöl, Peru", new DateTime(1997, 11, 12, 5, 11, 54, 704, DateTimeKind.Local).AddTicks(4262), new DateTime(2025, 4, 14, 23, 37, 9, 921, DateTimeKind.Local).AddTicks(6331), null, "Bongulboğa", new DateTime(2017, 12, 13, 5, 5, 52, 47, DateTimeKind.Local).AddTicks(818), "Abadan", null, "+905221056956", "Aşçı", 106893.52m, 2, 1 },
                    { 21, "Nalbant Sokak 77c, Gaziantep, Gine", new DateTime(2004, 3, 2, 5, 10, 42, 752, DateTimeKind.Local).AddTicks(5720), new DateTime(2025, 4, 14, 23, 37, 9, 921, DateTimeKind.Local).AddTicks(6403), null, "Aydoğmuş", new DateTime(2020, 9, 21, 12, 36, 29, 438, DateTimeKind.Local).AddTicks(5855), "Ertürk", null, "+905424078377", "Aşçı", 112639.64m, 1, 1 },
                    { 22, "İsmet Paşa Caddesi 9, Çankırı, Montserrat", new DateTime(2005, 9, 23, 18, 3, 8, 817, DateTimeKind.Local).AddTicks(9298), new DateTime(2025, 4, 14, 23, 37, 9, 921, DateTimeKind.Local).AddTicks(6448), null, "Açığ", new DateTime(2018, 2, 1, 7, 32, 3, 113, DateTimeKind.Local).AddTicks(3882), "Aykaç", null, "+905718824073", "Aşçı", 119719.13m, 2, 1 },
                    { 23, "Sarıkaya Caddesi 13a, Edirne, Pakistan", new DateTime(1988, 7, 28, 10, 42, 9, 637, DateTimeKind.Local).AddTicks(729), new DateTime(2025, 4, 14, 23, 37, 9, 921, DateTimeKind.Local).AddTicks(6516), null, "Alpay", new DateTime(2023, 5, 30, 23, 7, 57, 157, DateTimeKind.Local).AddTicks(6402), "Tunaboylu", null, "+905231691725", "Aşçı", 119454.21m, 1, 1 },
                    { 24, "Gül Sokak 70c, Eskişehir, Anguilla, İngiltere", new DateTime(1999, 2, 7, 7, 39, 0, 854, DateTimeKind.Local).AddTicks(4147), new DateTime(2025, 4, 14, 23, 37, 9, 921, DateTimeKind.Local).AddTicks(6584), null, "Adıkutlutaş", new DateTime(2017, 11, 8, 7, 45, 32, 859, DateTimeKind.Local).AddTicks(5250), "Nalbantoğlu", null, "+905119423626", "Aşçı", 113654.68m, 1, 1 },
                    { 25, "Dağınık Evler Sokak 38c, Samsun, Özbekistan", new DateTime(1993, 12, 5, 2, 15, 43, 939, DateTimeKind.Local).AddTicks(9345), new DateTime(2025, 4, 14, 23, 37, 9, 921, DateTimeKind.Local).AddTicks(6633), null, "Atalmış", new DateTime(2023, 2, 28, 10, 29, 59, 538, DateTimeKind.Local).AddTicks(7581), "Tekand", null, "+905845420057", "Aşçı", 102978.11m, 1, 1 },
                    { 26, "Afyon Kaya Sokak 66a, Adıyaman, Kamboçya", new DateTime(2000, 5, 7, 5, 1, 43, 368, DateTimeKind.Local).AddTicks(4273), new DateTime(2025, 4, 14, 23, 37, 9, 921, DateTimeKind.Local).AddTicks(6700), null, "Çokramayul", new DateTime(2015, 5, 23, 6, 49, 23, 632, DateTimeKind.Local).AddTicks(334), "Saygıner", null, "+905563517811", "Aşçı", 108994.14m, 1, 1 },
                    { 27, "Lütfi Karadirek Caddesi 354, Antalya, Finlandiya", new DateTime(2006, 5, 30, 20, 46, 51, 187, DateTimeKind.Local).AddTicks(3068), new DateTime(2025, 4, 14, 23, 37, 9, 921, DateTimeKind.Local).AddTicks(6769), null, "Asartegin", new DateTime(2021, 2, 21, 15, 55, 44, 887, DateTimeKind.Local).AddTicks(6135), "Dalkıran", null, "+905551434322", "Aşçı", 112969.86m, 2, 1 },
                    { 28, "İsmet Attila Caddesi 06, Aksaray, Kamboçya", new DateTime(1968, 12, 1, 15, 23, 34, 759, DateTimeKind.Local).AddTicks(919), new DateTime(2025, 4, 14, 23, 37, 9, 921, DateTimeKind.Local).AddTicks(6812), null, "Barımtay", new DateTime(2017, 4, 30, 3, 6, 30, 662, DateTimeKind.Local).AddTicks(333), "Yalçın", null, "+905980335963", "Aşçı", 109094.68m, 2, 1 },
                    { 29, "Kaldırım Sokak 355, İzmir, Fildişi Sahili", new DateTime(1988, 10, 23, 6, 49, 21, 816, DateTimeKind.Local).AddTicks(5990), new DateTime(2025, 4, 14, 23, 37, 9, 921, DateTimeKind.Local).AddTicks(6874), null, "Bargan", new DateTime(2019, 11, 22, 17, 27, 2, 31, DateTimeKind.Local).AddTicks(1352), "Demirbaş", null, "+905556204664", "Aşçı", 106032.16m, 1, 1 },
                    { 30, "Saygılı Sokak 227, K.maraş, Kongo Demokratik Cumhuriyeti", new DateTime(1968, 3, 28, 15, 41, 23, 679, DateTimeKind.Local).AddTicks(5805), new DateTime(2025, 4, 14, 23, 37, 9, 921, DateTimeKind.Local).AddTicks(6954), null, "Ilaçın", new DateTime(2021, 3, 25, 14, 6, 4, 454, DateTimeKind.Local).AddTicks(7118), "Yılmazer", null, "+905163703784", "Garson", 71156.32m, 2, 1 },
                    { 31, "Fatih Sokak  63a, Samsun, Mozambik", new DateTime(1997, 11, 23, 2, 39, 42, 263, DateTimeKind.Local).AddTicks(2300), new DateTime(2025, 4, 14, 23, 37, 9, 921, DateTimeKind.Local).AddTicks(6999), null, "Bıtrı", new DateTime(2020, 7, 26, 18, 8, 42, 789, DateTimeKind.Local).AddTicks(801), "Tokgöz", null, "+905079275911", "Garson", 81328.28m, 2, 1 },
                    { 32, "Barış Sokak 04b, Kırşehir, Vietnam", new DateTime(1982, 11, 1, 9, 39, 53, 656, DateTimeKind.Local).AddTicks(7938), new DateTime(2025, 4, 14, 23, 37, 9, 921, DateTimeKind.Local).AddTicks(7072), null, "Baran", new DateTime(2014, 9, 7, 0, 14, 55, 823, DateTimeKind.Local).AddTicks(1258), "Karaer", null, "+905312185573", "Garson", 87791.20m, 1, 1 },
                    { 33, "Atatürk Bulvarı 26, Kilis, Haiti", new DateTime(1975, 2, 12, 20, 27, 28, 208, DateTimeKind.Local).AddTicks(4450), new DateTime(2025, 4, 14, 23, 37, 9, 921, DateTimeKind.Local).AddTicks(7113), null, "Çabdar", new DateTime(2015, 4, 27, 23, 53, 21, 424, DateTimeKind.Local).AddTicks(8143), "Mertoğlu", null, "+905157705115", "Garson", 81457.21m, 1, 1 },
                    { 34, "Fatih Sokak  390, Çorum, Antigua ve Barbuda", new DateTime(1997, 10, 26, 23, 13, 59, 609, DateTimeKind.Local).AddTicks(5194), new DateTime(2025, 4, 14, 23, 37, 9, 921, DateTimeKind.Local).AddTicks(7183), null, "Bunsuz", new DateTime(2016, 6, 20, 5, 58, 57, 139, DateTimeKind.Local).AddTicks(368), "Kıraç ", null, "+905934087409", "Garson", 80215.98m, 1, 1 },
                    { 35, "Fatih Sokak  23a, Elazığ, Gambiya", new DateTime(1986, 5, 21, 11, 44, 28, 939, DateTimeKind.Local).AddTicks(569), new DateTime(2025, 4, 14, 23, 37, 9, 921, DateTimeKind.Local).AddTicks(7249), null, "İnci", new DateTime(2018, 1, 17, 21, 37, 23, 64, DateTimeKind.Local).AddTicks(3433), "Kulaksızoğlu", null, "+905481623853", "Garson", 80856.25m, 1, 1 },
                    { 36, "Kocatepe Caddesi 23, Ardahan, Gabon", new DateTime(1977, 9, 27, 3, 55, 55, 802, DateTimeKind.Local).AddTicks(1426), new DateTime(2025, 4, 14, 23, 37, 9, 921, DateTimeKind.Local).AddTicks(7291), null, "Aldemir", new DateTime(2022, 6, 14, 13, 44, 10, 289, DateTimeKind.Local).AddTicks(5291), "Kahveci", null, "+905765648872", "Garson", 96166.08m, 2, 1 },
                    { 37, "Afyon Kaya Sokak 83, Kayseri, Angola", new DateTime(1971, 8, 1, 17, 10, 57, 386, DateTimeKind.Local).AddTicks(8638), new DateTime(2025, 4, 14, 23, 37, 9, 921, DateTimeKind.Local).AddTicks(7359), null, "Aykan", new DateTime(2022, 4, 11, 11, 19, 22, 805, DateTimeKind.Local).AddTicks(426), "Kumcuoğlu", null, "+905676886100", "Garson", 79614.34m, 1, 1 },
                    { 38, "Okul Sokak 33b, Rize, Uganda", new DateTime(1976, 7, 15, 14, 49, 25, 552, DateTimeKind.Local).AddTicks(624), new DateTime(2025, 4, 14, 23, 37, 9, 921, DateTimeKind.Local).AddTicks(7424), null, "Aprançur", new DateTime(2022, 7, 12, 21, 28, 30, 997, DateTimeKind.Local).AddTicks(272), "Akay", null, "+905617768783", "Garson", 98723.88m, 1, 1 },
                    { 39, "Barış Sokak 57a, Sivas, Tunus", new DateTime(1997, 8, 29, 22, 8, 54, 732, DateTimeKind.Local).AddTicks(1383), new DateTime(2025, 4, 14, 23, 37, 9, 921, DateTimeKind.Local).AddTicks(7466), null, "Arbuz", new DateTime(2020, 3, 6, 10, 21, 48, 542, DateTimeKind.Local).AddTicks(7078), "Numanoğlu", null, "+905068258534", "Garson", 94443.43m, 1, 1 },
                    { 40, "Atatürk Bulvarı 50, Siirt, Orta Afrika Cumhuriyeti", new DateTime(2004, 11, 24, 1, 45, 12, 850, DateTimeKind.Local).AddTicks(3693), new DateTime(2025, 4, 14, 23, 37, 9, 921, DateTimeKind.Local).AddTicks(7531), null, "Esenbike", new DateTime(2014, 12, 28, 8, 37, 46, 628, DateTimeKind.Local).AddTicks(534), "Örge", null, "+905864041960", "Garson", 81476.81m, 1, 1 },
                    { 41, "Atatürk Bulvarı 530, Tokat, İran", new DateTime(1998, 11, 4, 20, 53, 36, 358, DateTimeKind.Local).AddTicks(9229), new DateTime(2025, 4, 14, 23, 37, 9, 921, DateTimeKind.Local).AddTicks(7594), null, "Böge", new DateTime(2014, 5, 7, 15, 13, 22, 839, DateTimeKind.Local).AddTicks(1537), "Çetiner", null, "+905656941011", "Garson", 83200.45m, 1, 1 },
                    { 42, "Kekeçoğlu Sokak 09b, Diyarbakır, Rusya Federasyonu", new DateTime(1995, 7, 19, 5, 57, 47, 167, DateTimeKind.Local).AddTicks(2236), new DateTime(2025, 4, 14, 23, 37, 9, 921, DateTimeKind.Local).AddTicks(7639), null, "Erinç", new DateTime(2019, 8, 31, 14, 1, 3, 118, DateTimeKind.Local).AddTicks(2211), "Arıcan", null, "+905694592871", "Garson", 85367.57m, 1, 1 },
                    { 43, "Ali Çetinkaya Caddesi 22b, Malatya, Fas", new DateTime(2007, 1, 30, 13, 20, 33, 641, DateTimeKind.Local).AddTicks(3843), new DateTime(2025, 4, 14, 23, 37, 9, 921, DateTimeKind.Local).AddTicks(7715), null, "Akboğa", new DateTime(2015, 1, 23, 23, 13, 24, 745, DateTimeKind.Local).AddTicks(7906), "Ayaydın", null, "+905024075213", "Elektrikçi", 126268.03m, 2, 1 },
                    { 44, "Dar Sokak 58, Aksaray, Mali", new DateTime(2006, 2, 24, 15, 45, 3, 986, DateTimeKind.Local).AddTicks(927), new DateTime(2025, 4, 14, 23, 37, 9, 921, DateTimeKind.Local).AddTicks(7790), null, "Çağrıbeğ", new DateTime(2016, 11, 15, 6, 5, 19, 803, DateTimeKind.Local).AddTicks(8445), "Kuday", null, "+905973745172", "IT Sorumlusu", 184589.15m, 3, 1 }
                });

            migrationBuilder.InsertData(
                table: "ExtraServices",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Description", "ModifiedDate", "Name", "Price", "Status" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 4, 14, 23, 37, 9, 999, DateTimeKind.Local).AddTicks(2196), null, "Günlük sınırsız spa kullanımı.", null, "Spa Kullanımı", 3000m, 1 },
                    { 2, new DateTime(2025, 4, 14, 23, 37, 9, 999, DateTimeKind.Local).AddTicks(2198), null, "24 saat oda servisi. Tüm yemek siparişleri dahildir.", null, "Oda Servisi", 1500m, 1 },
                    { 3, new DateTime(2025, 4, 14, 23, 37, 9, 999, DateTimeKind.Local).AddTicks(2199), null, "Minibardaki içecekler ve atıştırmalıklar dahil.", null, "Minibar Kullanımı", 1000m, 1 },
                    { 4, new DateTime(2025, 4, 14, 23, 37, 9, 999, DateTimeKind.Local).AddTicks(2200), null, "Gidiş-dönüş özel araç transferi.", null, "Havalimanı Transferi", 5000m, 1 },
                    { 5, new DateTime(2025, 4, 14, 23, 37, 9, 999, DateTimeKind.Local).AddTicks(2202), null, "Konaklama süresince ücretsiz çamaşır ve kuru temizleme hizmeti.", null, "Çamaşırhane Hizmeti", 500m, 1 },
                    { 6, new DateTime(2025, 4, 14, 23, 37, 9, 999, DateTimeKind.Local).AddTicks(2209), null, "Ekstra günlük temizlik ve hijyen paketi.", null, "Günlük Oda Temizliği", 500m, 1 },
                    { 7, new DateTime(2025, 4, 14, 23, 37, 9, 999, DateTimeKind.Local).AddTicks(2210), null, "Özel şezlong ve plaj hizmetleri.", null, "Özel Plaj Alanı", 7500m, 1 }
                });

            migrationBuilder.InsertData(
                table: "Packages",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Description", "ModifiedDate", "Name", "PriceMultiplier", "Status" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 4, 14, 23, 37, 9, 999, DateTimeKind.Local).AddTicks(2157), null, "Kahvaltı, öğle ve akşam yemeği dahil.", null, "Tam Pansiyon", 1.2m, 1 },
                    { 2, new DateTime(2025, 4, 14, 23, 37, 9, 999, DateTimeKind.Local).AddTicks(2159), null, "Tüm yemekler, alkollü-alkolsüz içecekler ve otelin sunduğu belirli hizmetler dahil.", null, "Her Şey Dahil", 1.5m, 1 }
                });

            migrationBuilder.InsertData(
                table: "RoomTypes",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Description", "ModifiedDate", "Name", "Status" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 4, 14, 23, 37, 9, 919, DateTimeKind.Local).AddTicks(8371), null, "1 adet tek kişilik yatak. Balkon ve minibar bulunmaz. Klima, TV, saç kurutma makinesi ve WiFi mevcuttur.", null, "Tek Kişilik", 1 },
                    { 2, new DateTime(2025, 4, 14, 23, 37, 9, 919, DateTimeKind.Local).AddTicks(8381), null, "1 adet büyük (duble) yatak. Klima, TV, saç kurutma makinesi ve WiFi mevcuttur.", null, "Çift Kişilik (Duble)", 1 },
                    { 3, new DateTime(2025, 4, 14, 23, 37, 9, 919, DateTimeKind.Local).AddTicks(8382), null, "2 adet tek kişilik yatak. Klima, TV, saç kurutma makinesi ve WiFi mevcuttur.", null, "Çift Kişilik (Tek Kişilik 2 Yataklı)", 1 },
                    { 4, new DateTime(2025, 4, 14, 23, 37, 9, 919, DateTimeKind.Local).AddTicks(8384), null, "3 adet tek kişilik yatak.  Klima, TV, saç kurutma makinesi ve WiFi mevcuttur.", null, "Üç Kişilik (Tek Kişilik 3 Yataklı)", 1 },
                    { 5, new DateTime(2025, 4, 14, 23, 37, 9, 919, DateTimeKind.Local).AddTicks(8385), null, "Bir tek bir duble yatak.  Klima, TV, saç kurutma makinesi ve WiFi mevcuttur.", null, "Üç Kişilik (1 Tek, 1 Duble Yataklı)", 1 },
                    { 6, new DateTime(2025, 4, 14, 23, 37, 9, 919, DateTimeKind.Local).AddTicks(8387), null, "1 adet büyük (duble) yatak + 2 adet tek kişilik yatak. Klima, TV, saç kurutma makinesi ve WiFi mevcuttur.", null, "Dört Kişilik", 1 },
                    { 7, new DateTime(2025, 4, 14, 23, 37, 9, 919, DateTimeKind.Local).AddTicks(8388), null, "Geniş ve lüks oda. Özel oturma alanı, büyük yatak, balkon, minibar, özel banyo ve lüks hizmetler. Klima, TV, saç kurutma makinesi, WiFi ve özel hizmetler mevcuttur.", null, "Kral Dairesi", 1 }
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
                    { 1, new DateTime(2025, 4, 14, 23, 37, 9, 919, DateTimeKind.Local).AddTicks(8516), null, 1, true, false, true, false, true, true, null, 1000m, "100", 1, 1, 1 },
                    { 2, new DateTime(2025, 4, 14, 23, 37, 9, 919, DateTimeKind.Local).AddTicks(8519), null, 1, true, false, true, false, true, true, null, 1000m, "101", 1, 1, 1 },
                    { 3, new DateTime(2025, 4, 14, 23, 37, 9, 919, DateTimeKind.Local).AddTicks(8520), null, 1, true, false, true, false, true, true, null, 1000m, "102", 1, 1, 1 },
                    { 4, new DateTime(2025, 4, 14, 23, 37, 9, 919, DateTimeKind.Local).AddTicks(8521), null, 1, true, false, true, false, true, true, null, 1000m, "103", 1, 1, 1 },
                    { 5, new DateTime(2025, 4, 14, 23, 37, 9, 919, DateTimeKind.Local).AddTicks(8522), null, 1, true, false, true, false, true, true, null, 1000m, "104", 1, 1, 1 },
                    { 6, new DateTime(2025, 4, 14, 23, 37, 9, 919, DateTimeKind.Local).AddTicks(8523), null, 1, true, false, true, false, true, true, null, 1000m, "105", 1, 1, 1 },
                    { 7, new DateTime(2025, 4, 14, 23, 37, 9, 919, DateTimeKind.Local).AddTicks(8524), null, 1, true, false, true, false, true, true, null, 1000m, "106", 1, 1, 1 },
                    { 8, new DateTime(2025, 4, 14, 23, 37, 9, 919, DateTimeKind.Local).AddTicks(8525), null, 1, true, false, true, false, true, true, null, 1000m, "107", 1, 1, 1 },
                    { 9, new DateTime(2025, 4, 14, 23, 37, 9, 919, DateTimeKind.Local).AddTicks(8526), null, 1, true, false, true, false, true, true, null, 1000m, "108", 1, 1, 1 },
                    { 10, new DateTime(2025, 4, 14, 23, 37, 9, 919, DateTimeKind.Local).AddTicks(8527), null, 1, true, false, true, false, true, true, null, 1000m, "109", 1, 1, 1 },
                    { 11, new DateTime(2025, 4, 14, 23, 37, 9, 919, DateTimeKind.Local).AddTicks(8529), null, 1, true, false, true, false, true, true, null, 1500m, "110", 1, 4, 1 },
                    { 12, new DateTime(2025, 4, 14, 23, 37, 9, 919, DateTimeKind.Local).AddTicks(8530), null, 1, true, false, true, false, true, true, null, 1500m, "111", 1, 4, 1 },
                    { 13, new DateTime(2025, 4, 14, 23, 37, 9, 919, DateTimeKind.Local).AddTicks(8531), null, 1, true, false, true, false, true, true, null, 1500m, "112", 1, 4, 1 },
                    { 14, new DateTime(2025, 4, 14, 23, 37, 9, 919, DateTimeKind.Local).AddTicks(8532), null, 1, true, false, true, false, true, true, null, 1500m, "113", 1, 4, 1 },
                    { 15, new DateTime(2025, 4, 14, 23, 37, 9, 919, DateTimeKind.Local).AddTicks(8532), null, 1, true, false, true, false, true, true, null, 1500m, "114", 1, 4, 1 },
                    { 16, new DateTime(2025, 4, 14, 23, 37, 9, 919, DateTimeKind.Local).AddTicks(8533), null, 1, true, false, true, false, true, true, null, 1500m, "115", 1, 4, 1 },
                    { 17, new DateTime(2025, 4, 14, 23, 37, 9, 919, DateTimeKind.Local).AddTicks(8533), null, 1, true, false, true, false, true, true, null, 1500m, "116", 1, 4, 1 },
                    { 18, new DateTime(2025, 4, 14, 23, 37, 9, 919, DateTimeKind.Local).AddTicks(8535), null, 1, true, false, true, false, true, true, null, 1500m, "117", 1, 4, 1 },
                    { 19, new DateTime(2025, 4, 14, 23, 37, 9, 919, DateTimeKind.Local).AddTicks(8535), null, 1, true, false, true, false, true, true, null, 1500m, "118", 1, 4, 1 },
                    { 20, new DateTime(2025, 4, 14, 23, 37, 9, 919, DateTimeKind.Local).AddTicks(8536), null, 1, true, false, true, false, true, true, null, 1500m, "119", 1, 4, 1 },
                    { 21, new DateTime(2025, 4, 14, 23, 37, 9, 919, DateTimeKind.Local).AddTicks(8538), null, 2, true, false, true, false, true, true, null, 1200m, "200", 1, 1, 1 },
                    { 22, new DateTime(2025, 4, 14, 23, 37, 9, 919, DateTimeKind.Local).AddTicks(8539), null, 2, true, false, true, false, true, true, null, 1200m, "201", 1, 1, 1 },
                    { 23, new DateTime(2025, 4, 14, 23, 37, 9, 919, DateTimeKind.Local).AddTicks(8539), null, 2, true, false, true, false, true, true, null, 1200m, "202", 1, 1, 1 },
                    { 24, new DateTime(2025, 4, 14, 23, 37, 9, 919, DateTimeKind.Local).AddTicks(8540), null, 2, true, false, true, false, true, true, null, 1200m, "203", 1, 1, 1 },
                    { 25, new DateTime(2025, 4, 14, 23, 37, 9, 919, DateTimeKind.Local).AddTicks(8540), null, 2, true, false, true, false, true, true, null, 1200m, "204", 1, 1, 1 },
                    { 26, new DateTime(2025, 4, 14, 23, 37, 9, 919, DateTimeKind.Local).AddTicks(8541), null, 2, true, false, true, false, true, true, null, 1200m, "205", 1, 1, 1 },
                    { 27, new DateTime(2025, 4, 14, 23, 37, 9, 919, DateTimeKind.Local).AddTicks(8541), null, 2, true, false, true, false, true, true, null, 1200m, "206", 1, 1, 1 },
                    { 28, new DateTime(2025, 4, 14, 23, 37, 9, 919, DateTimeKind.Local).AddTicks(8542), null, 2, true, false, true, false, true, true, null, 1200m, "207", 1, 1, 1 },
                    { 29, new DateTime(2025, 4, 14, 23, 37, 9, 919, DateTimeKind.Local).AddTicks(8543), null, 2, true, false, true, false, true, true, null, 1200m, "208", 1, 1, 1 },
                    { 30, new DateTime(2025, 4, 14, 23, 37, 9, 919, DateTimeKind.Local).AddTicks(8544), null, 2, true, false, true, false, true, true, null, 1200m, "209", 1, 1, 1 },
                    { 31, new DateTime(2025, 4, 14, 23, 37, 9, 919, DateTimeKind.Local).AddTicks(8546), null, 2, true, false, true, true, true, true, null, 1800m, "210", 1, 3, 1 },
                    { 32, new DateTime(2025, 4, 14, 23, 37, 9, 919, DateTimeKind.Local).AddTicks(8547), null, 2, true, false, true, true, true, true, null, 1800m, "211", 1, 3, 1 },
                    { 33, new DateTime(2025, 4, 14, 23, 37, 9, 919, DateTimeKind.Local).AddTicks(8547), null, 2, true, false, true, true, true, true, null, 1800m, "212", 1, 3, 1 },
                    { 34, new DateTime(2025, 4, 14, 23, 37, 9, 919, DateTimeKind.Local).AddTicks(8548), null, 2, true, false, true, true, true, true, null, 1800m, "213", 1, 3, 1 },
                    { 35, new DateTime(2025, 4, 14, 23, 37, 9, 919, DateTimeKind.Local).AddTicks(8549), null, 2, true, false, true, true, true, true, null, 1800m, "214", 1, 3, 1 },
                    { 36, new DateTime(2025, 4, 14, 23, 37, 9, 919, DateTimeKind.Local).AddTicks(8549), null, 2, true, false, true, true, true, true, null, 1800m, "215", 1, 3, 1 },
                    { 37, new DateTime(2025, 4, 14, 23, 37, 9, 919, DateTimeKind.Local).AddTicks(8550), null, 2, true, false, true, true, true, true, null, 1800m, "216", 1, 3, 1 },
                    { 38, new DateTime(2025, 4, 14, 23, 37, 9, 919, DateTimeKind.Local).AddTicks(8550), null, 2, true, false, true, true, true, true, null, 1800m, "217", 1, 3, 1 },
                    { 39, new DateTime(2025, 4, 14, 23, 37, 9, 919, DateTimeKind.Local).AddTicks(8551), null, 2, true, false, true, true, true, true, null, 1800m, "218", 1, 3, 1 },
                    { 40, new DateTime(2025, 4, 14, 23, 37, 9, 919, DateTimeKind.Local).AddTicks(8551), null, 2, true, false, true, true, true, true, null, 1800m, "219", 1, 3, 1 },
                    { 41, new DateTime(2025, 4, 14, 23, 37, 9, 919, DateTimeKind.Local).AddTicks(8554), null, 3, true, true, true, true, true, true, null, 2200m, "300", 1, 2, 1 },
                    { 42, new DateTime(2025, 4, 14, 23, 37, 9, 919, DateTimeKind.Local).AddTicks(8555), null, 3, true, true, true, true, true, true, null, 2200m, "301", 1, 2, 1 },
                    { 43, new DateTime(2025, 4, 14, 23, 37, 9, 919, DateTimeKind.Local).AddTicks(8556), null, 3, true, true, true, true, true, true, null, 2200m, "302", 1, 2, 1 },
                    { 44, new DateTime(2025, 4, 14, 23, 37, 9, 919, DateTimeKind.Local).AddTicks(8557), null, 3, true, true, true, true, true, true, null, 2200m, "303", 1, 2, 1 },
                    { 45, new DateTime(2025, 4, 14, 23, 37, 9, 919, DateTimeKind.Local).AddTicks(8557), null, 3, true, true, true, true, true, true, null, 2200m, "304", 1, 2, 1 },
                    { 46, new DateTime(2025, 4, 14, 23, 37, 9, 919, DateTimeKind.Local).AddTicks(8558), null, 3, true, true, true, true, true, true, null, 2200m, "305", 1, 2, 1 },
                    { 47, new DateTime(2025, 4, 14, 23, 37, 9, 919, DateTimeKind.Local).AddTicks(8559), null, 3, true, true, true, true, true, true, null, 2200m, "306", 1, 2, 1 },
                    { 48, new DateTime(2025, 4, 14, 23, 37, 9, 919, DateTimeKind.Local).AddTicks(8559), null, 3, true, true, true, true, true, true, null, 2200m, "307", 1, 2, 1 },
                    { 49, new DateTime(2025, 4, 14, 23, 37, 9, 919, DateTimeKind.Local).AddTicks(8560), null, 3, true, true, true, true, true, true, null, 2200m, "308", 1, 2, 1 },
                    { 50, new DateTime(2025, 4, 14, 23, 37, 9, 919, DateTimeKind.Local).AddTicks(8560), null, 3, true, true, true, true, true, true, null, 2200m, "309", 1, 2, 1 },
                    { 51, new DateTime(2025, 4, 14, 23, 37, 9, 919, DateTimeKind.Local).AddTicks(8591), null, 3, true, true, true, true, true, true, null, 2500m, "310", 1, 5, 1 },
                    { 52, new DateTime(2025, 4, 14, 23, 37, 9, 919, DateTimeKind.Local).AddTicks(8593), null, 3, true, true, true, true, true, true, null, 2500m, "311", 1, 5, 1 },
                    { 53, new DateTime(2025, 4, 14, 23, 37, 9, 919, DateTimeKind.Local).AddTicks(8593), null, 3, true, true, true, true, true, true, null, 2500m, "312", 1, 5, 1 },
                    { 54, new DateTime(2025, 4, 14, 23, 37, 9, 919, DateTimeKind.Local).AddTicks(8594), null, 3, true, true, true, true, true, true, null, 2500m, "313", 1, 5, 1 },
                    { 55, new DateTime(2025, 4, 14, 23, 37, 9, 919, DateTimeKind.Local).AddTicks(8594), null, 3, true, true, true, true, true, true, null, 2500m, "314", 1, 5, 1 },
                    { 56, new DateTime(2025, 4, 14, 23, 37, 9, 919, DateTimeKind.Local).AddTicks(8595), null, 3, true, true, true, true, true, true, null, 2500m, "315", 1, 5, 1 },
                    { 57, new DateTime(2025, 4, 14, 23, 37, 9, 919, DateTimeKind.Local).AddTicks(8596), null, 3, true, true, true, true, true, true, null, 2500m, "316", 1, 5, 1 },
                    { 58, new DateTime(2025, 4, 14, 23, 37, 9, 919, DateTimeKind.Local).AddTicks(8596), null, 3, true, true, true, true, true, true, null, 2500m, "317", 1, 5, 1 },
                    { 59, new DateTime(2025, 4, 14, 23, 37, 9, 919, DateTimeKind.Local).AddTicks(8597), null, 3, true, true, true, true, true, true, null, 2500m, "318", 1, 5, 1 },
                    { 60, new DateTime(2025, 4, 14, 23, 37, 9, 919, DateTimeKind.Local).AddTicks(8597), null, 3, true, true, true, true, true, true, null, 2500m, "319", 1, 5, 1 },
                    { 61, new DateTime(2025, 4, 14, 23, 37, 9, 919, DateTimeKind.Local).AddTicks(8599), null, 4, true, true, true, true, true, true, null, 2800m, "400", 1, 2, 1 },
                    { 62, new DateTime(2025, 4, 14, 23, 37, 9, 919, DateTimeKind.Local).AddTicks(8600), null, 4, true, true, true, true, true, true, null, 2800m, "401", 1, 2, 1 },
                    { 63, new DateTime(2025, 4, 14, 23, 37, 9, 919, DateTimeKind.Local).AddTicks(8601), null, 4, true, true, true, true, true, true, null, 2800m, "402", 1, 2, 1 },
                    { 64, new DateTime(2025, 4, 14, 23, 37, 9, 919, DateTimeKind.Local).AddTicks(8601), null, 4, true, true, true, true, true, true, null, 2800m, "403", 1, 2, 1 },
                    { 65, new DateTime(2025, 4, 14, 23, 37, 9, 919, DateTimeKind.Local).AddTicks(8602), null, 4, true, true, true, true, true, true, null, 2800m, "404", 1, 2, 1 },
                    { 66, new DateTime(2025, 4, 14, 23, 37, 9, 919, DateTimeKind.Local).AddTicks(8603), null, 4, true, true, true, true, true, true, null, 2800m, "405", 1, 2, 1 },
                    { 67, new DateTime(2025, 4, 14, 23, 37, 9, 919, DateTimeKind.Local).AddTicks(8604), null, 4, true, true, true, true, true, true, null, 2800m, "406", 1, 2, 1 },
                    { 68, new DateTime(2025, 4, 14, 23, 37, 9, 919, DateTimeKind.Local).AddTicks(8604), null, 4, true, true, true, true, true, true, null, 2800m, "407", 1, 2, 1 },
                    { 69, new DateTime(2025, 4, 14, 23, 37, 9, 919, DateTimeKind.Local).AddTicks(8605), null, 4, true, true, true, true, true, true, null, 2800m, "408", 1, 2, 1 },
                    { 70, new DateTime(2025, 4, 14, 23, 37, 9, 919, DateTimeKind.Local).AddTicks(8605), null, 4, true, true, true, true, true, true, null, 2800m, "409", 1, 2, 1 },
                    { 71, new DateTime(2025, 4, 14, 23, 37, 9, 919, DateTimeKind.Local).AddTicks(8607), null, 4, true, true, true, true, true, true, null, 3500m, "410", 1, 6, 1 },
                    { 72, new DateTime(2025, 4, 14, 23, 37, 9, 919, DateTimeKind.Local).AddTicks(8608), null, 4, true, true, true, true, true, true, null, 3500m, "411", 1, 6, 1 },
                    { 73, new DateTime(2025, 4, 14, 23, 37, 9, 919, DateTimeKind.Local).AddTicks(8609), null, 4, true, true, true, true, true, true, null, 3500m, "412", 1, 6, 1 },
                    { 74, new DateTime(2025, 4, 14, 23, 37, 9, 919, DateTimeKind.Local).AddTicks(8610), null, 4, true, true, true, true, true, true, null, 3500m, "413", 1, 6, 1 },
                    { 75, new DateTime(2025, 4, 14, 23, 37, 9, 919, DateTimeKind.Local).AddTicks(8610), null, 4, true, true, true, true, true, true, null, 3500m, "414", 1, 6, 1 },
                    { 76, new DateTime(2025, 4, 14, 23, 37, 9, 919, DateTimeKind.Local).AddTicks(8611), null, 4, true, true, true, true, true, true, null, 3500m, "415", 1, 6, 1 },
                    { 77, new DateTime(2025, 4, 14, 23, 37, 9, 919, DateTimeKind.Local).AddTicks(8612), null, 4, true, true, true, true, true, true, null, 10000m, "417", 1, 7, 1 }
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
