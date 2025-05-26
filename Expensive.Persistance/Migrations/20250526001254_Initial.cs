using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Expensive.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "Categories",
                schema: "dbo",
                columns: table => new
                {
                    CategorieId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    IsDefault = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    Operation = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    UpdatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    RowGuid = table.Column<string>(type: "nvarchar(450)", nullable: true, defaultValueSql: "NEWID()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategorieId);
                });

            migrationBuilder.CreateTable(
                name: "PaymentMethods",
                schema: "dbo",
                columns: table => new
                {
                    PaymentMethodId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    IsDefault = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    UpdatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    RowGuid = table.Column<string>(type: "nvarchar(450)", nullable: true, defaultValueSql: "NEWID()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentMethods", x => x.PaymentMethodId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                schema: "dbo",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirtsName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    UpdatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    RowGuid = table.Column<string>(type: "nvarchar(450)", nullable: true, defaultValueSql: "NEWID()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "UserCategories",
                schema: "dbo",
                columns: table => new
                {
                    UserCategorieId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CategorieId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    UpdatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    RowGuid = table.Column<string>(type: "nvarchar(450)", nullable: true, defaultValueSql: "NEWID()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserCategories", x => x.UserCategorieId);
                    table.ForeignKey(
                        name: "FK_UserCategories_Categories_CategorieId",
                        column: x => x.CategorieId,
                        principalSchema: "dbo",
                        principalTable: "Categories",
                        principalColumn: "CategorieId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserCategories_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserPaymentMethods",
                schema: "dbo",
                columns: table => new
                {
                    UserPaymentMethodId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    PaymentMethodId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    UpdatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    RowGuid = table.Column<string>(type: "nvarchar(450)", nullable: true, defaultValueSql: "NEWID()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPaymentMethods", x => x.UserPaymentMethodId);
                    table.ForeignKey(
                        name: "FK_UserPaymentMethods_PaymentMethods_PaymentMethodId",
                        column: x => x.PaymentMethodId,
                        principalSchema: "dbo",
                        principalTable: "PaymentMethods",
                        principalColumn: "PaymentMethodId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserPaymentMethods_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Categories",
                columns: new[] { "CategorieId", "CreatedBy", "Description", "IsDefault", "Name", "Operation", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, "Created By Default", "Categoria de gastos del Hogar", true, "Hogar", "EXPENSE", null },
                    { 2, "Created By Default", "Categoria de gastos del Automovil", true, "Automovil", "EXPENSE", null },
                    { 3, "Created By Default", "Categoria de gastos del Mascotas", true, "Mascotas", "EXPENSE", null },
                    { 4, "Created By Default", "Categoria de gastos del Salud", true, "Salud", "EXPENSE", null },
                    { 5, "Created By Default", "Categoria de gastos del Mercado", true, "Mercado", "EXPENSE", null },
                    { 6, "Created By Default", "Categoria de gastos del Entretenimiento", true, "Entretenimiento", "EXPENSE", null },
                    { 7, "Created By Default", "Categoria de ingresos del ahorro", true, "Ahorros", "INCOME", null },
                    { 8, "Created By Default", "Categoria de ingresos del sueldo", true, "Sueldo", "INCOME", null }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "PaymentMethods",
                columns: new[] { "PaymentMethodId", "CreatedBy", "Description", "IsDefault", "Name", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, "Created By Default", "Metodo de pago en efectivo", true, "Efectivo", null },
                    { 2, "Created By Default", "Metodo de pago en Tarjeta de Credito", true, "Tarjeta de Credito", null },
                    { 3, "Created By Default", "Metodo de pago en Tarjeta de Debito", true, "Tarjeta de Debito", null }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Users",
                columns: new[] { "UserId", "CreatedBy", "Email", "FirtsName", "LastName", "Password", "UpdatedBy", "UserName" },
                values: new object[] { 1, "System", "miguelmodd@gmail.com", "Miguel Jose", "Mata Ramos", "jose@123A", null, "miguelmodd" });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "UserCategories",
                columns: new[] { "UserCategorieId", "CategorieId", "CreatedBy", "UpdatedBy", "UserId" },
                values: new object[,]
                {
                    { 1L, 1, "Created By Default", null, 1 },
                    { 2L, 2, "Created By Default", null, 1 },
                    { 3L, 3, "Created By Default", null, 1 },
                    { 4L, 4, "Created By Default", null, 1 },
                    { 5L, 5, "Created By Default", null, 1 },
                    { 6L, 6, "Created By Default", null, 1 },
                    { 7L, 7, "Created By Default", null, 1 },
                    { 8L, 8, "Created By Default", null, 1 }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "UserPaymentMethods",
                columns: new[] { "UserPaymentMethodId", "CreatedBy", "PaymentMethodId", "UpdatedBy", "UserId" },
                values: new object[,]
                {
                    { 1, "Created By Default", 1, null, 1 },
                    { 2, "Created By Default", 2, null, 1 },
                    { 3, "Created By Default", 3, null, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Categories_Name",
                schema: "dbo",
                table: "Categories",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Categories_RowGuid",
                schema: "dbo",
                table: "Categories",
                column: "RowGuid",
                unique: true,
                filter: "[RowGuid] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentMethods_Name",
                schema: "dbo",
                table: "PaymentMethods",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PaymentMethods_RowGuid",
                schema: "dbo",
                table: "PaymentMethods",
                column: "RowGuid",
                unique: true,
                filter: "[RowGuid] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_UserCategories_CategorieId",
                schema: "dbo",
                table: "UserCategories",
                column: "CategorieId");

            migrationBuilder.CreateIndex(
                name: "IX_UserCategories_RowGuid",
                schema: "dbo",
                table: "UserCategories",
                column: "RowGuid",
                unique: true,
                filter: "[RowGuid] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_UserCategories_UserId_CategorieId",
                schema: "dbo",
                table: "UserCategories",
                columns: new[] { "UserId", "CategorieId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Categories_RowGuid",
                schema: "dbo",
                table: "UserPaymentMethods",
                column: "RowGuid",
                unique: true,
                filter: "[RowGuid] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_UserPaymentMethods_PaymentMethodId",
                schema: "dbo",
                table: "UserPaymentMethods",
                column: "PaymentMethodId");

            migrationBuilder.CreateIndex(
                name: "IX_UserPaymentMethods_UserId_PaymentMethodId",
                schema: "dbo",
                table: "UserPaymentMethods",
                columns: new[] { "UserId", "PaymentMethodId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Categories_RowGuid",
                schema: "dbo",
                table: "Users",
                column: "RowGuid",
                unique: true,
                filter: "[RowGuid] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                schema: "dbo",
                table: "Users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserName",
                schema: "dbo",
                table: "Users",
                column: "UserName",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserCategories",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "UserPaymentMethods",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Categories",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "PaymentMethods",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Users",
                schema: "dbo");
        }
    }
}
