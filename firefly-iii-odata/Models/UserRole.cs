using System;
using System.Collections.Generic;

namespace firefly_iii_odata.Models;

public partial class UserRole
{
    public ulong Id { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public string Title { get; set; } = null!;

    public virtual ICollection<GroupMembership> GroupMemberships { get; } = new List<GroupMembership>();
}
