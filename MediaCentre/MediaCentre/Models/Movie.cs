namespace MediaCentre.Models
{
    public class Movie
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Directors { get; set; }

        public string Description { get; set; }

        public string Genre { get; set; }

        public int Year { get; set; }

        public MovieMetadata Metadata { get; set; }

        public int Rating { get; set; }
    }
}