using System;
using System.Collections.Generic;

namespace firefly_iii_odata.Models;

public partial class RtMetum
{
    public uint Id { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public uint RtId { get; set; }

    public string Name { get; set; } = null!;

    public string Value { get; set; } = null!;

    public virtual RecurrencesTransaction Rt { get; set; } = null!;
}
