using System;
using Users.User.domain;
using Users.User.infraestructure;

namespace UsersTest.domain
{
    public class UserIdMother //: TestDataBuilder<UserId, UserIdMother>
    {
        public static UserId Random()
        {
            return new UserId(GuidCreator.Execute());
        }

        //public static UserName WithUserId(UserId userId)
        //{
        //    return User.Create(userId, Arg.Any<UserName>());
        //}
    }

}
