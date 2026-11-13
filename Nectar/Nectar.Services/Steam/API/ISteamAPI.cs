using Steam.Models.SteamCommunity;

namespace Nectar.Integrations.Steam.API;

public interface ISteamApi
{
    public Task<PlayerSummaryModel> GetPlayerProfile();
}