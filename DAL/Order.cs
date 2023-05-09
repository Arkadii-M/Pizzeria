using System;
using System.Collections.Generic;

namespace DAL;

public partial class Order
{
    public int OrderId { get; set; }

    public long UserId { get; set; }

    public DateOnly OrderDate { get; set; }

    public int? OrderStatusId { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

    public virtual OrderStatus? OrderStatus { get; set; }

    public virtual User User { get; set; } = null!;
}
