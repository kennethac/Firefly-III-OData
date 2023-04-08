using System;
using System.Collections.Generic;

namespace firefly_iii_odata.Models;

public partial class RuleTrigger
{
    public uint Id { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public uint RuleId { get; set; }

    public string TriggerType { get; set; } = null!;

    public string TriggerValue { get; set; } = null!;

    public uint Order { get; set; }

    public bool? Active { get; set; }

    public bool StopProcessing { get; set; }

    public virtual Rule Rule { get; set; } = null!;
}
