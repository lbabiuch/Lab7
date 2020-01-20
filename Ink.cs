using System;
using System.Collections.Generic;
using System.Text;

namespace Printer
{
    public class Inks
    {
        public string Colour { get; }
        public int InkLeft { get; set; }

        public Inks(string colour, int inkLeft = 40)
        {
            Colour = colour;
            InkLeft = inkLeft;
        }        
        public static List<Inks> SetInks()
        {
            return new List<Inks> { new Inks("Black"), new Inks("Magenta"), new Inks("Cyan"), new Inks("Yellow") };
        }  
    }
    
}
