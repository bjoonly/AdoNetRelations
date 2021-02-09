using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoNetRelationships
{
    internal class Initializer : DropCreateDatabaseIfModelChanges<AirlinesDbContext>
    {
        protected override void Seed(AirlinesDbContext context)
        {
            base.Seed(context);

            Type type1 = context.Types.Add(new Type() { Name = "Commercial" });
            Type type2 = context.Types.Add(new Type() { Name = "Jets" });
            Type type3 = context.Types.Add(new Type() { Name = "Props" });
            context.SaveChanges();

            Country ua = context.Countries.Add(new Country() { Name = "Ukraine" });
            Country pl = context.Countries.Add(new Country() { Name = "Poland" });
            Country tr = context.Countries.Add(new Country() { Name = "Turkey" });
            Country usa = context.Countries.Add(new Country() { Name = "United States" });
            Country fr = context.Countries.Add(new Country() { Name = "France" });
            context.SaveChanges();

            City kyiv = context.Cities.Add(new City() { Name = "Kyiv", CountryId = ua.Id });
            City lviv = context.Cities.Add(new City() { Name = "Lviv", CountryId = ua.Id });
            City rivne = context.Cities.Add(new City() { Name = "Rivne", CountryId = ua.Id });
            City warsaw = context.Cities.Add(new City() { Name = "Warsaw", CountryId = pl.Id });
            City krakow = context.Cities.Add(new City() { Name = "Kraków", CountryId = pl.Id });
            City istanbul = context.Cities.Add(new City() { Name = "İstanbul", CountryId = tr.Id });
            City ankara = context.Cities.Add(new City() { Name = "Ankara", CountryId = tr.Id });
            context.SaveChanges();

            DateTime dateTime1 = new DateTime(2021, 3, 20, 8, 30, 0);
            DateTime dateTime2 = new DateTime(2021, 3, 25, 10, 0, 0);
            

            Airplane airplane1 = context.Airplanes.Add(new Airplane()
            {
                Model = "Boeing 787",
                CountryId = usa.Id,
                MaxPassengers = 287,
                TypeId = type1.Id
            });
            Airplane airplane2 = context.Airplanes.Add(new Airplane()
            {
                Model = "Airbus A320",
                CountryId = fr.Id,
                MaxPassengers = 256,
                TypeId = type2.Id
            });
            Airplane airplane3 = context.Airplanes.Add(new Airplane()
            {
                Model = "Airbus A220",
                CountryId = fr.Id,
                MaxPassengers = 256,
                TypeId = type3.Id
            });
            context.SaveChanges();

            context.Flights.Add(new Flight()
            {
                DepartureTime = System.DateTime.Now,
                AirplaneId = airplane1.Id,
                CityFromId = kyiv.Id,
                CityToId = ankara.Id
            });
            context.Flights.Add(new Flight()
            {
                DepartureTime = System.DateTime.Now,
                AirplaneId = airplane1.Id,
                CityFromId = lviv.Id,
                CityToId = krakow.Id
            });
            context.Flights.Add(new Flight()
            {
                DepartureTime = System.DateTime.Now,
                AirplaneId = airplane2.Id,
                CityFromId = warsaw.Id,
                CityToId = istanbul.Id
            });
            context.Flights.Add(new Flight()
            {
                DepartureTime = dateTime1,
                AirplaneId = airplane1.Id,
                CityFromId = warsaw.Id,
                CityToId = istanbul.Id
            });
            context.Flights.Add(new Flight()
            {
                DepartureTime = dateTime1,
                AirplaneId = airplane2.Id,
                CityFromId = istanbul.Id,
                CityToId = rivne.Id
            });
            context.Flights.Add(new Flight()
            {
                DepartureTime = dateTime1,
                AirplaneId = airplane3.Id,
                CityFromId = istanbul.Id,
                CityToId = lviv.Id
            });
            context.Flights.Add(new Flight()
            {
                DepartureTime = dateTime1,
                AirplaneId = airplane3.Id,
                CityFromId = istanbul.Id,
                CityToId = lviv.Id
            });
            context.Flights.Add(new Flight()
            {
                DepartureTime = dateTime2,
                AirplaneId = airplane2.Id,
                CityFromId = lviv.Id,
                CityToId = istanbul.Id
            });
            context.Flights.Add(new Flight()
            {
                DepartureTime = dateTime2,
                AirplaneId = airplane1.Id,
                CityFromId = istanbul.Id,
                CityToId = lviv.Id
            });
            context.Flights.Add(new Flight()
            {
                DepartureTime = dateTime2,
                AirplaneId = airplane3.Id,
                CityFromId = ankara.Id,
                CityToId = rivne.Id
            });
            context.Flights.Add(new Flight()
            {
                DepartureTime = dateTime2,
                AirplaneId = airplane3.Id,
                CityFromId = rivne.Id,
                CityToId = ankara.Id
            });
            context.SaveChanges();
        }
    }
}
