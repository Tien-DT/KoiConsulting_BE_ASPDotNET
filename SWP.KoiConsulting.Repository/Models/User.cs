using System;
using System.Collections.Generic;

namespace SWP.KoiConsulting.Repository.Models;

public partial class User
{
    public int Id { get; set; }

    public string? FullName { get; set; }

    public string? Email { get; set; }

    public int? Yob { get; set; }

    public string? Password { get; set; }

    public string? PhoneNumber { get; set; }

    public int? AddressId { get; set; }

    public int? Status { get; set; }

    public bool? Gender { get; set; }

    public int? Role { get; set; }

    public int? ElementId { get; set; }

    public virtual Address? Address { get; set; }

    public virtual Element? Element { get; set; }

    public virtual ICollection<NewAndBlog> NewAndBlogs { get; set; } = new List<NewAndBlog>();

    public virtual ICollection<OrderPackage> OrderPackages { get; set; } = new List<OrderPackage>();

    public virtual ICollection<Post> Posts { get; set; } = new List<Post>();

    public virtual ICollection<WishList> WishLists { get; set; } = new List<WishList>();
}
