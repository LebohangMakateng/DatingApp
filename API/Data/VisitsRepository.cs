using System.Linq;
using System.Threading.Tasks;
using API.DTOs;
using API.Entities;
using API.Extensions;
using API.Helpers;
using API.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class VisitsRepository : IVisitsRepository
    {
        private readonly DataContext _context;
        public VisitsRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<UserVisit> GetUserVisit(int sourceeUserId, int VisitedUserId)
        {
            return await _context.Visits.FindAsync(sourceeUserId, VisitedUserId);
        }

        public async Task<PagedList<VisitDto>> GetUserVisits(VisitsParams visitsParams)
        {
            var users = _context.Users.OrderBy(u => u.UserName).AsQueryable();
            var Visits = _context.Visits.AsQueryable();

            if (visitsParams.Predicate == "visited")
            {
                Visits = Visits.Where(visit => visit.SourceeUserId == visitsParams.UserId);
                users = Visits.Select(visit => visit.VisitedUser); // List of users visited by the current user
            }

            if (visitsParams.Predicate == "visitedBy")
            {
                Visits = Visits.Where(visit => visit.VisitedUserId == visitsParams.UserId);
                users = Visits.Select(visit => visit.SourceeUser); // List of users who have visited the current user
            }

            var visitedUsers = users.Select(user => new VisitDto
            {
                Username = user.UserName,
                KnownAs = user.KnownAs,
                Age = user.DateOfBirth.CalculateAge(),
                PhotoUrl = user.Photos.FirstOrDefault(p => p.IsMain).Url,
                City = user.City,
                Id = user.Id
            });

            return await PagedList<VisitDto>.CreateAsync(visitedUsers,
            visitsParams.PageNumber, visitsParams.PageSize);
        }

        public async Task<AppUser> GetUserWithVisits(int userId)
        {
            return await _context.Users
                .Include(x => x.VisitedUsers)
                .FirstOrDefaultAsync(x => x.Id == userId);
        }
    }
}