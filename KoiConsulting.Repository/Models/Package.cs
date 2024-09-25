using System;
using System.Collections.Generic;

namespace KoiConsulting.Repository.Models;

public partial class Package
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int? Exp { get; set; }

    public double? Price { get; set; }

    public virtual ICollection<OrderPackage> OrderPackages { get; set; } = new List<OrderPackage>();
}
