using CommunityToolkit.Mvvm.ComponentModel;
using Nectar.Integrations.Steam.API;
using Nectar.Public.Views;

namespace Nectar.Public.ViewModels;

public partial class HomeViewModel : ViewModelBase<HomeView>
{
    private ISteamApi _steamApi;
    
    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(GetWelcomeMessage))]
    private string _userName = "";

    public string GetWelcomeMessage => UserName == "" ? "Welcome!" : $"Welcome {UserName}";
    

    public HomeViewModel(ISteamApi steamApi) : base()
    {
        _steamApi = steamApi;


        _ = LoadDataAsync();
    }
    
    



    private async Task LoadDataAsync()
    {
        var user = await _steamApi.GetPlayerProfile();
        UserName = user.Nickname;
    }
}