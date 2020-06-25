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
        SortedDictionary<int, Song> songs = new SortedDictionary<int, Song>();
        public Thread printIfSongPlaysThread;
        public Thread printCommercialsThread;
        AutoResetEvent songEnds = new AutoResetEvent(false);
        Stopwatch stopWatch;
        int numberOfSongs;
        CommercialFileActions commercial = new CommercialFileActions();

        /// <summary>
        /// main menu of application
        /// it is runned  by 
        /// </summary>
        public void StartMenu()
        {
            ReadSongsFromFile();
            commercial.ReadSongsFromFile();
            string option;

            do
            {
                Console.WriteLine("1.Dodaj novu pesmu");
                Console.WriteLine("2.Prikazi sve pesme");
                Console.WriteLine("Pritisnite ESC da ugasite Audio Player u bilo kom trenutku");
                
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
                            Console.WriteLine("\nNe postoji pesma sa tim rednim brojem\n");
                        else
                        {

                            PlaySong(songNumber);
                            //we create thread that prints message that song is playing  every 1000ms
                            printIfSongPlaysThread = new Thread(() => PrintIfSongPlays(songNumber));
                            //we create thread that prints commercial every 200ms
                            printCommercialsThread = new Thread(()=>PrintCommercials(songNumber));
                            
                            stopWatch = new Stopwatch();

                            printIfSongPlaysThread.Start();
                            stopWatch.Start();
                            printCommercialsThread.Start();


                            songEnds.WaitOne();
                        }
                        break;

                    default:
                        Console.WriteLine("\nIzabrali ste nepostojecu opciju\n");
                        break;
                }
            } while (true);
                     
        }

        /// <summary>
        /// method that reads songs from file and adds them to dictionary songs
        /// </summary>
        public void ReadSongsFromFile()
        {
            using (StreamReader sr = new StreamReader("../../Music.txt"))
            {
                string line;
                int counter = 1;
                while ((line = sr.ReadLine()) != null)
                {
                  
                    string[]strArr = line.Split(',');
                    string[] timeSpan = strArr[2].Split(':');
                   
                    Song songFromFile = new Song(strArr[0],strArr[1],timeSpan);
                    songs.Add(counter++, songFromFile);
                }
            }
            numberOfSongs = songs.Count();
        }

        /// <summary>
        /// method that prints user songs from dictionary songs
        /// </summary>
        public void ReadSongs()
        {
            foreach (KeyValuePair<int, Song> song in songs)
            {
                Console.WriteLine("{0} - {1}", song.Key, song.Value);
            }
        }

        /// <summary>
        /// method that adds new song
        /// it adds new song to file and to dictionary songs
        /// </summary>
        public void AddSong()
        {
            string author = Validations.AuthorInput();
            string songName = Validations.SongNameInput();

            string hours, minutes, seconds;

            Validations.SongDurationInput(out hours, out minutes, out seconds);

            Song newSong = new Song(author, songName, Int32.Parse(hours), Int32.Parse(minutes), Int32.Parse(seconds));
            songs.Add(++numberOfSongs, newSong);

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

        /// <summary>
        /// method that prints the moment when sont started and name of the song
        /// </summary>
        /// <param name="songNumber"></param>
        public void PlaySong(int songNumber)
        {

            Console.WriteLine("Vreme pustanja pesme {0}:{1}:{2}",DateTime.Now.Hour,
                DateTime.Now.Minute,DateTime.Now.Second);
            Console.WriteLine("Naziv pesme: {0}\n",songs[songNumber].Name);  
        }
        /// <summary>
        /// method that notifies user that song is still playing every 1000ms
        /// it notifies user when song is ended and at that moment it signals thread that runs StartMenu method  
        /// so it can continue to work
        /// </summary>
        /// <param name="songNumber"></param>
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

        /// <summary>
        /// method that print random commercial from file commercials every 2000ms
        /// </summary>
        /// <param name="songNumber"></param>
        public void PrintCommercials(int songNumber)
        {
             
            while (stopWatch.ElapsedMilliseconds < songs[songNumber].DurationInMiliSeconds)
            {
                commercial.PrintRandomCommercial();
                Thread.Sleep(200);
            }
        }
    }
}
