namespace Core.Response.GenericResults
{
    public interface IResult
    {
        public bool Success { get; }
        public string Message { get; }
    }
}
