using System;
using System.Collections.Generic;

namespace firefly_iii_odata.Models;

public partial class Transaction
{
    public uint Id { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public bool Reconciled { get; set; }

    public uint AccountId { get; set; }

    public uint TransactionJournalId { get; set; }

    public string? Description { get; set; }

    public uint? TransactionCurrencyId { get; set; }

    public decimal Amount { get; set; }

    public decimal? ForeignAmount { get; set; }

    public uint? ForeignCurrencyId { get; set; }

    public ushort Identifier { get; set; }

    public virtual Account Account { get; set; } = null!;

    public virtual ICollection<BudgetTransaction> BudgetTransactions { get; } = new List<BudgetTransaction>();

    public virtual ICollection<CategoryTransaction> CategoryTransactions { get; } = new List<CategoryTransaction>();

    public virtual TransactionCurrency? ForeignCurrency { get; set; }

    public virtual TransactionCurrency? TransactionCurrency { get; set; }

    public virtual TransactionJournal TransactionJournal { get; set; } = null!;
}
