using System;
using System.Collections.Generic;

namespace KoiConsulting.Repository.Models;

public partial class Address
{
    public int Id { get; set; }

    public string? City { get; set; }

    public string? AddressDetail { get; set; }

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
