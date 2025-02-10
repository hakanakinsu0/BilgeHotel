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
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
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
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => x.Id);
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
                columns: new[] { "Id", "ConcurrencyStamp", "CreatedDate", "DeletedDate", "ModifiedDate", "Name", "NormalizedName", "Status" },
                values: new object[] { 1, "859a4f25-a55f-4724-9622-9a4062d741e3", new DateTime(2025, 2, 10, 22, 36, 13, 228, DateTimeKind.Local).AddTicks(5820), null, null, "Admin", "ADMIN", 1 });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ActivationCode", "ConcurrencyStamp", "CreatedDate", "DeletedDate", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "ModifiedDate", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Status", "TwoFactorEnabled", "UserName" },
                values: new object[] { 1, 0, new Guid("00000000-0000-0000-0000-000000000000"), "1a4ca70b-04eb-4146-a98b-3ee93322b155", new DateTime(2025, 2, 10, 22, 36, 13, 267, DateTimeKind.Local).AddTicks(2752), null, "bilgehotel@email.com", true, false, null, null, "BILGEHOTEL@EMAIL.COM", "BILGEHOTEL", "AQAAAAIAAYagAAAAECeXHvLMYPsJIai8k1HoVOsPd0FZK8i9mAi8XCZSqIV1gsdZJVKRTX+nHzeaOKa6Pg==", null, false, "676db23f-0142-4177-8cbe-74434f0e499b", 1, false, "bilgehotel" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "FirstName", "LastName", "ModifiedDate", "Position", "Status" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 2, 10, 22, 36, 13, 228, DateTimeKind.Local).AddTicks(2552), null, "Adalan", "Tazegül", null, "Resepsiyonist", 1 },
                    { 2, new DateTime(2025, 2, 10, 22, 36, 13, 228, DateTimeKind.Local).AddTicks(2840), null, "Bekbekeç", "Mayhoş", null, "Resepsiyonist", 1 },
                    { 3, new DateTime(2025, 2, 10, 22, 36, 13, 228, DateTimeKind.Local).AddTicks(2937), null, "Güzey", "Özdoğan", null, "Resepsiyonist", 1 },
                    { 4, new DateTime(2025, 2, 10, 22, 36, 13, 228, DateTimeKind.Local).AddTicks(2987), null, "Arademir", "Akaydın", null, "Resepsiyonist", 1 },
                    { 5, new DateTime(2025, 2, 10, 22, 36, 13, 228, DateTimeKind.Local).AddTicks(3071), null, "Büre", "Kuday", null, "Resepsiyonist", 1 },
                    { 6, new DateTime(2025, 2, 10, 22, 36, 13, 228, DateTimeKind.Local).AddTicks(3149), null, "Kayaçık", "Durmaz", null, "Resepsiyonist", 1 },
                    { 7, new DateTime(2025, 2, 10, 22, 36, 13, 228, DateTimeKind.Local).AddTicks(3196), null, "Baçman", "Akgül", null, "Resepsiyonist", 1 },
                    { 8, new DateTime(2025, 2, 10, 22, 36, 13, 228, DateTimeKind.Local).AddTicks(3268), null, "Bilgekutluk", "Oraloğlu", null, "Temizlik Görevlisi", 1 },
                    { 9, new DateTime(2025, 2, 10, 22, 36, 13, 228, DateTimeKind.Local).AddTicks(3340), null, "Aşanboğa", "Özgörkey", null, "Temizlik Görevlisi", 1 },
                    { 10, new DateTime(2025, 2, 10, 22, 36, 13, 228, DateTimeKind.Local).AddTicks(3417), null, "Bangu", "Beşok", null, "Temizlik Görevlisi", 1 },
                    { 11, new DateTime(2025, 2, 10, 22, 36, 13, 228, DateTimeKind.Local).AddTicks(3465), null, "İrinçköl", "Türkyılmaz", null, "Temizlik Görevlisi", 1 },
                    { 12, new DateTime(2025, 2, 10, 22, 36, 13, 228, DateTimeKind.Local).AddTicks(3535), null, "Bayankağan", "Uca", null, "Temizlik Görevlisi", 1 },
                    { 13, new DateTime(2025, 2, 10, 22, 36, 13, 228, DateTimeKind.Local).AddTicks(3595), null, "Biçek", "Pekkan", null, "Temizlik Görevlisi", 1 },
                    { 14, new DateTime(2025, 2, 10, 22, 36, 13, 228, DateTimeKind.Local).AddTicks(3671), null, "İlgegü", "Dağlaroğlu", null, "Temizlik Görevlisi", 1 },
                    { 15, new DateTime(2025, 2, 10, 22, 36, 13, 228, DateTimeKind.Local).AddTicks(3727), null, "Altınkan", "Sadıklar", null, "Temizlik Görevlisi", 1 },
                    { 16, new DateTime(2025, 2, 10, 22, 36, 13, 228, DateTimeKind.Local).AddTicks(3802), null, "Akbörü", "Yıldırım ", null, "Temizlik Görevlisi", 1 },
                    { 17, new DateTime(2025, 2, 10, 22, 36, 13, 228, DateTimeKind.Local).AddTicks(3877), null, "Alaban", "Erberk", null, "Temizlik Görevlisi", 1 },
                    { 18, new DateTime(2025, 2, 10, 22, 36, 13, 228, DateTimeKind.Local).AddTicks(3952), null, "Altınkağan", "Mayhoş", null, "Temizlik Görevlisi", 1 },
                    { 19, new DateTime(2025, 2, 10, 22, 36, 13, 228, DateTimeKind.Local).AddTicks(3996), null, "Başak", "Durmaz", null, "Aşçı", 1 },
                    { 20, new DateTime(2025, 2, 10, 22, 36, 13, 228, DateTimeKind.Local).AddTicks(4066), null, "İtil", "Barbarosoğlu", null, "Aşçı", 1 },
                    { 21, new DateTime(2025, 2, 10, 22, 36, 13, 228, DateTimeKind.Local).AddTicks(4132), null, "Bayındır", "Ilıcalı", null, "Aşçı", 1 },
                    { 22, new DateTime(2025, 2, 10, 22, 36, 13, 228, DateTimeKind.Local).AddTicks(4203), null, "Ediz", "Ilıcalı", null, "Aşçı", 1 },
                    { 23, new DateTime(2025, 2, 10, 22, 36, 13, 228, DateTimeKind.Local).AddTicks(4249), null, "Alparslan", "Çağıran", null, "Aşçı", 1 },
                    { 24, new DateTime(2025, 2, 10, 22, 36, 13, 228, DateTimeKind.Local).AddTicks(4314), null, "Bekazıl", "Abacı", null, "Aşçı", 1 },
                    { 25, new DateTime(2025, 2, 10, 22, 36, 13, 228, DateTimeKind.Local).AddTicks(4382), null, "Armağan", "Beşok", null, "Aşçı", 1 },
                    { 26, new DateTime(2025, 2, 10, 22, 36, 13, 228, DateTimeKind.Local).AddTicks(4457), null, "Barçan", "Günday", null, "Aşçı", 1 },
                    { 27, new DateTime(2025, 2, 10, 22, 36, 13, 228, DateTimeKind.Local).AddTicks(4503), null, "Bars", "Aşıkoğlu", null, "Aşçı", 1 },
                    { 28, new DateTime(2025, 2, 10, 22, 36, 13, 228, DateTimeKind.Local).AddTicks(4587), null, "Altınkağan", "Tokatlıoğlu", null, "Aşçı", 1 },
                    { 29, new DateTime(2025, 2, 10, 22, 36, 13, 228, DateTimeKind.Local).AddTicks(4659), null, "İnci", "Topçuoğlu", null, "Aşçı", 1 },
                    { 30, new DateTime(2025, 2, 10, 22, 36, 13, 228, DateTimeKind.Local).AddTicks(4703), null, "Adsız", "Sarıoğlu", null, "Garson", 1 },
                    { 31, new DateTime(2025, 2, 10, 22, 36, 13, 228, DateTimeKind.Local).AddTicks(4768), null, "Atımer", "Balcı", null, "Garson", 1 },
                    { 32, new DateTime(2025, 2, 10, 22, 36, 13, 228, DateTimeKind.Local).AddTicks(4840), null, "Benlidemir", "Sandalcı", null, "Garson", 1 },
                    { 33, new DateTime(2025, 2, 10, 22, 36, 13, 228, DateTimeKind.Local).AddTicks(4907), null, "Çobulmak", "Dağlaroğlu", null, "Garson", 1 },
                    { 34, new DateTime(2025, 2, 10, 22, 36, 13, 228, DateTimeKind.Local).AddTicks(4957), null, "Altınkan", "Pektemek", null, "Garson", 1 },
                    { 35, new DateTime(2025, 2, 10, 22, 36, 13, 228, DateTimeKind.Local).AddTicks(5015), null, "Bek", "Kumcuoğlu", null, "Garson", 1 },
                    { 36, new DateTime(2025, 2, 10, 22, 36, 13, 228, DateTimeKind.Local).AddTicks(5091), null, "Ayyıldız", "Paksüt", null, "Garson", 1 },
                    { 37, new DateTime(2025, 2, 10, 22, 36, 13, 228, DateTimeKind.Local).AddTicks(5165), null, "Bek", "Çamdalı", null, "Garson", 1 },
                    { 38, new DateTime(2025, 2, 10, 22, 36, 13, 228, DateTimeKind.Local).AddTicks(5210), null, "Börü", "Ekşioğlu", null, "Garson", 1 },
                    { 39, new DateTime(2025, 2, 10, 22, 36, 13, 228, DateTimeKind.Local).AddTicks(5276), null, "Asuğ", "Kocabıyık", null, "Garson", 1 },
                    { 40, new DateTime(2025, 2, 10, 22, 36, 13, 228, DateTimeKind.Local).AddTicks(5342), null, "Begitutuk", "Çatalbaş", null, "Garson", 1 },
                    { 41, new DateTime(2025, 2, 10, 22, 36, 13, 228, DateTimeKind.Local).AddTicks(5407), null, "Afşar", "Atakol", null, "Garson", 1 },
                    { 42, new DateTime(2025, 2, 10, 22, 36, 13, 228, DateTimeKind.Local).AddTicks(5451), null, "Beğkulu", "Demirbaş", null, "Garson", 1 },
                    { 43, new DateTime(2025, 2, 10, 22, 36, 13, 228, DateTimeKind.Local).AddTicks(5518), null, "Katun", "Kumcuoğlu", null, "Elektrikçi", 1 },
                    { 44, new DateTime(2025, 2, 10, 22, 36, 13, 228, DateTimeKind.Local).AddTicks(5583), null, "Bamsı", "Özkara", null, "IT Sorumlusu", 1 }
                });

            migrationBuilder.InsertData(
                table: "RoomTypes",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Description", "ModifiedDate", "Name", "Status" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 2, 10, 22, 36, 13, 225, DateTimeKind.Local).AddTicks(6242), null, "1 tek kişilik yatak", null, "Tek Kişilik", 1 },
                    { 2, new DateTime(2025, 2, 10, 22, 36, 13, 225, DateTimeKind.Local).AddTicks(6253), null, "1 büyük yatak", null, "Çift Kişilik (Duble)", 1 },
                    { 3, new DateTime(2025, 2, 10, 22, 36, 13, 225, DateTimeKind.Local).AddTicks(6255), null, "3 tek kişilik yatak", null, "Üç Kişilik", 1 },
                    { 4, new DateTime(2025, 2, 10, 22, 36, 13, 225, DateTimeKind.Local).AddTicks(6256), null, "1 büyük + 2 tek kişilik yatak", null, "Dört Kişilik", 1 },
                    { 5, new DateTime(2025, 2, 10, 22, 36, 13, 225, DateTimeKind.Local).AddTicks(6257), null, "Lüks konaklama, özel hizmetler", null, "Kral Dairesi", 1 }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "ModifiedDate", "RoleId", "Status", "UserId" },
                values: new object[] { 1, new DateTime(2025, 2, 10, 22, 36, 13, 267, DateTimeKind.Local).AddTicks(2888), null, null, 1, 1, 1 });

            migrationBuilder.InsertData(
                table: "EmployeeDetails",
                columns: new[] { "Id", "Address", "BirthDate", "CreatedDate", "DeletedDate", "EmployeeId", "HireDate", "ModifiedDate", "PhoneNumber", "Salary", "Status" },
                values: new object[,]
                {
                    { 1, "Köypınar Sokak 00, Gaziantep, Andorra", new DateTime(1998, 8, 21, 15, 51, 55, 984, DateTimeKind.Local).AddTicks(5114), new DateTime(2025, 2, 10, 22, 36, 13, 228, DateTimeKind.Local).AddTicks(2831), null, 1, new DateTime(2015, 11, 28, 13, 56, 44, 31, DateTimeKind.Local).AddTicks(3555), null, "+90-125-361-1-267", 37701.88m, 1 },
                    { 2, "Bayır Sokak 51a, Bingöl, Monako", new DateTime(1972, 7, 8, 10, 55, 8, 895, DateTimeKind.Local).AddTicks(5677), new DateTime(2025, 2, 10, 22, 36, 13, 228, DateTimeKind.Local).AddTicks(2902), null, 2, new DateTime(2019, 8, 14, 15, 3, 26, 942, DateTimeKind.Local).AddTicks(3573), null, "+90-197-123-52-33", 44476.23m, 1 },
                    { 3, "Bandak Sokak 60a, Niğde, Nauru", new DateTime(1995, 1, 6, 7, 13, 42, 887, DateTimeKind.Local).AddTicks(5301), new DateTime(2025, 2, 10, 22, 36, 13, 228, DateTimeKind.Local).AddTicks(2981), null, 3, new DateTime(2021, 4, 28, 21, 16, 5, 32, DateTimeKind.Local).AddTicks(4444), null, "+90-627-430-8-531", 15774.05m, 1 },
                    { 4, "Kekeçoğlu Sokak 01, Yalova, Komorlar", new DateTime(2002, 10, 29, 22, 3, 28, 34, DateTimeKind.Local).AddTicks(154), new DateTime(2025, 2, 10, 22, 36, 13, 228, DateTimeKind.Local).AddTicks(3065), null, 4, new DateTime(2015, 8, 10, 22, 21, 35, 664, DateTimeKind.Local).AddTicks(9160), null, "+90-145-355-3-265", 44455.67m, 1 },
                    { 5, "Okul Sokak 11b, Yozgat, Tanzanya", new DateTime(1985, 8, 1, 22, 41, 56, 836, DateTimeKind.Local).AddTicks(3520), new DateTime(2025, 2, 10, 22, 36, 13, 228, DateTimeKind.Local).AddTicks(3142), null, 5, new DateTime(2018, 2, 1, 11, 11, 23, 525, DateTimeKind.Local).AddTicks(976), null, "+90-705-849-5-764", 35421.81m, 1 },
                    { 6, "Atatürk Bulvarı 98, Van, Nikaragua", new DateTime(1992, 7, 18, 13, 30, 0, 617, DateTimeKind.Local).AddTicks(1857), new DateTime(2025, 2, 10, 22, 36, 13, 228, DateTimeKind.Local).AddTicks(3190), null, 6, new DateTime(2023, 12, 23, 10, 18, 40, 341, DateTimeKind.Local).AddTicks(6127), null, "+90-807-261-9-285", 29491.24m, 1 },
                    { 7, "Kerimoğlu Sokak 80a, Kastamonu, Porto Riko, Amerika", new DateTime(1996, 4, 14, 11, 23, 29, 979, DateTimeKind.Local).AddTicks(2943), new DateTime(2025, 2, 10, 22, 36, 13, 228, DateTimeKind.Local).AddTicks(3261), null, 7, new DateTime(2014, 8, 7, 7, 33, 4, 807, DateTimeKind.Local).AddTicks(4126), null, "+90-531-723-32-18", 40151.25m, 1 },
                    { 8, "Oğuzhan Sokak 40b, Ardahan, Grönland", new DateTime(1972, 2, 10, 21, 7, 33, 275, DateTimeKind.Local).AddTicks(9636), new DateTime(2025, 2, 10, 22, 36, 13, 228, DateTimeKind.Local).AddTicks(3334), null, 8, new DateTime(2021, 8, 5, 11, 31, 43, 375, DateTimeKind.Local).AddTicks(4448), null, "+90-832-364-4-728", 37457.51m, 1 },
                    { 9, "İbn-i Sina Sokak 30, Ağrı, Tayland", new DateTime(1977, 8, 6, 13, 54, 54, 358, DateTimeKind.Local).AddTicks(6240), new DateTime(2025, 2, 10, 22, 36, 13, 228, DateTimeKind.Local).AddTicks(3406), null, 9, new DateTime(2015, 8, 30, 20, 57, 59, 23, DateTimeKind.Local).AddTicks(8921), null, "+90-088-197-9-519", 15506.60m, 1 },
                    { 10, "Ülkü Sokak 19, Bartın, Bermuda, İngiltere", new DateTime(1977, 6, 27, 15, 49, 28, 207, DateTimeKind.Local).AddTicks(651), new DateTime(2025, 2, 10, 22, 36, 13, 228, DateTimeKind.Local).AddTicks(3459), null, 10, new DateTime(2022, 12, 27, 5, 20, 25, 665, DateTimeKind.Local).AddTicks(6344), null, "+90-277-942-25-60", 45103.76m, 1 },
                    { 11, "Atatürk Bulvarı 167, Kastamonu, Anguilla, İngiltere", new DateTime(1985, 1, 12, 14, 26, 8, 851, DateTimeKind.Local).AddTicks(3177), new DateTime(2025, 2, 10, 22, 36, 13, 228, DateTimeKind.Local).AddTicks(3529), null, 11, new DateTime(2021, 10, 10, 20, 57, 49, 256, DateTimeKind.Local).AddTicks(8547), null, "+90-126-819-6-149", 28447.21m, 1 },
                    { 12, "Dar Sokak 78b, Kırşehir, Venezuela", new DateTime(1981, 7, 16, 7, 43, 24, 759, DateTimeKind.Local).AddTicks(3144), new DateTime(2025, 2, 10, 22, 36, 13, 228, DateTimeKind.Local).AddTicks(3589), null, 12, new DateTime(2022, 7, 10, 8, 51, 30, 119, DateTimeKind.Local).AddTicks(2671), null, "+90-618-012-66-45", 39042.29m, 1 },
                    { 13, "Lütfi Karadirek Caddesi 181, Amasya, Almanya", new DateTime(1983, 8, 4, 9, 41, 35, 334, DateTimeKind.Local).AddTicks(6045), new DateTime(2025, 2, 10, 22, 36, 13, 228, DateTimeKind.Local).AddTicks(3666), null, 13, new DateTime(2023, 1, 15, 9, 52, 16, 808, DateTimeKind.Local).AddTicks(5361), null, "+90-497-035-6-387", 43254.27m, 1 },
                    { 14, "Sağlık Sokak 8, İzmir, Kamboçya", new DateTime(1985, 10, 23, 20, 17, 53, 848, DateTimeKind.Local).AddTicks(4838), new DateTime(2025, 2, 10, 22, 36, 13, 228, DateTimeKind.Local).AddTicks(3713), null, 14, new DateTime(2023, 1, 22, 21, 39, 13, 844, DateTimeKind.Local).AddTicks(9740), null, "+90-299-051-6-883", 24147.87m, 1 },
                    { 15, "Ali Çetinkaya Caddesi 51a, Karabük, Papua Yeni Gine", new DateTime(1969, 6, 28, 11, 42, 58, 715, DateTimeKind.Local).AddTicks(7767), new DateTime(2025, 2, 10, 22, 36, 13, 228, DateTimeKind.Local).AddTicks(3797), null, 15, new DateTime(2014, 11, 8, 23, 41, 28, 670, DateTimeKind.Local).AddTicks(3476), null, "+90-819-244-64-77", 42141.61m, 1 },
                    { 16, "Sarıkaya Caddesi 185, Uşak, Honduras", new DateTime(1999, 3, 26, 7, 36, 3, 993, DateTimeKind.Local).AddTicks(7914), new DateTime(2025, 2, 10, 22, 36, 13, 228, DateTimeKind.Local).AddTicks(3866), null, 16, new DateTime(2016, 1, 10, 23, 40, 44, 429, DateTimeKind.Local).AddTicks(3713), null, "+90-309-659-0-128", 38440.51m, 1 },
                    { 17, "Oğuzhan Sokak 89c, Yozgat, Cayman Adaları, İngiltere", new DateTime(1981, 3, 5, 10, 32, 38, 581, DateTimeKind.Local).AddTicks(7482), new DateTime(2025, 2, 10, 22, 36, 13, 228, DateTimeKind.Local).AddTicks(3944), null, 17, new DateTime(2015, 1, 25, 4, 51, 22, 76, DateTimeKind.Local).AddTicks(5369), null, "+90-971-484-08-20", 18024.41m, 1 },
                    { 18, "Güven Yaka Sokak 9, Afyon, Moritanya", new DateTime(2004, 12, 19, 13, 29, 37, 267, DateTimeKind.Local).AddTicks(1247), new DateTime(2025, 2, 10, 22, 36, 13, 228, DateTimeKind.Local).AddTicks(3992), null, 18, new DateTime(2015, 6, 8, 17, 36, 13, 642, DateTimeKind.Local).AddTicks(3555), null, "+90-148-392-66-48", 38152.87m, 1 },
                    { 19, "Sevgi Sokak 32a, Tekirdağ, Suriye", new DateTime(1983, 1, 14, 7, 51, 35, 180, DateTimeKind.Local).AddTicks(682), new DateTime(2025, 2, 10, 22, 36, 13, 228, DateTimeKind.Local).AddTicks(4060), null, 19, new DateTime(2023, 10, 25, 5, 13, 11, 170, DateTimeKind.Local).AddTicks(3446), null, "+90-278-399-2-041", 48401.59m, 1 },
                    { 20, "Ali Çetinkaya Caddesi 98a, Yalova, Çin", new DateTime(1982, 9, 18, 9, 43, 26, 82, DateTimeKind.Local).AddTicks(5666), new DateTime(2025, 2, 10, 22, 36, 13, 228, DateTimeKind.Local).AddTicks(4127), null, 20, new DateTime(2016, 4, 15, 10, 3, 15, 782, DateTimeKind.Local).AddTicks(7129), null, "+90-805-812-5-613", 30632.19m, 1 },
                    { 21, "Harman Altı Sokak 58c, Siirt, Monako", new DateTime(1968, 6, 1, 16, 37, 57, 60, DateTimeKind.Local).AddTicks(2407), new DateTime(2025, 2, 10, 22, 36, 13, 228, DateTimeKind.Local).AddTicks(4197), null, 21, new DateTime(2015, 2, 27, 15, 0, 29, 881, DateTimeKind.Local).AddTicks(6904), null, "+90-739-304-0-953", 34829.41m, 1 },
                    { 22, "Dağınık Evler Sokak 0, Bursa, Lesotho", new DateTime(1980, 12, 5, 12, 33, 29, 428, DateTimeKind.Local).AddTicks(6344), new DateTime(2025, 2, 10, 22, 36, 13, 228, DateTimeKind.Local).AddTicks(4243), null, 22, new DateTime(2023, 3, 28, 3, 29, 24, 882, DateTimeKind.Local).AddTicks(8645), null, "+90-881-510-4-914", 17412.73m, 1 },
                    { 23, "Kekeçoğlu Sokak 01c, K.maraş, Sırbistan", new DateTime(1983, 4, 24, 23, 19, 3, 382, DateTimeKind.Local).AddTicks(5952), new DateTime(2025, 2, 10, 22, 36, 13, 228, DateTimeKind.Local).AddTicks(4303), null, 23, new DateTime(2017, 7, 27, 0, 12, 28, 63, DateTimeKind.Local).AddTicks(2575), null, "+90-932-959-0-390", 47401.04m, 1 },
                    { 24, "Güven Yaka Sokak 72, Bingöl, Angola", new DateTime(1989, 7, 13, 13, 57, 43, 527, DateTimeKind.Local).AddTicks(8212), new DateTime(2025, 2, 10, 22, 36, 13, 228, DateTimeKind.Local).AddTicks(4378), null, 24, new DateTime(2021, 1, 15, 22, 32, 13, 445, DateTimeKind.Local).AddTicks(3005), null, "+90-063-514-40-89", 43808.16m, 1 },
                    { 25, "Nalbant Sokak 59, Diyarbakır, Cibuti", new DateTime(1981, 12, 9, 23, 0, 0, 458, DateTimeKind.Local).AddTicks(6852), new DateTime(2025, 2, 10, 22, 36, 13, 228, DateTimeKind.Local).AddTicks(4452), null, 25, new DateTime(2014, 6, 19, 5, 49, 13, 559, DateTimeKind.Local).AddTicks(8996), null, "+90-705-982-6-156", 40198.04m, 1 },
                    { 26, "Gül Sokak 169, Gümüşhane, İspanya", new DateTime(1983, 3, 21, 10, 50, 7, 654, DateTimeKind.Local).AddTicks(9247), new DateTime(2025, 2, 10, 22, 36, 13, 228, DateTimeKind.Local).AddTicks(4498), null, 26, new DateTime(2017, 7, 6, 5, 49, 16, 657, DateTimeKind.Local).AddTicks(6561), null, "+90-802-401-42-12", 37369.21m, 1 },
                    { 27, "Okul Sokak 81c, Bilecik, Birleşik Arap Emirlikleri", new DateTime(2003, 11, 8, 23, 16, 49, 571, DateTimeKind.Local).AddTicks(2056), new DateTime(2025, 2, 10, 22, 36, 13, 228, DateTimeKind.Local).AddTicks(4583), null, 27, new DateTime(2016, 12, 10, 2, 50, 59, 534, DateTimeKind.Local).AddTicks(7595), null, "+90-958-039-38-72", 31970.99m, 1 },
                    { 28, "Ergenekon Sokak   46b, Çanakkale, Türkiye", new DateTime(1985, 7, 18, 8, 35, 9, 188, DateTimeKind.Local).AddTicks(9241), new DateTime(2025, 2, 10, 22, 36, 13, 228, DateTimeKind.Local).AddTicks(4653), null, 28, new DateTime(2015, 5, 9, 23, 39, 34, 304, DateTimeKind.Local).AddTicks(1508), null, "+90-687-316-77-17", 22685.21m, 1 },
                    { 29, "Yunus Emre Sokak 26b, Adana, Monako", new DateTime(1988, 4, 5, 12, 8, 19, 505, DateTimeKind.Local).AddTicks(8414), new DateTime(2025, 2, 10, 22, 36, 13, 228, DateTimeKind.Local).AddTicks(4698), null, 29, new DateTime(2022, 11, 24, 3, 30, 50, 652, DateTimeKind.Local).AddTicks(327), null, "+90-243-686-16-47", 46178.39m, 1 },
                    { 30, "Dar Sokak 2, Sinop, Kenya", new DateTime(1971, 10, 28, 21, 15, 53, 734, DateTimeKind.Local).AddTicks(4541), new DateTime(2025, 2, 10, 22, 36, 13, 228, DateTimeKind.Local).AddTicks(4764), null, 30, new DateTime(2015, 7, 18, 4, 16, 18, 840, DateTimeKind.Local).AddTicks(7731), null, "+90-293-694-28-03", 30803.06m, 1 },
                    { 31, "Oğuzhan Sokak 9, Konya, Tonga", new DateTime(1983, 10, 12, 12, 51, 32, 636, DateTimeKind.Local).AddTicks(1962), new DateTime(2025, 2, 10, 22, 36, 13, 228, DateTimeKind.Local).AddTicks(4834), null, 31, new DateTime(2016, 11, 29, 23, 17, 43, 501, DateTimeKind.Local).AddTicks(4784), null, "+90-909-153-7-569", 17243.63m, 1 },
                    { 32, "Atatürk Bulvarı 8, Bayburt, Endonezya", new DateTime(1988, 12, 7, 10, 4, 55, 444, DateTimeKind.Local).AddTicks(6028), new DateTime(2025, 2, 10, 22, 36, 13, 228, DateTimeKind.Local).AddTicks(4902), null, 32, new DateTime(2015, 7, 5, 9, 2, 6, 189, DateTimeKind.Local).AddTicks(9131), null, "+90-130-850-40-09", 34102.49m, 1 },
                    { 33, "Saygılı Sokak 37c, Kırklareli, Jamaika", new DateTime(1968, 7, 24, 0, 36, 51, 265, DateTimeKind.Local).AddTicks(5458), new DateTime(2025, 2, 10, 22, 36, 13, 228, DateTimeKind.Local).AddTicks(4952), null, 33, new DateTime(2022, 12, 23, 0, 40, 45, 397, DateTimeKind.Local).AddTicks(9853), null, "+90-457-644-5-752", 24475.33m, 1 },
                    { 34, "Mevlana Sokak 11, Şırnak, İspanya", new DateTime(2005, 12, 4, 22, 7, 39, 561, DateTimeKind.Local).AddTicks(1443), new DateTime(2025, 2, 10, 22, 36, 13, 228, DateTimeKind.Local).AddTicks(5010), null, 34, new DateTime(2019, 6, 17, 10, 27, 51, 714, DateTimeKind.Local).AddTicks(4342), null, "+90-991-640-46-48", 36679.47m, 1 },
                    { 35, "Afyon Kaya Sokak 88, Şanlıurfa, Meksika", new DateTime(1968, 9, 8, 1, 55, 58, 400, DateTimeKind.Local).AddTicks(5579), new DateTime(2025, 2, 10, 22, 36, 13, 228, DateTimeKind.Local).AddTicks(5084), null, 35, new DateTime(2014, 8, 21, 1, 50, 4, 37, DateTimeKind.Local).AddTicks(8765), null, "+90-731-290-71-77", 20995.96m, 1 },
                    { 36, "Gül Sokak 00a, Sinop, Japonya", new DateTime(2002, 8, 25, 15, 41, 17, 329, DateTimeKind.Local).AddTicks(5510), new DateTime(2025, 2, 10, 22, 36, 13, 228, DateTimeKind.Local).AddTicks(5158), null, 36, new DateTime(2019, 9, 12, 14, 39, 38, 785, DateTimeKind.Local).AddTicks(9834), null, "+90-935-958-09-93", 31506.61m, 1 },
                    { 37, "Kocatepe Caddesi 90, Kırıkkale, Slovenya", new DateTime(1982, 1, 20, 6, 21, 9, 224, DateTimeKind.Local).AddTicks(2860), new DateTime(2025, 2, 10, 22, 36, 13, 228, DateTimeKind.Local).AddTicks(5204), null, 37, new DateTime(2023, 3, 25, 20, 54, 44, 312, DateTimeKind.Local).AddTicks(7831), null, "+90-310-018-04-49", 45314.01m, 1 },
                    { 38, "Sağlık Sokak 430, Sivas, Portekiz", new DateTime(1996, 4, 14, 9, 15, 37, 407, DateTimeKind.Local).AddTicks(3792), new DateTime(2025, 2, 10, 22, 36, 13, 228, DateTimeKind.Local).AddTicks(5271), null, 38, new DateTime(2014, 12, 6, 19, 5, 2, 395, DateTimeKind.Local).AddTicks(3011), null, "+90-440-324-83-04", 32657.98m, 1 },
                    { 39, "Dar Sokak 57a, Sakarya, Karadağ", new DateTime(1998, 5, 1, 7, 31, 3, 260, DateTimeKind.Local).AddTicks(1750), new DateTime(2025, 2, 10, 22, 36, 13, 228, DateTimeKind.Local).AddTicks(5337), null, 39, new DateTime(2016, 4, 4, 10, 20, 4, 887, DateTimeKind.Local).AddTicks(9700), null, "+90-663-118-46-74", 44408.06m, 1 },
                    { 40, "Sevgi Sokak 421, Burdur, İzlanda", new DateTime(1983, 7, 19, 3, 19, 18, 86, DateTimeKind.Local).AddTicks(2200), new DateTime(2025, 2, 10, 22, 36, 13, 228, DateTimeKind.Local).AddTicks(5402), null, 40, new DateTime(2021, 9, 5, 11, 50, 27, 713, DateTimeKind.Local).AddTicks(9176), null, "+90-454-444-6-834", 20715.71m, 1 },
                    { 41, "Sıran Söğüt Sokak 9, Uşak, Karadağ", new DateTime(1972, 8, 18, 12, 23, 10, 596, DateTimeKind.Local).AddTicks(8024), new DateTime(2025, 2, 10, 22, 36, 13, 228, DateTimeKind.Local).AddTicks(5444), null, 41, new DateTime(2021, 9, 10, 18, 18, 52, 419, DateTimeKind.Local).AddTicks(3273), null, "+90-620-905-4-620", 49059.40m, 1 },
                    { 42, "Mevlana Sokak 54, Erzurum, Tonga", new DateTime(2002, 10, 16, 12, 23, 10, 933, DateTimeKind.Local).AddTicks(1894), new DateTime(2025, 2, 10, 22, 36, 13, 228, DateTimeKind.Local).AddTicks(5514), null, 42, new DateTime(2019, 8, 14, 12, 35, 14, 303, DateTimeKind.Local).AddTicks(3028), null, "+90-864-040-90-47", 17956.04m, 1 },
                    { 43, "Sarıkaya Caddesi 24c, Bartın, Kosta Rika", new DateTime(2006, 8, 14, 2, 6, 39, 493, DateTimeKind.Local).AddTicks(7295), new DateTime(2025, 2, 10, 22, 36, 13, 228, DateTimeKind.Local).AddTicks(5578), null, 43, new DateTime(2021, 7, 7, 16, 24, 0, 284, DateTimeKind.Local).AddTicks(5372), null, "+90-811-924-94-77", 16721.86m, 1 },
                    { 44, "Tevfik Fikret Caddesi 0, Manisa, Burundi", new DateTime(1975, 3, 17, 17, 47, 44, 907, DateTimeKind.Local).AddTicks(5432), new DateTime(2025, 2, 10, 22, 36, 13, 228, DateTimeKind.Local).AddTicks(5622), null, 44, new DateTime(2019, 9, 18, 8, 36, 49, 183, DateTimeKind.Local).AddTicks(6589), null, "+90-813-966-1-093", 27449.91m, 1 }
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Floor", "ModifiedDate", "PricePerNight", "RoomNumber", "RoomStatus", "RoomTypeId", "Status" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 2, 10, 22, 36, 13, 227, DateTimeKind.Local).AddTicks(1289), null, 1, null, 99.21m, "177", 3, 1, 1 },
                    { 2, new DateTime(2025, 2, 10, 22, 36, 13, 227, DateTimeKind.Local).AddTicks(1303), null, 1, null, 181.09m, "185", 3, 1, 1 },
                    { 3, new DateTime(2025, 2, 10, 22, 36, 13, 227, DateTimeKind.Local).AddTicks(1306), null, 1, null, 167.79m, "185", 1, 3, 1 },
                    { 4, new DateTime(2025, 2, 10, 22, 36, 13, 227, DateTimeKind.Local).AddTicks(1311), null, 1, null, 75.11m, "105", 2, 3, 1 },
                    { 5, new DateTime(2025, 2, 10, 22, 36, 13, 227, DateTimeKind.Local).AddTicks(1319), null, 1, null, 158.03m, "156", 1, 3, 1 },
                    { 6, new DateTime(2025, 2, 10, 22, 36, 13, 227, DateTimeKind.Local).AddTicks(1322), null, 1, null, 101.91m, "174", 2, 1, 1 },
                    { 7, new DateTime(2025, 2, 10, 22, 36, 13, 227, DateTimeKind.Local).AddTicks(1325), null, 1, null, 67.77m, "134", 2, 3, 1 },
                    { 8, new DateTime(2025, 2, 10, 22, 36, 13, 227, DateTimeKind.Local).AddTicks(1328), null, 1, null, 116.62m, "147", 3, 3, 1 },
                    { 9, new DateTime(2025, 2, 10, 22, 36, 13, 227, DateTimeKind.Local).AddTicks(1330), null, 1, null, 71.50m, "151", 2, 1, 1 },
                    { 10, new DateTime(2025, 2, 10, 22, 36, 13, 227, DateTimeKind.Local).AddTicks(1333), null, 1, null, 57.57m, "157", 2, 1, 1 },
                    { 11, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2, null, 117.54m, "282", 1, 2, 0 },
                    { 12, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2, null, 180.31m, "213", 3, 2, 0 },
                    { 13, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2, null, 178.38m, "220", 2, 1, 0 },
                    { 14, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2, null, 199.30m, "252", 2, 1, 0 },
                    { 15, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2, null, 183.84m, "247", 3, 2, 0 },
                    { 16, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2, null, 177.57m, "289", 3, 2, 0 },
                    { 17, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2, null, 122.02m, "200", 1, 2, 0 },
                    { 18, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2, null, 144.92m, "250", 1, 2, 0 },
                    { 19, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2, null, 148.03m, "282", 1, 1, 0 },
                    { 20, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2, null, 188.86m, "218", 1, 1, 0 },
                    { 21, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 3, null, 290.58m, "363", 2, 3, 0 },
                    { 22, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 3, null, 249.12m, "350", 2, 3, 0 },
                    { 23, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 3, null, 171.12m, "385", 2, 3, 0 },
                    { 24, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 3, null, 277.32m, "376", 1, 2, 0 },
                    { 25, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 3, null, 218.82m, "359", 1, 3, 0 },
                    { 26, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 3, null, 176.52m, "328", 1, 2, 0 },
                    { 27, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 3, null, 179.19m, "388", 2, 3, 0 },
                    { 28, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 3, null, 239.46m, "347", 1, 2, 0 },
                    { 29, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 3, null, 187.87m, "393", 3, 2, 0 },
                    { 30, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 3, null, 237.12m, "379", 1, 3, 0 },
                    { 31, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 4, null, 324.99m, "468", 1, 2, 0 },
                    { 32, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 4, null, 460.50m, "424", 2, 2, 0 },
                    { 33, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 4, null, 335.59m, "478", 2, 2, 0 },
                    { 34, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 4, null, 249.26m, "494", 1, 4, 0 },
                    { 35, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 4, null, 209.14m, "418", 3, 2, 0 },
                    { 36, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 4, null, 391.61m, "413", 3, 4, 0 },
                    { 37, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 4, null, 396.42m, "413", 1, 2, 0 },
                    { 38, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 4, null, 335.23m, "439", 3, 2, 0 },
                    { 39, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 4, null, 463.24m, "405", 1, 2, 0 },
                    { 40, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 4, null, 228.41m, "488", 2, 2, 0 },
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
                name: "IX_AspNetUserRoles_UserId_RoleId",
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                unique: true);

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
