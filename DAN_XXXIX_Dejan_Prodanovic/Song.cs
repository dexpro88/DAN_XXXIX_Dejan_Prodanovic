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
        private int hours;
        private int minutes;
        private int seconds;

        public Song()
        {

        }
        
        public Song(string author, string name, string[] timeSpanString)
        {
            Author = author;
            Name = name;
            hours = Int32.Parse(timeSpanString[0]);
            minutes = Int32.Parse(timeSpanString[1]);
            seconds = Int32.Parse(timeSpanString[2]);

            TimeSpan timeSpan = new TimeSpan(hours, minutes, seconds);
            DurationInMiliSeconds = timeSpan.TotalMilliseconds;
        }

        public Song(string author, string name, int hours, int minutes, int seconds)
        {
            Author = author;
            Name = name;
            this.hours = hours;
            this.minutes = minutes;
            this.seconds = seconds;
            TimeSpan timeSpan = new TimeSpan(hours, minutes, seconds);
            DurationInMiliSeconds = timeSpan.TotalMilliseconds;
        }

        /// <summary>
        /// we override ToString method for Song class
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string hours, minutes, seconds;

            if (this.hours.ToString().Length < 2)
                hours = String.Format("0{0}", this.hours);
            else
                hours = this.hours.ToString();

            if (this.minutes.ToString().Length < 2)
                minutes = String.Format("0{0}", this.minutes);
            else
                minutes = this.minutes.ToString();

            if (this.seconds.ToString().Length < 2)
                seconds = String.Format("0{0}", this.seconds);
            else
                seconds = this.seconds.ToString();

            return Author+": " + Name + " " + hours + ":" + minutes + ":" + seconds;
        }
    }
}
