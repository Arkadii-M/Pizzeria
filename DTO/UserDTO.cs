using System;
using System.Collections.Generic;

namespace DTO;

public partial class UserDTO
{
    public long UserId { get; set; }

    public string UserName { get; set; } = null!;

    public string? Password { get; set; }

    public string Email { get; set; } = null!;

    public int? RoleId { get; set; }

    public int? UserStatusId { get; set; }

    public virtual ICollection<OrderDTO> Orders { get; set; } = new List<OrderDTO>();

    public virtual RoleDTO? Role { get; set; }

    public virtual UserStatusDTO? UserStatus { get; set; }
}
