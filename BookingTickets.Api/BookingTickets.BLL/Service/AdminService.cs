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
        private readonly IStatisticsDays _statisticsDays;
        private readonly IStatisticsCashiers _statisticsCashiers;

        public AdminService(ICinemaManager cinemaManager, ISessionManager sessionManager, IUserManager userManager,
            IStatisticsFilm statisticsFilm, INLogLogger logger, IStatisticsDays statisticsDays, IStatisticsCashiers statisticsCashiers)
        {
            _sessionManager = sessionManager;
            _userManager = userManager;
            _cinemaManager = cinemaManager;
            _statisticsFilm = statisticsFilm;
            _statisticsDays = statisticsDays;
            _statisticsCashiers = statisticsCashiers;
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

        public List<UserBLL> GetAllCashiers(int adminCinemaId)
        {
            var allCashiers = _userManager.GetAllCashiers();

            var allCashiersInCinema = allCashiers.Where(k => k.Cinema.Id == adminCinemaId).ToList();

            if (allCashiers != null)
            {
                return allCashiersInCinema;
            }
            else
            {
                throw new UserExceptions(777);
            }
        }

        public void CreateNewCashier(int cashierId, int adminCinemaId)
        {
            var cashier = _userManager.GetCashierById(cashierId);

            if(cashier != null) 
            { 
                _userManager.ChangeUserStatus(UserStatus.CashierService, cashierId);
                _userManager.ChangeUserCinemaId(adminCinemaId, cashierId);
            }
            else
            {
                throw new UserExceptions(777);
            }
        }

        public void DeleteCashierById(int id, int adminCinemaId)
        {
            _userManager.DeleteCashierById(id, adminCinemaId);
        }

        public UserBLL UpdateCashier(UpdateCashierInputModel user, int cashierId)
        {
            var res = _userManager.UpdateCashier(user, cashierId);

            return res;
        }

        public void CopySession(DateTime dateCopy, DateTime dateWhereToCopy, int cinemaId)
        {
            _sessionManager.CopySession(dateCopy, dateWhereToCopy, cinemaId);
        }

        public List<StatisticDays_OutputModel> StatisticOfDays(StatisticDays_InputModel inputModel)
        {
            var res = _statisticsDays.StatisticOfDays(inputModel);
            return res;
        }

        public List<StatisticCashiers_OutputModel> StatisticOfCashiers(StatisticCashiers_InputModel inputModel)
        {
            var res = _statisticsCashiers.StatisticOfCashiers(inputModel);
            return res;
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
