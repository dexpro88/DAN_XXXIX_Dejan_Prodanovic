using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAN_XXXIX_Dejan_Prodanovic
{
    class CommercialFileActions
    {
        Dictionary<int, string> commercials = new Dictionary<int, string>();
        Random rnd = new Random();

        public void ReadSongsFromFile()
        {
            using (StreamReader sr = new StreamReader("../../Reklame.txt"))
            {
                string line;
                int counter = 1;
                while ((line = sr.ReadLine()) != null)
                {
                    commercials.Add(counter++, line);
                  
                }
            }
           
        }

        public void PrintRandomCommercial()
        {
            int commercialIndex = rnd.Next(1,commercials.Count);
            Console.WriteLine(commercials[commercialIndex]);
        }
    }
}
