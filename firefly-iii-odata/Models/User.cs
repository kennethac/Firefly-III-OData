using System;
using System.Collections.Generic;

namespace firefly_iii_odata.Models;

public partial class User
{
    public uint Id { get; set; }

    public Guid? Objectguid { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string? RememberToken { get; set; }

    public string? Reset { get; set; }

    public byte Blocked { get; set; }

    public string? BlockedCode { get; set; }

    public string? MfaSecret { get; set; }

    public string? Domain { get; set; }

    public ulong? UserGroupId { get; set; }

    public virtual ICollection<Account> Accounts { get; } = new List<Account>();

    public virtual ICollection<Attachment> Attachments { get; } = new List<Attachment>();

    public virtual ICollection<AvailableBudget> AvailableBudgets { get; } = new List<AvailableBudget>();

    public virtual ICollection<Bill> Bills { get; } = new List<Bill>();

    public virtual ICollection<Budget> Budgets { get; } = new List<Budget>();

    public virtual ICollection<Category> Categories { get; } = new List<Category>();

    public virtual ICollection<CurrencyExchangeRate> CurrencyExchangeRates { get; } = new List<CurrencyExchangeRate>();

    public virtual ICollection<ExportJob> ExportJobs { get; } = new List<ExportJob>();

    public virtual ICollection<GroupMembership> GroupMemberships { get; } = new List<GroupMembership>();

    public virtual ICollection<ImportJob> ImportJobs { get; } = new List<ImportJob>();

    public virtual ICollection<InvitedUser> InvitedUsers { get; } = new List<InvitedUser>();

    public virtual ICollection<ObjectGroup> ObjectGroups { get; } = new List<ObjectGroup>();

    public virtual ICollection<Preference> Preferences { get; } = new List<Preference>();

    public virtual ICollection<Recurrence> Recurrences { get; } = new List<Recurrence>();

    public virtual ICollection<RuleGroup> RuleGroups { get; } = new List<RuleGroup>();

    public virtual ICollection<Rule> Rules { get; } = new List<Rule>();

    public virtual ICollection<Tag> Tags { get; } = new List<Tag>();

    public virtual ICollection<TransactionGroup> TransactionGroups { get; } = new List<TransactionGroup>();

    public virtual ICollection<TransactionJournal> TransactionJournals { get; } = new List<TransactionJournal>();

    public virtual UserGroup? UserGroup { get; set; }

    public virtual ICollection<Webhook> Webhooks { get; } = new List<Webhook>();

    public virtual ICollection<_2faToken> _2faTokens { get; } = new List<_2faToken>();

    public virtual ICollection<Role> Roles { get; } = new List<Role>();
}
