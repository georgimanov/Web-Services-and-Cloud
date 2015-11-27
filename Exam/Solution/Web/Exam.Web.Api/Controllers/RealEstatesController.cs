namespace Exam.Web.Api.Controllers
{
    using AutoMapper.QueryableExtensions;
    using System.Linq;
    using System.Web.Http;
    using Services.Data.Contracts;
    using Microsoft.AspNet.Identity;
    using Infrastructure.Validation;
    using AutoMapper;
    using System.Net.Http;
    using System.Net;
    using Models.RealEstates;

    public class RealEstatesController : ApiController
    {
        private IRealEstateService realEstates;

        public RealEstatesController(IRealEstateService realEstates)
        {
            this.realEstates = realEstates;
        }

        public IHttpActionResult Get([FromUri]int skip = 0, [FromUri]int take = 10)
        {
            if (skip < 0 || take < 0)
            {
                return this.BadRequest("Cannot provide negative values!");
            }

            if (take >= 100)
            {
                take = 100;
            }

            var realEstates = this.realEstates.GetPublicRealEstates(skip, take)
                .ProjectTo<BaseRealEstateResponseModel>()
                .ToList();

            return this.Ok(realEstates);
        }

        public IHttpActionResult Get(int id)
        {

           var realEstates = this.realEstates.GetRealEstateDetails(id)
                .ProjectTo<FullInfoRealEstateResponseModel>()
                .ToList();

            return this.Ok(realEstates);
        }

        [Authorize]
        [ValidateModel]
        public IHttpActionResult Post(CreateRealEstateRequestModel model)
        {
            var realEstate = this.realEstates.CreateRealEstate(
                 model.Title,
                 model.Description,
                 model.Address,
                 model.Contact,model.ConstructionYear, 
                 model.SellingPrice, 
                 model.RentingPrice,
                 model.RealEstateType,
                 this.User.Identity.GetUserId());

            var realEstateResult = this.realEstates
                .GetRealEstateDetails(realEstate.Id)
                .ProjectTo<BaseRealEstateResponseModel>()
                .FirstOrDefault();

            var location = string.Format("api/realestates/{0}", realEstate.Id);

            return this.Created(location, realEstateResult);
        }
    }
}