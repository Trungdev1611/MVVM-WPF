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