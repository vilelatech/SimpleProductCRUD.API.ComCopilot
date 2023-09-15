namespace SimpleProductCRUD.API.ComCopilot.Validations;

public class ExceptionValidation : Exception
{
    public ExceptionValidation(string message) : base(message)
    {
    }

    public static void When(bool hasError, string message)
    {
        if (hasError)
            throw new ExceptionValidation(message);
    }
}