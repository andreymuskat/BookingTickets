using BookingTickets.DAL.Interfaces;
using BookingTickets.DAL.Models;

namespace BookingTickets.DAL
{
    public class AuthRepository : IAuthRepository
    {
        private readonly AuthContext context;

        public AuthRepository(AuthContext authContext)
        {
            context = authContext;
        }

        public int AddUser(UserDto user)
        {
            context.Users.Add(user);
            context.SaveChanges();

            return user.Id;
        }

        public UserDto GetUser(string name)
        {
            var res = context.Users.Single(s => s.Name == name);
            return res;
        }


    }
}
