using System;
using System.Collections.Generic;

namespace KoiConsulting.Repository.Models;

public partial class User
{
    public int Id { get; set; }

    public string FullName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string? PhoneNumber { get; set; }

    public int? AddressId { get; set; }

    public int? Status { get; set; }

    public virtual Address? Address { get; set; }

    public virtual ICollection<OrderPackage> OrderPackages { get; set; } = new List<OrderPackage>();

    public virtual ICollection<Post> Posts { get; set; } = new List<Post>();

    public virtual ICollection<Profile> Profiles { get; set; } = new List<Profile>();
}
