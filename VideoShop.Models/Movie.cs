﻿namespace VideoShop.Models
{
    public class Movie
    {

        public int Id { get; set; }
        public string Title { get; set; }
        public int Duration { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Genre { get; set; }


    }
}