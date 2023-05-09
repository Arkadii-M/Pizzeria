using System;
using System.Collections.Generic;

namespace DAL;

public partial class User
{
    public long UserId { get; set; }

    public string UserName { get; set; } = null!;

    public string? Password { get; set; }

    public string Email { get; set; } = null!;

    public int? RoleId { get; set; }

    public int? UserStatusId { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual Role? Role { get; set; }

    public virtual UserStatus? UserStatus { get; set; }
}
