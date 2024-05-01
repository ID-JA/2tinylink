namespace Application.Common.Exceptions
{
    public class AppException : Exception
    {
        public AppException(int statusCode, string errorMessage, List<string>? errorMessages = default) : base(errorMessage)
        {
            StatusCode = statusCode;
            ErrorMessages = errorMessages;
        }
        public int StatusCode { get; }
        public string ErrorMessage { get; }
        public List<string> ErrorMessages { get; set;}
    }
}