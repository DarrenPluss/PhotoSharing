using PhotoSharing.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoSharing.Ef
{
    public class EfRepository : IPhotoRepository
    {
        PhotoSharingContext _db = new PhotoSharingContext();

        PhotoDetails IPhotoRepository.PhotoDetailsById(int id)
        {
            var pd = _db.Photos.Where(p => p.PhotoID == id)
                .Select(p => new PhotoDetails
                {
                    PhotoID = p.PhotoID,
                    Title = p.Title,
                    Description = p.Description,
                    UserName = p.UserName,
                    CreatedDate = p.CreatedDate
                }).FirstOrDefault();

            return pd;
        }

        List<PhotoDetails> IPhotoRepository.GetPhotos(int count = 0)
        {
            var photos = _db.Photos.Select(p => new PhotoDetails
               {
                   PhotoID = p.PhotoID,
                   Title = p.Title,
                   Description = p.Description,
                   UserName = p.UserName,
                   CreatedDate = p.CreatedDate
               });

            if (count == 0)
                return photos.ToList();

            return photos.Take(count).ToList();
     
        }

        List<PhotoDetails> IPhotoRepository.PhotosByTitle(string title)
        {
            var photos = _db.Photos.Where(p => p.Title.Contains(title)).Select(p => new PhotoDetails
            {
                PhotoID = p.PhotoID,
                Title = p.Title,
                Description = p.Description,
                UserName = p.UserName,
                CreatedDate = p.CreatedDate
            });

            return photos.ToList();
        }

        PhotoImage IPhotoRepository.PhotoImageById(int id)
        {
            var pi = _db.Photos.Where(p => p.PhotoID == id)
                .Select(p => new PhotoImage
                {
                    PhotoID = p.PhotoID,
                    ImageMimeType=p.ImageMimeType,
                    PhotoFile = p.PhotoFile
                }).FirstOrDefault();

            return pi;
        }

        void IPhotoRepository.DeletePhoto(int id)
        {
            var p = new Photo { PhotoID = id };
            _db.Photos.Attach(p);
            _db.Entry(p).State = System.Data.EntityState.Deleted;
        }

        void IPhotoRepository.AddOrUpdatePhoto(Photo photo)
        {
            var original = _db.Photos.SingleOrDefault(p => p.PhotoID == photo.PhotoID);

            if (original == null)
                _db.Photos.Add(photo);
            else
                _db.Entry(original).CurrentValues.SetValues(photo);
        }
        
        void IPhotoRepository.SaveChanges()
        {
            _db.SaveChanges();
        }

        void IDisposable.Dispose()
        {
            if (_db != null)
                _db.Dispose();
        }
        
        Photo IPhotoRepository.PhotoById(int id)
        {
            return _db.Photos.FirstOrDefault(p => p.PhotoID == id);
        }
    }
}
