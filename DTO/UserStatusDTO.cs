using System;
using System.Collections.Generic;

namespace DTO;

public partial class UserStatusDTO
{
    public int UserStatusId { get; set; }

    public string UserStatusName { get; set; } = null!;

    public virtual ICollection<UserDTO> Users { get; set; } = new List<UserDTO>();
}
