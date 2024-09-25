using System;
using System.Collections.Generic;

namespace KoiConsulting.Repository.Models;

public partial class Pond
{
    public int Id { get; set; }

    public string? Direction { get; set; }

    public virtual ICollection<ElementPond> ElementPonds { get; set; } = new List<ElementPond>();
}
