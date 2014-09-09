using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PhotoSharing.Model;
using PhotoSharing.Ef;
using AutoMapper;
using PhotoSharing.Models;

namespace PhotoSharingApplication.Controllers
{
    public class PhotoController : Controller
    {
        private IPhotoRepository _rep = new EfRepository();

        //
        // GET: /Photo/

        public ActionResult Index()
        {
            return View(_rep.GetPhotos().Select(p => Mapper.Map<PhotoDisplayModel>(p)).ToList());
        }

        //
        // GET: /Photo/Details/5

        public ActionResult Details(int id = 0)
        {
            PhotoDetails photo = _rep.PhotoById(id);
            if (photo == null)
            {
                return HttpNotFound();
            }
            return View(Mapper.Map<PhotoDisplayModel>(photo));
        }

        //
        // GET: /Photo/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Photo/Create

        [HttpPost]
        public ActionResult Create(PhotoEditModel photo)
        {
            if (ModelState.IsValid)
            {
                var photo2 = Mapper.Map<Photo>(photo);

                photo2.CreatedDate = DateTime.Now;
                photo2.UserName = User.Identity.Name;

                _rep.AddOrUpdatePhoto(photo2);
                _rep.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(photo);
        }

        //
        // GET: /Photo/Edit/5

        public ActionResult Edit(int id = 0)
        {
            PhotoDetails photo = _rep.PhotoById(id);
            if (photo == null)
            {
                return HttpNotFound();
            }
            return View(photo);
        }

        //
        // POST: /Photo/Edit/5

        [HttpPost]
        public ActionResult Edit(Photo photo)
        {
            if (ModelState.IsValid)
            {
                _rep.AddOrUpdatePhoto(photo);
                _rep.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(photo);
        }

        //
        // GET: /Photo/Delete/5

        public ActionResult Delete(int id = 0)
        {
            PhotoDetails photo = _rep.PhotoById(id);
            if (photo == null)
            {
                return HttpNotFound();
            }
            return View(Mapper.Map<PhotoDisplayModel>(photo));
        }

        //
        // POST: /Photo/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            _rep.DeletePhoto(id);
            _rep.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            _rep.Dispose();
            base.Dispose(disposing);
        }
    }
}