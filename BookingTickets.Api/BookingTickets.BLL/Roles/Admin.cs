using BookingTickets.BLL.CustomException;
using BookingTickets.BLL.InterfacesBll;
using BookingTickets.BLL.Models;
using BookingTickets.BLL.Models.InputModel.All_Session_InputModel;
using BookingTickets.BLL.Models.InputModel.All_Statistics_InputModels;
using BookingTickets.BLL.Models.InputModel.All_User_InputModel;
using BookingTickets.BLL.Models.OutputModel.All_Statistics_OutputModels;
using BookingTickets.BLL.Statistics;
using Core;
using BookingTickets.BLL.Models.All_StatisticBLLModels;
using BookingTickets.BLL.Models.All_UserBLLModels;
using BookingTickets.BLL.Statistics;
using BookingTickets.DAL.Models;

namespace BookingTickets.BLL.Roles
{
    public class Admin : IAdmin
    {
        private readonly SessionManager _sessionManager;
        private readonly UserManager _userManager;
        private readonly CinemaManager _cinemaManager;
        private readonly Statistics_Film _statisticsFilm;
        private readonly Statistics_Days _statisticDays;
        private readonly Statistics_Cashiers _statisticCashiers;

        public Admin()
        {
            _sessionManager = new SessionManager();
            _userManager = new UserManager();
            _cinemaManager = new CinemaManager();
            _statisticsFilm = new Statistics_Film();
            _statisticDays = new Statistics_Days();
            _statisticCashiers = new Statistics_Cashiers();
        }

        public void CreateSession(CreateSessionInputModel session, int cinemaId, int userId)
        {
            var cinemaBll = _cinemaManager.GetCinemaByHallId(session.HallId);
            var userBll = _userManager.GetUserById(userId);

            if (cinemaBll.Id == cinemaId || userBll.UserStatus == UserStatus.MainAdmin)
            {
                _sessionManager.CreateSession(session);
            }
            else
            {
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

        public UserBLL UpdateCashier(UpdateCashierInputModel user)
        {
            var res = _userManager.UpdateCashier(user);

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

        public void CopySession(DateTime dateCopy, DateTime dateWhereToCopy, int CinemaId)
        {
            _userManager.CopySession(dateCopy, dateWhereToCopy, CinemaId);
        }

        public List<StatisticOfDaysOutputModel> StatisticOfDays(StatisticOfDaysInputModel inputModel)
        {
            var res = _statisticDays.StatisticOfDays(inputModel);
            return res;
        }

        public List<StatisticOfCashiersOutputModel> StatisticOfCashiers(StatisticOfCashiersInputModel inputModel)
        {
            var res = _statisticCashiers.StatisticOfCashiers(inputModel);
            return res;
        }
    }
}
