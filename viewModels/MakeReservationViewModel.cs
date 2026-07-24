using System.Windows.Input;
using Reserveroom.Models;

namespace Reserveroom.viewModels;

public class MakeReservationViewModel : ViewModelBase
{
    private string _username = string.Empty;
    private int _floorNo;
    private int _roomNo;
    private DateTime _startDate = DateTime.Today;
    private DateTime _endDate = DateTime.Today.AddDays(1);

    private ReservationViewModel? _editingItem;

    public string Username
    {
        get => _username;
        set
        {
            _username = value;
            OnPropertyChanged(nameof(Username));
        }
    }

    public int FloorNo
    {
        get => _floorNo;
        set
        {
            _floorNo = value;
            OnPropertyChanged(nameof(FloorNo));
        }
    }

    public int RoomNo
    {
        get => _roomNo;
        set
        {
            _roomNo = value;
            OnPropertyChanged(nameof(RoomNo));
        }
    }

    public DateTime StartDate
    {
        get => _startDate;
        set
        {
            _startDate = value;
            OnPropertyChanged(nameof(StartDate));
        }
    }

    public DateTime EndDate
    {
        get => _endDate;
        set
        {
            _endDate = value;
            OnPropertyChanged(nameof(EndDate));
        }
    }

    public ICommand MakeReservationSubmitCommand { get; }
    public ICommand MakeReservationCancelCommand { get; }

    public void SetReservationForEdit(ReservationViewModel itemEdit)
    {
        if (itemEdit == null) return;

        Username = itemEdit.UserName;
        FloorNo = itemEdit.FloorNumber;
        RoomNo = itemEdit.RoomNumber;
        StartDate = itemEdit.StartDate;
        EndDate = itemEdit.EndDate;
        _editingItem = itemEdit;
    }

    public MakeReservationViewModel(MainViewModel mainViewModel)
    {
        MakeReservationSubmitCommand = new RelayCommand(() =>
        {
            if (_editingItem != null)
            {
                _editingItem.UpdateData(Username, FloorNo, RoomNo, StartDate, EndDate);
            }
            else
            {
                // Chỉ tạo data — không cần gắn onEdit/onDelete
                var reservation = new Reservation(new RoomID(FloorNo, RoomNo), Username, StartDate, EndDate);
                mainViewModel.ListReservations.Add(new ReservationViewModel(reservation));
            }

            NavigationToReservation(mainViewModel);
        });

        MakeReservationCancelCommand = new RelayCommand(() =>
        {
            NavigationToReservation(mainViewModel);
        });
    }

    private void NavigationToReservation(MainViewModel mainViewModel)
    {
        mainViewModel.CurrentViewModel = new ReservationListingViewModel(mainViewModel);
    }
}
