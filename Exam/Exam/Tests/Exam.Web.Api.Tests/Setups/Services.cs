namespace Exam.Web.Api.Tests.Setups
{
    using Exam.Services.Data;
    using Exam.Services.Data.Contracts;

    public static class Services
    {
        public static IGamesService GetGamesService()
        {
            return new GamesService(Repositories.GetGamesRepository());
        } 
    }
}
