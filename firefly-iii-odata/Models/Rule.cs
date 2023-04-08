using System;
using System.Collections.Generic;

namespace firefly_iii_odata.Models;

public partial class Rule
{
    public uint Id { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public uint UserId { get; set; }

    public ulong? UserGroupId { get; set; }

    public uint RuleGroupId { get; set; }

    public string Title { get; set; } = null!;

    public string? Description { get; set; }

    public uint Order { get; set; }

    public bool? Active { get; set; }

    public bool StopProcessing { get; set; }

    public bool? Strict { get; set; }

    public virtual ICollection<RuleAction> RuleActions { get; } = new List<RuleAction>();

    public virtual RuleGroup RuleGroup { get; set; } = null!;

    public virtual ICollection<RuleTrigger> RuleTriggers { get; } = new List<RuleTrigger>();

    public virtual User User { get; set; } = null!;

    public virtual UserGroup? UserGroup { get; set; }
}
