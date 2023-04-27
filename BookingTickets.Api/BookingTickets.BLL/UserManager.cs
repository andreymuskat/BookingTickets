using AutoMapper;
using BookingTickets.BLL.Models;
using BookingTickets.DAL.Interfaces;
using BookingTickets.DAL;

namespace BookingTickets.BLL
{
    public class UserManager
    {
        private MapperBLL _instanceMapperBll = MapperBLL.getInstance();
        private readonly IAuthRepository _authRepository;


        public UserManager()
        {
            _authRepository = new AuthRepository();
        }
        public UserBLL GetUserByName(string name)
        {
            return _instanceMapperBll.MapUserDtoUserBLL(_authRepository.GetUserByName(name));
        }
    }
}