using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAN_XXXIX_Dejan_Prodanovic
{
    class Validations
    {
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

        public static void SongDurationInput(out string hours, out string minutes, out string seconds)
        {
            Console.WriteLine("Format trajanja pesme je 00:00:00”");
            
            do
            {
                Console.WriteLine("Unesite sate:");
                hours = Console.ReadLine();

                if (hours.Length > 2 || hours.Length < 0 || !IsStringNumeric(hours))
                {
                    Console.WriteLine("Nevalidan format za sate");
                }
            } while (hours.Length > 2 || hours.Length < 0 || !IsStringNumeric(hours));

         
            do
            {
                Console.WriteLine("Unesite minute:");
                minutes = Console.ReadLine();

                if (minutes.Length > 2 || minutes.Length < 0 || !IsStringNumeric(minutes))
                {
                    Console.WriteLine("Nevalidan format za minute");
                }
            } while (minutes.Length > 2 || minutes.Length < 0 || !IsStringNumeric(minutes));

             
            do
            {
                Console.WriteLine("Unesite sekunde:");
                seconds = Console.ReadLine();

                if (seconds.Length > 2 || seconds.Length<0 || !IsStringNumeric(seconds))
                {
                    Console.WriteLine("Nevalidan format za sekunde");
                }
            } while (seconds.Length > 2 || seconds.Length < 0 || !IsStringNumeric(seconds));


        }

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

        private static bool IsStringNumeric(string str)
        {
            for (int i = 0; i < str.Length; i++)
            {
                if (!Char.IsDigit(str, i))
                {
                    return false;
                }   
            }
            return true;
        }
    }
}
