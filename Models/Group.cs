using System;
using System.Collections.Generic;

namespace APIGW.Models;

public partial class Group
{
    public short Id { get; set; }

    public string Name { get; set; } = null!;

    public short TypeId { get; set; }

    public bool Visible { get; set; }
}
