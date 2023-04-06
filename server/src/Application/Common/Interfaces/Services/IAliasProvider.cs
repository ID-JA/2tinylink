namespace Application.Common.Interfaces.Services
{
    public interface IAliasProvider
    {
        Task<string> GetAliasAsync();
    }
}