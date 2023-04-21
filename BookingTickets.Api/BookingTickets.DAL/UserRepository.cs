using BookingTickets.DAL.Interfaces;
using BookingTickets.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace BookingTickets.DAL
{
    public class UserRepository: IUserRepository
    {
        private static Context _context;

        public UserRepository()
        {
            _context = new Context();
        }

        public List<UserDto> GetAllUsers()
        {
            //return _context.Users.Where(t => !t.IsDeleted).ToList();
            var result = new List<UserDto>();

            result = _context.Users
                .Include(u => u.Cinema)
                .AsNoTracking()
                .ToList();

            return result;
        }

        public UserDto GetUserById(int id)
        {
            try
            {
                return _context.Users
                .Include(u => u.Cinema)
                    .Single(u => u.Id == id);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                throw new Exception($"Id:{id} - отсутствует");
            }
        }

        public void CreateCashier(UserDto cashier)
        {

        }
    }
}

using BookingTickets.DAL.Interfaces;
using BookingTickets.DAL.Models;

namespace BookingTickets.DAL
{
    public class UserRepository : IUserRepository
    {
        public int AddNewUser(UserDto user)
        {
            throw new NotImplementedException();
        }
    }
}
