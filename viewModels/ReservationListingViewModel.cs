using System.Collections.ObjectModel;
using System.Windows.Input;
using Reserveroom.Models;

namespace Reserveroom.viewModels;

public class ReservationListingViewModel : ViewModelBase
{
    //tạo field để lưu trữ danh sách row trong table
    private readonly ObservableCollection<ReservationViewModel> _reservations;
    public ObservableCollection<ReservationViewModel> Reservations => _reservations; //ép kiểu từ ObservableCollection<Reservation> sang IEnumerable<Reservation>
    //     public ObservableCollection<Reservation> Reservations tương đương bên trên
    // {
    //     get
    //     {
    //         return _reservations;
    //     }
    // }
    //tạo property để trả về danh sách row trong table

    public ICommand MakeReservationCommand { get; } //readonly command - nút bấm trong ReservationListingView.xaml



    public ReservationListingViewModel(MainViewModel mainViewModel)
    {
        _reservations = new ObservableCollection<ReservationViewModel>();
        // 2. SET DATA DEFAULT (Thêm dữ liệu mẫu ban đầu vào đây)
        Reservations.Add(new ReservationViewModel(new Models.Reservation(new Models.RoomID(1, 12), "Sean", DateTime.Now, DateTime.Now.AddDays(2))));
        Reservations.Add(new ReservationViewModel(new Models.Reservation(new Models.RoomID(2, 101), "John",
            DateTime.Now, DateTime.Now.AddDays(5))));

        
        MakeReservationCommand = new RelayCommand(() =>
        {
            mainViewModel.CurrentViewModel = new MakeReservationViewModel(mainViewModel,"TrungPham",1, 102 );
        });

    }


}