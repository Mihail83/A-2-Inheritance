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
        /// AL3-P2/3. Отредактировать консольное приложение Printer. 
        /// Заменить базовый абстрактный класс на интерфейс.
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

            IPrinter printer = null;
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
    public interface IPrinter
    {
         string TextToPrint { get; set; }        
         void Print();
    }

    public class ConsolePrinter : IPrinter
    {
        public string TextToPrint { get; set; }
        ConsoleColor forPrint;

        public  void Print()
        {
            Console.ForegroundColor = forPrint;
            Console.WriteLine(TextToPrint);
        }
        public ConsolePrinter(string str, ConsoleColor color)        {
            TextToPrint = str;
            forPrint = color;
        }
    }

    public class FilePrinter : IPrinter
    {
        public string TextToPrint { get; set; }
        private string _fileName;

        public FilePrinter(string str, string fileName)
        {
             TextToPrint = str;
            _fileName = fileName;
        }
        public  void Print()
        {
            System.IO.File.AppendAllText($@"D:\{_fileName}.txt", TextToPrint);
        }
    }

    public class ImagePrinter : IPrinter
    {
        public string TextToPrint { get; set; }
        private string _fileName;

        public ImagePrinter(string str, string fileName)
        {
            TextToPrint = str;
            _fileName = fileName;
        }
        public  void Print()
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
