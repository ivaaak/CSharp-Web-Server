using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SharedTrip.Data.Models
{
    public class Trip
    {
        [Key]
        [StringLength(36)]
        public string Id { get; set; }

        [Required]
        [StringLength(100)]
        public string StartPoint { get; set; }

        [Required]
        [StringLength (100)]
        public string EndPoint { get; set; }

        [Required]
        public DateTime DepartureTime { get; set; }

        [Range(2,6)]
        public int Seats { get; set; }

        [Required]
        [StringLength(80)]
        public string Description { get; set; }

        [StringLength(300)]
        public string ImagePath { get; set; }

        public ICollection<UserTrip> UserTrips { get; set; }

        public Trip()
        {
            UserTrips = new List<UserTrip>();
            Id = Guid.NewGuid().ToString();
        }
    }
}
