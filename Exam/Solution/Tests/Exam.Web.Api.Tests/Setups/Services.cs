namespace Exam.Web.Api.Tests.Setups
{
    using Exam.Services.Data;
    using Exam.Services.Data.Contracts;

    public static class Services
    {
        public static IRealEstateService GetRealEstatesService()
        {
            return new RealEstateService(Repositories.GetRealEstatesRepository());
        }

        public static ICommentsService GetCommentsService()
        {
            return new CommentsService(Repositories.GetCommentsRepository());
        }
    }
}
