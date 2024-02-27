using MySql.Data.MySqlClient;
using Org.BouncyCastle.Tls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace KonyvtarAsztaliKonzolos
{
    internal class Statisztika
    {
        static List<Book> book = new List<Book>();
        static MySqlConnection con = null;
        static MySqlCommand cmd = null;
        public static void read()
        {
            MySqlConnectionStringBuilder sb = new MySqlConnectionStringBuilder();
            sb.Server = "localhost";
            sb.UserID = "root";
            sb.Password = "";
            sb.Database = "books";
            sb.CharacterSet = "utf8";
            con = new MySqlConnection(sb.ConnectionString);
            cmd = con.CreateCommand();
            try
            {
                con.Open();
                cmd.CommandText = "SELECT * FROM `books`";
                using (MySqlDataReader data = cmd.ExecuteReader())
                {
                    while (data.Read())
                    {
                        Book newBook = new Book(data.GetString("author"), data.GetInt16("id"), data.GetInt32("page_count"), data.GetInt32("publish_year"), data.GetString("title"));
                        book.Add(newBook);
                    }
                }
                con.Close();
            }
            catch (MySqlException ex) 
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Something WRONG!!");
                Environment.Exit(0);
            }
        }
        public static void moreThenFiveHundredPages() 
        {
            int count = 0;
            foreach (Book item in book)
            {
                if (item.Page_count > 500) { 
                    count++;
                }
            }
            Console.WriteLine($"500 oldalnál hosszabb könyvek száma: {count}");
        }
        public static void olderThenNineteenFifty() {
            int count = 0;
            foreach (Book item in book)
            {
                if (item.Publish_year < 1950) {
                    count++;
                }
            }
            if (count > 0)
            {
                Console.WriteLine("Van 1950-nél régebbi könyv.");
            }
        }
        public static void longestBook() {
            int maxPage = 0;
            string author = "";
            string title = "";
            int published = 0;
            int page = 0;
            foreach (var item in book)
            {
                if (item.Page_count > maxPage)
                {
                    maxPage = item.Page_count;
                    author = item.Author;
                    title = item.Title;
                    published = item.Publish_year;
                    page = item.Page_count;
                }
            }
            Console.WriteLine($"A leghosszabb könyv: \n" +
                                $"\tSzerző: {author} \n" +
                                $"\tCím: {title} \n" +
                                $"\tKiadás éve: {published} \n" +
                                $"\tOldalszám: {page}");
        }
        public static void mostOwnedBook() {
            foreach (var item in book)
            {
            }
        }
        public static void whoIsTheAuthor() {
            Console.Write("Adjon meg egy könyv címet: ");
            string bookTitle = Console.ReadLine();
            string author = "";
            foreach (Book item in book)
            {
                if (bookTitle == item.Title) 
                {
                    author = item.Author;
                }
            }
            if (author.Length != 0)
            {
                Console.WriteLine($"A megdott könyv szerzője: {author}");
            }
            else
            {
                Console.WriteLine("Nincs ilyen könyv");
            }
            
        }
    }
}
