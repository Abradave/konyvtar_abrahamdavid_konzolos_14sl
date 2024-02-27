using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonyvtarAsztaliKonzolos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Statisztika.read();
            Statisztika.moreThenFiveHundredPages();
            Statisztika.olderThenNineteenFifty();
            Statisztika.longestBook();
            Statisztika.whoIsTheAuthor();
            Console.ReadKey();
        }

    }
}
