using AutoMapper;
using ClubApp.Models;
using ClubApp.Models.DTOs.Players;

namespace ClubApp.Mappers
{
    public class FifaMapper : Profile
    {
        public FifaMapper()
        {
            CreateMap<Player, PlayerDto>().ReverseMap();
        }
    }
}
