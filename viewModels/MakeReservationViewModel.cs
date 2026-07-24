using System.Windows.Input;
using Reserveroom.Models;
using Reserveroom.Services;

namespace Reserveroom.viewModels;

public class MakeReservationViewModel : ViewModelBase
{
    private readonly IReservationStore _store;
    private readonly INavigationService _navigation;
    private readonly ReservationViewModel? _editingItem;

    private string _username = string.Empty;
    private int _floorNo;
    private int _roomNo;
    private DateTime _startDate = DateTime.Today;
    private DateTime _endDate = DateTime.Today.AddDays(1);

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

    /// <summary>Create mới.</summary>
    public MakeReservationViewModel(IReservationStore store, INavigationService navigation)
        : this(store, navigation, editingItem: null)
    {
    }

    /// <summary>Edit — truyền sẵn item cần sửa.</summary>
    public MakeReservationViewModel(
        IReservationStore store,
        INavigationService navigation,
        ReservationViewModel? editingItem)
    {
        _store = store;
        _navigation = navigation;
        _editingItem = editingItem;

        if (_editingItem != null)
        {
            Username = _editingItem.UserName;
            FloorNo = _editingItem.FloorNumber;
            RoomNo = _editingItem.RoomNumber;
            StartDate = _editingItem.StartDate;
            EndDate = _editingItem.EndDate;
        }

        MakeReservationSubmitCommand = new RelayCommand(() =>
        {
            if (_editingItem != null)
            {
                _editingItem.UpdateData(Username, FloorNo, RoomNo, StartDate, EndDate);
            }
            else
            {
                var reservation = new Reservation(new RoomID(FloorNo, RoomNo), Username, StartDate, EndDate);
                _store.Add(new ReservationViewModel(reservation));
            }

            NavigateToListing();
        });

        MakeReservationCancelCommand = new RelayCommand(NavigateToListing);
    }

    private void NavigateToListing()
    {
        _navigation.NavigateTo(new ReservationListingViewModel(_store, _navigation));
    }
}
