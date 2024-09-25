using System;
using System.Collections.Generic;

namespace KoiConsulting.Repository.Models;

public partial class Profile
{
    public int Id { get; set; }

    public int? UserId { get; set; }

    public string? Name { get; set; }

    public int? Yob { get; set; }

    public bool? Gender { get; set; }

    public int? ElementId { get; set; }

    public int? WishListId { get; set; }

    public virtual Element? Element { get; set; }

    public virtual User? User { get; set; }
}
