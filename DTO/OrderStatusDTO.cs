using System;
using System.Collections.Generic;

namespace DTO;

public partial class OrderStatusDTO
{
    public int OrderStatusId { get; set; }

    public string OrderStatusName { get; set; } = null!;

    public virtual ICollection<OrderDTO> Orders { get; set; } = new List<OrderDTO>();
}
