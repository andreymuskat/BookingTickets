using BookingTickets.BLL.CustomException;
using BookingTickets.BLL.Models.All_User_InputModel;
using BookingTickets.DAL;
using BookingTickets.DAL.Interfaces;

namespace BookingTickets.BLL
{
    public class UserManager
    {
        private MapperBLL _instanceMapperBll = MapperBLL.getInstance();
        private readonly IUserRepository _userRepository;
        private readonly ICinemaRepository _cinemaRepository;

        public UserManager()
        {
            _userRepository = new UserRepository();
            _cinemaRepository= new CinemaRepository();
        }

        public void AddNewAdmin(CreateNewEmployeeInputModel user)
        {
            var cinema = _cinemaRepository.GetCinemaById(user.CinemaId);

            if(cinema == null) 
            { throw new UserExceptions("Кинотеатра, в который вы хотите записать администратора, не существует."); }
            else
            {
                _userRepository.AddNewUser(_instanceMapperBll.MapCreateNewEmployeeInputModelToUserDto(user));
            }
        }
    }
}