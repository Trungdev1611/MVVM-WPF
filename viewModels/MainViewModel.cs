namespace Reserveroom.viewModels;

public class MainViewModel: ViewModelBase
{
    // Biến này quyết định màn hình nào đang active hiện tại
    private ViewModelBase _currentViewModel;

    public ViewModelBase CurrentViewModel
    {
        get => _currentViewModel;
        set
        {
            _currentViewModel = value;
            OnPropertyChanged(nameof(CurrentViewModel));
        }
        
    }

    public MainViewModel()
    {
        // Ban đầu khởi chạy: Cho CurrentViewModel = màn hình Danh sách
        CurrentViewModel = new ReservationListingViewModel(this);
        // CurrentViewModel = new MakeReservationViewModel();
    }
}