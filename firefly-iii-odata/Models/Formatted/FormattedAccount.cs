using System;
using System.Collections.Generic;

namespace firefly_iii_odata.Models.Formatted;

public partial class FormattedAccount
{
    public uint Id { get; set; }
    public uint AccountTypeId { get; set; }
    public string AccountType { get; set; }
    public string Name { get; set; } = null!;
    public required decimal? VirtualBalance { get; set; }
    public bool? Active { get; set; }
    public uint Order { get; set; }
    public required decimal? CurrentBalance { get; set; }
}
