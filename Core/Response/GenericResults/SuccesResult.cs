namespace Core.Response.GenericResults
{
    public class SuccesResult : Result, IResult
    {
        public SuccesResult(string message) : base(true, message)
        {

        }
        public SuccesResult() : base(true)
        {

        }

    }
}
