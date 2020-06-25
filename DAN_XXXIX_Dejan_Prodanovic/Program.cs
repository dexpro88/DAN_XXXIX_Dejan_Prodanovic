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


            //Thread t1 = new Thread(audioPlayer.StartMenu);
            //t1.Start();

            //t1.Join();

            while (!(Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.Escape))
            {
                
                    Console.WriteLine("nesto");
                
            }

            
            
        }
    }
}
