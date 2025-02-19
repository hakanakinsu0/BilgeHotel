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
                name: "Features",
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
                    table.PrimaryKey("PK_Features", x => x.Id);
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
                name: "Shifts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShiftName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    EndTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shifts", x => x.Id);
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
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    AppUserId = table.Column<int>(type: "int", nullable: true),
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
                        principalColumn: "Id");
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
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AppUserId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customers_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Salary = table.Column<decimal>(type: "money", nullable: false),
                    HireDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeDetails_Employees_EmployeeId",
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
                name: "EmployeeShifts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    ShiftId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeShifts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeShifts_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeShifts_Shifts_ShiftId",
                        column: x => x.ShiftId,
                        principalTable: "Shifts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CustomerDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nationality = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdentityNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomerDetails_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
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
                    CustomerId = table.Column<int>(type: "int", nullable: true),
                    RoomId = table.Column<int>(type: "int", nullable: false),
                    PackageId = table.Column<int>(type: "int", nullable: true),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reservations_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
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
                name: "RoomFeatures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    RoomId = table.Column<int>(type: "int", nullable: false),
                    FeatureId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomFeatures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoomFeatures_Features_FeatureId",
                        column: x => x.FeatureId,
                        principalTable: "Features",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoomFeatures_Rooms_RoomId",
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { 1, "d067d351-b30d-4b32-84ff-b21cac004a5d", "Admin", "ADMIN" },
                    { 2, "c8845b60-abe0-4501-83df-01b6e2c3c38b", "Member", "MEMBER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ActivationCode", "ConcurrencyStamp", "CreatedDate", "DeletedDate", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "ModifiedDate", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Status", "TwoFactorEnabled", "UserName" },
                values: new object[] { 1, 0, new Guid("00000000-0000-0000-0000-000000000000"), "8c002990-0f8b-4174-bfe2-bde3fc9166d8", new DateTime(2025, 2, 19, 23, 14, 36, 668, DateTimeKind.Local).AddTicks(7681), null, "bilgehotel@email.com", true, false, null, null, "BILGEHOTEL@EMAIL.COM", "BILGEHOTEL", "AQAAAAIAAYagAAAAEOCWlduuLPgdHc95HdiP23hVPGCd5IeHwEUcKJx9QVhD49Leamz/nAGrBZ9zlvfLHA==", null, false, "8d6ac6cf-6343-432e-b962-8a2c99fa3ec8", 1, false, "bilgehotel" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "FirstName", "LastName", "ModifiedDate", "Position", "Status" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 2, 19, 23, 14, 36, 630, DateTimeKind.Local).AddTicks(1645), null, "Cebe", "Baykam", null, "Resepsiyonist", 1 },
                    { 2, new DateTime(2025, 2, 19, 23, 14, 36, 630, DateTimeKind.Local).AddTicks(1938), null, "Bağatur", "Dizdar ", null, "Resepsiyonist", 1 },
                    { 3, new DateTime(2025, 2, 19, 23, 14, 36, 630, DateTimeKind.Local).AddTicks(2028), null, "Arı", "Türkdoğan", null, "Resepsiyonist", 1 },
                    { 4, new DateTime(2025, 2, 19, 23, 14, 36, 630, DateTimeKind.Local).AddTicks(2109), null, "Atunçu", "Balaban", null, "Resepsiyonist", 1 },
                    { 5, new DateTime(2025, 2, 19, 23, 14, 36, 630, DateTimeKind.Local).AddTicks(2187), null, "Baykara", "Sandalcı", null, "Resepsiyonist", 1 },
                    { 6, new DateTime(2025, 2, 19, 23, 14, 36, 630, DateTimeKind.Local).AddTicks(2239), null, "İrinç", "Elçiboğa", null, "Resepsiyonist", 1 },
                    { 7, new DateTime(2025, 2, 19, 23, 14, 36, 630, DateTimeKind.Local).AddTicks(2315), null, "Çağrıtegin", "Adıvar", null, "Resepsiyonist", 1 },
                    { 8, new DateTime(2025, 2, 19, 23, 14, 36, 630, DateTimeKind.Local).AddTicks(2393), null, "Abluç", "Sezek", null, "Temizlik Görevlisi", 1 },
                    { 9, new DateTime(2025, 2, 19, 23, 14, 36, 630, DateTimeKind.Local).AddTicks(2458), null, "Bumın", "Kulaksızoğlu", null, "Temizlik Görevlisi", 1 },
                    { 10, new DateTime(2025, 2, 19, 23, 14, 36, 630, DateTimeKind.Local).AddTicks(2506), null, "Avşar", "Özkök ", null, "Temizlik Görevlisi", 1 },
                    { 11, new DateTime(2025, 2, 19, 23, 14, 36, 630, DateTimeKind.Local).AddTicks(2584), null, "Borlukçu", "Ilıcalı", null, "Temizlik Görevlisi", 1 },
                    { 12, new DateTime(2025, 2, 19, 23, 14, 36, 630, DateTimeKind.Local).AddTicks(2670), null, "Bağan", "Kılıççı", null, "Temizlik Görevlisi", 1 },
                    { 13, new DateTime(2025, 2, 19, 23, 14, 36, 630, DateTimeKind.Local).AddTicks(2747), null, "Bilge", "Erkekli", null, "Temizlik Görevlisi", 1 },
                    { 14, new DateTime(2025, 2, 19, 23, 14, 36, 630, DateTimeKind.Local).AddTicks(2804), null, "Akçakoca", "Toraman", null, "Temizlik Görevlisi", 1 },
                    { 15, new DateTime(2025, 2, 19, 23, 14, 36, 630, DateTimeKind.Local).AddTicks(2880), null, "Apatarkan", "Demirel", null, "Temizlik Görevlisi", 1 },
                    { 16, new DateTime(2025, 2, 19, 23, 14, 36, 630, DateTimeKind.Local).AddTicks(2949), null, "Çolpan", "Ağaoğlu", null, "Temizlik Görevlisi", 1 },
                    { 17, new DateTime(2025, 2, 19, 23, 14, 36, 630, DateTimeKind.Local).AddTicks(3021), null, "Adsız", "Erçetin", null, "Temizlik Görevlisi", 1 },
                    { 18, new DateTime(2025, 2, 19, 23, 14, 36, 630, DateTimeKind.Local).AddTicks(3069), null, "Baykoca", "Kunter", null, "Temizlik Görevlisi", 1 },
                    { 19, new DateTime(2025, 2, 19, 23, 14, 36, 630, DateTimeKind.Local).AddTicks(3140), null, "Alpay", "Karaböcek", null, "Aşçı", 1 },
                    { 20, new DateTime(2025, 2, 19, 23, 14, 36, 630, DateTimeKind.Local).AddTicks(3207), null, "Bekeçtegin", "Mertoğlu", null, "Aşçı", 1 },
                    { 21, new DateTime(2025, 2, 19, 23, 14, 36, 630, DateTimeKind.Local).AddTicks(3281), null, "Buluğ", "Elmastaşoğlu", null, "Aşçı", 1 },
                    { 22, new DateTime(2025, 2, 19, 23, 14, 36, 630, DateTimeKind.Local).AddTicks(3334), null, "Cılasun", "Bolatlı", null, "Aşçı", 1 },
                    { 23, new DateTime(2025, 2, 19, 23, 14, 36, 630, DateTimeKind.Local).AddTicks(3413), null, "Bükebuyraç", "Yıldırım ", null, "Aşçı", 1 },
                    { 24, new DateTime(2025, 2, 19, 23, 14, 36, 630, DateTimeKind.Local).AddTicks(3490), null, "Barmaklı", "Çetin", null, "Aşçı", 1 },
                    { 25, new DateTime(2025, 2, 19, 23, 14, 36, 630, DateTimeKind.Local).AddTicks(3534), null, "Bıtrı", "Beşerler", null, "Aşçı", 1 },
                    { 26, new DateTime(2025, 2, 19, 23, 14, 36, 630, DateTimeKind.Local).AddTicks(3610), null, "Dizik", "Kılıççı", null, "Aşçı", 1 },
                    { 27, new DateTime(2025, 2, 19, 23, 14, 36, 630, DateTimeKind.Local).AddTicks(3681), null, "Aldoğan", "Özkara", null, "Aşçı", 1 },
                    { 28, new DateTime(2025, 2, 19, 23, 14, 36, 630, DateTimeKind.Local).AddTicks(3752), null, "Basu", "Günday", null, "Aşçı", 1 },
                    { 29, new DateTime(2025, 2, 19, 23, 14, 36, 630, DateTimeKind.Local).AddTicks(3796), null, "Bayındır", "Tanrıkulu", null, "Aşçı", 1 },
                    { 30, new DateTime(2025, 2, 19, 23, 14, 36, 630, DateTimeKind.Local).AddTicks(3867), null, "Abılay", "Ertürk", null, "Garson", 1 },
                    { 31, new DateTime(2025, 2, 19, 23, 14, 36, 630, DateTimeKind.Local).AddTicks(3929), null, "Armağan", "Türkdoğan", null, "Garson", 1 },
                    { 32, new DateTime(2025, 2, 19, 23, 14, 36, 630, DateTimeKind.Local).AddTicks(4004), null, "Çemgen", "Akal", null, "Garson", 1 },
                    { 33, new DateTime(2025, 2, 19, 23, 14, 36, 630, DateTimeKind.Local).AddTicks(4049), null, "Bongul", "Tazegül", null, "Garson", 1 },
                    { 34, new DateTime(2025, 2, 19, 23, 14, 36, 630, DateTimeKind.Local).AddTicks(4130), null, "Bümen", "Balcı", null, "Garson", 1 },
                    { 35, new DateTime(2025, 2, 19, 23, 14, 36, 630, DateTimeKind.Local).AddTicks(4199), null, "Aysılığ", "Barbarosoğlu", null, "Garson", 1 },
                    { 36, new DateTime(2025, 2, 19, 23, 14, 36, 630, DateTimeKind.Local).AddTicks(4274), null, "Bektür", "Özdenak", null, "Garson", 1 },
                    { 37, new DateTime(2025, 2, 19, 23, 14, 36, 630, DateTimeKind.Local).AddTicks(4322), null, "Bayraç", "Öztonga", null, "Garson", 1 },
                    { 38, new DateTime(2025, 2, 19, 23, 14, 36, 630, DateTimeKind.Local).AddTicks(4390), null, "Kayaçık", "Dağdaş", null, "Garson", 1 },
                    { 39, new DateTime(2025, 2, 19, 23, 14, 36, 630, DateTimeKind.Local).AddTicks(4460), null, "Buşulgan", "Doğan ", null, "Garson", 1 },
                    { 40, new DateTime(2025, 2, 19, 23, 14, 36, 630, DateTimeKind.Local).AddTicks(4529), null, "Edil", "Akışık", null, "Garson", 1 },
                    { 41, new DateTime(2025, 2, 19, 23, 14, 36, 630, DateTimeKind.Local).AddTicks(4573), null, "Basanyalavaç", "Akbulut", null, "Garson", 1 },
                    { 42, new DateTime(2025, 2, 19, 23, 14, 36, 630, DateTimeKind.Local).AddTicks(4632), null, "Alpurungu", "Yılmazer", null, "Garson", 1 },
                    { 43, new DateTime(2025, 2, 19, 23, 14, 36, 630, DateTimeKind.Local).AddTicks(4708), null, "Baydur", "Süleymanoğlu", null, "Elektrikçi", 1 },
                    { 44, new DateTime(2025, 2, 19, 23, 14, 36, 630, DateTimeKind.Local).AddTicks(4791), null, "Bürlük", "Keseroğlu", null, "IT Sorumlusu", 1 }
                });

            migrationBuilder.InsertData(
                table: "RoomTypes",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Description", "ModifiedDate", "Name", "Status" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 2, 19, 23, 14, 36, 627, DateTimeKind.Local).AddTicks(4616), null, "1 tek kişilik yatak", null, "Tek Kişilik", 1 },
                    { 2, new DateTime(2025, 2, 19, 23, 14, 36, 627, DateTimeKind.Local).AddTicks(4627), null, "1 büyük yatak", null, "Çift Kişilik (Duble)", 1 },
                    { 3, new DateTime(2025, 2, 19, 23, 14, 36, 627, DateTimeKind.Local).AddTicks(4628), null, "3 tek kişilik yatak", null, "Üç Kişilik", 1 },
                    { 4, new DateTime(2025, 2, 19, 23, 14, 36, 627, DateTimeKind.Local).AddTicks(4629), null, "1 büyük + 2 tek kişilik yatak", null, "Dört Kişilik", 1 },
                    { 5, new DateTime(2025, 2, 19, 23, 14, 36, 627, DateTimeKind.Local).AddTicks(4630), null, "Lüks konaklama, özel hizmetler", null, "Kral Dairesi", 1 }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { 1, 1 });

            migrationBuilder.InsertData(
                table: "EmployeeDetails",
                columns: new[] { "Id", "Address", "BirthDate", "CreatedDate", "DeletedDate", "EmployeeId", "HireDate", "ModifiedDate", "PhoneNumber", "Salary", "Status" },
                values: new object[,]
                {
                    { 1, "Sıran Söğüt Sokak 2, Hatay, Ukrayna", new DateTime(1979, 10, 24, 3, 57, 58, 73, DateTimeKind.Local).AddTicks(9296), new DateTime(2025, 2, 19, 23, 14, 36, 630, DateTimeKind.Local).AddTicks(1929), null, 1, new DateTime(2023, 12, 16, 13, 30, 20, 214, DateTimeKind.Local).AddTicks(70), null, "+90-061-626-2-081", 17720.30m, 1 },
                    { 2, "Oğuzhan Sokak 486, Manisa, Papua Yeni Gine", new DateTime(2006, 9, 23, 7, 5, 27, 197, DateTimeKind.Local).AddTicks(1165), new DateTime(2025, 2, 19, 23, 14, 36, 630, DateTimeKind.Local).AddTicks(2021), null, 2, new DateTime(2014, 10, 8, 14, 34, 13, 510, DateTimeKind.Local).AddTicks(9984), null, "+90-275-822-8-604", 15898.61m, 1 },
                    { 3, "Afyon Kaya Sokak 1, Şanlıurfa, Mozambik", new DateTime(1984, 2, 16, 22, 4, 0, 135, DateTimeKind.Local).AddTicks(1549), new DateTime(2025, 2, 19, 23, 14, 36, 630, DateTimeKind.Local).AddTicks(2102), null, 3, new DateTime(2019, 7, 17, 22, 8, 2, 474, DateTimeKind.Local).AddTicks(8043), null, "+90-853-937-60-68", 17747.57m, 1 },
                    { 4, "Alparslan Türkeş Bulvarı 429, Denizli, Folkland Adaları, İngiltere", new DateTime(1997, 9, 28, 6, 53, 13, 965, DateTimeKind.Local).AddTicks(6296), new DateTime(2025, 2, 19, 23, 14, 36, 630, DateTimeKind.Local).AddTicks(2180), null, 4, new DateTime(2015, 4, 15, 6, 17, 19, 514, DateTimeKind.Local).AddTicks(7351), null, "+90-188-555-7-650", 15440.60m, 1 },
                    { 5, "Fatih Sokak  33a, Bingöl, Johnston Atoll, Amerika", new DateTime(1995, 7, 27, 8, 27, 21, 360, DateTimeKind.Local).AddTicks(3603), new DateTime(2025, 2, 19, 23, 14, 36, 630, DateTimeKind.Local).AddTicks(2232), null, 5, new DateTime(2022, 3, 12, 21, 53, 2, 253, DateTimeKind.Local).AddTicks(5559), null, "+90-718-712-5-660", 27624.02m, 1 },
                    { 6, "Ali Çetinkaya Caddesi 35a, Hatay, Romanya", new DateTime(1971, 9, 15, 0, 40, 16, 28, DateTimeKind.Local).AddTicks(4856), new DateTime(2025, 2, 19, 23, 14, 36, 630, DateTimeKind.Local).AddTicks(2310), null, 6, new DateTime(2017, 11, 11, 13, 12, 28, 984, DateTimeKind.Local).AddTicks(2820), null, "+90-368-017-6-606", 38781.63m, 1 },
                    { 7, "Köypınar Sokak 26, Mardin, Kuzey Maryana Adaları", new DateTime(2002, 7, 25, 0, 59, 43, 138, DateTimeKind.Local).AddTicks(4519), new DateTime(2025, 2, 19, 23, 14, 36, 630, DateTimeKind.Local).AddTicks(2387), null, 7, new DateTime(2019, 6, 22, 10, 25, 13, 898, DateTimeKind.Local).AddTicks(2717), null, "+90-556-752-32-31", 37818.36m, 1 },
                    { 8, "Harman Altı Sokak 84a, Niğde, Montserrat", new DateTime(1995, 3, 27, 7, 26, 40, 625, DateTimeKind.Local).AddTicks(9942), new DateTime(2025, 2, 19, 23, 14, 36, 630, DateTimeKind.Local).AddTicks(2452), null, 8, new DateTime(2019, 8, 31, 12, 29, 12, 907, DateTimeKind.Local).AddTicks(3417), null, "+90-141-932-33-90", 48615.42m, 1 },
                    { 9, "Yunus Emre Sokak 26c, Manisa, Malezya", new DateTime(2006, 11, 21, 21, 49, 12, 854, DateTimeKind.Local).AddTicks(6452), new DateTime(2025, 2, 19, 23, 14, 36, 630, DateTimeKind.Local).AddTicks(2500), null, 9, new DateTime(2014, 5, 14, 1, 27, 42, 489, DateTimeKind.Local).AddTicks(8749), null, "+90-597-710-5-406", 27096.42m, 1 },
                    { 10, "Dağınık Evler Sokak 65c, Adana, Tayland", new DateTime(1989, 9, 9, 23, 19, 21, 4, DateTimeKind.Local).AddTicks(6909), new DateTime(2025, 2, 19, 23, 14, 36, 630, DateTimeKind.Local).AddTicks(2578), null, 10, new DateTime(2022, 7, 5, 12, 44, 56, 40, DateTimeKind.Local).AddTicks(8509), null, "+90-186-337-19-60", 27260.28m, 1 },
                    { 11, "Sevgi Sokak 40a, Balıkesir, Birleşik Arap Emirlikleri", new DateTime(2000, 6, 30, 9, 20, 19, 23, DateTimeKind.Local).AddTicks(4239), new DateTime(2025, 2, 19, 23, 14, 36, 630, DateTimeKind.Local).AddTicks(2665), null, 11, new DateTime(2016, 3, 15, 4, 39, 8, 793, DateTimeKind.Local).AddTicks(7756), null, "+90-742-340-54-81", 22487.59m, 1 },
                    { 12, "Saygılı Sokak 84b, Çorum, Almanya", new DateTime(1976, 3, 21, 21, 47, 11, 839, DateTimeKind.Local).AddTicks(3810), new DateTime(2025, 2, 19, 23, 14, 36, 630, DateTimeKind.Local).AddTicks(2740), null, 12, new DateTime(2019, 3, 27, 22, 24, 14, 616, DateTimeKind.Local).AddTicks(9739), null, "+90-701-061-5-985", 21307.09m, 1 },
                    { 13, "Kocatepe Caddesi 0, Erzincan, Rusya Federasyonu", new DateTime(1992, 6, 23, 1, 19, 40, 651, DateTimeKind.Local).AddTicks(2890), new DateTime(2025, 2, 19, 23, 14, 36, 630, DateTimeKind.Local).AddTicks(2793), null, 13, new DateTime(2021, 8, 14, 6, 22, 57, 685, DateTimeKind.Local).AddTicks(7534), null, "+90-657-504-63-62", 42108.75m, 1 },
                    { 14, "Barış Sokak 55a, Antalya, Avusturya", new DateTime(1991, 4, 5, 0, 23, 14, 932, DateTimeKind.Local).AddTicks(5300), new DateTime(2025, 2, 19, 23, 14, 36, 630, DateTimeKind.Local).AddTicks(2871), null, 14, new DateTime(2020, 2, 17, 10, 17, 57, 398, DateTimeKind.Local).AddTicks(5552), null, "+90-673-837-4-173", 19038.39m, 1 },
                    { 15, "Harman Altı Sokak 6, Afyon, Tuvalu", new DateTime(1968, 12, 2, 0, 1, 35, 584, DateTimeKind.Local).AddTicks(6988), new DateTime(2025, 2, 19, 23, 14, 36, 630, DateTimeKind.Local).AddTicks(2944), null, 15, new DateTime(2024, 2, 4, 10, 46, 40, 362, DateTimeKind.Local).AddTicks(2027), null, "+90-321-470-11-19", 30902.21m, 1 },
                    { 16, "Okul Sokak 63a, Kırklareli, Moğolistan", new DateTime(1987, 12, 12, 11, 43, 45, 784, DateTimeKind.Local).AddTicks(9797), new DateTime(2025, 2, 19, 23, 14, 36, 630, DateTimeKind.Local).AddTicks(3016), null, 16, new DateTime(2014, 10, 9, 18, 54, 27, 89, DateTimeKind.Local).AddTicks(2464), null, "+90-279-554-94-14", 21155.18m, 1 },
                    { 17, "Sıran Söğüt Sokak 71c, Uşak, Türkiye", new DateTime(2003, 4, 7, 3, 6, 20, 859, DateTimeKind.Local).AddTicks(9971), new DateTime(2025, 2, 19, 23, 14, 36, 630, DateTimeKind.Local).AddTicks(3063), null, 17, new DateTime(2015, 5, 26, 2, 50, 17, 142, DateTimeKind.Local).AddTicks(5278), null, "+90-878-255-5-914", 45395.87m, 1 },
                    { 18, "Dar Sokak 51a, Karabük, Saint Martin, Fransa", new DateTime(1988, 2, 15, 19, 18, 41, 819, DateTimeKind.Local).AddTicks(6996), new DateTime(2025, 2, 19, 23, 14, 36, 630, DateTimeKind.Local).AddTicks(3133), null, 18, new DateTime(2016, 3, 28, 19, 15, 15, 825, DateTimeKind.Local).AddTicks(1300), null, "+90-057-212-12-37", 31018.99m, 1 },
                    { 19, "Okul Sokak 129, Kırşehir, Güney Kore", new DateTime(1974, 11, 10, 20, 33, 0, 581, DateTimeKind.Local).AddTicks(5667), new DateTime(2025, 2, 19, 23, 14, 36, 630, DateTimeKind.Local).AddTicks(3201), null, 19, new DateTime(2021, 11, 20, 16, 38, 2, 49, DateTimeKind.Local).AddTicks(4867), null, "+90-602-711-68-19", 39610.85m, 1 },
                    { 20, "Mevlana Sokak 6, Erzincan, Macaristan", new DateTime(1997, 9, 25, 5, 26, 50, 774, DateTimeKind.Local).AddTicks(9655), new DateTime(2025, 2, 19, 23, 14, 36, 630, DateTimeKind.Local).AddTicks(3276), null, 20, new DateTime(2015, 5, 25, 3, 55, 49, 917, DateTimeKind.Local).AddTicks(9805), null, "+90-276-750-6-872", 48462.34m, 1 },
                    { 21, "Menekşe Sokak 274, Osmaniye, Bahreyn", new DateTime(2000, 5, 18, 10, 31, 28, 742, DateTimeKind.Local).AddTicks(4121), new DateTime(2025, 2, 19, 23, 14, 36, 630, DateTimeKind.Local).AddTicks(3324), null, 21, new DateTime(2016, 11, 25, 3, 8, 50, 953, DateTimeKind.Local).AddTicks(7739), null, "+90-133-284-9-366", 31204.99m, 1 },
                    { 22, "Dağınık Evler Sokak 57, Ardahan, Şili", new DateTime(2001, 10, 26, 0, 49, 44, 340, DateTimeKind.Local).AddTicks(2079), new DateTime(2025, 2, 19, 23, 14, 36, 630, DateTimeKind.Local).AddTicks(3407), null, 22, new DateTime(2023, 1, 1, 1, 40, 51, 955, DateTimeKind.Local).AddTicks(7602), null, "+90-501-381-70-24", 44155.92m, 1 },
                    { 23, "Sıran Söğüt Sokak 778, Zonguldak, İsviçre", new DateTime(1967, 11, 18, 4, 54, 33, 214, DateTimeKind.Local).AddTicks(923), new DateTime(2025, 2, 19, 23, 14, 36, 630, DateTimeKind.Local).AddTicks(3485), null, 23, new DateTime(2015, 2, 16, 11, 29, 28, 744, DateTimeKind.Local).AddTicks(6722), null, "+90-808-265-83-85", 25020.43m, 1 },
                    { 24, "Ali Çetinkaya Caddesi 14, Sivas, Ukrayna", new DateTime(1999, 11, 3, 19, 13, 17, 451, DateTimeKind.Local).AddTicks(9190), new DateTime(2025, 2, 19, 23, 14, 36, 630, DateTimeKind.Local).AddTicks(3530), null, 24, new DateTime(2019, 3, 17, 3, 22, 34, 489, DateTimeKind.Local).AddTicks(6848), null, "+90-387-848-6-073", 31618.83m, 1 },
                    { 25, "Kekeçoğlu Sokak 51, Kırşehir, Bhutan", new DateTime(1975, 3, 28, 12, 1, 43, 356, DateTimeKind.Local).AddTicks(9950), new DateTime(2025, 2, 19, 23, 14, 36, 630, DateTimeKind.Local).AddTicks(3606), null, 25, new DateTime(2023, 12, 21, 11, 27, 15, 276, DateTimeKind.Local).AddTicks(5637), null, "+90-344-570-5-017", 17262.03m, 1 },
                    { 26, "Yunus Emre Sokak 92, Afyon, Polonya", new DateTime(2004, 11, 26, 19, 53, 18, 223, DateTimeKind.Local).AddTicks(9012), new DateTime(2025, 2, 19, 23, 14, 36, 630, DateTimeKind.Local).AddTicks(3676), null, 26, new DateTime(2022, 1, 12, 5, 9, 35, 914, DateTimeKind.Local).AddTicks(2775), null, "+90-641-047-73-01", 17066.52m, 1 },
                    { 27, "Okul Sokak 35b, Antalya, Makedonya", new DateTime(1981, 1, 19, 22, 38, 19, 782, DateTimeKind.Local).AddTicks(7873), new DateTime(2025, 2, 19, 23, 14, 36, 630, DateTimeKind.Local).AddTicks(3748), null, 27, new DateTime(2014, 10, 21, 14, 8, 49, 862, DateTimeKind.Local).AddTicks(9383), null, "+90-584-031-57-64", 39594.22m, 1 },
                    { 28, "Bahçe Sokak 79, Karabük, Papua Yeni Gine", new DateTime(1986, 6, 13, 11, 35, 18, 677, DateTimeKind.Local).AddTicks(1547), new DateTime(2025, 2, 19, 23, 14, 36, 630, DateTimeKind.Local).AddTicks(3791), null, 28, new DateTime(2018, 4, 12, 22, 49, 16, 212, DateTimeKind.Local).AddTicks(7666), null, "+90-375-144-6-865", 19761.26m, 1 },
                    { 29, "Lütfi Karadirek Caddesi 22c, Giresun, Burkina Faso", new DateTime(1999, 10, 10, 17, 20, 46, 669, DateTimeKind.Local).AddTicks(8520), new DateTime(2025, 2, 19, 23, 14, 36, 630, DateTimeKind.Local).AddTicks(3862), null, 29, new DateTime(2020, 3, 14, 7, 56, 12, 904, DateTimeKind.Local).AddTicks(5192), null, "+90-769-923-41-39", 34872.92m, 1 },
                    { 30, "Barış Sokak 0, İstanbul, Güney Kıbrıs Rum Yönetimi", new DateTime(1986, 7, 23, 19, 23, 54, 206, DateTimeKind.Local).AddTicks(3228), new DateTime(2025, 2, 19, 23, 14, 36, 630, DateTimeKind.Local).AddTicks(3924), null, 30, new DateTime(2022, 10, 14, 8, 30, 33, 969, DateTimeKind.Local).AddTicks(4368), null, "+90-524-917-7-903", 33318.39m, 1 },
                    { 31, "Gül Sokak 83c, Rize, Japonya", new DateTime(1996, 6, 29, 14, 53, 9, 561, DateTimeKind.Local).AddTicks(2292), new DateTime(2025, 2, 19, 23, 14, 36, 630, DateTimeKind.Local).AddTicks(3998), null, 31, new DateTime(2022, 9, 8, 3, 22, 39, 325, DateTimeKind.Local).AddTicks(8589), null, "+90-695-572-92-73", 23410.81m, 1 },
                    { 32, "Atatürk Bulvarı 7, Muş, Bangladeş", new DateTime(1975, 2, 5, 16, 36, 6, 777, DateTimeKind.Local).AddTicks(855), new DateTime(2025, 2, 19, 23, 14, 36, 630, DateTimeKind.Local).AddTicks(4045), null, 32, new DateTime(2014, 6, 1, 8, 25, 13, 544, DateTimeKind.Local).AddTicks(9325), null, "+90-595-959-44-30", 30067.33m, 1 },
                    { 33, "Köypınar Sokak 442, Diyarbakır, Mauritius", new DateTime(1993, 1, 17, 12, 58, 59, 405, DateTimeKind.Local).AddTicks(4335), new DateTime(2025, 2, 19, 23, 14, 36, 630, DateTimeKind.Local).AddTicks(4124), null, 33, new DateTime(2021, 10, 22, 20, 48, 49, 42, DateTimeKind.Local).AddTicks(5869), null, "+90-098-603-57-41", 33008.21m, 1 },
                    { 34, "Bandak Sokak 62, Kars, İsveç", new DateTime(1992, 2, 5, 6, 57, 19, 281, DateTimeKind.Local).AddTicks(4622), new DateTime(2025, 2, 19, 23, 14, 36, 630, DateTimeKind.Local).AddTicks(4193), null, 34, new DateTime(2023, 11, 27, 15, 3, 22, 97, DateTimeKind.Local).AddTicks(4960), null, "+90-638-192-67-93", 18110.96m, 1 },
                    { 35, "Menekşe Sokak 16c, Nevşehir, San Marino", new DateTime(2003, 8, 9, 10, 40, 40, 529, DateTimeKind.Local).AddTicks(6433), new DateTime(2025, 2, 19, 23, 14, 36, 630, DateTimeKind.Local).AddTicks(4269), null, 35, new DateTime(2020, 10, 27, 19, 31, 1, 838, DateTimeKind.Local).AddTicks(7132), null, "+90-143-057-6-255", 37604.40m, 1 },
                    { 36, "Lütfi Karadirek Caddesi 48c, Çorum, Makedonya", new DateTime(1997, 11, 21, 17, 53, 36, 823, DateTimeKind.Local).AddTicks(1907), new DateTime(2025, 2, 19, 23, 14, 36, 630, DateTimeKind.Local).AddTicks(4313), null, 36, new DateTime(2018, 7, 3, 1, 24, 22, 478, DateTimeKind.Local).AddTicks(6979), null, "+90-389-588-1-961", 43716.71m, 1 },
                    { 37, "Kocatepe Caddesi 2, Batman, Kamerun", new DateTime(1969, 6, 6, 14, 38, 27, 213, DateTimeKind.Local).AddTicks(4996), new DateTime(2025, 2, 19, 23, 14, 36, 630, DateTimeKind.Local).AddTicks(4386), null, 37, new DateTime(2014, 12, 7, 3, 0, 5, 932, DateTimeKind.Local).AddTicks(8699), null, "+90-807-957-14-44", 28634.12m, 1 },
                    { 38, "Yunus Emre Sokak 144, Muş, Lübnan", new DateTime(1999, 9, 8, 21, 55, 56, 974, DateTimeKind.Local).AddTicks(514), new DateTime(2025, 2, 19, 23, 14, 36, 630, DateTimeKind.Local).AddTicks(4456), null, 38, new DateTime(2014, 3, 7, 4, 43, 25, 761, DateTimeKind.Local).AddTicks(6180), null, "+90-787-463-28-28", 35242.11m, 1 },
                    { 39, "Lütfi Karadirek Caddesi 40b, Uşak, Tacikistan", new DateTime(1973, 12, 13, 19, 16, 55, 890, DateTimeKind.Local).AddTicks(2757), new DateTime(2025, 2, 19, 23, 14, 36, 630, DateTimeKind.Local).AddTicks(4524), null, 39, new DateTime(2016, 2, 23, 14, 6, 45, 315, DateTimeKind.Local).AddTicks(8768), null, "+90-658-286-4-594", 49109.72m, 1 },
                    { 40, "Kekeçoğlu Sokak 70c, Denizli, Danimarka", new DateTime(1981, 1, 30, 15, 5, 8, 164, DateTimeKind.Local).AddTicks(3468), new DateTime(2025, 2, 19, 23, 14, 36, 630, DateTimeKind.Local).AddTicks(4569), null, 40, new DateTime(2021, 8, 8, 15, 55, 23, 96, DateTimeKind.Local).AddTicks(2596), null, "+90-935-038-06-01", 23616.41m, 1 },
                    { 41, "Köypınar Sokak 74, Diyarbakır, Benin", new DateTime(1990, 9, 19, 19, 37, 26, 567, DateTimeKind.Local).AddTicks(4705), new DateTime(2025, 2, 19, 23, 14, 36, 630, DateTimeKind.Local).AddTicks(4628), null, 41, new DateTime(2016, 1, 16, 15, 19, 38, 690, DateTimeKind.Local).AddTicks(8289), null, "+90-499-358-2-360", 19155.86m, 1 },
                    { 42, "Nalbant Sokak 84, İzmir, Türkmenistan", new DateTime(1976, 1, 4, 17, 48, 47, 216, DateTimeKind.Local).AddTicks(3054), new DateTime(2025, 2, 19, 23, 14, 36, 630, DateTimeKind.Local).AddTicks(4702), null, 42, new DateTime(2014, 9, 30, 4, 2, 20, 265, DateTimeKind.Local).AddTicks(9414), null, "+90-145-144-3-000", 15436.48m, 1 },
                    { 43, "Kocatepe Caddesi 8, Kocaeli, Malta", new DateTime(1991, 6, 14, 8, 53, 37, 223, DateTimeKind.Local).AddTicks(3033), new DateTime(2025, 2, 19, 23, 14, 36, 630, DateTimeKind.Local).AddTicks(4786), null, 43, new DateTime(2019, 9, 17, 11, 25, 44, 894, DateTimeKind.Local).AddTicks(8487), null, "+90-659-550-7-103", 30230.25m, 1 },
                    { 44, "Menekşe Sokak 58, Bursa, San Marino", new DateTime(1991, 9, 16, 8, 43, 42, 416, DateTimeKind.Local).AddTicks(4365), new DateTime(2025, 2, 19, 23, 14, 36, 630, DateTimeKind.Local).AddTicks(4830), null, 44, new DateTime(2019, 10, 12, 16, 7, 7, 825, DateTimeKind.Local).AddTicks(3817), null, "+90-556-320-74-74", 36084.83m, 1 }
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Floor", "ModifiedDate", "PricePerNight", "RoomNumber", "RoomStatus", "RoomTypeId", "Status" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 2, 19, 23, 14, 36, 629, DateTimeKind.Local).AddTicks(436), null, 1, null, 160.85m, "199", 3, 1, 1 },
                    { 2, new DateTime(2025, 2, 19, 23, 14, 36, 629, DateTimeKind.Local).AddTicks(450), null, 1, null, 111.77m, "191", 3, 1, 1 },
                    { 3, new DateTime(2025, 2, 19, 23, 14, 36, 629, DateTimeKind.Local).AddTicks(455), null, 1, null, 142.69m, "109", 1, 1, 1 },
                    { 4, new DateTime(2025, 2, 19, 23, 14, 36, 629, DateTimeKind.Local).AddTicks(458), null, 1, null, 173.86m, "135", 1, 1, 1 },
                    { 5, new DateTime(2025, 2, 19, 23, 14, 36, 629, DateTimeKind.Local).AddTicks(462), null, 1, null, 180.85m, "129", 2, 3, 1 },
                    { 6, new DateTime(2025, 2, 19, 23, 14, 36, 629, DateTimeKind.Local).AddTicks(466), null, 1, null, 195.15m, "144", 1, 3, 1 },
                    { 7, new DateTime(2025, 2, 19, 23, 14, 36, 629, DateTimeKind.Local).AddTicks(469), null, 1, null, 147.11m, "173", 3, 3, 1 },
                    { 8, new DateTime(2025, 2, 19, 23, 14, 36, 629, DateTimeKind.Local).AddTicks(471), null, 1, null, 158.23m, "174", 1, 3, 1 },
                    { 9, new DateTime(2025, 2, 19, 23, 14, 36, 629, DateTimeKind.Local).AddTicks(474), null, 1, null, 119.43m, "126", 1, 3, 1 },
                    { 10, new DateTime(2025, 2, 19, 23, 14, 36, 629, DateTimeKind.Local).AddTicks(503), null, 1, null, 113.51m, "154", 3, 1, 1 },
                    { 11, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2, null, 228.96m, "232", 2, 1, 0 },
                    { 12, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2, null, 246.63m, "268", 3, 2, 0 },
                    { 13, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2, null, 121.73m, "203", 1, 2, 0 },
                    { 14, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2, null, 127.03m, "273", 1, 2, 0 },
                    { 15, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2, null, 224.84m, "229", 1, 1, 0 },
                    { 16, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2, null, 195.67m, "279", 3, 2, 0 },
                    { 17, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2, null, 199.67m, "290", 3, 2, 0 },
                    { 18, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2, null, 133.67m, "209", 1, 2, 0 },
                    { 19, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2, null, 134.40m, "213", 3, 2, 0 },
                    { 20, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2, null, 122.79m, "286", 1, 1, 0 },
                    { 21, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 3, null, 292.67m, "331", 3, 3, 0 },
                    { 22, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 3, null, 216.66m, "342", 1, 3, 0 },
                    { 23, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 3, null, 167.59m, "324", 1, 2, 0 },
                    { 24, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 3, null, 167.98m, "357", 1, 3, 0 },
                    { 25, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 3, null, 249.66m, "372", 3, 3, 0 },
                    { 26, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 3, null, 263.07m, "389", 3, 2, 0 },
                    { 27, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 3, null, 151.18m, "366", 1, 3, 0 },
                    { 28, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 3, null, 178.88m, "363", 1, 3, 0 },
                    { 29, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 3, null, 166.51m, "345", 3, 2, 0 },
                    { 30, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 3, null, 205.30m, "344", 2, 3, 0 },
                    { 31, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 4, null, 288.39m, "432", 2, 4, 0 },
                    { 32, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 4, null, 497.44m, "405", 3, 4, 0 },
                    { 33, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 4, null, 433.16m, "455", 1, 4, 0 },
                    { 34, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 4, null, 312.12m, "481", 2, 2, 0 },
                    { 35, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 4, null, 273.16m, "426", 2, 2, 0 },
                    { 36, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 4, null, 264.36m, "431", 3, 4, 0 },
                    { 37, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 4, null, 337.29m, "471", 2, 2, 0 },
                    { 38, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 4, null, 494.10m, "477", 2, 2, 0 },
                    { 39, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 4, null, 454.74m, "435", 2, 4, 0 },
                    { 40, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 4, null, 315.99m, "432", 1, 4, 0 },
                    { 41, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 4, null, 1000m, "500", 1, 5, 0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppUserProfiles_AppUserId",
                table: "AppUserProfiles",
                column: "AppUserId",
                unique: true,
                filter: "[AppUserId] IS NOT NULL");

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
                name: "IX_CustomerDetails_CustomerId",
                table: "CustomerDetails",
                column: "CustomerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Customers_AppUserId",
                table: "Customers",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeDetails_EmployeeId",
                table: "EmployeeDetails",
                column: "EmployeeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeShifts_EmployeeId_ShiftId",
                table: "EmployeeShifts",
                columns: new[] { "EmployeeId", "ShiftId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeShifts_ShiftId",
                table: "EmployeeShifts",
                column: "ShiftId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_ReservationId",
                table: "Payments",
                column: "ReservationId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_CustomerId",
                table: "Reservations",
                column: "CustomerId");

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
                name: "IX_RoomFeatures_FeatureId",
                table: "RoomFeatures",
                column: "FeatureId");

            migrationBuilder.CreateIndex(
                name: "IX_RoomFeatures_RoomId_FeatureId",
                table: "RoomFeatures",
                columns: new[] { "RoomId", "FeatureId" },
                unique: true);

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
                name: "CustomerDetails");

            migrationBuilder.DropTable(
                name: "EmployeeDetails");

            migrationBuilder.DropTable(
                name: "EmployeeShifts");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "RoomFeatures");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Shifts");

            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropTable(
                name: "Features");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Packages");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "RoomTypes");
        }
    }
}
