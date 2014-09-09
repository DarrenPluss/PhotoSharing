using AutoMapper;
using PhotoSharing.Ef;
using PhotoSharing.Filters;
using PhotoSharing.Model;
using PhotoSharing.Models;
using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PhotoSharingApplication.Controllers
{    
    public class PhotoController : Controller
    {
        private IPhotoRepository _rep = new EfRepository();

        //
        // GET: /Photo/

        public ActionResult Index()
        {
            return View(_rep.GetPhotos()
                .Select(p => Mapper.Map<PhotoDisplayModel>(p)).ToList());
        }

        //
        // GET: /Photo/Details/5

        public ActionResult Details(int id = 0)
        {
            PhotoDetails photo = _rep.PhotoDetailsById(id);
            if (photo == null)
            {
                return HttpNotFound();
            }
            return View(Mapper.Map<PhotoDisplayModel>(photo));
        }

        public ActionResult Image(int id)
        {
            PhotoImage photo = _rep.PhotoImageById(id);
            if (photo == null)
            {
                return HttpNotFound();
            }

            return File(photo.PhotoFile, photo.ImageMimeType);
        }

        public ActionResult Title(string title)
        {
            var photos = _rep.PhotosByTitle(title)
                .Select(p => Mapper.Map<PhotoDisplayModel>(p)).ToList();

            if (photos.Count == 1)
                return View("Details", photos.First());

            return View("Index", photos);
        }

        /* 
        Example of a version without filters
         
        public ActionResult Create2(PhotoEditModel photo)
        {
            //Audit this...

            if (!User.Identity.IsAuthenticated)
                return Redirect("????");

            if (Request.HttpMethod != "POST")
                return View();

            if (ModelState.IsValid)
            {
                var photo2 = Mapper.Map<Photo>(photo);

                photo2.CreatedDate = DateTime.Now;
                photo2.UserName = User.Identity.Name;

                _rep.AddOrUpdatePhoto(photo2);
                try
                {
                    _rep.SaveChanges();
                }
                catch
                {
                    Redirect("data base is broken error");
                }

                return RedirectToAction("Index");
            }

            return View(photo);
        }
        */

        public ActionResult Create()
        {
            return View();
        }


        //
        // POST: /Photo/Create

        [HttpPost]
        public ActionResult Create(PhotoEditModel photo, HttpPostedFileBase image)
        {
            if (ModelState.IsValid)
            {
                var photo2 = Mapper.Map<Photo>(photo);

                photo2.CreatedDate = DateTime.Now;
                photo2.UserName = User.Identity.Name;

                if (image != null)
                {
                    photo2.ImageMimeType = image.ContentType;
                    photo2.PhotoFile = new byte[image.ContentLength];
                    image.InputStream.Read(photo2.PhotoFile, 0, image.ContentLength);
                }

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
            PhotoDetails photo = _rep.PhotoDetailsById(id);
            if (photo == null)
            {
                return HttpNotFound();
            }
            return View(Mapper.Map<PhotoEditModel>(photo));
        }

        [ActionName("Edit")]
        [RoleFilter("Admins")]
        public ActionResult EditAdmin(int id = 0)
        {
            PhotoDetails photo = _rep.PhotoDetailsById(id);
            if (photo == null)
            {
                return HttpNotFound();
            }
            return View("EditAdmin",Mapper.Map<AdminPhotoEditModel>(photo));
        }

        //
        // POST: /Photo/Edit/5

        [HttpPost]
        public ActionResult Edit(PhotoEditModel photo)
        {
            if (ModelState.IsValid)
            {
                var originalPhoto = _rep.PhotoById(photo.PhotoID);
                Mapper.Map<PhotoEditModel, Photo>(photo, originalPhoto);
                _rep.AddOrUpdatePhoto(originalPhoto);
                _rep.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(photo);
        }

   

        //
        // POST: /Photo/Edit/5

        [HttpPost]
        [ActionName("Edit")]
        [RoleFilter("Admins")]
        public ActionResult EditAdmin(AdminPhotoEditModel photo)
        {
            if (ModelState.IsValid)
            {
                var originalPhoto = _rep.PhotoById(photo.PhotoID);
                Mapper.Map<AdminPhotoEditModel, Photo>(photo, originalPhoto);
                _rep.AddOrUpdatePhoto(originalPhoto);
                _rep.SaveChanges();
                return RedirectToAction("Index"); 
            }
            return View("EditAdmin", photo);
        }

        //
        // GET: /Photo/Delete/5

        public ActionResult Delete(int id = 0)
        {
            PhotoDetails photo = _rep.PhotoDetailsById(id);
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