using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Nhập số nguyên n: ");
        int n = int.Parse(Console.ReadLine());

        if(n<1 || n>100000) // Kiểm tra điều kiện n có nằm trong khoảng từ 1 đến 100000 hay không
        {
            Console.WriteLine("Vui lòng nhập số nguyên n trong khoảng từ 1 đến 100000.");
            return;
        }

        int [] arr = new int[n];
        Console.WriteLine("Nhập các phần tử của mảng: ");
        for(int i = 0; i < n; i++)
        {
            arr[i] = int.Parse(Console.ReadLine());
        }
        long sum = 0; // Dùng kiểu long để tránh tràn số khi cộng dồn nhiều số nguyên int lớn
        double agv = 0; // Ép kiểu sum sang double trước khi chia để phép chia không bị cắt cụt phần thập phân
        int max = arr[0], min = arr[0]; // Khởi tạo biến max và min
        int count = 0, am = 0, duong = 0; // Khởi tạo biến đếm số phần tử âm, dương và bằng 0
        for(int i = 0; i < n; i++)
        {
            sum += arr[i];
            agv = (double)sum / n;
            if(arr[i] > max)
                max = arr[i];
            if(arr[i] < min)
                min = arr[i];
            if(arr[i] == 0)
            count++;   
            if(arr[i] < 0)
                am++;
            if(arr[i] > 0)
                duong++;
        }
        Console.WriteLine("Số phần tử âm: "+ am);
        Console.WriteLine("Số phần tử dương: "+ duong);
        Console.WriteLine("Số phần tử bằng 0: "+ count);
        Console.WriteLine("Tổng các phần tử của mảng là: "+ sum);
        Console.WriteLine("Giá trị lớn nhất của mảng là: "+ max);
        Console.WriteLine("Giá trị nhỏ nhất của mảng là: "+ min);
        Console.WriteLine("Giá trị trung bình của mảng là: "+ agv.ToString("F2"));

        int left = 0, right = n - 1;

        while(left < right)// Vòng lặp tiếp tục khi left còn nằm trước right; dừng lại khi gặp nhau hoặc vượt qua nhau
        {
            int temp = arr[left];
            arr[left] = arr[right];
            arr[right] = temp;
            left++;
            right--;
        }
        
        Console.WriteLine("Mảng sau khi đảo ngược: ");
        for(int i = 0; i < n; i++)
        {
            Console.Write(arr[i] + " ");
        }
    }
}