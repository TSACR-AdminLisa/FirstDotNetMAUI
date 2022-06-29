using System.ComponentModel;

namespace TestMauiApp.ViewModel;

public class MainViewModelClassic : INotifyPropertyChanged
{
    string text;
    public string Text 
    {
        get => text;
        set
        {
            text = value;
            OnPropertyChanged(nameof(Text));
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    void OnPropertyChanged(string name) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
}
