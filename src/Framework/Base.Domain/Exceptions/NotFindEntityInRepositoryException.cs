namespace Framework.Domain.Exceptions;

public  class NotFindEntityInRepositoryException : Exception
{
    public NotFindEntityInRepositoryException() : base("انتیتی مورد نظر یافت نشد")
    {
    }
    public NotFindEntityInRepositoryException(string message) : base(message)
    {
    }
}