using Users.User.domain;
using Users.User.infraestructure.Persistence.Contexts;

namespace Users.User.infraestructure.Persistence.Repositories;

public class InMemoryUserRepository : IUserRepository
{    
    private readonly List<domain.User> _users;
  
    public InMemoryUserRepository(UserContext context)
    {        
        _users = context.Set<domain.User>();
    }

    public void Save(domain.User user)
    {
        Upsert(user);        
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
        return _users.Where(u=>u.Id.Value == userId.Value).Any();
    }

    #region Metodos privados

    private void Insert(domain.User user)
    {
        _users.Add(user);
    }

    private void Delete(domain.User user)
    {
        int index = FindIndex(user.Id);
        domain.User userToDeleted = _users[index];
        _users.Remove(userToDeleted);
    }

    private void Update(domain.User user)
    {
        int index = FindIndex(user.Id);        
        _users[index] = user;
    }

    private domain.User FindById(Guid userId)
    {
        return _users.FirstOrDefault(u => u.Id.Value == userId)!;
    }

    private int FindIndex(UserId userId)
    {
        int index = _users.FindIndex(u => u.Id.Value == userId.Value);
        return index;
    }
    private void Upsert(domain.User user)
    {
        int index = FindIndex(user.Id);

        if (index == -1)
        {
            Insert(user);
        }
        else
        {
            Update(user);
        }
    }
 
    #endregion
}