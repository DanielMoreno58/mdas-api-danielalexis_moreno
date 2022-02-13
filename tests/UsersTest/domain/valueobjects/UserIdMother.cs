using Users.User.domain;
using Users.User.infraestructure;

namespace UsersTest.domain
{
    public class UserIdMother 
    {
        public static UserId Random()
        {
            return new UserId(GuidCreator.Execute());
        }
    }

}
