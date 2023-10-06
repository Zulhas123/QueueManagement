using System;
using System.Collections.Generic;

namespace QMSKiosk.Models;

public partial class AspNetUser
{
    public string Id { get; set; } = null!;

    public string? UserName { get; set; }

    public string? NormalizedUserName { get; set; }

    public string? Email { get; set; }

    public string? NormalizedEmail { get; set; }

    public bool EmailConfirmed { get; set; }

    public string? PasswordHash { get; set; }

    public string? SecurityStamp { get; set; }

    public string? ConcurrencyStamp { get; set; }

    public string? PhoneNumber { get; set; }

    public bool PhoneNumberConfirmed { get; set; }

    public bool TwoFactorEnabled { get; set; }

    public DateTimeOffset? LockoutEnd { get; set; }

    public bool LockoutEnabled { get; set; }

    public int AccessFailedCount { get; set; }

    public string EmployeeCode { get; set; } = null!;

    public string FullName { get; set; } = null!;

    public virtual ICollection<Advertisement> AdvertisementCreatedBies { get; } = new List<Advertisement>();

    public virtual ICollection<Advertisement> AdvertisementDeletedBies { get; } = new List<Advertisement>();

    public virtual ICollection<Advertisement> AdvertisementUpdatedBies { get; } = new List<Advertisement>();

    public virtual ICollection<AspNetUserClaim> AspNetUserClaims { get; } = new List<AspNetUserClaim>();

    public virtual ICollection<AspNetUserLogin> AspNetUserLogins { get; } = new List<AspNetUserLogin>();

    public virtual ICollection<AspNetUserToken> AspNetUserTokens { get; } = new List<AspNetUserToken>();

    public virtual ICollection<Desk> DeskCreatedBies { get; } = new List<Desk>();

    public virtual ICollection<Desk> DeskDeletedBies { get; } = new List<Desk>();

    public virtual ICollection<Desk> DeskUpdatedBies { get; } = new List<Desk>();

    public virtual ICollection<ServiceInfo> ServiceInfoCreatedBies { get; } = new List<ServiceInfo>();

    public virtual ICollection<ServiceInfo> ServiceInfoDeletedBies { get; } = new List<ServiceInfo>();

    public virtual ICollection<ServiceInfo> ServiceInfoUpdatedBies { get; } = new List<ServiceInfo>();

    public virtual ICollection<ServiceReceiver> ServiceReceivers { get; } = new List<ServiceReceiver>();

    public virtual ICollection<UserServicesDesk> UserServicesDeskAppUsers { get; } = new List<UserServicesDesk>();

    public virtual ICollection<UserServicesDesk> UserServicesDeskCreatedBies { get; } = new List<UserServicesDesk>();

    public virtual ICollection<UserServicesDesk> UserServicesDeskDeletedBies { get; } = new List<UserServicesDesk>();

    public virtual ICollection<UserServicesDesk> UserServicesDeskUpdatedBies { get; } = new List<UserServicesDesk>();

    public virtual ICollection<AspNetRole> Roles { get; } = new List<AspNetRole>();
}
