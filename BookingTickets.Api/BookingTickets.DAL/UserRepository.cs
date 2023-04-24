using BookingTickets.DAL.Interfaces;
using BookingTickets.DAL.Models;

namespace BookingTickets.DAL
{
    public class UserRepository : IUserRepository
    {

        private readonly Context _context;

        public UserRepository()
        {
            _context = new Context();
        }

        public int AddNewUser(UserDto user)
        {
            throw new NotImplementedException();
        }

        //_____________

        public int GetCashiersCinemaId(UserDto user)
        {
            return user.CinemaId;
        }
    }
}
