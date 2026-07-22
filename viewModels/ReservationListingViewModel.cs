using System.Collections.ObjectModel;
using System.Windows.Input;
using Reserveroom.Models;

namespace Reserveroom.viewModels;

public class ReservationListingViewModel : ViewModelBase
{
    //tạo field để lưu trữ danh sách row trong table
    private readonly ObservableCollection<ReservationModel> _reservations;
    public ObservableCollection<ReservationModel> Reservations => _reservations; //ép kiểu từ ObservableCollection<Reservation> sang IEnumerable<Reservation>
    //     public ObservableCollection<Reservation> Reservations tương đương bên trên
    // {
    //     get
    //     {
    //         return _reservations;
    //     }
    // }
    //tạo property để trả về danh sách row trong table

    public ICommand MakeReservationCommand { get; } //readonly command

    public ReservationListingViewModel()
    {
        _reservations = new ObservableCollection<ReservationModel>();

      
    }


}