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
                    AddSong();
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
            string author = Validations.AuthorInput();
            string songName = Validations.SongNameInput();

            string hours, minutes, seconds;

            Validations.SongDurationInput(out hours, out minutes, out seconds);

            if (hours.Length != 2)
                hours = String.Format("0{0}",hours);

            if (minutes.Length != 2)
                minutes = String.Format("0{0}", minutes);

            if (seconds.Length != 2)
                seconds = String.Format("0{0}", seconds);

            using (StreamWriter sw = File.AppendText("../../Music.txt"))
            {
                string songForFile = String.Format("{0},{1},{2}:{3}:{4}",author,songName,hours,minutes,seconds);
                sw.WriteLine(songForFile);
                
            }
        }
    }
}
