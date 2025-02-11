using MusicProduction.Client.Models;
using System.Net.Http.Json;

namespace MusicProduction.Client.Services
{
    public class MusicService : IMusicService
    {
        private readonly HttpClient _httpClient;

        public MusicService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<Album>> GetAlbums()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<Album>>("api/albums");
        }

        public async Task<Album> CreateAlbum(Album album)
        {
            var response = await _httpClient.PostAsJsonAsync("api/albums", album);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<Album>();
        }

        public async Task<IEnumerable<Song>> GetSongs()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<Song>>("api/songs");
        }

        public async Task<Song> CreateSong(Song song)
        {
            var response = await _httpClient.PostAsJsonAsync("api/songs", song);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<Song>();
        }
    }
}