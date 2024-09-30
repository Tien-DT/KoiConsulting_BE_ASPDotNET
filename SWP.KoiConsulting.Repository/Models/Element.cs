using System;
using System.Collections.Generic;

namespace SWP.KoiConsulting.Repository.Models;

public partial class Element
{
    public int Num { get; set; }

    public int Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<ElementCalculator> ElementCalculators { get; set; } = new List<ElementCalculator>();

    public virtual ICollection<ElementKoi> ElementKois { get; set; } = new List<ElementKoi>();

    public virtual ICollection<ElementPond> ElementPonds { get; set; } = new List<ElementPond>();

    public virtual ICollection<ElementSpec> ElementSpecs { get; set; } = new List<ElementSpec>();

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
