using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DataAccess;
using DataAccess.Repositories;
using ExamWork.DB;
using ExamWork.DB.Entities;

namespace ExamWork.Controllers
{
    public class MoviesController : Controller
    {
        //TUK NE SUM SIGUREN
        private IBaseRepository baseRepository;

        public MoviesController()
        {
            this.baseRepository = new BaseRepository(new MovieContext());
        }
        //VNIMAVAI SHHH ALO^

        //private MovieContext db = new MovieContext();

        // GET: Movies
        //public ActionResult Index()
        //{
        //    var movies = db.Movies.Include(m => m.Director).Include(m => m.Genre);
        //    return View(movies.ToList());
        //}
        public ViewResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            //ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            ViewBag.CurrentFilter = searchString;

            var movies = from s in baseRepository.GetMovies()
                           select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                movies = movies.Where(s => s.MovieName.ToUpper().Contains(searchString.ToUpper())
            //|| s.FirstMidName.ToUpper().Contains(searchString.ToUpper()));
            );
            }
            switch (sortOrder)
            {
                case "name_desc":
                    movies = movies.OrderByDescending(s => s.MovieName);
                    break;
                //case "Date":
                //    movies = movies.OrderBy(s => s.EnrollmentDate);
                //    break;
                //case "date_desc":
                //    movies = movies.OrderByDescending(s => s.EnrollmentDate);
                //    break;
                default:  // Name ascending 
                    movies = movies.OrderBy(s => s.MovieName);
                    break;
            }

            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return View(movies/*.ToPagedList(pageNumber, pageSize)*/);
        }

        // GET: Movies/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Movie movie = db.Movies.Find(id);
        //    if (movie == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(movie);
        //}
        public ViewResult Details(int id)
        {
            Movie movie = baseRepository.GetMovieByID(id);
            return View(movie);
        }

        // GET: Movies/Create
        public ActionResult Create()
        {
        //    ViewBag.DirectorID = new SelectList(db.Directors, "DirectorID", "DirectorName");
        //    ViewBag.GenreID = new SelectList(db.Genres, "GenreID", "GenreType");
            return View();
        }

        // POST: Movies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MovieID,MovieName,MoviePrice,GenreID,DirectorID")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                //db.Movies.Add(movie);
                //db.SaveChanges();
                baseRepository.InsertMovie(movie);
                baseRepository.Save();
                return RedirectToAction("Index");
            }

            //ViewBag.DirectorID = new SelectList(db.Directors, "DirectorID", "DirectorName", movie.DirectorID);
            //ViewBag.GenreID = new SelectList(db.Genres, "GenreID", "GenreType", movie.GenreID);
            return View(movie);
        }

        // GET: Movies/Edit/5
        public ActionResult Edit(int/*?*/ id)
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            //Movie movie = db.Movies.Find(id);
            //if (movie == null)
            //{
            //    return HttpNotFound();
            //}
            //ViewBag.DirectorID = new SelectList(db.Directors, "DirectorID", "DirectorName", movie.DirectorID);
            //ViewBag.GenreID = new SelectList(db.Genres, "GenreID", "GenreType", movie.GenreID);
            Movie movie = baseRepository.GetMovieByID(id);
            return View(movie);
        }

        // POST: Movies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MovieID,MovieName,MoviePrice,GenreID,DirectorID")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(movie).State = EntityState.Modified;
                //db.SaveChanges();
                baseRepository.UpdateMovie(movie);
                baseRepository.Save();
                return RedirectToAction("Index");
            }
            //ViewBag.DirectorID = new SelectList(db.Directors, "DirectorID", "DirectorName", movie.DirectorID);
            //ViewBag.GenreID = new SelectList(db.Genres, "GenreID", "GenreType", movie.GenreID);
            return View(movie);
        }

        // GET: Movies/Delete/5
        public ActionResult Delete(int/*?*/ id)
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            //Movie movie = db.Movies.Find(id);
            //if (movie == null)
            //{
            //    return HttpNotFound();
            //}
            Movie movie = baseRepository.GetMovieByID(id);
            return View(movie);
        }

        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                Movie movie = baseRepository.GetMovieByID(id);
                baseRepository.DeleteMovie(id);
                baseRepository.Save();
            }
            catch (DataException /* dex */)
            {
                //Log the error (uncomment dex variable name after DataException and add a line here to write a log.
                return RedirectToAction("Delete", new { id = id, saveChangesError = true });
            }
            //Movie movie = db.Movies.Find(id);
            //db.Movies.Remove(movie);
            //db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            //if (disposing)
            //{
            //    db.Dispose();
            //}
            baseRepository.Dispose();
            base.Dispose(disposing);
        }
    }
}
