using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAN_XXXIX_Dejan_Prodanovic
{
    class Validations
    {

        /// <summary>
        /// method that takes input for author from keyboard
        /// it disables user to iput string whose length is less than 3 characters
        /// </summary>
        /// <returns></returns>
        public static string AuthorInput()
        {
            string author;
            do
            {
                Console.WriteLine("Autor pesme:");
                author = Console.ReadLine();

                if (String.IsNullOrEmpty(author) || author.Length < 3 || author.Length > 30)
                    Console.WriteLine("Nevalidan unos. Duzina mora biti izmedju 3 i 30 karaktera");
            } while (String.IsNullOrEmpty(author) || author.Length < 3 || author.Length > 30);

            return author;
        }

        /// <summary>
        /// method that takes input for song name from keyboard
        /// it disables user to iput string whose length is less than 3 characters
        /// </summary>
        /// <returns></returns>
        public static string SongNameInput()
        {
            string songName;
            do
            {
                Console.WriteLine("Naziv pesme:");
                songName = Console.ReadLine();

                if (String.IsNullOrEmpty(songName) || songName.Length < 3 || songName.Length > 30)
                    Console.WriteLine("Nevalidan unos. Duzina mora biti izmedju 3 i 30 karaktera");
            } while (String.IsNullOrEmpty(songName) || songName.Length < 3 || songName.Length > 30);

            return songName;

        }
        /// <summary>
        /// method that takes input for duration of song from keyboard
        /// it takes input for hours than for minutes and at the end for seconds
        /// it disables user from invalid input
        /// </summary>
        /// <param name="hours"></param>
        /// <param name="minutes"></param>
        /// <param name="seconds"></param>
        public static void SongDurationInput(out string hours, out string minutes, out string seconds)
        {
            Console.WriteLine("Format trajanja pesme je ”00:00:00”");
            //input for hours
            int hoursInt;
            bool succes = false;
            do
            {
                Console.WriteLine("Unesite sate:");
                succes = Int32.TryParse(Console.ReadLine(), out hoursInt);
                if (!succes || hoursInt<0 || hoursInt > 99)
                {
                    Console.WriteLine("Nevalidan unos za sate");
                }
            } while (!succes || hoursInt < 0 || hoursInt > 99);
            hours = hoursInt.ToString();
            
            //input for minutes
            int minutesInt;
            
            do
            {
                Console.WriteLine("Unesite minute:");
                succes = Int32.TryParse(Console.ReadLine(), out minutesInt);
                if (!succes || minutesInt < 0 || minutesInt > 59)
                {
                    Console.WriteLine("Nevalidan unos za minute");
                }
            } while (!succes || minutesInt < 0 || minutesInt > 59);
            minutes = minutesInt.ToString();
            
            //input for seconds
            int secundsInt;

            do
            {
                Console.WriteLine("Unesite sekunde:");
                succes = Int32.TryParse(Console.ReadLine(), out secundsInt);
                if (!succes || secundsInt < 0 || secundsInt > 59)
                {
                    Console.WriteLine("Nevalidan unos za sekunde");
                }
            } while (!succes || secundsInt < 0 || secundsInt > 59);
            seconds = secundsInt.ToString();
          
        }
        /// <summary>
        /// method that takes input for number of song that user want to play
        /// user has to input integer number
        /// </summary>
        /// <returns></returns>
        public static int SongNumberInput()
        {
            int songNumber;
            bool success;
            do
            {
                success = Int32.TryParse(Console.ReadLine(), out songNumber);
                if (!success)
                {
                    Console.WriteLine("Nevalidan unos unesite ceo broj");
                }
            } while (!success);
            return songNumber;
        }

        
    }
}
