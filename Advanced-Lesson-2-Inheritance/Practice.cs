using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced_Lesson_2_Inheritance
{
    public static partial class Practice
    {
        /// <summary>
        /// A.L2.P1/1. Создать консольное приложение, которое может выводить 
        /// на печатать введенный текст  одним из трех способов: 
        /// консоль, файл, картинка. 
        /// </summary>
        


        public static void A_L2_P1_1()
        {
            Console.WriteLine("Введите текст ");
            var text = Console.ReadLine();
            Console.WriteLine("Способ печати? ");
            Console.WriteLine("1 - Console ");
            Console.WriteLine("2  - file");
            Console.WriteLine("3 -  image");
            var  printType = Convert.ToInt32(Console.ReadLine());   //   мона стринг     версия не та 
            switch (printType)
            {
                case 1:
                    Console.WriteLine("You have choosen printing into Console ");
                    break;
                    case 2:
                    Console.WriteLine("You have choosen printing into file ");
                    break;
                    case 31:
                    Console.WriteLine("You have choosen printing into image ");
                    break;
                default:
                    Console.WriteLine("хрень");
                    break;
            }

        }
    }

    public abstract class Printer
    {
        public Printer()
        { }
        public string TextToPrint { get; set;} 
        public abstract void Print();
        public Printer(String text)
        {
            TextToPrint = text;
        }    
    }

    public class ConsolePrinter : Printer
    {
        public override void Print()
        {
            throw new NotImplementedException();
        }
        public ConsolePrinter(string str, ConsoleColor color)
        {
            TextToPrint = str;
        }

        public class FilePrinter : Printer
        {
            private string _fileName;
            public FilePrinter(string str, string fileName) //   дописать конструкторы
            {
                _fileName = fileName;
            }
            public override void Print()
            {
                System.IO.File.AppendAllText($@"D:\{_fileName}.txt", TextToPrint);                
            }
        }
    }
}
