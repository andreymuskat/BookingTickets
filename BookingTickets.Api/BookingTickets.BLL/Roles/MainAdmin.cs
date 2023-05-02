using BookingTickets.BLL.Models;
using BookingTickets.BLL.Models.All_Seat_InputModel;
using BookingTickets.BLL.Models.InputModel.All_Hall_InputModels;
using BookingTickets.BLL.Models.InputModel.All_Statistics_InputModels;
using BookingTickets.BLL.Models.InputModel.All_User_InputModel;
using BookingTickets.BLL.Models.OutputModel.All_Statistics_OutputModels;
using BookingTickets.BLL.NewFolder;
using BookingTickets.BLL.Statistics;
using Core;

namespace BookingTickets.BLL.Roles
{
    public class MainAdmin : IMainAdmin
    {
        private MapperBLL _instanceMapperBll = MapperBLL.getInstance();
        private readonly FilmManager _filmManager;
        private readonly CinemaManager _cinemaManager;
        private readonly SeatManager _seatManager;
        private readonly HallManager _hallManager;
        private readonly UserManager _userManager;
        private readonly Statistics_Film _statisticsFilm;

        public MainAdmin()
        {
            _filmManager = new FilmManager();
            _cinemaManager = new CinemaManager();
            _seatManager = new SeatManager();
            _hallManager = new HallManager();
            _userManager = new UserManager();
            _statisticsFilm = new Statistics_Film();
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