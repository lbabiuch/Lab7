using System;
using System.Collections.Generic;

namespace Printer
{
    public class Printer
    {
        private List<Ink> Inks;
        private int PaperCount;
        public event EventHandler OutOfPaperEvent;
        public event EventHandler<OutOfInkEventArgs> OutOfInkEvent;
        public void Print(int pages)
        {
            var UsedInk = new Random();
            Console.WriteLine("Printing");
            PaperCount -= Math.Min(PaperCount, pages);
            if (PaperCount == 0) OutOfPaperEvent.Invoke(this, EventArgs.Empty);
        }
        private void OutOfPaperEventHandler(object sender, EventArgs args)
        {
            Console.WriteLine(
                $"{DateTime.Now.ToShortDateString()} " +
                $"{DateTime.Now.ToShortTimeString()} |[Printerlog]: Out of paper");
        }
        private void OutOfInkEventHandler(object sender, EventArgs args)
        {
            Console.WriteLine(
               $"{DateTime.Now.ToShortDateString()} " +
               $"{DateTime.Now.ToShortTimeString()} |[Printerlog]: Out of ink");
        }
        public Printer(int pages, int ink)
        {
            PaperCount = pages;
            OutOfPaperEvent += OutOfPaperEventHandler;
            OutOfInkEvent += OutOfInkEventHandler;
            Inks = new List<Ink> { new Ink("Black"), new Ink("Magenta"), new Ink("Cyan"), new Ink("Yellow") };
        }
        class Ink
        {
            string Colour;
            int InkLeft;

            public Ink(string colour, int inkLeft = 100)
            {
                Colour = colour;
                InkLeft = inkLeft;
            }
        }
    }
}