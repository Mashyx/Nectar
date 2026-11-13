using Microsoft.Extensions.Options;
using Nectar.Integrations.Steam;
using Nectar.Integrations.Steam.API;
using Steam.Models.SteamCommunity;
using SteamWebAPI2.Interfaces;
using SteamWebAPI2.Utilities;

namespace Nectar.Services.Steam.API;

public class SteamApiService : ISteamApi
{
    private readonly SteamSettings _steamSettings;
    private readonly HttpClient _httpClient;

    public SteamApiService(IOptions<SteamSettings> settings)
    {
        _steamSettings = settings.Value;
        _httpClient = new HttpClient();
    }

    public async Task<PlayerSummaryModel> GetPlayerProfile()
    {
        SteamWebInterfaceFactory factory = GetInterfaceFactory();
        var userInterface = factory.CreateSteamWebInterface<SteamUser>(_httpClient);
        
        var response = await userInterface.GetPlayerSummaryAsync(_steamSettings.UserId);
        return response.Data;
    }

    private SteamWebInterfaceFactory GetInterfaceFactory()
    {
        return new SteamWebInterfaceFactory(_steamSettings.ApiKey);
    }
}