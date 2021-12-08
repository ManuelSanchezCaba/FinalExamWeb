using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalExamWeb.Models
{
    public class Comic
    {
        public string error { get; set; }
        public List<Result> results { get; set; }
    }

    public class Result
    {
        public string aliases { get; set; }
        public DateTime date_added { get; set; }
        public string deck { get; set; }
        public string description { get; set; }
        public string name { get; set; }
        public int id { get; set; }
        public Image image { get; set; }
        public string site_detail_url { get; set; }
    }

    public class Image
    {
        public string icon_url { get; set; }
        public string original_url { get; set; }
        public string image_tags { get; set; }
        public string small_url { get; set; }
        public string tiny_url { get; set; }
        public string super_url { get; set; }
    }
}
