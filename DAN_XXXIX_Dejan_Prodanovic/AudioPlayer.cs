using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAN_XXXIX_Dejan_Prodanovic
{
    class AudioPlayer
    {
        public void StartMenu()
        {
            Console.WriteLine("1.Dodaj novu pesmu");
            Console.WriteLine("2.Prikazi sve pesme");
            string option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    
                    break;
                case "2":
                    ReadSongs();
                    break;
                default:
                    Console.WriteLine("Izabrali ste nepostojecu opciju");
                    break;
            }
        }
        public void ReadSongs()
        {
            using (StreamReader sr = new StreamReader("../../Music.txt"))
            {
                string line;
                
                while ((line = sr.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }
            }
        }

        public void AddSong()
        {
            using (StreamWriter sw = File.AppendText("../../Music.txt"))
            {
                sw.WriteLine("This");
                sw.WriteLine("is Extra");
                sw.WriteLine("Text");
            }
        }
    }
}
