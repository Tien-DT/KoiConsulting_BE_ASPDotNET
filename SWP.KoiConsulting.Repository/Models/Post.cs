using System;
using System.Collections.Generic;

namespace SWP.KoiConsulting.Repository.Models;

public partial class Post
{
    public int Id { get; set; }

    public int? UserId { get; set; }

    public int? OrderId { get; set; }

    public string? Title { get; set; }

    public string? Detail { get; set; }

    public DateTime? CreatedTime { get; set; }

    public DateTime? ExpTime { get; set; }

    public int? ElementId { get; set; }

    public int? KoiId { get; set; }

    public int? Status { get; set; }

    public virtual OrderPackage? OrderPackage { get; set; }

    public virtual User? User { get; set; }

    public virtual ICollection<WishList> WishLists { get; set; } = new List<WishList>();
}
