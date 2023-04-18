using BookingTickets.BLL.Authentication.AuthModels;

namespace BookingTickets.BLL.Authentication
{
    public interface IAuthService
    {
        Task<AuthResult> RegisterUser(UserRegister userregister);

        Task<AuthResult> LoginUser(UserLogin userLogin);
    }
}