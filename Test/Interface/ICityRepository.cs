using GG.Models;

namespace GG.Interface
{
    public interface ICityRepository
    {
        Task<IEnumerable<City>> GetCitiesAsync();
        void AddCity(City city);
        void UpdateCity(City city);
        void DetachCity(int cityId);

        Task<City> FindCity(int id);



    }
}
