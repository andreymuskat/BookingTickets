using CompanyName.Application.Services.AuthService.Models;

namespace BookingTickets.BLL.Authentication
{
    public interface IAuthService
    {
        Task<AuthResult> RegisterUser(UserRegister userregister);

        Task<AuthResult> LoginUser(UserLogin userLogin);
    }
}