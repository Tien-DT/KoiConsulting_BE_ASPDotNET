using System;
using System.Collections.Generic;

namespace KoiConsulting.Repository.Models;

public partial class KoiType
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int Status { get; set; }

    public virtual ICollection<ElementKoiDetail> ElementKoiDetails { get; set; } = new List<ElementKoiDetail>();

    public virtual ICollection<ElementKoi> ElementKois { get; set; } = new List<ElementKoi>();

    public virtual ICollection<KoiAttribute> KoiAttributes { get; set; } = new List<KoiAttribute>();
}
