using System.Collections.ObjectModel;
using System.Windows.Input;
using Reserveroom.viewModels;

namespace Reserveroom.Models;

public class ReservationViewModel:ViewModelBase
{
    private  Reservation _reservation;

    public int FloorNumber => _reservation.RoomID?.FloorNumber ?? 0;
    public int RoomNumber => _reservation.RoomID?.RoomNumber ?? 0;
    public string RoomID
    {
        get
        {
            return _reservation.RoomID?.ToString();
        }
    }
    public string UserName => _reservation.Username;
    public DateTime StartDate => _reservation.StartTime;
    public DateTime EndDate => _reservation.EndTime;

    public void UpdateData(string username, int floorNo, int roomNo, DateTime startDate, DateTime endDate)
{
    // 1. Cập nhật Model bên trong
    _reservation = new Reservation(new RoomID(floorNo, roomNo), username, startDate, endDate);

    // 2. Báo UI cập nhật lại các cột tương ứng
    OnPropertyChanged(nameof(UserName));
    OnPropertyChanged(nameof(RoomID));
    OnPropertyChanged(nameof(FloorNumber));
    OnPropertyChanged(nameof(RoomNumber));
    OnPropertyChanged(nameof(StartDate));
    OnPropertyChanged(nameof(EndDate));
}
    
    public ICommand DeleteReservationCommand { get; }

    public ICommand EditReservationCommand {get;}

    public ReservationViewModel(Reservation reservation, Action onDelete=null, Action onEdit = null)
    {
        _reservation = reservation;
        DeleteReservationCommand = new RelayCommand(() => onDelete());
        EditReservationCommand = new RelayCommand(() => onEdit());
    }
    
   
}