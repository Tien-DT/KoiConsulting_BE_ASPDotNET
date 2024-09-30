using System;
using System.Collections.Generic;

namespace SWP.KoiConsulting.Repository.Models;

public partial class KoiAttributeGroup
{
    public int KoiId { get; set; }

    public int AttributeId { get; set; }

    public virtual KoiType Koi { get; set; } = null!;
}
