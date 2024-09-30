using System;
using System.Collections.Generic;

namespace SWP.KoiConsulting.Repository.Models;

public partial class Payment
{
    public int Id { get; set; }

    public DateTime? Time { get; set; }

    public int? Status { get; set; }

    public double? Price { get; set; }

    public int? OrderPackageId { get; set; }

    public virtual OrderPackage? OrderPackage { get; set; }
}
