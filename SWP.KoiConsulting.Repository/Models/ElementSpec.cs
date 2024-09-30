using System;
using System.Collections.Generic;

namespace SWP.KoiConsulting.Repository.Models;

public partial class ElementSpec
{
    public int Id { get; set; }

    public int? KoiId { get; set; }

    public int? ElementId { get; set; }

    public int? AppropriateLevel { get; set; }

    public string? Type { get; set; }

    public string? Detail { get; set; }

    public int? ElementKoiId { get; set; }

    public virtual Element? Element { get; set; }

    public virtual ElementKoi? ElementKoi { get; set; }

    public virtual KoiType? Koi { get; set; }
}
