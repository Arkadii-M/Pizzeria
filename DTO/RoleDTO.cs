using System;
using System.Collections.Generic;

namespace DTO;

public partial class RoleDTO
{
    public int RoleId { get; set; }

    public string RoleName { get; set; } = null!;

    public virtual ICollection<UserDTO> Users { get; set; } = new List<UserDTO>();
}
