namespace EducationSystem.Service.Exceptions;

public class CustomException : Exception
{
    public int StatusCode {  get; set; }
    public CustomException(int statusCode, string Message) : base(Message)
    {
        StatusCode = statusCode;
    }
}
