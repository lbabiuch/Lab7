using System;
using System.Collections.Generic;
using System.Linq;

namespace Printer
{
    public class Printer
    {
        private List<Inks> Inks;
        private int PaperCount;
        public event EventHandler OutOfPaperEvent;
        public event EventHandler<OutOfInkEventArgs> OutOfInkEvent;
        private Random random;
        public Printer(int pages, List<Inks> inks)
        {
            PaperCount = pages;
            Inks = inks;
            OutOfPaperEvent += OutOfPaperEventHandler;
            OutOfInkEvent += OutOfInkEventHandler;
            random = new Random();
        }
        public void Print(int pages)
        {
            Console.WriteLine("Printing...");
            if (PaperCount-pages < 0)
            {
                OutOfPaperEvent.Invoke(this, EventArgs.Empty);
                return;
            }
            PaperCount -= pages;
            Console.WriteLine("");
            for (int pageNumber = 0; pageNumber < pages; pageNumber++)
            {
                foreach (var item in Inks)
                {
                    item.InkLeft -= Math.Min(item.InkLeft, random.Next(0, 10));
                    if (item.InkLeft == 0)
                    {
                        OutOfInkEvent.Invoke(this,
                            new OutOfInkEventArgs(item.Colour, pageNumber));
                        return;
                    }
                }
            }                
        }
        private void OutOfPaperEventHandler(object sender, EventArgs args)
        {
            Console.WriteLine(
                $"{DateTime.Now.ToShortDateString()} " +
                $"{DateTime.Now.ToShortTimeString()} |[Printerlog]: Out of paper");
        }
        private void OutOfInkEventHandler(object sender, OutOfInkEventArgs args)
        {
            Console.WriteLine(
               $"{DateTime.Now.ToShortDateString()} " +
               $"{DateTime.Now.ToShortTimeString()} " + 
               "|[Printerlog]: Out of {0} ink (printing stopped at page: {1})",
               args.Colour,args.PageNumber);
        }
    }    
}
