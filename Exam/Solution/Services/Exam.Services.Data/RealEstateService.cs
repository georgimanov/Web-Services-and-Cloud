namespace Exam.Services.Data
{
    using System.Linq;
    using Exam.Data.Models;
    using Contracts;
    using Exam.Data.Repositories;
    using System;

    public class RealEstateService : IRealEstateService
    {
        private IRepository<RealEstate> realEstates;

        public RealEstateService(IRepository<RealEstate> realEstates)
        {
            this.realEstates = realEstates;
        }

        public IQueryable<RealEstate> GetPublicRealEstates(int skip = 0, int take = 10)
        {
            return this.realEstates
                .All()
                .OrderByDescending(re => re.DateCreated)
                .Skip(skip)
                .Take(take);
        }

        public RealEstate CreateRealEstate(string title, string description, string address, string contact, int constructionYear, decimal? sellingPrice, decimal? rentingPrice, int realEstateType, string userId)
        {
            var newRealEstate = new RealEstate
            {
                Title = title,
                Description = description,
                Address = address, 
                Contact = contact, 
                ConstructionYear = constructionYear, 
                SellingPrice = sellingPrice, 
                RentingPrice = rentingPrice, 
                RealEstateType = (RealEstateType)realEstateType,
                DateCreated = DateTime.UtcNow,
                CanBeRented = rentingPrice.HasValue ? true : false,
                CanBeSold = sellingPrice.HasValue ? true : false,
                UserId = userId
            };

            this.realEstates.Add(newRealEstate);
            this.realEstates.SaveChanges();

            return newRealEstate;
        }

         

        public IQueryable<RealEstate> GetRealEstateDetails(int id)
        {
            return this.realEstates.All().Where(g => g.Id == id);
        }        
    }
}
