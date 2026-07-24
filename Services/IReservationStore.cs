using System.Collections.ObjectModel;
using Reserveroom.Models;

namespace Reserveroom.Services;

/// <summary>
/// Store giữ danh sách reservation — nguồn dữ liệu dùng chung cho mọi màn hình.
/// </summary>
public interface IReservationStore
{
    ObservableCollection<ReservationViewModel> Reservations { get; }

    void Add(ReservationViewModel item);
    void Remove(ReservationViewModel item);
}
