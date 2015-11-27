namespace Exam.Web.Wcf
{
    using System.Collections.Generic;
    using System.Linq;
    using System.ServiceModel;
    using Models;

    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class Users : BaseService, IUsers
    {
        public IEnumerable<UserModel> GetTop()
        {

            return this.Users
                .All()
                .Select(u => new UserModel
                {
                    Id = u.Id,
                    Username = u.Email,
                    Comments = u.Comments.Count,
                    RealEstates = u.RealEstates.Count,
                    Rating = (u.Ratings.Any() ? u.Ratings.Average(re => (float)re.Value) : 0)
                })
                .OrderByDescending(u => u.Rating)
                .Take(10)
                .ToList();
        }
    }
}
