
namespace Reserveroom.Models;

public class Reservation
{

  public RoomID RoomID { get; }

  public string Username {get;}
  public DateTime StartTime { get; }
  public DateTime EndTime { get; }

  public TimeSpan Length => EndTime - StartTime;

  public Reservation(RoomID roomID, string username, DateTime startTime, DateTime endTime)
  {
    RoomID = roomID;
    StartTime = startTime;
    EndTime = endTime;
    Username = username;
  }

    public bool Conflicts(Reservation reservation) {
    if(reservation.RoomID != RoomID) {
      return false;
    }

    return reservation.StartTime < EndTime && reservation.EndTime > StartTime;
  }

  public override string ToString()
        {
            return $"[Reservation] Khách: {Username} | Phòng: {RoomID} | Từ: {StartTime:dd/MM/yyyy HH:mm} -> Đến: {EndTime:dd/MM/yyyy HH:mm}";
        }
}