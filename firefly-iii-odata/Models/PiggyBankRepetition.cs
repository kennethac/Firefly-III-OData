using System;
using System.Collections.Generic;

namespace firefly_iii_odata.Models;

public partial class PiggyBankRepetition
{
    public uint Id { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public uint PiggyBankId { get; set; }

    public DateOnly? Startdate { get; set; }

    public DateOnly? Targetdate { get; set; }

    public decimal Currentamount { get; set; }

    public virtual PiggyBank PiggyBank { get; set; } = null!;
}
