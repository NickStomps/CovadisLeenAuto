namespace DemoCovadis.Shared.Interfaces;

public interface ICurrentUserContext
{
    public CurrentUser User { get; }
    public bool IsAuthenticated { get; }
    public bool IsInRole(string role);

    public record CurrentUser(
        int Id,
        string Naam,
        string Email,
        List<string> Roles);
}