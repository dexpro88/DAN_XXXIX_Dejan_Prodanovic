using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAN_XXXIX_Dejan_Prodanovic
{
    class Validations
    {
        public static void AuthorInput()
        {
            Console.WriteLine("Autor pesme:");
            string author = Console.ReadLine();

            if (String.IsNullOrEmpty(author)|| author.Length < 3 || author.Length >30)
                Console.WriteLine("Nevalidan unos. Duzina mora biti izmedju 3 i 30 karaktera");
        }

        public static void SongNameInput()
        {
            Console.WriteLine("Autor pesme:");
            string author = Console.ReadLine();

            if (String.IsNullOrEmpty(author) || author.Length < 3 || author.Length > 30)
                Console.WriteLine("Nevalidan unos. Duzina mora biti izmedju 3 i 30 karaktera");
        }
    }
}
