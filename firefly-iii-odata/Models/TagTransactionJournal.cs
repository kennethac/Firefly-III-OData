using System;
using System.Collections.Generic;

namespace firefly_iii_odata.Models;

public partial class TagTransactionJournal
{
    public uint Id { get; set; }

    public uint TagId { get; set; }

    public uint TransactionJournalId { get; set; }

    public virtual Tag Tag { get; set; } = null!;

    public virtual TransactionJournal TransactionJournal { get; set; } = null!;
}
