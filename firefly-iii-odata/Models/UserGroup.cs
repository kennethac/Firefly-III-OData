using System;
using System.Collections.Generic;

namespace firefly_iii_odata.Models;

public partial class UserGroup
{
    public ulong Id { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public string Title { get; set; } = null!;

    public virtual ICollection<Account> Accounts { get; } = new List<Account>();

    public virtual ICollection<Attachment> Attachments { get; } = new List<Attachment>();

    public virtual ICollection<AvailableBudget> AvailableBudgets { get; } = new List<AvailableBudget>();

    public virtual ICollection<Bill> Bills { get; } = new List<Bill>();

    public virtual ICollection<Budget> Budgets { get; } = new List<Budget>();

    public virtual ICollection<Category> Categories { get; } = new List<Category>();

    public virtual ICollection<CurrencyExchangeRate> CurrencyExchangeRates { get; } = new List<CurrencyExchangeRate>();

    public virtual ICollection<GroupMembership> GroupMemberships { get; } = new List<GroupMembership>();

    public virtual ICollection<Recurrence> Recurrences { get; } = new List<Recurrence>();

    public virtual ICollection<RuleGroup> RuleGroups { get; } = new List<RuleGroup>();

    public virtual ICollection<Rule> Rules { get; } = new List<Rule>();

    public virtual ICollection<Tag> Tags { get; } = new List<Tag>();

    public virtual ICollection<TransactionGroup> TransactionGroups { get; } = new List<TransactionGroup>();

    public virtual ICollection<TransactionJournal> TransactionJournals { get; } = new List<TransactionJournal>();

    public virtual ICollection<User> Users { get; } = new List<User>();

    public virtual ICollection<Webhook> Webhooks { get; } = new List<Webhook>();
}
