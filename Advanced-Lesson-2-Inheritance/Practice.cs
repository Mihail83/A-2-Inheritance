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
            var printType = Console.ReadLine();

            Printer printer = null;
            switch (printType)
            {
                case "1":
                    Console.WriteLine("You have choosen printing into Console ");
                    printer = new ConsolePrinter(text, ConsoleColor.Red);
                    break;
                case "2":
                    Console.WriteLine("You have choosen printing into file ");
                    printer = new FilePrinter(text, "testingfile");

                    break;
                case "3":
                    Console.WriteLine("You have choosen printing into image ");
                    printer = new ImagePrinter(text, "testingfile");

                    break;
                default:
                    Console.WriteLine("????");
                    break;
            }
            printer.Print();
        }
    }
    public abstract class Printer
    {
        public string TextToPrint { get; set; }
        public Printer()               //конструктор
        { }
        public Printer(string str)    //конструктор
        {
            TextToPrint = str;
        }
        public abstract void Print();
    }

    public class ConsolePrinter : Printer
    {
        ConsoleColor forPrint;

        public override void Print()
        {
            Console.ForegroundColor = forPrint;
            Console.WriteLine(TextToPrint);
        }
        public ConsolePrinter(string str, ConsoleColor color) : base(str)   //конструктор
        {
            forPrint = color;
        }
    }

    public class FilePrinter : Printer
    {
        private string _fileName;

        public FilePrinter(string str, string fileName) : base(str)
        {
            _fileName = fileName;
        }
        public override void Print()
        {
            System.IO.File.AppendAllText($@"D:\{_fileName}.txt", TextToPrint);
        }
    }

    public class ImagePrinter : Printer
    {
        private string _fileName;

        public ImagePrinter(string str, string fileName) : base(str)
        {
            _fileName = fileName;
        }
        public override void Print()
        {
            int width = 0;
            int height = 0;
            Bitmap bitmap = new Bitmap(1, 1);
            Font font = new Font("Arial", 20, FontStyle.Bold, GraphicsUnit.Pixel);
            SolidBrush brush = new SolidBrush(Color.Red);
            Graphics graphics = Graphics.FromImage(bitmap);

            width = (int)graphics.MeasureString(TextToPrint, font).Width;
            height = (int)graphics.MeasureString(TextToPrint, font).Height;

            //bitmap = new Bitmap(bitmap, new Size(width, height));
            bitmap = new Bitmap(width, height);
            graphics = Graphics.FromImage(bitmap);

            graphics.Clear(Color.White);
            graphics.DrawString(TextToPrint, font, brush, 0, 0);
            bitmap.Save($@"D:\{_fileName}.bmp");
        }
    }

}
