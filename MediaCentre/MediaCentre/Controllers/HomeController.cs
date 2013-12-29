using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web.Mvc;
using MediaCentre.Models;

namespace MediaCentre.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            //using (var writeContext = new MediaCentreEntities())
            //{
            //    var movieBinaryData = (Server.MapPath("~/Content/Images/turbo-movie.jpg")).GetImageBinaryData();

            //    var movieThumbnail = writeContext.MovieThumbnails.Select(x=>x).First();
            //    movieThumbnail.BinaryData = movieBinaryData;

            //    writeContext.MovieThumbnails.AddOrUpdate(movieThumbnail);

            //    writeContext.SaveChanges();
            //}

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

                    }).First();

                currentMovie.ThumbnailPath = "/Content/Images/Thumbnails/" + currentMovie.Thumbnail.GetImageFromBinaryData(Server.MapPath("~/Content/Images/Thumbnails/" + currentMovie.Name +".jpg"));

                PopulateModel(currentMovie);                

                return View(currentMovie);
            }
        }

        public ActionResult PlayMovie(int id)
        {
            using (var context = new MediaCentreEntities())
            {

                var currentMovie = from movie in context.Movie
                    join genre in context.Genre
                        on movie.GenreId equals genre.Id
                    join year in context.Year
                        on movie.YearId equals year.Id
                    join metaData in context.Metadata
                        on movie.MetadataId equals metaData.Id
                    join rating in context.Rating
                        on movie.RatingId equals rating.Id
                    join format in context.Format
                        on metaData.FormatId equals format.Id
                    where movie.Id == id
                    select new Models.Movie
                    {
                        Description = movie.Description,
                        Directors = movie.Directors,
                        Genre = genre.Value,
                        Year = (int) year.Value,
                        Name = movie.Name,
                        Rating = (int) rating.Value,
                        MovieUrl = movie.MovieUrl,
                        Metadata = new MovieMetadata
                        {
                            AudioCodec = metaData.AudioCodec,
                            Duration = metaData.Duration,
                            ScreenResolution = metaData.ScreenResolution,
                            VideoCodec = metaData.VideoCodec,
                            Format = format.Value
                        }
                    };

                return View("Play", currentMovie.First());
            }
        }

        [HttpGet]
        public ActionResult EditMovie(int id)
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
                    where movie.Id == id
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

                    }).First();

                PopulateModel(currentMovie);

                return View("EditMovie", currentMovie);
            }
        }

        [HttpPost]
        public ActionResult SaveMovie(Models.Movie movie)
        {           
            using (DatabaseContext)
            {
                var existingMovie = DatabaseContext.Movie.Find(movie.Id);

                existingMovie.Name = movie.Name;
                existingMovie.Description = movie.Description;
                existingMovie.Directors = movie.Directors;
                existingMovie.GenreId = Convert.ToInt32(movie.Genre);
                existingMovie.RatingId = movie.Rating;
                existingMovie.YearId = movie.Year;

                DatabaseContext.Movie.AddOrUpdate(existingMovie);
                DatabaseContext.SaveChanges();

                return View("Index", null);
            }            
        }
    }
}
