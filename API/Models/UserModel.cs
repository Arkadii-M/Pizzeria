namespace API.Models
{
    public class UserModel
    {
        public long Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
        public RoleModel Role { get; set; }
    }
}
