namespace Core.Response.GenericResults
{
    public class ErrorResult : Result, IResult
    {
        public ErrorResult(string message) : base(false, message)
        {

        }
        public ErrorResult() : base(false)
        {

        }
    }
}
