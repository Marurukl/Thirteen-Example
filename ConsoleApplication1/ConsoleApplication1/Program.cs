using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using static System.Console;

namespace FirstExample
{
    class Program
    {
        static void Main(string[] args)
        {
            //            1.В файле записана непустая последовательность целых чисел, являющихся числами Фибоначчи.
            //Приписать еще столько же чисел этой последовательности.
            string pathDirectory = @"C:\FibonaccyNumbers\";
            string path = pathDirectory + @"Fibonaccy.txt";
            int size = 5;
            int newSize = 0;
            int first = 1;
            int second = 1;
            int sum = 0;
            int[] firstFibonaccyNum = new int[size];
            string[] strNum;

            Directory.CreateDirectory(pathDirectory);

            for (int i = 0 + newSize; i < size; i++)
            {
                firstFibonaccyNum[i] = first;
                sum = first + second;
                first = second;
                second = sum;
                Console.Write("{0} ", firstFibonaccyNum[i]);
            }

            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {

                string strStream = "";
                for (int i = 0; i < firstFibonaccyNum.Length; i++)
                {
                    strStream += firstFibonaccyNum[i].ToString();
                    if (i < (firstFibonaccyNum.Length - 1)) strStream += " ";
                }
                byte[] bytes = new byte[strStream.Length];
                bytes = Encoding.Default.GetBytes(strStream);
                fs.Write(bytes, 0, bytes.Length);
            }


            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                byte[] bytes = new byte[fs.Length];
                fs.Read(bytes, 0, bytes.Length);
                strNum = (Encoding.Default.GetString(bytes)).Split(' ');
                newSize = bytes.Length;
            }

            int sizeForArr = newSize + size;
            Array.Resize(ref firstFibonaccyNum, sizeForArr);

            for (int i = 0 + newSize; i < sizeForArr; i++)
            {
                firstFibonaccyNum[i] = first;
                sum = first + second;
                first = second;
                second = sum;
                Console.Write("{0} ", firstFibonaccyNum[i]);
            }
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {

                string strStream = "";
                for (int i = 0; i < firstFibonaccyNum.Length; i++)
                {
                    strStream += firstFibonaccyNum[i].ToString();
                    if (i < (firstFibonaccyNum.Length - 1)) strStream += " ";
                }
                byte[] bytes = new byte[strStream.Length];
                bytes = Encoding.Default.GetBytes(strStream);
                fs.Write(bytes, 0, bytes.Length);
            }







            Console.ReadLine();
        }

        
    }
}
