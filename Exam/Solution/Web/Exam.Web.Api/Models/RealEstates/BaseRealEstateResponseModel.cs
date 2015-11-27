namespace Exam.Web.Api.Models.RealEstates
{
    using AutoMapper;
    using Data.Models;
    using Infrastructure.Mappings;

    public class BaseRealEstateResponseModel : IMapFrom<RealEstate>, IHaveCustomMappings
    {
        public int Id { get;set; }

        public string Title { get;set; }
       
        public decimal? SellingPrice { get;set; }

        public decimal? RentingPrice { get;set; }

        public bool CanBeSold { get;set; } 

        public bool CanBeRented { get;set; }

        public virtual void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<RealEstate, BaseRealEstateResponseModel>()
                .ForMember(re => re.Title, opts => opts.MapFrom(re => re.Title))
                .ForMember(re => re.SellingPrice, opts => opts.MapFrom(re => re.SellingPrice))
                .ForMember(re => re.RentingPrice, opts => opts.MapFrom(re => re.RentingPrice))
                .ForMember(re => re.CanBeSold, opts => opts.MapFrom(re => re.CanBeSold))
                .ForMember(re => re.CanBeRented, opts => opts.MapFrom(re => re.CanBeRented));
        }
    }
}