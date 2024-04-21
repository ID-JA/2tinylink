namespace Infrastructure.Persistence;
internal class DatabaseSettings
{
    public string DBProvider { get; set; } = string.Empty;
    public string ConnectionString { get; set; } = string.Empty;
}