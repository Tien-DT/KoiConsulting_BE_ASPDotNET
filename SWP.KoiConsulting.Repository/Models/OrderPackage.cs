using System;
using System.Collections.Generic;

namespace SWP.KoiConsulting.Repository.Models;

public partial class OrderPackage
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public int? Detail { get; set; }

    public double? TotalPrice { get; set; }

    public virtual Package? DetailNavigation { get; set; }

    public virtual Payment Id1 { get; set; } = null!;

    public virtual Post IdNavigation { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
