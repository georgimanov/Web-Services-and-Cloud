namespace Exam.Web.Wcf
{
    using System.Collections.Generic;
    using System.ServiceModel;
    using System.ServiceModel.Web;
    using Models;

    [ServiceContract]
    public interface IUsers
    {
        [OperationContract]
        [WebInvoke(Method = "Get", UriTemplate = "users/top.svc")]
        IEnumerable<UserModel> GetTop();
    }
}
