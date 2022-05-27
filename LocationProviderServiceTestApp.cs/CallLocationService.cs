using System;
using System.Collections.Generic;
using System.Reflection;
using FWPJ.LocationServices;

namespace LocationProviderServiceTestApp.cs
{
    public static class CallLocationService
    {
        public static void CallLocationsForService(string URL, List<string> ServiceCodes, bool IncludeLocationTypeCodeFilter)
        {
            var serviceURL = LocationsServices.CreateURL(URL, ServiceCodes, null, IncludeLocationTypeCodeFilter);
            Console.WriteLine("URL invoked:");
            Console.WriteLine(serviceURL);
            Console.WriteLine("=================================");
            var result = LocationsServices.GetForServiceByCounty(URL, ServiceCodes);

            foreach(var key in result.Keys)
            {
                Console.WriteLine("**** Key: " + key + ", Count: " + result[key].Count.ToString());
                foreach(var l in result[key])
                {
                    Console.WriteLine("---- " + l.Name + ", " + l.City + " " + l.StateAbbreviation + " " + l.ZipCode);
                }
            }
        }
    }
}
