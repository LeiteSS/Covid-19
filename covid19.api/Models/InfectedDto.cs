using System;

namespace covid19.api.Models
{
    public class InfectedDto
    {
        public DateTime BirthDate { get; set; }

        public string Genre { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }
    }
}