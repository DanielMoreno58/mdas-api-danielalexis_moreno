using Users.User.domain;

namespace Users.User.infraestructure
{
    public class InMemoryUserRepository : IUserRepository
    {
        public void Save(domain.User user) {
            // Save user to database
        }
        public domain.User Find(UserId userId) {
            // Find user in database
            throw new UserDoesNotExistException();
        }
    }
}
