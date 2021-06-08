using System;
using MongoDB.Driver.GeoJsonObjectModel;

namespace covid19.api.Data.Collections
{
    public class Infected
    {
        public DateTime BirthDate { get; set; }

        public string Genre { get; set; }

        public GeoJson2DGeographicCoordinates Location { get; set; }

        public Infected(DateTime birthDate, string genre, double latitude, double longitude)
        {
            this.BirthDate = birthDate;
            this.Genre = genre;
            this.Location = new GeoJson2DGeographicCoordinates(longitude, latitude);
        }
    }
}