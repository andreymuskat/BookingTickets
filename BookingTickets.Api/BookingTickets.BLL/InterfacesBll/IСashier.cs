﻿using BookingTickets.BLL.Models;
using BookingTickets.BLL.Models.All_OrderBLLModel;
using Core;

namespace BookingTickets.BLL.InterfacesBll
{
    public interface IСashier
    {
        public FilmBLL GetFilmById(int filmId); /*+*/


        public List <OrderBLL> FindOrderByCodeNumber(string codeNumber); /*+*/

        public void CreateOrderByCashier(CreateOrderInputModel order, int requestedCinemaId, int cinemaId, string name); /*+*/


        public SessionBLL GetSessionById(int idSession); /*+*/
        public void EditOrderStatus(OrderStatus status, string code, int cinemaId); /*+ ПРОВЕРИТЬ ЧТО ЭТО ЕГО КИНОТЕАТР*/
        public List<SessionBLL> GetSessionsInHisCinema(UserBLL userId);
        public List<SessionBLL> GetSessionsByFilmInHisCinema(int idFilm, int cashiersCinemaId);

        public List<SeatBLL> GetFreeSeatsBySessionInHisCinema(int sessionId, int cashiersCinemaId);
    }
}
