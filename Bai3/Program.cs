using System;
using System.Collections.Generic;

namespace Bai3
{
    public class Student
    {
        // Lưu mã duy nhất dùng để nhận diện sinh viên.
        public string Id { get; set; } = "";

        // Lưu họ tên dùng cho hiển thị và tìm kiếm.
        public string FullName { get; set; } = "";

        // Lưu điểm tổng kết trong đoạn từ 0 đến 10.
        public double Point { get; set; }

        public override string ToString()
        {
            return $"MSSV: {Id,-10} | Ho Ten: {FullName,-25} | Diem: {Point,5:F2}";
        }
    }

    class Program
    {
        // Tìm vị trí của sinh viên theo Id thông qua duyệt mảng tuần tự (O(n)), không dùng LINQ.
        static int FindStudentIndexById(List<Student> list, string id)
        {
            for (int i = 0; i < list.Count; i++)
            {
                // So sánh chuỗi không phân biệt chữ hoa, chữ thường.
                if (string.Equals(list[i].Id, id, StringComparison.OrdinalIgnoreCase))
                {
                    // Trả về chỉ số ngay khi tìm thấy.
                    return i;
                }
            }
            // Trả về -1 nếu duyệt hết danh sách mà không tìm thấy mã tương ứng.
            return -1;
        }

        // Chức năng 1: Thêm mới sinh viên kèm kiểm tra ràng buộc.
        static void AddStudent(List<Student> list)
        {
            Console.WriteLine("\n--- THEM SINH VIEN MOI ---");
            Console.Write("Nhap ma sinh vien: ");
            string id = Console.ReadLine()!.Trim();

            // Kiểm tra trùng mã bằng cách duyệt danh sách hiện tại.
            if (FindStudentIndexById(list, id) != -1)
            {
                Console.WriteLine("Loi: Ma sinh vien da ton tai trong he thong!");
                return;
            }

            Console.Write("Nhap ho va ten: ");
            string name = Console.ReadLine()!.Trim();

            Console.Write("Nhap diem tong ket (0 - 10): ");
            if (!double.TryParse(Console.ReadLine(), out double point) || point < 0 || point > 10)
            {
                // Bắt lỗi nếu điểm không phải là số hợp lệ hoặc nằm ngoài miền [0, 10].
                Console.WriteLine("Loi: Diem khong hop le! Diem phai la so thuc nam trong doan [0, 10].");
                return;
            }

            // Tạo đối tượng và thêm vào danh sách.
            Student newStudent = new Student { Id = id, FullName = name, Point = point };
            list.Add(newStudent);
            Console.WriteLine("Them sinh vien thanh cong!");
        }

        // Chức năng 2: Cập nhật thông tin sinh viên theo mã.
        static void UpdateStudent(List<Student> list)
        {
            Console.WriteLine("\n--- CAP NHAT SINH VIEN ---");
            Console.Write("Nhap ma sinh vien can cap nhat: ");
            string id = Console.ReadLine()!.Trim();

            // Tìm vị trí sinh viên trong danh sách.
            int index = FindStudentIndexById(list, id);
            if (index == -1)
            {
                Console.WriteLine("Loi: Khong tim thay sinh vien co ma nay!");
                return;
            }

            Console.Write("Nhap ho ten moi (de trong neu giu nguyen): ");
            string newName = Console.ReadLine()!.Trim();
            if (!string.IsNullOrEmpty(newName))
            {
                // Cập nhật họ tên mới.
                list[index].FullName = newName;
            }

            Console.Write("Nhap diem moi : ");
            string pointInput = Console.ReadLine()!.Trim();
            if (!string.IsNullOrEmpty(pointInput))
            {
                if (double.TryParse(pointInput, out double newPoint) && newPoint >= 0 && newPoint <= 10)
                {
                    // Cập nhật điểm mới nếu hợp lệ.
                    list[index].Point = newPoint;
                }
                else
                {
                    Console.WriteLine("Loi: Diem khong hop le! Diem phai la so thuc nam trong doan [0, 10].");
                    return;
                }
            }

            Console.WriteLine("Cap nhat thong tin thanh cong!");
        }

        // Chức năng 3: Xóa sinh viên theo mã.
        static void RemoveStudent(List<Student> list)
        {
            Console.WriteLine("\n--- XOA SINH VIEN ---");
            Console.Write("Nhap ma sinh vien can xoa: ");
            string id = Console.ReadLine()!.Trim();

            int index = FindStudentIndexById(list, id);
            if (index == -1)
            {
                Console.WriteLine("Loi: Khong tim thay sinh vien can xoa!");
                return;
            }

            // Xóa phần tử tại vị trí index; thao tác này tốn chi phí dịch chuyển các phần tử phía sau.
            list.RemoveAt(index);
            Console.WriteLine("Xoa sinh vien thanh cong!");
        }

