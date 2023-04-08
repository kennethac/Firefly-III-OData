using System;
using System.Collections.Generic;

namespace firefly_iii_odata.Models;

public partial class PiggyBankEvent
{
    public uint Id { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public uint PiggyBankId { get; set; }

    public uint? TransactionJournalId { get; set; }

    public DateOnly Date { get; set; }

    public decimal Amount { get; set; }

    public virtual PiggyBank PiggyBank { get; set; } = null!;

    public virtual TransactionJournal? TransactionJournal { get; set; }
}
