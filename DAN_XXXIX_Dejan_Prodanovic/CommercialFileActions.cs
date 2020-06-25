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

        /// <summary>
        /// method that reads commercials from file and adds them to Dictionary collection
        /// </summary>
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
        /// <summary>
        /// method that prints random commercial from dictionary commercials
        /// </summary>
        public void PrintRandomCommercial()
        {
            int commercialIndex = rnd.Next(1,commercials.Count);
            Console.WriteLine(commercials[commercialIndex]);
        }
    }
}
