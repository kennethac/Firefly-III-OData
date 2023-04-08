using System;
using System.Collections.Generic;

namespace firefly_iii_odata.Models;

public partial class Recurrence
{
    public uint Id { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public uint UserId { get; set; }

    public ulong? UserGroupId { get; set; }

    public uint TransactionTypeId { get; set; }

    public string Title { get; set; } = null!;

    public string Description { get; set; } = null!;

    public DateOnly FirstDate { get; set; }

    public DateOnly? RepeatUntil { get; set; }

    public DateOnly? LatestDate { get; set; }

    public ushort Repetitions { get; set; }

    public bool? ApplyRules { get; set; }

    public bool? Active { get; set; }

    public virtual ICollection<RecurrencesMetum> RecurrencesMeta { get; } = new List<RecurrencesMetum>();

    public virtual ICollection<RecurrencesRepetition> RecurrencesRepetitions { get; } = new List<RecurrencesRepetition>();

    public virtual ICollection<RecurrencesTransaction> RecurrencesTransactions { get; } = new List<RecurrencesTransaction>();

    public virtual TransactionType TransactionType { get; set; } = null!;

    public virtual User User { get; set; } = null!;

    public virtual UserGroup? UserGroup { get; set; }
}
