using Users.User.domain;
using Users.User.infraestructure.Persistence.Contexts;

namespace Users.User.infraestructure.Persistence.Repositories;

public class EFUserRepository : EFGenericRepository<domain.User, UserId>, IUserRepository
{
    public EFUserRepository(UserContext context) : base(context)
    {
    }

    public void Save(domain.User user)
    {
        Upsert(user);
        Save();
    }

    public domain.User Find(UserId userId)
    {
        domain.User user = FindById(userId.Value);
        
        if(user== null)
        {
            throw new UserDoesNotExistException();
        }

        return user;
    }

    public bool Exists(UserId userId)
    {
        return Exists(userId.Value);
    }
}