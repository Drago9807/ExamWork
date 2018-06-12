using ExamWork.DB;
using ExamWork.DB.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class UnitOfWork : IDisposable
    {
        private MovieContext context = new MovieContext();
        private GenericRepository<Movie> movieRepository;
        private GenericRepository<Genre> genreRepository;
        private GenericRepository<Director> directorRepository;

        public UnitOfWork(MovieContext connection)
        {
            context = connection;
        }
        public GenericRepository<Movie> MovieRepository
        {
            get
            {

                if (this.movieRepository == null)
                {
                    this.movieRepository = new GenericRepository<Movie>(context);
                }
                return movieRepository;
            }
        }

        public GenericRepository<Genre> GenreRepository
        {
            get
            {

                if (this.genreRepository == null)
                {
                    this.genreRepository = new GenericRepository<Genre>(context);
                }
                return genreRepository;
            }
        }

        public GenericRepository<Director> DirectorRepository
        {
            get
            {

                if (this.directorRepository == null)
                {
                    this.directorRepository = new GenericRepository<Director>(context);
                }
                return directorRepository;
            }
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
