namespace Reserveroom.viewModels;

public class MainViewModel: ViewModelBase
{
    // Biến này quyết định màn hình nào đang active hiện tại
    public ViewModelBase CurrentViewModel { get; }

    public MainViewModel()
    {
        // Ban đầu khởi chạy: Cho CurrentViewModel = màn hình Danh sách
        CurrentViewModel = new ReservationListingViewModel();
        // CurrentViewModel = new MakeReservationViewModel();
    }
}