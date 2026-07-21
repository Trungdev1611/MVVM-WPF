using System.Configuration;
using System.Data;
using System.Windows;
using Reserveroom.Exception;
using Reserveroom.Models;
using Reservoom.Models;

namespace Reserveroom;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
  protected override void OnStartup(StartupEventArgs e)
  {

    try
    {
      Hotel hotel = new("Trung Hotel");
      hotel.MakeReservation(new Reservation(
        new RoomID(1, 3), // RoomID: Phòng 3, Tầng 1
        "PhamTrung", // Username/Tên khách đặt
        new DateTime(2026, 7, 22), // StartTime
        new DateTime(2026, 7, 25)  // EndTime
      ));

      hotel.MakeReservation(new Reservation(
      new RoomID(1, 3), // RoomID: Phòng 2, Tầng 1
      "PhamTrung", // Username/Tên khách đặt
      new DateTime(2026, 7, 22), // StartTime
      new DateTime(2026, 7, 28)  // EndTime
    ));
      IEnumerable<Reservation> listReverstation = hotel.GetReservationsForUser("PhamTrung");

      foreach (Reservation reservation in listReverstation)
      {
        Console.WriteLine(reservation);

      }
      base.OnStartup(e);
    }
    catch (ReservationConflictExceptionException ex)
    {
      Console.WriteLine($"Message error: {ex.Message}");
      throw;
    }

  }
}

