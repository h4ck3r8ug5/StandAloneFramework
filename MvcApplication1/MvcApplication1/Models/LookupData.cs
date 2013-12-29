using System.Collections.Generic;
using System.Web.Mvc;
using System.Linq;

namespace MvcApplication1.Models
{
    public class LookupData
    {
        public IList<SelectListItem> Years { get; set; }
        public IList<SelectListItem> Rating { get; set; }
        public IList<SelectListItem> Genre { get; set; }

        public LookupData()
        {
            var dbContext = new MediaCentreEntities();

            Years = new List<SelectListItem>();
            Genre = new List<SelectListItem>();
            
            var dbYears = dbContext.Year.Select(x=>x).ToList();

            dbYears.ForEach(year =>
            {
                Years.Add(new SelectListItem
                {
                    Text = year.Value.ToString(),
                    Value = year.Id.ToString()
                });
            });

            Rating = Enumerable.Range(1, 10).Select(x => new SelectListItem
            {
                Text = x.ToString(),
                Value = x.ToString()
            }).ToList();

            var dbGenres = dbContext.Genre.Select(x => x).ToList();

            dbGenres.ForEach(genre =>
            {
                Genre.Add(new SelectListItem
                {
                    Text = genre.Value.ToString(),
                    Value = genre.Id.ToString()
                });
            });
        }
    }
}