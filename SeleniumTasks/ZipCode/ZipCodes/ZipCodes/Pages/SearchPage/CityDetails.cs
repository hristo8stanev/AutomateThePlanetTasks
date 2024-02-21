using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZipCodes.Pages.SearchPage;
public class CityDetails
{

    public string CityName { get; set; }
    public string State { get; set; }
    public string ZipCode { get; set; }
    public string LongitudeAndLatitude { get; set; }
    public string GoogleMapsLink { get; set; }


    public CityDetails(string cityName, string state, string zipCode, string longitudeAndLatitude, string googleMapsLink)
    {
        CityName = cityName;
        State = state;
        ZipCode = zipCode;
        LongitudeAndLatitude = longitudeAndLatitude;
        GoogleMapsLink = googleMapsLink;

    }
    public override string ToString()
    {
        return $"City: {CityName}, State: {State}, ZIP Code: {ZipCode}, Longtitude and Latitude: {LongitudeAndLatitude}";

    }
}
