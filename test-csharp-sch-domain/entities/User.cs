using test_csharp_sch_domain.enums;

namespace test_csharp_sch_domain.entities
{
    public class User
    {
        public string Username { get; }
        public string Password { get; }
        public Roles Role { get; }

        public User(string username, string password, Roles role)
        {
            Username = username;
            Password = password;
            Role = role;
        }
    }
}
