
namespace WebApp.Models;

public class ProjectViewModel
{
    public string Id { get; set; } = Guid.NewGuid().ToString();

    public string ProjectImage { get; set; } = string.Empty;
    public string ProjectName { get; set; } = string.Empty;

    public string ClientName { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;

    public string TimeLeft { get; set; } = string.Empty;

    public IEnumerable<string> Members { get; set; } = [];


}