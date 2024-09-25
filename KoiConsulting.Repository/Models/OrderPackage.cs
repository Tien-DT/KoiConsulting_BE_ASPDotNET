using System;
using System.Collections.Generic;

namespace KoiConsulting.Repository.Models;

public partial class OrderPackage
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public int? PackageId { get; set; }

    public virtual Post Id1 { get; set; } = null!;

    public virtual OrderPackageDetail IdNavigation { get; set; } = null!;

    public virtual Package? Package { get; set; }

    public virtual User User { get; set; } = null!;
}
