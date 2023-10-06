using System;
using System.Collections.Generic;

namespace QMSKiosk.Models;

public partial class ServiceInfo
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string CreatedById { get; set; } = null!;

    public DateTime CreatedDate { get; set; }

    public string? UpdatedById { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public string? DeletedById { get; set; }

    public DateTime? DeletedDate { get; set; }

    public bool IsActive { get; set; }

    public int? ParentId { get; set; }

    public string TokenStart { get; set; } = null!;

    public virtual AspNetUser CreatedBy { get; set; } = null!;

    public virtual AspNetUser? DeletedBy { get; set; }

    public virtual ICollection<ServiceInfo> InverseParent { get; } = new List<ServiceInfo>();

    public virtual ServiceInfo? Parent { get; set; }

    public virtual ICollection<ServiceReceiver> ServiceReceivers { get; } = new List<ServiceReceiver>();

    public virtual AspNetUser? UpdatedBy { get; set; }

    public virtual ICollection<UserServicesDesk> UserServicesDesks { get; } = new List<UserServicesDesk>();
}
