using System.ComponentModel;

namespace Reserveroom.viewModels;

public class ViewModelBase: INotifyPropertyChanged
{
    
    public event PropertyChangedEventHandler? PropertyChanged;

    protected void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}