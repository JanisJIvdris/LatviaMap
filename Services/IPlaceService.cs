using LatviaMap.Models;

namespace LatviaMap.Services
{
    public interface IPlaceService
    {
        IEnumerable<Place> GetExtremePlaces();
        IEnumerable<Place> SearchPlaces(string query);
    }
}