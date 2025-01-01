namespace Core.Shared;

public class Result
{
    private Result(bool isSuccess, Error error)
    {
        if ((isSuccess && error != Error.Empty) ||
            (!isSuccess && error == Error.Empty))
            throw new ArgumentException("Invalid error", nameof(error));

        IsSuccess = isSuccess;
        Error = error;
    }

    public bool IsSuccess { get; }
    public bool IsFailure => !IsSuccess;
    public Error Error { get; }

    public static Result Success()
    {
        return new Result(true, null);
    }

    public static Result Failure(Error error)
    {
        return new Result(false, error);
    }
}