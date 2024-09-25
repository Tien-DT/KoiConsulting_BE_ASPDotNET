using System;
using System.Collections.Generic;

namespace KoiConsulting.Repository.Models;

public partial class Payment
{
    public int Id { get; set; }

    public DateTime? Time { get; set; }

    public int? Status { get; set; }

    public virtual ICollection<OrderPackageDetail> OrderPackageDetails { get; set; } = new List<OrderPackageDetail>();
}
