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
            Console.WriteLine("Format trajanja pesme je ”00:00:00”");

            int hoursInt;
            bool succes = false;
            do
            {
                Console.WriteLine("Unesite sate:");
                succes = Int32.TryParse(Console.ReadLine(), out hoursInt);
                if (!succes || hoursInt<0 || hoursInt > 99)
                {
                    Console.WriteLine("Nevalidan format za sate");
                }
            } while (!succes || hoursInt < 0 || hoursInt > 99);
            hours = hoursInt.ToString();
            //do
            //{
            //    Console.WriteLine("Unesite sate:");
            //    hours = Console.ReadLine();

            //    if ( String.IsNullOrEmpty(hours) || hours.Length > 2 || !IsStringNumeric(hours))
            //    {
            //        Console.WriteLine("Nevalidan format za sate");
            //    }
            //} while (String.IsNullOrEmpty(hours) || hours.Length > 2 || !IsStringNumeric(hours));

            int minutesInt;
            
            do
            {
                Console.WriteLine("Unesite minute:");
                succes = Int32.TryParse(Console.ReadLine(), out minutesInt);
                if (!succes || minutesInt < 0 || minutesInt > 59)
                {
                    Console.WriteLine("Nevalidan format za minute");
                }
            } while (!succes || minutesInt < 0 || minutesInt > 59);
            minutes = minutesInt.ToString();
            //do
            //{
            //    Console.WriteLine("Unesite minute:");
            //    minutes = Console.ReadLine();

            //    if (String.IsNullOrEmpty(minutes) ||minutes.Length > 2 || !IsStringNumeric(minutes))
            //    {
            //        Console.WriteLine("Nevalidan format za minute");
            //    }
            //} while (String.IsNullOrEmpty(minutes) || minutes.Length > 2 || !IsStringNumeric(minutes));

            int secundsInt;

            do
            {
                Console.WriteLine("Unesite sekunde:");
                succes = Int32.TryParse(Console.ReadLine(), out secundsInt);
                if (!succes || secundsInt < 0 || secundsInt > 59)
                {
                    Console.WriteLine("Nevalidan format za sekunde");
                }
            } while (!succes || secundsInt < 0 || secundsInt > 59);
            seconds = secundsInt.ToString();
            //do
            //{
            //    Console.WriteLine("Unesite sekunde:");
            //    seconds = Console.ReadLine();

            //    if (String.IsNullOrEmpty(seconds) || seconds.Length > 2 || !IsStringNumeric(seconds))
            //    {
            //        Console.WriteLine("Nevalidan format za sekunde");
            //    }
            //} while (String.IsNullOrEmpty(seconds) || seconds.Length > 2 || !IsStringNumeric(seconds));


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
