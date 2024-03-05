using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPSCordinatesProject.Interface;
public interface IGeolocation
{
    void setGeoLocation(double latitude, double longitude);
}


