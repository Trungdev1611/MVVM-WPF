# 1. Model (Domain Model / Business Logic)
Khái niệm chuẩn: Chứa dữ liệu và Logic nghiệp vụ cốt lõi (Business Logic / Domain Logic).

Ví dụ trong app Reserveroom của bạn:

Reservation, RoomID, Hotel, ReservationBook.

Logic nằm ở đây: Công thức kiểm tra trùng lịch (Start1 < End2 && End1 > Start2), kiểm tra tên khách không được để trống, v.v. Các quy tắc này tồn tại độc lập, dù app có giao diện hay chạy trên Console thì logic này vẫn đúng.

# 2. View (User Interface)
Khái niệm chuẩn: Chứa giao diện hiển thị (XAML) và logic giao diện thuần túy (UI Logic).

Nhiệm vụ: Hiển thị dữ liệu lên màn hình và bắt các sự kiện người dùng (click chuột, gõ phím). View không bao giờ tính toán nghiệp vụ.

# 3. ViewModel (Presentation Logic / Bridge)
Khái niệm chuẩn: Chứa Logic hiển thị (Presentation Logic) và làm cầu nối giữa View và Model.

Nhiệm vụ:

Lấy dữ liệu từ Model, "nhào nặn/biến đổi" (Format) thành dạng mà View dễ hiển thị nhất (ví dụ: chuyển DateTime từ Model thành chuỗi "22/07/2026" để View đưa lên TextBox).

Hứng các hành động từ View (thông qua ICommand như SubmitCommand, CancelCommand) rồi gọi sang Model xử lý.

ViewModel KHÔNG chứa Business Logic gốc, nó chỉ gọi Model thực hiện Business Logic đó.



Luồng ứng dụng MVVM
MainViewModel -> CurrentViewModel quyết định màn hình nào đang active hiện tại


# 1. File Store (TodoStore.cs)
   Nơi nắm giữ dữ liệu chung cho toàn bộ app:

C#
using System;
using System.Collections.ObjectModel;

public class TodoStore
{
// Danh sách chung mà tất cả ViewModel cùng nhìn thấy
public ObservableCollection<TodoItemViewModel> Todos { get; } = new ObservableCollection<TodoItemViewModel>();

    // Hàm thêm item mới
    public void AddTodo(string title)
    {
        Todos.Add(new TodoItemViewModel { Title = title, IsCompleted = false });
    }
}

# 2. ViewModel Con (CreateTodoViewModel.cs)
   Nhận Store hoặc Action từ bên ngoài truyền vào qua Constructor:

C#
using System;
using System.Windows.Input;

public class CreateTodoViewModel : ViewModelBase
{
private string _title;
public string Title
{
get => _title;
set { _title = value; OnPropertyChanged(); }
}

    public ICommand SubmitCommand { get; }
    public ICommand CancelCommand { get; }

    // Constructor: Truyền Action từ Bố (MainViewModel) vào
    public CreateTodoViewModel(Action<string> onSubmit, Action onCancel)
    {
        SubmitCommand = new RelayCommand(() =>
        {
            // Validate sơ bộ tại Con
            if (string.IsNullOrWhiteSpace(Title)) return;

            // Bắn dữ liệu về cho Bố xử lý
            onSubmit(Title);
        });

        CancelCommand = new RelayCommand(() =>
        {
            // Báo cho Bố là bấm Hủy
            onCancel();
        });
    }
}

# 3. ViewModel Bố (MainViewModel.cs)
   Nơi giữ bản gốc của TodoStore và phân phối nó cho các màn hình con:

C#
using System.Windows.Input;

public class MainViewModel : ViewModelBase
{
// 1. Khởi tạo Store duy nhất tại Bố
private readonly TodoStore _todoStore;

    private ViewModelBase _currentViewModel;
    public ViewModelBase CurrentViewModel
    {
        get => _currentViewModel;
        set { _currentViewModel = value; OnPropertyChanged(); }
    }

    public ICommand OpenCreateViewCommand { get; }

    public MainViewModel()
    {
        _todoStore = new TodoStore();

        // Mặc định ban đầu hiển thị danh sách (truyền _todoStore vào cho màn hình danh sách)
        CurrentViewModel = new TodoListViewModel(_todoStore);

        // Command để mở màn hình Thêm mới
        OpenCreateViewCommand = new RelayCommand(OpenCreateScreen);
    }

    private void OpenCreateScreen()
    {
        // 2. Chuyển màn hình: Tạo CreateTodoViewModel và định nghĩa 2 Action Submit/Cancel
        CurrentViewModel = new CreateTodoViewModel(
            onSubmit: (newTitle) =>
            {
                // Xử lý Submit: Gọi Store thêm dữ liệu
                _todoStore.AddTodo(newTitle);

                // Chuyển lại về màn hình Danh sách
                CurrentViewModel = new TodoListViewModel(_todoStore);
            },
            onCancel: () =>
            {
                // Xử lý Cancel: Bỏ qua, chỉ đổi màn hình về Danh sách
                CurrentViewModel = new TodoListViewModel(_todoStore);
            }
        );
    }
}

# 4. ViewModel Danh sách (TodoListViewModel.cs)Nhận TodoStore để hiển thị danh sách lên UI:C#using System.Collections.ObjectModel;

public class TodoListViewModel : ViewModelBase
{
// Binding trực tiếp danh sách này lên DataGrid / ListView trên XAML
public ObservableCollection<TodoItemViewModel> Todos { get; }

    public TodoListViewModel(TodoStore todoStore)
    {
        // Lấy danh sách từ Store dùng chung
        Todos = todoStore.Todos;
    }
}
Luồng chạy cực kỳ mượt mà:Khởi động App: MainViewModel tạo _todoStore.Xem Danh sách: 
MainViewModel gán CurrentViewModel = new TodoListViewModel(_todoStore). 
Dữ liệu từ Store hiển thị ra màn hình.Bấm "Thêm": MainViewModel khởi tạo CreateTodoViewModel kèm 
2 hàm Callback (onSubmit và onCancel).Bấm "Lưu" ở màn Thêm: CreateTodoViewModel gọi onSubmit(Title)
$\rightarrow$ Code ở MainViewModel chạy $\rightarrow$ Thêm item vào _todoStore $\rightarrow$ Chuyển CurrentViewModel về lại TodoListViewModel.
Giao diện tự động re-render: Nhờ ObservableCollection, 
DataGrid ở màn hình danh sách tự động xuất hiện item mới mà 
không cần viết 1 dòng code refresh nào!

# 5. File Giao diện chính (MainWindow.xaml)
   Tại màn hình chính, bạn tạo một nút "Thêm To-Do Mới" và liên kết nó với OpenCreateViewCommand:

Đoạn mã
<Window x:Class="TodoListApp.MainWindow"
xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
Title="To-Do List Manager" Height="450" Width="700">

    <DockPanel Margin="10">
        <!-- 1. Thanh công cụ phía trên: Nút bấm mở màn hình Thêm -->
        <StackPanel DockPanel.Dock="Top" Orientation="Horizontal" Margin="0,0,0,10">
            <!-- ĐÂY CHÍNH LA` DÒNG LIÊN KẾT COMMAND -->
            <Button Content="+ Thêm To-Do Mới" 
                    Command="{Binding OpenCreateViewCommand}" 
                    Padding="10,5" 
                    Background="#007ACC" 
                    Foreground="White" 
                    FontWeight="Bold"/>
        </StackPanel>

        <!-- 2. Khu vực hiển thị Màn hình hiện tại (CurrentViewModel) -->
        <ContentControl Content="{Binding CurrentViewModel}" />
    </DockPanel>
