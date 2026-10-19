# CTDLGT-Buoi02-BoSung-35253020206
Họ và tên: Trần Duy Linh
Mã số sinh viên (MSSV): 35253020206
Học phần: Cấu trúc dữ liệu và Giải thuật

# KHAI BÁO SỬ DỤNG AI
Tôi đã sử dụng Gemini để hỗ trợ giải thích yêu cầu, gợi ý cách làm, hỗ trợ sửa lỗi, xây dựng ca kiểm thử và hướng dẫn soạn README. Tôi đã chạy thử chương trình, kiểm tra kết quả và chịu trách nhiệm về mã nguồn cùng nội dung nộp bài.

# HƯỚNG DẪN CHẠY CHƯƠNG TRÌNH
Mở file solution (.sln) bằng Visual Studio hoặc Visual Studio Code.

Cài đặt .NET SDK (khuyến nghị .NET 6.0 trở lên).

Mở Terminal tại thư mục gốc của từng bài (Bai1, Bai2, Bai3, Bai4) và chạy lệnh: dotnet run

# Mô tả thuật toán
Bài 1: Thống kê và đảo mảng Mô tả thuật toán

Nhập n và các phần tử của mảng.
Khởi tạo tổng, giá trị nhỏ nhất và lớn nhất từ phần tử đầu tiên.
Duyệt mảng một lần để tính tổng, min, max, trung bình và đếm số phần tử âm, dương, bằng 0.
Dùng hai chỉ số trái và phải để hoán đổi phần tử từ hai đầu vào giữa, đảo mảng tại chỗ. Độ phức tạp
Thống kê: thời gian Θ(n), bộ nhớ phụ Θ(1).
Đảo mảng: thời gian Θ(n), bộ nhớ phụ Θ(1).
Tổng thể sau khi nhập mảng: thời gian Θ(n). Các ca kiểm thử
Mảng 3 7 2 9 5: kiểm tra min, max và mảng sau khi đảo.
Mảng -5 0 5 0: kiểm tra đếm số âm, dương và bằng 0.
Mảng 8: kiểm tra trường hợp chỉ có một phần tử.
Mảng -4 -2 -9: kiểm tra mảng toàn số âm và trung bình âm.

Bài 2: Chèn và xóa trên mảng Mô tả thuật toán

Dùng count để xác định số phần tử hợp lệ và data.Length để xác định sức chứa.
Insert: kiểm tra chỉ số và sức chứa; dịch phần tử từ phải sang trái, ghi giá trị mới rồi tăng count.
RemoveAt: kiểm tra chỉ số; dịch phần tử phía sau sang trái rồi giảm count.
Chỉ số không hợp lệ phát sinh ArgumentOutOfRangeException; chèn khi mảng đầy phát sinh InvalidOperationException. Độ phức tạp
Insert tại index: thời gian Θ(count - index + 1), xấu nhất O(n), bộ nhớ phụ Θ(1).
RemoveAt tại index: thời gian Θ(count - index), xấu nhất O(n), bộ nhớ phụ Θ(1). Các ca kiểm thử
Ban đầu [4, 7, 2, 9, 5], chèn 99 tại chỉ số 2, sau đó xóa tại chỉ số 1.
Chèn ở đầu và cuối phần dữ liệu.
Xóa ở đầu và xóa phần tử cuối.
Chèn với chỉ số âm.
Xóa tại index == count.
Chèn khi mảng đã đầy.

Bài 3: Quản lý sinh viên bằng List Mô tả thuật toán

Tạo lớp Student gồm mã sinh viên, họ tên và điểm.
Xây dựng menu để thêm, cập nhật, xóa, tìm kiếm, hiển thị và thống kê sinh viên.
Kiểm tra mã trùng trước khi thêm và chỉ chấp nhận điểm từ 0 đến 10.
Tìm kiếm theo một phần họ tên, không phân biệt chữ hoa và chữ thường.
Tính điểm trung bình và đếm sinh viên có điểm từ 5 trở lên; xử lý riêng khi danh sách rỗng. Độ phức tạp
Thêm có kiểm tra mã trùng: O(n).
Tìm theo mã hoặc họ tên: trường hợp xấu O(n).
Xóa theo mã: O(n) do tìm kiếm và có thể dịch phần tử.
Thống kê: Θ(n), bộ nhớ phụ Θ(1). Các ca kiểm thử
Chuẩn bị ít nhất năm sinh viên.
Thêm sinh viên hợp lệ.
Từ chối mã sinh viên bị trùng.
Từ chối điểm nhỏ hơn 0 hoặc lớn hơn 10.
Cập nhật họ tên hoặc điểm.
Tìm kiếm có kết quả và không có kết quả.
Xóa sinh viên tồn tại và thử xóa mã không tồn tại.
Thống kê khi danh sách rỗng. 

Bài 4: Mảng động và Capacity Mô tả thuật toán

Xây dựng lớp DynamicArray dùng mảng T[] làm vùng lưu trữ nội bộ.
Count lưu số phần tử hợp lệ; Capacity trả về sức chứa của mảng.
Khi thêm mà mảng đã đầy, tạo mảng mới có dung lượng gấp đôi, sao chép đúng Count phần tử rồi chuyển sang mảng mới.
Dùng indexer để đọc và cập nhật phần tử; chỉ chấp nhận chỉ số từ 0 đến Count - 1. Độ phức tạp
Indexer đọc/ghi: O(1).
Add khi còn chỗ: O(1).
Add khi phải mở rộng: O(n).
Add khấu hao qua nhiều lần thêm: O(1).
Thêm n phần tử từ mảng rỗng: O(n) tổng thời gian; bộ nhớ lưu trữ O(n). Các ca kiểm thử
Thêm lần lượt số từ 1 đến 10, in Count và Capacity sau mỗi lần thêm.
Đọc và cập nhật phần tử bằng indexer.
Kiểm tra chỉ số âm và chỉ số bằng Count; cả hai phải phát sinh ArgumentOutOfRangeException.
Theo dõi dung lượng tăng từ 4 lên 8 và xác nhận thứ tự dữ liệu cũ được giữ nguyên.
Ghi số phần tử được sao chép mỗi lần mở rộng: 4 phần tử khi tăng 4 → 8, và 8 phần tử khi tăng 8 → 16.
