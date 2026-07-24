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

    private ReservationViewModel? _editingItem ; 

    private ReservationViewModel _itemDefault = new ReservationViewModel(new Reservation(new RoomID(3, 301), "usertest",DateTime.Today,DateTime.Today.AddDays(1)));

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

    //method for edit and set value
    public void SetReservationForEdit(ReservationViewModel itemEdit)
    {
        if(itemEdit ==null) return;
        Username = itemEdit.UserName;
        FloorNo = itemEdit.FloorNumber;
        RoomNo = itemEdit.RoomNumber;
        StartDate = itemEdit.StartDate;
        EndDate = itemEdit.EndDate;
        this._editingItem = itemEdit;
    }

  

    // Constructor 2: Cho phép gọi và truyền dữ liệu từ bên ngoài vào
    public MakeReservationViewModel(MainViewModel mainViewModel)
    {

        this.MakeReservationSubmitCommand = new RelayCommand(() =>
        {
            if(this._editingItem != null)
            {
                //edit data row
                _editingItem.UpdateData(Username, FloorNo,RoomNo, StartDate,EndDate  );
            }
            else
            {
                //case create new
                ReservationViewModel newItem = null!;
                var reservation = new Reservation(new RoomID(FloorNo, RoomNo), Username, StartDate, EndDate);
                newItem = new ReservationViewModel(
                    reservation,
                    onDelete: () => mainViewModel.ListReservations.Remove(newItem),
                    onEdit: () => mainViewModel.EditReservation(newItem)
                );
                mainViewModel.ListReservations.Add(newItem);
            }
        
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