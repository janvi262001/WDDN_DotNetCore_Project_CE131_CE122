using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce_MVC_Core.Data;
using Ecommerce_MVC_Core.Models.Admin;

namespace Ecommerce_MVC_Core.Code
{
    public static class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();

            if (!context.Countries.Any())
            {
                var country = new Country[]
                {
                    new Country{Name = "USA",AddedDate = DateTime.Parse("2018-01-01"),ModifiedDate = DateTime.Parse("2018-01-01")},
                    new Country{Name = "India",AddedDate = DateTime.Parse("2018-01-01"),ModifiedDate = DateTime.Parse("2018-01-01")},
                };
                foreach (Country c in country)
                {
                    context.Countries.Add(c);
                }
                context.SaveChanges();
            }

            if (!context.Cities.Any())
            {
                var coutryId = context.Countries.First(x=>x.Name=="USA").Id;
                var city = new City[]
                {
                    new City{Name = "Los Angeles",CountryId = coutryId,AddedDate = DateTime.Parse("2018-01-01"),ModifiedDate = DateTime.Parse("2018-01-01")},
                    new City{Name = "Chicago",CountryId = coutryId,AddedDate = DateTime.Parse("2018-01-01"),ModifiedDate = DateTime.Parse("2018-01-01")},
                    new City{Name = "Houston",CountryId = coutryId,AddedDate = DateTime.Parse("2018-01-01"),ModifiedDate = DateTime.Parse("2018-01-01")},
                };
                foreach (City c in city)
                {
                    context.Cities.Add(c);
                }
                context.SaveChanges();
            }


        }
    }
}
