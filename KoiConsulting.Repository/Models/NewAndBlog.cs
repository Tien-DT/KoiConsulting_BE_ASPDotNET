using System;
using System.Collections.Generic;

namespace KoiConsulting.Repository.Models;

public partial class NewAndBlog
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string Detail { get; set; } = null!;

    public byte[]? Img { get; set; }

    public DateTime CreatedTime { get; set; }

    public bool Type { get; set; }

    public bool Status { get; set; }

    public int? AuthorId { get; set; }

    public virtual Admin? Author { get; set; }
}
