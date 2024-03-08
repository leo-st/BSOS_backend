using System;
using System.Collections.Generic;

namespace BSOSApi.Models;

public partial class Service
{
    public int Id { get; set; }

    public string ServiceName { get; set; } = null!;

    public string? ServiceDescription { get; set; }

    public double? ServicePrice { get; set; }

    public int? DurationTime { get; set; }

    public int StoreCategoryId { get; set; }

    public virtual StoreCategory StoreCategory { get; set; } = null!;
}
