using System.Collections.ObjectModel;

namespace Reserveroom.Models;

public class ReservationModel
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

    public ReservationModel(Reservation reservation)
    {
        _reservation = reservation;
    }
}