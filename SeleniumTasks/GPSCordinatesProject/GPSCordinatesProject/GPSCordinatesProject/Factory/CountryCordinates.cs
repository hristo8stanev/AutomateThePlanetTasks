namespace GPSCordinatesProject.Factory;
public class CountryCordinates
{

    //IN PROGRESS
    public string Country { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }

    public CountryCordinates(string country, double latitude, double longtitude)
    {
        Country = country;
        Latitude = latitude;
        Longitude = longtitude;
    }
}
