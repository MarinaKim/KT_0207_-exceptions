using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    class Program
    {
        static void Main(string[] args)
        {
            int n;
            Console.WriteLine("Введите  пункт: ");
            n = Int32.Parse(Console.ReadLine());
            switch (n)
            {
                case 1:   {
                        try
                        {
                            try
                            {
                                Exm05();
                            }
                            catch (IndexOutOfRangeException ie)
                            {
                                Console.WriteLine(ie.Message);
                                Console.WriteLine("---------------------------------------------");

                                Console.WriteLine(ie.Source);
                                Console.WriteLine("---------------------------------------------");

                                Console.WriteLine(ie.StackTrace);
                                Console.WriteLine("---------------------------------------------");

                                Console.WriteLine(ie.TargetSite);
                                Console.WriteLine("------------------------------------------------------------------------------");
                                Console.WriteLine("-----------------------------------------------------------------------------");

                                //senet email
                                // повторное создание исключения
                                throw new SmtpException(message: "не удалось отправить email");
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);

                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                            Console.WriteLine("---------------------------------------------");

                            Console.WriteLine(ex.Source);
                            Console.WriteLine("---------------------------------------------");

                            Console.WriteLine(ex.StackTrace);
                            Console.WriteLine("---------------------------------------------");

                            Console.WriteLine(ex.TargetSite);
                        }
                    }
                    break;

                //Exm07
                case 2:
                    {
                        Exm07();
                    }
                    break;

                case 3:
                    {
                        Exm08();
                    }
                    break;
            }
        }

        static void Exm01()
        {
            try
            {
                int y = 0;
                int x = 56 / y;
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("---------------------------------------------");

                Console.WriteLine(ex.Source);
                Console.WriteLine("---------------------------------------------");

                Console.WriteLine(ex.StackTrace);
                Console.WriteLine("---------------------------------------------");

                Console.WriteLine(ex.TargetSite);

            }
        }

        static void Exm02()
        {
            int y = 0;
            int x = 56;
            if (y != 0)
                x = 56 / y;
            else
                x = 56 / 1;
        }


        //обработка многочисленных исключений
        static void Exm03()
        {
            try
            {
                Console.Write("Введите число типа byte: ");
                byte b = byte.Parse(Console.ReadLine());

                int[] myArray = new int[] { 1, 2, 010, 12, 24 };
                Console.WriteLine("исходный массив: ");
                for (int p = 0; p < myArray.Length + 1; p++)
                {
                    Console.WriteLine("{0}\t ", myArray[p]);
                }

                //foreach (int item in myArray)
                //    Console.WriteLine("{0} ",myArray);
                int i = 120;
                Console.WriteLine("\n Делим на число:\n");

                foreach (int item in myArray)
                    Console.WriteLine(i / item);
            }
            catch (OverflowException oe)
            {
                Console.WriteLine("Данное число не входит в диапазон 0-255");
                Console.WriteLine(oe.Message);
            }
            catch (DivideByZeroException de)
            {
                Console.WriteLine("Делит на 0 нельзя");
                Console.WriteLine(de.Message);
            }
            catch (IndexOutOfRangeException ie)
            {
                Console.WriteLine("выход за рпеделы массива");
                Console.WriteLine(ie.Message);
            }
            finally
            {

            }
        }

        //фильтр исключений
        static void Exm04()
        {
            int x = 1;
            int y = 0;
            try
            {
                int result = x / y;
            }
            catch (Exception ex) when (y == 0)
            {
                Console.WriteLine("y не должен быть 0");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        //throw- позволяет нам самим генерировать ошибки
        static void Exm05()
        {
            Exm06(11, 1989, 1);
            Exm06(year: 1988, month: 12, day: 24);


            throw new IndexOutOfRangeException(message: "Упсс)))");
        }

        static void Exm06(int month, int year, int day)
        {

        }

        static void Exm07()
        {

            int[] val = { 10, 7 };
            foreach (var item in val)
            {
                try
                {
                    Console.WriteLine("{0} divide by 2 is {1}", item, DbyT(item));
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine("{0}:{1}", ae.GetType().Name, ae.Message);
                }
            }
        }
        static int DbyT(int num)
        {
            if ((num & 1) == 1)
                throw new ArgumentException(
                    string.Format("{0} is not even number", num), "num");
            return num / 2;
        }

        static void Exm08()
        {
            try
            {
                string path = @"c:jhdfjh\jfh";
                Directory.SetCurrentDirectory(path);
            }
            catch (DirectoryNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
