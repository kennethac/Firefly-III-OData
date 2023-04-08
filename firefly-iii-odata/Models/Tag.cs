using System;
using System.Collections.Generic;

namespace firefly_iii_odata.Models;

public partial class Tag
{
    public uint Id { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public uint UserId { get; set; }

    public ulong? UserGroupId { get; set; }

    public string Tag1 { get; set; } = null!;

    public string TagMode { get; set; } = null!;

    public DateOnly? Date { get; set; }

    public string? Description { get; set; }

    public decimal? Latitude { get; set; }

    public decimal? Longitude { get; set; }

    public ushort? ZoomLevel { get; set; }

    public virtual ICollection<ImportJob> ImportJobs { get; } = new List<ImportJob>();

    public virtual ICollection<TagTransactionJournal> TagTransactionJournals { get; } = new List<TagTransactionJournal>();

    public virtual User User { get; set; } = null!;

    public virtual UserGroup? UserGroup { get; set; }
}
