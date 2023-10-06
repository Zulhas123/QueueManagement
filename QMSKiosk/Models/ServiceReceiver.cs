using System;
using System.Collections.Generic;

namespace QMSKiosk.Models;

public partial class ServiceReceiver
{
    public long Id { get; set; }

    public int ServiceInfoId { get; set; }

    public DateTime TokenCreationDate { get; set; }

    public string TokenNo { get; set; } = null!;

    public int SerialNo { get; set; }

    public int Status { get; set; }

    public DateTime? ServiceStartDate { get; set; }

    public DateTime? ServiceEndDate { get; set; }

    public string? ServiceProviderId { get; set; }

    public bool? IsClearedFromDisplay { get; set; }

    public virtual ServiceInfo ServiceInfo { get; set; } = null!;

    public virtual AspNetUser? ServiceProvider { get; set; }
}
