using Reserveroom.Models;

namespace Reserveroom.Exception;
public class ReservationConflictExceptionException : System.Exception
{

  public Reservation ExistingReservation {get;}
  public Reservation InComingReservation {get;}
  public ReservationConflictExceptionException(Reservation existingReservation,Reservation inComingReservation ) {
    ExistingReservation = existingReservation;
    InComingReservation = inComingReservation;
   }
  public ReservationConflictExceptionException(string message) : base(message) { }
  public ReservationConflictExceptionException(string message, System.Exception inner) : base(message, inner) { }
  protected ReservationConflictExceptionException(
    System.Runtime.Serialization.SerializationInfo info,
    System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
}