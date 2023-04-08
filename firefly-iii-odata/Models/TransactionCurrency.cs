using System;
using System.Collections.Generic;

namespace firefly_iii_odata.Models;

public partial class TransactionCurrency
{
    public uint Id { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public bool Enabled { get; set; }

    public string Code { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Symbol { get; set; } = null!;

    public ushort DecimalPlaces { get; set; }

    public virtual ICollection<AutoBudget> AutoBudgets { get; } = new List<AutoBudget>();

    public virtual ICollection<AvailableBudget> AvailableBudgets { get; } = new List<AvailableBudget>();

    public virtual ICollection<Bill> Bills { get; } = new List<Bill>();

    public virtual ICollection<BudgetLimit> BudgetLimits { get; } = new List<BudgetLimit>();

    public virtual ICollection<CurrencyExchangeRate> CurrencyExchangeRateFromCurrencies { get; } = new List<CurrencyExchangeRate>();

    public virtual ICollection<CurrencyExchangeRate> CurrencyExchangeRateToCurrencies { get; } = new List<CurrencyExchangeRate>();

    public virtual ICollection<RecurrencesTransaction> RecurrencesTransactionForeignCurrencies { get; } = new List<RecurrencesTransaction>();

    public virtual ICollection<RecurrencesTransaction> RecurrencesTransactionTransactionCurrencies { get; } = new List<RecurrencesTransaction>();

    public virtual ICollection<Transaction> TransactionForeignCurrencies { get; } = new List<Transaction>();

    public virtual ICollection<TransactionJournal> TransactionJournals { get; } = new List<TransactionJournal>();

    public virtual ICollection<Transaction> TransactionTransactionCurrencies { get; } = new List<Transaction>();
}
