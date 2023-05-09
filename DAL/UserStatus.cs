using System;
using System.Collections.Generic;

namespace DAL;

public partial class UserStatus
{
    public int UserStatusId { get; set; }

    public string UserStatusName { get; set; } = null!;

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
