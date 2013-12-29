using System.Collections.Generic;

namespace MvcApplication1.Models
{
    public class Movies
    {
        public IList<Movie> MoviesList { get; set; }

        public Movies()
        {
            MoviesList = new List<Movie>();
        }
    }
}