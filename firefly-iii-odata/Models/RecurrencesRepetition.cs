using System;
using System.Collections.Generic;

namespace firefly_iii_odata.Models;

public partial class RecurrencesRepetition
{
    public uint Id { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public uint RecurrenceId { get; set; }

    public string RepetitionType { get; set; } = null!;

    public string RepetitionMoment { get; set; } = null!;

    public ushort RepetitionSkip { get; set; }

    public ushort Weekend { get; set; }

    public virtual Recurrence Recurrence { get; set; } = null!;
}
