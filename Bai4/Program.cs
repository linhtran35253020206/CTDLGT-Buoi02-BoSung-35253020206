using System;

    public class DynamicArray<T>
    {
        // Mảng tĩnh nguyên thủy dùng làm vùng lưu trữ dữ liệu nội bộ.
        private T[] items;

        // Số phần tử thực tế đang có trong mảng động.
        public int Count { get; private set; }

        // Sức chứa tối đa hiện tại trước khi bắt buộc phải cấp phát lại.
        public int Capacity => items.Length;

        // Hàm khởi tạo với dung lượng mặc định là 4.
        public DynamicArray(int capacity = 4)
        {
            // Kiểm tra dung lượng khởi tạo không được âm.
            if (capacity < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(capacity), "Dung luong khoi tao khong duoc am.");
            }

            // Cấp phát mảng tĩnh ban đầu.
            items = new T[capacity];
            Count = 0;
        }

        // Đảm bảo đủ dung lượng trước khi thêm phần tử; nhân đôi mảng nếu đã chạm ngưỡng.
        private void EnsureCapacity()
        {
            // Chỉ nhân đôi kích thước khi số phần tử thực tế đã chạm mức sức chứa tối đa.
            if (Count == Capacity)
            {
                // Nếu ban đầu sức chứa là 0 thì đặt là 4, ngược lại nhân đôi kích thước cũ.
                int newCapacity = Capacity == 0 ? 4 : Capacity * 2;
                
                // Cấp phát vùng nhớ mới có kích thước gấp đôi.
                T[] newItems = new T[newCapacity];

                // Sao chép tuần tự toàn bộ Count phần tử cũ sang mảng mới bằng vòng lặp thủ công.
                for (int i = 0; i < Count; i++)
                {
                    newItems[i] = items[i];
                }

                Console.WriteLine($"[He thong] Capacity da tang tu {Capacity} -> {newCapacity}. Da sao chep {Count} phan tu.");

                // Trỏ con trỏ items sang vùng nhớ mới để hoàn tất việc mở rộng.
                items = newItems;
            }
        }

        // Thêm một phần tử vào cuối danh sách.
        public void Add(T item)
        {
            // Mở rộng mảng nếu cần thiết trước khi gán.
            EnsureCapacity();

            // Gán phần tử vào ô trống đầu tiên (vị trí Count).
            items[Count] = item;

            // Tăng số lượng phần tử hợp lệ lên 1.
            Count++;
        }

        // Bộ chỉ mục (Indexer) cho phép truy cập hoặc thay đổi dữ liệu theo chỉ số.
        public T this[int index]
        {
            get
            {
                // Kiểm tra chỉ số truy cập phải nằm trong đoạn [0, Count - 1].
                if (index < 0 || index >= Count)
                {
                    throw new ArgumentOutOfRangeException(nameof(index), "Chi so nam ngoai pham vi [0, Count - 1].");
                }
                // Trả về phần tử tại vị trí index.
                return items[index];
            }
            set
            {
                // Kiểm tra chỉ số gán dữ liệu phải nằm trong đoạn [0, Count - 1].
                if (index < 0 || index >= Count)
                {
                    throw new ArgumentOutOfRangeException(nameof(index), "Chi so nam ngoai pham vi [0, Count - 1].");
                }
                // Gán giá trị mới cho phần tử tại vị trí index.
                items[index] = value;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== KIEM THU LOP DYNAMICARRAY<T> ===");

            // Khởi tạo DynamicArray với dung lượng mặc định là 4.
            DynamicArray<int> dynamicArr = new DynamicArray<int>(4);
            Console.WriteLine($"Khoi tao: Count = {dynamicArr.Count}, Capacity = {dynamicArr.Capacity}\n");

            // Thêm lần lượt các số từ 1 đến 10 và in Count, Capacity theo yêu cầu đề bài.
            Console.WriteLine("--- Tien hanh Add tu 1 den 10 ---");
            for (int i = 1; i <= 10; i++)
            {
                dynamicArr.Add(i);
                Console.WriteLine($"Add({i,2}) -> Count = {dynamicArr.Count,2}, Capacity = {dynamicArr.Capacity,2}");
            }

            // Đọc và in toàn bộ dữ liệu để chứng minh thứ tự dữ liệu cũ được giữ nguyên sau khi tăng kích thước.
            Console.Write("\nCac phan tu hien tai trong DynamicArray: ");
            for (int i = 0; i < dynamicArr.Count; i++)
            {
                Console.Write(dynamicArr[i] + (i == dynamicArr.Count - 1 ? "" : ", "));
            }
            Console.WriteLine();

            // Đọc và cập nhật qua Indexer theo đúng yêu cầu: đọc mang[2], sau đó gán mang[2] = 99
            Console.WriteLine("\n--- Doc va cap nhat indexer: mang[2] ---");
            int oldValue = dynamicArr[2];
            Console.WriteLine($"Gia tri doc duoc tai mang[2]: {oldValue}");

            dynamicArr[2] = 99;
            Console.WriteLine("Da gan: mang[2] = 99");

            int newValue = dynamicArr[2];
            Console.WriteLine($"Gia tri sau khi gan tai mang[2]: {newValue}");
            Console.Write("Mang hien tai sau khi cap nhat: ");
            for (int i = 0; i < dynamicArr.Count; i++)
            {
                Console.Write(dynamicArr[i] + (i == dynamicArr.Count - 1 ? "" : ", "));
            }
            Console.WriteLine();

            // Kiểm thử bắt ngoại lệ ArgumentOutOfRangeException với index không hợp lệ.
            Console.WriteLine("\n--- Kiem thu bat ngoai le voi Index am (-1) ---");
            try
            {
                int val = dynamicArr[-1];
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine($"Ngoai le bat duoc dung nhu mong doi: {ex.Message}");
            }

            Console.WriteLine("\n--- Kiem thu bat ngoai le voi Index bang Count (10) ---");
            try
            {
                int val = dynamicArr[dynamicArr.Count];
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine($"Ngoai le bat duoc dung nhu mong doi: {ex.Message}");
            }
        }
    }