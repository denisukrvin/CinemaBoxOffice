using System;
using CinemaBoxOffice.API.Helpers;
using System.ComponentModel.DataAnnotations;

namespace CinemaBoxOffice.API.Models.Session
{
    public class SessionModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(500, MinimumLength = 1)]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        [CustomDate]
        public DateTime? Date { get; set; }
    }
}