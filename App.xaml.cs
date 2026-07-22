using System.Configuration;
using System.Data;
using System.Windows;
using Reserveroom.Exception;
using Reserveroom.Models;
using Reserveroom.viewModels;

namespace Reserveroom;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
  protected override void OnStartup(StartupEventArgs e)
  {

    try
    {
      //cách viết này là tương đương bên dưới
      // MainWindow = new MainWindow()
      //   {
      //       DataContext = mainViewModel
      //   };
      //   MainWindow.Show();
      
      MainWindow mainWindow = new MainWindow(); // Tạo màn hình chính
      mainWindow.DataContext = new MainViewModel(); // Set DataContext cho màn hình chính
      mainWindow.Show(); // Hiển thị màn hình chính

      base.OnStartup(e); // Gọi phương thức OnStartup của lớp cha
    }
    catch (ReservationConflictExceptionException ex)
    {
      Console.WriteLine($"Message error: {ex.Message}");
      throw;
    }

  }
}

