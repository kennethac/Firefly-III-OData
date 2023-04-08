using System;
using System.Collections.Generic;

namespace firefly_iii_odata.Models;

public partial class WebhookMessage
{
    public uint Id { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public bool Sent { get; set; }

    public bool Errored { get; set; }

    public uint WebhookId { get; set; }

    public string Uuid { get; set; } = null!;

    public string Message { get; set; } = null!;

    public virtual Webhook Webhook { get; set; } = null!;

    public virtual ICollection<WebhookAttempt> WebhookAttempts { get; } = new List<WebhookAttempt>();
}
