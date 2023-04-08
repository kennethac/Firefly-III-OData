using System;
using System.Collections.Generic;

namespace firefly_iii_odata.Models;

public partial class TransactionGroup
{
    public uint Id { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public uint UserId { get; set; }

    public ulong? UserGroupId { get; set; }

    public string? Title { get; set; }

    public virtual ICollection<GroupJournal> GroupJournals { get; } = new List<GroupJournal>();

    public virtual ICollection<TransactionJournal> TransactionJournals { get; } = new List<TransactionJournal>();

    public virtual User User { get; set; } = null!;

    public virtual UserGroup? UserGroup { get; set; }
}
