using System;
using System.Collections.Generic;

namespace QMSKiosk.Models;

public partial class UserServicesDesk
{
    public int Id { get; set; }

    public string AppUserId { get; set; } = null!;

    public int ServiceInfoId { get; set; }

    public int DeskId { get; set; }

    public int ServiceStatus { get; set; }

    public string CreatedById { get; set; } = null!;

    public DateTime CreatedDate { get; set; }

    public string? UpdatedById { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public string? DeletedById { get; set; }

    public DateTime? DeletedDate { get; set; }

    public bool IsActive { get; set; }

    public virtual AspNetUser AppUser { get; set; } = null!;

    public virtual AspNetUser CreatedBy { get; set; } = null!;

    public virtual AspNetUser? DeletedBy { get; set; }

    public virtual Desk Desk { get; set; } = null!;

    public virtual ServiceInfo ServiceInfo { get; set; } = null!;

    public virtual AspNetUser? UpdatedBy { get; set; }
}
