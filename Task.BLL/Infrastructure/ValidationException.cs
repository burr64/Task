namespace Task.BLL.Infrastructure;

public class ValidationException : Exception
{
    public ValidationException(string message, string prop) : base(message)
    {
    }
}