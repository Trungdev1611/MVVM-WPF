using System.Windows;
using Reserveroom.Exception;
using Reserveroom.Services;
using Reserveroom.viewModels;

namespace Reserveroom;

/// <summary>
/// Composition root: tạo Store + Navigation, inject vào MainViewModel.
/// </summary>
public partial class App : Application
{
    protected override void OnStartup(StartupEventArgs e)
    {
        try
        {
            IReservationStore store = new ReservationStore();
            INavigationService navigation = new NavigationService();

            MainWindow mainWindow = new MainWindow
            {
                DataContext = new MainViewModel(store, navigation)
            };
            mainWindow.Show();

            base.OnStartup(e);
        }
        catch (ReservationConflictExceptionException ex)
        {
            Console.WriteLine($"Message error: {ex.Message}");
            throw;
        }
    }
}
