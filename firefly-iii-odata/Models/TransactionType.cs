using System;
using System.Collections.Generic;

namespace firefly_iii_odata.Models;

public partial class TransactionType
{
    public uint Id { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public string Type { get; set; } = null!;

    public virtual ICollection<Recurrence> Recurrences { get; } = new List<Recurrence>();

    public virtual ICollection<RecurrencesTransaction> RecurrencesTransactions { get; } = new List<RecurrencesTransaction>();

    public virtual ICollection<TransactionJournal> TransactionJournals { get; } = new List<TransactionJournal>();
}
