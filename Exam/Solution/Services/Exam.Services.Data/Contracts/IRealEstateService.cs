namespace Exam.Services.Data.Contracts
{
    using System.Linq;
    using Exam.Data.Models;

    public interface IRealEstateService
    {
        IQueryable<RealEstate> GetPublicRealEstates(int skip = 0, int take = 10);

        RealEstate CreateRealEstate(string title, string description, string address, string contact, int constructionYear, decimal? sellingPrice, decimal? rentingPrice, int realEstateType, string userId);

        IQueryable<RealEstate> GetRealEstateDetails(int id);
    }
}
