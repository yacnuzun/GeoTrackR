namespace Core.Response.GenericResults
{
    public interface IDataResult<T> : IResult
    {
        T Data { get; }
    }
}
