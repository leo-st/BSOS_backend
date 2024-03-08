using System;
using System.Collections.Generic;

namespace BSOSApi.Models;

public partial class Store
{
    public int Id { get; set; }

    public string StoreName { get; set; } = null!;

    public string StoreAdress { get; set; } = null!;

    public string StoreOwner { get; set; } = null!;

    public virtual ICollection<StoreCategory> StoreCategories { get; set; } = new List<StoreCategory>();
}
