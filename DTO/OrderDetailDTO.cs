using System;
using System.Collections.Generic;

namespace DTO;

public partial class OrderDetailDTO
{
    public int OrderDetailsId { get; set; }

    public int OrderId { get; set; }

    public int ItemId { get; set; }

    public bool? IsReady { get; set; }

    public virtual MenuDTO Item { get; set; } = null!;

    public virtual OrderDTO Order { get; set; } = null!;
}
