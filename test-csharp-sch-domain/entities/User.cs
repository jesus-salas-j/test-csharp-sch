using test_csharp_sch_domain.enums;

namespace test_csharp_sch_domain.entities
{
    public class User
    {
        public Roles Role { get; }

        public User(Roles role)
        {
            Role = role;
        }
    }
}
