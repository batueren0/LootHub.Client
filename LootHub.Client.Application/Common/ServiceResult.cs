namespace LootHub.Client.Application.Common;

public class ServiceResult<T>
{
    public bool IsSuccess { get; }
    public T? Data { get; }
    public string? ErrorMessage { get; }
    public int StatusCode { get; }

    private ServiceResult(bool isSuccess, T? data, string? errorMessage, int statusCode)
    {
        this.IsSuccess = isSuccess;
        this.Data = data;
        this.ErrorMessage = errorMessage;
        this.StatusCode = statusCode;
    }
    public static ServiceResult<T> Success(T data) => new(true, data, null, 200);
    public static ServiceResult<T> Failure(string errorMessage, int statusCode) => new(false, default, errorMessage, statusCode);
}

public class ServiceResult
{
    public bool IsSuccess { get; }
    public string? ErrorMessage { get; }
    public int StatusCode { get; }
    private ServiceResult(bool isSuccess, string? errorMessage, int statusCode)
    {
        this.IsSuccess = isSuccess;
        this.ErrorMessage = errorMessage;
        this.StatusCode = statusCode;
    }
    public static ServiceResult Success() => new(true, null, 200);
    public static ServiceResult Failure(string errorMessage, int statusCode) => new(false, errorMessage, statusCode);
}