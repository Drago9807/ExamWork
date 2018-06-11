using ExamWork.DB.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public interface IBaseRepository : IDisposable
    {
        IEnumerable<Movie> GetMovies();
        Movie GetMovieByID(int movieId);
        void InsertMovie(Movie movie);
        void DeleteMovie(int movieID);
        void UpdateMovie(Movie movie);
        void Save();
    }
}
