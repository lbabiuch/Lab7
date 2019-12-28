using System;

namespace Printer

{
    public class OutOfInkEventArgs : EventArgs
    {
        public string Colour { get; set; }
        public OutOfInkEventArgs(string colour)
        {
            Colour = colour;
        }
    }
}