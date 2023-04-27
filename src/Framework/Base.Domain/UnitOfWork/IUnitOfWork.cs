namespace Framework.Domain.UnitOfWork;

public interface IUnitOfWork
{
    void SaveChanges();
    Task SaveChangesAsync();
}