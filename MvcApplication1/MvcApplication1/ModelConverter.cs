
namespace MvcApplication1
{
    /// <summary>
    /// Converts a model object to an entity and vice versa
    /// </summary>
    public static class ModelConverter
    {
        public static Models.Movie ConvertToMovieModel(this Movie source)
        {
            return new Models.Movie
            {
                Description = source.Description,
                Genre = source.GenreId.ToString(),
                Id = source.Id,
                Directors = source.Directors,
                MovieUrl = source.MovieUrl,
                Name = source.Name,
                Year = (int) source.YearId,
                Rating = (int) source.RatingId,
                //ThumbnailPath = source.ThumbnailId
            };
        }
    }
}