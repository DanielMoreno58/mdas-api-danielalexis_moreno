using Microsoft.EntityFrameworkCore;
using Users.User.infraestructure.Persistence.Contexts;

namespace Users.User.infraestructure.Persistence.Repositories;

public class EFGenericRepository<TEntity, TEntityId>
    where TEntity : class
{
    private readonly UserContext _context;
    private readonly DbSet<TEntity> _dbSet;
    public EFGenericRepository(UserContext context)
    {
        _context = context;
        _dbSet = context.Set<TEntity>();
    }

    public virtual void Edit(TEntity entity)
    {
        dynamic e = entity as dynamic;
        dynamic entityToUpdate = FindById(e.Id.Value);
        entityToUpdate.Update(entity);

        _dbSet.Attach(entityToUpdate);
        _context.Entry(entityToUpdate).State = EntityState.Modified;
    }
    public virtual void Delete(Guid id)
    {
        TEntity entityToDelete = FindById(id);
        Delete(entityToDelete);
    }

    public virtual void Delete(TEntity entityToDelete)
    {
        if (_context.Entry(entityToDelete).State == EntityState.Detached)
        {
            _dbSet.Attach(entityToDelete);
        }
        _dbSet.Remove(entityToDelete);
    }
    public virtual void Insert(TEntity entity)
    {
        _dbSet.Add(entity);
    }

    public virtual void Upsert(TEntity entity)
    {
        dynamic e = entity as dynamic;
        if (!Exists(e.Id.Value))
        {
            Insert(entity);
        }
        else
        {
            Edit(entity);
        }
    }

    public virtual TEntity? FindById(Guid id)
    {
        TEntityId entityId = (TEntityId)Activator.CreateInstance(typeof(TEntityId), id);
        return _dbSet.Find(entityId);
    }

    public virtual bool Exists(Guid id)
    {
        TEntityId entityId = (TEntityId)Activator.CreateInstance(typeof(TEntityId), id);
        return _dbSet.Find(entityId) != null;
    }

    public virtual List<TEntity> GetAll()
    {
        return _dbSet.ToList();
    }

    public void Save()
    {
        _context.SaveChanges();
    }
}
