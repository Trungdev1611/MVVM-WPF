using System.Collections.ObjectModel;
using Reserveroom.Models;

namespace Reserveroom.viewModels;

public class MainViewModel: ViewModelBase
{
    // Biến này quyết định màn hình nào đang active hiện tại
    private  ViewModelBase _currentViewModel;
    
    //tạo field để lưu trữ danh sách row trong table
    public ObservableCollection <ReservationViewModel> Reservations = [];
    
    public  ObservableCollection<ReservationViewModel> ListReservations => Reservations;

    public  ViewModelBase CurrentViewModel
    {
        get => _currentViewModel;
        set
        {
            _currentViewModel = value;
            OnPropertyChanged(nameof(CurrentViewModel));
        }
        
    }

    

    public void EditReservation(ReservationViewModel itemEdit)
    {
        var makeReservationVM = new MakeReservationViewModel(this);
        makeReservationVM.SetReservationForEdit(itemEdit);
        CurrentViewModel = makeReservationVM;
    }

    public MainViewModel()
    {
        // Ban đầu khởi chạy: Cho CurrentViewModel = màn hình Danh sách
        _currentViewModel = new ReservationListingViewModel(this);
        // CurrentViewModel = new MakeReservationViewModel();
    }
}