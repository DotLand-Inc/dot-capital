using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dotland.DotCapital.WebApi.Infrastructure.Data.Migrations.Tenant
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ACCOUNTS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NAME = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SLUG = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ACCOUNT_TYPE = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PARENT_ACCOUNT_ID = table.Column<int>(type: "int", nullable: false),
                    CODE = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DESCRIPTION = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ACTIVE = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    INDEX = table.Column<int>(type: "int", nullable: false),
                    PREDEFINED = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    AMOUNT = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    CURRENCY_CODE = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SEEDED_AT = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CREATED_AT = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UPDATED_AT = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    PLAID_ACCOUNT_ID = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ACCOUNT_MASK = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BANK_BALANCE = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    UNCATEGORIZED_TRANSACTIONS = table.Column<int>(type: "int", nullable: false),
                    IS_SYSTEM_ACCOUNT = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    IS_FEEDS_ACTIVE = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    IS_SYNCING_OWNER = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    LAST_FEEDS_UPDATED_AT = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    PLAID_ITEM_ID = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ACCOUNTS", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ACCOUNTS_TRANSACTIONS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CREDIT = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    DEBIT = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    CURRENCY_CODE = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EXCHANGE_RATE = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    TRANSACTION_TYPE = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    REFERENCE_TYPE = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    REFERENCE_ID = table.Column<int>(type: "int", nullable: false),
                    ACCOUNT_ID = table.Column<int>(type: "int", nullable: false),
                    CONTACT_TYPE = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CONTACT_ID = table.Column<int>(type: "int", nullable: false),
                    TRANSACTION_NUMBER = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    REFERENCE_NUMBER = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ITEM_ID = table.Column<int>(type: "int", nullable: false),
                    ITEM_QUANTITY = table.Column<int>(type: "int", nullable: false),
                    NOTE = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    USER_ID = table.Column<int>(type: "int", nullable: false),
                    INDEX_GROUP = table.Column<int>(type: "int", nullable: false),
                    INDEX = table.Column<int>(type: "int", nullable: false),
                    DATE = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CREATED_AT = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    COSTABLE = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    BRANCH_ID = table.Column<int>(type: "int", nullable: false),
                    PROJECT_ID = table.Column<int>(type: "int", nullable: false),
                    TAX_RATE_ID = table.Column<int>(type: "int", nullable: false),
                    TAX_RATE = table.Column<decimal>(type: "decimal(65,30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ACCOUNTS_TRANSACTIONS", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "BANK_RULE_CONDITIONS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    RULE_ID = table.Column<int>(type: "int", nullable: false),
                    FIELD = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    COMPARATOR = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    VALUE = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BANK_RULE_CONDITIONS", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "BANK_RULES",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NAME = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ORDER = table.Column<int>(type: "int", nullable: false),
                    APPLY_IF_ACCOUNT_ID = table.Column<int>(type: "int", nullable: false),
                    APPLY_IF_TRANSACTION_TYPE = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ASSIGN_CATEGORY = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ASSIGN_ACCOUNT_ID = table.Column<int>(type: "int", nullable: false),
                    ASSIGN_PAYEE = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ASSIGN_MEMO = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CONDITIONS_TYPE = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CREATED_AT = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UPDATED_AT = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BANK_RULES", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "BILL_LOCATED_COST_ENTRIES",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    COST = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    ENTRY_ID = table.Column<int>(type: "int", nullable: false),
                    BILL_LOCATED_COST_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BILL_LOCATED_COST_ENTRIES", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "BILL_LOCATED_COSTS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    AMOUNT = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    CURRENCY_CODE = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EXCHANGE_RATE = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    FROM_TRANSACTION_ID = table.Column<int>(type: "int", nullable: false),
                    FROM_TRANSACTION_TYPE = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FROM_TRANSACTION_ENTRY_ID = table.Column<int>(type: "int", nullable: false),
                    ALLOCATION_METHOD = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    COST_ACCOUNT_ID = table.Column<int>(type: "int", nullable: false),
                    DESCRIPTION = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BILL_ID = table.Column<int>(type: "int", nullable: false),
                    CREATED_AT = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UPDATED_AT = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BILL_LOCATED_COSTS", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "BILLS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    VENDOR_ID = table.Column<int>(type: "int", nullable: false),
                    BILL_NUMBER = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BILL_DATE = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DUE_DATE = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    REFERENCE_NO = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    STATUS = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NOTE = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AMOUNT = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    DISCOUNT = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    DISCOUNT_TYPE = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ADJUSTMENT = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    CURRENCY_CODE = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EXCHANGE_RATE = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    PAYMENT_AMOUNT = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    LANDED_COST_AMOUNT = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    ALLOCATED_COST_AMOUNT = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    CREDITED_AMOUNT = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    INV_LOT_NUMBER = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    OPENED_AT = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    USER_ID = table.Column<int>(type: "int", nullable: false),
                    CREATED_AT = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UPDATED_AT = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    WAREHOUSE_ID = table.Column<int>(type: "int", nullable: false),
                    BRANCH_ID = table.Column<int>(type: "int", nullable: false),
                    PROJECT_ID = table.Column<int>(type: "int", nullable: false),
                    INVOICED_AMOUNT = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    IS_INCLUSIVE_TAX = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    TAX_AMOUNT_WITHHELD = table.Column<decimal>(type: "decimal(65,30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BILLS", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "BILLS_PAYMENTS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    VENDOR_ID = table.Column<int>(type: "int", nullable: false),
                    AMOUNT = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    CURRENCY_CODE = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EXCHANGE_RATE = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    PAYMENT_ACCOUNT_ID = table.Column<int>(type: "int", nullable: false),
                    PAYMENT_NUMBER = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PAYMENT_DATE = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    PAYMENT_METHOD = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    REFERENCE = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    USER_ID = table.Column<int>(type: "int", nullable: false),
                    STATEMENT = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CREATED_AT = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UPDATED_AT = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    BRANCH_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BILLS_PAYMENTS", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "BILLS_PAYMENTS_ENTRIES",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    BILL_PAYMENT_ID = table.Column<int>(type: "int", nullable: false),
                    BILL_ID = table.Column<int>(type: "int", nullable: false),
                    PAYMENT_AMOUNT = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    INDEX = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BILLS_PAYMENTS_ENTRIES", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "BRANCHES",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NAME = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CODE = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ADDRESS = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CITY = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    COUNTRY = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PHONE_NUMBER = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EMAIL = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    WEBSITE = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PRIMARY = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CREATED_AT = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UPDATED_AT = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BRANCHES", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CASHFLOW_TRANSACTION_LINES",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CASHFLOW_TRANSACTION_ID = table.Column<int>(type: "int", nullable: false),
                    CASHFLOW_ACCOUNT_ID = table.Column<int>(type: "int", nullable: false),
                    CREDIT_ACCOUNT_ID = table.Column<int>(type: "int", nullable: false),
                    AMOUNT = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    INDEX = table.Column<int>(type: "int", nullable: false),
                    CREATED_AT = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UPDATED_AT = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CASHFLOW_TRANSACTION_LINES", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CASHFLOW_TRANSACTIONS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DATE = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    AMOUNT = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    CURRENCY_CODE = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EXCHANGE_RATE = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    REFERENCE_NO = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TRANSACTION_TYPE = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TRANSACTION_NUMBER = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DESCRIPTION = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PUBLISHED_AT = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    USER_ID = table.Column<int>(type: "int", nullable: false),
                    BRANCH_ID = table.Column<int>(type: "int", nullable: false),
                    CREATED_AT = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UPDATED_AT = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CASHFLOW_ACCOUNT_ID = table.Column<int>(type: "int", nullable: false),
                    CREDIT_ACCOUNT_ID = table.Column<int>(type: "int", nullable: false),
                    PLAID_TRANSACTION_ID = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UNCATEGORIZED_TRANSACTION_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CASHFLOW_TRANSACTIONS", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CONTACTS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CONTACT_SERVICE = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CONTACT_TYPE = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BALANCE = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    CURRENCY_CODE = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    OPENING_BALANCE = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    OPENING_BALANCE_AT = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    OPENING_BALANCE_EXCHANGE_RATE = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    OPENING_BALANCE_BRANCH_ID = table.Column<int>(type: "int", nullable: false),
                    SALUTATION = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FIRST_NAME = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LAST_NAME = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    COMPANY_NAME = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DISPLAY_NAME = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EMAIL = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    WORK_PHONE = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PERSONAL_PHONE = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    WEBSITE = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BILLING_ADDRESS1 = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BILLING_ADDRESS2 = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BILLING_ADDRESS_CITY = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BILLING_ADDRESS_COUNTRY = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BILLING_ADDRESS_EMAIL = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BILLING_ADDRESS_POSTCODE = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BILLING_ADDRESS_PHONE = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BILLING_ADDRESS_STATE = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SHIPPING_ADDRESS1 = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SHIPPING_ADDRESS2 = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SHIPPING_ADDRESS_CITY = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SHIPPING_ADDRESS_COUNTRY = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SHIPPING_ADDRESS_EMAIL = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SHIPPING_ADDRESS_POSTCODE = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SHIPPING_ADDRESS_PHONE = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SHIPPING_ADDRESS_STATE = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NOTE = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ACTIVE = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CREATED_AT = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UPDATED_AT = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CONTACTS", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CREDIT_NOTE_APPLIED_INVOICE",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    AMOUNT = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    CREDIT_NOTE_ID = table.Column<int>(type: "int", nullable: false),
                    INVOICE_ID = table.Column<int>(type: "int", nullable: false),
                    CREATED_AT = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UPDATED_AT = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CREDIT_NOTE_APPLIED_INVOICE", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CREDIT_NOTES",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CUSTOMER_ID = table.Column<int>(type: "int", nullable: false),
                    CREDIT_NOTE_DATE = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CREDIT_NOTE_NUMBER = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    REFERENCE_NO = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AMOUNT = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    REFUNDED_AMOUNT = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    INVOICES_AMOUNT = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    CURRENCY_CODE = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EXCHANGE_RATE = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    DISCOUNT = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    DISCOUNT_TYPE = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ADJUSTMENT = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    NOTE = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TERMS_CONDITIONS = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    OPENED_AT = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    USER_ID = table.Column<int>(type: "int", nullable: false),
                    CREATED_AT = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UPDATED_AT = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    WAREHOUSE_ID = table.Column<int>(type: "int", nullable: false),
                    BRANCH_ID = table.Column<int>(type: "int", nullable: false),
                    PDF_TEMPLATE_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CREDIT_NOTES", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CURRENCIES",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CURRENCY_NAME = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CURRENCY_CODE = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CURRENCY_SIGN = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CREATED_AT = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UPDATED_AT = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CURRENCIES", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "DOCUMENT_LINKS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    MODEL_REF = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MODEL_ID = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DOCUMENT_ID = table.Column<int>(type: "int", nullable: false),
                    EXPIRES_AT = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CREATED_AT = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UPDATED_AT = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DOCUMENT_LINKS", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "DOCUMENTS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    KEY = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MIME_TYPE = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SIZE = table.Column<int>(type: "int", nullable: false),
                    ORIGIN_NAME = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CREATED_AT = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UPDATED_AT = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DOCUMENTS", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "EXCHANGE_RATES",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CURRENCY_CODE = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EXCHANGE_RATE = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    DATE = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CREATED_AT = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UPDATED_AT = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EXCHANGE_RATES", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "EXPENSE_TRANSACTION_CATEGORIES",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    EXPENSE_ACCOUNT_ID = table.Column<int>(type: "int", nullable: false),
                    INDEX = table.Column<int>(type: "int", nullable: false),
                    DESCRIPTION = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AMOUNT = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    ALLOCATED_COST_AMOUNT = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    LANDED_COST = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    EXPENSE_ID = table.Column<int>(type: "int", nullable: false),
                    CREATED_AT = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UPDATED_AT = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    PROJECT_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EXPENSE_TRANSACTION_CATEGORIES", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "EXPENSES_TRANSACTIONS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CURRENCY_CODE = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EXCHANGE_RATE = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    DESCRIPTION = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PAYMENT_ACCOUNT_ID = table.Column<int>(type: "int", nullable: false),
                    PAYEE_ID = table.Column<int>(type: "int", nullable: false),
                    REFERENCE_NO = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TOTAL_AMOUNT = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    LANDED_COST_AMOUNT = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    ALLOCATED_COST_AMOUNT = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    PUBLISHED_AT = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    USER_ID = table.Column<int>(type: "int", nullable: false),
                    BRANCH_ID = table.Column<int>(type: "int", nullable: false),
                    PAYMENT_DATE = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CREATED_AT = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UPDATED_AT = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    PROJECT_ID = table.Column<int>(type: "int", nullable: false),
                    INVOICED_AMOUNT = table.Column<decimal>(type: "decimal(65,30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EXPENSES_TRANSACTIONS", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "INVENTORY_ADJUSTMENTS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DATE = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    TYPE = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ADJUSTMENT_ACCOUNT_ID = table.Column<int>(type: "int", nullable: false),
                    REASON = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    REFERENCE_NO = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DESCRIPTION = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    USER_ID = table.Column<int>(type: "int", nullable: false),
                    PUBLISHED_AT = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CREATED_AT = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UPDATED_AT = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    BRANCH_ID = table.Column<int>(type: "int", nullable: false),
                    WAREHOUSE_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_INVENTORY_ADJUSTMENTS", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "INVENTORY_ADJUSTMENTS_ENTRIES",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ADJUSTMENT_ID = table.Column<int>(type: "int", nullable: false),
                    INDEX = table.Column<int>(type: "int", nullable: false),
                    ITEM_ID = table.Column<int>(type: "int", nullable: false),
                    QUANTITY = table.Column<int>(type: "int", nullable: false),
                    COST = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    VALUE = table.Column<decimal>(type: "decimal(65,30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_INVENTORY_ADJUSTMENTS_ENTRIES", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "INVENTORY_COST_LOT_TRACKER",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DATE = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DIRECTION = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ITEM_ID = table.Column<int>(type: "int", nullable: false),
                    QUANTITY = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    RATE = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    REMAINING = table.Column<int>(type: "int", nullable: false),
                    COST = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    TRANSACTION_TYPE = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TRANSACTION_ID = table.Column<int>(type: "int", nullable: false),
                    ENTRY_ID = table.Column<int>(type: "int", nullable: false),
                    COST_ACCOUNT_ID = table.Column<int>(type: "int", nullable: false),
                    INVENTORY_TRANSACTION_ID = table.Column<int>(type: "int", nullable: false),
                    CREATED_AT = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    WAREHOUSE_ID = table.Column<int>(type: "int", nullable: false),
                    BRANCH_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_INVENTORY_COST_LOT_TRACKER", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "INVENTORY_TRANSACTION_META",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    TRANSACTION_NUMBER = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DESCRIPTION = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    INVENTORY_TRANSACTION_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_INVENTORY_TRANSACTION_META", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "INVENTORY_TRANSACTIONS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DATE = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DIRECTION = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ITEM_ID = table.Column<int>(type: "int", nullable: false),
                    QUANTITY = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    RATE = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    TRANSACTION_TYPE = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TRANSACTION_ID = table.Column<int>(type: "int", nullable: false),
                    ENTRY_ID = table.Column<int>(type: "int", nullable: false),
                    COST_ACCOUNT_ID = table.Column<int>(type: "int", nullable: false),
                    CREATED_AT = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UPDATED_AT = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    WAREHOUSE_ID = table.Column<int>(type: "int", nullable: false),
                    BRANCH_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_INVENTORY_TRANSACTIONS", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ITEMS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NAME = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TYPE = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CODE = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SELLABLE = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    PURCHASABLE = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    SELL_PRICE = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    COST_PRICE = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    PICTURE_URI = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    COST_ACCOUNT_ID = table.Column<int>(type: "int", nullable: false),
                    SELL_ACCOUNT_ID = table.Column<int>(type: "int", nullable: false),
                    INVENTORY_ACCOUNT_ID = table.Column<int>(type: "int", nullable: false),
                    SELL_DESCRIPTION = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PURCHASE_DESCRIPTION = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    QUANTITY_ON_HAND = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    LANDED_COST = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    NOTE = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ACTIVE = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CATEGORY_ID = table.Column<int>(type: "int", nullable: false),
                    USER_ID = table.Column<int>(type: "int", nullable: false),
                    CREATED_AT = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UPDATED_AT = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    SELL_TAX_RATE_ID = table.Column<int>(type: "int", nullable: false),
                    PURCHASE_TAX_RATE_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ITEMS", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ITEMS_CATEGORIES",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NAME = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DESCRIPTION = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    USER_ID = table.Column<int>(type: "int", nullable: false),
                    COST_ACCOUNT_ID = table.Column<int>(type: "int", nullable: false),
                    SELL_ACCOUNT_ID = table.Column<int>(type: "int", nullable: false),
                    INVENTORY_ACCOUNT_ID = table.Column<int>(type: "int", nullable: false),
                    COST_METHOD = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CREATED_AT = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UPDATED_AT = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ITEMS_CATEGORIES", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ITEMS_ENTRIES",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    REFERENCE_TYPE = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    REFERENCE_ID = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    INDEX = table.Column<int>(type: "int", nullable: false),
                    ITEM_ID = table.Column<int>(type: "int", nullable: false),
                    DESCRIPTION = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DISCOUNT = table.Column<int>(type: "int", nullable: false),
                    DISCOUNT_TYPE = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    QUANTITY = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    RATE = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    SELL_ACCOUNT_ID = table.Column<int>(type: "int", nullable: false),
                    COST_ACCOUNT_ID = table.Column<int>(type: "int", nullable: false),
                    LANDED_COST = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    ALLOCATED_COST_AMOUNT = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    CREATED_AT = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UPDATED_AT = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    WAREHOUSE_ID = table.Column<int>(type: "int", nullable: false),
                    PROJECT_ID = table.Column<int>(type: "int", nullable: false),
                    PROJECT_REF_ID = table.Column<int>(type: "int", nullable: false),
                    PROJECT_REF_TYPE = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PROJECT_REF_INVOICED_AMOUNT = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    IS_INCLUSIVE_TAX = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    TAX_RATE_ID = table.Column<int>(type: "int", nullable: false),
                    TAX_RATE = table.Column<decimal>(type: "decimal(65,30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ITEMS_ENTRIES", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ITEMS_WAREHOUSES_QUANTITY",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ITEM_ID = table.Column<int>(type: "int", nullable: false),
                    WAREHOUSE_ID = table.Column<int>(type: "int", nullable: false),
                    QUANTITY_ON_HAND = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ITEMS_WAREHOUSES_QUANTITY", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "MANUAL_JOURNALS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    JOURNAL_NUMBER = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    REFERENCE = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    JOURNAL_TYPE = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AMOUNT = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    CURRENCY_CODE = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EXCHANGE_RATE = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    DATE = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DESCRIPTION = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PUBLISHED_AT = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ATTACHMENT_FILE = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    USER_ID = table.Column<int>(type: "int", nullable: false),
                    CREATED_AT = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UPDATED_AT = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    BRANCH_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MANUAL_JOURNALS", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "MANUAL_JOURNALS_ENTRIES",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CREDIT = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    DEBIT = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    INDEX = table.Column<int>(type: "int", nullable: false),
                    ACCOUNT_ID = table.Column<int>(type: "int", nullable: false),
                    CONTACT_ID = table.Column<int>(type: "int", nullable: false),
                    NOTE = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MANUAL_JOURNAL_ID = table.Column<int>(type: "int", nullable: false),
                    BRANCH_ID = table.Column<int>(type: "int", nullable: false),
                    PROJECT_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MANUAL_JOURNALS_ENTRIES", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "MATCHED_BANK_TRANSACTIONS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UNCATEGORIZED_TRANSACTION_ID = table.Column<int>(type: "int", nullable: false),
                    REFERENCE_TYPE = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    REFERENCE_ID = table.Column<int>(type: "int", nullable: false),
                    AMOUNT = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    CREATED_AT = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UPDATED_AT = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MATCHED_BANK_TRANSACTIONS", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "MEDIA",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ATTACHMENT_FILE = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CREATED_AT = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UPDATED_AT = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MEDIA", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "MEDIA_LINKS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    MODEL_NAME = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MEDIA_ID = table.Column<int>(type: "int", nullable: false),
                    MODEL_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MEDIA_LINKS", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PAYMENT_INTEGRATIONS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    SERVICE = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NAME = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SLUG = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PAYMENT_ENABLED = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    PAYOUT_ENABLED = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    ACCOUNT_ID = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    OPTIONS = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CREATED_AT = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UPDATED_AT = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PAYMENT_INTEGRATIONS", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PAYMENT_RECEIVES",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CUSTOMER_ID = table.Column<int>(type: "int", nullable: false),
                    PAYMENT_DATE = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    AMOUNT = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    CURRENCY_CODE = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EXCHANGE_RATE = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    REFERENCE_NO = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DEPOSIT_ACCOUNT_ID = table.Column<int>(type: "int", nullable: false),
                    PAYMENT_RECEIVE_NO = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    STATEMENT = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    USER_ID = table.Column<int>(type: "int", nullable: false),
                    CREATED_AT = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UPDATED_AT = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    BRANCH_ID = table.Column<int>(type: "int", nullable: false),
                    STRIPE_PINTENT_ID = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PDF_TEMPLATE_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PAYMENT_RECEIVES", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PAYMENT_RECEIVES_ENTRIES",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PAYMENT_RECEIVE_ID = table.Column<int>(type: "int", nullable: false),
                    INVOICE_ID = table.Column<int>(type: "int", nullable: false),
                    PAYMENT_AMOUNT = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    INDEX = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PAYMENT_RECEIVES_ENTRIES", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PDF_TEMPLATES",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    RESOURCE = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TEMPLATE_NAME = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ATTRIBUTES = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PREDEFINED = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DEFAULT = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CREATED_AT = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UPDATED_AT = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PDF_TEMPLATES", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PLAID_ITEMS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    TENANT_ID = table.Column<int>(type: "int", nullable: false),
                    PLAID_ITEM_ID = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PLAID_INSTITUTION_ID = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PLAID_ACCESS_TOKEN = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LAST_CURSOR = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    STATUS = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CREATED_AT = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UPDATED_AT = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    PAUSED_AT = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PLAID_ITEMS", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PROJECTS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NAME = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CONTACT_ID = table.Column<int>(type: "int", nullable: false),
                    DEADLINE = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    COST_ESTIMATE = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    STATUS = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CREATED_AT = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UPDATED_AT = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PROJECTS", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "RECOGNIZED_BANK_TRANSACTIONS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UNCATEGORIZED_TRANSACTION_ID = table.Column<int>(type: "int", nullable: false),
                    BANK_RULE_ID = table.Column<int>(type: "int", nullable: false),
                    ASSIGNED_CATEGORY = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ASSIGNED_ACCOUNT_ID = table.Column<int>(type: "int", nullable: false),
                    ASSIGNED_PAYEE = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ASSIGNED_MEMO = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CREATED_AT = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UPDATED_AT = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RECOGNIZED_BANK_TRANSACTIONS", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "REFUND_CREDIT_NOTE_TRANSACTIONS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DATE = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CREDIT_NOTE_ID = table.Column<int>(type: "int", nullable: false),
                    AMOUNT = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    CURRENCY_CODE = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EXCHANGE_RATE = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    REFERENCE_NO = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FROM_ACCOUNT_ID = table.Column<int>(type: "int", nullable: false),
                    DESCRIPTION = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BRANCH_ID = table.Column<int>(type: "int", nullable: false),
                    CREATED_AT = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UPDATED_AT = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_REFUND_CREDIT_NOTE_TRANSACTIONS", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "REFUND_VENDOR_CREDIT_TRANSACTIONS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DATE = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    VENDOR_CREDIT_ID = table.Column<int>(type: "int", nullable: false),
                    AMOUNT = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    CURRENCY_CODE = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EXCHANGE_RATE = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    REFERENCE_NO = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DEPOSIT_ACCOUNT_ID = table.Column<int>(type: "int", nullable: false),
                    DESCRIPTION = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BRANCH_ID = table.Column<int>(type: "int", nullable: false),
                    CREATED_AT = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UPDATED_AT = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_REFUND_VENDOR_CREDIT_TRANSACTIONS", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ROLE_PERMISSIONS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ROLE_ID = table.Column<int>(type: "int", nullable: false),
                    SUBJECT = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ABILITY = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    VALUE = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ROLE_PERMISSIONS", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ROLES",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NAME = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SLUG = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DESCRIPTION = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PREDEFINED = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ROLES", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "SALES_ESTIMATES",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    AMOUNT = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    DISCOUNT = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    DISCOUNT_TYPE = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ADJUSTMENT = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    CURRENCY_CODE = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CUSTOMER_ID = table.Column<int>(type: "int", nullable: false),
                    ESTIMATE_DATE = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    EXPIRATION_DATE = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    REFERENCE = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ESTIMATE_NUMBER = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NOTE = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TERMS_CONDITIONS = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SEND_TO_EMAIL = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DELIVERED_AT = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    APPROVED_AT = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    REJECTED_AT = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    USER_ID = table.Column<int>(type: "int", nullable: false),
                    CONVERTED_TO_INVOICE_ID = table.Column<int>(type: "int", nullable: false),
                    CONVERTED_TO_INVOICE_AT = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CREATED_AT = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UPDATED_AT = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    WAREHOUSE_ID = table.Column<int>(type: "int", nullable: false),
                    BRANCH_ID = table.Column<int>(type: "int", nullable: false),
                    EXCHANGE_RATE = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    PDF_TEMPLATE_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SALES_ESTIMATES", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "SALES_INVOICES",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CUSTOMER_ID = table.Column<int>(type: "int", nullable: false),
                    INVOICE_DATE = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DUE_DATE = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    INVOICE_NO = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    REFERENCE_NO = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    INVOICE_MESSAGE = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TERMS_CONDITIONS = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BALANCE = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    PAYMENT_AMOUNT = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    CURRENCY_CODE = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EXCHANGE_RATE = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    CREDITED_AMOUNT = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    DISCOUNT = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    DISCOUNT_TYPE = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ADJUSTMENT = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    INV_LOT_NUMBER = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DELIVERED_AT = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    USER_ID = table.Column<int>(type: "int", nullable: false),
                    CREATED_AT = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UPDATED_AT = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    WRITTENOFF_AMOUNT = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    WRITTENOFF_AT = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    WAREHOUSE_ID = table.Column<int>(type: "int", nullable: false),
                    BRANCH_ID = table.Column<int>(type: "int", nullable: false),
                    WRITTENOFF_EXPENSE_ACCOUNT_ID = table.Column<int>(type: "int", nullable: false),
                    PROJECT_ID = table.Column<int>(type: "int", nullable: false),
                    IS_INCLUSIVE_TAX = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    TAX_AMOUNT_WITHHELD = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    PDF_TEMPLATE_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SALES_INVOICES", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "SALES_RECEIPTS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    AMOUNT = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    DISCOUNT = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    DISCOUNT_TYPE = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ADJUSTMENT = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    CURRENCY_CODE = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EXCHANGE_RATE = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    DEPOSIT_ACCOUNT_ID = table.Column<int>(type: "int", nullable: false),
                    CUSTOMER_ID = table.Column<int>(type: "int", nullable: false),
                    RECEIPT_DATE = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    RECEIPT_NUMBER = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    REFERENCE_NO = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SEND_TO_EMAIL = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RECEIPT_MESSAGE = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    STATEMENT = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CLOSED_AT = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CREATED_AT = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UPDATED_AT = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    WAREHOUSE_ID = table.Column<int>(type: "int", nullable: false),
                    BRANCH_ID = table.Column<int>(type: "int", nullable: false),
                    PDF_TEMPLATE_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SALES_RECEIPTS", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "SETTINGS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    USER_ID = table.Column<int>(type: "int", nullable: false),
                    GROUP = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TYPE = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    KEY = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    VALUE = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SETTINGS", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TASKS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NAME = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CHARGE_TYPE = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RATE = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    ESTIMATE_HOURS = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    ACTUAL_HOURS = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    INVOICED_HOURS = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    PROJECT_ID = table.Column<int>(type: "int", nullable: false),
                    CREATED_AT = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UPDATED_AT = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TASKS", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TAX_RATE_TRANSACTIONS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    TAX_RATE_ID = table.Column<int>(type: "int", nullable: false),
                    REFERENCE_TYPE = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    REFERENCE_ID = table.Column<int>(type: "int", nullable: false),
                    RATE = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    TAX_ACCOUNT_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TAX_RATE_TRANSACTIONS", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TAX_RATES",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NAME = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CODE = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RATE = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    DESCRIPTION = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IS_NON_RECOVERABLE = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    IS_COMPOUND = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    ACTIVE = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DELETED_AT = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CREATED_AT = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UPDATED_AT = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TAX_RATES", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TIMES",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DURATION = table.Column<int>(type: "int", nullable: false),
                    DESCRIPTION = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DATE = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    TASK_ID = table.Column<int>(type: "int", nullable: false),
                    PROJECT_ID = table.Column<int>(type: "int", nullable: false),
                    CREATED_AT = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UPDATED_AT = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TIMES", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TRANSACTIONS_PAYMENT_METHODS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    REFERENCE_ID = table.Column<int>(type: "int", nullable: false),
                    REFERENCE_TYPE = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PAYMENT_INTEGRATION_ID = table.Column<int>(type: "int", nullable: false),
                    ENABLE = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    OPTIONS = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TRANSACTIONS_PAYMENT_METHODS", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "UNCATEGORIZED_CASHFLOW_TRANSACTIONS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DATE = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    AMOUNT = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    CURRENCY_CODE = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    REFERENCE_NO = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PAYEE = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ACCOUNT_ID = table.Column<int>(type: "int", nullable: false),
                    DESCRIPTION = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CATEGORIZE_REF_TYPE = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CATEGORIZE_REF_ID = table.Column<int>(type: "int", nullable: false),
                    CATEGORIZED = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    PLAID_TRANSACTION_ID = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CREATED_AT = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UPDATED_AT = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    RECOGNIZED_TRANSACTION_ID = table.Column<int>(type: "int", nullable: false),
                    EXCLUDED_AT = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    BATCH = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PENDING = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    PENDING_PLAID_TRANSACTION_ID = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UNCATEGORIZED_CASHFLOW_TRANSACTIONS", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "USERS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FIRST_NAME = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LAST_NAME = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EMAIL = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ACTIVE = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    ROLE_ID = table.Column<int>(type: "int", nullable: false),
                    SYSTEM_USER_ID = table.Column<int>(type: "int", nullable: false),
                    INVITED_AT = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    INVITE_ACCEPTED_AT = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CREATED_AT = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UPDATED_AT = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USERS", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "VENDOR_CREDIT_APPLIED_BILL",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    AMOUNT = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    VENDOR_CREDIT_ID = table.Column<int>(type: "int", nullable: false),
                    BILL_ID = table.Column<int>(type: "int", nullable: false),
                    CREATED_AT = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UPDATED_AT = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VENDOR_CREDIT_APPLIED_BILL", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "VENDOR_CREDITS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    VENDOR_ID = table.Column<int>(type: "int", nullable: false),
                    AMOUNT = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    DISCOUNT = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    DISCOUNT_TYPE = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ADJUSTMENT = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    CURRENCY_CODE = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EXCHANGE_RATE = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    VENDOR_CREDIT_DATE = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    VENDOR_CREDIT_NUMBER = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    REFERENCE_NO = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    REFUNDED_AMOUNT = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    INVOICED_AMOUNT = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    NOTE = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    OPENED_AT = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    USER_ID = table.Column<int>(type: "int", nullable: false),
                    CREATED_AT = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UPDATED_AT = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    BRANCH_ID = table.Column<int>(type: "int", nullable: false),
                    WAREHOUSE_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VENDOR_CREDITS", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "VIEW_HAS_COLUMNS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    VIEW_ID = table.Column<int>(type: "int", nullable: false),
                    FIELD_KEY = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    INDEX = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VIEW_HAS_COLUMNS", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "VIEW_ROLES",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    INDEX = table.Column<int>(type: "int", nullable: false),
                    FIELD_KEY = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    COMPARATOR = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    VALUE = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    VIEW_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VIEW_ROLES", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "VIEWS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NAME = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SLUG = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PREDEFINED = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    RESOURCE_MODEL = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FAVOURITE = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    ROLES_LOGIC_EXPRESSION = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CREATED_AT = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UPDATED_AT = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VIEWS", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "WAREHOUSES",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NAME = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CODE = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ADDRESS = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CITY = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    COUNTRY = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PHONE_NUMBER = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EMAIL = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    WEBSITE = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PRIMARY = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CREATED_AT = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UPDATED_AT = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WAREHOUSES", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "WAREHOUSES_TRANSFERS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DATE = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    TO_WAREHOUSE_ID = table.Column<int>(type: "int", nullable: false),
                    FROM_WAREHOUSE_ID = table.Column<int>(type: "int", nullable: false),
                    TRANSACTION_NUMBER = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TRANSFER_INITIATED_AT = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    TRANSFER_DELIVERED_AT = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CREATED_AT = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UPDATED_AT = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WAREHOUSES_TRANSFERS", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "WAREHOUSES_TRANSFERS_ENTRIES",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    INDEX = table.Column<int>(type: "int", nullable: false),
                    WAREHOUSE_TRANSFER_ID = table.Column<int>(type: "int", nullable: false),
                    ITEM_ID = table.Column<int>(type: "int", nullable: false),
                    DESCRIPTION = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    QUANTITY = table.Column<int>(type: "int", nullable: false),
                    COST = table.Column<decimal>(type: "decimal(65,30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WAREHOUSES_TRANSFERS_ENTRIES", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ACCOUNTS");

            migrationBuilder.DropTable(
                name: "ACCOUNTS_TRANSACTIONS");

            migrationBuilder.DropTable(
                name: "BANK_RULE_CONDITIONS");

            migrationBuilder.DropTable(
                name: "BANK_RULES");

            migrationBuilder.DropTable(
                name: "BILL_LOCATED_COST_ENTRIES");

            migrationBuilder.DropTable(
                name: "BILL_LOCATED_COSTS");

            migrationBuilder.DropTable(
                name: "BILLS");

            migrationBuilder.DropTable(
                name: "BILLS_PAYMENTS");

            migrationBuilder.DropTable(
                name: "BILLS_PAYMENTS_ENTRIES");

            migrationBuilder.DropTable(
                name: "BRANCHES");

            migrationBuilder.DropTable(
                name: "CASHFLOW_TRANSACTION_LINES");

            migrationBuilder.DropTable(
                name: "CASHFLOW_TRANSACTIONS");

            migrationBuilder.DropTable(
                name: "CONTACTS");

            migrationBuilder.DropTable(
                name: "CREDIT_NOTE_APPLIED_INVOICE");

            migrationBuilder.DropTable(
                name: "CREDIT_NOTES");

            migrationBuilder.DropTable(
                name: "CURRENCIES");

            migrationBuilder.DropTable(
                name: "DOCUMENT_LINKS");

            migrationBuilder.DropTable(
                name: "DOCUMENTS");

            migrationBuilder.DropTable(
                name: "EXCHANGE_RATES");

            migrationBuilder.DropTable(
                name: "EXPENSE_TRANSACTION_CATEGORIES");

            migrationBuilder.DropTable(
                name: "EXPENSES_TRANSACTIONS");

            migrationBuilder.DropTable(
                name: "INVENTORY_ADJUSTMENTS");

            migrationBuilder.DropTable(
                name: "INVENTORY_ADJUSTMENTS_ENTRIES");

            migrationBuilder.DropTable(
                name: "INVENTORY_COST_LOT_TRACKER");

            migrationBuilder.DropTable(
                name: "INVENTORY_TRANSACTION_META");

            migrationBuilder.DropTable(
                name: "INVENTORY_TRANSACTIONS");

            migrationBuilder.DropTable(
                name: "ITEMS");

            migrationBuilder.DropTable(
                name: "ITEMS_CATEGORIES");

            migrationBuilder.DropTable(
                name: "ITEMS_ENTRIES");

            migrationBuilder.DropTable(
                name: "ITEMS_WAREHOUSES_QUANTITY");

            migrationBuilder.DropTable(
                name: "MANUAL_JOURNALS");

            migrationBuilder.DropTable(
                name: "MANUAL_JOURNALS_ENTRIES");

            migrationBuilder.DropTable(
                name: "MATCHED_BANK_TRANSACTIONS");

            migrationBuilder.DropTable(
                name: "MEDIA");

            migrationBuilder.DropTable(
                name: "MEDIA_LINKS");

            migrationBuilder.DropTable(
                name: "PAYMENT_INTEGRATIONS");

            migrationBuilder.DropTable(
                name: "PAYMENT_RECEIVES");

            migrationBuilder.DropTable(
                name: "PAYMENT_RECEIVES_ENTRIES");

            migrationBuilder.DropTable(
                name: "PDF_TEMPLATES");

            migrationBuilder.DropTable(
                name: "PLAID_ITEMS");

            migrationBuilder.DropTable(
                name: "PROJECTS");

            migrationBuilder.DropTable(
                name: "RECOGNIZED_BANK_TRANSACTIONS");

            migrationBuilder.DropTable(
                name: "REFUND_CREDIT_NOTE_TRANSACTIONS");

            migrationBuilder.DropTable(
                name: "REFUND_VENDOR_CREDIT_TRANSACTIONS");

            migrationBuilder.DropTable(
                name: "ROLE_PERMISSIONS");

            migrationBuilder.DropTable(
                name: "ROLES");

            migrationBuilder.DropTable(
                name: "SALES_ESTIMATES");

            migrationBuilder.DropTable(
                name: "SALES_INVOICES");

            migrationBuilder.DropTable(
                name: "SALES_RECEIPTS");

            migrationBuilder.DropTable(
                name: "SETTINGS");

            migrationBuilder.DropTable(
                name: "TASKS");

            migrationBuilder.DropTable(
                name: "TAX_RATE_TRANSACTIONS");

            migrationBuilder.DropTable(
                name: "TAX_RATES");

            migrationBuilder.DropTable(
                name: "TIMES");

            migrationBuilder.DropTable(
                name: "TRANSACTIONS_PAYMENT_METHODS");

            migrationBuilder.DropTable(
                name: "UNCATEGORIZED_CASHFLOW_TRANSACTIONS");

            migrationBuilder.DropTable(
                name: "USERS");

            migrationBuilder.DropTable(
                name: "VENDOR_CREDIT_APPLIED_BILL");

            migrationBuilder.DropTable(
                name: "VENDOR_CREDITS");

            migrationBuilder.DropTable(
                name: "VIEW_HAS_COLUMNS");

            migrationBuilder.DropTable(
                name: "VIEW_ROLES");

            migrationBuilder.DropTable(
                name: "VIEWS");

            migrationBuilder.DropTable(
                name: "WAREHOUSES");

            migrationBuilder.DropTable(
                name: "WAREHOUSES_TRANSFERS");

            migrationBuilder.DropTable(
                name: "WAREHOUSES_TRANSFERS_ENTRIES");
        }
    }
}
