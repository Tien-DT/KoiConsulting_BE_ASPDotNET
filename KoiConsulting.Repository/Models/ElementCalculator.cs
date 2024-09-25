using System;
using System.Collections.Generic;

namespace KoiConsulting.Repository.Models;

public partial class ElementCalculator
{
    public int ElementId { get; set; }

    public int Number { get; set; }

    public virtual Element Element { get; set; } = null!;
}
