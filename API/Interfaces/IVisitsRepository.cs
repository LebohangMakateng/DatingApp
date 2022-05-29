using System.Threading.Tasks;
using API.Entities;

namespace API.Interfaces
{
    public interface IVisitsRepository
    {
         Task<UserVisit> GetUserLike(int sourceUserId, int likedUserId);
        Task<AppUser> GetUserWithLikes(int userId);
        Task<PagedList<LikeDto>> GetUserLikes(LikesParams likesParams);
    }
}