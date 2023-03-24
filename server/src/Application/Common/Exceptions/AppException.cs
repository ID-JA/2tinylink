namespace Application.Common.Exceptions
{
    public class AppException : Exception
    {
        public AppException(int statusCode, string errorMessage)
        {
            StatusCode = statusCode;
            ErrorMessage = errorMessage;
        }
        public int StatusCode { get; }
        public string ErrorMessage { get; }
    }
}