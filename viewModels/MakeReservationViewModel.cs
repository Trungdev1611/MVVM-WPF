using System.Windows.Input;

namespace Reserveroom.viewModels;

public class MakeReservationViewModel: ViewModelBase
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
        
    }
}