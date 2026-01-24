using Microsoft.EntityFrameworkCore;
using Dotland.DotCapital.WebApi.Domain.Entities.Tenant;
using Dotland.DotCapital.WebApi.Application.Common.Interfaces;

namespace Dotland.DotCapital.WebApi.Infrastructure.Data;

public class TenantDbContext(DbContextOptions<TenantDbContext> options) : DbContext(options), IApplicationDbContext
{
    public DbSet<Account> Accounts => Set<Account>();
    public DbSet<AccountsTransaction> AccountsTransactions => Set<AccountsTransaction>();
    public DbSet<BankRule> BankRules => Set<BankRule>();
    public DbSet<BankRuleCondition> BankRuleConditions => Set<BankRuleCondition>();
    public DbSet<Bill> Bills => Set<Bill>();
    public DbSet<BillsPayment> BillsPayments => Set<BillsPayment>();
    public DbSet<BillsPaymentsEntrie> BillsPaymentsEntries => Set<BillsPaymentsEntrie>();
    public DbSet<BillLocatedCost> BillLocatedCosts => Set<BillLocatedCost>();
    public DbSet<BillLocatedCostEntrie> BillLocatedCostEntries => Set<BillLocatedCostEntrie>();
    public DbSet<Branche> Branches => Set<Branche>();
    public DbSet<CashflowTransaction> CashflowTransactions => Set<CashflowTransaction>();
    public DbSet<CashflowTransactionLine> CashflowTransactionLines => Set<CashflowTransactionLine>();
    public DbSet<Contact> Contacts => Set<Contact>();
    public DbSet<CreditNote> CreditNotes => Set<CreditNote>();
    public DbSet<CreditNoteAppliedInvoice> CreditNoteAppliedInvoices => Set<CreditNoteAppliedInvoice>();
    public DbSet<Currencie> Currencies => Set<Currencie>();
    public DbSet<Document> Documents => Set<Document>();
    public DbSet<DocumentLink> DocumentLinks => Set<DocumentLink>();
    public DbSet<ExchangeRate> ExchangeRates => Set<ExchangeRate>();
    public DbSet<ExpensesTransaction> ExpensesTransactions => Set<ExpensesTransaction>();
    public DbSet<ExpenseTransactionCategorie> ExpenseTransactionCategories => Set<ExpenseTransactionCategorie>();
    public DbSet<InventoryAdjustment> InventoryAdjustments => Set<InventoryAdjustment>();
    public DbSet<InventoryAdjustmentsEntrie> InventoryAdjustmentsEntries => Set<InventoryAdjustmentsEntrie>();
    public DbSet<InventoryCostLotTracker> InventoryCostLotTrackers => Set<InventoryCostLotTracker>();
    public DbSet<InventoryTransaction> InventoryTransactions => Set<InventoryTransaction>();
    public DbSet<InventoryTransactionMeta> InventoryTransactionMetas => Set<InventoryTransactionMeta>();
    public DbSet<Item> Items => Set<Item>();
    public DbSet<ItemsCategorie> ItemsCategories => Set<ItemsCategorie>();
    public DbSet<ItemsEntrie> ItemsEntries => Set<ItemsEntrie>();
    public DbSet<ItemsWarehousesQuantity> ItemsWarehousesQuantitys => Set<ItemsWarehousesQuantity>();
    public DbSet<ManualJournal> ManualJournals => Set<ManualJournal>();
    public DbSet<ManualJournalsEntrie> ManualJournalsEntries => Set<ManualJournalsEntrie>();
    public DbSet<MatchedBankTransaction> MatchedBankTransactions => Set<MatchedBankTransaction>();
    public DbSet<Media> Medias => Set<Media>();
    public DbSet<MediaLink> MediaLinks => Set<MediaLink>();
    public DbSet<PaymentIntegration> PaymentIntegrations => Set<PaymentIntegration>();
    public DbSet<PaymentReceive> PaymentReceives => Set<PaymentReceive>();
    public DbSet<PaymentReceivesEntrie> PaymentReceivesEntries => Set<PaymentReceivesEntrie>();
    public DbSet<PdfTemplate> PdfTemplates => Set<PdfTemplate>();
    public DbSet<PlaidItem> PlaidItems => Set<PlaidItem>();
    public DbSet<Project> Projects => Set<Project>();
    public DbSet<RecognizedBankTransaction> RecognizedBankTransactions => Set<RecognizedBankTransaction>();
    public DbSet<RefundCreditNoteTransaction> RefundCreditNoteTransactions => Set<RefundCreditNoteTransaction>();
    public DbSet<RefundVendorCreditTransaction> RefundVendorCreditTransactions => Set<RefundVendorCreditTransaction>();
    public DbSet<Role> Roles => Set<Role>();
    public DbSet<RolePermission> RolePermissions => Set<RolePermission>();
    public DbSet<SalesEstimate> SalesEstimates => Set<SalesEstimate>();
    public DbSet<SalesInvoice> SalesInvoices => Set<SalesInvoice>();
    public DbSet<SalesReceipt> SalesReceipts => Set<SalesReceipt>();
    public DbSet<Setting> Settings => Set<Setting>();
    public DbSet<TaskEntity> Tasks => Set<TaskEntity>(); // Renamed Task to TaskEntity to avoid system conflict? Assuming generated as Task.
    public DbSet<TaxRate> TaxRates => Set<TaxRate>();
    public DbSet<TaxRateTransaction> TaxRateTransactions => Set<TaxRateTransaction>();
    public DbSet<Time> Times => Set<Time>();
    public DbSet<TransactionsPaymentMethod> TransactionsPaymentMethods => Set<TransactionsPaymentMethod>();
    public DbSet<UncategorizedCashflowTransaction> UncategorizedCashflowTransactions => Set<UncategorizedCashflowTransaction>();
    public DbSet<User> Users => Set<User>();
    public DbSet<VendorCredit> VendorCredits => Set<VendorCredit>();
    public DbSet<VendorCreditAppliedBill> VendorCreditAppliedBills => Set<VendorCreditAppliedBill>();
    public DbSet<View> Views => Set<View>();
    public DbSet<ViewHasColumn> ViewHasColumns => Set<ViewHasColumn>();
    public DbSet<ViewRole> ViewRoles => Set<ViewRole>();
    public DbSet<Warehouse> Warehouses => Set<Warehouse>();
    public DbSet<WarehousesTransfer> WarehousesTransfers => Set<WarehousesTransfer>();
    public DbSet<WarehousesTransfersEntrie> WarehousesTransfersEntries => Set<WarehousesTransfersEntrie>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
    }
    
    public static TenantDbContext CreateDbContext(string connectionString)
    {
        var optionsBuilder = new DbContextOptionsBuilder<TenantDbContext>();
        optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));

        return new TenantDbContext(optionsBuilder.Options);
    }
}
