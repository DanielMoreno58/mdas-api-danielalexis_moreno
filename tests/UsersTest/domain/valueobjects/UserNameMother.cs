using System;
using Moq;
using Users.User.domain;

namespace UsersTest.domain
{
    public class UserNameMother //: TestDataBuilder<UserName, UserNameMother>
    {
        public static UserName Random()
        {
            return new UserName(It.IsAny<string>());
        }

        //public static UserName WithUserId(UserId userId)
        //{
        //    return User.Create(userId, Arg.Any<UserName>());
        //}
    }

}
