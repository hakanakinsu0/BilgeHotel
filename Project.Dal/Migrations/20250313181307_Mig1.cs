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
                    { 1, "ec91170d-640e-4375-aa79-03b6be744f94", "Admin", "ADMIN" },
                    { 2, "1dab580b-083e-47b4-a52b-f10e1a8a1432", "Member", "MEMBER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ActivationCode", "ConcurrencyStamp", "CreatedDate", "DeletedDate", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "ModifiedDate", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Status", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { 1, 0, new Guid("00000000-0000-0000-0000-000000000000"), "e8173b0c-8109-4ba7-a969-196b822a81a3", new DateTime(2025, 3, 13, 21, 13, 7, 147, DateTimeKind.Local).AddTicks(8996), null, "bilgehotel@email.com", true, false, null, null, "BILGEHOTEL@EMAIL.COM", "BILGEHOTEL", "AQAAAAIAAYagAAAAEGLJpud4gx+SVzMVvFobASHvnSqPYVC2WkCn6IKW7BylhXUfEyXQwADExckIKFjuMA==", null, false, "9d23d97a-0ee4-4cb4-b378-845c46fc4b6d", 1, false, "bilgehotel" },
                    { 2, 0, new Guid("00000000-0000-0000-0000-000000000000"), "86a23fd2-a570-4280-8693-2764cd3be8be", new DateTime(2025, 3, 13, 21, 13, 7, 187, DateTimeKind.Local).AddTicks(5336), null, "testmember@email.com", true, false, null, null, "TESTMEMBER@EMAIL.COM", "TESTMEMBER", "AQAAAAIAAYagAAAAEOmjcj6GCKzV5uLAA4Atu8oqJs+p+5FKw171AWCnxozEdR9sLDo4N1YOWc7M/VP9oQ==", null, false, "64b69dac-1c60-46cf-b470-6c3fe57d33be", 1, false, "testmember" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Address", "BirthDate", "CreatedDate", "DeletedDate", "FirstName", "HireDate", "LastName", "ModifiedDate", "PhoneNumber", "Position", "Salary", "Shift", "Status" },
                values: new object[,]
                {
                    { 1, "Dağınık Evler Sokak 35a, Aydın, Estonya", new DateTime(1998, 12, 25, 0, 1, 19, 825, DateTimeKind.Local).AddTicks(7622), new DateTime(2025, 3, 13, 21, 13, 7, 107, DateTimeKind.Local).AddTicks(4895), null, "Barsurungu", new DateTime(2015, 6, 2, 8, 2, 50, 234, DateTimeKind.Local).AddTicks(4501), "Özdoğan", null, "+90-314-652-2-534", "Resepsiyonist", 53288.19m, 3, 1 },
                    { 2, "Tevfik Fikret Caddesi 118, Kırıkkale, Azerbaycan", new DateTime(1981, 5, 7, 22, 39, 28, 775, DateTimeKind.Local).AddTicks(2384), new DateTime(2025, 3, 13, 21, 13, 7, 107, DateTimeKind.Local).AddTicks(4998), null, "Barkdurmuş", new DateTime(2017, 5, 1, 12, 13, 26, 474, DateTimeKind.Local).AddTicks(7192), "Ertepınar", null, "+90-984-991-88-08", "Resepsiyonist", 46380.82m, 3, 1 },
                    { 3, "İsmet Attila Caddesi 1, Giresun, Umman", new DateTime(1971, 4, 3, 9, 45, 33, 259, DateTimeKind.Local).AddTicks(4473), new DateTime(2025, 3, 13, 21, 13, 7, 107, DateTimeKind.Local).AddTicks(5060), null, "Alptutuk", new DateTime(2014, 7, 10, 0, 5, 15, 880, DateTimeKind.Local).AddTicks(5622), "Özdoğan", null, "+90-435-285-09-71", "Resepsiyonist", 53212.57m, 1, 1 },
                    { 4, "Ali Çetinkaya Caddesi 12c, İzmir, Çek Cumhuriyeti", new DateTime(1992, 4, 25, 6, 49, 14, 275, DateTimeKind.Local).AddTicks(8681), new DateTime(2025, 3, 13, 21, 13, 7, 107, DateTimeKind.Local).AddTicks(5145), null, "Barskan", new DateTime(2023, 11, 28, 0, 48, 34, 257, DateTimeKind.Local).AddTicks(6137), "Erginsoy", null, "+90-951-235-7-077", "Resepsiyonist", 41475.18m, 1, 1 },
                    { 5, "Kekeçoğlu Sokak 61c, Şanlıurfa, Saint Martin, Fransa", new DateTime(1979, 11, 16, 4, 14, 9, 544, DateTimeKind.Local).AddTicks(3534), new DateTime(2025, 3, 13, 21, 13, 7, 107, DateTimeKind.Local).AddTicks(5225), null, "Abılay", new DateTime(2022, 6, 1, 11, 12, 18, 808, DateTimeKind.Local).AddTicks(6159), "Körmükçü", null, "+90-522-148-92-52", "Resepsiyonist", 43749.79m, 3, 1 },
                    { 6, "Barış Sokak 92, Ankara, Bermuda, İngiltere", new DateTime(2003, 8, 22, 12, 40, 22, 170, DateTimeKind.Local).AddTicks(1650), new DateTime(2025, 3, 13, 21, 13, 7, 107, DateTimeKind.Local).AddTicks(5297), null, "Gönül", new DateTime(2020, 6, 19, 1, 31, 7, 619, DateTimeKind.Local).AddTicks(2486), "Koçoğlu", null, "+90-633-943-1-204", "Resepsiyonist", 54828.83m, 1, 1 },
                    { 7, "Nalbant Sokak 0, Çankırı, Palmyra Atoll, Amerika", new DateTime(1987, 11, 15, 10, 24, 37, 947, DateTimeKind.Local).AddTicks(4857), new DateTime(2025, 3, 13, 21, 13, 7, 107, DateTimeKind.Local).AddTicks(5351), null, "Berkyaruk", new DateTime(2018, 6, 18, 21, 13, 1, 847, DateTimeKind.Local).AddTicks(2550), "Akbulut", null, "+90-437-294-11-95", "Resepsiyonist", 56611.37m, 1, 1 },
                    { 8, "Atatürk Bulvarı 55c, Kilis, Cape Verde", new DateTime(1980, 12, 24, 16, 54, 4, 519, DateTimeKind.Local).AddTicks(9746), new DateTime(2025, 3, 13, 21, 13, 7, 107, DateTimeKind.Local).AddTicks(5441), null, "Bayınçur", new DateTime(2023, 9, 21, 22, 47, 17, 1, DateTimeKind.Local).AddTicks(7458), "Öztuna", null, "+90-914-301-1-073", "Temizlik Görevlisi", 31756.10m, 2, 1 },
                    { 9, "Okul Sokak 33b, Bitlis, Mali", new DateTime(1970, 4, 25, 7, 49, 22, 290, DateTimeKind.Local).AddTicks(7872), new DateTime(2025, 3, 13, 21, 13, 7, 107, DateTimeKind.Local).AddTicks(5523), null, "Bayboğa", new DateTime(2022, 6, 26, 7, 14, 28, 687, DateTimeKind.Local).AddTicks(1085), "Sarıoğlu", null, "+90-679-127-8-213", "Temizlik Görevlisi", 30156.99m, 2, 1 },
                    { 10, "Kerimoğlu Sokak 44c, Bartın, Kazakistan", new DateTime(1990, 4, 27, 7, 47, 21, 384, DateTimeKind.Local).AddTicks(1435), new DateTime(2025, 3, 13, 21, 13, 7, 107, DateTimeKind.Local).AddTicks(5601), null, "Altıntay", new DateTime(2016, 4, 3, 21, 20, 59, 545, DateTimeKind.Local).AddTicks(7123), "Biçer", null, "+90-869-493-2-681", "Temizlik Görevlisi", 27404.06m, 2, 1 },
                    { 11, "Ali Çetinkaya Caddesi 92b, Adıyaman, Birmanya (Myanmar)", new DateTime(2005, 9, 18, 18, 12, 53, 40, DateTimeKind.Local).AddTicks(3213), new DateTime(2025, 3, 13, 21, 13, 7, 107, DateTimeKind.Local).AddTicks(5651), null, "Basan", new DateTime(2014, 8, 1, 2, 6, 54, 196, DateTimeKind.Local).AddTicks(4663), "Öymen", null, "+90-235-537-43-23", "Temizlik Görevlisi", 25797.98m, 1, 1 },
                    { 12, "Kaldırım Sokak 36, Amasya, Honduras", new DateTime(1989, 9, 13, 18, 22, 43, 641, DateTimeKind.Local).AddTicks(6299), new DateTime(2025, 3, 13, 21, 13, 7, 107, DateTimeKind.Local).AddTicks(5729), null, "Biçek", new DateTime(2018, 3, 25, 2, 39, 51, 229, DateTimeKind.Local).AddTicks(4513), "Gürmen", null, "+90-351-388-84-93", "Temizlik Görevlisi", 29327.01m, 1, 1 },
                    { 13, "Barış Sokak 18c, Aydın, Malta", new DateTime(1996, 8, 1, 3, 13, 33, 595, DateTimeKind.Local).AddTicks(5399), new DateTime(2025, 3, 13, 21, 13, 7, 107, DateTimeKind.Local).AddTicks(5800), null, "Alpşalçı", new DateTime(2018, 12, 20, 19, 5, 38, 926, DateTimeKind.Local).AddTicks(3267), "Kılıççı", null, "+90-576-612-6-957", "Temizlik Görevlisi", 31321.94m, 1, 1 },
                    { 14, "Kerimoğlu Sokak 02a, İçel (Mersin), Gambiya", new DateTime(1997, 12, 28, 12, 1, 8, 793, DateTimeKind.Local).AddTicks(6387), new DateTime(2025, 3, 13, 21, 13, 7, 107, DateTimeKind.Local).AddTicks(5850), null, "Iyıktağ", new DateTime(2015, 9, 26, 5, 3, 33, 57, DateTimeKind.Local).AddTicks(4332), "Arıcan", null, "+90-022-723-3-189", "Temizlik Görevlisi", 34776.41m, 2, 1 },
                    { 15, "Fatih Sokak  305, Bartın, Benin", new DateTime(1967, 12, 6, 1, 43, 1, 824, DateTimeKind.Local).AddTicks(3117), new DateTime(2025, 3, 13, 21, 13, 7, 107, DateTimeKind.Local).AddTicks(5942), null, "Ediz", new DateTime(2023, 4, 5, 6, 57, 12, 914, DateTimeKind.Local).AddTicks(9564), "Özgörkey", null, "+90-740-430-67-06", "Temizlik Görevlisi", 25524.03m, 1, 1 },
                    { 16, "Alparslan Türkeş Bulvarı 6, Kırklareli, Guam, Amerika", new DateTime(1974, 12, 3, 8, 47, 55, 61, DateTimeKind.Local).AddTicks(4332), new DateTime(2025, 3, 13, 21, 13, 7, 107, DateTimeKind.Local).AddTicks(6007), null, "İmrem", new DateTime(2016, 3, 10, 4, 59, 16, 692, DateTimeKind.Local).AddTicks(1621), "Körmükçü", null, "+90-254-008-0-597", "Temizlik Görevlisi", 30893.55m, 1, 1 },
                    { 17, "Barış Sokak 67c, Sivas, Belize", new DateTime(1976, 10, 6, 5, 35, 16, 392, DateTimeKind.Local).AddTicks(11), new DateTime(2025, 3, 13, 21, 13, 7, 107, DateTimeKind.Local).AddTicks(6088), null, "Bağaturgerey", new DateTime(2021, 1, 14, 17, 33, 23, 908, DateTimeKind.Local).AddTicks(7220), "Ekici", null, "+90-012-491-96-94", "Temizlik Görevlisi", 25151.08m, 1, 1 },
                    { 18, "Sağlık Sokak 34b, Kilis, Hollanda Antilleri", new DateTime(1977, 4, 14, 7, 14, 25, 365, DateTimeKind.Local).AddTicks(1392), new DateTime(2025, 3, 13, 21, 13, 7, 107, DateTimeKind.Local).AddTicks(6137), null, "Kırçiçek", new DateTime(2022, 6, 11, 4, 59, 7, 976, DateTimeKind.Local).AddTicks(6084), "Çevik", null, "+90-043-368-6-938", "Temizlik Görevlisi", 30833.44m, 1, 1 },
                    { 19, "Saygılı Sokak 232, Yozgat, Virgin Adaları, İngiltere", new DateTime(1989, 5, 20, 5, 54, 26, 569, DateTimeKind.Local).AddTicks(6877), new DateTime(2025, 3, 13, 21, 13, 7, 107, DateTimeKind.Local).AddTicks(6224), null, "Altıntamgan", new DateTime(2014, 8, 31, 12, 6, 28, 118, DateTimeKind.Local).AddTicks(9738), "Sözeri", null, "+90-346-938-52-19", "Aşçı", 110119.27m, 2, 1 },
                    { 20, "Güven Yaka Sokak 089, Düzce, Güney Kıbrıs Rum Yönetimi", new DateTime(2000, 5, 11, 13, 7, 45, 906, DateTimeKind.Local).AddTicks(8018), new DateTime(2025, 3, 13, 21, 13, 7, 107, DateTimeKind.Local).AddTicks(6301), null, "Atlı", new DateTime(2016, 9, 8, 7, 14, 8, 358, DateTimeKind.Local).AddTicks(8437), "Hakyemez", null, "+90-860-499-6-178", "Aşçı", 102256.96m, 2, 1 },
                    { 21, "Dağınık Evler Sokak 6, Hakkari, Fransa", new DateTime(1972, 4, 25, 6, 31, 39, 455, DateTimeKind.Local).AddTicks(9030), new DateTime(2025, 3, 13, 21, 13, 7, 107, DateTimeKind.Local).AddTicks(6375), null, "Bayınçur", new DateTime(2016, 5, 4, 8, 44, 3, 891, DateTimeKind.Local).AddTicks(7611), "Çevik", null, "+90-934-050-88-42", "Aşçı", 102324.14m, 1, 1 },
                    { 22, "Güven Yaka Sokak 91b, Batman, Rusya Federasyonu", new DateTime(1994, 8, 2, 12, 10, 59, 132, DateTimeKind.Local).AddTicks(7845), new DateTime(2025, 3, 13, 21, 13, 7, 107, DateTimeKind.Local).AddTicks(6423), null, "Başkırt", new DateTime(2018, 6, 1, 9, 26, 36, 824, DateTimeKind.Local).AddTicks(4446), "Alyanak", null, "+90-666-208-2-937", "Aşçı", 107177.17m, 2, 1 },
                    { 23, "Harman Yolu Sokak  3, Bartın, Avustralya", new DateTime(1984, 3, 27, 14, 17, 43, 990, DateTimeKind.Local).AddTicks(7396), new DateTime(2025, 3, 13, 21, 13, 7, 107, DateTimeKind.Local).AddTicks(6497), null, "Bayna", new DateTime(2017, 7, 29, 3, 41, 23, 360, DateTimeKind.Local).AddTicks(2939), "Babacan", null, "+90-853-171-7-742", "Aşçı", 115136.26m, 1, 1 },
                    { 24, "Harman Altı Sokak 44b, Muğla, Gabon", new DateTime(1978, 12, 15, 4, 50, 9, 696, DateTimeKind.Local).AddTicks(813), new DateTime(2025, 3, 13, 21, 13, 7, 107, DateTimeKind.Local).AddTicks(6570), null, "Büke", new DateTime(2022, 2, 14, 2, 18, 33, 152, DateTimeKind.Local).AddTicks(3680), "Durmaz", null, "+90-701-271-0-364", "Aşçı", 106689.77m, 2, 1 },
                    { 25, "Harman Yolu Sokak  96a, Bartın, Doğu Timor", new DateTime(2003, 3, 17, 6, 54, 23, 534, DateTimeKind.Local).AddTicks(5595), new DateTime(2025, 3, 13, 21, 13, 7, 107, DateTimeKind.Local).AddTicks(6640), null, "Batuk", new DateTime(2014, 7, 28, 17, 56, 29, 673, DateTimeKind.Local).AddTicks(147), "Erçetin", null, "+90-906-788-1-892", "Aşçı", 118763.45m, 1, 1 },
                    { 26, "Dar Sokak 70a, Kocaeli, Komorlar", new DateTime(1984, 11, 29, 4, 40, 30, 371, DateTimeKind.Local).AddTicks(9727), new DateTime(2025, 3, 13, 21, 13, 7, 107, DateTimeKind.Local).AddTicks(6690), null, "Alpamış", new DateTime(2017, 5, 28, 23, 50, 36, 293, DateTimeKind.Local).AddTicks(4851), "Kulaksızoğlu", null, "+90-873-052-72-22", "Aşçı", 110318.98m, 2, 1 },
                    { 27, "Mevlana Sokak 17a, Aydın, Uganda", new DateTime(1975, 6, 13, 23, 12, 42, 773, DateTimeKind.Local).AddTicks(5931), new DateTime(2025, 3, 13, 21, 13, 7, 107, DateTimeKind.Local).AddTicks(6756), null, "Barkan", new DateTime(2016, 3, 8, 17, 32, 10, 974, DateTimeKind.Local).AddTicks(1820), "Kıraç ", null, "+90-296-604-85-53", "Aşçı", 104120.85m, 1, 1 },
                    { 28, "Tevfik Fikret Caddesi 794, Karaman, Bahreyn", new DateTime(2000, 9, 7, 19, 43, 10, 42, DateTimeKind.Local).AddTicks(5840), new DateTime(2025, 3, 13, 21, 13, 7, 107, DateTimeKind.Local).AddTicks(6835), null, "Alpgerey", new DateTime(2020, 7, 9, 16, 42, 31, 10, DateTimeKind.Local).AddTicks(9881), "Kılıççı", null, "+90-373-297-85-78", "Aşçı", 113665.85m, 2, 1 },
                    { 29, "Oğuzhan Sokak 8, Samsun, Peru", new DateTime(1989, 12, 9, 0, 0, 41, 457, DateTimeKind.Local).AddTicks(6671), new DateTime(2025, 3, 13, 21, 13, 7, 107, DateTimeKind.Local).AddTicks(6918), null, "Aral", new DateTime(2016, 5, 5, 15, 3, 7, 838, DateTimeKind.Local).AddTicks(6148), "Babaoğlu", null, "+90-503-115-2-260", "Aşçı", 104489.91m, 1, 1 },
                    { 30, "Sarıkaya Caddesi 20, Diyarbakır, Kosta Rika", new DateTime(1985, 11, 7, 19, 0, 16, 173, DateTimeKind.Local).AddTicks(488), new DateTime(2025, 3, 13, 21, 13, 7, 107, DateTimeKind.Local).AddTicks(6967), null, "Ay", new DateTime(2018, 12, 16, 13, 43, 52, 564, DateTimeKind.Local).AddTicks(4022), "Duygulu", null, "+90-552-273-3-557", "Garson", 94414.73m, 2, 1 },
                    { 31, "Dağınık Evler Sokak 25a, Amasya, Tacikistan", new DateTime(1992, 7, 26, 10, 20, 17, 155, DateTimeKind.Local).AddTicks(2992), new DateTime(2025, 3, 13, 21, 13, 7, 107, DateTimeKind.Local).AddTicks(7041), null, "Eyiz", new DateTime(2023, 4, 24, 22, 9, 42, 650, DateTimeKind.Local).AddTicks(3662), "Karadaş", null, "+90-485-349-06-96", "Garson", 92967.29m, 2, 1 },
                    { 32, "Barış Sokak 07b, Kırıkkale, Bulgaristan", new DateTime(1970, 2, 27, 18, 51, 33, 68, DateTimeKind.Local).AddTicks(7178), new DateTime(2025, 3, 13, 21, 13, 7, 107, DateTimeKind.Local).AddTicks(7115), null, "Kapgar", new DateTime(2023, 4, 15, 22, 35, 4, 795, DateTimeKind.Local).AddTicks(4775), "Topaloğlu", null, "+90-485-793-80-16", "Garson", 71182.22m, 1, 1 },
                    { 33, "Harman Altı Sokak 46c, Çanakkale, Sri Lanka", new DateTime(1973, 8, 20, 19, 32, 53, 640, DateTimeKind.Local).AddTicks(233), new DateTime(2025, 3, 13, 21, 13, 7, 107, DateTimeKind.Local).AddTicks(7192), null, "Barbol", new DateTime(2021, 3, 31, 20, 30, 54, 127, DateTimeKind.Local).AddTicks(5236), "Sinanoğlu", null, "+90-411-212-63-87", "Garson", 94929.26m, 2, 1 },
                    { 34, "Köypınar Sokak 67b, Adana, Monako", new DateTime(1983, 10, 8, 8, 11, 3, 411, DateTimeKind.Local).AddTicks(4446), new DateTime(2025, 3, 13, 21, 13, 7, 107, DateTimeKind.Local).AddTicks(7248), null, "Al", new DateTime(2024, 1, 11, 14, 41, 31, 771, DateTimeKind.Local).AddTicks(545), "Ekşioğlu", null, "+90-298-550-35-17", "Garson", 76315.29m, 2, 1 },
                    { 35, "Kaldırım Sokak 61b, Manisa, Brunei", new DateTime(1996, 10, 29, 19, 44, 43, 582, DateTimeKind.Local).AddTicks(3154), new DateTime(2025, 3, 13, 21, 13, 7, 107, DateTimeKind.Local).AddTicks(7323), null, "Evin", new DateTime(2022, 2, 22, 21, 51, 27, 941, DateTimeKind.Local).AddTicks(8701), "Yeşilkaya", null, "+90-442-201-20-65", "Garson", 74702.10m, 2, 1 },
                    { 36, "Kaldırım Sokak 96, Kırklareli, Mali", new DateTime(1975, 11, 21, 13, 38, 40, 482, DateTimeKind.Local).AddTicks(4580), new DateTime(2025, 3, 13, 21, 13, 7, 107, DateTimeKind.Local).AddTicks(7399), null, "Bögde", new DateTime(2020, 7, 21, 23, 36, 18, 959, DateTimeKind.Local).AddTicks(6264), "Akman", null, "+90-770-704-7-185", "Garson", 87956.57m, 2, 1 },
                    { 37, "Güven Yaka Sokak 3, Sinop, Niue, Yeni Zelanda", new DateTime(1970, 12, 28, 12, 36, 0, 375, DateTimeKind.Local).AddTicks(8214), new DateTime(2025, 3, 13, 21, 13, 7, 107, DateTimeKind.Local).AddTicks(7461), null, "İdil", new DateTime(2015, 10, 23, 21, 27, 3, 636, DateTimeKind.Local).AddTicks(3781), "Öztonga", null, "+90-718-994-63-03", "Garson", 79281.45m, 1, 1 },
                    { 38, "Kaldırım Sokak 04a, Kars, Johnston Atoll, Amerika", new DateTime(1969, 4, 22, 6, 52, 58, 418, DateTimeKind.Local).AddTicks(3642), new DateTime(2025, 3, 13, 21, 13, 7, 107, DateTimeKind.Local).AddTicks(7509), null, "Amrak", new DateTime(2015, 12, 27, 17, 19, 27, 428, DateTimeKind.Local).AddTicks(1356), "Yetkiner", null, "+90-991-881-6-125", "Garson", 77790.54m, 1, 1 },
                    { 39, "Harman Yolu Sokak  36, Rize, Etiyopya", new DateTime(1974, 10, 14, 6, 24, 10, 48, DateTimeKind.Local).AddTicks(5076), new DateTime(2025, 3, 13, 21, 13, 7, 107, DateTimeKind.Local).AddTicks(7591), null, "Bayançar", new DateTime(2023, 7, 28, 22, 40, 29, 992, DateTimeKind.Local).AddTicks(694), "Poçan", null, "+90-579-510-0-961", "Garson", 79485.15m, 2, 1 },
                    { 40, "Ergenekon Sokak   202, Nevşehir, Güney Kıbrıs Rum Yönetimi", new DateTime(1970, 12, 17, 19, 39, 32, 46, DateTimeKind.Local).AddTicks(9691), new DateTime(2025, 3, 13, 21, 13, 7, 107, DateTimeKind.Local).AddTicks(7676), null, "Esen", new DateTime(2021, 12, 6, 21, 32, 39, 292, DateTimeKind.Local).AddTicks(8301), "Ertepınar", null, "+90-896-458-2-631", "Garson", 95055.91m, 2, 1 },
                    { 41, "Afyon Kaya Sokak 02c, Niğde, Macaristan", new DateTime(1973, 2, 14, 0, 39, 43, 887, DateTimeKind.Local).AddTicks(5245), new DateTime(2025, 3, 13, 21, 13, 7, 107, DateTimeKind.Local).AddTicks(7728), null, "Ayma", new DateTime(2015, 3, 10, 12, 10, 37, 624, DateTimeKind.Local).AddTicks(3610), "Hakyemez", null, "+90-013-699-1-910", "Garson", 78834.61m, 2, 1 },
                    { 42, "Harman Yolu Sokak  38a, Trabzon, Zimbabve", new DateTime(2005, 3, 27, 4, 16, 58, 81, DateTimeKind.Local).AddTicks(9395), new DateTime(2025, 3, 13, 21, 13, 7, 107, DateTimeKind.Local).AddTicks(7800), null, "Esin", new DateTime(2020, 10, 3, 9, 4, 36, 650, DateTimeKind.Local).AddTicks(9568), "Keseroğlu", null, "+90-437-816-89-01", "Garson", 74125.06m, 2, 1 },
                    { 43, "Atatürk Bulvarı 430, Aksaray, Kanarya Adaları", new DateTime(1999, 10, 21, 20, 57, 34, 674, DateTimeKind.Local).AddTicks(8992), new DateTime(2025, 3, 13, 21, 13, 7, 107, DateTimeKind.Local).AddTicks(7878), null, "Alkaevli", new DateTime(2021, 7, 21, 18, 31, 56, 451, DateTimeKind.Local).AddTicks(8749), "Biçer", null, "+90-246-661-5-094", "Elektrikçi", 152753.39m, 3, 1 },
                    { 44, "Köypınar Sokak 38c, Kilis, Folkland Adaları, İngiltere", new DateTime(1996, 10, 15, 13, 52, 12, 161, DateTimeKind.Local).AddTicks(4238), new DateTime(2025, 3, 13, 21, 13, 7, 107, DateTimeKind.Local).AddTicks(7951), null, "Bölükbaşı", new DateTime(2018, 5, 25, 5, 21, 45, 798, DateTimeKind.Local).AddTicks(4765), "Erbulak", null, "+90-861-068-9-446", "IT Sorumlusu", 171724.13m, 3, 1 }
                });

            migrationBuilder.InsertData(
                table: "ExtraServices",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Description", "ModifiedDate", "Name", "Price", "Status" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 3, 13, 21, 13, 7, 187, DateTimeKind.Local).AddTicks(5717), null, "Günlük sınırsız spa kullanımı.", null, "Spa Kullanımı", 3000m, 1 },
                    { 2, new DateTime(2025, 3, 13, 21, 13, 7, 187, DateTimeKind.Local).AddTicks(5719), null, "24 saat oda servisi. Tüm yemek siparişleri dahildir.", null, "Oda Servisi", 1500m, 1 },
                    { 3, new DateTime(2025, 3, 13, 21, 13, 7, 187, DateTimeKind.Local).AddTicks(5720), null, "Minibardaki içecekler ve atıştırmalıklar dahil.", null, "Minibar Kullanımı", 1000m, 1 },
                    { 4, new DateTime(2025, 3, 13, 21, 13, 7, 187, DateTimeKind.Local).AddTicks(5722), null, "Gidiş-dönüş özel araç transferi.", null, "Havalimanı Transferi", 5000m, 1 },
                    { 5, new DateTime(2025, 3, 13, 21, 13, 7, 187, DateTimeKind.Local).AddTicks(5723), null, "Konaklama süresince ücretsiz çamaşır ve kuru temizleme hizmeti.", null, "Çamaşırhane Hizmeti", 500m, 1 },
                    { 6, new DateTime(2025, 3, 13, 21, 13, 7, 187, DateTimeKind.Local).AddTicks(5738), null, "Ekstra günlük temizlik ve hijyen paketi.", null, "Günlük Oda Temizliği", 500m, 1 },
                    { 7, new DateTime(2025, 3, 13, 21, 13, 7, 187, DateTimeKind.Local).AddTicks(5739), null, "Özel şezlong ve plaj hizmetleri.", null, "Özel Plaj Alanı", 7500m, 1 }
                });

            migrationBuilder.InsertData(
                table: "Packages",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Description", "ModifiedDate", "Name", "PriceMultiplier", "Status" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 3, 13, 21, 13, 7, 187, DateTimeKind.Local).AddTicks(5676), null, "Kahvaltı, öğle ve akşam yemeği dahil.", null, "Tam Pansiyon", 1.2m, 1 },
                    { 2, new DateTime(2025, 3, 13, 21, 13, 7, 187, DateTimeKind.Local).AddTicks(5680), null, "Tüm yemekler, alkollü-alkolsüz içecekler ve otelin sunduğu belirli hizmetler dahil.", null, "Her Şey Dahil", 1.5m, 1 }
                });

            migrationBuilder.InsertData(
                table: "RoomTypes",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Description", "ModifiedDate", "Name", "Status" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 3, 13, 21, 13, 7, 105, DateTimeKind.Local).AddTicks(7409), null, "1 adet tek kişilik yatak. Balkon ve minibar bulunmaz. Klima, TV, saç kurutma makinesi ve WiFi mevcuttur.", null, "Tek Kişilik", 1 },
                    { 2, new DateTime(2025, 3, 13, 21, 13, 7, 105, DateTimeKind.Local).AddTicks(7422), null, "1 adet büyük (duble) yatak. Klima, TV, saç kurutma makinesi ve WiFi mevcuttur.", null, "Çift Kişilik (Duble)", 1 },
                    { 3, new DateTime(2025, 3, 13, 21, 13, 7, 105, DateTimeKind.Local).AddTicks(7423), null, "2 adet tek kişilik yatak. Klima, TV, saç kurutma makinesi ve WiFi mevcuttur.", null, "Çift Kişilik (Tek Kişilik 2 Yataklı)", 1 },
                    { 4, new DateTime(2025, 3, 13, 21, 13, 7, 105, DateTimeKind.Local).AddTicks(7425), null, "3 adet tek kişilik yatak.  Klima, TV, saç kurutma makinesi ve WiFi mevcuttur.", null, "Üç Kişilik (Tek Kişilik 3 Yataklı)", 1 },
                    { 5, new DateTime(2025, 3, 13, 21, 13, 7, 105, DateTimeKind.Local).AddTicks(7426), null, "Bir tek bir duble yatak.  Klima, TV, saç kurutma makinesi ve WiFi mevcuttur.", null, "Üç Kişilik (1 Tek, 1 Duble Yataklı)", 1 },
                    { 6, new DateTime(2025, 3, 13, 21, 13, 7, 105, DateTimeKind.Local).AddTicks(7459), null, "1 adet büyük (duble) yatak + 2 adet tek kişilik yatak. Klima, TV, saç kurutma makinesi ve WiFi mevcuttur.", null, "Dört Kişilik", 1 },
                    { 7, new DateTime(2025, 3, 13, 21, 13, 7, 105, DateTimeKind.Local).AddTicks(7460), null, "Geniş ve lüks oda. Özel oturma alanı, büyük yatak, balkon, minibar, özel banyo ve lüks hizmetler. Klima, TV, saç kurutma makinesi, WiFi ve özel hizmetler mevcuttur.", null, "Kral Dairesi", 1 }
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
                    { 1, new DateTime(2025, 3, 13, 21, 13, 7, 105, DateTimeKind.Local).AddTicks(7547), null, 1, true, false, true, false, true, true, null, 1000m, "100", 1, 1, 1 },
                    { 2, new DateTime(2025, 3, 13, 21, 13, 7, 105, DateTimeKind.Local).AddTicks(7550), null, 1, true, false, true, false, true, true, null, 1000m, "101", 1, 1, 1 },
                    { 3, new DateTime(2025, 3, 13, 21, 13, 7, 105, DateTimeKind.Local).AddTicks(7551), null, 1, true, false, true, false, true, true, null, 1000m, "102", 1, 1, 1 },
                    { 4, new DateTime(2025, 3, 13, 21, 13, 7, 105, DateTimeKind.Local).AddTicks(7552), null, 1, true, false, true, false, true, true, null, 1000m, "103", 1, 1, 1 },
                    { 5, new DateTime(2025, 3, 13, 21, 13, 7, 105, DateTimeKind.Local).AddTicks(7552), null, 1, true, false, true, false, true, true, null, 1000m, "104", 1, 1, 1 },
                    { 6, new DateTime(2025, 3, 13, 21, 13, 7, 105, DateTimeKind.Local).AddTicks(7554), null, 1, true, false, true, false, true, true, null, 1000m, "105", 1, 1, 1 },
                    { 7, new DateTime(2025, 3, 13, 21, 13, 7, 105, DateTimeKind.Local).AddTicks(7555), null, 1, true, false, true, false, true, true, null, 1000m, "106", 1, 1, 1 },
                    { 8, new DateTime(2025, 3, 13, 21, 13, 7, 105, DateTimeKind.Local).AddTicks(7556), null, 1, true, false, true, false, true, true, null, 1000m, "107", 1, 1, 1 },
                    { 9, new DateTime(2025, 3, 13, 21, 13, 7, 105, DateTimeKind.Local).AddTicks(7556), null, 1, true, false, true, false, true, true, null, 1000m, "108", 1, 1, 1 },
                    { 10, new DateTime(2025, 3, 13, 21, 13, 7, 105, DateTimeKind.Local).AddTicks(7558), null, 1, true, false, true, false, true, true, null, 1000m, "109", 1, 1, 1 },
                    { 11, new DateTime(2025, 3, 13, 21, 13, 7, 105, DateTimeKind.Local).AddTicks(7560), null, 1, true, false, true, false, true, true, null, 1500m, "110", 1, 4, 1 },
                    { 12, new DateTime(2025, 3, 13, 21, 13, 7, 105, DateTimeKind.Local).AddTicks(7561), null, 1, true, false, true, false, true, true, null, 1500m, "111", 1, 4, 1 },
                    { 13, new DateTime(2025, 3, 13, 21, 13, 7, 105, DateTimeKind.Local).AddTicks(7562), null, 1, true, false, true, false, true, true, null, 1500m, "112", 1, 4, 1 },
                    { 14, new DateTime(2025, 3, 13, 21, 13, 7, 105, DateTimeKind.Local).AddTicks(7562), null, 1, true, false, true, false, true, true, null, 1500m, "113", 1, 4, 1 },
                    { 15, new DateTime(2025, 3, 13, 21, 13, 7, 105, DateTimeKind.Local).AddTicks(7563), null, 1, true, false, true, false, true, true, null, 1500m, "114", 1, 4, 1 },
                    { 16, new DateTime(2025, 3, 13, 21, 13, 7, 105, DateTimeKind.Local).AddTicks(7563), null, 1, true, false, true, false, true, true, null, 1500m, "115", 1, 4, 1 },
                    { 17, new DateTime(2025, 3, 13, 21, 13, 7, 105, DateTimeKind.Local).AddTicks(7564), null, 1, true, false, true, false, true, true, null, 1500m, "116", 1, 4, 1 },
                    { 18, new DateTime(2025, 3, 13, 21, 13, 7, 105, DateTimeKind.Local).AddTicks(7565), null, 1, true, false, true, false, true, true, null, 1500m, "117", 1, 4, 1 },
                    { 19, new DateTime(2025, 3, 13, 21, 13, 7, 105, DateTimeKind.Local).AddTicks(7566), null, 1, true, false, true, false, true, true, null, 1500m, "118", 1, 4, 1 },
                    { 20, new DateTime(2025, 3, 13, 21, 13, 7, 105, DateTimeKind.Local).AddTicks(7567), null, 1, true, false, true, false, true, true, null, 1500m, "119", 1, 4, 1 },
                    { 21, new DateTime(2025, 3, 13, 21, 13, 7, 105, DateTimeKind.Local).AddTicks(7569), null, 2, true, false, true, false, true, true, null, 1200m, "200", 1, 1, 1 },
                    { 22, new DateTime(2025, 3, 13, 21, 13, 7, 105, DateTimeKind.Local).AddTicks(7570), null, 2, true, false, true, false, true, true, null, 1200m, "201", 1, 1, 1 },
                    { 23, new DateTime(2025, 3, 13, 21, 13, 7, 105, DateTimeKind.Local).AddTicks(7570), null, 2, true, false, true, false, true, true, null, 1200m, "202", 1, 1, 1 },
                    { 24, new DateTime(2025, 3, 13, 21, 13, 7, 105, DateTimeKind.Local).AddTicks(7571), null, 2, true, false, true, false, true, true, null, 1200m, "203", 1, 1, 1 },
                    { 25, new DateTime(2025, 3, 13, 21, 13, 7, 105, DateTimeKind.Local).AddTicks(7571), null, 2, true, false, true, false, true, true, null, 1200m, "204", 1, 1, 1 },
                    { 26, new DateTime(2025, 3, 13, 21, 13, 7, 105, DateTimeKind.Local).AddTicks(7572), null, 2, true, false, true, false, true, true, null, 1200m, "205", 1, 1, 1 },
                    { 27, new DateTime(2025, 3, 13, 21, 13, 7, 105, DateTimeKind.Local).AddTicks(7573), null, 2, true, false, true, false, true, true, null, 1200m, "206", 1, 1, 1 },
                    { 28, new DateTime(2025, 3, 13, 21, 13, 7, 105, DateTimeKind.Local).AddTicks(7573), null, 2, true, false, true, false, true, true, null, 1200m, "207", 1, 1, 1 },
                    { 29, new DateTime(2025, 3, 13, 21, 13, 7, 105, DateTimeKind.Local).AddTicks(7574), null, 2, true, false, true, false, true, true, null, 1200m, "208", 1, 1, 1 },
                    { 30, new DateTime(2025, 3, 13, 21, 13, 7, 105, DateTimeKind.Local).AddTicks(7574), null, 2, true, false, true, false, true, true, null, 1200m, "209", 1, 1, 1 },
                    { 31, new DateTime(2025, 3, 13, 21, 13, 7, 105, DateTimeKind.Local).AddTicks(7576), null, 2, true, false, true, true, true, true, null, 1800m, "210", 1, 3, 1 },
                    { 32, new DateTime(2025, 3, 13, 21, 13, 7, 105, DateTimeKind.Local).AddTicks(7577), null, 2, true, false, true, true, true, true, null, 1800m, "211", 1, 3, 1 },
                    { 33, new DateTime(2025, 3, 13, 21, 13, 7, 105, DateTimeKind.Local).AddTicks(7578), null, 2, true, false, true, true, true, true, null, 1800m, "212", 1, 3, 1 },
                    { 34, new DateTime(2025, 3, 13, 21, 13, 7, 105, DateTimeKind.Local).AddTicks(7579), null, 2, true, false, true, true, true, true, null, 1800m, "213", 1, 3, 1 },
                    { 35, new DateTime(2025, 3, 13, 21, 13, 7, 105, DateTimeKind.Local).AddTicks(7580), null, 2, true, false, true, true, true, true, null, 1800m, "214", 1, 3, 1 },
                    { 36, new DateTime(2025, 3, 13, 21, 13, 7, 105, DateTimeKind.Local).AddTicks(7581), null, 2, true, false, true, true, true, true, null, 1800m, "215", 1, 3, 1 },
                    { 37, new DateTime(2025, 3, 13, 21, 13, 7, 105, DateTimeKind.Local).AddTicks(7581), null, 2, true, false, true, true, true, true, null, 1800m, "216", 1, 3, 1 },
                    { 38, new DateTime(2025, 3, 13, 21, 13, 7, 105, DateTimeKind.Local).AddTicks(7582), null, 2, true, false, true, true, true, true, null, 1800m, "217", 1, 3, 1 },
                    { 39, new DateTime(2025, 3, 13, 21, 13, 7, 105, DateTimeKind.Local).AddTicks(7582), null, 2, true, false, true, true, true, true, null, 1800m, "218", 1, 3, 1 },
                    { 40, new DateTime(2025, 3, 13, 21, 13, 7, 105, DateTimeKind.Local).AddTicks(7583), null, 2, true, false, true, true, true, true, null, 1800m, "219", 1, 3, 1 },
                    { 41, new DateTime(2025, 3, 13, 21, 13, 7, 105, DateTimeKind.Local).AddTicks(7586), null, 3, true, true, true, true, true, true, null, 2200m, "300", 1, 2, 1 },
                    { 42, new DateTime(2025, 3, 13, 21, 13, 7, 105, DateTimeKind.Local).AddTicks(7587), null, 3, true, true, true, true, true, true, null, 2200m, "301", 1, 2, 1 },
                    { 43, new DateTime(2025, 3, 13, 21, 13, 7, 105, DateTimeKind.Local).AddTicks(7588), null, 3, true, true, true, true, true, true, null, 2200m, "302", 1, 2, 1 },
                    { 44, new DateTime(2025, 3, 13, 21, 13, 7, 105, DateTimeKind.Local).AddTicks(7588), null, 3, true, true, true, true, true, true, null, 2200m, "303", 1, 2, 1 },
                    { 45, new DateTime(2025, 3, 13, 21, 13, 7, 105, DateTimeKind.Local).AddTicks(7589), null, 3, true, true, true, true, true, true, null, 2200m, "304", 1, 2, 1 },
                    { 46, new DateTime(2025, 3, 13, 21, 13, 7, 105, DateTimeKind.Local).AddTicks(7590), null, 3, true, true, true, true, true, true, null, 2200m, "305", 1, 2, 1 },
                    { 47, new DateTime(2025, 3, 13, 21, 13, 7, 105, DateTimeKind.Local).AddTicks(7590), null, 3, true, true, true, true, true, true, null, 2200m, "306", 1, 2, 1 },
                    { 48, new DateTime(2025, 3, 13, 21, 13, 7, 105, DateTimeKind.Local).AddTicks(7591), null, 3, true, true, true, true, true, true, null, 2200m, "307", 1, 2, 1 },
                    { 49, new DateTime(2025, 3, 13, 21, 13, 7, 105, DateTimeKind.Local).AddTicks(7592), null, 3, true, true, true, true, true, true, null, 2200m, "308", 1, 2, 1 },
                    { 50, new DateTime(2025, 3, 13, 21, 13, 7, 105, DateTimeKind.Local).AddTicks(7612), null, 3, true, true, true, true, true, true, null, 2200m, "309", 1, 2, 1 },
                    { 51, new DateTime(2025, 3, 13, 21, 13, 7, 105, DateTimeKind.Local).AddTicks(7617), null, 3, true, true, true, true, true, true, null, 2500m, "310", 1, 5, 1 },
                    { 52, new DateTime(2025, 3, 13, 21, 13, 7, 105, DateTimeKind.Local).AddTicks(7618), null, 3, true, true, true, true, true, true, null, 2500m, "311", 1, 5, 1 },
                    { 53, new DateTime(2025, 3, 13, 21, 13, 7, 105, DateTimeKind.Local).AddTicks(7619), null, 3, true, true, true, true, true, true, null, 2500m, "312", 1, 5, 1 },
                    { 54, new DateTime(2025, 3, 13, 21, 13, 7, 105, DateTimeKind.Local).AddTicks(7620), null, 3, true, true, true, true, true, true, null, 2500m, "313", 1, 5, 1 },
                    { 55, new DateTime(2025, 3, 13, 21, 13, 7, 105, DateTimeKind.Local).AddTicks(7621), null, 3, true, true, true, true, true, true, null, 2500m, "314", 1, 5, 1 },
                    { 56, new DateTime(2025, 3, 13, 21, 13, 7, 105, DateTimeKind.Local).AddTicks(7621), null, 3, true, true, true, true, true, true, null, 2500m, "315", 1, 5, 1 },
                    { 57, new DateTime(2025, 3, 13, 21, 13, 7, 105, DateTimeKind.Local).AddTicks(7622), null, 3, true, true, true, true, true, true, null, 2500m, "316", 1, 5, 1 },
                    { 58, new DateTime(2025, 3, 13, 21, 13, 7, 105, DateTimeKind.Local).AddTicks(7622), null, 3, true, true, true, true, true, true, null, 2500m, "317", 1, 5, 1 },
                    { 59, new DateTime(2025, 3, 13, 21, 13, 7, 105, DateTimeKind.Local).AddTicks(7623), null, 3, true, true, true, true, true, true, null, 2500m, "318", 1, 5, 1 },
                    { 60, new DateTime(2025, 3, 13, 21, 13, 7, 105, DateTimeKind.Local).AddTicks(7624), null, 3, true, true, true, true, true, true, null, 2500m, "319", 1, 5, 1 },
                    { 61, new DateTime(2025, 3, 13, 21, 13, 7, 105, DateTimeKind.Local).AddTicks(7626), null, 4, true, true, true, true, true, true, null, 2800m, "400", 1, 2, 1 },
                    { 62, new DateTime(2025, 3, 13, 21, 13, 7, 105, DateTimeKind.Local).AddTicks(7626), null, 4, true, true, true, true, true, true, null, 2800m, "401", 1, 2, 1 },
                    { 63, new DateTime(2025, 3, 13, 21, 13, 7, 105, DateTimeKind.Local).AddTicks(7627), null, 4, true, true, true, true, true, true, null, 2800m, "402", 1, 2, 1 },
                    { 64, new DateTime(2025, 3, 13, 21, 13, 7, 105, DateTimeKind.Local).AddTicks(7628), null, 4, true, true, true, true, true, true, null, 2800m, "403", 1, 2, 1 },
                    { 65, new DateTime(2025, 3, 13, 21, 13, 7, 105, DateTimeKind.Local).AddTicks(7628), null, 4, true, true, true, true, true, true, null, 2800m, "404", 1, 2, 1 },
                    { 66, new DateTime(2025, 3, 13, 21, 13, 7, 105, DateTimeKind.Local).AddTicks(7629), null, 4, true, true, true, true, true, true, null, 2800m, "405", 1, 2, 1 },
                    { 67, new DateTime(2025, 3, 13, 21, 13, 7, 105, DateTimeKind.Local).AddTicks(7630), null, 4, true, true, true, true, true, true, null, 2800m, "406", 1, 2, 1 },
                    { 68, new DateTime(2025, 3, 13, 21, 13, 7, 105, DateTimeKind.Local).AddTicks(7631), null, 4, true, true, true, true, true, true, null, 2800m, "407", 1, 2, 1 },
                    { 69, new DateTime(2025, 3, 13, 21, 13, 7, 105, DateTimeKind.Local).AddTicks(7631), null, 4, true, true, true, true, true, true, null, 2800m, "408", 1, 2, 1 },
                    { 70, new DateTime(2025, 3, 13, 21, 13, 7, 105, DateTimeKind.Local).AddTicks(7632), null, 4, true, true, true, true, true, true, null, 2800m, "409", 1, 2, 1 },
                    { 71, new DateTime(2025, 3, 13, 21, 13, 7, 105, DateTimeKind.Local).AddTicks(7635), null, 4, true, true, true, true, true, true, null, 3500m, "410", 1, 6, 1 },
                    { 72, new DateTime(2025, 3, 13, 21, 13, 7, 105, DateTimeKind.Local).AddTicks(7636), null, 4, true, true, true, true, true, true, null, 3500m, "411", 1, 6, 1 },
                    { 73, new DateTime(2025, 3, 13, 21, 13, 7, 105, DateTimeKind.Local).AddTicks(7637), null, 4, true, true, true, true, true, true, null, 3500m, "412", 1, 6, 1 },
                    { 74, new DateTime(2025, 3, 13, 21, 13, 7, 105, DateTimeKind.Local).AddTicks(7637), null, 4, true, true, true, true, true, true, null, 3500m, "413", 1, 6, 1 },
                    { 75, new DateTime(2025, 3, 13, 21, 13, 7, 105, DateTimeKind.Local).AddTicks(7638), null, 4, true, true, true, true, true, true, null, 3500m, "414", 1, 6, 1 },
                    { 76, new DateTime(2025, 3, 13, 21, 13, 7, 105, DateTimeKind.Local).AddTicks(7638), null, 4, true, true, true, true, true, true, null, 3500m, "415", 1, 6, 1 },
                    { 77, new DateTime(2025, 3, 13, 21, 13, 7, 105, DateTimeKind.Local).AddTicks(7641), null, 4, true, true, true, true, true, true, null, 10000m, "417", 1, 7, 1 }
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
