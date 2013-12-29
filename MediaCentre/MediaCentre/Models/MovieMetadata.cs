namespace MediaCentre.Models
{
    public class MovieMetadata
    {
        public int Id { get; set; }

        public string ScreenResolution { get; set; }

        public string Duration { get; set; }

        public string VideoCodec { get; set; }
        
        public string AudioCodec { get; set; }

        public string Format { get; set; }
    }
}