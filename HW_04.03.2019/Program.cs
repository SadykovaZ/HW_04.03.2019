using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_04._03._2019
{
    public struct MyInfo
    {
        public string name;
        public string surname;
        public int age;


        public MyInfo(string name, string surname, int age)
        {
            this.name = name;
            this.surname = surname;
            this.age = age;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Выберите задание: ");
            int ch = int.Parse(Console.ReadLine());
            if (ch == 1)
            {
                Ex1();
            }
            else if (ch == 2)
            {
                Ex2();
            }
            else if (ch == 3)
            {
                Ex3();
            }
            else if (ch == 4)
            {
                Ex4();
            }
        }

        static void Ex1()
        {
            //1.	В файле записана непустая последовательность целых чисел, являющихся числами Фибоначчи. Приписать еще столько же чисел этой последовательности
            int[] arr = new int[5];
            arr[0] = 1;
            arr[1] = 2;
            arr[2] = 3;
            arr[3] = 5;
            arr[4] = 8;
            string path = @"C:\Users\Жанара\Source\Repos\HW_04.03.2019\HW_04.03.2019\bin\Debug\fib.txt";
            try
            {
                using (StreamWriter sw = new StreamWriter(path, false))
                {
                    foreach (int item in arr)
                    {
                        sw.Write(item + " ");
                    }
                }
                int[] arr2 = new int[5];
                arr2[0] = 13;
                arr2[1] = 21;
                arr2[2] = 34;
                arr2[3] = 55;
                arr2[4] = 89;
                using (StreamWriter sw2 = new StreamWriter(path, true))
                {
                    foreach (int item in arr2)
                    {
                        sw2.Write(item + " ");
                    }
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        static void Ex2()
        {
            //2.	Сложить два целых числа А и В
            string path = @"C:\Users\Жанара\Source\Repos\HW_04.03.2019\HW_04.03.2019\bin\Debug\input.txt";
            string path2 = @"C:\Users\Жанара\Source\Repos\HW_04.03.2019\HW_04.03.2019\bin\Debug\output.txt";

            string[] words;
            List<int> numbers = new List<int>();

            using (StreamReader stream = new StreamReader(path))
            {
                string text = stream.ReadLine();
                words = text.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
            }

            bool isInt = false;
            foreach (string item in words)
            {
                int number = 0;
                isInt = int.TryParse(item, out number);

                if (isInt)
                    numbers.Add(number);
            }

            int result = numbers[0] + numbers[1];

            Console.WriteLine(numbers[0] + " + " + numbers[1] + " = " + result);

            using (FileStream stream = new FileStream(path2, FileMode.Create))
            {
                string data = result.ToString();

                byte[] bytes = System.Text.Encoding.Unicode.GetBytes(data);

                stream.Write(bytes, 0, bytes.Length);
            }

            Console.ReadLine();


        }

        static void Ex3()
        {
            //	Написать программу, читающую побайтно заданный файл и подсчитывающую число появлений каждого из 256 возможных знаков
            string path = @"C:\Users\Жанара\Source\Repos\HW_04.03.2019\HW_04.03.2019\bin\Debug\sample.txt";
            Dictionary<char, int> stat = new Dictionary<char, int>();

            using (FileStream stream = new FileStream(path, FileMode.OpenOrCreate))
            {
                byte[] bytes = new byte[stream.Length];

                stream.Read(bytes, 0, bytes.Length);

                string data = System.Text.Encoding.Default.GetString(bytes);
                foreach (char symbol in data)
                {
                    if (stat.ContainsKey(symbol))
                    {
                        stat[symbol]++;
                    }
                    else
                    {
                        stat[symbol] = 0;
                    }
                }
                
            }
            foreach (KeyValuePair<char, int> item in stat)
            {
                Console.WriteLine(item.Key + " " + item.Value);
            }
           
        }

        static void Ex4()
        {
            // С помощью класса StreamWriter записать в текстовый файл свое имя, фамилию и возраст. Каждая запись должна начинаться с новой строки.
            MyInfo[] info = new MyInfo[1];
            info[0] = new MyInfo("Zhanar", "Sadykova", 26);
            string path = @"C:\Users\Жанара\Source\Repos\HW_04.03.2019\HW_04.03.2019\bin\Debug\Info.txt";

            try
            {
                using (StreamWriter sw = new StreamWriter(path))
                {
                    foreach (var item in info)
                    {
                        sw.WriteLine(item.name);
                        sw.WriteLine(item.surname);
                        sw.WriteLine(item.age);

                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
