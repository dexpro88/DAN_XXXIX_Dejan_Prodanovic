using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAN_XXXIX_Dejan_Prodanovic
{
    
    class Program
    {
        
        static void Main(string[] args)
        {
            AudioPlayer audioPlayer = new AudioPlayer();
            audioPlayer.StartMenu();
           
            Console.ReadLine();
        }
    }
}
