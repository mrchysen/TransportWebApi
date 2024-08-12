using Core;

namespace Data;

public class UnitOfWork : IUnitOfWork
{
    public ApplicationDbContext Context { get; init; }
    public UnitOfWork(ApplicationDbContext context)
    {
        Context = context;
    }
    public void Save()
    {
        Context.SaveChanges();
    }
}
