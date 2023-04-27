namespace Base.Shared.ResultUtil;

/// <summary>
/// اکستنشن هایی جهت راحت کردن استفاده از
/// resultOperation
/// </summary>
public static class UtilityResultExtension
{
    /// <summary>
    /// ساختن یک نتیجه عملیات موفق به صورت جنریک
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="entity"></param>
    /// <returns></returns>
    public static ResultOperation<T> ToSuccessResult<T>(this T entity)
    {
        return ResultOperation<T>.BuildSuccessResult(entity);
    }
    /// <summary>
    /// ساختن یک نتیجه عملیات موفق به صورت جنریک به همراه پیام
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="entity"></param>
    /// <returns></returns>
    public static ResultOperation<T> ToSuccessResult<T>(this T entity, string message)
    {
        return ResultOperation<T>.BuildSuccessResult(message, entity);
    }
    public static ResultOperation<T> ToFailed<T>(this T entity, string message)
    {
        return ResultOperation<T>.BuildFailedResult(message);
    }
    public static ResultOperation<object> ToFailed(this object entity, string message)
    {
        return ResultOperation<object>.BuildFailedResult(message);
    }
    public static ResultOperation<object> ToFailed(this object entity)
    {
        return ResultOperation<object>.BuildFailedResult();
    }
}
