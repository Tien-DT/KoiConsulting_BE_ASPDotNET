using System;
using System.Collections.Generic;

namespace SWP.KoiConsulting.Repository.Models;

public partial class KoiType
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int Status { get; set; }

    public virtual ICollection<ElementKoi> ElementKois { get; set; } = new List<ElementKoi>();

    public virtual ICollection<ElementSpec> ElementSpecs { get; set; } = new List<ElementSpec>();

    public virtual ICollection<KoiAttributeGroup> KoiAttributeGroups { get; set; } = new List<KoiAttributeGroup>();
}
