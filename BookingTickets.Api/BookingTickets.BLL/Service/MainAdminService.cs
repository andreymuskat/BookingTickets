using BookingTickets.BLL.InterfacesBll;
using BookingTickets.BLL.InterfacesBll.Service_Interfaces;
using BookingTickets.BLL.Models;
using BookingTickets.BLL.Models.All_Seat_InputModel;
using BookingTickets.BLL.Models.InputModel.All_Hall_InputModels;
using BookingTickets.BLL.Models.InputModel.All_Statistics_InputModels;
using BookingTickets.BLL.Models.OutputModel.All_Statistics_OutputModels;
using BookingTickets.Core.CustomException;
using Core.Status;

namespace BookingTickets.BLL.Roles
{
    public class MainAdminService : IMainAdminService
    {
        private readonly IFilmManager _filmManager;
        private readonly ICinemaManager _cinemaManager;
        private readonly ISeatManager _seatManager;
        private readonly IHallManager _hallManager;
        private readonly IUserManager _userManager;
        private readonly IStatisticsFilm _statisticsFilm;

        public MainAdminService(ICinemaManager cinemaManager, IUserManager userManager, IStatisticsFilm statisticsFilm,
            IFilmManager filmManager, ISeatManager seatManager, IHallManager hallManager)
        {
            _filmManager = filmManager;
            _cinemaManager = cinemaManager;
            _seatManager = seatManager;
            _hallManager = hallManager;
            _userManager = userManager;
            _statisticsFilm = statisticsFilm;
        }

        public void CreateNewFilm(FilmBLL newFilm)
        {
            _filmManager.CreateNewFilm(newFilm);
        }

        public void CreateCinema(CinemaBLL newCinema)
        {
            _cinemaManager.CreateCinema(newCinema);
        }

        public void DeleteCinema(int cinemaId)
        {
            _cinemaManager.DeleteCinema(cinemaId);
        }

        public void CreateHall(CreateAndUpdateHallInputModel hall)
        {
            _hallManager.CreateHall(hall);
        }

        public void DeleteHall(int hallId)
        {
            _hallManager.DeleteHall(hallId);
        }

        public void AddRowToHall(AddSeatsRowsInputModel rowSeats)
        {
            _seatManager.AddRowToHall(rowSeats);
        }

        public void ChangeUserStatus(UserStatus status, int userId)
        {
            _userManager.ChangeUserStatus(status, userId);
        }

        public void DeleteFilm(int filmId)
        {
            _filmManager.DeleteFilm(filmId);
        }

        public void EditFilm(FilmBLL newFilm, int idFilm)
        {
            _filmManager.EditFilm(newFilm, idFilm);
        }

        public void EditCinema(CinemaBLL newCinema, int cinemaId)
        {
            _cinemaManager.EditCinema(newCinema, cinemaId);
        }

        public void EditHall(CreateAndUpdateHallInputModel newHall, int hallId)
        {
            _hallManager.EditHall(newHall, hallId);
        }

        public StatisticsFilm_OutputModels GetStatisticsByFilm(StatisticsFilm_InputModels infoForStatic)
        {
            StatisticsFilm_OutputModels outputStat = new StatisticsFilm_OutputModels();
            DateOnly dateStart = DateOnly.Parse(infoForStatic.DataStart);
            DateOnly dateEnd = DateOnly.Parse(infoForStatic.DataEnd);
            List<CinemaBLL> cinemaBLL = _cinemaManager.GetAllCinema();

            for (int i = 0; i < cinemaBLL.Count; i++)
            {
                var cinemaId = cinemaBLL[i].Id;

                outputStat.TotalAmountTickets += _statisticsFilm.AmountTicketsOnFilmInCinema(cinemaId, infoForStatic.FilmId, dateStart, dateEnd);
                outputStat.PurchasedTickets += _statisticsFilm.PurchasedTicketsOnFilmInCinema(cinemaId, infoForStatic.FilmId, dateStart, dateEnd);
                outputStat.NotPurchasedTickets += _statisticsFilm.NotPurchasedTicketsOnFilmInCinema(cinemaId, infoForStatic.FilmId, dateStart, dateEnd);
                outputStat.BoxOfficeOnFilm += _statisticsFilm.BoxOfficeOnFilmInCinema(cinemaId, infoForStatic.FilmId, dateStart, dateEnd);
            }

            return outputStat;
        }
    }
}