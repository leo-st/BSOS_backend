using System;
using System.Collections.Generic;

namespace BSOSApi.Models;

public partial class StoreCategory
{
    public int Id { get; set; }

    public int StoreId { get; set; }

    public int CategoryId { get; set; }

    public virtual Category Category { get; set; } = null!;

    public virtual ICollection<Service> Services { get; set; } = new List<Service>();

    public virtual Store Store { get; set; } = null!;
}
