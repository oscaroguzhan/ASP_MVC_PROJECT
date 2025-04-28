
namespace Data.Models;

public class RepositoryResults<T>
{
    public bool Success { get; set; }
    public int StatusCode { get; set; }
    public string? Error { get; set; }

    public T? Result { get; set; }
    
}
