using System;
using System.Collections.Generic;

namespace DAL;

public partial class OrderDetail
{
    public int OrderDetailsId { get; set; }

    public int OrderId { get; set; }

    public int ItemId { get; set; }

    public bool? IsReady { get; set; }

    public virtual Menu Item { get; set; } = null!;

    public virtual Order Order { get; set; } = null!;
}
