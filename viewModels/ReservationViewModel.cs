using Reserveroom.viewModels;

namespace Reserveroom.Models;

/// <summary>Row item — chỉ data. Edit/Delete do Listing VM + Store xử lý.</summary>
public class ReservationViewModel : ViewModelBase
{
    private Reservation _reservation;

    public int FloorNumber => _reservation.RoomID?.FloorNumber ?? 0;
    public int RoomNumber => _reservation.RoomID?.RoomNumber ?? 0;
    public string RoomID => _reservation.RoomID?.ToString() ?? string.Empty;
    public string UserName => _reservation.Username;
    public DateTime StartDate => _reservation.StartTime;
    public DateTime EndDate => _reservation.EndTime;

    public ReservationViewModel(Reservation reservation)
    {
        _reservation = reservation;
    }

    public void UpdateData(string username, int floorNo, int roomNo, DateTime startDate, DateTime endDate)
    {
        _reservation = new Reservation(new RoomID(floorNo, roomNo), username, startDate, endDate);

        OnPropertyChanged(nameof(UserName));
        OnPropertyChanged(nameof(RoomID));
        OnPropertyChanged(nameof(FloorNumber));
        OnPropertyChanged(nameof(RoomNumber));
        OnPropertyChanged(nameof(StartDate));
        OnPropertyChanged(nameof(EndDate));
    }
}
