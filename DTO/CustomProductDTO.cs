using System;
using System.Collections.Generic;

namespace DTO;

public partial class CustomProductDTO
{
    public int ProductId { get; set; }

    public string ProductName { get; set; } = null!;

    public double Price { get; set; }

    public int ProductTypeId { get; set; }

    public virtual ItemTypeDTO ProductType { get; set; } = null!;
}
