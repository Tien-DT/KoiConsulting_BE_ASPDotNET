using System;
using System.Collections.Generic;

namespace KoiConsulting.Repository.Models;

public partial class Element
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<ElementCalculator> ElementCalculators { get; set; } = new List<ElementCalculator>();

    public virtual ICollection<ElementKoi> ElementKois { get; set; } = new List<ElementKoi>();

    public virtual ICollection<ElementPond> ElementPonds { get; set; } = new List<ElementPond>();

    public virtual ICollection<Profile> Profiles { get; set; } = new List<Profile>();
}
