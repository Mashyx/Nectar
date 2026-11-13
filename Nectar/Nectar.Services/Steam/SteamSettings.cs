namespace Nectar.Integrations.Steam;

public class SteamSettings
{
    public const string SectionName = "SteamSettings";

    public string ApiKey { get; set; } = string.Empty;
    public ulong UserId { get; set; } = 0;
    public int MaxRetryCount { get; set; }
}