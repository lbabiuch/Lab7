using System;

namespace Printer
{
    class Program
    {
        static void Main(string[] args)
        {
            var RandomPages = new Random();
            var printer = new Printer(RandomPages.Next(20,40),Inks.SetInks());
            printer.OutOfPaperEvent += OutOfPaperEventHandler;
            printer.OutOfInkEvent += OutOfInkEventHandler;
            printer.Print(30);
        }      
        static void OutOfPaperEventHandler(object sender,EventArgs args)
        {
            Console.WriteLine("Printer ran out of paper :(. Put new paper.");
        }
        static void OutOfInkEventHandler(object sender, EventArgs args)
        {
            Console.WriteLine("No ink! :(");
        }  
    }
}
