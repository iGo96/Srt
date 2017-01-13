using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SrtReader
{
    public class Battuta
    {
        public int NBattuta { get; private set; }
        public string Da { get; private set; }
        public string A { get; private set; }
        public string Text { get; private set; }

        public Battuta(int initNBattuta, string initDa, string initA, string initText)
        {
            this.NBattuta = initNBattuta;
            this.Da = initDa;
            this.A = initA;
            this.Text = initText;
        }
    }
}