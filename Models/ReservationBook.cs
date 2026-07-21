using Reserveroom.Exception;
using Reservoom.Models;

namespace Reserveroom.Models;

public class ReservationBook
{
  private readonly List<Reservation> _roomReservations;

  public ReservationBook() {
    _roomReservations = new List<Reservation>();
  }

  public IEnumerable<Reservation> GetReservationsForUser(string Username) {
    return _roomReservations.Where(reservation => reservation.Username == Username);
  }

  public void AddReservation(Reservation reservation) {
    foreach (Reservation existingReservation in _roomReservations)
    {
      if(existingReservation.Conflicts(reservation)) {
        throw new ReservationConflictExceptionException(existingReservation, reservation);
      }
    }
    _roomReservations.Add(reservation);
  }


}