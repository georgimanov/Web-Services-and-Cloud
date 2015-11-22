namespace Exam.Web.Api.Models.Games
{
    using System;
    using AutoMapper;
    using Data.Models;
    using Infrastructure.Mappings;

    public class PublicGameResponseModel : IMapFrom<Game>, IHaveCustomMappings
    {
        public int Id
        {
            get;
            set;
        }

        public string Name
        {
            get; set;
        }

        public string Blue
        {
            get; set;
        }

        public string Red
        {
            get; set;
        }

        public string GameState
        {
            get; set;
        }

        public DateTime DateCreated
        {
            get; set;
        }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Game, PublicGameResponseModel>()
                .ForMember(g => g.Blue, opts => opts.MapFrom(g => g.BlueUser == null ? "No blue player yet!" : g.BlueUser.Email));
        }
    }
}