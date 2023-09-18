namespace SCPersonalProject.Models
{
    public class DateLineModel
    {
        public List<Result> results { get; set; }

        public class Result
        {
            public int id { get; set; }
            public string order { get; set; }
            public string Year { get; set; }
            public string Event { get; set; }
            public string UID { get; set; }
        }
    }
}
