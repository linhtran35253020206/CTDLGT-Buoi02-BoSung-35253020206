using   System;

class Program
{
    public static void Insert(int[] data, ref int count, int index, int value)// Chèn một giá trị vào vị trí index trên mảng tĩnh có vùng trống.
        {
            // 1. Kiểm tra vị trí chèn có hợp lệ hay không
            if (index < 0 || index > count)
            {
                throw new ArgumentOutOfRangeException(nameof(index), "Vị trí chèn không hợp lệ.");
            }

            // 2. Kiểm tra mảng còn ô trống hay không
            if (count >= data.Length)
            {
                throw new InvalidOperationException("Mảng đã đầy dung lượng, không thể chèn thêm.");
            }

            // 3. Dịch các phần tử từ phải sang trái để tránh ghi đè
            for (int i = count; i > index; i--)
            {
                data[i] = data[i - 1];// Dịch các phần tử phía sau vị trí chèn sang phải
            }

            data[index] = value;// Gán giá trị mới vào vị trí chèn
            
            count++;// Tăng số lượng phần tử trong mảng lên 1
        }

        public static void Delete(int[] data, ref int count, int index)// Xóa một giá trị tại vị trí index trên mảng tĩnh.
        {
            // 1. Kiểm tra vị trí xóa có hợp lệ hay không
            if (index < 0 || index >= count)
            {
                throw new ArgumentOutOfRangeException(nameof(index), "Vị trí xóa không hợp lệ.");
            }
            for (int i = index; i < count - 1; i++)
            {
                data[i] = data[i + 1]; // Dịch các phần tử phía sau vị trí xóa sang trái
            }

            data[count - 1] = 0; // Gán giá trị 0 cho phần tử cuối cùng sau khi xóa

            count--;// Giảm số lượng phần tử trong mảng đi 1
        }

        public static void Print(int[] data, int count)// In ra các phần tử của mảng tĩnh.
        {
            for (int i = 0; i < count; i++)
            {
                Console.Write(data[i] + (i == count - 1 ? "" : " "));
            }
            Console.WriteLine();
        }
    static void Main()
    {
        int [] arr = new int[10] {4, 7, 2, 9, 5, 0, 0, 0, 0, 0}; // Mảng có dung lượng 10, nhưng chỉ có 5 phần tử thực sự được sử dụng
        int count = 5  ;
        
        Console.WriteLine("Mang ban dau: ");
        Print(arr, count);

        Insert(arr, ref count, 2, 99);// Chèn giá trị 99 vào vị trí 2
        Console.WriteLine("Mang sau khi chen gia tri 99 vao vi tri 2: ");
        Print(arr, count);

        Delete(arr, ref count, 1);// Xóa phần tử tại vị trí 1
        Console.WriteLine("Mang sau khi xoa phan tu tai vi tri 1: ");
        Print(arr, count);

        Insert(arr, ref count, 0, 100); // Thử chèn vào vị trí 0
        Console.WriteLine("Mang sau khi chen gia tri 100 vao vi tri 0: ");
        Print(arr, count);

        Insert(arr, ref count, count, 200); // Thử chèn vào vị trí cuối mảng
        Console.WriteLine("Mang sau khi chen gia tri 200 vao vi tri cuoi: ");
        Print(arr, count);

        Delete(arr, ref count, 0); // Thử xóa phần tử đầu mảng
        Console.WriteLine("Mang sau khi xoa phan tu dau: ");
        Print(arr, count);

        Delete(arr, ref count, count-1); // Thử xóa phần tử cuối mảng
        Console.WriteLine("Mang sau khi xoa phan tu cuoi: ");
        Print(arr, count);

        // Delete(arr, ref count, -1); // Thử xóa phần tử ngoài phạm vi mảng (vị trí âm)
        // Console.WriteLine("Mang sau khi xoa phan tu ngoai pham vi (vi tri am): ");
        // Print(arr, count);

        // Delete(arr, ref count, count); // Thử xóa phần tử ngoài phạm vi mảng (vị trí bằng count)
        // Console.WriteLine("Mang sau khi xoa phan tu ngoai pham vi (vi tri bang count): ");
        // Print(arr, count);


    }
}
