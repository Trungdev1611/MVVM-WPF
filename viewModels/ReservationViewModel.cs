using System.Collections.ObjectModel;
using System.Windows.Input;
using Reserveroom.viewModels;

namespace Reserveroom.Models;

public class ReservationViewModel
{
    private readonly Reservation _reservation;
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
    
    public ICommand DeleteReservationCommand { get; }

    public ReservationViewModel(Reservation reservation, Action onDelete)
    {
        _reservation = reservation;
        DeleteReservationCommand = new RelayCommand(() => onDelete());
    }
    
   
}