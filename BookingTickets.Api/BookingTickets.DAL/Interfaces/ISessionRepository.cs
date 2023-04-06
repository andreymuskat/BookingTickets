using BookingTickets.DAL.Models;

namespace BookingTickets.DAL.Interfaces
{
    public interface ISessionRepository
    {
        public SessionDto CreateSession(SessionDto session);
        public void UpdateSession(SessionDto session);
        public void DeleteSession(int idSession);
    }
}