        // Chức năng 4: Tìm kiếm theo họ tên (tìm kiếm chứa chuỗi con không phân biệt hoa thường).
        static void SearchByName(List<Student> list)
        {
            Console.WriteLine("\n--- TIM KIEM THEO HO TEN ---");
            Console.Write("Nhap ten hoac mot phan ho ten can tim: ");
            string keyword = Console.ReadLine()!.Trim();

            int matchCount = 0;
            // Duyệt tuần tự toàn bộ danh sách để tìm kiếm thủ công, không dùng LINQ.
            for (int i = 0; i < list.Count; i++)
            {
                // Kiểm tra từ khóa có xuất hiện trong họ tên sinh viên hay không.
                if (list[i].FullName.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    Console.WriteLine(list[i]);
                    matchCount++;
                }
            }

            if (matchCount == 0)
            {
                Console.WriteLine("Khong tim thay sinh vien nao phu hop voi tu khoa!");
            }
        }

        // Chức năng 5: Hiển thị danh sách, tính điểm trung bình và đếm số lượng đạt.
        static void DisplayAndStatistics(List<Student> list)
        {
            Console.WriteLine("\n--- DANH SACH VA THONG KE SINH VIEN ---");
            
            // Xử lý an toàn khi danh sách rỗng để tránh phép chia cho 0.
            if (list.Count == 0)
            {
                Console.WriteLine("Danh sach sinh vien hien dang rong.");
                Console.WriteLine("Diem trung binh: 0.00");
                Console.WriteLine("So sinh vien dat (diem >= 5.0): 0");
                return;
            }

            double sumPoint = 0;
            int passCount = 0;

            // Duyệt một vòng lặp để vừa in dữ liệu vừa tính toán thống kê.
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine(list[i]);
                sumPoint += list[i].Point;

                if (list[i].Point >= 5.0)
                {
                    passCount++;
                }
            }

            // Tính điểm trung bình của toàn bộ sinh viên.
            double avgPoint = sumPoint / list.Count;

            Console.WriteLine("------------------------------------------------------------");
            Console.WriteLine($"Tong so sinh vien: {list.Count}");
            Console.WriteLine($"Diem trung binh ca lop: {avgPoint:F2}");
            Console.WriteLine($"So sinh vien dat (>= 5.0): {passCount}");
        }

        static void Main(string[] args)
        {
            List<Student> students = new List<Student>
            {
                // Khởi tạo danh sách sinh viên mẫu để tiện kiểm tra chức năng.
                new Student { Id = "SV01", FullName = "Nguyen Van An", Point = 8.5 },
                new Student { Id = "SV02", FullName = "Tran Thi Bich", Point = 9.0 },
                new Student { Id = "SV03", FullName = "Le Hoang Long", Point = 4.0 },   
                new Student { Id = "SV04", FullName = "Pham Quoc Bao", Point = 6.5 },
                new Student { Id = "SV05", FullName = "Dang Thu Thao", Point = 5.0 } 
            };
            bool running = true;

            while (running)
            {
                Console.WriteLine("\n================ QUAN LY SINH VIEN ================");
                Console.WriteLine("1. Them sinh vien");
                Console.WriteLine("2. Cap nhat sinh vien theo ma");
                Console.WriteLine("3. Xoa sinh vien theo ma");
                Console.WriteLine("4. Tim kiem theo ho ten");
                Console.WriteLine("5. Hien thi danh sach va thong ke");
                Console.WriteLine("0. Thoat");
                Console.Write("Chon chuc nang: ");

                string choice = Console.ReadLine()!;
                switch (choice)
                {
                    case "1":
                        AddStudent(students);
                        break;
                    case "2":
                        UpdateStudent(students);
                        break;
                    case "3":
                        RemoveStudent(students);
                        break;
                    case "4":
                        SearchByName(students);
                        break;
                    case "5":
                        DisplayAndStatistics(students);
                        break;
                    case "0":
                        running = false;
                        Console.WriteLine("Ket thuc chuong trinh.");
                        break;
                    default:
                        Console.WriteLine("Tuy chon khong hop le, vui long chon lai.");
                        break;
                }
            }
        }
    }
}