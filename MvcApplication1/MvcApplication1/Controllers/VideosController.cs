using System.Web.Mvc;
using MvcApplication1.Models;
using System.Linq;

namespace MvcApplication1.Controllers
{
    public class VideosController : BaseController
    {
        public ActionResult GetMovies()
        {
            var movies = ( from movie in DatabaseContext.Movie
                    join genre in DatabaseContext.Genre
                        on movie.GenreId equals genre.Id
                    join year in DatabaseContext.Year
                        on movie.YearId equals year.Id
                    join rating in DatabaseContext.Rating
                        on movie.RatingId equals rating.Id
                    join movieThumbnail in DatabaseContext.MovieThumbnails
                        on movie.ThumbnailId equals movieThumbnail.Id
                    join metaData in DatabaseContext.Metadata
                        on movie.MetadataId equals metaData.Id
                    join format in DatabaseContext.Format
                        on metaData.FormatId equals format.Id
                    select new Models.Movie
                    {
                        Id = movie.Id,
                        Description = movie.Description,
                        Directors = movie.Directors,
                        Genre = genre.Value,
                        Year = (int) year.Value,
                        Name = movie.Name,
                        Rating = (int) rating.Value,
                        MovieUrl = movie.MovieUrl,
                        Thumbnail = movieThumbnail.BinaryData,
                        Metadata = new MovieMetadata
                        {
                            AudioCodec = metaData.AudioCodec,
                            Duration = metaData.Duration,
                            ScreenResolution = metaData.ScreenResolution,
                            VideoCodec = metaData.VideoCodec,
                            Format = format.Value
                        },

                    }).ToList();

            var moviesList = new Movies
            {
                MoviesList = movies
            };

            return View("GetMovies", moviesList);
        }

        //public ActionResult Series()
        //{
        //    return View();
        //}

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            using (var context = new MediaCentreEntities())
            {
                var currentMovie = (from movie in context.Movie
                                    join genre in context.Genre
                                        on movie.GenreId equals genre.Id
                                    join year in context.Year
                                        on movie.YearId equals year.Id
                                    join rating in context.Rating
                                        on movie.RatingId equals rating.Id
                                    join movieThumbnail in context.MovieThumbnails
                                        on movie.ThumbnailId equals movieThumbnail.Id
                                    join metaData in context.Metadata
                                        on movie.MetadataId equals metaData.Id
                                    join format in context.Format
                                        on metaData.FormatId equals format.Id
                                    select new Models.Movie
                                    {
                                        Id = movie.Id,
                                        Description = movie.Description,
                                        Directors = movie.Directors,
                                        Genre = genre.Value,
                                        Year = (int)year.Value,
                                        Name = movie.Name,
                                        Rating = (int)rating.Value,
                                        MovieUrl = movie.MovieUrl,
                                        Thumbnail = movieThumbnail.BinaryData,
                                        Metadata = new MovieMetadata
                                        {
                                            AudioCodec = metaData.AudioCodec,
                                            Duration = metaData.Duration,
                                            ScreenResolution = metaData.ScreenResolution,
                                            VideoCodec = metaData.VideoCodec,
                                            Format = format.Value
                                        },

                                    }).First();

                currentMovie.ThumbnailPath = "/Content/Images/Thumbnails/" +
                                             currentMovie.Thumbnail.GetImageFromBinaryData(
                                                 Server.MapPath("~/Content/Images/Thumbnails/" + currentMovie.Name +
                                                                ".jpg"));

                return View(currentMovie);
            }
        }
        
        [HttpPost]
        public ActionResult AddVideo(Movie movie)
        {
            if (ModelState.IsValid)
            {
                //var dbMovie = 
                DatabaseContext.Movie.Add(movie);
                DatabaseContext.SaveChanges();

                RedirectToAction("GetMovies");
            }

            return View(movie);
        }

        public ActionResult CreateVideo()
        {
            var model = new Movie();

            return View("AddVideo",model);
        }
    }
}
