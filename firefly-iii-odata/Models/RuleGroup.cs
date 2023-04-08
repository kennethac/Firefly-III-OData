using System;
using System.Collections.Generic;

namespace firefly_iii_odata.Models;

public partial class RuleGroup
{
    public uint Id { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public uint UserId { get; set; }

    public ulong? UserGroupId { get; set; }

    public string Title { get; set; } = null!;

    public string? Description { get; set; }

    public uint Order { get; set; }

    public bool? Active { get; set; }

    public bool StopProcessing { get; set; }

    public virtual ICollection<Rule> Rules { get; } = new List<Rule>();

    public virtual User User { get; set; } = null!;

    public virtual UserGroup? UserGroup { get; set; }
}
