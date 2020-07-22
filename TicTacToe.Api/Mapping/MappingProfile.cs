using AutoMapper;
using TicTacToe.Api.Resources;
using TicTacToe.Core.Models;

namespace MyMusic.Api.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Domain to Resource
            CreateMap<Game, GameResource>();

            // Resource to Domain
            CreateMap<GameResource, Game>();

            CreateMap<GameMovement, GameMovementResource>();

            CreateCreateMovementProfile();
        }

        private void CreateCreateMovementProfile()
        {
            CreateMap<CreateGameMovementResource, GameMovement>()
                .ForMember(dest =>
                   dest.PositionX,
                    opt => opt.MapFrom(src => src.position.x))
                .ForMember(dest =>
                   dest.PositionX,
                    opt => opt.MapFrom(src => src.position.y))
                .ForMember(dest =>
                   dest.GameId,
                    opt => opt.MapFrom(src => src.Id))
                .ForMember(dest =>
                   dest.Id,
                    opt => opt.MapFrom(src => src.movId))
                .ForMember(dest =>
                   dest.Player,
                    opt => opt.MapFrom(src => src.Player));

        }
    }
}