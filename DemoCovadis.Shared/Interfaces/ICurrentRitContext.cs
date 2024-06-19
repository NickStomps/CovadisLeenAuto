using DemoCovadis.Shared.Dtos;

namespace DemoCovadis.Shared.Interfaces;

internal class ICurrentRitContext
{
    public CurrentRit Rit { get; }
    public bool IsAuthenticated { get; }

    public record CurrentRit(
        int id,
        int AutoId,
        AutoDto? auto,
        int kilometerGereden,
        UserDto? bestuurder,
        string beginAdres,
        string eindAdres,
        string vertrekTijd,
        string aankomstTijd
        );
}
