using System;
using System.Collections.Generic;
using System.Configuration;

namespace LocationProviderServiceTestApp.cs
{
    class Program
    {
        public static string LocationsURL;
        public static string ProvidersURL;

        static void Main(string[] args)
        {
            GetURLs();

            // Specialty Codes can be Family Medicine: FMP, Midwifery: CNM, Obstetrics: OBS
            var specialtyCodes = new List<string>();
            specialtyCodes.Add("CNM");

            CallProviderService.CallProvidersForServiceCode(ProvidersURL, specialtyCodes);



            //var serviceCodes = new List<string>();
            //serviceCodes.Add(FWPJConstants.Locations.ServiceCodes.Midwifery);
            //serviceCodes.Add(FWPJConstants.Locations.ServiceCodes.CenteringPregnancy);
            //serviceCodes.Add(FWPJConstants.Locations.ServiceCodes.FamilyMedicineObstetrics);
            //serviceCodes.Add(FWPJConstants.Locations.ServiceCodes.Obstetrics);

            
            //CallLocationService.CallLocationsForService(LocationsURL, serviceCodes, true);
            //CallLocationService.CallLocationsForService(LocationsURL, serviceCodes, false);

            Console.Write("Press Enter to end.");
            Console.ReadLine();
        }

        private static void GetURLs()
        {
            LocationsURL = ConfigurationManager.AppSettings["LocationServiceURL"];
            ProvidersURL = ConfigurationManager.AppSettings["ProviderServiceURL"];
        }
    }
}
