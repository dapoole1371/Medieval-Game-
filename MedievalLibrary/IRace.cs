using System;
using System.Collections.Generic;
using System.Text;

namespace MedievalLibrary
{
    interface IRace
    {
        public string raceName { get; set; }
        public double raceAttMod { get; set; }
        public double raceMagMod { get; set; }
    }
}
