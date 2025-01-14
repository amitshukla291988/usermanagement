﻿using GG.Interface;
using GG.Models;
using Microsoft.EntityFrameworkCore;

namespace GG.Data.Repo
{
    public class CityRepository : ICityRepository
    {
        private readonly DataContext dc;

        public CityRepository(DataContext dc)
        {
            this.dc = dc;
        }
        public void AddCity(City city)
        {
           dc.Cities.Add(city);
        }

        public void UpdateCity(City city) { 
            dc.Cities.Update(city);
        }
        public void DetachCity(int cityId)
        {
            var city = dc.Cities.Find(cityId);
            dc.Cities.Remove(city);
        }

        public async Task<City> FindCity(int id)
        {
            return await dc.Cities.FindAsync(id);
        }

        public async Task<IEnumerable<City>> GetCitiesAsync()
        {
            return await dc.Cities.ToListAsync();
        }
/*
        public async Task<bool> SaveAsync()
        {
            return await dc.SaveChangesAsync() > 0;
        }*/
    }
}
