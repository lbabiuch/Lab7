using System;

namespace Printer
{
    class Program
    {
        static void Main(string[] args)
        {
            var printer = new Printer(5, 2);
            printer.OutOfPaperEvent += OutOfPaperEventHandler;
            printer.OutOfInkEvent += OutOfInkEventHandler;
            printer.Print(5);
        }
        static void OutOfPaperEventHandler(object sender, EventArgs args)
        {
            Console.WriteLine("Printer ran out of paper. Put new paper.");
        }
        static void OutOfInkEventHandler(
            object sender, EventArgs args)
        {
            Console.WriteLine("No ink!");
        }
    }
}