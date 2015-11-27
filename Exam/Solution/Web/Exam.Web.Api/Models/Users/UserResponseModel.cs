namespace Exam.Web.Api.Models.Users
{
    using System.Linq;
    using AutoMapper;
    using Data.Models;
    using Infrastructure.Mappings;

    public class UserResponseModel : IMapFrom<User>, IHaveCustomMappings
    {
        public string UserName { get; set; }

        public int RealEstates { get; set; }

        public int Comments { get; set; }

        public float Rating { get; set; }
    
        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<User, UserResponseModel>()
               .ForMember(u => u.UserName, opts => opts.MapFrom(u => u.UserName))
               .ForMember(u => u.RealEstates, opts => opts.MapFrom(u => u.RealEstates.Count))
               .ForMember(u => u.Comments, opts => opts.MapFrom(u => u.Comments.Count))
               .ForMember(e => e.Rating, opts => opts.MapFrom(e => e.Ratings.Any() ? e.Ratings.Average(r => (float)r.Value) : 0.0f));
        }
    }
}