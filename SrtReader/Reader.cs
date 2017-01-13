using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SrtReader.Exceptions;

namespace SrtReader
{
    public class Reader : IDisposable
    {
        // lista di Battute : corrisponde alla lista sopra che però contiene oggetti
        List<Battuta> battute;
        public Reader()
        {
            // lista di Battute : corrisponde alla lista sopra che però contiene oggetti
            battute = new List<Battuta>();
        }

        public void Dispose()
        {
            battute = null;
        }

        /// <summary>
        /// Creates a list of Battuta starting from an array of strings formatted
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public List<Battuta> LoadBattute(string[] text)
        {
            // lista che contiene una lista di stringhe che corrispondono ad una battuta
            List<List<string>> _b = new List<List<string>>();
            // lista di aiuto che contiene le stringhe che corrispondono ad una battuta
            List<string> h = new List<string>();

            int nBattuta;
            string da, a, content;

            foreach (var line in text)
            {
                if (!string.IsNullOrEmpty(line))
                {
                    // lista help che tiene solo le linee di una battuta
                    h.Add(line);
                }
                else
                {
                    // carico la battuta nel blocco di battute
                    _b.Add(h);
                    h = new List<string>();
                }
            }

            foreach (var sezione in _b)
            {
                nBattuta = 1;
                da = "";
                a = "";
                content = "";

                battute.Add(new Battuta(nBattuta, da, a, content));
            }

            return battute;
        }

        /// <summary>
        /// returns informations of the battuta
        /// </summary>
        /// <param name="nBattuta">the unique number that identifies the battuta</param>
        /// <returns>a Battuta object</returns>
        public Battuta GetBattuta(int nBattuta)
        {
            foreach (var battuta in battute)
            {
                if (battuta.NBattuta == nBattuta)
                {
                    return battuta;
                }
            }
            return null;
        }

        /// <summary>
        /// Sets the values of battuta to the new given values
        /// </summary>
        /// <param name="nBattuta"></param>
        /// <param name="b"></param>
        public void SetBattuta(int nBattuta, Battuta b)
        {
            // I had to use for instead of foreach because I have to modify the element of the list
            for (int i = 0; i < battute.Count; i++)
            {
                if (battute[i].NBattuta == nBattuta)
                {
                    battute[i] = b;
                }
            }
        }

        /// <summary>
        /// Returns the starting hour, minute and
        /// </summary>
        /// <param name="FromTo">string that corresponds to the second line of the Battuta</param>
        private string GetDa(string FromTo)
        {
            return FromTo.Split('-', '>')[0];
        }

        /// <summary>
        /// Returns the ending hour, minute and
        /// </summary>
        /// <param name="FromTo">string that corresponds to the second line of the Battuta</param>
        private string GetA(string FromTo)
        {
            return FromTo.Split('-', '>')[3];
        }

        /// <summary>
        /// Removes the white rows in the list given
        /// </summary>
        /// <param name="text">a list without white rows</param>
        private List<string> RemoveWhitelines(List<string> text)
        {
            // help list
            List<string> h = new List<string>(); 

            foreach (var line in text)
            {
                if (!string.IsNullOrEmpty(line))
                {
                    h.Add(line);
                }
            }

            return h;
        }
    }
}
