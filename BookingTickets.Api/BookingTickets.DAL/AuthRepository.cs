using System.Collections.Generic;
using BookingTickets.DAL.Interfaces;
using BookingTickets.DAL.Models;

namespace BookingTickets.DAL
{
    public class AuthRepository : IAuthRepository
    {
        private readonly Context _context;

        public AuthRepository()
        {
            _context = new Context();
        }

        public Dictionary<string, int?> GetAllEmployeesCinemaId()
        {
            var users = _context.Users;
            Dictionary<string, int?> usersD = new Dictionary<string, int?>();
            foreach (var user in users)
            {
                if (user.CinemaId != null)
                {
                    usersD.Add("{user.CinemaId}", user.CinemaId);
                }
            }

            return usersD;
        }

        public int AddUser(UserDto user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();

            return user.Id;
        }

        public UserDto GetUserByName(string name)
        {
            var res = _context.Users.Single(s => s.Name == name);
            return res;
        }


    }
}
