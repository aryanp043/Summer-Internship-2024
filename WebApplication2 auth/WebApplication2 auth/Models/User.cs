namespace WebApplication2_auth.Models
{
    public class User
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
    public class RequestUser
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
