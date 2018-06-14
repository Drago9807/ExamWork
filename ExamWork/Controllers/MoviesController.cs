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
        private IBaseRepository baseRepository;

        public MoviesController()
        {
            this.baseRepository = new BaseRepository(new MovieContext());///////
        }
        private MovieContext db = new MovieContext();


        // GET: Movies
        [HttpGet]
        public ActionResult Index()
        {
            var movies = db.Movies.Include(c => c.Director).Include(c => c.Genre);
            return View(movies.ToList());
        }

        // GET: Movies/Details/5
        [HttpGet]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }
        public ViewResult Details(int id)
        {
            Movie movie = baseRepository.GetMovieByID(id); ///////
            return View(movie);
        }

        // GET: Movies/Create
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.DirectorID = new SelectList(db.Directors, "DirectorID", "DirectorName");
            ViewBag.GenreID = new SelectList(db.Genres, "GenreID", "GenreType");
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
                db.Movies.Add(movie);
                db.SaveChanges();///////
                //baseRepository.InsertMovie(movie);////////
                //baseRepository.Save();//////////
                return RedirectToAction("Index");
            }

            ViewBag.DirectorID = new SelectList(db.Directors, "DirectorID", "DirectorName", movie.DirectorID);
            ViewBag.GenreID = new SelectList(db.Genres, "GenreID", "GenreType", movie.GenreID);
            return View(movie);
        }

        // GET: Movies/Edit/5
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            ViewBag.DirectorID = new SelectList(db.Directors, "DirectorID", "DirectorName", movie.DirectorID);
            ViewBag.GenreID = new SelectList(db.Genres, "GenreID", "GenreType", movie.GenreID);
            //Movie movie = baseRepository.GetMovieByID(id);
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
                db.Entry(movie).State = EntityState.Modified;
                db.SaveChanges();
                baseRepository.UpdateMovie(movie);////////
                baseRepository.Save();///////
                return RedirectToAction("Index");
            }
            ViewBag.DirectorID = new SelectList(db.Directors, "DirectorID", "DirectorName", movie.DirectorID);
            ViewBag.GenreID = new SelectList(db.Genres, "GenreID", "GenreType", movie.GenreID);
            return View(movie);
        }

        // GET: Movies/Delete/5
        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            //Movie movie = baseRepository.GetMovieByID(id);//
            return View(movie);
        }

        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Movie movie = db.Movies.Find(id);
            db.Movies.Remove(movie);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            baseRepository.Dispose();
            base.Dispose(disposing);
        }
    }
}
