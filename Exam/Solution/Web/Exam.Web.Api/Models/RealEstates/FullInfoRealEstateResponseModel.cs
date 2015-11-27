namespace Exam.Web.Api.Models.RealEstates
{
    using System;
    using AutoMapper;
    using Data.Models;
    using Infrastructure.Mappings;

    public class FullInfoRealEstateResponseModel : BaseRealEstateResponseModel, IMapFrom<RealEstate>, IHaveCustomMappings
    {
        public DateTime CreatedOn { get; set; }
         
        public int? ConstructionYear { get; set; }

        public string Address { get; set; }

        public string RealEstateType { get; set; }

        public string Description { get; set; }

        public override void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<RealEstate, FullInfoRealEstateResponseModel>()
               .ForMember(re => re.CreatedOn, opts => opts.MapFrom(re => re.DateCreated))
               .ForMember(re => re.ConstructionYear, opts => opts.MapFrom(re => re.ConstructionYear))
               .ForMember(re => re.Address, opts => opts.MapFrom(re => re.Address))
               .ForMember(re => re.RealEstateType, opts => opts.MapFrom(re => re.RealEstateType.ToString()))
               .ForMember(re => re.Description, opts => opts.MapFrom(re => re.Description));

            base.CreateMappings(configuration);
        }
    }
}