using ExamWork.DB.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamWork.DB.DataAccessLayer
{
    //намира приложение в application_start
    public class MovieInitializer : System.Data.Entity.DropCreateDatabaseAlways<MovieContext>
    {
        protected override void Seed(MovieContext context)
        {
            GetMovies().ForEach(c => context.Movies.Add(c));
            GetGenres().ForEach(c => context.Genres.Add(c));
            GetDirectors().ForEach(c => context.Directors.Add(c));
        }

        private static List<Movie> GetMovies()
        {
            var movies = new List<Movie>
                    {
                        new Movie{MovieID=1,MovieName="Avengers: Infinity war",MoviePrice=5.00,GenreID=1,DirectorID=1},
                        new Movie{MovieID=2,MovieName="Black Panther",MoviePrice=7.00,GenreID=1,DirectorID=1},
                        new Movie{MovieID=3,MovieName="Deadpool 2",MoviePrice=6.00,GenreID=1,DirectorID=2},
                        new Movie{MovieID=4,MovieName="Solo: A star wars story",MoviePrice=5.00,GenreID=2,DirectorID=3},
                        new Movie{MovieID=5,MovieName="Jurassic world",MoviePrice=4.00,GenreID=2,DirectorID=4},
                        new Movie{MovieID=6,MovieName="Night games",MoviePrice=3.00,GenreID=3,DirectorID=5}
                    };
            return movies;
        }

        private static List<Genre> GetGenres()
        {
            var genres = new List<Genre>
                    {
                        new Genre{GenreID=1,GenreType="Action"},
                        new Genre{GenreID=2,GenreType="Fantasy"},
                        new Genre{GenreID=3,GenreType="Comedy"}
                    };
            return genres;
        }
        private static List<Director> GetDirectors()
        {
            var directors = new List<Director>
                    {
                        new Director{DirectorID=1,DirectorName="Ryan Coogler"},
                        new Director{DirectorID=2,DirectorName="Ron Howard"},
                        new Director{DirectorID=3,DirectorName="David Leitch"},
                        new Director{DirectorID=4,DirectorName="Colin Trevorrow"},
                        new Director{DirectorID=5,DirectorName="Jorn Francis Daley"}
                    };
            return directors;
        }

    }
}
