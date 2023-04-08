using System;
using System.Collections.Generic;

namespace firefly_iii_odata.Models;

public partial class Preference
{
    public uint Id { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public uint UserId { get; set; }

    public string Name { get; set; } = null!;

    public string? Data { get; set; }

    public virtual User User { get; set; } = null!;
}
