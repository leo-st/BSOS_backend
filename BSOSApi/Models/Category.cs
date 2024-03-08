using System;
using System.Collections.Generic;

namespace BSOSApi.Models;

public partial class Category
{
    public int Id { get; set; }

    public string CategoryName { get; set; } = null!;

    public string CategoryDescription { get; set; } = null!;

    public virtual ICollection<StoreCategory> StoreCategories { get; set; } = new List<StoreCategory>();
}
