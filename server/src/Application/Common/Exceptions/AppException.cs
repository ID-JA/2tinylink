namespace Application.Common.Exceptions
{
    public class AppException : Exception
    {
        public AppException(int statusCode, string errorMessage, string code = null)
        {
            StatusCode   = statusCode;
            ErrorMessage = errorMessage;
            Code         = code;
        }
        public int StatusCode { get; }
        public string ErrorMessage { get; }
        public string Code { get; set; }
    }
}