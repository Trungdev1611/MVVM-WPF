using System.Collections.ObjectModel;
using System.Windows.Input;
using Reserveroom.Models;
using Reserveroom.Services;

namespace Reserveroom.viewModels;

public class ReservationListingViewModel : ViewModelBase
{
    private readonly IReservationStore _store;
    private readonly INavigationService _navigation;

    public ObservableCollection<ReservationViewModel> Reservations => _store.Reservations;

    public ICommand MakeReservationCommand { get; }
    public ICommand EditReservationCommand { get; }
    public ICommand DeleteReservationCommand { get; }

    public ReservationListingViewModel(IReservationStore store, INavigationService navigation)
    {
        _store = store;
        _navigation = navigation;

        MakeReservationCommand = new RelayCommand(() =>
        {
            _navigation.NavigateTo(new MakeReservationViewModel(_store, _navigation));
        });

        EditReservationCommand = new RelayCommand(parameter =>
        {
            if (parameter is ReservationViewModel item)
            {
                _navigation.NavigateTo(new MakeReservationViewModel(_store, _navigation, item));
            }
        });

        DeleteReservationCommand = new RelayCommand(parameter =>
        {
            if (parameter is ReservationViewModel item)
            {
                _store.Remove(item);
            }
        });
    }
}
