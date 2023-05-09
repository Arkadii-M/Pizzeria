using System;
using System.Collections.Generic;

namespace DAL;

public partial class ItemType
{
    public int ItemTypeId { get; set; }

    public string ItemTypeName { get; set; } = null!;

    public virtual ICollection<CustomProduct> CustomProducts { get; set; } = new List<CustomProduct>();

    public virtual ICollection<Menu> Menus { get; set; } = new List<Menu>();
}
