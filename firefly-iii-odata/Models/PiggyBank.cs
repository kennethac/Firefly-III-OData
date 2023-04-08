using System;
using System.Collections.Generic;

namespace firefly_iii_odata.Models;

public partial class PiggyBank
{
    public uint Id { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public uint AccountId { get; set; }

    public string Name { get; set; } = null!;

    public decimal Targetamount { get; set; }

    public DateOnly? Startdate { get; set; }

    public DateOnly? Targetdate { get; set; }

    public uint Order { get; set; }

    public bool Active { get; set; }

    public bool? Encrypted { get; set; }

    public virtual Account Account { get; set; } = null!;

    public virtual ICollection<PiggyBankEvent> PiggyBankEvents { get; } = new List<PiggyBankEvent>();

    public virtual ICollection<PiggyBankRepetition> PiggyBankRepetitions { get; } = new List<PiggyBankRepetition>();
}
