using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace KonyvtarAsztaliKonzolos
{
    internal class Book
    {
        private string author;
        private int id;
        private int page_count;
        private int publish_year;
        private string title;

        public Book(string author, int id, int page_count, int publish_year, string title)
        {
            this.Author = author;
            this.Id = id;
            this.Page_count = page_count;
            this.Publish_year = publish_year;
            this.Title = title;
        }

        public string Author { get => author; set => author = value; }
        public int Id { get => id; set => id = value; }
        public int Page_count { get => page_count; set => page_count = value; }
        public int Publish_year { get => publish_year; set => publish_year = value; }
        public string Title { get => title; set => title = value; }

        public override string ToString()
        {
            return ($"{this.Author}: {this.Title}");
        }
    }
}
