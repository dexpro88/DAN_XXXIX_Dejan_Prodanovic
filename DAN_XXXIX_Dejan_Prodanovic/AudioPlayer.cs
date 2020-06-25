using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DAN_XXXIX_Dejan_Prodanovic
{
    class AudioPlayer
    {
        Dictionary<int, Song> songs = new Dictionary<int, Song>();
        Thread printIfSongPlaysThread;
        
        AutoResetEvent songEnds = new AutoResetEvent(false);
        Stopwatch stopWatch;

        public void StartMenu()
        {
            ReadSongsFromFile();
            string option;
            do
            {
                Console.WriteLine("1.Dodaj novu pesmu");
                Console.WriteLine("2.Prikazi sve pesme");
                //Console.WriteLine("3.Napusti program");
                option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        AddSong();
                        break;
                    case "2":
                        ReadSongs();

                        Console.WriteLine("\nUnesite redni broj pesme koju zelite da pustite");
                        int songNumber = Validations.SongNumberInput();
                        if (!songs.ContainsKey(songNumber))
                            Console.WriteLine("Ne postoji pesma sa tim rednim brojem");
                        else
                        {

                            PlaySong(songNumber);
                            printIfSongPlaysThread = new Thread(() => PrintIfSongPlays(songNumber));
                            stopWatch = new Stopwatch();
                            printIfSongPlaysThread.Start();
                            stopWatch.Start();
                            songEnds.WaitOne();
                        }
                        break;

                    default:
                        Console.WriteLine("Izabrali ste nepostojecu opciju");
                        break;
                }
            } while (true);
                     
        }
        public void ReadSongsFromFile()
        {
            using (StreamReader sr = new StreamReader("../../Music.txt"))
            {
                string line;
                int counter = 1;
                while ((line = sr.ReadLine()) != null)
                {
                    //Console.WriteLine("{0}.{1}",counter,line);
                    string[]strArr = line.Split(',');
                    string[] timeSpan = strArr[2].Split(':');
                   
                    Song songFromFile = new Song(strArr[0],strArr[1],timeSpan);
                    songs.Add(counter++, songFromFile);
                }
            }
        }
        public void ReadSongs()
        {
            foreach (KeyValuePair<int, Song> song in songs)
            {
                Console.WriteLine("{0} - {1}", song.Key, song.Value);
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
        public void PlaySong(int songNumber)
        {

            Console.WriteLine("Vreme pustanja pesme {0}:{1}:{2}",DateTime.Now.Hour,
                DateTime.Now.Minute,DateTime.Now.Second);
            Console.WriteLine("Naziv pesme: {0}\n",songs[songNumber].Name);  
        }

        public void PrintIfSongPlays(int songNumber)
        {       
            while (stopWatch.ElapsedMilliseconds < songs[songNumber].DurationInMiliSeconds)
            {
                Console.WriteLine("Pesma i dalje traje");
                Thread.Sleep(1000);
            }
            Console.WriteLine("\nPesma je zavrsena");
            Console.WriteLine();
            songEnds.Set();
        }
    }
}
