using System;
using System.ComponentModel.DataAnnotations;

namespace CinemaBoxOffice.API.Helpers
{
    public class CustomDateAttribute : RangeAttribute
    {
        public CustomDateAttribute()
          : base(typeof(DateTime),
            DateTime.Now.ToShortDateString(),
            DateTime.Now.AddYears(1).ToShortDateString())
        { }
    }
}