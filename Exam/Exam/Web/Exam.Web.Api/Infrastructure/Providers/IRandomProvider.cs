namespace Exam.Web.Api.Infrastructure.Providers
{
    public interface IRandomProvider
    {
        int GetRandomNumber(int min, int max);
    }
}