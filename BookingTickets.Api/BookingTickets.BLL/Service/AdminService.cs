using BookingTickets.BLL.InterfacesBll;
using BookingTickets.BLL.InterfacesBll.Service_Interfaces;
using BookingTickets.BLL.Models;
using BookingTickets.BLL.Models.InputModel.All_Session_InputModel;
using BookingTickets.BLL.Models.InputModel.All_Statistics_InputModels;
using BookingTickets.BLL.Models.InputModel.All_User_InputModel;
using BookingTickets.BLL.Models.OutputModel.All_Statistics_OutputModels;
using BookingTickets.Core.CustomException;
using Core.ILogger;
using Core.Status;

namespace BookingTickets.BLL.Roles
{
    public class AdminService : IAdminService
    {
        private readonly INLogLogger _logger;
        private readonly ISessionManager _sessionManager;
        private readonly IUserManager _userManager;
        private readonly ICinemaManager _cinemaManager;
        private readonly IStatisticsFilm _statisticsFilm;

        public AdminService(ICinemaManager cinemaManager, ISessionManager sessionManager, IUserManager userManager,
            IStatisticsFilm statisticsFilm, INLogLogger logger)
        {
            _sessionManager = sessionManager;
            _userManager = userManager;
            _cinemaManager = cinemaManager;
            _statisticsFilm = statisticsFilm;
            _logger = logger;
        }

        public void CreateSession(CreateSessionInputModel session, int cinemaId, int userId)
        {
            var cinemaBll = _cinemaManager.GetCinemaByHallId(session.HallId);
            var userBll = _userManager.GetUserById(userId);

            if (cinemaBll.Id == cinemaId || userBll.UserStatus == UserStatus.MainAdminService)
            {
                _sessionManager.CreateSession(session);
            }
            else
            {
                _logger.Warn($"UserId: {userId} tried to create a session not in your cinema");

                throw new SessionException(205);
            }
        }

        public void DeleteSession(int sessionId)
        {
            _sessionManager.DeleteSession(sessionId);
        }

        public List<UserBLL> GetAllUsers()
        {
            var allUsers = _userManager.GetAllUsers();

            return allUsers;
        }

        public List<UserBLL> GetAllCashiers()
        {
            var allUsers = _userManager.GetAllCashiers();

            return allUsers;
        }

        public UserBLL CreateNewCashier(CreateCashierInputModel newUser)
        {
            var res = _userManager.CreateNewCashier(newUser);

            return res;
        }

        public void DeleteCashierById(int id)
        {
            _userManager.DeleteCashierById(id);
        }

        public StatisticsFilm_OutputModels GetStatisticsByFilm(StatisticsFilm_InputModels infoForStatic, int cinemaId)
        {
            StatisticsFilm_OutputModels outputStat = new StatisticsFilm_OutputModels();
            DateOnly dateStart = DateOnly.Parse(infoForStatic.DataStart);
            DateOnly dateEnd = DateOnly.Parse(infoForStatic.DataEnd);


            outputStat.TotalAmountTickets = _statisticsFilm.AmountTicketsOnFilmInCinema(cinemaId, infoForStatic.FilmId, dateStart, dateEnd);
            outputStat.PurchasedTickets = _statisticsFilm.PurchasedTicketsOnFilmInCinema(cinemaId, infoForStatic.FilmId, dateStart, dateEnd);
            outputStat.NotPurchasedTickets = _statisticsFilm.NotPurchasedTicketsOnFilmInCinema(cinemaId, infoForStatic.FilmId, dateStart, dateEnd);
            outputStat.BoxOfficeOnFilm = _statisticsFilm.BoxOfficeOnFilmInCinema(cinemaId, infoForStatic.FilmId, dateStart, dateEnd);

            return outputStat;
        }
    }
}
