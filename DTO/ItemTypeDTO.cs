using System;
using System.Collections.Generic;

namespace DTO;

public partial class ItemTypeDTO
{
    public int ItemTypeId { get; set; }

    public string ItemTypeName { get; set; } = null!;

    public virtual ICollection<CustomProductDTO> CustomProducts { get; set; } = new List<CustomProductDTO>();

    public virtual ICollection<MenuDTO> Menus { get; set; } = new List<MenuDTO>();
}
