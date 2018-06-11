using DataAccess.Repositories;
using ExamWork.DB;
using ExamWork.DB.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class BaseRepository : IBaseRepository, IDisposable
    {
        private MovieContext context;

        public BaseRepository(MovieContext context)
        {
            this.context = context;
        }

        public IEnumerable<Movie> GetMovies()
        {
            return context.Movies.ToList();
        }

        public Movie GetMovieByID(int id)
        {
            return context.Movies.Find(id);
        }

        public void InsertMovie(Movie movie)
        {
            context.Movies.Add(movie);
        }

        public void DeleteMovie(int movieID)
        {
            Movie movie = context.Movies.Find(movieID);
            context.Movies.Remove(movie);
        }

        public void UpdateMovie(Movie movie)
        {
            context.Entry(movie).State = EntityState.Modified;
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
