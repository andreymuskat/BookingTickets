﻿using AutoMapper;
using BookingTickets.API.Model.RequestModels;
using BookingTickets.BLL.Models.InputModels;
using BookingTickets.BLL.Models.OutputModels;

namespace BookingTickets.API
{
    public class MapperAPI
    {
        private readonly MapperAPI _mapper = new();
        private readonly MapperConfiguration _configuration;

        public MapperAPI()
        {
            _configuration = new MapperConfiguration(
                cfg =>
                {
                    cfg.CreateMap<FilmBLL, FilmResponseModel>();
                    cfg.CreateMap<FilmRequestModel, FilmBLL>();
                    cfg.CreateMap<CinemaRequestModel, CinemaBLL>();
                });
        }

        public List<FilmResponseModel> MapListFilmBLLToListFilmResponseModel(List<FilmBLL> film)
        {
            return _configuration.CreateMapper().Map<List<FilmResponseModel>>(film);
        }
        
        public FilmBLL MapFilmRequestModelToFilmBLL(FilmRequestModel film)
        {
            return _configuration.CreateMapper().Map<FilmBLL>(film);
        }

        public FilmInputModel MapFilmRequestModelToFilmInputModel(FilmRequestModel film)
        {
            return _configuration.CreateMapper().Map<FilmInputModel>(film);
        }

        public CinemaBLL MapCinemaRequestModelToCinemaBLL(CinemaRequestModel model)
        {
            return _configuration.CreateMapper().Map<CinemaBLL>(model);
        }
    }
}
