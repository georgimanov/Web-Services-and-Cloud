namespace Exam.Web.Wcf
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.ServiceModel;
    using Models;

    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class Users : BaseService, IUsers
    {
        public IEnumerable<UserModel> GetAll(string page)
        {
            var pageAsNumber = int.Parse(page);

            return this.Users
                .All()
                .OrderBy(u => u.UserName)
                .Skip(pageAsNumber * 10)
                .Take(pageAsNumber)
                .Select(u => new UserModel
                {
                    Id = u.Id,
                    Username = u.Email
                })
                .ToList();
        }
    }
}
