using System;
using System.Collections.Generic;

namespace DTO;

public partial class OrderDTO
{
    public int OrderId { get; set; }

    public long UserId { get; set; }

    public DateOnly OrderDate { get; set; }

    public int? OrderStatusId { get; set; }

    public virtual ICollection<OrderDetailDTO> OrderDetails { get; set; } = new List<OrderDetailDTO>();

    public virtual OrderStatusDTO? OrderStatus { get; set; }

    public virtual UserDTO? User { get; set; } = null!;
}
