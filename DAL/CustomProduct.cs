using System;
using System.Collections.Generic;

namespace DAL;

public partial class CustomProduct
{
    public int ProductId { get; set; }

    public string ProductName { get; set; } = null!;

    public double Price { get; set; }

    public int ProductTypeId { get; set; }

    public virtual ItemType ProductType { get; set; } = null!;
}
