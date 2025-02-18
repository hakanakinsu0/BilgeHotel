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
                    { 1, "3708abff-df03-405b-b7bc-cccbef7871b9", "Admin", "ADMIN" },
                    { 2, "58c0c24b-df43-4477-952c-979f0422645e", "Member", "MEMBER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ActivationCode", "ConcurrencyStamp", "CreatedDate", "DeletedDate", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "ModifiedDate", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Status", "TwoFactorEnabled", "UserName" },
                values: new object[] { 1, 0, new Guid("00000000-0000-0000-0000-000000000000"), "393880ca-680b-4bc8-8040-766a661246ea", new DateTime(2025, 2, 18, 23, 20, 10, 562, DateTimeKind.Local).AddTicks(4262), null, "bilgehotel@email.com", true, false, null, null, "BILGEHOTEL@EMAIL.COM", "BILGEHOTEL", "AQAAAAIAAYagAAAAEN9a/NDpgywVN7Pe+UpUMN2ByMyjhdrD50DQDajM2kQ1LRVj2efaRUK0F+lemn2EsA==", null, false, "a80e6874-afa0-4f51-b723-1f35965628e5", 1, false, "bilgehotel" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "FirstName", "LastName", "ModifiedDate", "Position", "Status" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 2, 18, 23, 20, 10, 519, DateTimeKind.Local).AddTicks(7391), null, "Buyraç", "Çörekçi", null, "Resepsiyonist", 1 },
                    { 2, new DateTime(2025, 2, 18, 23, 20, 10, 519, DateTimeKind.Local).AddTicks(7777), null, "Akata", "Evliyaoğlu", null, "Resepsiyonist", 1 },
                    { 3, new DateTime(2025, 2, 18, 23, 20, 10, 519, DateTimeKind.Local).AddTicks(7886), null, "Çolman", "Küçükler", null, "Resepsiyonist", 1 },
                    { 4, new DateTime(2025, 2, 18, 23, 20, 10, 519, DateTimeKind.Local).AddTicks(7969), null, "Apak", "Egeli", null, "Resepsiyonist", 1 },
                    { 5, new DateTime(2025, 2, 18, 23, 20, 10, 519, DateTimeKind.Local).AddTicks(8025), null, "Ekim", "Kunt", null, "Resepsiyonist", 1 },
                    { 6, new DateTime(2025, 2, 18, 23, 20, 10, 519, DateTimeKind.Local).AddTicks(8126), null, "Bongul", "Kaplangı", null, "Resepsiyonist", 1 },
                    { 7, new DateTime(2025, 2, 18, 23, 20, 10, 519, DateTimeKind.Local).AddTicks(8241), null, "Aladağ", "Kocabıyık", null, "Resepsiyonist", 1 },
                    { 8, new DateTime(2025, 2, 18, 23, 20, 10, 519, DateTimeKind.Local).AddTicks(8327), null, "Büdüstudun", "Aşıkoğlu", null, "Temizlik Görevlisi", 1 },
                    { 9, new DateTime(2025, 2, 18, 23, 20, 10, 519, DateTimeKind.Local).AddTicks(8382), null, "Boylakutlutarkan", "Ekici", null, "Temizlik Görevlisi", 1 },
                    { 10, new DateTime(2025, 2, 18, 23, 20, 10, 519, DateTimeKind.Local).AddTicks(8473), null, "Baştar", "Sarıoğlu", null, "Temizlik Görevlisi", 1 },
                    { 11, new DateTime(2025, 2, 18, 23, 20, 10, 519, DateTimeKind.Local).AddTicks(8568), null, "Ala", "Çetiner", null, "Temizlik Görevlisi", 1 },
                    { 12, new DateTime(2025, 2, 18, 23, 20, 10, 519, DateTimeKind.Local).AddTicks(8655), null, "Kançı", "Topaloğlu", null, "Temizlik Görevlisi", 1 },
                    { 13, new DateTime(2025, 2, 18, 23, 20, 10, 519, DateTimeKind.Local).AddTicks(8711), null, "Barçadoğdu", "Taşlı", null, "Temizlik Görevlisi", 1 },
                    { 14, new DateTime(2025, 2, 18, 23, 20, 10, 519, DateTimeKind.Local).AddTicks(8794), null, "Azıl", "Balaban", null, "Temizlik Görevlisi", 1 },
                    { 15, new DateTime(2025, 2, 18, 23, 20, 10, 519, DateTimeKind.Local).AddTicks(8864), null, "Alpkara", "Tazegül", null, "Temizlik Görevlisi", 1 },
                    { 16, new DateTime(2025, 2, 18, 23, 20, 10, 519, DateTimeKind.Local).AddTicks(8919), null, "Besentegin", "Alnıaçık", null, "Temizlik Görevlisi", 1 },
                    { 17, new DateTime(2025, 2, 18, 23, 20, 10, 519, DateTimeKind.Local).AddTicks(9014), null, "Bengü", "Küçükler", null, "Temizlik Görevlisi", 1 },
                    { 18, new DateTime(2025, 2, 18, 23, 20, 10, 519, DateTimeKind.Local).AddTicks(9113), null, "Beğdilli", "Yetkiner", null, "Temizlik Görevlisi", 1 },
                    { 19, new DateTime(2025, 2, 18, 23, 20, 10, 519, DateTimeKind.Local).AddTicks(9197), null, "Ayas", "Alpuğan", null, "Aşçı", 1 },
                    { 20, new DateTime(2025, 2, 18, 23, 20, 10, 519, DateTimeKind.Local).AddTicks(9246), null, "Bağaalp", "Erkekli", null, "Aşçı", 1 },
                    { 21, new DateTime(2025, 2, 18, 23, 20, 10, 519, DateTimeKind.Local).AddTicks(9336), null, "İlbilge", "Uca", null, "Aşçı", 1 },
                    { 22, new DateTime(2025, 2, 18, 23, 20, 10, 519, DateTimeKind.Local).AddTicks(9418), null, "Amaç", "Koç", null, "Aşçı", 1 },
                    { 23, new DateTime(2025, 2, 18, 23, 20, 10, 519, DateTimeKind.Local).AddTicks(9506), null, "Bermek", "Aykaç", null, "Aşçı", 1 },
                    { 24, new DateTime(2025, 2, 18, 23, 20, 10, 519, DateTimeKind.Local).AddTicks(9561), null, "Çağlayan", "Çörekçi", null, "Aşçı", 1 },
                    { 25, new DateTime(2025, 2, 18, 23, 20, 10, 519, DateTimeKind.Local).AddTicks(9642), null, "Bağaturçigşi", "Eronat", null, "Aşçı", 1 },
                    { 26, new DateTime(2025, 2, 18, 23, 20, 10, 519, DateTimeKind.Local).AddTicks(9717), null, "Beğtegin", "Özbir", null, "Aşçı", 1 },
                    { 27, new DateTime(2025, 2, 18, 23, 20, 10, 519, DateTimeKind.Local).AddTicks(9805), null, "Buyruç", "Dalkıran", null, "Aşçı", 1 },
                    { 28, new DateTime(2025, 2, 18, 23, 20, 10, 519, DateTimeKind.Local).AddTicks(9870), null, "Alakurt", "Orbay", null, "Aşçı", 1 },
                    { 29, new DateTime(2025, 2, 18, 23, 20, 10, 519, DateTimeKind.Local).AddTicks(9969), null, "Bügdüzemen", "Yalçın", null, "Aşçı", 1 },
                    { 30, new DateTime(2025, 2, 18, 23, 20, 10, 520, DateTimeKind.Local).AddTicks(56), null, "Bağış", "Velioğlu", null, "Garson", 1 },
                    { 31, new DateTime(2025, 2, 18, 23, 20, 10, 520, DateTimeKind.Local).AddTicks(140), null, "Bağaturgerey", "Akbulut", null, "Garson", 1 },
                    { 32, new DateTime(2025, 2, 18, 23, 20, 10, 520, DateTimeKind.Local).AddTicks(192), null, "Baltır", "Yalçın", null, "Garson", 1 },
                    { 33, new DateTime(2025, 2, 18, 23, 20, 10, 520, DateTimeKind.Local).AddTicks(279), null, "Aprançur", "Aclan", null, "Garson", 1 },
                    { 34, new DateTime(2025, 2, 18, 23, 20, 10, 520, DateTimeKind.Local).AddTicks(377), null, "Büre", "Beşerler", null, "Garson", 1 },
                    { 35, new DateTime(2025, 2, 18, 23, 20, 10, 520, DateTimeKind.Local).AddTicks(462), null, "Baturalp", "Eliçin", null, "Garson", 1 },
                    { 36, new DateTime(2025, 2, 18, 23, 20, 10, 520, DateTimeKind.Local).AddTicks(516), null, "Isık", "Yeşilkaya", null, "Garson", 1 },
                    { 37, new DateTime(2025, 2, 18, 23, 20, 10, 520, DateTimeKind.Local).AddTicks(585), null, "Esin", "Tunaboylu", null, "Garson", 1 },
                    { 38, new DateTime(2025, 2, 18, 23, 20, 10, 520, DateTimeKind.Local).AddTicks(671), null, "İldike", "Sözeri", null, "Garson", 1 },
                    { 39, new DateTime(2025, 2, 18, 23, 20, 10, 520, DateTimeKind.Local).AddTicks(762), null, "Kançı", "Öztonga", null, "Garson", 1 },
                    { 40, new DateTime(2025, 2, 18, 23, 20, 10, 520, DateTimeKind.Local).AddTicks(815), null, "Egemen", "Topçuoğlu", null, "Garson", 1 },
                    { 41, new DateTime(2025, 2, 18, 23, 20, 10, 520, DateTimeKind.Local).AddTicks(897), null, "Bilgetonyukuk", "Karaer", null, "Garson", 1 },
                    { 42, new DateTime(2025, 2, 18, 23, 20, 10, 520, DateTimeKind.Local).AddTicks(978), null, "Baybora", "Tekand", null, "Garson", 1 },
                    { 43, new DateTime(2025, 2, 18, 23, 20, 10, 520, DateTimeKind.Local).AddTicks(1067), null, "Erdenikatun", "Doğan ", null, "Elektrikçi", 1 },
                    { 44, new DateTime(2025, 2, 18, 23, 20, 10, 520, DateTimeKind.Local).AddTicks(1118), null, "Karaça", "Arslanoğlu", null, "IT Sorumlusu", 1 }
                });

            migrationBuilder.InsertData(
                table: "RoomTypes",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Description", "ModifiedDate", "Name", "Status" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 2, 18, 23, 20, 10, 516, DateTimeKind.Local).AddTicks(4156), null, "1 tek kişilik yatak", null, "Tek Kişilik", 1 },
                    { 2, new DateTime(2025, 2, 18, 23, 20, 10, 516, DateTimeKind.Local).AddTicks(4175), null, "1 büyük yatak", null, "Çift Kişilik (Duble)", 1 },
                    { 3, new DateTime(2025, 2, 18, 23, 20, 10, 516, DateTimeKind.Local).AddTicks(4177), null, "3 tek kişilik yatak", null, "Üç Kişilik", 1 },
                    { 4, new DateTime(2025, 2, 18, 23, 20, 10, 516, DateTimeKind.Local).AddTicks(4178), null, "1 büyük + 2 tek kişilik yatak", null, "Dört Kişilik", 1 },
                    { 5, new DateTime(2025, 2, 18, 23, 20, 10, 516, DateTimeKind.Local).AddTicks(4179), null, "Lüks konaklama, özel hizmetler", null, "Kral Dairesi", 1 }
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
                    { 1, "Güven Yaka Sokak 64a, Ardahan, Kazakistan", new DateTime(1981, 11, 24, 4, 12, 35, 761, DateTimeKind.Local).AddTicks(4795), new DateTime(2025, 2, 18, 23, 20, 10, 519, DateTimeKind.Local).AddTicks(7761), null, 1, new DateTime(2018, 10, 7, 21, 22, 42, 326, DateTimeKind.Local).AddTicks(433), null, "+90-297-309-5-297", 34062.82m, 1 },
                    { 2, "Dağınık Evler Sokak 48b, Gümüşhane, Nikaragua", new DateTime(2002, 10, 11, 11, 59, 7, 731, DateTimeKind.Local).AddTicks(7068), new DateTime(2025, 2, 18, 23, 20, 10, 519, DateTimeKind.Local).AddTicks(7877), null, 2, new DateTime(2020, 3, 5, 17, 17, 46, 912, DateTimeKind.Local).AddTicks(9104), null, "+90-033-818-41-15", 18727.48m, 1 },
                    { 3, "Kocatepe Caddesi 54, Sakarya, Türkmenistan", new DateTime(1983, 2, 13, 20, 44, 12, 728, DateTimeKind.Local).AddTicks(2127), new DateTime(2025, 2, 18, 23, 20, 10, 519, DateTimeKind.Local).AddTicks(7961), null, 3, new DateTime(2020, 10, 29, 1, 26, 52, 58, DateTimeKind.Local).AddTicks(3873), null, "+90-836-622-8-271", 21618.27m, 1 },
                    { 4, "İbn-i Sina Sokak 46c, Bartın, Panama", new DateTime(1980, 4, 16, 11, 20, 19, 993, DateTimeKind.Local).AddTicks(2962), new DateTime(2025, 2, 18, 23, 20, 10, 519, DateTimeKind.Local).AddTicks(8020), null, 4, new DateTime(2016, 10, 28, 1, 32, 52, 879, DateTimeKind.Local).AddTicks(3013), null, "+90-277-961-4-710", 48832.69m, 1 },
                    { 5, "Ergenekon Sokak   2, Kırklareli, Kamboçya", new DateTime(1981, 7, 27, 18, 55, 52, 885, DateTimeKind.Local).AddTicks(5301), new DateTime(2025, 2, 18, 23, 20, 10, 519, DateTimeKind.Local).AddTicks(8118), null, 5, new DateTime(2023, 3, 23, 19, 7, 51, 791, DateTimeKind.Local).AddTicks(6698), null, "+90-230-023-3-273", 44531.43m, 1 },
                    { 6, "Gül Sokak 78a, Hakkari, Gabon", new DateTime(1994, 7, 9, 21, 23, 12, 510, DateTimeKind.Local).AddTicks(6257), new DateTime(2025, 2, 18, 23, 20, 10, 519, DateTimeKind.Local).AddTicks(8228), null, 6, new DateTime(2022, 9, 3, 5, 20, 15, 3, DateTimeKind.Local).AddTicks(4845), null, "+90-996-744-75-91", 25619.64m, 1 },
                    { 7, "Güven Yaka Sokak 5, Batman, Liechtenstein", new DateTime(1993, 11, 3, 17, 20, 59, 297, DateTimeKind.Local).AddTicks(2009), new DateTime(2025, 2, 18, 23, 20, 10, 519, DateTimeKind.Local).AddTicks(8318), null, 7, new DateTime(2023, 3, 26, 0, 52, 52, 156, DateTimeKind.Local).AddTicks(8519), null, "+90-426-810-3-914", 20631.83m, 1 },
                    { 8, "Gül Sokak 92a, Tekirdağ, Tonga", new DateTime(1967, 9, 18, 13, 27, 20, 53, DateTimeKind.Local).AddTicks(4299), new DateTime(2025, 2, 18, 23, 20, 10, 519, DateTimeKind.Local).AddTicks(8375), null, 8, new DateTime(2018, 1, 5, 10, 0, 28, 221, DateTimeKind.Local).AddTicks(5007), null, "+90-813-064-84-32", 37099.68m, 1 },
                    { 9, "Nalbant Sokak 74a, Aksaray, Brezilya", new DateTime(1971, 5, 9, 10, 41, 37, 383, DateTimeKind.Local).AddTicks(3558), new DateTime(2025, 2, 18, 23, 20, 10, 519, DateTimeKind.Local).AddTicks(8464), null, 9, new DateTime(2017, 11, 17, 0, 39, 58, 529, DateTimeKind.Local).AddTicks(8720), null, "+90-771-930-75-80", 32302.22m, 1 },
                    { 10, "Harman Altı Sokak 981, Bitlis, Portekiz", new DateTime(1988, 8, 28, 11, 38, 59, 321, DateTimeKind.Local).AddTicks(9124), new DateTime(2025, 2, 18, 23, 20, 10, 519, DateTimeKind.Local).AddTicks(8555), null, 10, new DateTime(2015, 9, 29, 15, 16, 59, 597, DateTimeKind.Local).AddTicks(2028), null, "+90-064-287-63-30", 35977.86m, 1 },
                    { 11, "Kaldırım Sokak 978, Kayseri, Afganistan", new DateTime(1995, 2, 7, 23, 16, 32, 377, DateTimeKind.Local).AddTicks(9840), new DateTime(2025, 2, 18, 23, 20, 10, 519, DateTimeKind.Local).AddTicks(8616), null, 11, new DateTime(2022, 4, 1, 9, 55, 57, 690, DateTimeKind.Local).AddTicks(9160), null, "+90-914-841-59-23", 31958.87m, 1 },
                    { 12, "İsmet Paşa Caddesi 43c, Düzce, Romanya", new DateTime(1969, 4, 24, 13, 5, 39, 397, DateTimeKind.Local).AddTicks(2366), new DateTime(2025, 2, 18, 23, 20, 10, 519, DateTimeKind.Local).AddTicks(8704), null, 12, new DateTime(2023, 12, 2, 11, 50, 2, 672, DateTimeKind.Local).AddTicks(3908), null, "+90-395-770-8-200", 24551.47m, 1 },
                    { 13, "Sağlık Sokak 78b, Zonguldak, Ruanda", new DateTime(1986, 1, 11, 6, 5, 43, 564, DateTimeKind.Local).AddTicks(9699), new DateTime(2025, 2, 18, 23, 20, 10, 519, DateTimeKind.Local).AddTicks(8787), null, 13, new DateTime(2019, 1, 12, 2, 57, 41, 316, DateTimeKind.Local).AddTicks(5130), null, "+90-951-094-53-08", 32829.77m, 1 },
                    { 14, "Sağlık Sokak 10a, Tekirdağ, Ekvator", new DateTime(1983, 8, 7, 1, 52, 42, 802, DateTimeKind.Local).AddTicks(4655), new DateTime(2025, 2, 18, 23, 20, 10, 519, DateTimeKind.Local).AddTicks(8858), null, 14, new DateTime(2020, 3, 19, 16, 43, 45, 770, DateTimeKind.Local).AddTicks(6081), null, "+90-996-902-18-17", 18009.27m, 1 },
                    { 15, "Namık Kemal Caddesi 7, Bingöl, İsrail", new DateTime(1970, 9, 23, 18, 19, 18, 273, DateTimeKind.Local).AddTicks(1006), new DateTime(2025, 2, 18, 23, 20, 10, 519, DateTimeKind.Local).AddTicks(8912), null, 15, new DateTime(2023, 4, 18, 17, 22, 15, 809, DateTimeKind.Local).AddTicks(7553), null, "+90-069-651-98-28", 40807.55m, 1 },
                    { 16, "Kaldırım Sokak 60a, Muğla, Turks ve Caicos Adaları, İngiltere", new DateTime(1999, 12, 19, 4, 15, 18, 191, DateTimeKind.Local).AddTicks(7290), new DateTime(2025, 2, 18, 23, 20, 10, 519, DateTimeKind.Local).AddTicks(9008), null, 16, new DateTime(2014, 9, 13, 18, 13, 47, 983, DateTimeKind.Local).AddTicks(3985), null, "+90-637-454-26-03", 45332.69m, 1 },
                    { 17, "Namık Kemal Caddesi 3, Bayburt, Laos", new DateTime(1983, 11, 11, 14, 31, 15, 744, DateTimeKind.Local).AddTicks(3107), new DateTime(2025, 2, 18, 23, 20, 10, 519, DateTimeKind.Local).AddTicks(9106), null, 17, new DateTime(2014, 6, 6, 9, 53, 13, 547, DateTimeKind.Local).AddTicks(6665), null, "+90-039-818-4-645", 43862.96m, 1 },
                    { 18, "Nalbant Sokak 87, Karabük, Katar", new DateTime(1972, 9, 15, 10, 18, 24, 702, DateTimeKind.Local).AddTicks(3653), new DateTime(2025, 2, 18, 23, 20, 10, 519, DateTimeKind.Local).AddTicks(9189), null, 18, new DateTime(2020, 12, 15, 2, 58, 55, 267, DateTimeKind.Local).AddTicks(2564), null, "+90-284-261-94-96", 42567.00m, 1 },
                    { 19, "Nalbant Sokak 39a, Bartın, Cibuti", new DateTime(2006, 7, 24, 15, 44, 26, 874, DateTimeKind.Local).AddTicks(4186), new DateTime(2025, 2, 18, 23, 20, 10, 519, DateTimeKind.Local).AddTicks(9241), null, 19, new DateTime(2023, 5, 15, 17, 13, 11, 247, DateTimeKind.Local).AddTicks(8714), null, "+90-607-333-9-528", 40285.49m, 1 },
                    { 20, "Namık Kemal Caddesi 40b, Siirt, Arjantin", new DateTime(1983, 7, 14, 10, 46, 52, 363, DateTimeKind.Local).AddTicks(7799), new DateTime(2025, 2, 18, 23, 20, 10, 519, DateTimeKind.Local).AddTicks(9330), null, 20, new DateTime(2023, 8, 12, 13, 17, 24, 788, DateTimeKind.Local).AddTicks(205), null, "+90-209-170-9-460", 44778.97m, 1 },
                    { 21, "Ülkü Sokak 50b, Kırşehir, Gürcistan H", new DateTime(1995, 11, 27, 1, 7, 10, 96, DateTimeKind.Local).AddTicks(6084), new DateTime(2025, 2, 18, 23, 20, 10, 519, DateTimeKind.Local).AddTicks(9412), null, 21, new DateTime(2014, 12, 31, 22, 0, 12, 320, DateTimeKind.Local).AddTicks(4469), null, "+90-071-824-0-834", 36916.08m, 1 },
                    { 22, "Menekşe Sokak 011, Çankırı, Solomon Adaları", new DateTime(2001, 7, 28, 7, 40, 1, 281, DateTimeKind.Local).AddTicks(7552), new DateTime(2025, 2, 18, 23, 20, 10, 519, DateTimeKind.Local).AddTicks(9500), null, 22, new DateTime(2019, 2, 15, 8, 35, 0, 51, DateTimeKind.Local).AddTicks(6995), null, "+90-321-837-3-485", 39555.12m, 1 },
                    { 23, "Sağlık Sokak 318, Muş, Kosta Rika", new DateTime(1976, 7, 10, 19, 24, 8, 745, DateTimeKind.Local).AddTicks(1286), new DateTime(2025, 2, 18, 23, 20, 10, 519, DateTimeKind.Local).AddTicks(9556), null, 23, new DateTime(2017, 12, 11, 20, 36, 13, 920, DateTimeKind.Local).AddTicks(911), null, "+90-326-930-9-695", 31438.83m, 1 },
                    { 24, "Bandak Sokak 761, Sinop, Cibuti", new DateTime(2001, 5, 25, 7, 20, 19, 183, DateTimeKind.Local).AddTicks(7238), new DateTime(2025, 2, 18, 23, 20, 10, 519, DateTimeKind.Local).AddTicks(9636), null, 24, new DateTime(2017, 8, 23, 13, 17, 19, 37, DateTimeKind.Local).AddTicks(2607), null, "+90-627-977-6-232", 19969.18m, 1 },
                    { 25, "Kekeçoğlu Sokak 71b, Gaziantep, Tonga", new DateTime(1989, 5, 13, 10, 2, 40, 436, DateTimeKind.Local).AddTicks(1543), new DateTime(2025, 2, 18, 23, 20, 10, 519, DateTimeKind.Local).AddTicks(9710), null, 25, new DateTime(2015, 5, 20, 8, 15, 6, 887, DateTimeKind.Local).AddTicks(6014), null, "+90-909-699-9-783", 44689.18m, 1 },
                    { 26, "Kocatepe Caddesi 19c, Tunceli, Vallis ve Futuna, Fransa", new DateTime(1994, 11, 1, 9, 31, 57, 345, DateTimeKind.Local).AddTicks(8381), new DateTime(2025, 2, 18, 23, 20, 10, 519, DateTimeKind.Local).AddTicks(9799), null, 26, new DateTime(2022, 10, 4, 17, 56, 54, 541, DateTimeKind.Local).AddTicks(8811), null, "+90-258-027-07-57", 34004.52m, 1 },
                    { 27, "Kerimoğlu Sokak 9, Tokat, Mikronezya", new DateTime(1981, 6, 6, 1, 8, 3, 928, DateTimeKind.Local).AddTicks(3087), new DateTime(2025, 2, 18, 23, 20, 10, 519, DateTimeKind.Local).AddTicks(9864), null, 27, new DateTime(2015, 12, 3, 7, 45, 41, 960, DateTimeKind.Local).AddTicks(5629), null, "+90-564-371-8-986", 45550.95m, 1 },
                    { 28, "Menekşe Sokak 03b, Yalova, Solomon Adaları", new DateTime(1980, 12, 10, 13, 17, 19, 733, DateTimeKind.Local).AddTicks(879), new DateTime(2025, 2, 18, 23, 20, 10, 519, DateTimeKind.Local).AddTicks(9963), null, 28, new DateTime(2019, 6, 28, 6, 21, 40, 788, DateTimeKind.Local).AddTicks(1061), null, "+90-675-605-9-981", 30801.90m, 1 },
                    { 29, "Dağınık Evler Sokak 14a, Kayseri, Makau (Makao)", new DateTime(1967, 8, 21, 0, 4, 45, 704, DateTimeKind.Local).AddTicks(134), new DateTime(2025, 2, 18, 23, 20, 10, 520, DateTimeKind.Local).AddTicks(47), null, 29, new DateTime(2023, 6, 15, 10, 45, 31, 568, DateTimeKind.Local).AddTicks(4669), null, "+90-169-022-85-55", 15225.80m, 1 },
                    { 30, "Okul Sokak 94b, Sinop, Güney Georgia ve Güney Sandviç Adaları, İngiltere", new DateTime(1987, 3, 2, 5, 25, 16, 818, DateTimeKind.Local).AddTicks(8464), new DateTime(2025, 2, 18, 23, 20, 10, 520, DateTimeKind.Local).AddTicks(135), null, 30, new DateTime(2014, 4, 6, 6, 29, 9, 456, DateTimeKind.Local).AddTicks(9842), null, "+90-402-128-29-06", 17627.83m, 1 },
                    { 31, "Namık Kemal Caddesi 55b, Rize, Haiti", new DateTime(1972, 11, 6, 3, 7, 28, 478, DateTimeKind.Local).AddTicks(1267), new DateTime(2025, 2, 18, 23, 20, 10, 520, DateTimeKind.Local).AddTicks(187), null, 31, new DateTime(2022, 3, 1, 9, 20, 19, 939, DateTimeKind.Local).AddTicks(362), null, "+90-529-474-37-07", 20164.81m, 1 },
                    { 32, "Kaldırım Sokak 95c, Erzincan, Palmyra Atoll, Amerika", new DateTime(1967, 11, 10, 1, 24, 0, 434, DateTimeKind.Local).AddTicks(2248), new DateTime(2025, 2, 18, 23, 20, 10, 520, DateTimeKind.Local).AddTicks(274), null, 32, new DateTime(2015, 2, 6, 16, 42, 51, 762, DateTimeKind.Local).AddTicks(413), null, "+90-884-571-32-99", 36038.69m, 1 },
                    { 33, "Dağınık Evler Sokak 44, Kastamonu, İsrail", new DateTime(1999, 5, 9, 7, 8, 28, 535, DateTimeKind.Local).AddTicks(1426), new DateTime(2025, 2, 18, 23, 20, 10, 520, DateTimeKind.Local).AddTicks(363), null, 33, new DateTime(2017, 8, 28, 17, 7, 12, 943, DateTimeKind.Local).AddTicks(6481), null, "+90-737-935-0-541", 29016.39m, 1 },
                    { 34, "Menekşe Sokak 69a, Hakkari, Estonya", new DateTime(1996, 10, 15, 11, 5, 7, 817, DateTimeKind.Local).AddTicks(2008), new DateTime(2025, 2, 18, 23, 20, 10, 520, DateTimeKind.Local).AddTicks(456), null, 34, new DateTime(2017, 4, 13, 23, 40, 6, 722, DateTimeKind.Local).AddTicks(2737), null, "+90-296-594-4-410", 46636.98m, 1 },
                    { 35, "Sarıkaya Caddesi 31a, K.maraş, Fas", new DateTime(2004, 4, 19, 21, 57, 14, 15, DateTimeKind.Local).AddTicks(7922), new DateTime(2025, 2, 18, 23, 20, 10, 520, DateTimeKind.Local).AddTicks(510), null, 35, new DateTime(2016, 3, 15, 21, 3, 19, 861, DateTimeKind.Local).AddTicks(2425), null, "+90-895-069-4-247", 19848.28m, 1 },
                    { 36, "Kaldırım Sokak 76a, Edirne, Botswana", new DateTime(1977, 6, 22, 7, 22, 44, 489, DateTimeKind.Local).AddTicks(7440), new DateTime(2025, 2, 18, 23, 20, 10, 520, DateTimeKind.Local).AddTicks(579), null, 36, new DateTime(2021, 11, 13, 23, 27, 26, 550, DateTimeKind.Local).AddTicks(4020), null, "+90-559-287-72-38", 49623.25m, 1 },
                    { 37, "30 Ağustos Caddesi 000, Zonguldak, Togo", new DateTime(1976, 11, 26, 16, 9, 25, 318, DateTimeKind.Local).AddTicks(1524), new DateTime(2025, 2, 18, 23, 20, 10, 520, DateTimeKind.Local).AddTicks(666), null, 37, new DateTime(2014, 12, 20, 14, 43, 48, 548, DateTimeKind.Local).AddTicks(12), null, "+90-475-406-5-917", 49481.60m, 1 },
                    { 38, "Okul Sokak 88b, Nevşehir, Letonya", new DateTime(1990, 4, 2, 19, 52, 1, 17, DateTimeKind.Local).AddTicks(873), new DateTime(2025, 2, 18, 23, 20, 10, 520, DateTimeKind.Local).AddTicks(757), null, 38, new DateTime(2023, 11, 11, 12, 3, 34, 114, DateTimeKind.Local).AddTicks(109), null, "+90-766-550-2-569", 18849.82m, 1 },
                    { 39, "Fatih Sokak  6, Düzce, Sri Lanka", new DateTime(1981, 3, 21, 3, 53, 40, 822, DateTimeKind.Local).AddTicks(3079), new DateTime(2025, 2, 18, 23, 20, 10, 520, DateTimeKind.Local).AddTicks(810), null, 39, new DateTime(2023, 9, 3, 7, 16, 10, 323, DateTimeKind.Local).AddTicks(1580), null, "+90-722-427-5-508", 25346.89m, 1 },
                    { 40, "Kerimoğlu Sokak 70b, Bolu, Kosta Rika", new DateTime(2001, 12, 29, 12, 39, 3, 799, DateTimeKind.Local).AddTicks(5819), new DateTime(2025, 2, 18, 23, 20, 10, 520, DateTimeKind.Local).AddTicks(891), null, 40, new DateTime(2021, 4, 4, 5, 4, 37, 743, DateTimeKind.Local).AddTicks(750), null, "+90-102-373-72-10", 21826.88m, 1 },
                    { 41, "Bahçe Sokak 89b, Karaman, Romanya", new DateTime(1983, 10, 21, 14, 35, 29, 703, DateTimeKind.Local).AddTicks(9907), new DateTime(2025, 2, 18, 23, 20, 10, 520, DateTimeKind.Local).AddTicks(973), null, 41, new DateTime(2020, 7, 8, 6, 1, 19, 635, DateTimeKind.Local).AddTicks(2568), null, "+90-523-818-00-29", 17172.59m, 1 },
                    { 42, "Kerimoğlu Sokak 992, Kars, Amerika Birleşik Devletleri", new DateTime(1969, 1, 26, 8, 51, 40, 243, DateTimeKind.Local).AddTicks(9417), new DateTime(2025, 2, 18, 23, 20, 10, 520, DateTimeKind.Local).AddTicks(1025), null, 42, new DateTime(2016, 11, 16, 9, 14, 52, 979, DateTimeKind.Local).AddTicks(9718), null, "+90-706-042-27-93", 33580.17m, 1 },
                    { 43, "Yunus Emre Sokak 74c, Gaziantep, Zimbabve", new DateTime(1994, 3, 17, 20, 16, 21, 483, DateTimeKind.Local).AddTicks(2279), new DateTime(2025, 2, 18, 23, 20, 10, 520, DateTimeKind.Local).AddTicks(1111), null, 43, new DateTime(2022, 3, 24, 10, 48, 50, 646, DateTimeKind.Local).AddTicks(2525), null, "+90-205-006-47-11", 37186.15m, 1 },
                    { 44, "Lütfi Karadirek Caddesi 003, Antalya, Johnston Atoll, Amerika", new DateTime(1987, 7, 10, 20, 11, 43, 64, DateTimeKind.Local).AddTicks(1852), new DateTime(2025, 2, 18, 23, 20, 10, 520, DateTimeKind.Local).AddTicks(1203), null, 44, new DateTime(2014, 10, 20, 13, 54, 0, 643, DateTimeKind.Local).AddTicks(8786), null, "+90-126-099-1-816", 29693.47m, 1 }
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Floor", "ModifiedDate", "PricePerNight", "RoomNumber", "RoomStatus", "RoomTypeId", "Status" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 2, 18, 23, 20, 10, 518, DateTimeKind.Local).AddTicks(4665), null, 1, null, 190.30m, "198", 3, 3, 1 },
                    { 2, new DateTime(2025, 2, 18, 23, 20, 10, 518, DateTimeKind.Local).AddTicks(4679), null, 1, null, 174.43m, "162", 1, 3, 1 },
                    { 3, new DateTime(2025, 2, 18, 23, 20, 10, 518, DateTimeKind.Local).AddTicks(4684), null, 1, null, 183.39m, "126", 3, 3, 1 },
                    { 4, new DateTime(2025, 2, 18, 23, 20, 10, 518, DateTimeKind.Local).AddTicks(4688), null, 1, null, 64.06m, "151", 1, 1, 1 },
                    { 5, new DateTime(2025, 2, 18, 23, 20, 10, 518, DateTimeKind.Local).AddTicks(4691), null, 1, null, 141.01m, "152", 1, 3, 1 },
                    { 6, new DateTime(2025, 2, 18, 23, 20, 10, 518, DateTimeKind.Local).AddTicks(4696), null, 1, null, 147.25m, "134", 3, 1, 1 },
                    { 7, new DateTime(2025, 2, 18, 23, 20, 10, 518, DateTimeKind.Local).AddTicks(4700), null, 1, null, 83.76m, "121", 2, 1, 1 },
                    { 8, new DateTime(2025, 2, 18, 23, 20, 10, 518, DateTimeKind.Local).AddTicks(4704), null, 1, null, 169.42m, "180", 3, 3, 1 },
                    { 9, new DateTime(2025, 2, 18, 23, 20, 10, 518, DateTimeKind.Local).AddTicks(4707), null, 1, null, 69.01m, "176", 1, 1, 1 },
                    { 10, new DateTime(2025, 2, 18, 23, 20, 10, 518, DateTimeKind.Local).AddTicks(4711), null, 1, null, 169.75m, "188", 2, 1, 1 },
                    { 11, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2, null, 175.47m, "282", 1, 2, 0 },
                    { 12, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2, null, 246.58m, "273", 3, 2, 0 },
                    { 13, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2, null, 150.48m, "204", 3, 2, 0 },
                    { 14, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2, null, 176.40m, "288", 3, 1, 0 },
                    { 15, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2, null, 129.71m, "236", 2, 1, 0 },
                    { 16, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2, null, 159.92m, "247", 3, 2, 0 },
                    { 17, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2, null, 112.54m, "262", 1, 1, 0 },
                    { 18, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2, null, 146.97m, "296", 3, 1, 0 },
                    { 19, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2, null, 149.10m, "239", 1, 1, 0 },
                    { 20, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2, null, 155.02m, "233", 2, 1, 0 },
                    { 21, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 3, null, 236.62m, "324", 1, 3, 0 },
                    { 22, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 3, null, 289.26m, "351", 3, 3, 0 },
                    { 23, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 3, null, 199.27m, "385", 3, 2, 0 },
                    { 24, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 3, null, 181.47m, "305", 2, 3, 0 },
                    { 25, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 3, null, 288.51m, "303", 1, 2, 0 },
                    { 26, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 3, null, 260.04m, "377", 2, 3, 0 },
                    { 27, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 3, null, 269.33m, "313", 3, 3, 0 },
                    { 28, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 3, null, 216.37m, "380", 1, 2, 0 },
                    { 29, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 3, null, 276.71m, "369", 2, 3, 0 },
                    { 30, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 3, null, 272.42m, "317", 1, 3, 0 },
                    { 31, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 4, null, 261.70m, "482", 2, 2, 0 },
                    { 32, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 4, null, 416.96m, "416", 2, 4, 0 },
                    { 33, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 4, null, 428.27m, "413", 1, 2, 0 },
                    { 34, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 4, null, 308.31m, "407", 2, 4, 0 },
                    { 35, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 4, null, 420.35m, "472", 2, 4, 0 },
                    { 36, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 4, null, 256.50m, "437", 2, 2, 0 },
                    { 37, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 4, null, 401.14m, "469", 2, 2, 0 },
                    { 38, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 4, null, 308.74m, "471", 2, 2, 0 },
                    { 39, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 4, null, 452.53m, "493", 1, 2, 0 },
                    { 40, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 4, null, 497.70m, "454", 1, 2, 0 },
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
