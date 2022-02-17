using Moq;
using Users.User.Domain;

namespace UsersTest.Domain
{

    public class UserMother 
    {
        public static User Random()
        {
            return User.Create(It.IsAny<UserId>(), It.IsAny<UserName>()); 
        }

        public static User Random(UserId userId, UserName userName)
        {
            return User.Create(userId, userName);
        }
    }
}
