using System;
using System.Collections.Generic;

namespace SWP.KoiConsulting.Repository.Models;

public partial class ElementKoi
{
    public int Id { get; set; }

    public int? ElementId { get; set; }

    public int? KoiId { get; set; }

    public string? Type { get; set; }

    public int? Status { get; set; }

    public virtual Element? Element { get; set; }

    public virtual ICollection<ElementSpec> ElementSpecs { get; set; } = new List<ElementSpec>();

    public virtual KoiType? Koi { get; set; }
}
