using LatviaMap.Models;

namespace LatviaMap.Services
{
    public class PlaceService : IPlaceService
    {
        private readonly PlaceRepository _placeRepository;

        public PlaceService(PlaceRepository placeRepository)
        {
            _placeRepository = placeRepository;
        }

        public IEnumerable<Place> GetExtremePlaces()
        {
            return _placeRepository.GetExtremePlaces();
        }

        public IEnumerable<Place> SearchPlaces(string query)
        {
            var places = _placeRepository.GetAllPlaces();
            return places.Where(p => p.Name.Contains(query, StringComparison.OrdinalIgnoreCase)).ToList();
        }
    }
}