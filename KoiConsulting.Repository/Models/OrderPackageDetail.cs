using System;
using System.Collections.Generic;

namespace KoiConsulting.Repository.Models;

public partial class OrderPackageDetail
{
    public int OrderId { get; set; }

    public string? Detail { get; set; }

    public double? Price { get; set; }

    public int? PaymentId { get; set; }

    public DateTime? Time { get; set; }

    public int? Status { get; set; }

    public virtual ICollection<OrderPackage> OrderPackages { get; set; } = new List<OrderPackage>();

    public virtual Payment? Payment { get; set; }
}
