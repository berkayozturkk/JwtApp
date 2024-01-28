namespace JwtApp.Core.Application.Dto;

public class Result
{
    public string? Message { get; set; }
    public bool IsSuccessful { get; set; }
    public object? Data { get; set; }

    public Result()
    {
        
    }

    public Result(bool isSuccessful)
    {
        IsSuccessful = isSuccessful;
    }

    public Result(string? message, bool ısSuccessful, object? data)
    {
        Message = message;
        IsSuccessful = ısSuccessful;
        Data = data;
    }
}
