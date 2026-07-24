using System.Collections.ObjectModel;
using System.Windows.Input;
using Reserveroom.Models;

namespace Reserveroom.viewModels;

public class ReservationListingViewModel : ViewModelBase
{
    private readonly MainViewModel _mainViewModel;

    public ObservableCollection<ReservationViewModel> Reservations { get; }

    public ICommand MakeReservationCommand { get; }

    /// <summary>Command ở parent — nhận row qua CommandParameter.</summary>
    public ICommand EditReservationCommand { get; }

    /// <summary>Command ở parent — nhận row qua CommandParameter.</summary>
    public ICommand DeleteReservationCommand { get; }

    public ReservationListingViewModel(MainViewModel mainViewModel)
    {
        _mainViewModel = mainViewModel;
        Reservations = mainViewModel.ListReservations;

        if (Reservations.Count == 0)
        {
            Reservations.Add(new ReservationViewModel(
                new Reservation(new RoomID(1, 12), "Sean", DateTime.Now, DateTime.Now.AddDays(2))));
            Reservations.Add(new ReservationViewModel(
                new Reservation(new RoomID(2, 101), "John", DateTime.Now, DateTime.Now.AddDays(5))));
        }

        MakeReservationCommand = new RelayCommand(() =>
        {
            _mainViewModel.CurrentViewModel = new MakeReservationViewModel(_mainViewModel);
        });

        EditReservationCommand = new RelayCommand(parameter =>
        {
            if (parameter is ReservationViewModel item)
            {
                _mainViewModel.EditReservation(item);
            }
        });

        DeleteReservationCommand = new RelayCommand(parameter =>
        {
            if (parameter is ReservationViewModel item)
            {
                Reservations.Remove(item);
            }
        });
    }
}
