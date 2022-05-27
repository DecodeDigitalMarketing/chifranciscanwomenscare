using System;
using System.Collections.Generic;
using FWPJ.ProviderServices;

namespace LocationProviderServiceTestApp
{
    public static class CallProviderService
    {
        public static void CallProvidersForServiceCode(string URL, List<string> SpecialtyCodes)
        {
            var serviceURL = ProviderServices.CreateURL(URL, SpecialtyCodes);
            Console.WriteLine("URL invoked:");
            Console.WriteLine(serviceURL);
            Console.WriteLine("=================================");
            var providers = ProviderServices.GetProvidersForServiceCode(URL, SpecialtyCodes);

            foreach (var provider in providers)
            {
                Console.WriteLine("First name: " + provider.FirstName);
                Console.WriteLine("Last name: " + provider.LastName);
                Console.WriteLine("Degrees: " + provider.Degrees);
                Console.WriteLine("ImageURL: " + provider.ImageURL);
                Console.WriteLine("BiographyHTML: " + provider.BiographyHTML);
                Console.WriteLine("Location: " + provider.Locations.Count.ToString());
                foreach(var location in provider.Locations)
                {
                    Console.WriteLine("------------------------");
                    Console.WriteLine("Sort Order: " + location.SortOrder.ToString());
                    Console.WriteLine("Name: " + location.Name);
                    Console.WriteLine("Address1: " + location.Address1);
                    if(!string.IsNullOrWhiteSpace(location.Address2))
                    {
                        Console.WriteLine("Address2: " + location.Address2);
                    }
                    Console.WriteLine(location.City + ", " + location.StateAbbreviation + " " + location.ZipCode);
                    Console.WriteLine("Phone: " + location.Phone);
                }
                Console.WriteLine();
                Console.WriteLine("============================================");
                Console.WriteLine();
            }
        }
    }
}
