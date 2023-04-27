using Framework.Domain.BaseEntities;
using Framework.Domain.Exceptions;

namespace Framework.Infrastructure.Extensions;

public  static class ExtensionsInFrameworkInfrastructureException
{
    public static void HandleNotFindEntityInRepositoryException<T>(this T? entity ) where T : class
    {
        if (entity == null)
        {
            throw new NotFindEntityInRepositoryException(typeof(T).Name);
        }
    }
    public static void HandleNotFindEntityInRepositoryException<T>(this T? entity , string message) where T : class
    {
        if (entity == null)
        {
            throw new NotFindEntityInRepositoryException(message);
        }
    }
    public static void HandleNullEntityInRepositoryException<T>(this T? entity) where T : class
    {
        if (entity == null)
        {
            throw new NullReferenceException(typeof(T).Name);
        }
    }
    public static void HandleNullEntityInRepositoryException<T>(this T? entity, string message) where T : class
    {
        if (entity == null)
        {
            throw new NullReferenceException(message);
        }
    }
}