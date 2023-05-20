using System;
using System.Collections.Generic;

namespace DTO;

public partial class MenuDTO
{
    public int ItemId { get; set; }

    public string ItemName { get; set; } = null!;

    public double Price { get; set; }

    public int ItemTypeId { get; set; }

    public bool? IsCustom { get; set; }

    public virtual ItemTypeDTO ItemType { get; set; } = null!;

    //public virtual ICollection<OrderDetailDTO> OrderDetails { get; set; } = new List<OrderDetailDTO>();
}
