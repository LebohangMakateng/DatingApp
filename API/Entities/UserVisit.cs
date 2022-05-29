namespace API.Entities
{
    public class UserVisit
    {
        public AppUser SourceeUser { get; set; }
        public int SourceeUserId {get;set;}
        public AppUser VisitedUser{get;set;}
        public int VisitedUserId { get; set; }
    }
}