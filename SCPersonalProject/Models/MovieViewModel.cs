namespace SCPersonalProject.Models
{
    public class MovieViewModel
    {
        public List<Movie> Results { get; set; }
        public int TotalResults { get; set; }
    }

    public class Movie
    {
        public int id { get; set; } // Film kimlik numarası
   

 
        public string poster_path { get; set; }

        public string title { get; set; }

        public float vote_average { get; set; }

    }
}
