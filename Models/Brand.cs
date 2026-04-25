using System;
using System.Collections.Generic;

namespace APIGW.Models;

public partial class Brand
{
    public byte Id { get; set; }

    public string Name { get; set; } = null!;

    public string? FullBrandName { get; set; }

    public string? Address { get; set; }

    public string? WebSite { get; set; }

    public bool Visible { get; set; }

    public short CurrencyId { get; set; }
}
