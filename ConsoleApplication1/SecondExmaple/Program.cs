using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace SecondExmaple
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
 2.	Сложить два целых числа А и В.
Входные данные
В единственной строке входного файла INPUT.TXT записано два натуральных числа через пробел.
Выходные данные
В единственную строку выходного файла OUTPUT.TXT нужно вывести одно целое число — сумму чисел А и В.
     */
            int a, b;
            string[] strNum;
            string pathDirectory = @"C:\FibonaccyNumbers\";
            Directory.CreateDirectory(pathDirectory);
            using(FileStream fs = new FileStream(pathDirectory + "INPUT.TXT" , FileMode.Create))
            {
                string strStream = "1 2";
                
                byte[] bytes = new byte[strStream.Length];
                bytes = Encoding.Default.GetBytes(strStream);
                fs.Write(bytes, 0, bytes.Length);
            }
            using (FileStream fs = new FileStream(pathDirectory+"INPUT.TXT", FileMode.Open))
            {
                byte[] bytes = new byte[fs.Length];
                fs.Read(bytes, 0, bytes.Length);
                strNum = (Encoding.Default.GetString(bytes)).Split(' ');
                Int32.TryParse(strNum[0], out a);
                Int32.TryParse(strNum[1], out b);
            }
            using (FileStream fs = new FileStream(pathDirectory+"OUTPUT.TXT", FileMode.Create))
            {
                string sum = String.Format("{0}", a + b);
                byte[] bytes = new byte[sum.Length];
                bytes = Encoding.Default.GetBytes(sum);
                fs.Write(bytes, 0, bytes.Length);
            }
            Console.ReadLine();
        }
    }
}
