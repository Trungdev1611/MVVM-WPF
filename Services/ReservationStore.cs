using System.Collections.ObjectModel;
using Reserveroom.Models;

namespace Reserveroom.Services;

public class ReservationStore : IReservationStore
{
    public ObservableCollection<ReservationViewModel> Reservations { get; } = [];

    public ReservationStore()
    {
        // Seed data mẫu một lần khi tạo store
        Reservations.Add(new ReservationViewModel(
            new Reservation(new RoomID(1, 12), "Sean", DateTime.Now, DateTime.Now.AddDays(2))));
        Reservations.Add(new ReservationViewModel(
            new Reservation(new RoomID(2, 101), "John", DateTime.Now, DateTime.Now.AddDays(5))));
    }

    public void Add(ReservationViewModel item) => Reservations.Add(item);

    public void Remove(ReservationViewModel item) => Reservations.Remove(item);
}
