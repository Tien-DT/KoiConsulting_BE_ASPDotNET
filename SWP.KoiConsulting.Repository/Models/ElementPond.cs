using System;
using System.Collections.Generic;

namespace SWP.KoiConsulting.Repository.Models;

public partial class ElementPond
{
    public int Id { get; set; }

    public int? ElementId { get; set; }

    public int? PondId { get; set; }

    public int? Status { get; set; }

    public virtual Element? Element { get; set; }

    public virtual Pond? Pond { get; set; }
}
