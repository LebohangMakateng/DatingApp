using System.Collections.Generic;
using System.Threading.Tasks;
using API.DTOs;
using API.Entities;
using API.Interfaces;

namespace API.Data
{
    public class PhotoRepository : IPhotoRepository
    {
        private readonly DataContext _context;
        public PhotoRepository(DataContext context)
        {
            _context = context;
        }

        public Task<Photo> GetPhotoById(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<PhotoForApprovalDto>> GetUnapprovedPhotos()
        {
            throw new System.NotImplementedException();
        }

        public void RemovePhoto(Photo photo)
        {
            _context.Photos.Remove(photo);
        }
    }
}