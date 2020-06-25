using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAN_XXXIX_Dejan_Prodanovic
{
    class AudioPlayer
    {
        List<Song> songs = new List<Song>();
        public void StartMenu()
        {
            string option;
            do
            {
                Console.WriteLine("1.Dodaj novu pesmu");
                Console.WriteLine("2.Prikazi sve pesme");
                Console.WriteLine("3.Napusti program");
                option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        AddSong();
                        break;
                    case "2":
                        ReadSongs();

                        Console.WriteLine("\nUnesite redni broj pesme koju zelite da pustite ili b za povratak nazad");
                        string answer = Console.ReadLine();
                        if (answer.Equals("b") || (answer.Equals("B")))
                        {
                            break;
                        }
                        break;
                    case "3":

                        break;
                    default:
                        Console.WriteLine("Izabrali ste nepostojecu opciju");
                        break;
                }
            } while (!option.Equals("3"));
           
        }
        public void ReadSongs()
        {
            using (StreamReader sr = new StreamReader("../../Music.txt"))
            {
                string line;
                int counter = 1;
                while ((line = sr.ReadLine()) != null)
                {
                    Console.WriteLine("{0}.{1}",counter++,line);
                    string[]strArr = line.Split(',');
                    string[] timeSpan = strArr[2].Split(':');
                   
                    Song songFromFile = new Song(strArr[0],strArr[1],timeSpan);
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
        public void PlaySong(string author, string songName, TimeSpan songDuration)
        {

        }
    }
}
