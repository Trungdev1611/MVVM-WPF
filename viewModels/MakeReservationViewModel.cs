using System.Windows;
using System.Windows.Input;
using Reserveroom.Models;

namespace Reserveroom.viewModels;

public class MakeReservationViewModel : ViewModelBase
{
    private string _username;
    private int _floorNo;
    private int _roomNo;
    private DateTime _startDate;
    private DateTime _endDate;

    // Username property in MakeReservationViewModel
    public string Username
    {
        get => _username;
        set
        {
            _username = value;
            OnPropertyChanged(nameof(Username));
        }
    }

    // Floor No property in MakeReservationViewModel
    public int FloorNo
    {
        get => _floorNo;
        set
        {
            _floorNo = value;
            OnPropertyChanged(nameof(FloorNo));
        }
    }
    // Room No property in MakeReservationViewModel
    public int RoomNo
    {
        get => _roomNo;
        set
        {
            _roomNo = value;
            OnPropertyChanged(nameof(RoomNo));
        }
    }
    // Start Date property in MakeReservationViewModel
    public DateTime StartDate
    {
        get => _startDate;
        set
        {
            _startDate = value;
            OnPropertyChanged(nameof(StartDate));
        }
    }

    //End Date property in MakeReservationViewModel
    public DateTime EndDate
    {
        get => _endDate;
        set
        {
            _endDate = value;
            OnPropertyChanged(nameof(EndDate));
        }
    }

    // button submit command
    public ICommand MakeReservationSubmitCommand { get; }

    //cancel button command
    public ICommand MakeReservationCancelCommand { get; }

    public MakeReservationViewModel()
    {
        // Set giá trị mặc định khi ViewModel này được khởi tạo

    }

    // Constructor 2: Cho phép gọi và truyền dữ liệu từ bên ngoài vào
    public MakeReservationViewModel(MainViewModel mainViewModel, string defaultUsername, int defaultFloor, int defaultRoom)
    {
        _username = defaultUsername;
        _floorNo = defaultFloor;
        _roomNo = defaultRoom;
        _startDate = DateTime.Today;
        _endDate = DateTime.Today.AddDays(1);

        this.MakeReservationSubmitCommand = new RelayCommand(() =>
        {
            ReservationViewModel itemAddNew = null!;
            var reservationNew = new Reservation(new RoomID(this._floorNo, this._roomNo), this._username
                , this._startDate, this._endDate);
            itemAddNew = new ReservationViewModel(reservationNew, onDelete: () => mainViewModel.ListReservations.Remove(itemAddNew) );
            
            mainViewModel.ListReservations.Add(itemAddNew);
            this.NavigationToReservation(mainViewModel);
        });

        this.MakeReservationCancelCommand = new RelayCommand(() =>
        {
            this.NavigationToReservation(mainViewModel);
        });
    }

    private void NavigationToReservation(MainViewModel mainViewModel)
    {
        mainViewModel.CurrentViewModel = new ReservationListingViewModel(mainViewModel);

    }

}