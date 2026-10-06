using System;
using System.Collections.Generic;
using System.Text;

namespace Baitap_8_9
{
    internal class Bai9
    {
        static void Main()
        {
       
            Console.Write("Nhap chuoi: ");
            string str = Console.ReadLine();

            Console.WriteLine("\n1. Chuoi vua nhap:");
            Console.WriteLine(str);

            Console.WriteLine("\n2. Do dai chuoi:");
            Console.WriteLine(GetLength(str));

            Console.WriteLine("\n3. Tung ky tu:");
            PrintCharacters(str);

            Console.WriteLine("\n4. Chuoi theo thu tu nguoc:");
            PrintReverse(str);

            Console.WriteLine("\n5. So tu trong chuoi:");
            Console.WriteLine(CountWords(str));

            Console.WriteLine("\n6. So sanh hai chuoi:");
            Console.Write("Nhap chuoi thu hai: ");
            string str2 = Console.ReadLine();

            if (CompareStrings(str, str2))
            {
                Console.WriteLine("Hai chuoi giong nhau.");
            }
            else
            {
                Console.WriteLine("Hai chuoi khac nhau.");
            }

            Console.WriteLine("\n7. Dem ky tu:");
            CountCharacters(str);

            Console.WriteLine("\n8. Dem nguyen am va phu am:");
            CountVowelsConsonants(str);

            Console.WriteLine("\n9. Kiem tra chuoi con:");
            Console.Write("Nhap chuoi con: ");
            string sub = Console.ReadLine();

            int position = FindSubstring(str, sub);

            if (position != -1)
            {
                Console.WriteLine("Chuoi con co ton tai.");
            }
            else
            {
                Console.WriteLine("Chuoi con khong ton tai.");
            }

            Console.WriteLine("\n10. Vi tri chuoi con:");
            if (position != -1)
            {
                Console.WriteLine("Vi tri dau tien: " + position);
            }
            else
            {
                Console.WriteLine("Khong tim thay.");
            }

            Console.WriteLine("\n11. Kiem tra ky tu:");
            Console.Write("Nhap mot ky tu: ");
            char c = Console.ReadKey().KeyChar;
            Console.WriteLine();

            CheckCharacter(c);

            Console.WriteLine("\n12. Dem so lan substring xuat hien:");
            Console.Write("Nhap substring can dem: ");
            string sub2 = Console.ReadLine();

            Console.WriteLine(
                "So lan xuat hien: " +
                CountSubstring(str, sub2)
            );

            Console.WriteLine("\n13. Chen substring:");
            Console.Write("Nhap substring can chen: ");
            string insert = Console.ReadLine();

            Console.Write("Nhap chuoi lam moc: ");
            string target = Console.ReadLine();

            string result = InsertBeforeFirst(str, insert, target);

            Console.WriteLine("Ket qua:");
            Console.WriteLine(result);
        }

        static int GetLength(string str)
        {
            int count = 0;

            foreach (char c in str)
            {
                count++;
            }

            return count;
        }

        static void PrintCharacters(string str)
        {
            for (int i = 0; i < GetLength(str); i++)
            {
                Console.WriteLine(str[i]);
            }
        }

        static void PrintReverse(string str)
        {
            for (int i = GetLength(str) - 1; i >= 0; i--)
            {
                Console.Write(str[i]);
            }

            Console.WriteLine();
        }

        static int CountWords(string str)
        {
            int count = 0;
            bool inWord = false;

            for (int i = 0; i < GetLength(str); i++)
            {
                if (str[i] != ' ' && str[i] != '\t')
                {
                    if (!inWord)
                    {
                        count++;
                        inWord = true;
                    }
                }
                else
                {
                    inWord = false;
                }
            }

            return count;
        }

        static bool CompareStrings(string str1, string str2)
        {
            if (GetLength(str1) != GetLength(str2))
            {
                return false;
            }

            for (int i = 0; i < GetLength(str1); i++)
            {
                if (str1[i] != str2[i])
                {
                    return false;
                }
            }

            return true;
        }

        static void CountCharacters(string str)
        {
            int alphabet = 0;
            int digit = 0;
            int special = 0;

            for (int i = 0; i < GetLength(str); i++)
            {
                char c = str[i];

                if ((c >= 'a' && c <= 'z') ||
                    (c >= 'A' && c <= 'Z'))
                {
                    alphabet++;
                }
                else if (c >= '0' && c <= '9')
                {
                    digit++;
                }
                else
                {
                    special++;
                }
            }

            Console.WriteLine("Alphabet: " + alphabet);
            Console.WriteLine("Digit: " + digit);
            Console.WriteLine("Special character: " + special);
        }

        static void CountVowelsConsonants(string str)
        {
            int vowels = 0;
            int consonants = 0;

            for (int i = 0; i < GetLength(str); i++)
            {
                char c = str[i];

                if (c >= 'A' && c <= 'Z')
                {
                    c = (char)(c + 32);
                }

                if (c >= 'a' && c <= 'z')
                {
                    if (c == 'a' ||
                        c == 'e' ||
                        c == 'i' ||
                        c == 'o' ||
                        c == 'u')
                    {
                        vowels++;
                    }
                    else
                    {
                        consonants++;
                    }
                }
            }

            Console.WriteLine("Nguyen am: " + vowels);
            Console.WriteLine("Phu am: " + consonants);
        }

        static int FindSubstring(string str, string sub)
        {
            int strLength = GetLength(str);
            int subLength = GetLength(sub);

            if (subLength == 0)
            {
                return 0;
            }

            if (subLength > strLength)
            {
                return -1;
            }

            for (int i = 0; i <= strLength - subLength; i++)
            {
                bool found = true;

                for (int j = 0; j < subLength; j++)
                {
                    if (str[i + j] != sub[j])
                    {
                        found = false;
                        break;
                    }
                }

                if (found)
                {
                    return i;
                }
            }

            return -1;
        }

        static void CheckCharacter(char c)
        {
            if (c >= 'A' && c <= 'Z')
            {
                Console.WriteLine("Day la alphabet.");
                Console.WriteLine("Chu hoa.");
            }
            else if (c >= 'a' && c <= 'z')
            {
                Console.WriteLine("Day la alphabet.");
                Console.WriteLine("Chu thuong.");
            }
            else
            {
                Console.WriteLine("Khong phai alphabet.");
            }
        }

        static int CountSubstring(string str, string sub)
        {
            int count = 0;
            int strLength = GetLength(str);
            int subLength = GetLength(sub);

            if (subLength == 0 || subLength > strLength)
            {
                return 0;
            }

            for (int i = 0; i <= strLength - subLength; i++)
            {
                bool found = true;

                for (int j = 0; j < subLength; j++)
                {
                    if (str[i + j] != sub[j])
                    {
                        found = false;
                        break;
                    }
                }

                if (found)
                {
                    count++;
                }
            }

            return count;
        }

        static string InsertBeforeFirst(
            string str,
            string insert,
            string target)
        {
            int position = FindSubstring(str, target);

            if (position == -1)
            {
                return str;
            }

            string result = "";

            for (int i = 0; i < position; i++)
            {
                result += str[i];
            }

            result += insert;

            for (int i = position; i < GetLength(str); i++)
            {
                result += str[i];
            }

            return result;
        }
    }
}
    

