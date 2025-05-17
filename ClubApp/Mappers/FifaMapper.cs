using AutoMapper;
using ClubApp.DTOs.Players;
using ClubApp.Models;

namespace ClubApp.Mappers
{
    public class FifaMapper : Profile
    {
        public FifaMapper()
        {
            CreateMap<Player, PlayerDto>();
            CreateMap<PlayerDto, Player>();
            CreateMap<AddingFixedPlayersDTO, PlayerDto>();
            CreateMap<PlayerDto, AddingFixedPlayersDTO>();
            CreateMap<AddingFixedPlayersDTO, Player>();
            CreateMap<Player, AddingFixedPlayersDTO>();
        }
    }
}
