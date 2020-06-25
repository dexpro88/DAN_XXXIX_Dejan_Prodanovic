using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DAN_XXXIX_Dejan_Prodanovic
{
    
    class Program
    {     
        static void Main(string[] args)
        {
            AudioPlayer audioPlayer = new AudioPlayer();
            Thread t1 = new Thread(audioPlayer.StartMenu);
            t1.Start();
            
            //in case that user press Escape button application will end
            do
            {
                 
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
           
            t1.Abort();

            if (audioPlayer.printIfSongPlaysThread!=null)
            {
                audioPlayer.printIfSongPlaysThread.Abort();
            }

            if (audioPlayer.printCommercialsThread != null)
            {
                audioPlayer.printCommercialsThread.Abort();
            }
            Console.WriteLine("\nAudio player je prestao sa radom");
            
            Console.ReadLine();
        }
    }
}
