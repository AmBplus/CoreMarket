
using Base.Domain.Date;
using Base.Shared.ResultUtil;

namespace Base.Domain.BaseEntities;

public abstract class BaseEntity<T>
{
    public T Id { get; set; }
    public DateTime CreatedDate { get;private set; }
    public DateTime UpdateDate { get; set; }
    public bool IsRemove { get;private set; } = false;
    public BaseEntity()
    {
        CreatedDate = DateUtility.DateTimeNow();
    }

    public virtual ResultOperation SetRemove()
    {
        IsRemove = true;
        return ResultOperation.BuildSuccessResult();
    }
    public virtual ResultOperation SetUnRemove()
    {
        IsRemove = false;
        return ResultOperation.BuildSuccessResult();
    }
}
