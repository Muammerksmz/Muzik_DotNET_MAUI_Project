using Microsoft.EntityFrameworkCore;
using Muzik.Models;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Muzik.Repositories
{
    public class SongRepository
    {
        private readonly AppDbContext _dbContext;

        public SongRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }



        public void AddSong(Song song)
        {
            _dbContext.Songs.Add(song);
            _dbContext.SaveChanges();
            Debug.WriteLine("Veriler eklendi.");
        }

        public List<Song> GetAllSongs()
        {
            return _dbContext.Songs.ToList();
        }



        public Song GetSongById(int id)
        {
            return _dbContext.Songs.FirstOrDefault(song => song.Id == id);
        }

        public void UpdateSong(Song song)
        {
            _dbContext.Entry(song).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }

        public void DeleteSong(Song song)
        {
            _dbContext.Songs.Remove(song);
            _dbContext.SaveChanges();
        }

        public void UpdateSongs()
        {
            var songs = GetAllSongs();
            _dbContext.Songs.RemoveRange(_dbContext.Songs);
            _dbContext.SaveChanges();

            _dbContext.Songs.AddRange(songs);
            _dbContext.SaveChanges();
        }

    }
}