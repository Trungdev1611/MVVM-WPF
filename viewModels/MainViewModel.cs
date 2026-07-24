using Reserveroom.Services;

namespace Reserveroom.viewModels;

/// <summary>
/// Shell VM — chỉ expose CurrentViewModel từ NavigationService.
/// Không giữ list, không tự navigate nghiệp vụ.
/// </summary>
public class MainViewModel : ViewModelBase
{
    private readonly INavigationService _navigation;

    public ViewModelBase? CurrentViewModel => _navigation.CurrentViewModel;

    public MainViewModel(IReservationStore store, INavigationService navigation)
    {
        _navigation = navigation;
        _navigation.CurrentViewModelChanged += () => OnPropertyChanged(nameof(CurrentViewModel));

        // Màn hình khởi động
        _navigation.NavigateTo(new ReservationListingViewModel(store, navigation));
    }
}
