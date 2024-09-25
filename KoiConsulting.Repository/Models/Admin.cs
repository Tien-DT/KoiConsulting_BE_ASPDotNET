using System;
using System.Collections.Generic;

namespace KoiConsulting.Repository.Models;

public partial class Admin
{
    public int Id { get; set; }

    public string? FullName { get; set; }

    public byte[]? Password { get; set; }

    public string? Email { get; set; }

    public bool? Status { get; set; }

    public bool? IsAdmin { get; set; }

    public virtual ICollection<NewAndBlog> NewAndBlogs { get; set; } = new List<NewAndBlog>();
}
