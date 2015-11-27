namespace Exam.Commmon.Providers
{
    public interface IRandomProvider
    {
        int GetRandomNumber(int min, int max);
    }
}