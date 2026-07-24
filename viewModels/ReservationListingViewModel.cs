using System.Collections.ObjectModel;
using System.Windows.Input;
using Reserveroom.Models;

namespace Reserveroom.viewModels;

public class ReservationListingViewModel : ViewModelBase
{
    public ObservableCollection<ReservationViewModel> Reservations
    {
        get;
    }

    //tạo property để trả về danh sách row trong table

    public ICommand MakeReservationCommand
    {
        get;
    } //readonly command - nút bấm trong ReservationListingView.xaml


    public ReservationListingViewModel(MainViewModel mainViewModel)
    {
        Reservations = mainViewModel.ListReservations;
        // 2. SET DATA DEFAULT (Thêm dữ liệu mẫu ban đầu vào đây)
        // 🟢 3. Thêm dữ liệu mẫu (Chỉ thêm nếu danh sách đang trống để tránh bị trùng lặp)
        if (Reservations.Count == 0)
        {
            ReservationViewModel item1 = null!;
            item1 = new ReservationViewModel(
                new Models.Reservation(new Models.RoomID(1, 12), "Sean", DateTime.Now, DateTime.Now.AddDays(2))
                , onDelete: () => Reservations.Remove(item1));
            Reservations.Add(item1);
            
            ReservationViewModel item2 = null!;
            item2 = new ReservationViewModel(
                new Models.Reservation(new Models.RoomID(2, 101), "John", DateTime.Now, DateTime.Now.AddDays(5))
                , onDelete: () => Reservations.Remove(item2));
            Reservations.Add(item2);
        }

        ;
        MakeReservationCommand = new RelayCommand(() =>
        {
            mainViewModel.CurrentViewModel = new MakeReservationViewModel(mainViewModel, "TrungPham", 1, 102);
        });
    }
}