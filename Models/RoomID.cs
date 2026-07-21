namespace Reservoom.Models;

public class RoomID
{
  public int FloorNumber { get; }
  public int RoomNumber { get; }

  public RoomID(int floorNumber, int roomNumber)
    {
        FloorNumber = floorNumber;
        RoomNumber = roomNumber;
    }

  public override string ToString() {
    return $"{FloorNumber}{RoomNumber}";
  }

  public override bool Equals(object obj) {
    return obj is RoomID roomID &&
           FloorNumber == roomID.FloorNumber &&
           RoomNumber == roomID.RoomNumber;
  }

  public override int GetHashCode() {
    return HashCode.Combine(FloorNumber, RoomNumber);
  }

  // 🔴 THÊM 2 HÀM NÀY VÀO CLASS ROOMID: - viết lại method ==
    public static bool operator ==(RoomID? left, RoomID? right)
    {
      // Dòng 1: Kiểm tra xem 2 biến có cùng trỏ vào 1 ô nhớ (hoặc cùng null) không
        if (ReferenceEquals(left, right)) return true;
      //  Dòng 2: Nếu 1 trong 2 vế bị null (mà vế kia không null) -> Chắc chắn KHÔNG bằng nhau
        if (left is null || right is null) return false;
        //Dòng 3: Cả 2 đều không null -> Gọi hàm Equals() để so sánh FloorNumber và RoomNumber
        return left.Equals(right);
    }

    public static bool operator !=(RoomID? left, RoomID? right) //viết lại method !=
    {
        return !(left == right);
    }
}