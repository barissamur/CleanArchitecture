namespace CleanArchitecture.Application.Common.Models;

public class CustomResult
{
    internal CustomResult(bool succeeded, IEnumerable<string> errors)
    {
        Succeeded = succeeded;
        Errors = errors.ToArray();
    }

    public bool Succeeded { get; init; }

    public string[] Errors { get; init; }

    public static CustomResult Success()
    {
        return new CustomResult(true, Array.Empty<string>());
    }

    public static CustomResult Failure(IEnumerable<string> errors)
    {
        return new CustomResult(false, errors);
    }
}
