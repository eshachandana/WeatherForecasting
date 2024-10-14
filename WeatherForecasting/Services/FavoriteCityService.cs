using Blazored.LocalStorage;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WeatherForecasting.Services
{
    public class FavoriteCityService
    {
        private const string FavoriteCitiesKey = "favoriteCities";
        private readonly ILocalStorageService _localStorage;

        public FavoriteCityService(ILocalStorageService localStorage)
        {
            _localStorage = localStorage;
        }

        public async Task<List<string>> GetFavoriteCitiesAsync()
        {
            try
            {
                var favorites = await _localStorage.GetItemAsync<List<string>>(FavoriteCitiesKey);
                return favorites ?? new List<string>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting favorite cities: {ex.Message}");
                return new List<string>();
            }
        }

        public async Task AddFavoriteCityAsync(string cityName)
        {
            var favorites = await GetFavoriteCitiesAsync();
            if (!favorites.Contains(cityName))
            {
                favorites.Add(cityName);
                await _localStorage.SetItemAsync(FavoriteCitiesKey, favorites);
            }
        }

        public async Task RemoveFavoriteCityAsync(string cityName)
        {
            var favorites = await GetFavoriteCitiesAsync();
            if (favorites.Remove(cityName))
            {
                await _localStorage.SetItemAsync(FavoriteCitiesKey, favorites);
            }
        }

        public async Task<bool> IsFavoriteCityAsync(string cityName)
        {
            var favorites = await GetFavoriteCitiesAsync();
            return favorites.Contains(cityName);
        }
    }
}