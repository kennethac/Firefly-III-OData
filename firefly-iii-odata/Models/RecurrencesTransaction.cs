using System;
using System.Collections.Generic;

namespace firefly_iii_odata.Models;

public partial class RecurrencesTransaction
{
    public uint Id { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public uint RecurrenceId { get; set; }

    public uint TransactionCurrencyId { get; set; }

    public uint? TransactionTypeId { get; set; }

    public uint? ForeignCurrencyId { get; set; }

    public uint SourceId { get; set; }

    public uint DestinationId { get; set; }

    public decimal Amount { get; set; }

    public decimal? ForeignAmount { get; set; }

    public string Description { get; set; } = null!;

    public virtual Account Destination { get; set; } = null!;

    public virtual TransactionCurrency? ForeignCurrency { get; set; }

    public virtual Recurrence Recurrence { get; set; } = null!;

    public virtual ICollection<RtMetum> RtMeta { get; } = new List<RtMetum>();

    public virtual Account Source { get; set; } = null!;

    public virtual TransactionCurrency TransactionCurrency { get; set; } = null!;

    public virtual TransactionType? TransactionType { get; set; }
}
