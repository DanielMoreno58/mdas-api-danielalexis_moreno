using Moq;
using Users.User.domain;

namespace UsersTest.domain
{
    public class UserNameMother 
    {
        public static UserName Random()
        {
            return new UserName(It.IsAny<string>());
        }

    }

}
