using System;
using System.Collections.Generic;

namespace firefly_iii_odata.Models;

public partial class Webhook
{
    public uint Id { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public uint UserId { get; set; }

    public ulong? UserGroupId { get; set; }

    public string Title { get; set; } = null!;

    public string Secret { get; set; } = null!;

    public bool? Active { get; set; }

    public ushort Trigger { get; set; }

    public ushort Response { get; set; }

    public ushort Delivery { get; set; }

    public string Url { get; set; } = null!;

    public virtual User User { get; set; } = null!;

    public virtual UserGroup? UserGroup { get; set; }

    public virtual ICollection<WebhookMessage> WebhookMessages { get; } = new List<WebhookMessage>();
}
