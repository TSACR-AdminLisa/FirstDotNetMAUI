using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace TestMauiApp.ViewModel;

public partial class MainViewModel : ObservableObject
{
    IConnectivity connectivity;

    [ObservableProperty]
    ObservableCollection<string> items;
    
    [ObservableProperty]
    string text;

    public MainViewModel(IConnectivity connectivity)
    {
        Items = new ObservableCollection<string>();
        this.connectivity = connectivity;
    }

    [RelayCommand]
    async Task Add()
    { 
        if (string.IsNullOrWhiteSpace(Text))
            return;

        if (connectivity.NetworkAccess != NetworkAccess.Internet)
        {
            await Shell.Current.DisplayAlert("Uh Oh!", "No Internet", "OK");
            return;
        }

        Items.Add(Text);

        Text = string.Empty;
    }

    [RelayCommand]
    void Delete(string itemValue)
    {
        if (!string.IsNullOrWhiteSpace(itemValue))
        { 
            Items.Remove(itemValue);
        }
    }

    [RelayCommand]
    async Task Tap(string itemValue)
    {
        if (!string.IsNullOrWhiteSpace(itemValue))
        {
            await Shell.Current.GoToAsync($"{nameof(DetailPage)}?Value={itemValue}");
        }
    }
}
