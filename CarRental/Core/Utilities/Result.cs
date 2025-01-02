namespace CarRental.Core.Utilities
{
    public class Result : IResult
    {
        public Result(bool success,string message) 
        {
            IsSuccess= success;
            Message= message;
        }

        public bool IsSuccess { get;  set; }
        public string Message { get;  set; }
    }
}
