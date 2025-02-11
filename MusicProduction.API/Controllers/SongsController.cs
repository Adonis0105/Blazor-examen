using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MusicProduction.API.Data;
using MusicProduction.API.DTOs;
using MusicProduction.API.Models;

namespace MusicProduction.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SongsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public SongsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<Song>> CreateSong(SongDto songDto)
        {
            var album = await _context.Albums.FindAsync(songDto.AlbumId);
            if (album == null)
                return NotFound("Album not found");

            var song = new Song
            {
                Title = songDto.Title,
                Artist = songDto.Artist,
                Duration = songDto.Duration,
                AlbumId = songDto.AlbumId
            };

            _context.Songs.Add(song);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetSong), new { id = song.Id }, song);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Song>>> GetSongs()
        {
            return await _context.Songs
                .Include(s => s.Album)
                .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Song>> GetSong(int id)
        {
            var song = await _context.Songs
                .Include(s => s.Album)
                .FirstOrDefaultAsync(s => s.Id == id);

            if (song == null)
                return NotFound();

            return song;
        }
    }
}