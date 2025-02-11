using MusicProduction.Client.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MusicProduction.Client.Services
{
    public interface IMusicService
    {
        Task<IEnumerable<Album>> GetAlbums();
        Task<Album> CreateAlbum(Album album);
        Task<IEnumerable<Song>> GetSongs();
        Task<Song> CreateSong(Song song);
    }
}