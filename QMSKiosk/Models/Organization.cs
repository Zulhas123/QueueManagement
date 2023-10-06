using System;
using System.Collections.Generic;

namespace QMSKiosk.Models;

public partial class Organization
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string? LogoBase64 { get; set; }
}
