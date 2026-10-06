using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace Baitap_8_9
{
    internal class Bai8
    {
       public static void Mainddd()
        {
            //ex1();
            //ex2();
            //CtyX();
        }
        static void ex1()
        {
            int[][] arr = {
            new int[] { 1, 1, 1, 1, 1 },
            new int[] { 2, 2 },
            new int[] { 3, 3, 3, 3 },
            new int[] { 4, 4 }, };
            for(int i = 0;i < arr.Length; i++)
            {
                for(int j = 0; j < arr[i].Length; j++)
                {
                    Console.Write(arr[i][j] + " ");
                }
                Console.WriteLine();
            }
        }

        static void ex2()
        {
            //tao mang
            Console.Write("Nhap so dong: ");
            int rows = int.Parse(Console.ReadLine());
            int[][] arr = new int[rows][];
            Random random = new Random();

            for (int i = 0; i < rows; i++)
            {
                Console.Write($"Nhap so cot dong {i + 1}: ");
                int cols = int.Parse(Console.ReadLine());
                arr[i] = new int[cols];

                for (int j = 0; j < cols; j++)
                {
                    arr[i][j] = random.Next(0, 101);
                }
            }

            //in mang
            for(int i = 0; i < arr.Length; i++)
            {
                for(int j = 0; j < arr[i].Length; j++)
                {
                    Console.Write(arr[i][j] + " ");
                }
                Console.WriteLine();
            }
            //tim max
            int maxAll = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                int max = arr[i][0];
                for(int j = 1; j < arr[i].Length; j++)
                {
                    if (arr[i][j] > max)
                    {
                        max = arr[i][j];
                    }
                }
                Console.WriteLine($"Max cua dong {i + 1}: " + max);
                if (max > maxAll)
                {
                    maxAll = max;
                }
            }
            Console.WriteLine("Max cua mang: " + maxAll);
            //sap xep phan tu
            for (int i = 0; i < arr.Length; i++)
            {
                for (int k = 0; k < arr[i].Length; k++)
                {
                    for (int j = 0; j < arr[i].Length - 1; j++)
                    {
                        if (arr[i][j] > arr[i][j + 1])
                        {
                            int temp = arr[i][j];
                            arr[i][j] = arr[i][j + 1];
                            arr[i][j + 1] = temp;
                        }
                    }
                }
            }
            Console.WriteLine("Mang sau khi sap xep");
            for (int i = 0; i < arr.Length; i++)
            {
                for(int j = 0; j < arr[i].Length; j++)
                {
                    Console.Write(arr[i][j] + " ");
                }
                Console.WriteLine();
            }
            //kiem tra so nguyen to
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write($"So nguyen to dong {i + 1}: ");
                for (int j = 0; j < arr[i].Length; j++)
                {
                    if (Kiemtrasonguyento(arr[i][j]))
                    {
                        Console.Write(arr[i][j] + " ");
                    }
                }
                Console.WriteLine();
            }
            //tim so tu user
            Console.Write("Nhap so can tim: ");
            int x = int.Parse(Console.ReadLine());
            bool found = false;
            for(int i = 0; i < arr.Length; i++)
            {
                for(int j = 0; j < arr[i].Length; j++)
                {
                    if (arr[i][j] == x)
                    {
                        found = true;
                        Console.WriteLine($"Tim thay so {x} o vi tri: ");
                        Console.WriteLine($"Dong {i + 1}, Cot {j + 1}");
                    }
                }
            }
            if (!found)
            {
                Console.WriteLine("Khong tim thay");
            }
        }
        static bool Kiemtrasonguyento(int n)
        {
            if (n<2)
            {
                return false;
            }
            for(int i = 2; i < n; i++)
            {
                if (n%i==0)
                {
                    return false;
                }
            }
            return true;
        }
        //***
        static void CtyX()
        {
            object[][][] members = new object[3][][];

            members[0] = new object[5][]
            {
                new object[] { 101, "Nguyen Van A", 12 },
                new object[] { 102, "Tran Thi B", 8 },
                new object[] { 103, "Le Van C", 15 },
                new object[] { 104, "Pham Thi D", 5 },
                new object[] { 105, "Hoang Van E", 20 }
            };

            members[1] = new object[3][]
            {
                new object[] { 201, "Vo Van F", 9 },
                new object[] { 202, "Dang Thi G", 18 },
                new object[] { 203, "Bui Van H", 11 }
            };

            members[2] = new object[6][]
            {
                new object[] { 301, "Ngo Van I", 14 },
                new object[] { 302, "Duong Thi K", 7 },
                new object[] { 303, "Luu Van L", 22 },
                new object[] { 304, "Do Thi M", 3 },
                new object[] { 305, "Trinh Van N", 16 },
                new object[] { 306, "Phan Thi O", 10 }
            };

            int choice;

            do
            {
                Console.WriteLine("\n========== MENU ==========");
                Console.WriteLine("1. In danh sach tat ca thanh vien");
                Console.WriteLine("2. Tim thanh vien theo ID");
                Console.WriteLine("3. Tim thanh vien co nhieu task nhat");
                Console.WriteLine("0. Thoat");
                Console.Write("Nhap lua chon: ");

                choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        PrintMembers(members);
                        break;

                    case 2:
                        Console.Write("Nhap ID can tim: ");
                        int id = int.Parse(Console.ReadLine());

                        FindMemberById(members, id);
                        break;

                    case 3:
                        FindHighestTasks(members);
                        break;

                    case 0:
                        Console.WriteLine("Thoat chuong trinh!");
                        break;

                    default:
                        Console.WriteLine("Lua chon khong hop le!");
                        break;
                }

            } while (choice != 0);
        }

        static void PrintMembers(object[][][] members)
        {
            for (int i = 0; i < members.Length; i++)
            {
                Console.WriteLine($"\n--- Group {i + 1} ---");

                for (int j = 0; j < members[i].Length; j++)
                {
                    Console.WriteLine(
                        $"ID: {members[i][j][0]}, " +
                        $"Name: {members[i][j][1]}, " +
                        $"Tasks: {members[i][j][2]}"
                    );
                }
            }
        }

        static void FindMemberById(object[][][] members, int id)
        {
            for (int i = 0; i < members.Length; i++)
            {
                for (int j = 0; j < members[i].Length; j++)
                {
                    if ((int)members[i][j][0] == id)
                    {
                        Console.WriteLine("\nThanh vien tim thay:");
                        Console.WriteLine($"ID: {members[i][j][0]}");
                        Console.WriteLine($"Name: {members[i][j][1]}");
                        Console.WriteLine($"Tasks: {members[i][j][2]}");

                        return;
                    }
                }
            }

            Console.WriteLine("Khong tim thay thanh vien!");
        }

        static void FindHighestTasks(object[][][] members)
        {
            object[] bestMember = members[0][0];

            for (int i = 0; i < members.Length; i++)
            {
                for (int j = 0; j < members[i].Length; j++)
                {
                    if ((int)members[i][j][2] > (int)bestMember[2])
                    {
                        bestMember = members[i][j];
                    }
                }
            }

            Console.WriteLine("\nThanh vien co nhieu task nhat:");
            Console.WriteLine($"ID: {bestMember[0]}");
            Console.WriteLine($"Name: {bestMember[1]}");
            Console.WriteLine($"Tasks: {bestMember[2]}");
        }
    }

}


