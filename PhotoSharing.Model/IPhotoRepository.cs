using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoSharing.Model
{
    public interface IPhotoRepository : IDisposable
    {
        PhotoDetails PhotoById(int id);
        List<PhotoDetails> GetPhotos(int count = 0);
        PhotoImage PhotoImageById(int id);
        void DeletePhoto(int id);
        void AddOrUpdatePhoto(Photo photo);
        void SaveChanges();
    }
}
