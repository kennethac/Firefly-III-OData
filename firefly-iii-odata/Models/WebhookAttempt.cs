using System;
using System.Collections.Generic;

namespace firefly_iii_odata.Models;

public partial class WebhookAttempt
{
    public uint Id { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public uint WebhookMessageId { get; set; }

    public ushort StatusCode { get; set; }

    public string? Logs { get; set; }

    public string? Response { get; set; }

    public virtual WebhookMessage WebhookMessage { get; set; } = null!;
}
