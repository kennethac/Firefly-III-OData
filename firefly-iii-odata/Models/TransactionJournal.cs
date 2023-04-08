using System;
using System.Collections.Generic;

namespace firefly_iii_odata.Models;

public partial class TransactionJournal
{
    public uint Id { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public uint UserId { get; set; }

    public ulong? UserGroupId { get; set; }

    public uint TransactionTypeId { get; set; }

    public uint? TransactionGroupId { get; set; }

    public uint? BillId { get; set; }

    public uint? TransactionCurrencyId { get; set; }

    public string Description { get; set; } = null!;

    public DateTime Date { get; set; }

    public DateOnly? InterestDate { get; set; }

    public DateOnly? BookDate { get; set; }

    public DateOnly? ProcessDate { get; set; }

    public uint Order { get; set; }

    public uint TagCount { get; set; }

    public bool? Encrypted { get; set; }

    public bool? Completed { get; set; }

    public virtual Bill? Bill { get; set; }

    public virtual ICollection<BudgetTransactionJournal> BudgetTransactionJournals { get; } = new List<BudgetTransactionJournal>();

    public virtual ICollection<CategoryTransactionJournal> CategoryTransactionJournals { get; } = new List<CategoryTransactionJournal>();

    public virtual ICollection<GroupJournal> GroupJournals { get; } = new List<GroupJournal>();

    public virtual ICollection<JournalLink> JournalLinkDestinations { get; } = new List<JournalLink>();

    public virtual ICollection<JournalLink> JournalLinkSources { get; } = new List<JournalLink>();

    public virtual ICollection<JournalMetum> JournalMeta { get; } = new List<JournalMetum>();

    public virtual ICollection<PiggyBankEvent> PiggyBankEvents { get; } = new List<PiggyBankEvent>();

    public virtual ICollection<TagTransactionJournal> TagTransactionJournals { get; } = new List<TagTransactionJournal>();

    public virtual TransactionCurrency? TransactionCurrency { get; set; }

    public virtual TransactionGroup? TransactionGroup { get; set; }

    public virtual TransactionType TransactionType { get; set; } = null!;

    public virtual ICollection<Transaction> Transactions { get; } = new List<Transaction>();

    public virtual User User { get; set; } = null!;

    public virtual UserGroup? UserGroup { get; set; }
}
