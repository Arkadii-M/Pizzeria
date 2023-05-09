using System;
using System.Collections.Generic;

namespace DAL;

public partial class Menu
{
    public int ItemId { get; set; }

    public string ItemName { get; set; } = null!;

    public double Price { get; set; }

    public int ItemTypeId { get; set; }

    public bool? IsCustom { get; set; }

    public virtual ItemType ItemType { get; set; } = null!;

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
}
