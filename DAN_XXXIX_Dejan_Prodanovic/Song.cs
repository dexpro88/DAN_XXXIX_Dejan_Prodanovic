using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAN_XXXIX_Dejan_Prodanovic
{
    class Song
    {
        public string Author { get; set; }
        public string Name { get; set; }
        public double DurationInMiliSeconds { get; set; }

        public Song()
        {

        }

        public Song(string author, string name, string[] timeSpanString)
        {
            Author = author;
            Name = name;
            int hours = Int32.Parse(timeSpanString[0]);
            int minutes = Int32.Parse(timeSpanString[1]);
            int seconds = Int32.Parse(timeSpanString[2]);

            TimeSpan timeSpan = new TimeSpan(hours, minutes, seconds);
            DurationInMiliSeconds = timeSpan.TotalMilliseconds;
        }
    }
}
